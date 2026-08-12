using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Agile;

public class FeiZhenChuanSuoShu : AttackChangeMobility
{
	public FeiZhenChuanSuoShu()
	{
	}

	public FeiZhenChuanSuoShu(CombatSkillKey skillKey)
		: base(skillKey, 3402)
	{
		RequireWeaponSubType = 0;
	}
}
