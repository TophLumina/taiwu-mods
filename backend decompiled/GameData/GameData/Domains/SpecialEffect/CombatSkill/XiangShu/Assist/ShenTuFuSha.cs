using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class ShenTuFuSha : AddDamageByFiveElementsType
{
	public ShenTuFuSha()
	{
	}

	public ShenTuFuSha(CombatSkillKey skillKey)
		: base(skillKey, 16407)
	{
		CounteringType = 2;
		CounteredType = 1;
	}
}
