using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Domains;
using NLog;

namespace TaiwuOptimization.Runtime;

internal static class PeriAdvanceMonthProtectionCache
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    private enum CacheState
    {
        Invalid,
        Building,
        Ready,
        Frozen,
    }

    private enum BuildStage
    {
        Group,
        RelationsInit,
        RelationAnchorBase,
        RelationAnchorReverse,
        Areas,
        Publish,
    }

    private static readonly ushort[] DirectRelationTypes =
    {
        1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768,
    };

    private static readonly object _syncRoot = new();

    private static int _groupVersion;
    private static int _relationVersion;
    private static int _areaVersion;
    private static int _needsFrameBuild = 1;

    private static CacheState _state = CacheState.Invalid;
    private static BuildSession? _buildSession;
    private static TaiwuGroupComponent? _taiwuGroup;
    private static TaiwuRelationComponent? _taiwuRelations;
    private static LiveSyncAreaComponent? _liveSyncAreas;
    private static Snapshot? _snapshot;
    private static Snapshot? _frozenSnapshot;

    public static Snapshot GetSnapshot() =>
        GetOrBuildSnapshot(freeze: false);

    public static void FreezeForPeriAdvanceMonth() =>
        GetOrBuildSnapshot(freeze: true);

    public static void UnfreezePeriAdvanceMonth()
    {
        lock (_syncRoot)
        {
            _frozenSnapshot = null;
            _state = IsSnapshotCurrent(_snapshot) ? CacheState.Ready : CacheState.Invalid;
            if (_state == CacheState.Invalid)
            {
                _buildSession = null;
                MarkNeedsFrameBuild();
            }
            else
            {
                ClearNeedsFrameBuild();
            }
        }
    }

    public static void Reset()
    {
        lock (_syncRoot)
        {
            _groupVersion++;
            _relationVersion++;
            _areaVersion++;
            _taiwuGroup = null;
            _taiwuRelations = null;
            _liveSyncAreas = null;
            _snapshot = null;
            _frozenSnapshot = null;
            _buildSession = null;
            _state = CacheState.Invalid;
            MarkNeedsFrameBuild();
        }
    }

    public static void MarkAllDirty()
    {
        lock (_syncRoot)
        {
            _groupVersion++;
            _relationVersion++;
            _areaVersion++;
            InvalidateCurrentSnapshot();
        }
    }

    public static void MarkTaiwuGroupDirty()
    {
        lock (_syncRoot)
        {
            _groupVersion++;
            _relationVersion++;
            InvalidateCurrentSnapshot();
        }
    }

    public static void MarkRelationDirtyIfTaiwuGroupRelated(int charId, int relatedCharId)
    {
        lock (_syncRoot)
        {
            if (IsCachedTaiwuGroupMember(charId) || IsCachedTaiwuGroupMember(relatedCharId))
            {
                _relationVersion++;
                InvalidateCurrentSnapshot();
            }
        }
    }

    public static void MarkLiveSyncAreasDirty()
    {
        lock (_syncRoot)
        {
            _areaVersion++;
            InvalidateCurrentSnapshot();
        }
    }

    public static bool NeedsFrameBuild()
    {
        return TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
            Volatile.Read(ref _needsFrameBuild) != 0;
    }

    /// <summary>
    /// 在帧预算内最多推进一个 protection-cache build step。
    /// </summary>
    /// <param name="frameBudget">与 deferred job 共享的当前帧预算。</param>
    /// <returns>本 tick 执行的 cache build step 数。</returns>
    public static int TickBuildPeriAdvanceMonthProtection(in AdvanceMonthOptimizationFrameBudget frameBudget)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled || !frameBudget.HasTimeRemaining())
        {
            return 0;
        }

        lock (_syncRoot)
        {
            if (_state == CacheState.Frozen || IsSnapshotCurrent(_snapshot))
            {
                if (_state != CacheState.Frozen)
                {
                    _state = CacheState.Ready;
                }

                ClearNeedsFrameBuild();
                return 0;
            }

            EnsureBuildSession();
            if (!frameBudget.HasTimeRemaining())
            {
                return 0;
            }

            if (TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
            {
                BuildStepLogContext logContext = CaptureBuildStepLogContext();
                long startedAt = Stopwatch.GetTimestamp();
                ExecuteBuildStep();
                LogFrameBuildStepOverrun(logContext, Stopwatch.GetTimestamp() - startedAt, frameBudget.BudgetTicks);
            }
            else
            {
                ExecuteBuildStep();
            }

            return 1;
        }
    }

    private static Snapshot GetOrBuildSnapshot(bool freeze)
    {
        long synchronousBuildStartedAt = 0;
        int synchronousBuildSteps = 0;
        while (true)
        {
            lock (_syncRoot)
            {
                if (_state == CacheState.Frozen && _frozenSnapshot != null)
                {
                    return _frozenSnapshot;
                }

                if (IsSnapshotCurrent(_snapshot))
                {
                    _state = freeze ? CacheState.Frozen : CacheState.Ready;
                    if (freeze)
                    {
                        _frozenSnapshot = _snapshot;
                    }

                    ClearNeedsFrameBuild();
                    LogSynchronousBuildIfNeeded(freeze, synchronousBuildStartedAt, synchronousBuildSteps);
                    return _snapshot!;
                }

                EnsureBuildSession();
                if (freeze &&
                    TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled &&
                    synchronousBuildStartedAt == 0)
                {
                    synchronousBuildStartedAt = Stopwatch.GetTimestamp();
                }

                ExecuteBuildStep();
                if (freeze)
                {
                    synchronousBuildSteps++;
                }
            }
        }
    }

    private static void EnsureBuildSession()
    {
        if (_state == CacheState.Building && _buildSession != null)
        {
            return;
        }

        _buildSession = CreateBuildSession();
        _state = CacheState.Building;
    }

    private static BuildSession CreateBuildSession()
    {
        bool includeNeighborAreas = TaiwuOptimizationSettings.ProtectNeighborStatesFromOfflineActionPointReduction;
        bool hasAreaSource = AdvanceMonthOptimizationRuntime.TryGetLiveSyncAreaCacheKey(
            includeNeighborAreas,
            out short areaSource);

        TaiwuGroupComponent? group = IsGroupCurrent(_taiwuGroup) ? _taiwuGroup : null;
        TaiwuRelationComponent? relations = IsRelationSetCurrent(_taiwuRelations) ? _taiwuRelations : null;
        LiveSyncAreaComponent? areas = IsAreaSetCurrent(_liveSyncAreas, hasAreaSource, areaSource, includeNeighborAreas)
            ? _liveSyncAreas
            : null;

        return new BuildSession(
            _groupVersion,
            _relationVersion,
            _areaVersion,
            hasAreaSource,
            areaSource,
            includeNeighborAreas,
            group,
            relations,
            areas);
    }

    private static void ExecuteBuildStep()
    {
        BuildSession? session = _buildSession;
        if (session == null)
        {
            return;
        }

        switch (session.Stage)
        {
            case BuildStage.Group:
                session.Group ??= new TaiwuGroupComponent(session.GroupVersion, BuildTaiwuGroupCharIds());
                session.Stage = BuildStage.RelationsInit;
                break;
            case BuildStage.RelationsInit:
                if (session.Relations != null)
                {
                    session.Stage = BuildStage.Areas;
                    break;
                }

                session.RelationCharIds = new HashSet<int>(session.Group!.CharIds);
                session.RelationAnchors = ToArray(session.Group.CharIds);
                session.RelationAnchorIndex = 0;
                session.RelationTypeIndex = 0;
                session.Stage = BuildStage.RelationAnchorBase;
                break;
            case BuildStage.RelationAnchorBase:
                if (session.RelationAnchors == null || session.RelationAnchorIndex >= session.RelationAnchors.Length)
                {
                    session.Relations = new TaiwuRelationComponent(
                        session.RelationVersion,
                        session.GroupVersion,
                        session.RelationCharIds ?? new HashSet<int>());
                    session.Stage = BuildStage.Areas;
                    break;
                }

                AddBaseDirectRelations(session.RelationAnchors[session.RelationAnchorIndex], session.RelationCharIds!);
                session.RelationTypeIndex = 0;
                session.Stage = BuildStage.RelationAnchorReverse;
                break;
            case BuildStage.RelationAnchorReverse:
                if (session.RelationAnchors == null || session.RelationCharIds == null)
                {
                    session.Stage = BuildStage.Areas;
                    break;
                }

                if (session.RelationTypeIndex < DirectRelationTypes.Length)
                {
                    AddReversedDirectRelation(
                        session.RelationAnchors[session.RelationAnchorIndex],
                        DirectRelationTypes[session.RelationTypeIndex],
                        session.RelationCharIds);
                    session.RelationTypeIndex++;
                    break;
                }

                session.RelationAnchorIndex++;
                session.Stage = BuildStage.RelationAnchorBase;
                break;
            case BuildStage.Areas:
                session.Areas ??= new LiveSyncAreaComponent(
                    session.AreaVersion,
                    session.HasLiveSyncAreaSource,
                    session.LiveSyncAreaSource,
                    session.LiveSyncAreaIncludesNeighbors,
                    BuildLiveSyncAreaIds(session.LiveSyncAreaIncludesNeighbors));
                session.Stage = BuildStage.Publish;
                break;
            case BuildStage.Publish:
                PublishBuildSession(session);
                break;
        }
    }

    private static void PublishBuildSession(BuildSession session)
    {
        if (!IsBuildSessionCurrent(session))
        {
            _buildSession = null;
            _state = CacheState.Invalid;
            MarkNeedsFrameBuild();
            return;
        }

        _taiwuGroup = session.Group;
        _taiwuRelations = session.Relations;
        _liveSyncAreas = session.Areas;
        _snapshot = new Snapshot(session.Group!, session.Relations!, session.Areas!);
        _buildSession = null;
        _state = CacheState.Ready;
        ClearNeedsFrameBuild();
    }

    private static bool IsBuildSessionCurrent(BuildSession session)
    {
        if (session.GroupVersion != _groupVersion ||
            session.RelationVersion != _relationVersion ||
            session.AreaVersion != _areaVersion)
        {
            return false;
        }

        bool includeNeighborAreas = TaiwuOptimizationSettings.ProtectNeighborStatesFromOfflineActionPointReduction;
        bool hasAreaSource = AdvanceMonthOptimizationRuntime.TryGetLiveSyncAreaCacheKey(
            includeNeighborAreas,
            out short areaSource);

        return session.HasLiveSyncAreaSource == hasAreaSource &&
            session.LiveSyncAreaSource == areaSource &&
            session.LiveSyncAreaIncludesNeighbors == includeNeighborAreas;
    }

    private static void InvalidateCurrentSnapshot()
    {
        _snapshot = null;
        _buildSession = null;
        if (_state != CacheState.Frozen)
        {
            _state = CacheState.Invalid;
        }

        MarkNeedsFrameBuild();
    }

    private static void MarkNeedsFrameBuild() =>
        Volatile.Write(ref _needsFrameBuild, 1);

    private static void ClearNeedsFrameBuild() =>
        Volatile.Write(ref _needsFrameBuild, 0);

    private static bool IsSnapshotCurrent(Snapshot? snapshot)
    {
        if (snapshot == null ||
            !snapshot.IsCurrent(_groupVersion, _relationVersion, _areaVersion))
        {
            return false;
        }

        bool includeNeighborAreas = TaiwuOptimizationSettings.ProtectNeighborStatesFromOfflineActionPointReduction;
        bool hasAreaSource = AdvanceMonthOptimizationRuntime.TryGetLiveSyncAreaCacheKey(
            includeNeighborAreas,
            out short areaSource);

        return snapshot.MatchesLiveSyncAreaKey(hasAreaSource, areaSource, includeNeighborAreas);
    }

    private static bool IsGroupCurrent(TaiwuGroupComponent? group) =>
        group != null && group.Version == _groupVersion;

    private static bool IsRelationSetCurrent(TaiwuRelationComponent? relations) =>
        relations != null &&
        relations.Version == _relationVersion &&
        relations.GroupVersion == _groupVersion;

    private static bool IsAreaSetCurrent(
        LiveSyncAreaComponent? areas,
        bool hasAreaSource,
        short areaSource,
        bool includeNeighborAreas) =>
        areas != null &&
        areas.Version == _areaVersion &&
        areas.MatchesKey(hasAreaSource, areaSource, includeNeighborAreas);

    private static bool IsCachedTaiwuGroupMember(int charId)
    {
        if (_frozenSnapshot != null)
        {
            return _frozenSnapshot.IsTaiwuOrGroupMember(charId);
        }

        if (_taiwuGroup != null)
        {
            return _taiwuGroup.CharIds.Contains(charId);
        }

        int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
        return charId == taiwuCharId || DomainManager.Taiwu.IsInGroup(charId);
    }

    private static HashSet<int> BuildTaiwuGroupCharIds()
    {
        HashSet<int> charIds = new();
        int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
        AddValidCharId(charIds, taiwuCharId);

        foreach (int charId in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
        {
            AddValidCharId(charIds, charId);
        }

        if (taiwuCharId >= 0)
        {
            foreach (int charId in DomainManager.Character.GetSpecialGroup(taiwuCharId))
            {
                AddValidCharId(charIds, charId);
            }
        }

        return charIds;
    }

    private static HashSet<int> BuildLiveSyncAreaIds(bool includeNeighborAreas)
    {
        HashSet<int> areaIds = new();
        AdvanceMonthOptimizationRuntime.CopyLiveSyncAreaIdsTo(areaIds, includeNeighborAreas);
        return areaIds;
    }

    private static void AddBaseDirectRelations(int anchorCharId, HashSet<int> relatedCharIds)
    {
        // 先调用一次原版索引关系接口，后续热判断只走 HashSet.Contains。
        DomainManager.Character.GetAllRelatedCharIds(anchorCharId, relatedCharIds, includeGeneral: false);
        DomainManager.Character.GetAllTwoWayRelatedCharIds(anchorCharId, relatedCharIds);
    }

    private static void AddReversedDirectRelation(int anchorCharId, ushort relationType, HashSet<int> relatedCharIds)
    {
        foreach (int charId in DomainManager.Character.GetReversedRelatedCharIds(anchorCharId, relationType).GetCollection())
        {
            AddValidCharId(relatedCharIds, charId);
        }
    }

    private static void AddValidCharId(HashSet<int> charIds, int charId)
    {
        if (charId >= 0)
        {
            charIds.Add(charId);
        }
    }

    private static int[] ToArray(HashSet<int> values)
    {
        int[] result = new int[values.Count];
        values.CopyTo(result);
        return result;
    }

    private static BuildStepLogContext CaptureBuildStepLogContext()
    {
        BuildSession? session = _buildSession;
        if (session == null)
        {
            return default;
        }

        int anchorCharId = -1;
        ushort relationType = 0;
        if (session.RelationAnchors != null &&
            session.RelationAnchorIndex >= 0 &&
            session.RelationAnchorIndex < session.RelationAnchors.Length)
        {
            anchorCharId = session.RelationAnchors[session.RelationAnchorIndex];
        }

        if (session.Stage == BuildStage.RelationAnchorReverse &&
            session.RelationTypeIndex >= 0 &&
            session.RelationTypeIndex < DirectRelationTypes.Length)
        {
            relationType = DirectRelationTypes[session.RelationTypeIndex];
        }

        return new BuildStepLogContext(
            session.Stage,
            session.RelationAnchorIndex,
            anchorCharId,
            session.RelationTypeIndex,
            relationType);
    }

    private static void LogFrameBuildStepOverrun(
        BuildStepLogContext context,
        long elapsedTicks,
        long budgetTicks)
    {
        if (elapsedTicks <= budgetTicks)
        {
            return;
        }

        AdvanceMonthOptimizationDiagnostics.RecordCacheStepOverrun();
        if (!Logger.IsWarnEnabled)
        {
            return;
        }

        Logger.Warn(
            "TaiwuOptimization: PeriAdvanceMonthProtectionCache build step exceeded frame budget. " +
            "stage={0}, anchorIndex={1}, anchorCharId={2}, relationTypeIndex={3}, relationType={4}, " +
            "elapsed={5:N3}ms, budget={6:N3}ms.",
            context.Stage,
            context.AnchorIndex,
            context.AnchorCharId,
            context.RelationTypeIndex,
            context.RelationType,
            TicksToMilliseconds(elapsedTicks),
            TicksToMilliseconds(budgetTicks));
    }

    private static void LogSynchronousBuildIfNeeded(bool freeze, long startedAt, int steps)
    {
        if (!freeze ||
            steps <= 0 ||
            !TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            return;
        }

        long elapsedTicks = Stopwatch.GetTimestamp() - startedAt;
        AdvanceMonthOptimizationDiagnostics.RecordSynchronousCacheBuild(steps, elapsedTicks);
        if (!Logger.IsInfoEnabled)
        {
            return;
        }

        Logger.Info(
            "TaiwuOptimization: PeriAdvanceMonthProtectionCache was completed synchronously before AdvanceMonth. " +
            "steps={0}, elapsed={1:N3}ms.",
            steps,
            TicksToMilliseconds(elapsedTicks));
    }

    private static double TicksToMilliseconds(long ticks) =>
        ticks * 1000.0 / Stopwatch.Frequency;

    private readonly struct BuildStepLogContext
    {
        // ExecuteBuildStep 改变索引前的 builder 状态快照。
        public readonly BuildStage Stage;
        public readonly int AnchorIndex;
        public readonly int AnchorCharId;
        public readonly int RelationTypeIndex;
        public readonly ushort RelationType;

        public BuildStepLogContext(
            BuildStage stage,
            int anchorIndex,
            int anchorCharId,
            int relationTypeIndex,
            ushort relationType)
        {
            Stage = stage;
            AnchorIndex = anchorIndex;
            AnchorCharId = anchorCharId;
            RelationTypeIndex = relationTypeIndex;
            RelationType = relationType;
        }
    }

    private sealed class BuildSession
    {
        public readonly int GroupVersion;
        public readonly int RelationVersion;
        public readonly int AreaVersion;
        public readonly bool HasLiveSyncAreaSource;
        public readonly short LiveSyncAreaSource;
        public readonly bool LiveSyncAreaIncludesNeighbors;

        public BuildStage Stage;
        public TaiwuGroupComponent? Group;
        public TaiwuRelationComponent? Relations;
        public LiveSyncAreaComponent? Areas;
        public HashSet<int>? RelationCharIds;
        public int[]? RelationAnchors;
        public int RelationAnchorIndex;
        public int RelationTypeIndex;

        public BuildSession(
            int groupVersion,
            int relationVersion,
            int areaVersion,
            bool hasLiveSyncAreaSource,
            short liveSyncAreaSource,
            bool liveSyncAreaIncludesNeighbors,
            TaiwuGroupComponent? group,
            TaiwuRelationComponent? relations,
            LiveSyncAreaComponent? areas)
        {
            GroupVersion = groupVersion;
            RelationVersion = relationVersion;
            AreaVersion = areaVersion;
            HasLiveSyncAreaSource = hasLiveSyncAreaSource;
            LiveSyncAreaSource = liveSyncAreaSource;
            LiveSyncAreaIncludesNeighbors = liveSyncAreaIncludesNeighbors;
            Group = group;
            Relations = relations;
            Areas = areas;
            Stage = BuildStage.Group;
        }
    }

    internal sealed class TaiwuGroupComponent
    {
        public readonly int Version;
        public readonly HashSet<int> CharIds;

        public TaiwuGroupComponent(int version, HashSet<int> charIds)
        {
            Version = version;
            CharIds = charIds;
        }
    }

    internal sealed class TaiwuRelationComponent
    {
        public readonly int Version;
        public readonly int GroupVersion;
        public readonly HashSet<int> CharIds;

        public TaiwuRelationComponent(int version, int groupVersion, HashSet<int> charIds)
        {
            Version = version;
            GroupVersion = groupVersion;
            CharIds = charIds;
        }
    }

    internal sealed class LiveSyncAreaComponent
    {
        public readonly int Version;
        private readonly bool _hasSourceArea;
        private readonly short _sourceAreaId;
        private readonly bool _includesNeighborAreas;
        public readonly HashSet<int> AreaIds;

        public LiveSyncAreaComponent(
            int version,
            bool hasSourceArea,
            short sourceAreaId,
            bool includesNeighborAreas,
            HashSet<int> areaIds)
        {
            Version = version;
            _hasSourceArea = hasSourceArea;
            _sourceAreaId = sourceAreaId;
            _includesNeighborAreas = includesNeighborAreas;
            AreaIds = areaIds;
        }

        public bool MatchesKey(bool hasSourceArea, short sourceAreaId, bool includesNeighborAreas) =>
            _hasSourceArea == hasSourceArea &&
            _sourceAreaId == sourceAreaId &&
            _includesNeighborAreas == includesNeighborAreas;
    }

    internal sealed class Snapshot
    {
        private readonly TaiwuGroupComponent _taiwuGroup;
        private readonly TaiwuRelationComponent _taiwuRelations;
        private readonly LiveSyncAreaComponent _liveSyncAreas;

        internal Snapshot(
            TaiwuGroupComponent taiwuGroup,
            TaiwuRelationComponent taiwuRelations,
            LiveSyncAreaComponent liveSyncAreas)
        {
            _taiwuGroup = taiwuGroup;
            _taiwuRelations = taiwuRelations;
            _liveSyncAreas = liveSyncAreas;
        }

        public bool IsCurrent(int groupVersion, int relationVersion, int areaVersion) =>
            _taiwuGroup.Version == groupVersion &&
            _taiwuRelations.Version == relationVersion &&
            _taiwuRelations.GroupVersion == groupVersion &&
            _liveSyncAreas.Version == areaVersion;

        public bool MatchesLiveSyncAreaKey(
            bool hasSourceArea,
            short sourceAreaId,
            bool includesNeighborAreas) =>
            _liveSyncAreas.MatchesKey(hasSourceArea, sourceAreaId, includesNeighborAreas);

        public bool IsTaiwuOrGroupMember(int charId) =>
            _taiwuGroup.CharIds.Contains(charId);

        public bool IsDirectlyRelatedToTaiwuGroup(int charId) =>
            _taiwuRelations.CharIds.Contains(charId);

        public bool IsLiveSyncArea(short areaId) =>
            areaId >= 0 && _liveSyncAreas.AreaIds.Contains(areaId);

        public bool HasActionTargetInTaiwuGroup(CharacterActionData? actionData)
        {
            if (actionData == null)
            {
                return false;
            }

            int[] targetCharIds = actionData.TargetCharIds;
            for (int i = 0; i < targetCharIds.Length; i++)
            {
                int targetCharId = targetCharIds[i];
                if (IsTaiwuOrGroupMember(targetCharId))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
