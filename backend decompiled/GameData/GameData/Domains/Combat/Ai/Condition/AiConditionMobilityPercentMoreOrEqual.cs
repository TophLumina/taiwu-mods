using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MobilityPercentMoreOrEqual)]
public class AiConditionMobilityPercentMoreOrEqual : AiConditionCheckCharExpressionBase
{
	public AiConditionMobilityPercentMoreOrEqual(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar, int expressionResult)
	{
		int percent = CValuePercent.ParseInt(checkChar.GetMobilityValue(), MoveSpecialConstants.MaxMobility);
		return percent >= expressionResult;
	}
}
