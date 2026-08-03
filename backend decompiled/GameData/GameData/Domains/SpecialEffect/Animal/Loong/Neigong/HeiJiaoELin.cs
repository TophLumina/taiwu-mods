using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class HeiJiaoELin : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongWaterImplementPoison(240, 600);
		}
	}

	public HeiJiaoELin()
	{
	}

	public HeiJiaoELin(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
