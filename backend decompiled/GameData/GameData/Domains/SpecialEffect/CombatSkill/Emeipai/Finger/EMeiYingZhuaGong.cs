using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class EMeiYingZhuaGong : ChangePowerByEquipType
{
	public EMeiYingZhuaGong()
	{
	}

	public EMeiYingZhuaGong(CombatSkillKey skillKey)
		: base(skillKey, 2200)
	{
		AffectEquipType = 2;
	}
}
