using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CastingSkill)]
public class AiConditionCastingSkill : AiConditionCombatBase
{
	private readonly bool _isAlly;

	private readonly short _skillId;

	public AiConditionCastingSkill(IReadOnlyList<int> ints)
	{
		_isAlly = ints[0] == 1;
		_skillId = (short)ints[1];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == _isAlly);
		return checkChar.GetPreparingSkillId() == _skillId;
	}
}
