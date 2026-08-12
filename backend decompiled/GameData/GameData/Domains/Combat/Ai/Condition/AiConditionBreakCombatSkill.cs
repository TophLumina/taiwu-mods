using System.Collections.Generic;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.BreakCombatSkill)]
public class AiConditionBreakCombatSkill : AiConditionCheckCharBase
{
	private readonly short _skillId;

	private readonly bool _isDirect;

	public AiConditionBreakCombatSkill(IReadOnlyList<int> ints)
		: base(ints)
	{
		_skillId = (short)ints[1];
		_isDirect = ints[2] == 1;
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		GameData.Domains.CombatSkill.CombatSkill skill;
		return DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: checkChar.GetId(), skillId: _skillId), out skill) && (int)skill.GetDirection() == ((!_isDirect) ? 1 : 0);
	}
}
