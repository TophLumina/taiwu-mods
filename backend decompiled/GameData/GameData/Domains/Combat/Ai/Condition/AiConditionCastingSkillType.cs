using System.Collections.Generic;
using Config;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CastingSkillType)]
public class AiConditionCastingSkillType : AiConditionCombatBase
{
	private readonly bool _isAlly;

	private readonly sbyte _equipType;

	public AiConditionCastingSkillType(IReadOnlyList<int> ints)
	{
		_isAlly = ints[0] == 1;
		_equipType = (sbyte)ints[1];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == _isAlly);
		if (checkChar.GetPreparingSkillId() < 0)
		{
			return false;
		}
		sbyte equipType = Config.CombatSkill.Instance[checkChar.GetPreparingSkillId()].EquipType;
		return equipType == _equipType;
	}
}
