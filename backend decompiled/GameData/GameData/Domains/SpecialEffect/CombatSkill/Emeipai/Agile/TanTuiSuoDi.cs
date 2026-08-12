using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Agile;

public class TanTuiSuoDi : ChangeAttackHitType
{
	public TanTuiSuoDi()
	{
	}

	public TanTuiSuoDi(CombatSkillKey skillKey)
		: base(skillKey, 2500)
	{
		HitType = 2;
	}
}
