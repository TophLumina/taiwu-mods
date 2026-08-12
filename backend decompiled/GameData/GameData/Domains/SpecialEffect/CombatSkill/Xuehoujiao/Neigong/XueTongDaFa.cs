using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class XueTongDaFa : ChangeNeiliAllocation
{
	public XueTongDaFa()
	{
	}

	public XueTongDaFa(CombatSkillKey skillKey)
		: base(skillKey, 15008)
	{
		AffectNeiliAllocationType = 0;
	}
}
