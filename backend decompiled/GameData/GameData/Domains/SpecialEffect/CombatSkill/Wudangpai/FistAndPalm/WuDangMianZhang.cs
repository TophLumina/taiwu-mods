using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class WuDangMianZhang : IgnoreArmor
{
	public WuDangMianZhang()
	{
	}

	public WuDangMianZhang(CombatSkillKey skillKey)
		: base(skillKey, 4102)
	{
		RequireMainAttributeType = 4;
	}
}
