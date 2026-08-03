using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class CanHuTong : AddMindMarkAndReduceTrick
{
	public CanHuTong()
	{
	}

	public CanHuTong(CombatSkillKey skillKey)
		: base(skillKey, 17044)
	{
		AffectFrameCount = 30;
	}
}
