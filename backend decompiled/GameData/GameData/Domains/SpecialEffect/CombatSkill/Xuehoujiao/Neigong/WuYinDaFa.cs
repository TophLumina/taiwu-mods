using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class WuYinDaFa : FiveElementsAddHitAndAvoid
{
	public WuYinDaFa()
	{
	}

	public WuYinDaFa(CombatSkillKey skillKey)
		: base(skillKey, 15005)
	{
		RequireFiveElementsType = 4;
	}
}
