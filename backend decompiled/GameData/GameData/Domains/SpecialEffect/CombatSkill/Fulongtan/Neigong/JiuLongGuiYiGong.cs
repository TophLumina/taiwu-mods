using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class JiuLongGuiYiGong : ChangeFiveElementsDirection
{
	protected override sbyte FiveElementsType => 3;

	protected override byte NeiliAllocationType => 0;

	public JiuLongGuiYiGong()
	{
	}

	public JiuLongGuiYiGong(CombatSkillKey skillKey)
		: base(skillKey, 14005)
	{
	}
}
