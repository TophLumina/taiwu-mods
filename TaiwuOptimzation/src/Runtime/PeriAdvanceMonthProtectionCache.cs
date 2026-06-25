using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Map;

namespace TaiwuOptimization.Runtime;

internal static class PeriAdvanceMonthProtectionCache
{
    private const int StateAreaCount = 135;

    private static readonly ushort[] DirectRelationTypes =
    {
        1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768,
    };

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
        ProtectedAreas,
        Publish,
    }

    private static readonly object _syncRoot = new();

    private static int _groupVersion;
    private static int _relationVersion;
    private static int _areaVersion;
    private static int _needsFrameBuild = 1;

    private static CacheState _state = CacheState.Invalid;
    private static BuildSession? _buildSession;
    private static TaiwuGroupComponent? _taiwuGroup;
    private static TaiwuRelationComponent? _taiwuRelations;
    private static ProtectedAreaComponent? _protectedAreas;
    private static Snapshot? _snapshot;
    private static Snapshot? _frozenSnapshot;

    /// <summary>尝试取得当前可用快照；快照未完成时返回 `false`，调用方应保持原版行为。</summary>
    public static bool TryGetSnapshot(out Snapshot snapshot)
    {
        lock (_syncRoot)
        {
            if (_frozenSnapshot != null)
            {
                snapshot = _frozenSnapshot;
                return true;
            }

            if (IsSnapshotCurrent(_snapshot))
            {
                _state = CacheState.Ready;
                ClearNeedsFrameBuild();
                snapshot = _snapshot!;
                return true;
            }

            snapshot = null!;
            EnsureBuildSession();
            MarkNeedsFrameBuild();
            return false;
        }
    }

    /// <summary>过月开始时冻结已就绪快照；未就绪时不强制构建，避免增加过月阻塞。</summary>
    public static bool TryFreezeForPeriAdvanceMonth()
    {
        lock (_syncRoot)
        {
            if (!IsSnapshotCurrent(_snapshot))
            {
                EnsureBuildSession();
                MarkNeedsFrameBuild();
                return false;
            }

            _frozenSnapshot = _snapshot;
            _state = CacheState.Frozen;
            ClearNeedsFrameBuild();
            return true;
        }
    }

    /// <summary>过月结束后释放冻结快照；如月结中标记过脏，则恢复到 `Invalid` 等待帧构建。</summary>
    public static void UnfreezePeriAdvanceMonth()
    {
        lock (_syncRoot)
        {
            _frozenSnapshot = null;
            if (IsSnapshotCurrent(_snapshot))
            {
                _state = CacheState.Ready;
                ClearNeedsFrameBuild();
            }
            else
            {
                _state = CacheState.Invalid;
                _buildSession = null;
                MarkNeedsFrameBuild();
            }
        }
    }

    /// <summary>清空所有快照和构建状态，用于初始化、卸载、退出世界或切档。</summary>
    public static void Reset()
    {
        lock (_syncRoot)
        {
            _groupVersion++;
            _relationVersion++;
            _areaVersion++;
            _taiwuGroup = null;
            _taiwuRelations = null;
            _protectedAreas = null;
            _snapshot = null;
            _frozenSnapshot = null;
            _buildSession = null;
            _state = CacheState.Invalid;
            MarkNeedsFrameBuild();
        }
    }

    /// <summary>设置改变后让全部保护数据失效。</summary>
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

    /// <summary>太吾队伍变化会影响队伍本身和直接关系保护集合。</summary>
    public static void MarkTaiwuGroupDirty()
    {
        lock (_syncRoot)
        {
            _groupVersion++;
            _relationVersion++;
            InvalidateCurrentSnapshot();
        }
    }

    /// <summary>只在关系变化涉及太吾/队友时重建关系保护集合。</summary>
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

    /// <summary>太吾位置变化后重建当前州域/相邻州域保护集合。</summary>
    public static void MarkProtectedAreasDirty()
    {
        lock (_syncRoot)
        {
            _areaVersion++;
            InvalidateCurrentSnapshot();
        }
    }

    public static bool NeedsFrameBuild()
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            return false;
        }

        lock (_syncRoot)
        {
            if (_state != CacheState.Frozen && !IsSnapshotCurrent(_snapshot))
            {
                MarkNeedsFrameBuild();
            }

            return Volatile.Read(ref _needsFrameBuild) != 0;
        }
    }

    /// <summary>在帧预算中推进一次保护快照构建。</summary>
    /// <param name="frameBudget">当前帧预算。</param>
    /// <returns>本帧执行的构建步骤数。</returns>
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

            ExecuteBuildStep();
            return 1;
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
        bool includeNeighborAreas = TaiwuOptimizationSettings.ProtectNeighborStatesForAdvanceMonthOptimization;
        bool hasAreaSource = TryGetProtectedAreaCacheKey(includeNeighborAreas, out short areaSource);
        TaiwuGroupComponent? group = IsGroupCurrent(_taiwuGroup) ? _taiwuGroup : null;
        TaiwuRelationComponent? relations = IsRelationSetCurrent(_taiwuRelations) ? _taiwuRelations : null;
        ProtectedAreaComponent? areas = IsAreaSetCurrent(_protectedAreas, hasAreaSource, areaSource, includeNeighborAreas)
            ? _protectedAreas
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
                    session.Stage = BuildStage.ProtectedAreas;
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
                    session.Stage = BuildStage.ProtectedAreas;
                    break;
                }

                AddBaseDirectRelations(session.RelationAnchors[session.RelationAnchorIndex], session.RelationCharIds!);
                session.RelationTypeIndex = 0;
                session.Stage = BuildStage.RelationAnchorReverse;
                break;
            case BuildStage.RelationAnchorReverse:
                if (session.RelationAnchors == null || session.RelationCharIds == null)
                {
                    session.Stage = BuildStage.ProtectedAreas;
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
            case BuildStage.ProtectedAreas:
                session.ProtectedAreas ??= new ProtectedAreaComponent(
                    session.AreaVersion,
                    session.HasProtectedAreaSource,
                    session.ProtectedAreaSource,
                    session.ProtectedAreaIncludesNeighbors,
                    BuildProtectedAreaIds(session.ProtectedAreaIncludesNeighbors));
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
        _protectedAreas = session.ProtectedAreas;
        _snapshot = new Snapshot(session.Group!, session.Relations!, session.ProtectedAreas!);
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

        bool includeNeighborAreas = TaiwuOptimizationSettings.ProtectNeighborStatesForAdvanceMonthOptimization;
        bool hasAreaSource = TryGetProtectedAreaCacheKey(includeNeighborAreas, out short areaSource);
        return session.HasProtectedAreaSource == hasAreaSource &&
            session.ProtectedAreaSource == areaSource &&
            session.ProtectedAreaIncludesNeighbors == includeNeighborAreas;
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
        if (snapshot == null || !snapshot.IsCurrent(_groupVersion, _relationVersion, _areaVersion))
        {
            return false;
        }

        bool includeNeighborAreas = TaiwuOptimizationSettings.ProtectNeighborStatesForAdvanceMonthOptimization;
        bool hasAreaSource = TryGetProtectedAreaCacheKey(includeNeighborAreas, out short areaSource);
        return snapshot.MatchesProtectedAreaKey(hasAreaSource, areaSource, includeNeighborAreas);
    }

    private static bool IsGroupCurrent(TaiwuGroupComponent? group) =>
        group != null && group.Version == _groupVersion;

    private static bool IsRelationSetCurrent(TaiwuRelationComponent? relations) =>
        relations != null && relations.Version == _relationVersion && relations.GroupVersion == _groupVersion;

    private static bool IsAreaSetCurrent(
        ProtectedAreaComponent? areas,
        bool hasSourceArea,
        short sourceAreaId,
        bool includeNeighborAreas) =>
        areas != null &&
        areas.Version == _areaVersion &&
        areas.MatchesKey(hasSourceArea, sourceAreaId, includeNeighborAreas);

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

    private static HashSet<int> BuildProtectedAreaIds(bool includeNeighborAreas)
    {
        HashSet<int> areaIds = new();
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return areaIds;
        }

        areaIds.Add(location.AreaId);
        if (location.AreaId < 0 || location.AreaId >= StateAreaCount)
        {
            return areaIds;
        }

        List<short> areaBuffer = new(16);
        sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
        AddAreasInState(stateId, areaIds, areaBuffer);

        if (includeNeighborAreas)
        {
            sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
            foreach (sbyte neighborStateTemplateId in MapState.Instance[stateTemplateId].NeighborStates)
            {
                sbyte neighborStateId = DomainManager.Map.GetStateIdByStateTemplateId(neighborStateTemplateId);
                AddAreasInState(neighborStateId, areaIds, areaBuffer);
            }
        }

        return areaIds;
    }

    private static void AddAreasInState(sbyte stateId, HashSet<int> areaIds, List<short> areaBuffer)
    {
        if (stateId < 0)
        {
            return;
        }

        areaBuffer.Clear();
        DomainManager.Map.GetAllAreaInState(stateId, areaBuffer);
        foreach (short areaId in areaBuffer)
        {
            areaIds.Add(areaId);
        }
    }

    private static bool TryGetProtectedAreaCacheKey(bool includeNeighborAreas, out short areaId)
    {
        areaId = -1;
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return false;
        }

        areaId = location.AreaId;
        _ = includeNeighborAreas;
        return true;
    }

    private static void AddBaseDirectRelations(int anchorCharId, HashSet<int> relatedCharIds)
    {
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

    private sealed class BuildSession
    {
        public readonly int GroupVersion;
        public readonly int RelationVersion;
        public readonly int AreaVersion;
        public readonly bool HasProtectedAreaSource;
        public readonly short ProtectedAreaSource;
        public readonly bool ProtectedAreaIncludesNeighbors;

        public BuildStage Stage;
        public TaiwuGroupComponent? Group;
        public TaiwuRelationComponent? Relations;
        public ProtectedAreaComponent? ProtectedAreas;
        public HashSet<int>? RelationCharIds;
        public int[]? RelationAnchors;
        public int RelationAnchorIndex;
        public int RelationTypeIndex;

        public BuildSession(
            int groupVersion,
            int relationVersion,
            int areaVersion,
            bool hasProtectedAreaSource,
            short protectedAreaSource,
            bool protectedAreaIncludesNeighbors,
            TaiwuGroupComponent? group,
            TaiwuRelationComponent? relations,
            ProtectedAreaComponent? protectedAreas)
        {
            GroupVersion = groupVersion;
            RelationVersion = relationVersion;
            AreaVersion = areaVersion;
            HasProtectedAreaSource = hasProtectedAreaSource;
            ProtectedAreaSource = protectedAreaSource;
            ProtectedAreaIncludesNeighbors = protectedAreaIncludesNeighbors;
            Group = group;
            Relations = relations;
            ProtectedAreas = protectedAreas;
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

    internal sealed class ProtectedAreaComponent
    {
        public readonly int Version;
        private readonly bool _hasSourceArea;
        private readonly short _sourceAreaId;
        private readonly bool _includesNeighborAreas;
        public readonly HashSet<int> AreaIds;

        public ProtectedAreaComponent(
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
        private readonly ProtectedAreaComponent _protectedAreas;

        internal Snapshot(
            TaiwuGroupComponent taiwuGroup,
            TaiwuRelationComponent taiwuRelations,
            ProtectedAreaComponent protectedAreas)
        {
            _taiwuGroup = taiwuGroup;
            _taiwuRelations = taiwuRelations;
            _protectedAreas = protectedAreas;
        }

        public bool IsCurrent(int groupVersion, int relationVersion, int areaVersion) =>
            _taiwuGroup.Version == groupVersion &&
            _taiwuRelations.Version == relationVersion &&
            _taiwuRelations.GroupVersion == groupVersion &&
            _protectedAreas.Version == areaVersion;

        public bool MatchesProtectedAreaKey(bool hasSourceArea, short sourceAreaId, bool includesNeighborAreas) =>
            _protectedAreas.MatchesKey(hasSourceArea, sourceAreaId, includesNeighborAreas);

        public bool IsTaiwuOrGroupMember(int charId) =>
            _taiwuGroup.CharIds.Contains(charId);

        public bool IsDirectlyRelatedToTaiwuGroup(int charId) =>
            _taiwuRelations.CharIds.Contains(charId);

        public bool IsProtectedArea(short areaId) =>
            areaId >= 0 && _protectedAreas.AreaIds.Contains(areaId);

        public bool HasActionTargetInTaiwuGroup(CharacterActionData? actionData)
        {
            if (actionData == null)
            {
                return false;
            }

            int[] targetCharIds = actionData.TargetCharIds;
            for (int i = 0; i < targetCharIds.Length; i++)
            {
                if (IsTaiwuOrGroupMember(targetCharIds[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
