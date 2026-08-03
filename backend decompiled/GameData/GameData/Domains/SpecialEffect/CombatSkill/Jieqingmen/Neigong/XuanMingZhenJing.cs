using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;

public class XuanMingZhenJing : TransferFiveElementsNeili
{
	public XuanMingZhenJing()
	{
	}

	public XuanMingZhenJing(CombatSkillKey skillKey)
		: base(skillKey, 13004)
	{
		SrcFiveElementsType = (sbyte)((!base.IsDirect) ? 4 : 0);
		DestFiveElementsType = 2;
	}
}
