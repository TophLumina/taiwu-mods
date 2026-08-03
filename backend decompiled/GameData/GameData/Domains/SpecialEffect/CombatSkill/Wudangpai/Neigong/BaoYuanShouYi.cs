using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class BaoYuanShouYi : StrengthenFiveElementsTypeSimple
{
	protected override sbyte FiveElementsType => 3;

	public BaoYuanShouYi()
	{
	}

	public BaoYuanShouYi(CombatSkillKey skillKey)
		: base(skillKey, 4001)
	{
	}
}
