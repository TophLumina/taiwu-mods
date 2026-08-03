using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.EquipCombatSkill)]
public class AiConditionEquipCombatSkill : AiConditionCheckCharBase
{
	private readonly short _skillId;

	public AiConditionEquipCombatSkill(IReadOnlyList<int> ints)
		: base(ints)
	{
		_skillId = (short)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return checkChar.GetCharacter().IsCombatSkillEquipped(_skillId);
	}
}
