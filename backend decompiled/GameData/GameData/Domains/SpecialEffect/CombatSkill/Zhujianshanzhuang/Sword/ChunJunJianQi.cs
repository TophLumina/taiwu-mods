using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;

public class ChunJunJianQi : SwordAddFatalEffectBase
{
	protected override IEnumerable<sbyte> RequirePersonalityTypes
	{
		get
		{
			yield return 0;
			yield return 1;
		}
	}

	protected override int RequirePersonalityValue => 40;

	protected override CValueMultiplier FlawOrAcupointCount => base.EnemyChar.GetDefeatMarkCollection().GetTotalAcupointCount();

	public ChunJunJianQi()
	{
	}

	public ChunJunJianQi(CombatSkillKey skillKey)
		: base(skillKey, 9106)
	{
	}
}
