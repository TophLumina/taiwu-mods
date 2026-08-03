using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;

public class HanTanCangHuiShi : AccumulateNeiliAllocationToStrengthen
{
	public HanTanCangHuiShi()
	{
	}

	public HanTanCangHuiShi(CombatSkillKey skillKey)
		: base(skillKey, 8204)
	{
		RequireNeiliAllocationType = 1;
	}
}
