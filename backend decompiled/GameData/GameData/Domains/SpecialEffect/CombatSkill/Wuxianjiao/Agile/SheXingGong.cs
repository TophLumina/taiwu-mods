using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Agile;

public class SheXingGong : AttackChangeMobility
{
	public SheXingGong()
	{
	}

	public SheXingGong(CombatSkillKey skillKey)
		: base(skillKey, 12600)
	{
		RequireWeaponSubType = 7;
	}
}
