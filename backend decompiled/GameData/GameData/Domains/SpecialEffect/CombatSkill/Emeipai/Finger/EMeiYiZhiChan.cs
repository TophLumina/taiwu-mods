using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class EMeiYiZhiChan : AddCombatStateBySkillPower
{
	public EMeiYiZhiChan()
	{
	}

	public EMeiYiZhiChan(CombatSkillKey skillKey)
		: base(skillKey, 2201)
	{
		StateTypes = new sbyte[2] { 1, 2 };
		StateIds = new short[2] { 17, 18 };
		StateAddToSelf = new bool[2] { true, false };
		StatePowerUnit = 20;
	}
}
