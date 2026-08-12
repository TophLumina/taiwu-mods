using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class NuMuJinGangChu : AddPestleEffect
{
	public NuMuJinGangChu()
	{
	}

	public NuMuJinGangChu(CombatSkillKey skillKey)
		: base(skillKey, 11303)
	{
		PestleEffectName = "CombatSkill.Jingangzong.PestleEffect.NuMuJinGangChu";
	}
}
