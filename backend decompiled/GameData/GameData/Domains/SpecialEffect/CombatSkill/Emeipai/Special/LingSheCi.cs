using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;

public class LingSheCi : PowerUpByMainAttribute
{
	public LingSheCi()
	{
	}

	public LingSheCi(CombatSkillKey skillKey)
		: base(skillKey, 2403)
	{
		RequireMainAttributeType = 1;
	}
}
