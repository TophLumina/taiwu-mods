using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.DefenseAndAssist;

public class TianMangDanXinShu : TrickAddHitOrAvoid
{
	public TianMangDanXinShu()
	{
	}

	public TianMangDanXinShu(CombatSkillKey skillKey)
		: base(skillKey, 14605)
	{
		RequireTrickTypes = new sbyte[3] { 6, 8, 7 };
	}
}
