using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;

public class QingShenSiWu : AddAcupoint
{
	public QingShenSiWu()
	{
	}

	public QingShenSiWu(CombatSkillKey skillKey)
		: base(skillKey, 17024)
	{
		AcupointCount = 2;
	}
}
