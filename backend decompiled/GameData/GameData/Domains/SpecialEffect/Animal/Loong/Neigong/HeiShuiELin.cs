using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class HeiShuiELin : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongWaterImplementPoison(180, 1200);
			yield return new LoongWaterImplementResist();
		}
	}

	public HeiShuiELin()
	{
	}

	public HeiShuiELin(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
