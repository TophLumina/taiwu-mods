using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.BlockPercentLess)]
public class AiConditionBlockPercentLess : AiConditionCheckCharExpressionBase
{
	public AiConditionBlockPercentLess(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar, int expressionResult)
	{
		return false;
	}
}
