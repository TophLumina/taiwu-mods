using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;

public class XiangLongGunFa : PolearmUnlockEffectBase, IExtraUnlockEffect
{
	private CValuePercent CastAddUnlockPercent => base.IsDirectOrReverseEffectDoubling ? 8 : 4;

	private static CValuePercent UnlockAddUnlockPercent => 15;

	protected override IEnumerable<sbyte> RequireMainAttributeTypes { get; } = new sbyte[1];

	protected override int RequireMainAttributeValue => 75;

	public XiangLongGunFa()
	{
	}

	public XiangLongGunFa(CombatSkillKey skillKey)
		: base(skillKey, 9300)
	{
	}

	protected override void OnCastAddUnlockAttackValue(DataContext context, CValuePercent power)
	{
		base.OnCastAddUnlockAttackValue(context, power);
		if (base.IsReverseOrUsingDirectWeapon)
		{
			base.CombatChar.ChangeAllUnlockAttackValue(context, CastAddUnlockPercent * power);
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}

	protected override void DoAffect(DataContext context, int weaponIndex)
	{
		base.CombatChar.InvokeExtraUnlockEffect(this, weaponIndex);
	}

	public void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		base.CombatChar.ChangeAllUnlockAttackValue(context, UnlockAddUnlockPercent);
		ShowSpecialEffectTips(0);
	}
}
