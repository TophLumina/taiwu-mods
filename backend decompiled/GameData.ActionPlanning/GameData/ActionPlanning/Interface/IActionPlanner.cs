using System.Collections.Generic;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface IActionPlanner<in TContext, TObject, TStateKey> where TStateKey : IStateKey<TStateKey>
{
	void Build(IEnumerable<IGoal<TObject, TStateKey>> goals, IEnumerable<IAction<TObject, TStateKey>> actions);

	void Plan(TContext context, IAgent<TObject, TStateKey> agent, int maxDepth = -1);

	bool ReassessPlan(TContext context, IAgent<TObject, TStateKey> agent, out bool modified);
}
