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

    private static volatile bool _stageActive;

    [ThreadStatic]
    private static int _offlineCurrentGoalActionScopeDepth;

    /// <summary>进入主/副目标行动规划阶段，清空上一阶段缓存并冻结本阶段读取语义。</summary>
    public static void BeginUpdateCurrentGoalActionsStage()
    {
        StageCache.Clear();
        _stageActive = IsEnabled();
    }

    /// <summary>离开主/副目标行动规划阶段，释放阶段缓存。</summary>
    public static void EndUpdateCurrentGoalActionsStage()
    {
        _stageActive = false;
        StageCache.Clear();
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

    /// <summary>关系删除或类型变化后关闭本阶段缓存；新增关系按冻结语义留到下月生效。</summary>
    public static void InvalidateForRelationMutation()
    {
        if (!_stageActive)
        {
            return;
        }

        _stageActive = false;
        StageCache.Clear();
    }

    /// <summary>清理全部运行时状态，供退出世界、切档或插件卸载时调用。</summary>
    public static void Reset()
    {
        _stageActive = false;
        StageCache.Clear();
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

        var key = new TargetMatcherKey(matcherItem, targetChar.GetId());
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

        public TargetMatcherKey(CharacterMatcherItem matcherItem, int targetCharId)
        {
            _matcherItem = matcherItem;
            _targetCharId = targetCharId;
        }

        public bool Equals(TargetMatcherKey other) =>
            ReferenceEquals(_matcherItem, other._matcherItem) && _targetCharId == other._targetCharId;

        public override bool Equals(object? obj) =>
            obj is TargetMatcherKey other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(RuntimeHelpers.GetHashCode(_matcherItem), _targetCharId);
    }
}
