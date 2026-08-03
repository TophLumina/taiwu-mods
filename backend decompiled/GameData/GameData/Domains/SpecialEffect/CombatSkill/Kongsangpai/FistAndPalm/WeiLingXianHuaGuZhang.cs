using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.FistAndPalm;

public class WeiLingXianHuaGuZhang : AddCombatStateBySkillPower
{
	public WeiLingXianHuaGuZhang()
	{
	}

	public WeiLingXianHuaGuZhang(CombatSkillKey skillKey)
		: base(skillKey, 10103)
	{
		StateTypes = new sbyte[2] { 2, 2 };
		StateIds = new short[2] { 45, 46 };
		StateAddToSelf = new bool[2];
		StatePowerUnit = 20;
	}
}
