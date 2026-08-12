using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.LearnCombatSkill)]
public class AiConditionLearnCombatSkill : AiConditionCheckCharBase
{
	private readonly short _skillId;

	public AiConditionLearnCombatSkill(IReadOnlyList<int> ints)
		: base(ints)
	{
		_skillId = (short)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return checkChar.GetCharacter().GetLearnedCombatSkills().Contains(_skillId);
	}
}
