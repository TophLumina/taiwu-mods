using System.Collections.Generic;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class ChiJiaoHuoJing : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongFireImplementWorse(WorsenConstants.DefaultPercent);
		}
	}

	public ChiJiaoHuoJing()
	{
	}

	public ChiJiaoHuoJing(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
