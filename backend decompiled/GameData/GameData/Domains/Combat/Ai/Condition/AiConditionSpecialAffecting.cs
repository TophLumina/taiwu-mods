using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionSpecialAffecting : AiConditionAnyAffecting
{
	protected readonly bool IsDirect;

	protected readonly short SkillId;

	protected AiConditionSpecialAffecting(IReadOnlyList<int> ints)
		: base(ints)
	{
		IsDirect = ints[1] == 1;
		SkillId = (short)ints[2];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == IsAlly);
		if (checkChar.GetAffectingMoveSkillId() != SkillId)
		{
			return false;
		}
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: checkChar.GetId(), skillId: SkillId), out var skill))
		{
			return false;
		}
		return (int)skill.GetDirection() == ((!IsDirect) ? 1 : 0);
	}
}
