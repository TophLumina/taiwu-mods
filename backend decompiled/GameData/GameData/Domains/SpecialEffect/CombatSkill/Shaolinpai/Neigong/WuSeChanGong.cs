using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class WuSeChanGong : StrengthenMainAttribute
{
	protected override bool ConsummateLevelRelatedMainAttributesHitAvoid => true;

	public WuSeChanGong()
	{
	}

	public WuSeChanGong(CombatSkillKey skillKey)
		: base(skillKey, 1003)
	{
		MainAttributeType = 2;
	}
}
