using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class LuoTianZhenJueShiErZhuang : TransferFiveElementsNeili
{
	public LuoTianZhenJueShiErZhuang()
	{
	}

	public LuoTianZhenJueShiErZhuang(CombatSkillKey skillKey)
		: base(skillKey, 4003)
	{
		SrcFiveElementsType = (sbyte)(base.IsDirect ? 1 : 2);
		DestFiveElementsType = 3;
	}
}
