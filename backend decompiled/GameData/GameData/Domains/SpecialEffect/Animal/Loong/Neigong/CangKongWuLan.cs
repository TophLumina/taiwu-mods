using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class CangKongWuLan : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongWoodImplementHeal();
			yield return new LoongWoodImplementRange(1, 4);
			yield return new LoongBaseImplementInvincible();
		}
	}

	public CangKongWuLan()
	{
	}

	public CangKongWuLan(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
