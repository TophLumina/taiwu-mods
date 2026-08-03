using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;

public class BianZouBianSha : AddPowerAndNeiliAllocationByMoving
{
	public BianZouBianSha()
	{
	}

	public BianZouBianSha(CombatSkillKey skillKey)
		: base(skillKey, 15304)
	{
		AddNeiliAllocationType = 0;
	}
}
