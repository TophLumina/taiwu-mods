using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Config;
using GameData.ActionPlanning;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;
using GameData.Common;
using HarmonyLib;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class CharacterActionPlannerGraphCache
{
    private static readonly object SyncRoot = new();

    private static readonly Type PlannerType =
        typeof(ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey>);

    private static readonly FieldInfo EffectToActionMapField =
        AccessTools.Field(PlannerType, "_effectToActionMap");

    private static readonly FieldInfo ConditionToNodeMapField =
        AccessTools.Field(PlannerType, "_conditionToNodeMap");

    private static volatile Snapshot? _snapshot;
    private static BuildStats _buildStats;

    /// <summary>清除静态规划图快照；配置重新加载或卸载时调用。</summary>
    public static void Reset()
    {
        lock (SyncRoot)
        {
            _snapshot = null;
            _buildStats = default;
        }
    }

    public static BuildStats GetBuildStats()
    {
        lock (SyncRoot)
        {
            return _buildStats;
        }
    }

    /// <summary>尝试读取 `StateCondition -> ActionNode[]` 邻接表；失败时回退原版路径。</summary>
    public static bool TryGetConditionConnectedActions(
        ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey> planner,
        StateCondition<StateKey> condition,
        out IEnumerable<INode<Character, StateKey>> actions)
    {
        actions = Array.Empty<INode<Character, StateKey>>();
        if (!TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization)
        {
            RecordConditionLookup(hit: false, miss: false, fallback: true, returnedNodeCount: 0);
            return false;
        }

        Snapshot? snapshot = EnsureSnapshot(planner);
        if (snapshot == null)
        {
            RecordConditionLookup(hit: false, miss: false, fallback: true, returnedNodeCount: 0);
            return false;
        }

        if (snapshot.ConditionConnectedActions.TryGetValue(condition, out INode<Character, StateKey>[]? cached))
        {
            actions = cached;
            RecordConditionLookup(hit: true, miss: false, fallback: false, returnedNodeCount: cached.Length);
            return true;
        }

        RecordConditionLookup(hit: false, miss: true, fallback: true, returnedNodeCount: 0);
        return false;
    }

    /// <summary>尝试读取 `StateEffect -> Node[]` 邻接表；当前主要用于保持原版公开接口一致。</summary>
    public static bool TryGetEffectConnectedActions(
        ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey> planner,
        StateEffect<StateKey> effect,
        out IEnumerable<INode<Character, StateKey>> nodes)
    {
        nodes = Array.Empty<INode<Character, StateKey>>();
        if (!TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization)
        {
            RecordEffectLookup(hit: false, miss: false, fallback: true, returnedNodeCount: 0);
            return false;
        }

        Snapshot? snapshot = EnsureSnapshot(planner);
        if (snapshot == null)
        {
            RecordEffectLookup(hit: false, miss: false, fallback: true, returnedNodeCount: 0);
            return false;
        }

        if (snapshot.EffectConnectedNodes.TryGetValue(effect, out INode<Character, StateKey>[]? cached))
        {
            nodes = cached;
            RecordEffectLookup(hit: true, miss: false, fallback: false, returnedNodeCount: cached.Length);
            return true;
        }

        RecordEffectLookup(hit: false, miss: true, fallback: true, returnedNodeCount: 0);
        return false;
    }

    /// <summary>在主线程初始化后预热快照，避免第一个 worker 在热路径中构建。</summary>
    public static void WarmUp(CharacterActionPlanner planner)
    {
        if (TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization)
        {
            _ = EnsureSnapshot(planner);
        }
    }

    private static Snapshot? EnsureSnapshot(ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey> planner)
    {
        Snapshot? snapshot = _snapshot;
        if (snapshot != null)
        {
            return snapshot;
        }

        lock (SyncRoot)
        {
            snapshot = _snapshot;
            if (snapshot != null)
            {
                return snapshot;
            }

            snapshot = BuildSnapshot(planner);
            _snapshot = snapshot;
            return snapshot;
        }
    }

    private static Snapshot? BuildSnapshot(ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey> planner)
    {
        long startTicks = Stopwatch.GetTimestamp();
        bool success = false;
        int conditionCount = 0;
        int effectCount = 0;
        long conditionEdgeCount = 0;
        long effectEdgeCount = 0;

        try
        {
            if (EffectToActionMapField.GetValue(planner) is not Dictionary<StateEffect<StateKey>, List<IAction<Character, StateKey>>> effectToActionMap ||
                ConditionToNodeMapField.GetValue(planner) is not Dictionary<StateCondition<StateKey>, List<INode<Character, StateKey>>> conditionToNodeMap)
            {
                return null;
            }

            conditionCount = conditionToNodeMap.Count;
            effectCount = effectToActionMap.Count;

            Dictionary<StateCondition<StateKey>, INode<Character, StateKey>[]> conditionConnectedActions =
                new(conditionToNodeMap.Count);
            foreach (StateCondition<StateKey> condition in conditionToNodeMap.Keys)
            {
                List<INode<Character, StateKey>> connected = new();
                foreach (KeyValuePair<StateEffect<StateKey>, List<IAction<Character, StateKey>>> pair in effectToActionMap)
                {
                    if (!pair.Key.CanSatisfy(condition))
                    {
                        continue;
                    }

                    List<IAction<Character, StateKey>> actions = pair.Value;
                    for (int i = 0; i < actions.Count; i++)
                    {
                        connected.Add(actions[i]);
                    }
                }

                conditionEdgeCount += connected.Count;
                conditionConnectedActions[condition] = connected.Count == 0
                    ? Array.Empty<INode<Character, StateKey>>()
                    : connected.ToArray();
            }

            Dictionary<StateEffect<StateKey>, INode<Character, StateKey>[]> effectConnectedNodes =
                new(effectToActionMap.Count);
            foreach (StateEffect<StateKey> effect in effectToActionMap.Keys)
            {
                List<INode<Character, StateKey>> connected = new();
                foreach (KeyValuePair<StateCondition<StateKey>, List<INode<Character, StateKey>>> pair in conditionToNodeMap)
                {
                    if (!effect.CanSatisfy(pair.Key))
                    {
                        continue;
                    }

                    List<INode<Character, StateKey>> nodes = pair.Value;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        connected.Add(nodes[i]);
                    }
                }

                effectEdgeCount += connected.Count;
                effectConnectedNodes[effect] = connected.Count == 0
                    ? Array.Empty<INode<Character, StateKey>>()
                    : connected.ToArray();
            }

            success = true;
            return new Snapshot(conditionConnectedActions, effectConnectedNodes);
        }
        finally
        {
            RecordBuild(
                Stopwatch.GetTimestamp() - startTicks,
                success,
                conditionCount,
                effectCount,
                conditionEdgeCount,
                effectEdgeCount);
        }
    }

    private static void RecordConditionLookup(bool hit, bool miss, bool fallback, int returnedNodeCount)
    {
        CharacterActionPlanningDiagnostics.RecordGraphCacheLookup(
            CharacterActionPlannerGraphCacheLookupKind.Condition,
            hit,
            miss,
            fallback,
            returnedNodeCount);
    }

    private static void RecordEffectLookup(bool hit, bool miss, bool fallback, int returnedNodeCount)
    {
        CharacterActionPlanningDiagnostics.RecordGraphCacheLookup(
            CharacterActionPlannerGraphCacheLookupKind.Effect,
            hit,
            miss,
            fallback,
            returnedNodeCount);
    }

    private static void RecordBuild(
        long elapsedTicks,
        bool success,
        int conditionCount,
        int effectCount,
        long conditionEdgeCount,
        long effectEdgeCount)
    {
        _buildStats = new BuildStats(
            _buildStats.ElapsedTicks + elapsedTicks,
            _buildStats.BuildCalls + 1,
            _buildStats.Successes + (success ? 1 : 0),
            _buildStats.Failures + (success ? 0 : 1),
            conditionCount,
            effectCount,
            conditionEdgeCount,
            effectEdgeCount);
    }

    private sealed class Snapshot
    {
        public readonly Dictionary<StateCondition<StateKey>, INode<Character, StateKey>[]> ConditionConnectedActions;
        public readonly Dictionary<StateEffect<StateKey>, INode<Character, StateKey>[]> EffectConnectedNodes;

        public Snapshot(
            Dictionary<StateCondition<StateKey>, INode<Character, StateKey>[]> conditionConnectedActions,
            Dictionary<StateEffect<StateKey>, INode<Character, StateKey>[]> effectConnectedNodes)
        {
            ConditionConnectedActions = conditionConnectedActions;
            EffectConnectedNodes = effectConnectedNodes;
        }
    }

    public readonly struct BuildStats
    {
        public readonly long ElapsedTicks;
        public readonly int BuildCalls;
        public readonly int Successes;
        public readonly int Failures;
        public readonly int ConditionCount;
        public readonly int EffectCount;
        public readonly long ConditionEdgeCount;
        public readonly long EffectEdgeCount;

        public BuildStats(
            long elapsedTicks,
            int buildCalls,
            int successes,
            int failures,
            int conditionCount,
            int effectCount,
            long conditionEdgeCount,
            long effectEdgeCount)
        {
            ElapsedTicks = elapsedTicks;
            BuildCalls = buildCalls;
            Successes = successes;
            Failures = failures;
            ConditionCount = conditionCount;
            EffectCount = effectCount;
            ConditionEdgeCount = conditionEdgeCount;
            EffectEdgeCount = effectEdgeCount;
        }
    }
}
