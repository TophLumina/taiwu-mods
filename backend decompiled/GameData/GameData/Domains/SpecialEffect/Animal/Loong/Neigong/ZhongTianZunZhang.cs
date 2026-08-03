using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class ZhongTianZunZhang : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongEarthImplementSilenceColorful
			{
				SilenceFrame = 3600
			};
			yield return new LoongBaseImplementInvincible();
		}
	}

	public ZhongTianZunZhang()
	{
	}

	public ZhongTianZunZhang(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
