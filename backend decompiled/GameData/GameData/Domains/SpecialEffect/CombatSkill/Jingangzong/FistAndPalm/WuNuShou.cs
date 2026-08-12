using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class WuNuShou : AddCombatStateBySkillPower
{
	public WuNuShou()
	{
	}

	public WuNuShou(CombatSkillKey skillKey)
		: base(skillKey, 11101)
	{
		StateTypes = new sbyte[2] { 1, 1 };
		StateIds = new short[2] { 53, 54 };
		StateAddToSelf = new bool[2] { true, true };
		StatePowerUnit = 20;
	}
}
