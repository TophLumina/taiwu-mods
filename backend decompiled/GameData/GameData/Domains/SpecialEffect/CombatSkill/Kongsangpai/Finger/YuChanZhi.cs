using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Finger;

public class YuChanZhi : ChangePoisonType
{
	public YuChanZhi()
	{
	}

	public YuChanZhi(CombatSkillKey skillKey)
		: base(skillKey, 10203)
	{
		CanChangePoisonType = new sbyte[3] { 1, 2, 5 };
		AddPowerPoisonType = 5;
	}
}
