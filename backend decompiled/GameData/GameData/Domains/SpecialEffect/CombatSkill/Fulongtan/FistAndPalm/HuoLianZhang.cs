using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class HuoLianZhang : IgnoreArmor
{
	public HuoLianZhang()
	{
	}

	public HuoLianZhang(CombatSkillKey skillKey)
		: base(skillKey, 14102)
	{
		RequireMainAttributeType = 3;
	}
}
