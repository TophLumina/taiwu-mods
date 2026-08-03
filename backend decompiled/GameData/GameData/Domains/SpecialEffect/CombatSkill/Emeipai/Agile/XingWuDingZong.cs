using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Agile;

public class XingWuDingZong : AttackChangeMobility
{
	public XingWuDingZong()
	{
	}

	public XingWuDingZong(CombatSkillKey skillKey)
		: base(skillKey, 2502)
	{
		RequireWeaponSubType = 1;
	}
}
