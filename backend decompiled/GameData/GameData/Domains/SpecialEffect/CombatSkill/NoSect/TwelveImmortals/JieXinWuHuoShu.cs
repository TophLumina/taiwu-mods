using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class JieXinWuHuoShu : TwelveImmortalsRelationBase
{
	protected override ushort RelationType => 32768;

	public JieXinWuHuoShu()
	{
	}

	public JieXinWuHuoShu(CombatSkillKey skillKey)
		: base(skillKey, 18000)
	{
	}
}
