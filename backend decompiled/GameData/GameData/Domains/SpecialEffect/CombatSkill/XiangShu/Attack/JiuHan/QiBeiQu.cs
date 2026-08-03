using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;

public class QiBeiQu : PreventAttack
{
	public QiBeiQu()
	{
	}

	public QiBeiQu(CombatSkillKey skillKey)
		: base(skillKey, 17022)
	{
	}
}
