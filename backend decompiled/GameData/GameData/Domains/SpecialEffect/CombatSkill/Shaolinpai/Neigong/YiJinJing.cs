using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class YiJinJing : ChangeNeiliAllocation
{
	public YiJinJing()
	{
	}

	public YiJinJing(CombatSkillKey skillKey)
		: base(skillKey, 1007)
	{
		AffectNeiliAllocationType = 2;
	}
}
