using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class CunXinDuanMeng : ReduceResourceAfterMove
{
	public CunXinDuanMeng()
	{
	}

	public CunXinDuanMeng(CombatSkillKey skillKey)
		: base(skillKey, 17003)
	{
	}
}
