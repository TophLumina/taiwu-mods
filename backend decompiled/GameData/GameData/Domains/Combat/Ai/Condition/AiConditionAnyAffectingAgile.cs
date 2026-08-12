using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AnyAffectingAgile)]
public class AiConditionAnyAffectingAgile : AiConditionAnyAffecting
{
	public AiConditionAnyAffectingAgile(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override short GetAffectingSkillId(CombatCharacter combatChar)
	{
		return combatChar.GetAffectingMoveSkillId();
	}
}
