using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Neigong;

public class BuNianXinJue : TransferFiveElementsNeili
{
	public BuNianXinJue()
	{
	}

	public BuNianXinJue(CombatSkillKey skillKey)
		: base(skillKey, 5003)
	{
		SrcFiveElementsType = ((!base.IsDirect) ? ((sbyte)1) : ((sbyte)0));
		DestFiveElementsType = 4;
	}
}
