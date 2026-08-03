using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class ZaAHanJing : ChangeFiveElementsDirection
{
	protected override sbyte FiveElementsType => 0;

	protected override byte NeiliAllocationType => 2;

	public ZaAHanJing()
	{
	}

	public ZaAHanJing(CombatSkillKey skillKey)
		: base(skillKey, 1005)
	{
	}
}
