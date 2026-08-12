using System.Collections.Generic;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class YanHuoShenZhu : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongFireImplementWorse(WorsenConstants.SpecialPercentLoongFire);
			yield return new LoongFireImplementBroken();
			yield return new LoongFireImplementBrokenHit();
			yield return new LoongBaseImplementInvincible();
		}
	}

	public YanHuoShenZhu()
	{
	}

	public YanHuoShenZhu(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
