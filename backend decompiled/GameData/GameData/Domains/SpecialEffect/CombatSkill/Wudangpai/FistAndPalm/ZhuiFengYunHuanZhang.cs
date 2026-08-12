using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class ZhuiFengYunHuanZhang : GetTrick
{
	public ZhuiFengYunHuanZhang()
	{
	}

	public ZhuiFengYunHuanZhang(CombatSkillKey skillKey)
		: base(skillKey, 4101)
	{
		GetTrickType = 8;
		DirectCanChangeTrickType = new sbyte[2] { 6, 7 };
	}
}
