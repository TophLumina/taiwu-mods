using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class FengYinJiuChu : AddFlaw
{
	public FengYinJiuChu()
	{
	}

	public FengYinJiuChu(CombatSkillKey skillKey)
		: base(skillKey, 17034)
	{
		FlawCount = 2;
	}
}
