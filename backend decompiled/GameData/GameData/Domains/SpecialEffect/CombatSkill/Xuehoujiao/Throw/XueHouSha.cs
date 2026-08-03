using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;

public class XueHouSha : StrengthenPoison
{
	public XueHouSha()
	{
	}

	public XueHouSha(CombatSkillKey skillKey)
		: base(skillKey, 15406)
	{
		AffectPoisonType = 3;
	}
}
