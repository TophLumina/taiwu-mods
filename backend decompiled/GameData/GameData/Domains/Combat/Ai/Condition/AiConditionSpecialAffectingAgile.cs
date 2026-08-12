using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.SpecialAffectingAgile)]
public class AiConditionSpecialAffectingAgile : AiConditionSpecialAffecting
{
	public AiConditionSpecialAffectingAgile(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override short GetAffectingSkillId(CombatCharacter combatChar)
	{
		return combatChar.GetAffectingMoveSkillId();
	}
}
