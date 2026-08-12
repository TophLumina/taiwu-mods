using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class QingHuangChiHeiShenZhang : StrengthenPoison
{
	protected override bool Variant1 => false;

	public QingHuangChiHeiShenZhang()
	{
	}

	public QingHuangChiHeiShenZhang(CombatSkillKey skillKey)
		: base(skillKey, 12106)
	{
		AffectPoisonType = 4;
	}
}
