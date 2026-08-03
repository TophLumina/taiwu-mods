using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CastingProgressLess)]
public class AiConditionCastingProgressLess : AiConditionCheckCharExpressionBase
{
	public AiConditionCastingProgressLess(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar, int expressionResult)
	{
		if (checkChar.GetPreparingSkillId() < 0)
		{
			return false;
		}
		return checkChar.GetSkillPreparePercent() < expressionResult;
	}
}
