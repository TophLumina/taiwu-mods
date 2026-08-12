using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class GuanYueXingHong : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongMetalImplementJump();
			yield return new LoongMetalImplementTeleport();
			yield return new LoongMetalImplementMindMark();
			yield return new LoongBaseImplementInvincible();
		}
	}

	public GuanYueXingHong()
	{
	}

	public GuanYueXingHong(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
