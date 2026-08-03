using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class TaiYuanYuNvGong : ChangeNeiliAllocation
{
	public TaiYuanYuNvGong()
	{
	}

	public TaiYuanYuNvGong(CombatSkillKey skillKey)
		: base(skillKey, 8007)
	{
		AffectNeiliAllocationType = 1;
	}
}
