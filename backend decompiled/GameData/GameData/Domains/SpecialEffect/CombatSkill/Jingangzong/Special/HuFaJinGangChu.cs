using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class HuFaJinGangChu : AddPestleEffect
{
	public HuFaJinGangChu()
	{
	}

	public HuFaJinGangChu(CombatSkillKey skillKey)
		: base(skillKey, 11301)
	{
		PestleEffectName = "CombatSkill.Jingangzong.PestleEffect.HuFaJinGangChu";
	}
}
