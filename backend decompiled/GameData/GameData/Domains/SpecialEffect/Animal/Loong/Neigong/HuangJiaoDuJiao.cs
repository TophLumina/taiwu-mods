using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class HuangJiaoDuJiao : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongEarthImplementSilence
			{
				SilenceFrame = 1800
			};
		}
	}

	public HuangJiaoDuJiao()
	{
	}

	public HuangJiaoDuJiao(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
