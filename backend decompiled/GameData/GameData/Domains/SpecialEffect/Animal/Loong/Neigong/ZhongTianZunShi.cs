using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class ZhongTianZunShi : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongEarthImplementSilencePower
			{
				SilenceFrame = 2700
			};
		}
	}

	public ZhongTianZunShi()
	{
	}

	public ZhongTianZunShi(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
