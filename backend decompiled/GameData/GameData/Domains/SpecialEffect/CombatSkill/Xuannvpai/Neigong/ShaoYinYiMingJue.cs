using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class ShaoYinYiMingJue : StrengthenMainAttribute
{
	protected override bool ConsummateLevelRelatedMainAttributesPenetrations => true;

	public ShaoYinYiMingJue()
	{
	}

	public ShaoYinYiMingJue(CombatSkillKey skillKey)
		: base(skillKey, 8003)
	{
		MainAttributeType = 4;
	}
}
