using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Finger;

public class ShaoLinYiZhiChan : AddCombatStateBySkillPower
{
	public ShaoLinYiZhiChan()
	{
	}

	public ShaoLinYiZhiChan(CombatSkillKey skillKey)
		: base(skillKey, 1201)
	{
		StateTypes = new sbyte[2] { 1, 2 };
		StateIds = new short[2] { 8, 9 };
		StateAddToSelf = new bool[2] { true, false };
		StatePowerUnit = 20;
	}
}
