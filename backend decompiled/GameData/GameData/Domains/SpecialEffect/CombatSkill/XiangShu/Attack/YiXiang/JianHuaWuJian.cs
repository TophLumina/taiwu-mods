using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class JianHuaWuJian : MobilityAddPower
{
	public JianHuaWuJian()
	{
	}

	public JianHuaWuJian(CombatSkillKey skillKey)
		: base(skillKey, 17064)
	{
		AddPowerUnit = 2;
	}
}
