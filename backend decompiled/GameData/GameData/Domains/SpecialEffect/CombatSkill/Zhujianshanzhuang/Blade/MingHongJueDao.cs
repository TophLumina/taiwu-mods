using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Blade;

public class MingHongJueDao : BladeUnlockEffectBase
{
	private const int AddDirectDamagePercent = 300;

	private bool _affected;

	private CValuePercent MaxStealUnlockValuePercent => base.IsDirectOrReverseEffectDoubling ? 40 : 20;

	protected override IEnumerable<short> RequireWeaponTypes
	{
		get
		{
			yield return 8;
		}
	}

	public MingHongJueDao()
	{
	}

	public MingHongJueDao(CombatSkillKey skillKey)
		: base(skillKey, 9207)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_UnlockAttackEnd(OnUnlockAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_UnlockAttackEnd(OnUnlockAttackEnd);
		base.OnDisable(context);
	}

	protected override void OnCastAddUnlockAttackValue(DataContext context, CValuePercent power)
	{
		base.OnCastAddUnlockAttackValue(context, power);
		if (!base.IsReverseOrUsingDirectWeapon)
		{
			return;
		}
		int usingIndex = base.CombatChar.GetUsingWeaponIndex();
		if (usingIndex >= 3 || base.CombatChar.GetUnlockEffect(usingIndex) == null)
		{
			return;
		}
		List<int> unlockValues = base.CombatChar.GetUnlockPrepareValue();
		int lackUnlockValue = GlobalConfig.Instance.UnlockAttackUnit - unlockValues[usingIndex];
		if (lackUnlockValue == 0)
		{
			return;
		}
		int maxStealValue = GlobalConfig.Instance.UnlockAttackUnit * MaxStealUnlockValuePercent * power;
		if (maxStealValue == 0)
		{
			return;
		}
		int avg = lackUnlockValue / 2;
		List<int> otherWeaponIndexes = ObjectPool<List<int>>.Instance.Get();
		List<int> otherWeaponUnlockValues = ObjectPool<List<int>>.Instance.Get();
		for (int i = 0; i < 3; i++)
		{
			if (i != usingIndex)
			{
				int canStealValue = Math.Min(unlockValues[i], maxStealValue);
				if (canStealValue != 0)
				{
					avg = Math.Min(avg, canStealValue);
					otherWeaponIndexes.Add(i);
					otherWeaponUnlockValues.Add(canStealValue);
				}
			}
		}
		int maxFillValue = Math.Min(maxStealValue * otherWeaponIndexes.Count, lackUnlockValue);
		int rem = maxFillValue - avg * otherWeaponIndexes.Count;
		for (int j = 0; j < otherWeaponIndexes.Count; j++)
		{
			int remFill = Math.Min(otherWeaponUnlockValues[j] - avg, rem);
			rem -= remFill;
			otherWeaponUnlockValues[j] = avg + remFill;
		}
		for (int k = 0; k < otherWeaponIndexes.Count; k++)
		{
			int stealIndex = otherWeaponIndexes[k];
			int stealValue = otherWeaponUnlockValues[k];
			base.CombatChar.ChangeUnlockAttackValue(context, stealIndex, -stealValue);
			base.CombatChar.ChangeUnlockAttackValue(context, base.CombatChar.GetUsingWeaponIndex(), stealValue);
		}
		if (otherWeaponIndexes.Count > 0)
		{
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
		ObjectPool<List<int>>.Instance.Return(otherWeaponIndexes);
		ObjectPool<List<int>>.Instance.Return(otherWeaponUnlockValues);
	}

	public override void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		_affected = true;
		ShowSpecialEffectTips(base.IsDirect, 2, 1);
	}

	private void OnUnlockAttackEnd(DataContext context, CombatCharacter attacker)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_affected = false;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69 || !_affected)
		{
			return 0;
		}
		return 300;
	}
}
