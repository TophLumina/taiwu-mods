using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Agile;

public class XianShiJiao : ChangeAttackHitType
{
	public XianShiJiao()
	{
	}

	public XianShiJiao(CombatSkillKey skillKey)
		: base(skillKey, 11500)
	{
		HitType = 0;
	}
}
