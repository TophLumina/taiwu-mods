using GameData.Domains.Combat.Ai.Selector;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkillAgileBuff)]
public class AiActionCastSkillAgileBuff : AiActionCastSkillBase
{
	protected override CombatSkillSelector Selector { get; } = new CombatSkillSelector(2, Predicate, Comparison);

	private static bool Predicate(CombatSkillSelectorContext context)
	{
		return context.Template.AddHitOnCast.Sum() > 0;
	}

	private static int Comparison(CombatSkillSelectorContext contextA, CombatSkillSelectorContext contextB)
	{
		int sumA = contextA.Template.AddHitOnCast.Sum();
		int sumB = contextB.Template.AddHitOnCast.Sum();
		return (sumA != sumB) ? sumB.CompareTo(sumA) : 0;
	}
}
