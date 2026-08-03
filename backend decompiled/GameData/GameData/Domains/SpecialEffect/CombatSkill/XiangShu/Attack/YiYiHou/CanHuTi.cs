using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class CanHuTi : AddMindMarkAndReduceTrick
{
	public CanHuTi()
	{
	}

	public CanHuTi(CombatSkillKey skillKey)
		: base(skillKey, 17041)
	{
		AffectFrameCount = 60;
	}
}
