using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class DaWeiDeJinGangChu : AddPestleEffect
{
	public DaWeiDeJinGangChu()
	{
	}

	public DaWeiDeJinGangChu(CombatSkillKey skillKey)
		: base(skillKey, 11305)
	{
		PestleEffectName = "CombatSkill.Jingangzong.PestleEffect.DaWeiDeJinGangChu";
	}
}
