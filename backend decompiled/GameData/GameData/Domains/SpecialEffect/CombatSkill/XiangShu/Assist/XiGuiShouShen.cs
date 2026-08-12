using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class XiGuiShouShen : AddDamageByHitType
{
	public XiGuiShouShen()
	{
	}

	public XiGuiShouShen(CombatSkillKey skillKey)
		: base(skillKey, 16406)
	{
		HitType = 2;
	}
}
