using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;

public class LianHuaTaiXuanGong : TransferFiveElementsNeili
{
	public LianHuaTaiXuanGong()
	{
	}

	public LianHuaTaiXuanGong(CombatSkillKey skillKey)
		: base(skillKey, 2004)
	{
		SrcFiveElementsType = (sbyte)(base.IsDirect ? 3 : 0);
		DestFiveElementsType = 1;
	}
}
