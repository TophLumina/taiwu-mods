using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.FistAndPalm;

public class ShiErShouLanChanSiQuan : GameData.Domains.SpecialEffect.CombatSkill.Common.Attack.AttackHitType
{
	public ShiErShouLanChanSiQuan()
	{
	}

	public ShiErShouLanChanSiQuan(CombatSkillKey skillKey)
		: base(skillKey, 2102)
	{
		AffectHitType = 2;
	}
}
