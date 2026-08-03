using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class SiXiangXueHuoShu : AttackExtraPart
{
	public SiXiangXueHuoShu()
	{
	}

	public SiXiangXueHuoShu(CombatSkillKey skillKey)
		: base(skillKey, 17042)
	{
		AttackExtraPartCount = 1;
	}
}
