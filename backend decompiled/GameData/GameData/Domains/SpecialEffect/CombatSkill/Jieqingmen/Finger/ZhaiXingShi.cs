using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class ZhaiXingShi : GetTrick
{
	public ZhaiXingShi()
	{
	}

	public ZhaiXingShi(CombatSkillKey skillKey)
		: base(skillKey, 13101)
	{
		GetTrickType = 7;
		DirectCanChangeTrickType = new sbyte[2] { 6, 8 };
	}
}
