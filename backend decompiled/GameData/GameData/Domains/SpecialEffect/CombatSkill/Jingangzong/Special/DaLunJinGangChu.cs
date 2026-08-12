using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class DaLunJinGangChu : ReverseNext
{
	public DaLunJinGangChu()
	{
	}

	public DaLunJinGangChu(CombatSkillKey skillKey)
		: base(skillKey, 11304)
	{
		AffectSectId = 11;
		AffectSkillType = 10;
	}
}
