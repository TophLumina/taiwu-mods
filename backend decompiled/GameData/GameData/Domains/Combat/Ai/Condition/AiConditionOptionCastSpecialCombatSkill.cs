using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionCastSpecialCombatSkill)]
public class AiConditionOptionCastSpecialCombatSkill : AiConditionOptionCastCombatSkillBase
{
	protected override short SkillId { get; }

	public AiConditionOptionCastSpecialCombatSkill(IReadOnlyList<int> ints)
	{
		SkillId = (short)ints[0];
	}
}
