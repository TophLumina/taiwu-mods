using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkillDefendBlock)]
public class AiActionCastSkillDefendBlock : AiActionCastSkillBase
{
	protected override CombatSkillSelector Selector { get; } = new CombatSkillSelector(3, Predicate, Comparison);

	private static bool Predicate(CombatSkillSelectorContext context)
	{
		return false;
	}

	private static int Comparison(CombatSkillSelectorContext contextA, CombatSkillSelectorContext contextB)
	{
		return 0;
	}
}
