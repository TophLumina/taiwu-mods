using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Throw;

public class LeiHuoDa : GetTrick
{
	public LeiHuoDa()
	{
	}

	public LeiHuoDa(CombatSkillKey skillKey)
		: base(skillKey, 14301)
	{
		GetTrickType = 0;
		DirectCanChangeTrickType = new sbyte[2] { 1, 2 };
	}
}
