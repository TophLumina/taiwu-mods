using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;

public class QingXianFa : TransferFiveElementsNeili
{
	public QingXianFa()
	{
	}

	public QingXianFa(CombatSkillKey skillKey)
		: base(skillKey, 12004)
	{
		SrcFiveElementsType = (sbyte)(base.IsDirect ? 2 : 4);
		DestFiveElementsType = 1;
	}
}
