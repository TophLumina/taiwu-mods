using System.Collections.Generic;
using Config;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.PreparingAttackRatio)]
public class AiConditionPreparingAttackRatio : AiConditionCheckCharBase
{
	private readonly int _lowerBound;

	private readonly int _upperBound;

	public AiConditionPreparingAttackRatio(IReadOnlyList<int> ints)
		: base(ints)
	{
		_lowerBound = ints[1];
		_upperBound = ints[2];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		short skillTemplateId = checkChar.GetPreparingSkillId();
		if (skillTemplateId < 0)
		{
			return false;
		}
		sbyte equipType = Config.CombatSkill.Instance[skillTemplateId].EquipType;
		if (equipType != 1)
		{
			return false;
		}
		CombatSkillKey key = new CombatSkillKey(checkChar.GetId(), skillTemplateId);
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(key, out var combatSkill))
		{
			return false;
		}
		sbyte ratio = combatSkill.GetCurrInnerRatio();
		return ratio >= _lowerBound && ratio <= _upperBound;
	}
}
