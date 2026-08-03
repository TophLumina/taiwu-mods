using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class PoYaoHui : ReduceResources
{
	public PoYaoHui()
	{
	}

	public PoYaoHui(CombatSkillKey skillKey)
		: base(skillKey, 17010)
	{
		AffectFrameCount = 120;
	}
}
