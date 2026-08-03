using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class ZhaiYeFeiHuaShu : GetTrick
{
	public ZhaiYeFeiHuaShu()
	{
	}

	public ZhaiYeFeiHuaShu(CombatSkillKey skillKey)
		: base(skillKey, 13301)
	{
		GetTrickType = 1;
		DirectCanChangeTrickType = new sbyte[2] { 0, 2 };
	}
}
