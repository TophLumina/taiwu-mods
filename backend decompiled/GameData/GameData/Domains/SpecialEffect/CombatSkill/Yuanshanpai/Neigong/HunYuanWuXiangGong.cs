using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Neigong;

public class HunYuanWuXiangGong : ChangeFiveElementsDirection
{
	protected override sbyte FiveElementsType => 4;

	protected override byte NeiliAllocationType => 3;

	public HunYuanWuXiangGong()
	{
	}

	public HunYuanWuXiangGong(CombatSkillKey skillKey)
		: base(skillKey, 5004)
	{
	}
}
