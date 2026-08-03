using System.Collections.Generic;
using Config;
using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkillAgileJumpPrepare)]
public class AiActionCastSkillAgileJumpPrepare : AiActionCastSkillBase
{
	private readonly bool _isDirect;

	protected override CombatSkillSelector Selector { get; }

	public AiActionCastSkillAgileJumpPrepare(IReadOnlyList<int> ints)
	{
		_isDirect = ints[0] == 1;
		Selector = new CombatSkillSelector(2, Predicate, Comparison);
	}

	private bool Predicate(CombatSkillSelectorContext context)
	{
		CombatSkillItem config = context.CombatSkill.Template;
		bool directMeet = (int)context.CombatSkill.GetDirection() == ((!_isDirect) ? 1 : 0);
		return config.JumpPrepareFrame > 0 && directMeet;
	}

	private static int Comparison(CombatSkillSelectorContext contextA, CombatSkillSelectorContext contextB)
	{
		CombatSkillItem configA = contextA.CombatSkill.Template;
		CombatSkillItem configB = contextB.CombatSkill.Template;
		return (configA.JumpPrepareFrame != configB.JumpPrepareFrame) ? configA.JumpPrepareFrame.CompareTo(configB.JumpPrepareFrame) : 0;
	}
}
