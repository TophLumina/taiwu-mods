using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;

public class SuXue : PreventMoveAndWeapon
{
	public SuXue()
	{
	}

	public SuXue(CombatSkillKey skillKey)
		: base(skillKey, 17020)
	{
	}
}
