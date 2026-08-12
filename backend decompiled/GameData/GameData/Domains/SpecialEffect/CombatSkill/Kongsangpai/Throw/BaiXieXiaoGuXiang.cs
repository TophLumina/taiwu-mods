using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class BaiXieXiaoGuXiang : StrengthenPoison
{
	public BaiXieXiaoGuXiang()
	{
	}

	public BaiXieXiaoGuXiang(CombatSkillKey skillKey)
		: base(skillKey, 10406)
	{
		AffectPoisonType = 1;
	}
}
