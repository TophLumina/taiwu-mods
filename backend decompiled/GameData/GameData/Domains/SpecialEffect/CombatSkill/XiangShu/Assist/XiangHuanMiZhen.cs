using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class XiangHuanMiZhen : AddDamageByHitType
{
	public XiangHuanMiZhen()
	{
	}

	public XiangHuanMiZhen(CombatSkillKey skillKey)
		: base(skillKey, 16404)
	{
		HitType = 3;
	}
}
