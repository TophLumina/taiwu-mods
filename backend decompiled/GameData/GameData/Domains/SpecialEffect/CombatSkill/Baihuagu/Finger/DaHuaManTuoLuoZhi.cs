using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class DaHuaManTuoLuoZhi : PowerUpByPoison
{
	protected override sbyte RequirePoisonType => 5;

	protected override short DirectStateId => 220;

	protected override short ReverseStateId => 221;

	public DaHuaManTuoLuoZhi()
	{
	}

	public DaHuaManTuoLuoZhi(CombatSkillKey skillKey)
		: base(skillKey, 3105)
	{
	}
}
