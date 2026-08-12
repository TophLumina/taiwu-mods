using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class ZhanELong : ReduceResources
{
	public ZhanELong()
	{
	}

	public ZhanELong(CombatSkillKey skillKey)
		: base(skillKey, 17013)
	{
		AffectFrameCount = 60;
	}
}
