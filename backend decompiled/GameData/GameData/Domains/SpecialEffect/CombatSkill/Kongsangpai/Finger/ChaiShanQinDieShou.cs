using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Finger;

public class ChaiShanQinDieShou : AddCombatStateBySkillPower
{
	public ChaiShanQinDieShou()
	{
	}

	public ChaiShanQinDieShou(CombatSkillKey skillKey)
		: base(skillKey, 10200)
	{
		StateTypes = new sbyte[2] { 2, 2 };
		StateIds = new short[2] { 43, 44 };
		StateAddToSelf = new bool[2];
		StatePowerUnit = 20;
	}
}
