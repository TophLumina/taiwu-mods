using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionCastDirectOrReverseCombatSkill)]
public class AiConditionOptionCastDirectOrReverseCombatSkill : AiConditionOptionCastSpecialCombatSkill
{
	private readonly bool _isDirect;

	public AiConditionOptionCastDirectOrReverseCombatSkill(IReadOnlyList<int> ints)
		: base(ints)
	{
		_isDirect = ints[1] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: combatChar.GetId(), skillId: SkillId), out var skill))
		{
			return false;
		}
		return (int)skill.GetDirection() == ((!_isDirect) ? 1 : 0) && base.Check(memory, combatChar);
	}
}
