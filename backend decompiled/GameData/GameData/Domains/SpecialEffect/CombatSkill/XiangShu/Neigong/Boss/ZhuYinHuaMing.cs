using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class ZhuYinHuaMing : BossNeigongBase
{
	private const sbyte AutoHealSpeed = 2;

	public ZhuYinHuaMing()
	{
	}

	public ZhuYinHuaMing(CombatSkillKey skillKey)
		: base(skillKey, 16105)
	{
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		base.CombatChar.OuterInjuryAutoHealSpeeds.Add(2);
		base.CombatChar.InnerInjuryAutoHealSpeeds.Add(2);
	}
}
