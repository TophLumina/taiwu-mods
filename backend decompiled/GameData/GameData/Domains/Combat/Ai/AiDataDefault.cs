using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai;

public class AiDataDefault : AiData
{
	protected override IReadOnlyList<IAiNode> Nodes { get; }

	protected override IReadOnlyList<IAiCondition> Conditions { get; }

	protected override IReadOnlyList<IAiAction> Actions { get; }

	private static IEnumerable<IAiNode> NewNodes()
	{
		yield return AiNodeFactory.Create(EAiNodeType.Branch, 0, new List<int> { 0, 1, -1 });
		yield return AiNodeFactory.Create(EAiNodeType.Action, 1, new List<int> { 0 });
	}

	private static IEnumerable<IAiCondition> NewConditions()
	{
		yield return AiConditionFactory.Create(EAiConditionType.Delay, 0, null, new List<int> { 300 });
	}

	private static IEnumerable<IAiAction> NewActions()
	{
		yield return AiActionFactory.Create(EAiActionType.NormalAttack, 0, null, null);
	}

	public AiDataDefault()
	{
		Nodes = new List<IAiNode>(NewNodes());
		Conditions = new List<IAiCondition>(NewConditions());
		Actions = new List<IAiAction>(NewActions());
	}
}
