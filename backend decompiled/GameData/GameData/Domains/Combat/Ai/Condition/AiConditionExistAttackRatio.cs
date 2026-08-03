using System.Collections.Generic;
using System.Linq;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.ExistAttackRatio)]
public class AiConditionExistAttackRatio : AiConditionCombatBase
{
	private readonly int _lowerBound;

	private readonly int _upperBound;

	private static bool IsValid(short skillId)
	{
		return skillId >= 0;
	}

	public AiConditionExistAttackRatio(IReadOnlyList<int> ints)
	{
		_lowerBound = ints[0];
		_upperBound = ints[1];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		int charId = combatChar.GetId();
		return combatChar.GetAttackSkillList().Where(IsValid).Where(combatChar.AiCanCast)
			.Where(delegate(short skillId)
			{
				if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: charId, skillId: skillId), out var element))
				{
					return false;
				}
				sbyte currInnerRatio = element.GetCurrInnerRatio();
				return currInnerRatio >= _lowerBound && currInnerRatio <= _upperBound;
			})
			.Any();
	}
}
