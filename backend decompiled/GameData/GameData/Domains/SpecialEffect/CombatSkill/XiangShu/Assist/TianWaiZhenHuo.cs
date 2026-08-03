using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class TianWaiZhenHuo : AddDamageByFiveElementsType
{
	public TianWaiZhenHuo()
	{
	}

	public TianWaiZhenHuo(CombatSkillKey skillKey)
		: base(skillKey, 16403)
	{
		CounteringType = 0;
		CounteredType = 2;
	}
}
