using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class QingJiaoTieJi : LoongBase
{
	protected override IEnumerable<ISpecialEffectImplement> Implements
	{
		get
		{
			yield return new LoongWoodImplementHeal();
		}
	}

	public QingJiaoTieJi()
	{
	}

	public QingJiaoTieJi(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}
}
