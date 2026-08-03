using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class CangKongJiYu : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongWoodImplementHeal();
			yield return new LoongWoodImplementRange(1, 2);
		}
	}

	public CangKongJiYu()
	{
	}

	public CangKongJiYu(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
