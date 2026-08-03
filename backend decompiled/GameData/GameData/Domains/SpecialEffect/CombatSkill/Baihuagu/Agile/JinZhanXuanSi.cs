using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Agile;

public class JinZhanXuanSi : CheckHitEffect
{
	public JinZhanXuanSi()
	{
	}

	public JinZhanXuanSi(CombatSkillKey skillKey)
		: base(skillKey, 3405)
	{
		CheckHitType = 1;
	}

	protected override bool HitEffect(DataContext context)
	{
		return base.CurrEnemyChar.WorsenRandomInjury(context, WorsenConstants.HighPercent);
	}
}
