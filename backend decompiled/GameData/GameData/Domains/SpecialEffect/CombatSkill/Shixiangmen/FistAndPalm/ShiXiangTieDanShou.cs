using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.FistAndPalm;

public class ShiXiangTieDanShou : GetTrick
{
	public ShiXiangTieDanShou()
	{
	}

	public ShiXiangTieDanShou(CombatSkillKey skillKey)
		: base(skillKey, 6101)
	{
		GetTrickType = 6;
		DirectCanChangeTrickType = new sbyte[2] { 7, 8 };
	}
}
