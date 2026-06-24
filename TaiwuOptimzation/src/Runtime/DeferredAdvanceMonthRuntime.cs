using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal static class DeferredAdvanceMonthRuntime
{
    private const int AreaCount = 141;
    private const int StateAreaCount = 135;
    private const int SkeletonAreaCount = 45;
    private const int CharacterParallelActionCharactersPerJob = 16;
    private const int HeavyCharacterParallelActionCharactersPerJob = 8;
    private const int MapBrokenBlockCountdownBlocksPerJob = 24;
    private const int GraveSkeletonBlocksPerJob = 16;
    private const int MapPickupsPostAdvanceMonthLocationsPerJob = 16;
    private const int MaxOverrunCooldownFrames = 3;

    private enum JobDrainMode
    {
        All,
        Area,
        AreaSet,
    }

    private static readonly object _syncRoot = new();
    private static readonly Queue<DeferredAdvanceMonthJob> _pendingJobs = new(512);
    private static readonly HashSet<int> _liveSynchronousAreaIds = new();
    private static readonly Dictionary<int, int> _pendingJobCountsByArea = new();

    private static int _pendingJobCount;
    private static int _delayedJobCooldownFrames;
    private static bool _advancingMonth;
    private static bool _replaying;
    private static short _liveSynchronousAreaSource = -1;
    private static bool _liveSynchronousAreaIncludesNeighbors;

    private static bool HasPendingJobs => Volatile.Read(ref _pendingJobCount) > 0;

    public static void Initialize()
    {
        AreaLocalMonthExecutors.Initialize();
    }

    public static void Dispose()
    {
        ClearPendingJobs();
    }

    public static void BeginAdvanceMonthDelayScope(DataContext context)
    {
        FlushAllPendingJobs(context);

        lock (_syncRoot)
        {
            InvalidateLiveSynchronousAreaCache();
            _delayedJobCooldownFrames = 0;
            _advancingMonth = DeferredAdvanceMonthSettings.Enabled;
        }
    }

    public static void EndAdvanceMonthDelayScope()
    {
        lock (_syncRoot)
        {
            _advancingMonth = false;
        }
    }

    public static bool TryDeferCharacterParallelActionInArea(int areaId, ICharacterParallelAction action)
    {
        if (!DeferredAdvanceMonthSettings.Enabled ||
            _replaying ||
            areaId < 0 ||
            !CanDeferCharacterPeriAdvanceMonthParallelAction(action))
        {
            return false;
        }

        if (!CanDelayAreaJobs(areaId))
        {
            return false;
        }

        List<int> characterIds = AreaLocalMonthExecutors.SnapshotAreaCharacterIdsForParallelAction(areaId);
        EnqueueCharacterParallelActionChunks(areaId, action, characterIds);
        return true;
    }

    public static bool TryDelayMapBrokenBlockUpdate(int areaId)
    {
        if (!DeferredAdvanceMonthSettings.Enabled ||
            !DeferredAdvanceMonthSettings.DelayMapBrokenBlockCountdown ||
            _replaying ||
            areaId < 0)
        {
            return false;
        }

        if (!CanDelayAreaJobs(areaId))
        {
            return false;
        }

        EnqueueBlockRangeJobs(areaId, MapBrokenBlockCountdownBlocksPerJob, DeferredAdvanceMonthJob.MapBrokenBlockUpdate);
        return true;
    }

    public static bool TryHandleAnimalAreaData(DataContext context)
    {
        return TryHandleAreaLoop(
            context,
            DeferredAdvanceMonthSettings.DelayAnimalAreaData,
            0,
            AreaCount,
            DeferredAdvanceMonthJob.AnimalAreaData,
            AreaLocalMonthExecutors.ExecuteAnimalAreaData);
    }

    public static bool TryHandleSkeletonGeneration(DataContext context)
    {
        if (!DeferredAdvanceMonthSettings.Enabled ||
            !DeferredAdvanceMonthSettings.DelayGraveSkeletonGeneration ||
            _replaying ||
            !IsAdvancingMonth())
        {
            return false;
        }

        for (int areaId = 0; areaId < SkeletonAreaCount; areaId++)
        {
            if (CanDelayAreaJobs(areaId))
            {
                EnqueueBlockRangeJobs(areaId, GraveSkeletonBlocksPerJob, DeferredAdvanceMonthJob.SkeletonGeneration);
            }
            else
            {
                AreaLocalMonthExecutors.ExecuteSkeletonGeneration(context, areaId);
            }
        }

        return true;
    }

    public static bool TryDelayMapPickupCleanup(DataContext context)
    {
        if (!DeferredAdvanceMonthSettings.Enabled ||
            !DeferredAdvanceMonthSettings.DelayMapPickupsPostAdvanceMonth ||
            _replaying ||
            !IsAdvancingMonth())
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
            EnqueueOrExecuteMapPickupCleanup(context, areaId, locations);
        }

        return true;
    }

    private static void EnqueueOrExecuteMapPickupCleanup(
        DataContext context,
        short areaId,
        List<Location> locations)
    {
        if (locations.Count <= MapPickupsPostAdvanceMonthLocationsPerJob)
        {
            EnqueueOrExecuteMapPickupCleanupChunk(context, areaId, locations);
            return;
        }

        for (int offset = 0; offset < locations.Count; offset += MapPickupsPostAdvanceMonthLocationsPerJob)
        {
            int count = Math.Min(MapPickupsPostAdvanceMonthLocationsPerJob, locations.Count - offset);
            List<Location> chunk = new(count);
            for (int i = 0; i < count; i++)
            {
                chunk.Add(locations[offset + i]);
            }

            EnqueueOrExecuteMapPickupCleanupChunk(context, areaId, chunk);
        }
    }

    private static void EnqueueOrExecuteMapPickupCleanupChunk(
        DataContext context,
        short areaId,
        IReadOnlyList<Location> locations)
    {
        if (!TryEnqueueAreaJob(DeferredAdvanceMonthJob.MapPickupCleanup(areaId, locations)))
        {
            AreaLocalMonthExecutors.ExecuteMapPickupCleanup(context, areaId, locations);
        }
    }

    public static void TickDelayedJobs(DataContext context)
    {
        if (!DeferredAdvanceMonthSettings.Enabled || _advancingMonth || _replaying)
        {
            return;
        }

        // Most frames have no delayed work; avoid rebuilding live sync areas then.
        if (!HasPendingJobs)
        {
            return;
        }

        if (!IsWorldDataAvailable())
        {
            ClearPendingJobs();
            return;
        }

        if (DomainManager.Global.GetSavingWorld())
        {
            ExecuteAllPendingJobs(context);
            return;
        }

        FlushLiveSyncAreas(context);
        if (!HasPendingJobs)
        {
            return;
        }

        if (_delayedJobCooldownFrames > 0)
        {
            _delayedJobCooldownFrames--;
            return;
        }

        long budgetTicks = Math.Max(1, DeferredAdvanceMonthSettings.FrameBudgetMs * Stopwatch.Frequency / 1000);
        long tickStart = Stopwatch.GetTimestamp();
        long deadline = tickStart + budgetTicks;
        int executedJobs = 0;
        DeferredAdvanceMonthJob? currentBatch = null;
        bool hasPendingApply = false;
        do
        {
            DeferredAdvanceMonthJob? job = DequeueJob();
            if (job == null)
            {
                ApplyPending(context, ref hasPendingApply);
                return;
            }

            executedJobs++;
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
        while (executedJobs < DeferredAdvanceMonthSettings.MaxJobsPerFrame && Stopwatch.GetTimestamp() < deadline);

        ApplyPending(context, ref hasPendingApply);
        ApplyOverrunCooldown(tickStart, budgetTicks);
    }

    public static void FlushAreaJobs(DataContext context, short areaId)
    {
        if (areaId < 0 || _replaying)
        {
            return;
        }

        ExecuteJobsBatched(context, DrainJobs(JobDrainMode.Area, areaId));
    }

    public static void FlushCurrentLiveSyncAreas(DataContext context)
    {
        if (_replaying || !HasPendingJobs)
        {
            return;
        }

        if (!IsWorldDataAvailable())
        {
            ClearPendingJobs();
            return;
        }

        // Keep Taiwu's visible region in original month-end state before travel UI resumes.
        FlushLiveSyncAreas(context);
    }

    public static void FlushAllPendingJobs(DataContext context)
    {
        if (!HasPendingJobs)
        {
            return;
        }

        if (!IsWorldDataAvailable())
        {
            ClearPendingJobs();
            return;
        }

        ExecuteAllPendingJobs(context);
    }

    public static void ClearPendingJobs()
    {
        lock (_syncRoot)
        {
            _pendingJobs.Clear();
            InvalidateLiveSynchronousAreaCache();
            _pendingJobCountsByArea.Clear();
            Volatile.Write(ref _pendingJobCount, 0);
            _delayedJobCooldownFrames = 0;
            _advancingMonth = false;
            _replaying = false;
        }
    }

    private static bool IsWorldDataAvailable() =>
        GameData.ArchiveData.Common.IsInWorld() && DomainManager.Global.GetLoadedAllArchiveData();

    private static void AddNeighborStates(short areaId, Action<short> addArea, List<short> areaBuffer)
    {
        if (!DeferredAdvanceMonthSettings.SyncNeighborStates || areaId < 0 || areaId >= StateAreaCount)
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

        ExecuteJobsBatched(context, DrainJobs(JobDrainMode.AreaSet, areaSet: areaIds));
    }

    // Only defer pre-action AdvanceMonth stages; CharacterActionPlanning stays on the original barrier.
    private static bool CanDeferCharacterPeriAdvanceMonthParallelAction(ICharacterParallelAction action)
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

        if (DeferredAdvanceMonthSettings.DelayCharacterPreparationCombatSkillAndItemEquipping &&
            type == typeof(CharacterPreparation_CombatSkillAndItemEquipping))
        {
            return true;
        }

        if (DeferredAdvanceMonthSettings.DelayCharacterPreparationLoseOverloadItems &&
            type == typeof(CharacterPreparation_LoseOverloadItems))
        {
            return true;
        }

        return false;
    }

    private static int GetCharacterParallelActionChunkSize(ICharacterParallelAction action)
    {
        Type type = action.GetType();
        return type == typeof(CharacterSelfImprovement_Reading) ||
            type == typeof(CharacterPreparation_CombatSkillAndItemEquipping) ||
            type == typeof(CharacterPreparation_LoseOverloadItems)
                ? HeavyCharacterParallelActionCharactersPerJob
                : CharacterParallelActionCharactersPerJob;
    }

    private static void EnqueueCharacterParallelActionChunks(
        int areaId,
        ICharacterParallelAction action,
        IReadOnlyList<int> characterIds)
    {
        int chunkSize = GetCharacterParallelActionChunkSize(action);
        for (int offset = 0; offset < characterIds.Count; offset += chunkSize)
        {
            int count = Math.Min(chunkSize, characterIds.Count - offset);
            int[] chunk = new int[count];
            for (int i = 0; i < count; i++)
            {
                chunk[i] = characterIds[offset + i];
            }

            EnqueueAreaJob(DeferredAdvanceMonthJob.CharacterParallelActionChunk(areaId, action, chunk));
        }
    }

    private static void EnqueueBlockRangeJobs(
        int areaId,
        int blocksPerJob,
        Func<int, int, int, DeferredAdvanceMonthJob> createJob)
    {
        int blockCount = DomainManager.Map.GetAreaBlocks((short)areaId).Length;
        for (int blockStart = 0; blockStart < blockCount; blockStart += blocksPerJob)
        {
            int count = Math.Min(blocksPerJob, blockCount - blockStart);
            EnqueueAreaJob(createJob(areaId, blockStart, count));
        }
    }

    private static DeferredAdvanceMonthJob? DequeueJob()
    {
        lock (_syncRoot)
        {
            if (_pendingJobs.Count == 0)
            {
                return null;
            }

            DeferredAdvanceMonthJob job = _pendingJobs.Dequeue();
            DecrementJobCount(job.AreaId);
            return job;
        }
    }

    private static List<DeferredAdvanceMonthJob> DrainJobs(
        JobDrainMode mode,
        int areaId = -1,
        HashSet<int>? areaSet = null)
    {
        List<DeferredAdvanceMonthJob> selected = new();
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
                DeferredAdvanceMonthJob job = _pendingJobs.Dequeue();
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
        DeferredAdvanceMonthJob job,
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

    private static void EnqueueJob(DeferredAdvanceMonthJob job)
    {
        _pendingJobs.Enqueue(job);
        Interlocked.Increment(ref _pendingJobCount);
        _pendingJobCountsByArea.TryGetValue(job.AreaId, out int count);
        _pendingJobCountsByArea[job.AreaId] = count + 1;
    }

    private static void DecrementJobCount(int areaId)
    {
        if (Interlocked.Decrement(ref _pendingJobCount) < 0)
        {
            Volatile.Write(ref _pendingJobCount, 0);
        }

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

    private static void ExecuteJobsBatched(DataContext context, List<DeferredAdvanceMonthJob> jobs)
    {
        DeferredAdvanceMonthJob? currentBatch = null;
        bool hasPendingApply = false;
        foreach (DeferredAdvanceMonthJob job in jobs)
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

    private static void ExecuteAllPendingJobs(DataContext context)
    {
        DeferredAdvanceMonthJob? currentBatch = null;
        bool hasPendingApply = false;
        while (true)
        {
            DeferredAdvanceMonthJob? job = DequeueJob();
            if (job == null)
            {
                ApplyPending(context, ref hasPendingApply);
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
    }

    private static bool ExecuteJobWithoutApply(DataContext context, DeferredAdvanceMonthJob job)
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

    private static void ApplyOverrunCooldown(long tickStart, long budgetTicks)
    {
        if (!HasPendingJobs)
        {
            _delayedJobCooldownFrames = 0;
            return;
        }

        long elapsedTicks = Stopwatch.GetTimestamp() - tickStart;
        if (elapsedTicks <= budgetTicks * 2)
        {
            _delayedJobCooldownFrames = 0;
            return;
        }

        long excessFrames = (elapsedTicks - budgetTicks) / budgetTicks;
        _delayedJobCooldownFrames = (int)Math.Min(MaxOverrunCooldownFrames, Math.Max(1, excessFrames));
    }

    private static bool TryHandleAreaLoop(
        DataContext context,
        bool settingEnabled,
        int startAreaId,
        int endAreaId,
        Func<int, DeferredAdvanceMonthJob> createJob,
        Action<DataContext, int> executeSync)
    {
        if (!DeferredAdvanceMonthSettings.Enabled || !settingEnabled || _replaying || !IsAdvancingMonth())
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

    private static bool TryEnqueueAreaJob(DeferredAdvanceMonthJob job)
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

    private static bool CanDelayAreaJobs(int areaId)
    {
        lock (_syncRoot)
        {
            return _advancingMonth && !IsSyncArea(areaId);
        }
    }

    private static void EnqueueAreaJob(DeferredAdvanceMonthJob job)
    {
        lock (_syncRoot)
        {
            EnqueueJob(job);
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

        bool includeNeighborStates = DeferredAdvanceMonthSettings.SyncNeighborStates;
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
