using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class FenShenXueHuoShu : AttackExtraPart
{
	public FenShenXueHuoShu()
	{
	}

	public FenShenXueHuoShu(CombatSkillKey skillKey)
		: base(skillKey, 17045)
	{
		AttackExtraPartCount = 3;
	}
}
