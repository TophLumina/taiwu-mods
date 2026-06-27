using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Config;
using GameData.Domains.Character;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class CharacterActionTargetMatcherStageCache
{
    private static readonly ConcurrentDictionary<TargetMatcherKey, bool> StageCache = new();
    private static readonly ConcurrentDictionary<int, int> TargetVersions = new();

    private static volatile bool _stageActive;

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

    /// <summary>目标角色的 matcher 相关状态变化后，只推进该角色的缓存版本。</summary>
    public static void InvalidateTarget(int targetCharId)
    {
        if (!_stageActive || targetCharId < 0)
        {
            return;
        }

        TargetVersions.AddOrUpdate(
            targetCharId,
            static _ => 1,
            static (_, version) => version == int.MaxValue ? 1 : version + 1);
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

    /// <summary>批量关系重写等无法精确定位时，清空本阶段 matcher 缓存但保留优化入口。</summary>
    public static void InvalidateAll()
    {
        if (!_stageActive)
        {
            return;
        }

        StageCache.Clear();
        TargetVersions.Clear();
    }

    /// <summary>清理全部运行时状态，供退出世界、切档或插件卸载时调用。</summary>
    public static void Reset()
    {
        _stageActive = false;
        StageCache.Clear();
        TargetVersions.Clear();
        _offlineCurrentGoalActionScopeDepth = 0;
    }

    /// <summary>替换原版 `CharacterMatcherHelper.Match` 的阶段缓存入口。</summary>
    public static bool Match(CharacterMatcherItem matcherItem, Character targetChar)
    {
        if (!_stageActive || _offlineCurrentGoalActionScopeDepth <= 0)
        {
            bool fallbackResult = CharacterMatcherHelper.Match(matcherItem, targetChar);
            CharacterActionPlanningDiagnostics.RecordTargetMatcherCacheFallback(fallbackResult);
            return fallbackResult;
        }

        int targetCharId = targetChar.GetId();
        int targetVersion = TargetVersions.TryGetValue(targetCharId, out int version) ? version : 0;
        var key = new TargetMatcherKey(matcherItem, targetCharId, targetVersion);
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

    private readonly struct TargetMatcherKey : IEquatable<TargetMatcherKey>
    {
        private readonly CharacterMatcherItem _matcherItem;
        private readonly int _targetCharId;
        private readonly int _targetVersion;

        public TargetMatcherKey(CharacterMatcherItem matcherItem, int targetCharId, int targetVersion)
        {
            _matcherItem = matcherItem;
            _targetCharId = targetCharId;
            _targetVersion = targetVersion;
        }

        public bool Equals(TargetMatcherKey other) =>
            ReferenceEquals(_matcherItem, other._matcherItem) &&
            _targetCharId == other._targetCharId &&
            _targetVersion == other._targetVersion;

        public override bool Equals(object? obj) =>
            obj is TargetMatcherKey other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(RuntimeHelpers.GetHashCode(_matcherItem), _targetCharId, _targetVersion);
    }
}
