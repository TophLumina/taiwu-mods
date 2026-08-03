using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class TaiYiXuanMenJian : PowerUpByMainAttribute
{
	public TaiYiXuanMenJian()
	{
	}

	public TaiYiXuanMenJian(CombatSkillKey skillKey)
		: base(skillKey, 4203)
	{
		RequireMainAttributeType = 4;
	}
}
