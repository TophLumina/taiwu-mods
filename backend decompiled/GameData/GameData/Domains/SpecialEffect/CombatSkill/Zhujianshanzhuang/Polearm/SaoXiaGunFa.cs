using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;

public class SaoXiaGunFa : RawCreateUnlockEffectBase
{
	private CValuePercent ReduceMobilityPercent => base.IsDirectOrReverseEffectDoubling ? (-20) : (-10);

	protected override IEnumerable<sbyte> RequireMainAttributeTypes
	{
		get
		{
			yield return 1;
		}
	}

	protected override int RequireMainAttributeValue => 75;

	public SaoXiaGunFa()
	{
	}

	public SaoXiaGunFa(CombatSkillKey skillKey)
		: base(skillKey, 9301)
	{
	}

	protected override void OnCastAddUnlockAttackValue(DataContext context, CValuePercent power)
	{
		base.OnCastAddUnlockAttackValue(context, power);
		if (base.IsReverseOrUsingDirectWeapon)
		{
			int changeValue = MoveSpecialConstants.MaxMobility * ReduceMobilityPercent * power;
			ChangeMobilityValue(context, base.EnemyChar, changeValue);
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}
}
