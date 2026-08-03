using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class BaiJiaoXiWei : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongMetalImplementJump();
		}
	}

	public BaiJiaoXiWei()
	{
	}

	public BaiJiaoXiWei(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
