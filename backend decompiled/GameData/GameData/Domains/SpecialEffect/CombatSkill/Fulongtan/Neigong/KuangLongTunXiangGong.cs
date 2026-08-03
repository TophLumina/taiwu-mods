using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class KuangLongTunXiangGong : TransferFiveElementsNeili
{
	public KuangLongTunXiangGong()
	{
	}

	public KuangLongTunXiangGong(CombatSkillKey skillKey)
		: base(skillKey, 14004)
	{
		SrcFiveElementsType = (sbyte)(base.IsDirect ? 4 : 0);
		DestFiveElementsType = 3;
	}
}
