using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AnyAffectingDefense)]
public class AiConditionAnyAffectingDefense : AiConditionAnyAffecting
{
	public AiConditionAnyAffectingDefense(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override short GetAffectingSkillId(CombatCharacter combatChar)
	{
		return combatChar.GetAffectingDefendSkillId();
	}
}
