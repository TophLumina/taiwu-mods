using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class PuTiXinXiuFa : TransferFiveElementsNeili
{
	public PuTiXinXiuFa()
	{
	}

	public PuTiXinXiuFa(CombatSkillKey skillKey)
		: base(skillKey, 1004)
	{
		SrcFiveElementsType = (sbyte)((!base.IsDirect) ? 1 : 2);
		DestFiveElementsType = 0;
	}
}
