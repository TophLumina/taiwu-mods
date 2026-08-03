using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class XuanHaiELin : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongWaterImplementPoison(120, 1800);
			yield return new LoongWaterImplementResist();
			yield return new LoongWaterImplementMix();
			yield return new LoongBaseImplementInvincible();
		}
	}

	public XuanHaiELin()
	{
	}

	public XuanHaiELin(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
