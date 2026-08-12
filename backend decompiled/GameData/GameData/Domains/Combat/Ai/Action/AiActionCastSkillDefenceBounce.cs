using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Combat.Ai.Selector;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkillDefenceBounce)]
public class AiActionCastSkillDefenceBounce : AiActionCastSkillBase
{
	private readonly bool _isInner;

	protected override CombatSkillSelector Selector { get; }

	public AiActionCastSkillDefenceBounce(IReadOnlyList<int> ints)
	{
		_isInner = ints[0] == 1;
		Selector = new CombatSkillSelector(3, Predicate, Comparison);
	}

	private bool Predicate(CombatSkillSelectorContext context)
	{
		return true;
	}

	private int Comparison(CombatSkillSelectorContext contextA, CombatSkillSelectorContext contextB)
	{
		GameData.Domains.CombatSkill.CombatSkill skillA = contextA.CombatSkill;
		GameData.Domains.CombatSkill.CombatSkill skillB = contextB.CombatSkill;
		OuterAndInnerInts powerA = skillA.GetBouncePower();
		OuterAndInnerInts powerB = skillB.GetBouncePower();
		return _isInner ? powerB.Inner.CompareTo(powerA.Inner) : powerB.Outer.CompareTo(powerA.Outer);
	}
}
