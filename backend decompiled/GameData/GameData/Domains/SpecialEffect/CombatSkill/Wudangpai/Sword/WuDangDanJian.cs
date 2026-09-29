using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class WuDangDanJian : ChangePowerByEquipType
{
	public WuDangDanJian()
	{
	}

	public WuDangDanJian(CombatSkillKey skillKey)
		: base(skillKey, 4200)
	{
		AffectEquipType = 4;
	}
}
