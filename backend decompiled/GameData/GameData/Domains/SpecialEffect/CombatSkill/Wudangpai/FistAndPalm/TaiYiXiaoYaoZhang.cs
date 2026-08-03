using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class TaiYiXiaoYaoZhang : AddPowerAndNeiliAllocationByMoving
{
	public TaiYiXiaoYaoZhang()
	{
	}

	public TaiYiXiaoYaoZhang(CombatSkillKey skillKey)
		: base(skillKey, 4104)
	{
		AddNeiliAllocationType = 3;
	}
}
