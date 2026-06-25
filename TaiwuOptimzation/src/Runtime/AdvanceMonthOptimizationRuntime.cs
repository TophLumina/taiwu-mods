using System;
using System.Collections.Generic;
using System.Threading;
using GameData.ActionPlanning.MonthlyAI;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal static class AdvanceMonthOptimizationRuntime
{
    private const int AreaCount = 141;
    private const int StateAreaCount = 135;
    private const int SkeletonAreaCount = 45;
    private const int CharacterParallelActionCharactersPerJob = 16;
    private const int HeavyCharacterParallelActionCharactersPerJob = 8;
    private const int MapBrokenBlockCountdownBlocksPerJob = 24;
    private const int GraveSkeletonBlocksPerJob = 16;
    private const int MapPickupsPostAdvanceMonthLocationsPerJob = 16;
    private const int PeriAdvanceMonthDeferredJobKindCount = 5;
    private const int MaxOverrunCooldownFrames = 3;

    private enum PendingAdvanceMonthJobDrainMode
    {
        All,
        Area,
        AreaSet,
    }

    private static readonly object _syncRoot = new();
    private static readonly Queue<PeriAdvanceMonthDeferredJob> _pendingAdvanceMonthJobs = new(512);
    private static readonly HashSet<int> _liveSyncAreaIds = new();
    private static readonly Dictionary<int, int> _pendingAdvanceMonthJobCountsByArea = new();

    // 在入队/出队时维护，避免诊断日志扫描 pending 队列。
    private static readonly int[] _pendingAdvanceMonthJobCountsByKind = new int[PeriAdvanceMonthDeferredJobKindCount];

    private static int _pendingAdvanceMonthJobCount;
    private static int _overrunCooldownFrames;
    private static bool _isInAdvanceMonth;
    private static bool _isReplayingDeferredJob;
    private static short _liveSyncAreaSource = -1;
    private static bool _liveSyncAreaIncludesNeighbors;

    private static bool HasPendingAdvanceMonthJobs => Volatile.Read(ref _pendingAdvanceMonthJobCount) > 0;

    public static void Initialize()
    {
        AreaLocalPeriAdvanceMonthExecutor.Initialize();
        PeriAdvanceMonthProtectionCache.Reset();
        AdvanceMonthOptimizationDiagnostics.Reset();
    }

    public static void Dispose()
    {
        ClearPendingAdvanceMonthJobs();
    }

    public static void BeginAdvanceMonthOptimizationScope(DataContext context)
    {
        FlushAllPendingAdvanceMonthJobs(context);

        lock (_syncRoot)
        {
            InvalidateLiveSyncAreaCache();
            _overrunCooldownFrames = 0;
            _isInAdvanceMonth = TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled;
        }

        if (TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            PeriAdvanceMonthProtectionCache.FreezeForPeriAdvanceMonth();
        }
    }

    public static void EndAdvanceMonthOptimizationScope()
    {
        lock (_syncRoot)
        {
            _isInAdvanceMonth = false;
        }

        PeriAdvanceMonthProtectionCache.UnfreezePeriAdvanceMonth();
    }

    public static bool TryDeferCharacterParallelActionInArea(DataContext context, int areaId, ICharacterParallelAction action)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            _isReplayingDeferredJob ||
            areaId < 0 ||
            !CanDeferCharacterPeriAdvanceMonthParallelAction(action))
        {
            return false;
        }

        if (!CanDeferAreaPeriAdvanceMonthJobs(areaId))
        {
            return false;
        }

        List<int> characterIds = AreaLocalPeriAdvanceMonthExecutor.SnapshotAreaCharacterIdsForParallelAction(areaId);
        PeriAdvanceMonthProtectionCache.Snapshot protection = PeriAdvanceMonthProtectionCache.GetSnapshot();
        List<int> originalPassCharacterIds = new();
        List<int> deferredCharacterIds = new();
        SplitCharacterParallelActionCharacters(characterIds, protection, originalPassCharacterIds, deferredCharacterIds);

        AreaLocalPeriAdvanceMonthExecutor.ExecuteCharacterParallelActionChunk(context, action, originalPassCharacterIds);
        EnqueueCharacterParallelActionChunks(areaId, action, deferredCharacterIds);
        return true;
    }

    public static bool TryDeferParallelUpdateBrokenBlockOnMonthChange(int areaId)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !TaiwuOptimizationSettings.DeferParallelUpdateBrokenBlockOnMonthChange ||
            _isReplayingDeferredJob ||
            areaId < 0)
        {
            return false;
        }

        if (!CanDeferAreaPeriAdvanceMonthJobs(areaId))
        {
            return false;
        }

        EnqueueBlockRangeJobs(areaId, MapBrokenBlockCountdownBlocksPerJob, PeriAdvanceMonthDeferredJob.MapBrokenBlockUpdate);
        return true;
    }

    public static bool TryDeferUpdateAnimalAreaData(DataContext context)
    {
        return TryDeferAreaLoop(
            context,
            TaiwuOptimizationSettings.DeferUpdateAnimalAreaData,
            0,
            AreaCount,
            PeriAdvanceMonthDeferredJob.AnimalAreaData,
            AreaLocalPeriAdvanceMonthExecutor.ExecuteAnimalAreaData);
    }

    public static bool TryDeferGenerateSkeletons(DataContext context)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !TaiwuOptimizationSettings.DeferGenerateSkeletons ||
            _isReplayingDeferredJob ||
            !IsAdvancingMonth())
        {
            return false;
        }

        for (int areaId = 0; areaId < SkeletonAreaCount; areaId++)
        {
            if (CanDeferAreaPeriAdvanceMonthJobs(areaId))
            {
                EnqueueBlockRangeJobs(areaId, GraveSkeletonBlocksPerJob, PeriAdvanceMonthDeferredJob.SkeletonGeneration);
            }
            else
            {
                AreaLocalPeriAdvanceMonthExecutor.ExecuteSkeletonGeneration(context, areaId);
            }
        }

        return true;
    }

    public static bool TryDeferMapPickupsPostAdvanceMonth(DataContext context)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !TaiwuOptimizationSettings.DeferMapPickupsPostAdvanceMonth ||
            _isReplayingDeferredJob ||
            !IsAdvancingMonth())
        {
            return false;
        }

        // 在月结时截取拾取物位置，避免延迟回放误处理后续新增的拾取物。
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
        if (!TryEnqueueAreaJob(PeriAdvanceMonthDeferredJob.MapPickupCleanup(areaId, locations)))
        {
            AreaLocalPeriAdvanceMonthExecutor.ExecuteMapPickupCleanup(context, areaId, locations);
        }
    }

    /// <summary>执行受帧预算限制的 cache 构建和延迟月结任务。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    public static void TickAdvanceMonthOptimization(DataContext context)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled || _isInAdvanceMonth || _isReplayingDeferredJob)
        {
            return;
        }

        bool hasPendingAdvanceMonthJobs = HasPendingAdvanceMonthJobs;
        bool needsProtectionCacheBuild = PeriAdvanceMonthProtectionCache.NeedsFrameBuild();
        if (!hasPendingAdvanceMonthJobs && !needsProtectionCacheBuild)
        {
            return;
        }

        if (!IsWorldDataAvailable())
        {
            if (hasPendingAdvanceMonthJobs)
            {
                ClearPendingAdvanceMonthJobs();
            }

            return;
        }

        if (DomainManager.Global.GetSavingWorld())
        {
            if (hasPendingAdvanceMonthJobs)
            {
                ExecuteAllPendingAdvanceMonthJobs(context);
            }

            return;
        }

        AdvanceMonthOptimizationFrameBudget frameBudget = AdvanceMonthOptimizationFrameBudget.Start();
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            TickAdvanceMonthOptimizationCore(context, needsProtectionCacheBuild, ref frameBudget);
            return;
        }

        TickAdvanceMonthOptimizationWithDiagnostics(context, needsProtectionCacheBuild, ref frameBudget);
    }

    /// <summary>执行一次不收集诊断信息的优化 tick。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="needsProtectionCacheBuild">是否优先推进 protection-cache 构建。</param>
    /// <param name="frameBudget">可变的单帧预算状态。</param>
    private static void TickAdvanceMonthOptimizationCore(
        DataContext context,
        bool needsProtectionCacheBuild,
        ref AdvanceMonthOptimizationFrameBudget frameBudget)
    {
        PeriAdvanceMonthDeferredJobStats ignoredStats = default;
        TickAdvanceMonthOptimizationCore(
            context,
            needsProtectionCacheBuild,
            ref frameBudget,
            collectStats: false,
            ref ignoredStats,
            out _);
    }

    /// <summary>
    /// 执行一次优化 tick，并确保所有退出路径都会记录诊断摘要。
    /// </summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="needsProtectionCacheBuild">protection cache 是否需要构建。</param>
    /// <param name="frameBudget">可变的单帧预算状态。</param>
    private static void TickAdvanceMonthOptimizationWithDiagnostics(
        DataContext context,
        bool needsProtectionCacheBuild,
        ref AdvanceMonthOptimizationFrameBudget frameBudget)
    {
        int cacheBuildSteps = 0;
        PeriAdvanceMonthDeferredJobStats executedJobStats = default;
        try
        {
            TickAdvanceMonthOptimizationCore(
                context,
                needsProtectionCacheBuild,
                ref frameBudget,
                collectStats: true,
                ref executedJobStats,
                out cacheBuildSteps);
        }
        finally
        {
            RecordAdvanceMonthOptimizationDiagnostics(in frameBudget, cacheBuildSteps, in executedJobStats);
        }
    }

    /// <summary>
    /// 共享的 tick 主体。诊断是可选的，因此普通热路径可以避开 try/finally。
    /// </summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="needsProtectionCacheBuild">是否优先推进 protection-cache 构建。</param>
    /// <param name="frameBudget">可变的单帧预算状态。</param>
    /// <param name="collectStats">为 true 时按类型统计本 tick 执行的 job。</param>
    /// <param name="executedJobStats">本 tick 执行的 job 计数。</param>
    /// <param name="cacheBuildSteps">本 tick 执行的 cache build step 数。</param>
    private static void TickAdvanceMonthOptimizationCore(
        DataContext context,
        bool needsProtectionCacheBuild,
        ref AdvanceMonthOptimizationFrameBudget frameBudget,
        bool collectStats,
        ref PeriAdvanceMonthDeferredJobStats executedJobStats,
        out int cacheBuildSteps)
    {
        cacheBuildSteps = 0;
        if (needsProtectionCacheBuild)
        {
            cacheBuildSteps = PeriAdvanceMonthProtectionCache.TickBuildPeriAdvanceMonthProtection(in frameBudget);
        }

        if (!HasPendingAdvanceMonthJobs)
        {
            _overrunCooldownFrames = 0;
            return;
        }

        if (!frameBudget.HasTimeRemaining())
        {
            ApplyOverrunCooldown(frameBudget);
            return;
        }

        if (collectStats)
        {
            PeriAdvanceMonthDeferredJobStats flushedLiveSyncJobStats = FlushLiveSyncAreas(context, collectStats: true);
            executedJobStats.Add(in flushedLiveSyncJobStats);
        }
        else
        {
            FlushLiveSyncAreas(context);
        }

        if (!HasPendingAdvanceMonthJobs)
        {
            _overrunCooldownFrames = 0;
            return;
        }

        if (_overrunCooldownFrames > 0)
        {
            _overrunCooldownFrames--;
            return;
        }

        PeriAdvanceMonthDeferredJob? currentBatch = null;
        bool hasPendingApply = false;
        while (frameBudget.CanExecutePendingAdvanceMonthJob())
        {
            PeriAdvanceMonthDeferredJob? job = DequeuePendingAdvanceMonthJob();
            if (job == null)
            {
                ApplyPendingParallelModifications(context, ref hasPendingApply);
                return;
            }

            frameBudget.CountPendingAdvanceMonthJob();
            if (hasPendingApply && currentBatch != null && (!job.RequiresParallelApply || !currentBatch.CanBatchWith(job)))
            {
                ApplyPendingParallelModifications(context, ref hasPendingApply);
            }

            if (ExecuteDeferredJobWithoutApply(context, job))
            {
                currentBatch = job;
                hasPendingApply = true;
            }

            if (collectStats)
            {
                executedJobStats.Count(job.Kind);
            }
        }

        ApplyPendingParallelModifications(context, ref hasPendingApply);
        ApplyOverrunCooldown(frameBudget);
    }

    public static void FlushPendingAdvanceMonthJobsInArea(DataContext context, short areaId)
    {
        if (areaId < 0 || _isReplayingDeferredJob)
        {
            return;
        }

        ExecuteAdvanceMonthJobsBatched(context, DrainPendingAdvanceMonthJobs(PendingAdvanceMonthJobDrainMode.Area, areaId));
    }

    public static void FlushPendingAdvanceMonthJobsInLiveSyncAreas(DataContext context)
    {
        if (_isReplayingDeferredJob || !HasPendingAdvanceMonthJobs)
        {
            return;
        }

        if (!IsWorldDataAvailable())
        {
            ClearPendingAdvanceMonthJobs();
            return;
        }

        // 在旅行 UI 恢复前，确保太吾可见区域已回到原版月结后的状态。
        FlushLiveSyncAreas(context);
    }

    public static void FlushAllPendingAdvanceMonthJobs(DataContext context)
    {
        if (!HasPendingAdvanceMonthJobs)
        {
            return;
        }

        if (!IsWorldDataAvailable())
        {
            ClearPendingAdvanceMonthJobs();
            return;
        }

        ExecuteAllPendingAdvanceMonthJobs(context);
    }

    public static void ClearPendingAdvanceMonthJobs()
    {
        lock (_syncRoot)
        {
            _pendingAdvanceMonthJobs.Clear();
            InvalidateLiveSyncAreaCache();
            _pendingAdvanceMonthJobCountsByArea.Clear();
            Array.Clear(_pendingAdvanceMonthJobCountsByKind);
            Volatile.Write(ref _pendingAdvanceMonthJobCount, 0);
            _overrunCooldownFrames = 0;
            _isInAdvanceMonth = false;
            _isReplayingDeferredJob = false;
        }

        PeriAdvanceMonthProtectionCache.Reset();
        AdvanceMonthOptimizationDiagnostics.Reset();
    }

    public static bool IsAreaLiveSync(short areaId)
    {
        if (areaId < 0)
        {
            return false;
        }

        lock (_syncRoot)
        {
            return IsLiveSyncArea(areaId);
        }
    }

    public static void CopyLiveSyncAreaIdsTo(HashSet<int> destination)
    {
        lock (_syncRoot)
        {
            destination.Clear();
            HashSet<int>? areaIds = GetLiveSyncAreaIds();
            if (areaIds == null)
            {
                return;
            }

            foreach (int areaId in areaIds)
            {
                destination.Add(areaId);
            }
        }
    }

    public static void CopyLiveSyncAreaIdsTo(HashSet<int> destination, bool includeNeighborStates)
    {
        lock (_syncRoot)
        {
            destination.Clear();
            AddLiveSyncAreas(areaId => destination.Add(areaId), includeNeighborStates);
        }
    }

    public static bool TryGetLiveSyncAreaCacheKey(out short areaId, out bool includeNeighborStates)
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        includeNeighborStates = TaiwuOptimizationSettings.SyncNeighborStatesForAdvanceMonth;
        if (!location.IsValid())
        {
            areaId = -1;
            return false;
        }

        areaId = location.AreaId;
        return true;
    }

    public static bool TryGetLiveSyncAreaCacheKey(bool includeNeighborStates, out short areaId)
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            areaId = -1;
            return false;
        }

        areaId = location.AreaId;
        return true;
    }

    private static bool IsWorldDataAvailable() =>
        GameData.ArchiveData.Common.IsInWorld() && DomainManager.Global.GetLoadedAllArchiveData();

    private static void AddNeighborStates(short areaId, Action<short> addArea, List<short> areaBuffer)
    {
        AddNeighborStates(areaId, TaiwuOptimizationSettings.SyncNeighborStatesForAdvanceMonth, addArea, areaBuffer);
    }

    private static void AddNeighborStates(
        short areaId,
        bool includeNeighborStates,
        Action<short> addArea,
        List<short> areaBuffer)
    {
        if (!includeNeighborStates || areaId < 0 || areaId >= StateAreaCount)
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
        HashSet<int>? areaIds = GetLiveSyncAreaIds();
        return areaIds != null && areaIds.Contains(areaId);
    }

    private static PeriAdvanceMonthDeferredJobStats FlushLiveSyncAreas(DataContext context, bool collectStats = false)
    {
        HashSet<int>? areaIds = GetLiveSyncAreaIds();
        if (areaIds == null || areaIds.Count == 0)
        {
            return default;
        }

        return ExecuteAdvanceMonthJobsBatched(
            context,
            DrainPendingAdvanceMonthJobs(PendingAdvanceMonthJobDrainMode.AreaSet, areaSet: areaIds),
            collectStats);
    }

    // 只延迟 AdvanceMonth 中行动前阶段；CharacterActionPlanning 仍保留在原版屏障内。
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

        if (TaiwuOptimizationSettings.DeferPeriAdvanceMonthActivePreparationCombatSkillAndItemEquipping &&
            type == typeof(CharacterPreparation_CombatSkillAndItemEquipping))
        {
            return true;
        }

        if (TaiwuOptimizationSettings.DeferPeriAdvanceMonthLoseOverloadItems &&
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

            EnqueueAreaJob(PeriAdvanceMonthDeferredJob.CharacterParallelActionChunk(areaId, action, chunk));
        }
    }

    private static void SplitCharacterParallelActionCharacters(
        IReadOnlyList<int> characterIds,
        PeriAdvanceMonthProtectionCache.Snapshot protection,
        List<int> originalPassCharacterIds,
        List<int> deferredCharacterIds)
    {
        for (int i = 0; i < characterIds.Count; i++)
        {
            int characterId = characterIds[i];
            if (ShouldKeepCharacterParallelActionInOriginalPass(characterId, protection))
            {
                originalPassCharacterIds.Add(characterId);
            }
            else
            {
                deferredCharacterIds.Add(characterId);
            }
        }
    }

    private static bool ShouldKeepCharacterParallelActionInOriginalPass(
        int characterId,
        PeriAdvanceMonthProtectionCache.Snapshot protection)
    {
        if (protection.IsTaiwuOrGroupMember(characterId) ||
            protection.IsDirectlyRelatedToTaiwuGroup(characterId) ||
            !DomainManager.Character.TryGetElement_Objects(characterId, out GameData.Domains.Character.Character? character))
        {
            return true;
        }

        if (IsSpecialOrEventCharacter(character))
        {
            return true;
        }

        Location location = character.GetLocation();
        if (!location.IsValid() || protection.IsLiveSyncArea(location.AreaId))
        {
            return true;
        }

        ActionPlanningData actionPlanningData = character.ActionPlanningData;
        return protection.HasActionTargetInTaiwuGroup(actionPlanningData.GetCurrentAction(ActionPlanningData.ECurrentGoalType.Primary)) ||
            protection.HasActionTargetInTaiwuGroup(actionPlanningData.GetCurrentAction(ActionPlanningData.ECurrentGoalType.Secondary));
    }

    private static bool IsSpecialOrEventCharacter(GameData.Domains.Character.Character character)
    {
        int characterId = character.GetId();
        return character.GetCreatingType() != 1 ||
            DomainManager.Character.IsTemporaryIntelligentCharacter(characterId) ||
            DomainManager.Character.IsSpecialGroupMember(character) ||
            character.IsCrossAreaTraveling() ||
            DomainManager.LegendaryBook.IsCharacterActingCrazy(character);
    }

    private static void EnqueueBlockRangeJobs(
        int areaId,
        int blocksPerJob,
        Func<int, int, int, PeriAdvanceMonthDeferredJob> createJob)
    {
        int blockCount = DomainManager.Map.GetAreaBlocks((short)areaId).Length;
        for (int blockStart = 0; blockStart < blockCount; blockStart += blocksPerJob)
        {
            int count = Math.Min(blocksPerJob, blockCount - blockStart);
            EnqueueAreaJob(createJob(areaId, blockStart, count));
        }
    }

    private static PeriAdvanceMonthDeferredJob? DequeuePendingAdvanceMonthJob()
    {
        lock (_syncRoot)
        {
            if (_pendingAdvanceMonthJobs.Count == 0)
            {
                return null;
            }

            PeriAdvanceMonthDeferredJob job = _pendingAdvanceMonthJobs.Dequeue();
            DecrementPendingAdvanceMonthJobCount(job);
            return job;
        }
    }

    private static List<PeriAdvanceMonthDeferredJob>? DrainPendingAdvanceMonthJobs(
        PendingAdvanceMonthJobDrainMode mode,
        int areaId = -1,
        HashSet<int>? areaSet = null)
    {
        lock (_syncRoot)
        {
            if (_pendingAdvanceMonthJobs.Count == 0 ||
                (mode == PendingAdvanceMonthJobDrainMode.Area && !_pendingAdvanceMonthJobCountsByArea.ContainsKey(areaId)) ||
                (mode == PendingAdvanceMonthJobDrainMode.AreaSet && !HasPendingAdvanceMonthJobInAreaSet(areaSet)))
            {
                return null;
            }

            List<PeriAdvanceMonthDeferredJob> selected = new();
            int count = _pendingAdvanceMonthJobs.Count;
            for (int i = 0; i < count; i++)
            {
                PeriAdvanceMonthDeferredJob job = _pendingAdvanceMonthJobs.Dequeue();
                if (ShouldDrainPendingAdvanceMonthJob(job, mode, areaId, areaSet))
                {
                    selected.Add(job);
                    DecrementPendingAdvanceMonthJobCount(job);
                }
                else
                {
                    _pendingAdvanceMonthJobs.Enqueue(job);
                }
            }
            return selected;
        }
    }

    private static bool ShouldDrainPendingAdvanceMonthJob(
        PeriAdvanceMonthDeferredJob job,
        PendingAdvanceMonthJobDrainMode mode,
        int areaId,
        HashSet<int>? areaSet)
    {
        return mode switch
        {
            PendingAdvanceMonthJobDrainMode.All => true,
            PendingAdvanceMonthJobDrainMode.Area => job.AreaId == areaId,
            PendingAdvanceMonthJobDrainMode.AreaSet => areaSet != null && areaSet.Contains(job.AreaId),
            _ => false,
        };
    }

    private static bool HasPendingAdvanceMonthJobInAreaSet(HashSet<int>? areaSet)
    {
        if (areaSet == null || areaSet.Count == 0)
        {
            return false;
        }

        foreach (int areaId in areaSet)
        {
            if (_pendingAdvanceMonthJobCountsByArea.ContainsKey(areaId))
            {
                return true;
            }
        }

        return false;
    }

    private static void EnqueuePendingAdvanceMonthJob(PeriAdvanceMonthDeferredJob job)
    {
        _pendingAdvanceMonthJobs.Enqueue(job);
        Interlocked.Increment(ref _pendingAdvanceMonthJobCount);
        _pendingAdvanceMonthJobCountsByArea.TryGetValue(job.AreaId, out int count);
        _pendingAdvanceMonthJobCountsByArea[job.AreaId] = count + 1;
        _pendingAdvanceMonthJobCountsByKind[(int)job.Kind]++;
    }

    private static void DecrementPendingAdvanceMonthJobCount(PeriAdvanceMonthDeferredJob job)
    {
        if (Interlocked.Decrement(ref _pendingAdvanceMonthJobCount) < 0)
        {
            Volatile.Write(ref _pendingAdvanceMonthJobCount, 0);
        }

        int areaId = job.AreaId;
        int count = _pendingAdvanceMonthJobCountsByArea[areaId] - 1;
        if (count <= 0)
        {
            _pendingAdvanceMonthJobCountsByArea.Remove(areaId);
        }
        else
        {
            _pendingAdvanceMonthJobCountsByArea[areaId] = count;
        }

        int kindIndex = (int)job.Kind;
        if (_pendingAdvanceMonthJobCountsByKind[kindIndex] > 0)
        {
            _pendingAdvanceMonthJobCountsByKind[kindIndex]--;
        }
    }

    private static PeriAdvanceMonthDeferredJobStats ExecuteAdvanceMonthJobsBatched(
        DataContext context,
        List<PeriAdvanceMonthDeferredJob>? jobs,
        bool collectStats = false)
    {
        if (jobs == null)
        {
            return default;
        }

        PeriAdvanceMonthDeferredJobStats stats = default;
        PeriAdvanceMonthDeferredJob? currentBatch = null;
        bool hasPendingApply = false;
        foreach (PeriAdvanceMonthDeferredJob job in jobs)
        {
            if (hasPendingApply && currentBatch != null && (!job.RequiresParallelApply || !currentBatch.CanBatchWith(job)))
            {
                ApplyPendingParallelModifications(context, ref hasPendingApply);
            }

            if (ExecuteDeferredJobWithoutApply(context, job))
            {
                currentBatch = job;
                hasPendingApply = true;
            }

            if (collectStats)
            {
                stats.Count(job.Kind);
            }
        }

        ApplyPendingParallelModifications(context, ref hasPendingApply);
        return stats;
    }

    private static void ExecuteAllPendingAdvanceMonthJobs(DataContext context)
    {
        PeriAdvanceMonthDeferredJob? currentBatch = null;
        bool hasPendingApply = false;
        while (true)
        {
            PeriAdvanceMonthDeferredJob? job = DequeuePendingAdvanceMonthJob();
            if (job == null)
            {
                ApplyPendingParallelModifications(context, ref hasPendingApply);
                return;
            }

            if (hasPendingApply && currentBatch != null && (!job.RequiresParallelApply || !currentBatch.CanBatchWith(job)))
            {
                ApplyPendingParallelModifications(context, ref hasPendingApply);
            }

            if (ExecuteDeferredJobWithoutApply(context, job))
            {
                currentBatch = job;
                hasPendingApply = true;
            }
        }
    }

    private static bool ExecuteDeferredJobWithoutApply(DataContext context, PeriAdvanceMonthDeferredJob job)
    {
        _isReplayingDeferredJob = true;
        try
        {
            job.Execute(context);
            return job.RequiresParallelApply;
        }
        finally
        {
            _isReplayingDeferredJob = false;
        }
    }

    private static void ApplyPendingParallelModifications(DataContext context, ref bool hasPendingApply)
    {
        if (!hasPendingApply)
        {
            return;
        }

        context.ParallelModificationsRecorder.ApplyAll(context);
        hasPendingApply = false;
    }

    private static void ApplyOverrunCooldown(AdvanceMonthOptimizationFrameBudget frameBudget)
    {
        if (!HasPendingAdvanceMonthJobs)
        {
            _overrunCooldownFrames = 0;
            return;
        }

        _overrunCooldownFrames = frameBudget.GetOverrunCooldownFrames(MaxOverrunCooldownFrames);
    }

    /// <summary>
    /// 将本 tick 加入诊断聚合，并在日志间隔到期时写出摘要。
    /// </summary>
    /// <param name="frameBudget">本 tick 使用的帧预算。</param>
    /// <param name="cacheBuildSteps">本 tick 执行的 protection-cache build step 数。</param>
    /// <param name="executedJobStats">本 tick 执行的 deferred job 类型统计。</param>
    private static void RecordAdvanceMonthOptimizationDiagnostics(
        in AdvanceMonthOptimizationFrameBudget frameBudget,
        int cacheBuildSteps,
        in PeriAdvanceMonthDeferredJobStats executedJobStats)
    {
        if (!AdvanceMonthOptimizationDiagnostics.RecordFrame(in frameBudget, cacheBuildSteps, in executedJobStats))
        {
            return;
        }

        int pendingJobCount;
        int overrunCooldownFrames;
        PeriAdvanceMonthDeferredJobStats pendingJobStats;
        lock (_syncRoot)
        {
            pendingJobCount = _pendingAdvanceMonthJobCount;
            overrunCooldownFrames = _overrunCooldownFrames;
            pendingJobStats = GetPendingAdvanceMonthJobStats();
        }

        AdvanceMonthOptimizationDiagnostics.FlushSummary(pendingJobCount, in pendingJobStats, overrunCooldownFrames);
    }

    /// <summary>从维护好的计数器中复制当前 pending 队列构成。</summary>
    private static PeriAdvanceMonthDeferredJobStats GetPendingAdvanceMonthJobStats()
    {
        return new PeriAdvanceMonthDeferredJobStats
        {
            CharacterParallelActionChunks = _pendingAdvanceMonthJobCountsByKind[(int)PeriAdvanceMonthDeferredJobKind.CharacterParallelActionChunk],
            MapBrokenBlockUpdates = _pendingAdvanceMonthJobCountsByKind[(int)PeriAdvanceMonthDeferredJobKind.MapBrokenBlockUpdate],
            AnimalAreaDataUpdates = _pendingAdvanceMonthJobCountsByKind[(int)PeriAdvanceMonthDeferredJobKind.AnimalAreaData],
            SkeletonGenerations = _pendingAdvanceMonthJobCountsByKind[(int)PeriAdvanceMonthDeferredJobKind.SkeletonGeneration],
            MapPickupCleanups = _pendingAdvanceMonthJobCountsByKind[(int)PeriAdvanceMonthDeferredJobKind.MapPickupCleanup],
        };
    }

    private static bool TryDeferAreaLoop(
        DataContext context,
        bool settingEnabled,
        int startAreaId,
        int endAreaId,
        Func<int, PeriAdvanceMonthDeferredJob> createJob,
        Action<DataContext, int> executeSync)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled || !settingEnabled || _isReplayingDeferredJob || !IsAdvancingMonth())
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

    private static bool TryEnqueueAreaJob(PeriAdvanceMonthDeferredJob job)
    {
        lock (_syncRoot)
        {
            if (!_isInAdvanceMonth || IsSyncArea(job.AreaId))
            {
                return false;
            }

            EnqueuePendingAdvanceMonthJob(job);
            return true;
        }
    }

    private static bool CanDeferAreaPeriAdvanceMonthJobs(int areaId)
    {
        lock (_syncRoot)
        {
            return _isInAdvanceMonth && !IsSyncArea(areaId);
        }
    }

    private static void EnqueueAreaJob(PeriAdvanceMonthDeferredJob job)
    {
        lock (_syncRoot)
        {
            EnqueuePendingAdvanceMonthJob(job);
        }
    }

    private static bool IsAdvancingMonth()
    {
        lock (_syncRoot)
        {
            return _isInAdvanceMonth;
        }
    }

    private static HashSet<int>? GetLiveSyncAreaIds()
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            InvalidateLiveSyncAreaCache();
            return null;
        }

        bool includeNeighborStates = TaiwuOptimizationSettings.SyncNeighborStatesForAdvanceMonth;
        if (_liveSyncAreaSource == location.AreaId &&
            _liveSyncAreaIncludesNeighbors == includeNeighborStates)
        {
            return _liveSyncAreaIds;
        }

        _liveSyncAreaIds.Clear();
        AddLiveSyncAreas(areaId => _liveSyncAreaIds.Add(areaId));
        _liveSyncAreaSource = location.AreaId;
        _liveSyncAreaIncludesNeighbors = includeNeighborStates;
        return _liveSyncAreaIds;
    }

    private static void InvalidateLiveSyncAreaCache()
    {
        _liveSyncAreaIds.Clear();
        _liveSyncAreaSource = -1;
        _liveSyncAreaIncludesNeighbors = false;
    }

    private static void AddLiveSyncAreas(Action<short> addArea)
    {
        AddLiveSyncAreas(addArea, TaiwuOptimizationSettings.SyncNeighborStatesForAdvanceMonth);
    }

    private static void AddLiveSyncAreas(Action<short> addArea, bool includeNeighborStates)
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
        AddNeighborStates(location.AreaId, includeNeighborStates, addArea, areaBuffer);
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
