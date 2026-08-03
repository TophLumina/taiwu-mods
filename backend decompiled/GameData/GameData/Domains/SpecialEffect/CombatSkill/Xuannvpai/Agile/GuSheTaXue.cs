using System;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Agile;

public class GuSheTaXue : CheckHitEffect
{
	private const int AttractionUnit = 360;

	private const int MaxReplaceCount = 3;

	public GuSheTaXue()
	{
	}

	public GuSheTaXue(CombatSkillKey skillKey)
		: base(skillKey, 8405)
	{
		CheckHitType = 3;
	}

	protected override bool HitEffect(DataContext context)
	{
		CombatCharacter trickChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		int maxReplaceCount = 1 + Math.Clamp(base.CombatChar.GetCharacter().GetAttraction() / 360, 0, 2);
		int replaceCount = trickChar.ReplaceUsableTrick(context, 20, maxReplaceCount);
		return replaceCount > 0;
	}
}
