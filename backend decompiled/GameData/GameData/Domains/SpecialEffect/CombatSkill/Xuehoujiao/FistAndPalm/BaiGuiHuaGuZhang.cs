using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class BaiGuiHuaGuZhang : CastAgainOrPowerUp
{
	public BaiGuiHuaGuZhang()
	{
	}

	public BaiGuiHuaGuZhang(CombatSkillKey skillKey)
		: base(skillKey, 15105)
	{
		RequireTrickType = 8;
	}
}
