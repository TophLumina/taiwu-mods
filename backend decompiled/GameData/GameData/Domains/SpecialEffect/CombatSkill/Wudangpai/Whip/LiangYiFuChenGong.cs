using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class LiangYiFuChenGong : ReverseNext
{
	public LiangYiFuChenGong()
	{
	}

	public LiangYiFuChenGong(CombatSkillKey skillKey)
		: base(skillKey, 4302)
	{
		AffectSectId = 4;
		AffectSkillType = 11;
	}
}
