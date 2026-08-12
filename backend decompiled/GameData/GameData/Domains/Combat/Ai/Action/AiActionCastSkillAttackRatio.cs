using System.Collections.Generic;
using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkillAttackRatio)]
public class AiActionCastSkillAttackRatio : AiActionCastSkillBase
{
	private readonly int _lowerBound;

	private readonly int _upperBound;

	protected override CombatSkillSelector Selector { get; }

	public AiActionCastSkillAttackRatio(IReadOnlyList<int> ints)
	{
		_lowerBound = ints[0];
		_upperBound = ints[1];
		Selector = new CombatSkillSelector(1, Predicate, null);
	}

	private bool Predicate(CombatSkillSelectorContext context)
	{
		sbyte ratio = context.CombatSkill.GetCurrInnerRatio();
		return ratio >= _lowerBound && ratio <= _upperBound;
	}
}
