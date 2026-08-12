using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class WangFaDanGong : TwelveImmortalsRelationBase
{
	protected override ushort RelationType => 16384;

	public WangFaDanGong()
	{
	}

	public WangFaDanGong(CombatSkillKey skillKey)
		: base(skillKey, 18010)
	{
	}
}
