using System;
using System.Collections.Generic;
using System.Diagnostics;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.Domains.Map;
using HarmonyLib;

namespace TaiwuOptimization.Runtime;

internal static class DelayMonthRuntime
{
    private const int AreaCount = 141;
    private const int StateAreaCount = 135;
    private const int SkeletonAreaCount = 45;

    private enum JobDrainMode
    {
        All,
        Area,
        AreaSet,
    }

    private static readonly object _syncRoot = new();
    private static readonly Queue<DelayedMonthJob> _pendingJobs = new(512);
    private static readonly HashSet<int> _liveSynchronousAreaIds = new();
    private static readonly Dictionary<int, int> _pendingJobCountsByArea = new();

    private static Action<DataContext, int, ICharacterParallelAction>? _executeCharacterAreaAction;
    private static bool _advancingMonth;
    private static bool _replaying;
    private static bool _saveAfterFlush;
    private static short _liveSynchronousAreaSource = -1;
    private static bool _liveSynchronousAreaIncludesNeighbors;

    private static bool HasPendingJobs
    {
        get
        {
            lock (_syncRoot)
            {
                return _pendingJobs.Count > 0;
            }
        }
    }

    public static void Initialize()
    {
        var method = AccessTools.Method(
            typeof(ParallelActionManager),
            "OfflineExecuteCharacterActionsInArea",
            new[] { typeof(DataContext), typeof(int), typeof(ICharacterParallelAction) });
        _executeCharacterAreaAction = method.CreateDelegate<Action<DataContext, int, ICharacterParallelAction>>();
        AreaLocalMonthExecutors.Initialize();
    }

    public static void Dispose()
    {
        lock (_syncRoot)
        {
            _pendingJobs.Clear();
            InvalidateLiveSynchronousAreaCache();
            _pendingJobCountsByArea.Clear();
            _advancingMonth = false;
            _replaying = false;
            _saveAfterFlush = false;
        }
    }

    public static void BeginAdvanceMonthDelayScope(DataContext context)
    {
        FlushAllJobs(context);

        lock (_syncRoot)
        {
            InvalidateLiveSynchronousAreaCache();
            _saveAfterFlush = false;
            _advancingMonth = DelayMonthSettings.Enabled;
        }
    }

    public static void EndAdvanceMonthDelayScope()
    {
        lock (_syncRoot)
        {
            _advancingMonth = false;
        }
    }

    public static bool TryDelayCharacterAreaAction(int areaId, ICharacterParallelAction action)
    {
        if (!DelayMonthSettings.Enabled || _replaying || areaId < 0 || !ShouldDelayAction(action))
        {
            return false;
        }

        return TryEnqueueAreaJob(DelayedMonthJob.CharacterAreaAction(areaId, action));
    }

    public static bool TryDelayMapBrokenBlockUpdate(int areaId)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayBrokenBlocks || _replaying || areaId < 0)
        {
            return false;
        }

        return TryEnqueueAreaJob(DelayedMonthJob.MapBrokenBlockUpdate(areaId));
    }

    public static bool TryHandleAnimalAreaData(DataContext context)
    {
        return TryHandleAreaLoop(
            context,
            DelayMonthSettings.DelayAnimalAreaData,
            0,
            AreaCount,
            DelayedMonthJob.AnimalAreaData,
            AreaLocalMonthExecutors.ExecuteAnimalAreaData);
    }

    public static bool TryHandleSkeletonGeneration(DataContext context)
    {
        return TryHandleAreaLoop(
            context,
            DelayMonthSettings.DelaySkeletonGeneration,
            0,
            SkeletonAreaCount,
            DelayedMonthJob.SkeletonGeneration,
            AreaLocalMonthExecutors.ExecuteSkeletonGeneration);
    }

    public static bool TryDelayMapPickupCleanup(DataContext context)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayMapPickups || _replaying || !IsAdvancingMonth())
        {
            return false;
        }

        // Snapshot pickup locations at month-end so delayed replay does not touch new pickups.
        Dictionary<short, List<Location>> locationsByArea = new();
        foreach (Location location in DomainManager.Extra.PickupDict.Keys)
        {
            if (location.AreaId >= 0)
            {
                if (!locationsByArea.TryGetValue(location.AreaId, out List<Location>? locations))
                {
                    locations = new();
                    locationsByArea.Add(location.AreaId, locations);
                }

                locations.Add(location);
            }
        }

        foreach ((short areaId, List<Location> locations) in locationsByArea)
        {
            if (!TryEnqueueAreaJob(DelayedMonthJob.MapPickupCleanup(areaId, locations)))
            {
                AreaLocalMonthExecutors.ExecuteMapPickupCleanup(context, areaId, locations);
            }
        }

        return true;
    }

    public static void TickDelayedJobs(DataContext context)
    {
        if (!DelayMonthSettings.Enabled || _advancingMonth || _replaying)
        {
            return;
        }

        // Most frames have no delayed work; avoid rebuilding live sync areas then.
        if (!HasPendingJobs)
        {
            return;
        }

        FlushLiveSyncAreas(context);
        if (!HasPendingJobs)
        {
            TryRunDeferredSave(context);
            return;
        }

        long deadline = Stopwatch.GetTimestamp() + DelayMonthSettings.FrameBudgetMs * Stopwatch.Frequency / 1000;
        DelayedMonthJob? currentBatch = null;
        bool hasPendingApply = false;
        do
        {
            DelayedMonthJob? job = DequeueJob();
            if (job == null)
            {
                ApplyPending(context, ref hasPendingApply);
                TryRunDeferredSave(context);
                return;
            }

            if (hasPendingApply && currentBatch != null && (!job.RequiresParallelApply || !currentBatch.CanBatchWith(job)))
            {
                ApplyPending(context, ref hasPendingApply);
            }

            if (ExecuteJobWithoutApply(context, job))
            {
                currentBatch = job;
                hasPendingApply = true;
            }
        }
        while (Stopwatch.GetTimestamp() < deadline);

        ApplyPending(context, ref hasPendingApply);

        if (!HasPendingJobs)
        {
            TryRunDeferredSave(context);
        }
    }

    public static void FlushAreaJobs(DataContext context, short areaId)
    {
        if (areaId < 0 || _replaying)
        {
            return;
        }

        ExecuteAndMaybeSave(context, DrainJobs(JobDrainMode.Area, areaId));
    }

    public static void FlushAllJobs(DataContext context)
    {
        ExecuteAndMaybeSave(context, DrainJobs(JobDrainMode.All));
    }

    public static bool PostponeSaveUntilJobsComplete(ref bool saveWorld)
    {
        if (!saveWorld)
        {
            return false;
        }

        lock (_syncRoot)
        {
            if (_pendingJobs.Count == 0)
            {
                return false;
            }

            _saveAfterFlush = true;
            saveWorld = false;
            return true;
        }
    }

    public static void ExecuteOriginalCharacterAreaAction(DataContext context, int areaId, ICharacterParallelAction action)
    {
        if (_executeCharacterAreaAction == null)
        {
            throw new InvalidOperationException("Character area action method was not resolved.");
        }

        _executeCharacterAreaAction(context, areaId, action);
    }

    private static void AddNeighborStates(short areaId, Action<short> addArea, List<short> areaBuffer)
    {
        if (!DelayMonthSettings.SyncNeighborStates || areaId < 0 || areaId >= StateAreaCount)
        {
            return;
        }

        sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
        foreach (sbyte neighborStateTemplateId in MapState.Instance[stateTemplateId].NeighborStates)
        {
            sbyte neighborStateId = DomainManager.Map.GetStateIdByStateTemplateId(neighborStateTemplateId);
            AddAreasInState(neighborStateId, addArea, areaBuffer);
        }
    }

    private static bool IsSyncArea(int areaId) =>
        IsLiveSyncArea(areaId);

    private static bool IsLiveSyncArea(int areaId)
    {
        HashSet<int>? areaIds = GetLiveSynchronousAreaIds();
        return areaIds != null && areaIds.Contains(areaId);
    }

    private static void FlushLiveSyncAreas(DataContext context)
    {
        HashSet<int>? areaIds = GetLiveSynchronousAreaIds();
        if (areaIds == null || areaIds.Count == 0)
        {
            return;
        }

        ExecuteAndMaybeSave(context, DrainJobs(JobDrainMode.AreaSet, areaSet: areaIds));
    }

    private static bool ShouldDelayAction(ICharacterParallelAction action)
    {
        Type type = action.GetType();
        if (type == typeof(CharacterSelfImprovement) ||
            type == typeof(CharacterSelfImprovement_LearnNewSkills) ||
            type == typeof(CharacterSelfImprovement_Reading) ||
            type == typeof(CharacterSelfImprovement_PracticeAndBreakout) ||
            type == typeof(CharacterPreparation_GetSupply))
        {
            return true;
        }

        if (DelayMonthSettings.DelayEquipment &&
            type == typeof(CharacterPreparation_CombatSkillAndItemEquipping))
        {
            return true;
        }

        if (DelayMonthSettings.DelayMissionGoal &&
            (type == typeof(UpdateCharacterMission) || type == typeof(UpdateCharacterGoal)))
        {
            return true;
        }

        if (DelayMonthSettings.DelayLoseOverloadItems &&
            type == typeof(CharacterPreparation_LoseOverloadItems))
        {
            return true;
        }

        return false;
    }

    private static DelayedMonthJob? DequeueJob()
    {
        lock (_syncRoot)
        {
            if (_pendingJobs.Count == 0)
            {
                return null;
            }

            DelayedMonthJob job = _pendingJobs.Dequeue();
            DecrementJobCount(job.AreaId);
            return job;
        }
    }

    private static List<DelayedMonthJob> DrainJobs(
        JobDrainMode mode,
        int areaId = -1,
        HashSet<int>? areaSet = null)
    {
        List<DelayedMonthJob> selected = new();
        lock (_syncRoot)
        {
            if (_pendingJobs.Count == 0 ||
                (mode == JobDrainMode.Area && !_pendingJobCountsByArea.ContainsKey(areaId)) ||
                (mode == JobDrainMode.AreaSet && !HasPendingJobInAreaSet(areaSet)))
            {
                return selected;
            }

            int count = _pendingJobs.Count;
            for (int i = 0; i < count; i++)
            {
                DelayedMonthJob job = _pendingJobs.Dequeue();
                if (ShouldDrainJob(job, mode, areaId, areaSet))
                {
                    selected.Add(job);
                    DecrementJobCount(job.AreaId);
                }
                else
                {
                    _pendingJobs.Enqueue(job);
                }
            }
        }

        return selected;
    }

    private static bool ShouldDrainJob(
        DelayedMonthJob job,
        JobDrainMode mode,
        int areaId,
        HashSet<int>? areaSet)
    {
        return mode switch
        {
            JobDrainMode.All => true,
            JobDrainMode.Area => job.AreaId == areaId,
            JobDrainMode.AreaSet => areaSet != null && areaSet.Contains(job.AreaId),
            _ => false,
        };
    }

    private static bool HasPendingJobInAreaSet(HashSet<int>? areaSet)
    {
        if (areaSet == null || areaSet.Count == 0)
        {
            return false;
        }

        foreach (int areaId in areaSet)
        {
            if (_pendingJobCountsByArea.ContainsKey(areaId))
            {
                return true;
            }
        }

        return false;
    }

    private static void ExecuteAndMaybeSave(DataContext context, List<DelayedMonthJob> jobs)
    {
        if (jobs.Count > 0)
        {
            ExecuteJobsBatched(context, jobs);
        }

        if (!HasPendingJobs)
        {
            TryRunDeferredSave(context);
        }
    }

    private static void EnqueueJob(DelayedMonthJob job)
    {
        _pendingJobs.Enqueue(job);
        _pendingJobCountsByArea.TryGetValue(job.AreaId, out int count);
        _pendingJobCountsByArea[job.AreaId] = count + 1;
    }

    private static void DecrementJobCount(int areaId)
    {
        int count = _pendingJobCountsByArea[areaId] - 1;
        if (count <= 0)
        {
            _pendingJobCountsByArea.Remove(areaId);
        }
        else
        {
            _pendingJobCountsByArea[areaId] = count;
        }
    }

    private static void ExecuteJobsBatched(DataContext context, List<DelayedMonthJob> jobs)
    {
        DelayedMonthJob? currentBatch = null;
        bool hasPendingApply = false;
        foreach (DelayedMonthJob job in jobs)
        {
            if (hasPendingApply && currentBatch != null && (!job.RequiresParallelApply || !currentBatch.CanBatchWith(job)))
            {
                ApplyPending(context, ref hasPendingApply);
            }

            if (ExecuteJobWithoutApply(context, job))
            {
                currentBatch = job;
                hasPendingApply = true;
            }
        }

        ApplyPending(context, ref hasPendingApply);
    }

    private static bool ExecuteJobWithoutApply(DataContext context, DelayedMonthJob job)
    {
        _replaying = true;
        try
        {
            job.Execute(context);
            return job.RequiresParallelApply;
        }
        finally
        {
            _replaying = false;
        }
    }

    private static void ApplyPending(DataContext context, ref bool hasPendingApply)
    {
        if (!hasPendingApply)
        {
            return;
        }

        context.ParallelModificationsRecorder.ApplyAll(context);
        hasPendingApply = false;
    }

    private static void TryRunDeferredSave(DataContext context)
    {
        lock (_syncRoot)
        {
            if (!_saveAfterFlush || _pendingJobs.Count > 0)
            {
                return;
            }

            _saveAfterFlush = false;
        }

        DomainManager.Global.SaveWorld(context);
    }

    private static bool TryHandleAreaLoop(
        DataContext context,
        bool settingEnabled,
        int startAreaId,
        int endAreaId,
        Func<int, DelayedMonthJob> createJob,
        Action<DataContext, int> executeSync)
    {
        if (!DelayMonthSettings.Enabled || !settingEnabled || _replaying || !IsAdvancingMonth())
        {
            return false;
        }

        for (int areaId = startAreaId; areaId < endAreaId; areaId++)
        {
            if (!TryEnqueueAreaJob(createJob(areaId)))
            {
                executeSync(context, areaId);
            }
        }

        return true;
    }

    private static bool TryEnqueueAreaJob(DelayedMonthJob job)
    {
        lock (_syncRoot)
        {
            if (!_advancingMonth || IsSyncArea(job.AreaId))
            {
                return false;
            }

            EnqueueJob(job);
            return true;
        }
    }

    private static bool IsAdvancingMonth()
    {
        lock (_syncRoot)
        {
            return _advancingMonth;
        }
    }

    private static HashSet<int>? GetLiveSynchronousAreaIds()
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            InvalidateLiveSynchronousAreaCache();
            return null;
        }

        bool includeNeighborStates = DelayMonthSettings.SyncNeighborStates;
        if (_liveSynchronousAreaSource == location.AreaId &&
            _liveSynchronousAreaIncludesNeighbors == includeNeighborStates)
        {
            return _liveSynchronousAreaIds;
        }

        _liveSynchronousAreaIds.Clear();
        AddLiveSyncAreas(areaId => _liveSynchronousAreaIds.Add(areaId));
        _liveSynchronousAreaSource = location.AreaId;
        _liveSynchronousAreaIncludesNeighbors = includeNeighborStates;
        return _liveSynchronousAreaIds;
    }

    private static void InvalidateLiveSynchronousAreaCache()
    {
        _liveSynchronousAreaIds.Clear();
        _liveSynchronousAreaSource = -1;
        _liveSynchronousAreaIncludesNeighbors = false;
    }

    private static void AddLiveSyncAreas(Action<short> addArea)
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return;
        }

        addArea(location.AreaId);
        if (location.AreaId < 0 || location.AreaId >= StateAreaCount)
        {
            return;
        }

        sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
        List<short> areaBuffer = new(16);
        AddAreasInState(stateId, addArea, areaBuffer);
        AddNeighborStates(location.AreaId, addArea, areaBuffer);
    }

    private static void AddAreasInState(sbyte stateId, Action<short> addArea, List<short> areaBuffer)
    {
        if (stateId < 0)
        {
            return;
        }

        areaBuffer.Clear();
        DomainManager.Map.GetAllAreaInState(stateId, areaBuffer);
        foreach (short areaId in areaBuffer)
        {
            addArea(areaId);
        }
    }
}
