using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;

public class EMeiShiErZhuang : FiveElementsAddPenetrateAndResist
{
	public EMeiShiErZhuang()
	{
	}

	public EMeiShiErZhuang(CombatSkillKey skillKey)
		: base(skillKey, 2001)
	{
		RequireFiveElementsType = 1;
	}
}
