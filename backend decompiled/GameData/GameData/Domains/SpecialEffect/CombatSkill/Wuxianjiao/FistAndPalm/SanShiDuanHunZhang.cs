using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class SanShiDuanHunZhang : ChangePoisonType
{
	public SanShiDuanHunZhang()
	{
	}

	public SanShiDuanHunZhang(CombatSkillKey skillKey)
		: base(skillKey, 12103)
	{
		CanChangePoisonType = new sbyte[3] { 0, 3, 4 };
		AddPowerPoisonType = 4;
	}
}
