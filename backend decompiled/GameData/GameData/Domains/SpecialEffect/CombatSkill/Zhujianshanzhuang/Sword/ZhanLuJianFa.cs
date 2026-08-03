using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;

public class ZhanLuJianFa : SwordUnlockEffectBase
{
	private const int GiveValueMultiplier = 2;

	private CValuePercent MaxGiveUnlockValuePercent => base.IsDirectOrReverseEffectDoubling ? 50 : 25;

	protected override IEnumerable<sbyte> RequirePersonalityTypes
	{
		get
		{
			yield return 4;
		}
	}

	protected override int RequirePersonalityValue => 50;

	public ZhanLuJianFa()
	{
	}

	public ZhanLuJianFa(CombatSkillKey skillKey)
		: base(skillKey, 9107)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(305, EDataModifyType.Custom, -1);
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
		if (unlockValues[usingIndex] <= 0)
		{
			return;
		}
		int maxGiveValue = GlobalConfig.Instance.UnlockAttackUnit * MaxGiveUnlockValuePercent * power;
		if (maxGiveValue <= 0)
		{
			return;
		}
		maxGiveValue = Math.Min(maxGiveValue, unlockValues[usingIndex]);
		List<int> otherWeaponIndexes = ObjectPool<List<int>>.Instance.Get();
		List<int> otherWeaponRequireValues = ObjectPool<List<int>>.Instance.Get();
		for (int i = 0; i < 3; i++)
		{
			if (i != usingIndex)
			{
				int lackValue = GlobalConfig.Instance.UnlockAttackUnit - unlockValues[i];
				if (lackValue != 0 && base.CombatChar.CanUnlockAttackByConfig(i))
				{
					int requireValue = lackValue / 2 + ((lackValue % 2 > 0) ? 1 : 0);
					requireValue = Math.Min(requireValue, maxGiveValue);
					otherWeaponIndexes.Add(i);
					otherWeaponRequireValues.Add(requireValue);
				}
			}
		}
		if (otherWeaponIndexes.Count > 0)
		{
			int giveIndex = RandomUtils.GetRandomIndex(otherWeaponRequireValues, context.Random);
			int index = otherWeaponIndexes[giveIndex];
			int value = otherWeaponRequireValues[giveIndex];
			base.CombatChar.ChangeUnlockAttackValue(context, index, value * 2);
			base.CombatChar.ChangeUnlockAttackValue(context, usingIndex, -value);
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
		ObjectPool<List<int>>.Instance.Return(otherWeaponIndexes);
		ObjectPool<List<int>>.Instance.Return(otherWeaponRequireValues);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 305 || base.EffectCount <= 0)
		{
			return dataValue;
		}
		ReduceEffectCount();
		ShowSpecialEffectTips(base.IsDirect, 2, 1);
		return true;
	}
}
