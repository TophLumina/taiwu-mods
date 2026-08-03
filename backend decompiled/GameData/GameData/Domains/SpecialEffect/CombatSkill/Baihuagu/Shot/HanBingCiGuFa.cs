using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;

public class HanBingCiGuFa : PowerUpByPoison
{
	protected override sbyte RequirePoisonType => 2;

	protected override short DirectStateId => 214;

	protected override short ReverseStateId => 215;

	public HanBingCiGuFa()
	{
	}

	public HanBingCiGuFa(CombatSkillKey skillKey)
		: base(skillKey, 3202)
	{
	}
}
