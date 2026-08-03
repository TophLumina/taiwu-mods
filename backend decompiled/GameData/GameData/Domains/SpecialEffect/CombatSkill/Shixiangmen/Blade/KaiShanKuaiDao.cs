using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class KaiShanKuaiDao : GetTrick
{
	public KaiShanKuaiDao()
	{
	}

	public KaiShanKuaiDao(CombatSkillKey skillKey)
		: base(skillKey, 6201)
	{
		GetTrickType = 3;
		DirectCanChangeTrickType = new sbyte[2] { 4, 5 };
	}
}
