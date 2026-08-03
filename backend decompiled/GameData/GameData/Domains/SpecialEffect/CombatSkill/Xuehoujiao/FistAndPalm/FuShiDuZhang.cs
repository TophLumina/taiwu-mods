using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class FuShiDuZhang : ChangePoisonLevelVariant1
{
	protected override sbyte AffectPoisonType => 4;

	public FuShiDuZhang()
	{
	}

	public FuShiDuZhang(CombatSkillKey skillKey)
		: base(skillKey, 15103)
	{
	}
}
