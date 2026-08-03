using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.DefenseAndAssist;

public class TaiBuXuanDian : TrickAddHitOrAvoid
{
	public TaiBuXuanDian()
	{
	}

	public TaiBuXuanDian(CombatSkillKey skillKey)
		: base(skillKey, 5605)
	{
		RequireTrickTypes = new sbyte[3] { 3, 5, 4 };
	}
}
