using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.StancePercentMoreOrEqual)]
public class AiConditionStancePercentMoreOrEqual : AiConditionCheckCharExpressionBase
{
	public AiConditionStancePercentMoreOrEqual(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar, int expressionResult)
	{
		int percent = CValuePercent.ParseInt(checkChar.GetStanceValue(), 4000);
		return percent >= expressionResult;
	}
}
