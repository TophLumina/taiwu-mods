using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Agile;

public class YunHuanBu : AttackChangeMobility
{
	public YunHuanBu()
	{
	}

	public YunHuanBu(CombatSkillKey skillKey)
		: base(skillKey, 4402)
	{
		RequireWeaponSubType = 6;
	}
}
