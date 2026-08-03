using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;

public class NingHong : PreventMoveAndWeapon
{
	public NingHong()
	{
	}

	public NingHong(CombatSkillKey skillKey)
		: base(skillKey, 17023)
	{
	}
}
