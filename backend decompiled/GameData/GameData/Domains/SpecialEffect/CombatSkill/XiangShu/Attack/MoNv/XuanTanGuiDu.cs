using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class XuanTanGuiDu : AddPoison
{
	public XuanTanGuiDu()
	{
	}

	public XuanTanGuiDu(CombatSkillKey skillKey)
		: base(skillKey, 17004)
	{
		PoisonTypeCount = 6;
	}
}
