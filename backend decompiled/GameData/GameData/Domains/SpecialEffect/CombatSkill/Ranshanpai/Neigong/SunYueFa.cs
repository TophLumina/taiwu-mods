using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class SunYueFa : StrengthenMainAttribute
{
	protected override bool ConsummateLevelRelatedMainAttributesHitAvoid => true;

	public SunYueFa()
	{
	}

	public SunYueFa(CombatSkillKey skillKey)
		: base(skillKey, 7003)
	{
		MainAttributeType = 5;
	}
}
