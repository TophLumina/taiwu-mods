using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class TianMoCanHunZhang : StrengthenPoison
{
	public TianMoCanHunZhang()
	{
	}

	public TianMoCanHunZhang(CombatSkillKey skillKey)
		: base(skillKey, 15106)
	{
		AffectPoisonType = 0;
	}
}
