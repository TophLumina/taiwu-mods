using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using Config;
using GameData.Domains.Character;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class CharacterActionTargetMatcherStageCache
{
    private static readonly ConcurrentDictionary<TargetMatcherKey, bool> StageCache = new();
    private static readonly ConcurrentDictionary<int, TargetVersionState> TargetVersions = new();

    private static volatile bool _stageActive;
    private static int _taiwuGroupVersion;
    private static int _crossAreaTravelVersion;
    private static int _adventureTaiwuVersion;

    [ThreadStatic]
    private static int _offlineCurrentGoalActionScopeDepth;

    /// <summary>进入主/副目标行动规划阶段，清空上一阶段缓存并冻结本阶段读取语义。</summary>
    public static void BeginUpdateCurrentGoalActionsStage()
    {
        StageCache.Clear();
        TargetVersions.Clear();
        _stageActive = IsEnabled();
    }

    /// <summary>离开主/副目标行动规划阶段，释放阶段缓存。</summary>
    public static void EndUpdateCurrentGoalActionsStage()
    {
        _stageActive = false;
        StageCache.Clear();
        TargetVersions.Clear();
    }

    /// <summary>进入原版 `OfflineUpdateCurrentGoalActions` 热路径。</summary>
    public static void EnterOfflineCurrentGoalActions()
    {
        if (_stageActive)
        {
            _offlineCurrentGoalActionScopeDepth++;
        }
    }

    /// <summary>离开原版 `OfflineUpdateCurrentGoalActions` 热路径。</summary>
    public static void LeaveOfflineCurrentGoalActions()
    {
        if (_offlineCurrentGoalActionScopeDepth > 0)
        {
            _offlineCurrentGoalActionScopeDepth--;
        }
    }

    /// <summary>目标角色发生无法分类的状态变化时，推进全部目标版本。</summary>
    public static void InvalidateTarget(int targetCharId)
    {
        if (!_stageActive || targetCharId < 0)
        {
            return;
        }

        TargetVersionState state = GetTargetVersionState(targetCharId);
        Bump(ref state.Age);
        Bump(ref state.Relation);
        Bump(ref state.Organization);
        Bump(ref state.Inventory);
        Bump(ref state.Equipment);
        Bump(ref state.Location);
        Bump(ref state.ExternalRelation);
        Bump(ref state.Kidnapper);
        Bump(ref state.Leader);
    }

    /// <summary>双向关系变化会影响两名角色各自作为 target 时的 matcher 结果。</summary>
    public static void InvalidateTargets(int firstCharId, int secondCharId)
    {
        InvalidateTarget(firstCharId);
        if (secondCharId != firstCharId)
        {
            InvalidateTarget(secondCharId);
        }
    }

    /// <summary>关系或好感变化只推进关系版本。</summary>
    public static void InvalidateRelationTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Relation));

    /// <summary>双向关系变化影响两名角色作为 target 的关系 matcher。</summary>
    public static void InvalidateRelationTargets(int firstCharId, int secondCharId)
    {
        InvalidateRelationTarget(firstCharId);
        if (secondCharId != firstCharId)
        {
            InvalidateRelationTarget(secondCharId);
        }
    }

    /// <summary>组织身份变化只推进组织版本。</summary>
    public static void InvalidateOrganizationTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Organization));

    /// <summary>背包变化只推进背包版本。</summary>
    public static void InvalidateInventoryTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Inventory));

    /// <summary>装备变化只推进装备版本。</summary>
    public static void InvalidateEquipmentTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Equipment));

    /// <summary>所在地变化只推进位置版本。</summary>
    public static void InvalidateLocationTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Location));

    public static void InvalidateExternalRelationTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.ExternalRelation));

    public static void InvalidateKidnapperTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Kidnapper));

    public static void InvalidateLeaderTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Leader));

    public static void InvalidateCrossAreaTravel()
    {
        if (_stageActive)
        {
            Bump(ref _crossAreaTravelVersion);
        }
    }

    public static void InvalidateAdventureTaiwu()
    {
        if (_stageActive)
        {
            Bump(ref _adventureTaiwuVersion);
        }
    }

    /// <summary>年龄段变化只推进年龄版本。</summary>
    public static void InvalidateAgeTarget(int targetCharId) =>
        InvalidateTargetVersion(targetCharId, static state => Bump(ref state.Age));

    /// <summary>太吾队伍变化会影响所有 `NotInTaiwuGroup` matcher。</summary>
    public static void InvalidateTaiwuGroup()
    {
        if (_stageActive)
        {
            Bump(ref _taiwuGroupVersion);
        }
    }

    /// <summary>批量关系重写等无法精确定位时，清空本阶段 matcher 缓存但保留优化入口。</summary>
    public static void InvalidateAll()
    {
        if (!_stageActive)
        {
            return;
        }

        StageCache.Clear();
        TargetVersions.Clear();
        Bump(ref _taiwuGroupVersion);
    }

    /// <summary>清理全部运行时状态，供退出世界、切档或插件卸载时调用。</summary>
    public static void Reset()
    {
        _stageActive = false;
        StageCache.Clear();
        TargetVersions.Clear();
        _offlineCurrentGoalActionScopeDepth = 0;
        _taiwuGroupVersion = 0;
        _crossAreaTravelVersion = 0;
        _adventureTaiwuVersion = 0;
    }

    /// <summary>替换原版 `CharacterMatcherHelper.Match` 的阶段缓存入口。</summary>
    public static bool Match(CharacterMatcherItem matcherItem, Character targetChar)
    {
        if (!_stageActive)
        {
            bool fallbackResult = CharacterMatcherHelper.Match(matcherItem, targetChar);
            CharacterActionPlanningDiagnostics.RecordTargetMatcherCacheFallback(
                CharacterTargetMatcherCacheRejectReason.StageInactive,
                0,
                fallbackResult);
            return fallbackResult;
        }

        if (_offlineCurrentGoalActionScopeDepth <= 0)
        {
            bool fallbackResult = CharacterMatcherHelper.Match(matcherItem, targetChar);
            CharacterActionPlanningDiagnostics.RecordTargetMatcherCacheFallback(
                CharacterTargetMatcherCacheRejectReason.OutsideOfflineCurrentGoalActions,
                0,
                fallbackResult);
            return fallbackResult;
        }

        if (!TryAnalyzeDependencies(
                matcherItem,
                out CharacterMatcherDependency dependencies,
                out CharacterTargetMatcherCacheRejectReason rejectReason,
                out int rejectDetail))
        {
            bool fallbackResult = CharacterMatcherHelper.Match(matcherItem, targetChar);
            CharacterActionPlanningDiagnostics.RecordTargetMatcherCacheFallback(
                rejectReason,
                rejectDetail,
                fallbackResult);
            return fallbackResult;
        }

        int targetCharId = targetChar.GetId();
        TargetVersionSnapshot targetVersion = GetVersionSnapshot(targetCharId, dependencies);
        var key = new TargetMatcherKey(matcherItem, targetCharId, dependencies, targetVersion);
        if (StageCache.TryGetValue(key, out bool cachedResult))
        {
            CharacterActionPlanningDiagnostics.RecordTargetMatcherCacheHit(cachedResult);
            return cachedResult;
        }

        bool result = CharacterMatcherHelper.Match(matcherItem, targetChar);
        StageCache.TryAdd(key, result);
        CharacterActionPlanningDiagnostics.RecordTargetMatcherCacheMiss(result);
        return result;
    }

    private static bool IsEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionTargetLookupCache;

    private static bool TryAnalyzeDependencies(
        CharacterMatcherItem matcherItem,
        out CharacterMatcherDependency dependencies,
        out CharacterTargetMatcherCacheRejectReason rejectReason,
        out int rejectDetail)
    {
        dependencies = CharacterMatcherDependency.None;
        rejectReason = CharacterTargetMatcherCacheRejectReason.None;
        rejectDetail = 0;

        if (matcherItem.AgeType != ECharacterMatcherAgeType.NotRestricted)
        {
            dependencies |= CharacterMatcherDependency.Age;
        }

        if (matcherItem.GenderType is
            ECharacterMatcherGenderType.DisplayFemale or
            ECharacterMatcherGenderType.DisplayMale)
        {
            rejectReason = CharacterTargetMatcherCacheRejectReason.UnsupportedDisplayGender;
            rejectDetail = (int)matcherItem.GenderType;
            return false;
        }

        if (matcherItem.IdentityType != ECharacterMatcherIdentityType.NotRestricted ||
            matcherItem.Organization >= 0)
        {
            dependencies |= CharacterMatcherDependency.Organization;
        }

        if (matcherItem.FavorRange is { Length: 2 })
        {
            dependencies |= CharacterMatcherDependency.Relation;
        }

        if (matcherItem.MerchantType >= 0)
        {
            rejectReason = CharacterTargetMatcherCacheRejectReason.UnsupportedMerchantType;
            rejectDetail = matcherItem.MerchantType;
            return false;
        }

        ECharacterMatcherSubCondition[] subConditions = matcherItem.SubConditions;
        if (subConditions == null || subConditions.Length == 0)
        {
            return true;
        }

        foreach (ECharacterMatcherSubCondition subCondition in subConditions)
        {
            switch (subCondition)
            {
                case ECharacterMatcherSubCondition.NotTaiwu:
                    break;
                case ECharacterMatcherSubCondition.NotInTaiwuGroup:
                    dependencies |= CharacterMatcherDependency.TaiwuGroup;
                    break;
                case ECharacterMatcherSubCondition.NotTaiwuFriendlyRelation:
                case ECharacterMatcherSubCondition.NotTaiwuFamiliyRelation:
                    dependencies |= CharacterMatcherDependency.Relation;
                    break;
                case ECharacterMatcherSubCondition.CanStroll:
                    dependencies |= CharacterMatcherDependency.Organization;
                    break;
                case ECharacterMatcherSubCondition.CanBeLocated:
                    dependencies |=
                        CharacterMatcherDependency.Location |
                        CharacterMatcherDependency.ExternalRelation |
                        CharacterMatcherDependency.Kidnapper |
                        CharacterMatcherDependency.Leader |
                        CharacterMatcherDependency.CrossAreaTravel |
                        CharacterMatcherDependency.AdventureTaiwu;
                    break;
                default:
                    rejectReason = CharacterTargetMatcherCacheRejectReason.UnsupportedSubCondition;
                    rejectDetail = (int)subCondition;
                    return false;
            }
        }

        return true;
    }

    private static TargetVersionState GetTargetVersionState(int targetCharId) =>
        TargetVersions.GetOrAdd(targetCharId, static _ => new TargetVersionState());

    private static void InvalidateTargetVersion(int targetCharId, Action<TargetVersionState> invalidate)
    {
        if (!_stageActive || targetCharId < 0)
        {
            return;
        }

        invalidate(GetTargetVersionState(targetCharId));
    }

    private static TargetVersionSnapshot GetVersionSnapshot(
        int targetCharId,
        CharacterMatcherDependency dependencies)
    {
        if (!TargetVersions.TryGetValue(targetCharId, out TargetVersionState? state))
        {
            return new TargetVersionSnapshot(
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                (dependencies & CharacterMatcherDependency.TaiwuGroup) != 0
                    ? Volatile.Read(ref _taiwuGroupVersion)
                    : 0,
                (dependencies & CharacterMatcherDependency.CrossAreaTravel) != 0
                    ? Volatile.Read(ref _crossAreaTravelVersion)
                    : 0,
                (dependencies & CharacterMatcherDependency.AdventureTaiwu) != 0
                    ? Volatile.Read(ref _adventureTaiwuVersion)
                    : 0);
        }

        return new TargetVersionSnapshot(
            (dependencies & CharacterMatcherDependency.Age) != 0 ? Volatile.Read(ref state.Age) : 0,
            (dependencies & CharacterMatcherDependency.Relation) != 0 ? Volatile.Read(ref state.Relation) : 0,
            (dependencies & CharacterMatcherDependency.Organization) != 0 ? Volatile.Read(ref state.Organization) : 0,
            (dependencies & CharacterMatcherDependency.Inventory) != 0 ? Volatile.Read(ref state.Inventory) : 0,
            (dependencies & CharacterMatcherDependency.Equipment) != 0 ? Volatile.Read(ref state.Equipment) : 0,
            (dependencies & CharacterMatcherDependency.Location) != 0 ? Volatile.Read(ref state.Location) : 0,
            (dependencies & CharacterMatcherDependency.ExternalRelation) != 0
                ? Volatile.Read(ref state.ExternalRelation)
                : 0,
            (dependencies & CharacterMatcherDependency.Kidnapper) != 0 ? Volatile.Read(ref state.Kidnapper) : 0,
            (dependencies & CharacterMatcherDependency.Leader) != 0 ? Volatile.Read(ref state.Leader) : 0,
            (dependencies & CharacterMatcherDependency.TaiwuGroup) != 0
                ? Volatile.Read(ref _taiwuGroupVersion)
                : 0,
            (dependencies & CharacterMatcherDependency.CrossAreaTravel) != 0
                ? Volatile.Read(ref _crossAreaTravelVersion)
                : 0,
            (dependencies & CharacterMatcherDependency.AdventureTaiwu) != 0
                ? Volatile.Read(ref _adventureTaiwuVersion)
                : 0);
    }

    private static void Bump(ref int version)
    {
        int value = Interlocked.Increment(ref version);
        if (value == int.MaxValue)
        {
            Interlocked.Exchange(ref version, 1);
        }
    }

    [Flags]
    private enum CharacterMatcherDependency
    {
        None = 0,
        Age = 1 << 0,
        Relation = 1 << 1,
        Organization = 1 << 2,
        Inventory = 1 << 3,
        Equipment = 1 << 4,
        Location = 1 << 5,
        TaiwuGroup = 1 << 6,
        ExternalRelation = 1 << 7,
        Kidnapper = 1 << 8,
        Leader = 1 << 9,
        CrossAreaTravel = 1 << 10,
        AdventureTaiwu = 1 << 11,
    }

    private sealed class TargetVersionState
    {
        public int Age;
        public int Relation;
        public int Organization;
        public int Inventory;
        public int Equipment;
        public int Location;
        public int ExternalRelation;
        public int Kidnapper;
        public int Leader;
    }

    private readonly struct TargetVersionSnapshot : IEquatable<TargetVersionSnapshot>
    {
        private readonly int _age;
        private readonly int _relation;
        private readonly int _organization;
        private readonly int _inventory;
        private readonly int _equipment;
        private readonly int _location;
        private readonly int _externalRelation;
        private readonly int _kidnapper;
        private readonly int _leader;
        private readonly int _taiwuGroup;
        private readonly int _crossAreaTravel;
        private readonly int _adventureTaiwu;

        public TargetVersionSnapshot(
            int age,
            int relation,
            int organization,
            int inventory,
            int equipment,
            int location,
            int externalRelation,
            int kidnapper,
            int leader,
            int taiwuGroup,
            int crossAreaTravel,
            int adventureTaiwu)
        {
            _age = age;
            _relation = relation;
            _organization = organization;
            _inventory = inventory;
            _equipment = equipment;
            _location = location;
            _externalRelation = externalRelation;
            _kidnapper = kidnapper;
            _leader = leader;
            _taiwuGroup = taiwuGroup;
            _crossAreaTravel = crossAreaTravel;
            _adventureTaiwu = adventureTaiwu;
        }

        public bool Equals(TargetVersionSnapshot other) =>
            _age == other._age &&
            _relation == other._relation &&
            _organization == other._organization &&
            _inventory == other._inventory &&
            _equipment == other._equipment &&
            _location == other._location &&
            _externalRelation == other._externalRelation &&
            _kidnapper == other._kidnapper &&
            _leader == other._leader &&
            _taiwuGroup == other._taiwuGroup &&
            _crossAreaTravel == other._crossAreaTravel &&
            _adventureTaiwu == other._adventureTaiwu;

        public override bool Equals(object? obj) =>
            obj is TargetVersionSnapshot other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hashCode = new();
            hashCode.Add(_age);
            hashCode.Add(_relation);
            hashCode.Add(_organization);
            hashCode.Add(_inventory);
            hashCode.Add(_equipment);
            hashCode.Add(_location);
            hashCode.Add(_externalRelation);
            hashCode.Add(_kidnapper);
            hashCode.Add(_leader);
            hashCode.Add(_taiwuGroup);
            hashCode.Add(_crossAreaTravel);
            hashCode.Add(_adventureTaiwu);
            return hashCode.ToHashCode();
        }
    }

    private readonly struct TargetMatcherKey : IEquatable<TargetMatcherKey>
    {
        private readonly CharacterMatcherItem _matcherItem;
        private readonly int _targetCharId;
        private readonly CharacterMatcherDependency _dependencies;
        private readonly TargetVersionSnapshot _targetVersion;

        public TargetMatcherKey(
            CharacterMatcherItem matcherItem,
            int targetCharId,
            CharacterMatcherDependency dependencies,
            TargetVersionSnapshot targetVersion)
        {
            _matcherItem = matcherItem;
            _targetCharId = targetCharId;
            _dependencies = dependencies;
            _targetVersion = targetVersion;
        }

        public bool Equals(TargetMatcherKey other) =>
            ReferenceEquals(_matcherItem, other._matcherItem) &&
            _targetCharId == other._targetCharId &&
            _dependencies == other._dependencies &&
            _targetVersion.Equals(other._targetVersion);

        public override bool Equals(object? obj) =>
            obj is TargetMatcherKey other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(
                RuntimeHelpers.GetHashCode(_matcherItem),
                _targetCharId,
                _dependencies,
                _targetVersion);
    }
}
