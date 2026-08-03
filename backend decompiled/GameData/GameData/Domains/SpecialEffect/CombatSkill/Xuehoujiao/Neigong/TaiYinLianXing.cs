using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class TaiYinLianXing : TransferFiveElementsNeili
{
	public TaiYinLianXing()
	{
	}

	public TaiYinLianXing(CombatSkillKey skillKey)
		: base(skillKey, 15004)
	{
		SrcFiveElementsType = (sbyte)(base.IsDirect ? 3 : 2);
		DestFiveElementsType = 4;
	}
}
