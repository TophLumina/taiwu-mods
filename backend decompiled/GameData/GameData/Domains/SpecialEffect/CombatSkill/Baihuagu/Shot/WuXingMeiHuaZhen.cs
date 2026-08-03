using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;

public class WuXingMeiHuaZhen : GetTrick
{
	public WuXingMeiHuaZhen()
	{
	}

	public WuXingMeiHuaZhen(CombatSkillKey skillKey)
		: base(skillKey, 3201)
	{
		GetTrickType = 2;
		DirectCanChangeTrickType = new sbyte[2] { 0, 1 };
	}
}
