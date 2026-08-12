using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Neigong;

public class JiaoZheSiFa : StrengthenMainAttribute
{
	protected override bool ConsummateLevelRelatedMainAttributesPenetrations => true;

	public JiaoZheSiFa()
	{
	}

	public JiaoZheSiFa(CombatSkillKey skillKey)
		: base(skillKey, 10003)
	{
		MainAttributeType = 3;
	}
}
