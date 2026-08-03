using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;

public class FuChongSha : PoisonDisableAgileOrDefense
{
	public FuChongSha()
	{
	}

	public FuChongSha(CombatSkillKey skillKey)
		: base(skillKey, 15401)
	{
		RequirePoisonType = 4;
	}
}
