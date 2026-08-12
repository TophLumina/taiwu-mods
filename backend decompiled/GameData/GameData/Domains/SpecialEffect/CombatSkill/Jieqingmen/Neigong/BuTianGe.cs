using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;

public class BuTianGe : StrengthenMainAttribute
{
	protected override bool ConsummateLevelRelatedMainAttributesHitAvoid => true;

	public BuTianGe()
	{
	}

	public BuTianGe(CombatSkillKey skillKey)
		: base(skillKey, 13003)
	{
		MainAttributeType = 1;
	}
}
