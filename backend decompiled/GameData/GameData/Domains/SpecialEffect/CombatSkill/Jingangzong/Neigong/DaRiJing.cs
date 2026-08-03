using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class DaRiJing : TransferFiveElementsNeili
{
	public DaRiJing()
	{
	}

	public DaRiJing(CombatSkillKey skillKey)
		: base(skillKey, 11005)
	{
		SrcFiveElementsType = (sbyte)(base.IsDirect ? 4 : 3);
		DestFiveElementsType = 0;
	}
}
