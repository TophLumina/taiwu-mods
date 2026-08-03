using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Neigong;

public class GuangMingShiZiJin : StrengthenMainAttribute
{
	protected override bool ConsummateLevelRelatedMainAttributesHitAvoid => true;

	public GuangMingShiZiJin()
	{
	}

	public GuangMingShiZiJin(CombatSkillKey skillKey)
		: base(skillKey, 6003)
	{
		MainAttributeType = 0;
	}
}
