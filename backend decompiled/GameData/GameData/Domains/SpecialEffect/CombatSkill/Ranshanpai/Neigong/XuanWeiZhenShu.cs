using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class XuanWeiZhenShu : ChangeNeiliAllocation
{
	public XuanWeiZhenShu()
	{
	}

	public XuanWeiZhenShu(CombatSkillKey skillKey)
		: base(skillKey, 7007)
	{
		AffectNeiliAllocationType = 3;
	}
}
