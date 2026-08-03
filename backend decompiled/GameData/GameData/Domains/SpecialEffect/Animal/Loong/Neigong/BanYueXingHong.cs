using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class BanYueXingHong : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongMetalImplementJump();
			yield return new LoongMetalImplementTeleport();
		}
	}

	public BanYueXingHong()
	{
	}

	public BanYueXingHong(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
