using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class TaiBaoJiuHuaJian : AccumulateNeiliAllocationToStrengthen
{
	public TaiBaoJiuHuaJian()
	{
	}

	public TaiBaoJiuHuaJian(CombatSkillKey skillKey)
		: base(skillKey, 7205)
	{
		RequireNeiliAllocationType = 3;
	}
}
