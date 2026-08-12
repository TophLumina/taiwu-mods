using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;

public class SuSiGe : PreventAttack
{
	public SuSiGe()
	{
	}

	public SuSiGe(CombatSkillKey skillKey)
		: base(skillKey, 17025)
	{
	}
}
