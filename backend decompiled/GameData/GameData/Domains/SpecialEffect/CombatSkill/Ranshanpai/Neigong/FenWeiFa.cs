using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class FenWeiFa : ChangeFiveElementsDirection
{
	protected override sbyte FiveElementsType => 1;

	protected override byte NeiliAllocationType => 3;

	public FenWeiFa()
	{
	}

	public FenWeiFa(CombatSkillKey skillKey)
		: base(skillKey, 7005)
	{
	}
}
