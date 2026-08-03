using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class WuJianHuaJian : MobilityAddPower
{
	public WuJianHuaJian()
	{
	}

	public WuJianHuaJian(CombatSkillKey skillKey)
		: base(skillKey, 17061)
	{
		AddPowerUnit = 1;
	}
}
