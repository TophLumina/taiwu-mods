using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CastingDirectOrReverseSkill)]
public class AiConditionCastingDirectOrReverseSkill : AiConditionCheckCharBase
{
	private readonly bool _isDirect;

	private readonly short _skillId;

	public AiConditionCastingDirectOrReverseSkill(IReadOnlyList<int> ints)
		: base(ints)
	{
		_isDirect = ints[1] == 1;
		_skillId = (short)ints[2];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		short casting = checkChar.GetPreparingSkillId();
		if (casting != _skillId)
		{
			return false;
		}
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: checkChar.GetId(), skillId: casting), out var skill))
		{
			return false;
		}
		return (int)skill.GetDirection() == ((!_isDirect) ? 1 : 0);
	}
}
