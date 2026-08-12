using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning;

public class ActionPlanner<TContext, TMemory, TObject, TStateKey> : IActionPlanner<TContext, TObject, TStateKey>, IGraph<IAgent<TObject, TStateKey>, INode<TObject, TStateKey>> where TMemory : StateMemory<TObject, TStateKey>, new() where TStateKey : IStateKey<TStateKey>
{
	private Dictionary<StateEffect<TStateKey>, List<IAction<TObject, TStateKey>>> _effectToActionMap;

	private Dictionary<StateCondition<TStateKey>, List<INode<TObject, TStateKey>>> _conditionToNodeMap;

	public void Build(IEnumerable<IGoal<TObject, TStateKey>> goals, IEnumerable<IAction<TObject, TStateKey>> actions)
	{
		_effectToActionMap = new Dictionary<StateEffect<TStateKey>, List<IAction<TObject, TStateKey>>>();
		_conditionToNodeMap = new Dictionary<StateCondition<TStateKey>, List<INode<TObject, TStateKey>>>();
		foreach (IGoal<TObject, TStateKey> goal in goals)
		{
			IEnumerable<StateConditionAndValue<TStateKey>> conditions = goal.GetPreconditions();
			if (conditions == null)
			{
				continue;
			}
			foreach (StateConditionAndValue<TStateKey> condition in conditions)
			{
				RegisterNodeCondition(condition.Condition, goal);
			}
		}
		foreach (IAction<TObject, TStateKey> action in actions)
		{
			IEnumerable<StateConditionAndValue<TStateKey>> conditions2 = action.GetPreconditions();
			if (conditions2 != null)
			{
				foreach (StateConditionAndValue<TStateKey> condition2 in conditions2)
				{
					RegisterNodeCondition(condition2.Condition, action);
				}
			}
			IEnumerable<StateEffect<TStateKey>> effects = action.GetEffects();
			if (effects == null)
			{
				continue;
			}
			foreach (StateEffect<TStateKey> effect in effects)
			{
				RegisterActionEffect(effect, action);
			}
		}
	}

	public virtual void Plan(TContext context, IAgent<TObject, TStateKey> agent, int maxDepth = -1)
	{
		IGoal<TObject, TStateKey> goal = agent.Goal;
		IList<INode<TObject, TStateKey>> plan = agent.Plan;
		agent.Pathfinder.FindPath(agent, goal, plan, (maxDepth < 0) ? goal.GetMaxDepth() : maxDepth);
	}

	public virtual bool ReassessPlan(TContext context, IAgent<TObject, TStateKey> agent, out bool modified)
	{
		IGoal<TObject, TStateKey> goal = agent.Goal;
		IList<INode<TObject, TStateKey>> plan = agent.Plan;
		modified = agent.Pathfinder.ReassessPath(agent, goal, plan);
		return plan.Count > 0;
	}

	private void RegisterActionEffect(StateEffect<TStateKey> effect, IAction<TObject, TStateKey> action)
	{
		if (!_effectToActionMap.TryGetValue(effect, out var list))
		{
			list = new List<IAction<TObject, TStateKey>>();
			_effectToActionMap.Add(effect, list);
		}
		list.Add(action);
	}

	private void RegisterNodeCondition(StateCondition<TStateKey> condition, INode<TObject, TStateKey> action)
	{
		if (!_conditionToNodeMap.TryGetValue(condition, out var list))
		{
			list = new List<INode<TObject, TStateKey>>();
			_conditionToNodeMap.Add(condition, list);
		}
		list.Add(action);
	}

	public IEnumerable<INode<TObject, TStateKey>> GetNeighborNodes(INode<TObject, TStateKey> from)
	{
		IEnumerable<StateConditionAndValue<TStateKey>> conditions = from.GetPreconditions();
		foreach (StateConditionAndValue<TStateKey> condition in conditions)
		{
			foreach (INode<TObject, TStateKey> conditionConnectedAction in GetConditionConnectedActions(condition.Condition))
			{
				yield return conditionConnectedAction;
			}
		}
	}

	public int GetWeight(IAgent<TObject, TStateKey> agent, INode<TObject, TStateKey> from, INode<TObject, TStateKey> to)
	{
		return to.GetWeight(agent);
	}

	public bool HasPath(INode<TObject, TStateKey> src, INode<TObject, TStateKey> dst)
	{
		if (src == dst)
		{
			return true;
		}
		foreach (INode<TObject, TStateKey> neighborNode in GetNeighborNodes(src))
		{
			if (HasPath(neighborNode, dst))
			{
				return true;
			}
		}
		return false;
	}

	public void ToDotFileString(StringBuilder stringBuilder)
	{
		stringBuilder.AppendLine("digraph {");
		foreach (var (condition, nodesWithCondition) in _conditionToNodeMap)
		{
			foreach (INode<TObject, TStateKey> node in nodesWithCondition)
			{
				if (node is IGoal<TObject, TStateKey>)
				{
					stringBuilder.AppendFormat("\t{0} {1}\n", node, "[shape=box, style=\"rounded,filled\", fillcolor=yellow]");
				}
			}
			foreach (var (effect, actionsWithEffect) in _effectToActionMap)
			{
				if (!effect.CanSatisfy(condition))
				{
					continue;
				}
				foreach (INode<TObject, TStateKey> nodeWithCondition in nodesWithCondition)
				{
					foreach (IAction<TObject, TStateKey> actionWithEffect in actionsWithEffect)
					{
						stringBuilder.AppendFormat("\t{0} -> {1}\n", actionWithEffect, nodeWithCondition);
					}
				}
			}
		}
		stringBuilder.AppendLine("}");
	}

	public IEnumerable<INode<TObject, TStateKey>> GetConditionConnectedActions(StateCondition<TStateKey> condition)
	{
		foreach (var (effect, actions) in _effectToActionMap)
		{
			if (!effect.CanSatisfy(condition))
			{
				continue;
			}
			foreach (IAction<TObject, TStateKey> item in actions)
			{
				yield return item;
			}
		}
	}

	public IEnumerable<INode<TObject, TStateKey>> GetEffectConnectedActions(StateEffect<TStateKey> effect)
	{
		foreach (var (condition, actions) in _conditionToNodeMap)
		{
			if (!effect.CanSatisfy(condition))
			{
				continue;
			}
			foreach (INode<TObject, TStateKey> item in actions)
			{
				yield return item;
			}
		}
	}

	public virtual bool CheckNodeReachable(INode<TObject, TStateKey> node)
	{
		foreach (StateConditionAndValue<TStateKey> condition in node.GetPreconditions())
		{
			if (!GetConditionConnectedActions(condition.Condition).Any())
			{
				return false;
			}
		}
		return true;
	}
}
