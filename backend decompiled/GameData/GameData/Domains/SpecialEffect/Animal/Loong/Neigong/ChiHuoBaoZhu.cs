using System.Collections.Generic;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class ChiHuoBaoZhu : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongFireImplementWorse(WorsenConstants.HighPercent);
			yield return new LoongFireImplementBroken();
		}
	}

	public ChiHuoBaoZhu()
	{
	}

	public ChiHuoBaoZhu(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
