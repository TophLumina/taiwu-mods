using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.State;
using GameData.Utilities;
using Character = GameData.Domains.Character.Character;

namespace TaiwuRemoveAILimitation.Runtime;

internal static class NpcActionReachabilityDiagnostics
{
    private const string LogTag = "TaiwuRemoveAILimitation";
    private const int MaxDetailLines = 160;
    private static int _logged;

    public static bool Enabled => TaiwuRemoveAILimitationSettings.EnableNpcActionReachabilityDiagnostics;

    public static void LogPlannerOnce(CharacterActionPlanner planner)
    {
        if (!Enabled)
        {
            return;
        }

        if (Interlocked.CompareExchange(ref _logged, 1, 0) != 0)
        {
            return;
        }

        try
        {
            LogPlanner(planner);
        }
        catch
        {
            _logged = 0;
        }
    }

    public static void LogPlanner(CharacterActionPlanner planner)
    {
        if (!Enabled)
        {
            return;
        }

        ReachabilityStats stats = new ReachabilityStats();
        StringBuilder details = new StringBuilder(8192);
        int detailCount = 0;

        foreach (PlanningGoalItem goal in PlanningGoal.Instance)
        {
            PlanningGoalNode node = planner.GetGoalNode(goal.TemplateId);
            NodeReachabilityAnalysis analysis = AnalyzeNode(planner, node, isGoalNode: true, actionTemplateId: -1);
            stats.AddGoal(node, analysis);
            AppendDetail(details, ref detailCount, FormatGoalDetail(node, analysis));
        }

        foreach (PlanningActionItem action in PlanningAction.Instance)
        {
            PlanningActionNode node = planner.GetActionNode(action.TemplateId);
            NodeReachabilityAnalysis analysis = AnalyzeNode(planner, node, isGoalNode: false, action.TemplateId);
            stats.AddAction(node, analysis);
            if (ShouldLogActionDetail(node, analysis))
            {
                AppendDetail(details, ref detailCount, FormatActionDetail(node, analysis));
            }
        }

        AdaptableLog.TagInfo(LogTag, stats.ToLogString());

        if (details.Length > 0)
        {
            if (detailCount > MaxDetailLines)
            {
                details.AppendLine($"... truncated detail lines: {detailCount - MaxDetailLines}");
            }

            AdaptableLog.TagInfo(LogTag, "NPC action reachability diagnostics details\n" + details);
        }
    }

    private static NodeReachabilityAnalysis AnalyzeNode(
        CharacterActionPlanner planner,
        INode<Character, StateKey> node,
        bool isGoalNode,
        int actionTemplateId)
    {
        NodeReachabilityAnalysis analysis = new NodeReachabilityAnalysis();
        AddMissingProducers(planner, node.GetPreconditions(), analysis.MissingProducerStates);
        AddNoneSensors(node.GetPreconditions(), analysis.NoneSensorStates);

        if (node is PlanningGoalNode goalNode)
        {
            AddNoneSensors(goalNode.Template.TargetCharacterConditionsA, analysis.NoneSensorStates);
            AddNoneSensors(goalNode.Template.TargetCharacterConditionsB, analysis.NoneSensorStates);
            AddNoneSensors(goalNode.Template.TargetCharacterConditionsC, analysis.NoneSensorStates);
            analysis.CurrentReachable = goalNode.Reachable;
        }
        else if (node is PlanningActionNode actionNode)
        {
            AddNoneSensors(actionNode.Template.SelfRestrictions, analysis.NoneSensorStates);
            AddNoneSensors(actionNode.Template.TargetCharacterConditions, analysis.NoneSensorStates);
            analysis.CurrentReachable = actionNode.Reachable;
        }

        foreach (int stateTemplateId in analysis.NoneSensorStates)
        {
            analysis.OriginalBlockedNoneSensorStates.Add(stateTemplateId);
            if (!NpcActionLimitationRemoval.CanBypassNoneSensorForNode(
                    isGoalNode,
                    actionTemplateId,
                    stateTemplateId))
            {
                analysis.BlockedNoneSensorStates.Add(stateTemplateId);
            }
        }

        foreach (int stateTemplateId in analysis.MissingProducerStates)
        {
            analysis.OriginalBlockedMissingProducerStates.Add(stateTemplateId);
            if (!NpcActionLimitationRemoval.CanTreatAsCurrentAvailabilityState(stateTemplateId))
            {
                analysis.BlockedMissingProducerStates.Add(stateTemplateId);
            }
        }

        analysis.NoImplementedDirectConnection = HasNoImplementedDirectConnection(node);
        analysis.OriginalReachable = analysis.OriginalBlockedMissingProducerStates.Count == 0 &&
                                     analysis.OriginalBlockedNoneSensorStates.Count == 0 &&
                                     !analysis.NoImplementedDirectConnection;
        analysis.BypassReachable = analysis.BlockedMissingProducerStates.Count == 0 &&
                                   analysis.BlockedNoneSensorStates.Count == 0 &&
                                   !analysis.NoImplementedDirectConnection;
        return analysis;
    }

    private static void AddMissingProducers(
        CharacterActionPlanner planner,
        IEnumerable<StateConditionAndValue<StateKey>>? conditions,
        HashSet<int> states)
    {
        if (conditions == null)
        {
            return;
        }

        foreach (StateConditionAndValue<StateKey> condition in conditions)
        {
            if (!planner.GetConditionConnectedActions(condition.Condition).Any())
            {
                states.Add(condition.Key.StateTemplateId);
            }
        }
    }

    private static void AddNoneSensors(
        IEnumerable<StateConditionAndValue<StateKey>>? conditions,
        HashSet<int> states)
    {
        if (conditions == null)
        {
            return;
        }

        foreach (StateConditionAndValue<StateKey> condition in conditions)
        {
            if (condition.Key.Template.SensorType == EPlanningStateSensorType.None)
            {
                states.Add(condition.Key.StateTemplateId);
            }
        }
    }

    private static bool HasNoImplementedDirectConnection(INode<Character, StateKey> node)
    {
        return node.HasDirectConnections() &&
               !node.GetDirectConnections().Any(static connection =>
                   connection is PlanningActionNode planningActionNode && planningActionNode.IsImplemented);
    }

    private static bool ShouldLogActionDetail(PlanningActionNode node, NodeReachabilityAnalysis analysis)
    {
        PlanningActionItem template = node.Template;
        return IsWatchedAction(template.TemplateId) ||
               NpcActionLimitationRemoval.IsBypassedAction(template.TemplateId) ||
               analysis.IsOriginalBlocked ||
               !string.IsNullOrEmpty(template.ImplementationPath) && !node.IsImplemented;
    }

    private static bool IsWatchedAction(int actionTemplateId)
    {
        return actionTemplateId is 382 or 383;
    }

    private static void AppendDetail(StringBuilder builder, ref int detailCount, string line)
    {
        detailCount++;
        if (detailCount <= MaxDetailLines)
        {
            builder.AppendLine(line);
        }
    }

    private static string FormatGoalDetail(PlanningGoalNode node, NodeReachabilityAnalysis analysis)
    {
        PlanningGoalItem template = node.Template;
        return $"goal G{template.TemplateId}: currentReachable={analysis.CurrentReachable}, " +
               $"originalReachable={analysis.OriginalReachable}, " +
               $"bypassReachable={analysis.BypassReachable}, " +
               $"noneSensors={FormatStates(analysis.NoneSensorStates)}, " +
               $"missingProducer={FormatStates(analysis.MissingProducerStates)}, " +
               $"blockedNoneSensors={FormatStates(analysis.BlockedNoneSensorStates)}, " +
               $"blockedMissingProducer={FormatStates(analysis.BlockedMissingProducerStates)}";
    }

    private static string FormatActionDetail(PlanningActionNode node, NodeReachabilityAnalysis analysis)
    {
        PlanningActionItem template = node.Template;
        return $"action A{template.TemplateId}: impl={FormatImpl(template)}, implemented={node.IsImplemented}, " +
               $"currentReachable={analysis.CurrentReachable}, originalReachable={analysis.OriginalReachable}, " +
               $"bypassReachable={analysis.BypassReachable}, " +
               $"noneSensors={FormatStates(analysis.NoneSensorStates)}, " +
               $"missingProducer={FormatStates(analysis.MissingProducerStates)}, " +
               $"blockedNoneSensors={FormatStates(analysis.BlockedNoneSensorStates)}, " +
               $"blockedMissingProducer={FormatStates(analysis.BlockedMissingProducerStates)}, " +
               $"behaviorWeights={FormatArray(template.BehaviorTypeWeights)}, personalityType={template.PersonalityType}, " +
               $"actionPointCost={template.ActionPointCost}, selfMatcher={template.SelfMatcher}, targetMatcher={template.TargetMatcher}";
    }

    private static string FormatImpl(PlanningActionItem template)
    {
        return string.IsNullOrEmpty(template.ImplementationPath) ? "<none>" : template.ImplementationPath;
    }

    private static string FormatStates(HashSet<int> states)
    {
        if (states.Count == 0)
        {
            return "-";
        }

        return string.Join(",", states.OrderBy(static value => value));
    }

    private static string FormatArray(int[]? values)
    {
        return values == null || values.Length == 0 ? "-" : string.Join("/", values);
    }

    private sealed class NodeReachabilityAnalysis
    {
        public readonly HashSet<int> NoneSensorStates = new HashSet<int>();
        public readonly HashSet<int> MissingProducerStates = new HashSet<int>();
        public readonly HashSet<int> OriginalBlockedNoneSensorStates = new HashSet<int>();
        public readonly HashSet<int> OriginalBlockedMissingProducerStates = new HashSet<int>();
        public readonly HashSet<int> BlockedNoneSensorStates = new HashSet<int>();
        public readonly HashSet<int> BlockedMissingProducerStates = new HashSet<int>();
        public bool NoImplementedDirectConnection;
        public bool CurrentReachable;
        public bool OriginalReachable;
        public bool BypassReachable;

        public bool IsOriginalBlocked => !OriginalReachable;
    }

    private sealed class ReachabilityStats
    {
        private int _goalTotal;
        private int _goalCurrentReachable;
        private int _goalOriginalReachable;
        private int _goalBypassReachable;
        private int _goalOriginalBlockedByNoneSensor;
        private int _goalOriginalBlockedByMissingProducer;
        private int _goalReachableByBypass;

        private int _actionTotal;
        private int _actionImplemented;
        private int _actionImplementationPathMissing;
        private int _actionImplementationNotLoaded;
        private int _actionCurrentReachable;
        private int _actionOriginalReachable;
        private int _actionBypassReachable;
        private int _actionOriginalBlockedByNoneSensor;
        private int _actionOriginalBlockedByMissingProducer;
        private int _actionReachableByBypass;

        public void AddGoal(PlanningGoalNode node, NodeReachabilityAnalysis analysis)
        {
            _goalTotal++;
            if (analysis.CurrentReachable)
            {
                _goalCurrentReachable++;
            }

            if (analysis.OriginalReachable)
            {
                _goalOriginalReachable++;
            }

            if (analysis.BypassReachable)
            {
                _goalBypassReachable++;
            }

            if (analysis.OriginalBlockedNoneSensorStates.Count > 0)
            {
                _goalOriginalBlockedByNoneSensor++;
            }

            if (analysis.OriginalBlockedMissingProducerStates.Count > 0)
            {
                _goalOriginalBlockedByMissingProducer++;
            }

            if (!analysis.OriginalReachable && analysis.BypassReachable)
            {
                _goalReachableByBypass++;
            }
        }

        public void AddAction(PlanningActionNode node, NodeReachabilityAnalysis analysis)
        {
            _actionTotal++;
            if (node.IsImplemented)
            {
                _actionImplemented++;
            }
            else if (string.IsNullOrEmpty(node.Template.ImplementationPath))
            {
                _actionImplementationPathMissing++;
            }
            else
            {
                _actionImplementationNotLoaded++;
            }

            if (analysis.CurrentReachable)
            {
                _actionCurrentReachable++;
            }

            if (analysis.OriginalReachable)
            {
                _actionOriginalReachable++;
            }

            if (analysis.BypassReachable)
            {
                _actionBypassReachable++;
            }

            if (analysis.OriginalBlockedNoneSensorStates.Count > 0)
            {
                _actionOriginalBlockedByNoneSensor++;
            }

            if (analysis.OriginalBlockedMissingProducerStates.Count > 0)
            {
                _actionOriginalBlockedByMissingProducer++;
            }

            if (!analysis.OriginalReachable && analysis.BypassReachable)
            {
                _actionReachableByBypass++;
            }
        }

        public string ToLogString()
        {
            return "NPC action reachability diagnostics summary\n" +
                   $"goals: total={_goalTotal}, currentReachable={_goalCurrentReachable}, " +
                   $"originalReachable={_goalOriginalReachable}, bypassReachable={_goalBypassReachable}, " +
                   $"reachableByBypass={_goalReachableByBypass}, " +
                   $"blockedByNoneSensor={_goalOriginalBlockedByNoneSensor}, " +
                   $"blockedByMissingProducer={_goalOriginalBlockedByMissingProducer}\n" +
                   $"actions: total={_actionTotal}, implemented={_actionImplemented}, " +
                   $"implementationPathMissing={_actionImplementationPathMissing}, " +
                   $"implementationNotLoaded={_actionImplementationNotLoaded}, " +
                   $"currentReachable={_actionCurrentReachable}, originalReachable={_actionOriginalReachable}, " +
                   $"bypassReachable={_actionBypassReachable}, reachableByBypass={_actionReachableByBypass}, " +
                   $"blockedByNoneSensor={_actionOriginalBlockedByNoneSensor}, " +
                   $"blockedByMissingProducer={_actionOriginalBlockedByMissingProducer}";
        }
    }
}
