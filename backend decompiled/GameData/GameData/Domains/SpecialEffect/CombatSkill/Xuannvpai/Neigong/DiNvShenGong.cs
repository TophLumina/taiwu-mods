using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class DiNvShenGong : TransferFiveElementsNeili
{
	public DiNvShenGong()
	{
	}

	public DiNvShenGong(CombatSkillKey skillKey)
		: base(skillKey, 8005)
	{
		SrcFiveElementsType = (sbyte)(base.IsDirect ? 1 : 3);
		DestFiveElementsType = 2;
	}
}
