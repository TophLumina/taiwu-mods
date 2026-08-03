using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class CunXinRuMeng : ReduceResourceAfterMove
{
	public CunXinRuMeng()
	{
	}

	public CunXinRuMeng(CombatSkillKey skillKey)
		: base(skillKey, 17000)
	{
	}
}
