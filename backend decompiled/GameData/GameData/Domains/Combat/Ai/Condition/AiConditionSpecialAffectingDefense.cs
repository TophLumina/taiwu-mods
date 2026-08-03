using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.SpecialAffectingDefense)]
public class AiConditionSpecialAffectingDefense : AiConditionSpecialAffecting
{
	public AiConditionSpecialAffectingDefense(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override short GetAffectingSkillId(CombatCharacter combatChar)
	{
		return combatChar.GetAffectingDefendSkillId();
	}
}
