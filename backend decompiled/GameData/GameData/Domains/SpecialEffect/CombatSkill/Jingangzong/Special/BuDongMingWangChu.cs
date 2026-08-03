using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class BuDongMingWangChu : AddPestleEffect
{
	public BuDongMingWangChu()
	{
	}

	public BuDongMingWangChu(CombatSkillKey skillKey)
		: base(skillKey, 11307)
	{
		PestleEffectName = "CombatSkill.Jingangzong.PestleEffect.BuDongMingWangChu";
	}
}
