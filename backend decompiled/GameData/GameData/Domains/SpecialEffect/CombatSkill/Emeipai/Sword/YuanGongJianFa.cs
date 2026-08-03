using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Sword;

public class YuanGongJianFa : GetTrick
{
	public YuanGongJianFa()
	{
	}

	public YuanGongJianFa(CombatSkillKey skillKey)
		: base(skillKey, 2301)
	{
		GetTrickType = 4;
		DirectCanChangeTrickType = new sbyte[2] { 3, 5 };
	}
}
