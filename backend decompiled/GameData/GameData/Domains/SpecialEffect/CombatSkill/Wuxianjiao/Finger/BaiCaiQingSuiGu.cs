using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class BaiCaiQingSuiGu : AddWug
{
	protected override int AddWugCount => 28;

	public BaiCaiQingSuiGu()
	{
	}

	public BaiCaiQingSuiGu(CombatSkillKey skillKey)
		: base(skillKey, 12208)
	{
		WugType = 7;
	}
}
