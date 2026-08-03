using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Agile;

public class WeiYaXuanHu : AttackChangeMobility
{
	public WeiYaXuanHu()
	{
	}

	public WeiYaXuanHu(CombatSkillKey skillKey)
		: base(skillKey, 10501)
	{
		RequireWeaponSubType = 14;
	}
}
