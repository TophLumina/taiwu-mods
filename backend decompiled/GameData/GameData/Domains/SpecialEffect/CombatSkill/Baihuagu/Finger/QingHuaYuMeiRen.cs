using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class QingHuaYuMeiRen : ChangePoisonLevelVariant1
{
	protected override sbyte AffectPoisonType => 5;

	public QingHuaYuMeiRen()
	{
	}

	public QingHuaYuMeiRen(CombatSkillKey skillKey)
		: base(skillKey, 3103)
	{
	}
}
