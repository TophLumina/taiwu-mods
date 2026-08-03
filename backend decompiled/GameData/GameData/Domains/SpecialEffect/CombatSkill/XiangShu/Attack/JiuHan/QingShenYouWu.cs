using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;

public class QingShenYouWu : AddAcupoint
{
	public QingShenYouWu()
	{
	}

	public QingShenYouWu(CombatSkillKey skillKey)
		: base(skillKey, 17021)
	{
		AcupointCount = 1;
	}
}
