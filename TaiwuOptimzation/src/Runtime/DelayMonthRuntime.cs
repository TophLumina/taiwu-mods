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
    private static readonly object Sync = new object();
    private static readonly Queue<DelayedMonthJob> Jobs = new Queue<DelayedMonthJob>(512);
    private static readonly HashSet<int> SyncAreas = new HashSet<int>();
    private static readonly Dictionary<int, int> JobCountsByArea = new Dictionary<int, int>();

    private static Action<DataContext, int, ICharacterParallelAction>? _characterAreaAction;
    private static bool _advancingMonth;
    private static bool _replaying;
    private static bool _saveAfterFlush;
    private static int _enqueuedThisMonth;
    private static int _appliedThisMonth;

    public static bool IsReplaying => _replaying;
    public static bool HasPendingJobs
    {
        get
        {
            lock (Sync)
            {
                return Jobs.Count > 0;
            }
        }
    }

    public static void Initialize()
    {
        var method = AccessTools.Method(
            typeof(ParallelActionManager),
            "OfflineExecuteCharacterActionsInArea",
            new[] { typeof(DataContext), typeof(int), typeof(ICharacterParallelAction) });
        _characterAreaAction = method.CreateDelegate<Action<DataContext, int, ICharacterParallelAction>>();
        AreaLocalMonthExecutors.Initialize();
    }

    public static void Dispose()
    {
        lock (Sync)
        {
            Jobs.Clear();
            SyncAreas.Clear();
            JobCountsByArea.Clear();
            _advancingMonth = false;
            _replaying = false;
            _saveAfterFlush = false;
            _enqueuedThisMonth = 0;
            _appliedThisMonth = 0;
        }
    }

    public static void BeginAdvanceMonth(DataContext context)
    {
        FlushAll(context);

        lock (Sync)
        {
            SyncAreas.Clear();
            _enqueuedThisMonth = 0;
            _appliedThisMonth = 0;
            _saveAfterFlush = false;
            _advancingMonth = DelayMonthSettings.Enabled;
        }

        if (DelayMonthSettings.Enabled)
        {
            BuildSyncAreas();
        }
    }

    public static void EndAdvanceMonth()
    {
        lock (Sync)
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

        return TryEnqueueAreaJob(DelayedMonthJob.CharacterArea(areaId, action));
    }

    public static bool TryDelayBrokenBlockArea(int areaId)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayBrokenBlocks || _replaying || areaId < 0)
        {
            return false;
        }

        return TryEnqueueAreaJob(DelayedMonthJob.BrokenBlockArea(areaId));
    }

    public static bool TryDelayMapMonthlyArea(int areaId)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayMapMonthlyUpdate || _replaying || areaId < 0)
        {
            return false;
        }

        return TryEnqueueAreaJob(DelayedMonthJob.MapMonthlyArea(areaId));
    }

    public static bool TryDelayRandomEnemiesArea(int areaId)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayRandomEnemies || _replaying || areaId < 0)
        {
            return false;
        }

        return TryEnqueueAreaJob(DelayedMonthJob.RandomEnemiesArea(areaId));
    }

    public static bool TryDelayNpcTamingArea(int areaId)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayNpcTaming || _replaying || areaId < 0)
        {
            return false;
        }

        return TryEnqueueAreaJob(DelayedMonthJob.NpcTamingArea(areaId));
    }

    public static bool TryHandleAnimalAreaData(DataContext context)
    {
        return TryHandleAreaLoop(
            context,
            DelayMonthSettings.DelayAnimalAreaData,
            0,
            141,
            DelayedMonthJob.AnimalAreaData,
            AreaLocalMonthExecutors.ExecuteAnimalAreaData);
    }

    public static bool TryHandleSkeletonGeneration(DataContext context)
    {
        return TryHandleAreaLoop(
            context,
            DelayMonthSettings.DelaySkeletonGeneration,
            0,
            45,
            DelayedMonthJob.SkeletonArea,
            AreaLocalMonthExecutors.ExecuteSkeletonGeneration);
    }

    public static bool TryHandleMapPickupsPostAdvanceMonth(DataContext context)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayMapPickups || _replaying || !IsAdvancingMonth())
        {
            return false;
        }

        HashSet<short> areaIds = new HashSet<short>();
        foreach (Location location in DomainManager.Extra.PickupDict.Keys)
        {
            if (location.AreaId >= 0)
            {
                areaIds.Add(location.AreaId);
            }
        }

        foreach (short areaId in areaIds)
        {
            if (!TryEnqueueAreaJob(DelayedMonthJob.MapPickupsArea(areaId)))
            {
                AreaLocalMonthExecutors.ExecuteMapPickupsPostAdvanceMonth(context, areaId);
            }
        }

        return true;
    }

    public static void Tick(DataContext context)
    {
        if (!DelayMonthSettings.Enabled || _advancingMonth || _replaying)
        {
            return;
        }

        FlushLiveSyncAreas(context);

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

    public static void FlushArea(DataContext context, short areaId)
    {
        if (areaId < 0 || _replaying)
        {
            return;
        }

        List<DelayedMonthJob> selected = new List<DelayedMonthJob>();
        lock (Sync)
        {
            if (!JobCountsByArea.ContainsKey(areaId))
            {
                return;
            }

            int count = Jobs.Count;
            for (int i = 0; i < count; i++)
            {
                DelayedMonthJob job = Jobs.Dequeue();
                if (job.AreaId == areaId)
                {
                    selected.Add(job);
                    DecrementJobCount(job.AreaId);
                }
                else
                {
                    Jobs.Enqueue(job);
                }
            }
        }

        ExecuteJobsBatched(context, selected);

        if (!HasPendingJobs)
        {
            TryRunDeferredSave(context);
        }
    }

    public static void FlushAll(DataContext context)
    {
        List<DelayedMonthJob> selected = new List<DelayedMonthJob>();
        while (true)
        {
            DelayedMonthJob? job = DequeueJob();
            if (job == null)
            {
                ExecuteJobsBatched(context, selected);
                TryRunDeferredSave(context);
                return;
            }

            selected.Add(job);
        }
    }

    public static bool PostponeSaveIfNeeded(ref bool saveWorld)
    {
        if (!saveWorld)
        {
            return false;
        }

        lock (Sync)
        {
            if (Jobs.Count == 0)
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
        if (_characterAreaAction == null)
        {
            throw new InvalidOperationException("Character area action method was not resolved.");
        }

        _characterAreaAction(context, areaId, action);
    }

    private static void BuildSyncAreas()
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return;
        }

        AddLiveSyncAreas(AddSyncArea);
    }

    private static void AddNeighborStates(short areaId, Action<short> addArea)
    {
        if (!DelayMonthSettings.SyncNeighborStates || areaId < 0 || areaId >= 135)
        {
            return;
        }

        sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
        foreach (sbyte neighborStateTemplateId in MapState.Instance[stateTemplateId].NeighborStates)
        {
            sbyte neighborStateId = DomainManager.Map.GetStateIdByStateTemplateId(neighborStateTemplateId);
            AddAreasInState(neighborStateId, addArea);
        }
    }

    private static void AddSyncArea(short areaId)
    {
        if (areaId >= 0 && areaId < 141)
        {
            lock (Sync)
            {
                SyncAreas.Add(areaId);
            }
        }
    }

    private static bool IsSyncArea(int areaId)
    {
        if (SyncAreas.Contains(areaId))
        {
            return true;
        }

        return IsLiveSyncArea(areaId);
    }

    private static bool IsLiveSyncArea(int areaId)
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return false;
        }

        if (areaId == location.AreaId)
        {
            return true;
        }

        if (areaId < 0 || location.AreaId < 0 || location.AreaId >= 135 || areaId >= 135)
        {
            return false;
        }

        sbyte taiwuStateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
        sbyte areaStateId = DomainManager.Map.GetStateIdByAreaId((short)areaId);
        if (areaStateId == taiwuStateId)
        {
            return true;
        }

        if (!DelayMonthSettings.SyncNeighborStates)
        {
            return false;
        }

        sbyte taiwuStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
        foreach (sbyte neighborStateTemplateId in MapState.Instance[taiwuStateTemplateId].NeighborStates)
        {
            if (DomainManager.Map.GetStateIdByStateTemplateId(neighborStateTemplateId) == areaStateId)
            {
                return true;
            }
        }

        return false;
    }

    private static void FlushLiveSyncAreas(DataContext context)
    {
        HashSet<short> areaIds = new HashSet<short>();
        AddLiveSyncAreas(areaId => areaIds.Add(areaId));
        foreach (short areaId in areaIds)
        {
            FlushArea(context, areaId);
        }
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
        lock (Sync)
        {
            if (Jobs.Count == 0)
            {
                return null;
            }

            DelayedMonthJob job = Jobs.Dequeue();
            DecrementJobCount(job.AreaId);
            return job;
        }
    }

    private static void EnqueueJob(DelayedMonthJob job)
    {
        Jobs.Enqueue(job);
        JobCountsByArea.TryGetValue(job.AreaId, out int count);
        JobCountsByArea[job.AreaId] = count + 1;
    }

    private static void DecrementJobCount(int areaId)
    {
        int count = JobCountsByArea[areaId] - 1;
        if (count <= 0)
        {
            JobCountsByArea.Remove(areaId);
        }
        else
        {
            JobCountsByArea[areaId] = count;
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
            _appliedThisMonth++;
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
        bool shouldSave;
        lock (Sync)
        {
            shouldSave = _saveAfterFlush && Jobs.Count == 0;
            _saveAfterFlush = false;
        }

        if (shouldSave)
        {
            DomainManager.Global.SaveWorld(context);
        }
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
        lock (Sync)
        {
            if (!_advancingMonth || IsSyncArea(job.AreaId))
            {
                return false;
            }

            EnqueueJob(job);
            _enqueuedThisMonth++;
            return true;
        }
    }

    private static bool IsAdvancingMonth()
    {
        lock (Sync)
        {
            return _advancingMonth;
        }
    }

    private static void AddLiveSyncAreas(Action<short> addArea)
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return;
        }

        addArea(location.AreaId);
        if (location.AreaId < 0 || location.AreaId >= 135)
        {
            return;
        }

        sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
        AddAreasInState(stateId, addArea);
        AddNeighborStates(location.AreaId, addArea);
    }

    private static void AddAreasInState(sbyte stateId, Action<short> addArea)
    {
        if (stateId < 0)
        {
            return;
        }

        List<short> areaList = new List<short>(16);
        DomainManager.Map.GetAllAreaInState(stateId, areaList);
        foreach (short areaId in areaList)
        {
            addArea(areaId);
        }
    }
}
