using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Character;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.ExistDefenseBounce)]
public class AiConditionExistDefenseBounce : AiConditionCombatBase
{
	private readonly bool _isInner;

	private static bool IsValid(short skillId)
	{
		return skillId >= 0;
	}

	public AiConditionExistDefenseBounce(IReadOnlyList<int> ints)
	{
		_isInner = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		int charId = combatChar.GetId();
		return combatChar.GetDefenceSkillList().Where(IsValid).Where(combatChar.AiCanCast)
			.Where(delegate(short skillId)
			{
				if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: charId, skillId: skillId), out var element))
				{
					return false;
				}
				OuterAndInnerInts bouncePower = element.GetBouncePower();
				return _isInner ? (bouncePower.Inner > 0) : (bouncePower.Outer > 0);
			})
			.Any();
	}
}
