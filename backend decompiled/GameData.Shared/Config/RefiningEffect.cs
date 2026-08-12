using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RefiningEffect : ConfigData<RefiningEffectItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static RefiningEffect Instance = new RefiningEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "WeaponType", "ArmorType", "AccessoryType" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new RefiningEffectItem(0, ERefiningEffectWeaponType.EquipmentDefense, ERefiningEffectArmorType.EquipmentDefense, ERefiningEffectAccessoryType.HitRateSpeed, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(1, ERefiningEffectWeaponType.HitRateSpeed, ERefiningEffectArmorType.AvoidRateSpeed, ERefiningEffectAccessoryType.AvoidRateSpeed, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(2, ERefiningEffectWeaponType.EquipmentAttack, ERefiningEffectArmorType.EquipmentAttack, ERefiningEffectAccessoryType.HitRateStrength, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(3, ERefiningEffectWeaponType.HitRateStrength, ERefiningEffectArmorType.AvoidRateStrength, ERefiningEffectAccessoryType.AvoidRateStrength, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(4, ERefiningEffectWeaponType.Penetration, ERefiningEffectArmorType.PenetrationResist, ERefiningEffectAccessoryType.HitRateMind, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(5, ERefiningEffectWeaponType.HitRateMind, ERefiningEffectArmorType.AvoidRateMind, ERefiningEffectAccessoryType.AvoidRateMind, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(6, ERefiningEffectWeaponType.Weight, ERefiningEffectArmorType.Weight, ERefiningEffectAccessoryType.HitRateTechnique, new sbyte[7] { -4, -5, -6, -7, -8, -9, -10 }, new sbyte[7] { -4, -5, -6, -7, -8, -9, -10 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(7, ERefiningEffectWeaponType.HitRateTechnique, ERefiningEffectArmorType.AvoidRateTechnique, ERefiningEffectAccessoryType.AvoidRateTechnique, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 2, 3, 4, 5, 6, 7, 8 }, new sbyte[7] { 6, 10, 14, 18, 22, 26, 30 }));
		_dataArray.Add(new RefiningEffectItem(8, ERefiningEffectWeaponType.MinAttackRange, ERefiningEffectArmorType.InjuryFactorInner, ERefiningEffectAccessoryType.Calm, new sbyte[7] { 1, 1, 1, 1, 1, 1, 1 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }));
		_dataArray.Add(new RefiningEffectItem(9, ERefiningEffectWeaponType.MaxDurability, ERefiningEffectArmorType.MaxDurability, ERefiningEffectAccessoryType.Firm, new sbyte[7] { 30, 30, 30, 30, 30, 30, 30 }, new sbyte[7] { 30, 30, 30, 30, 30, 30, 30 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }));
		_dataArray.Add(new RefiningEffectItem(10, ERefiningEffectWeaponType.MaxAttackRange, ERefiningEffectArmorType.InjuryFactorOuter, ERefiningEffectAccessoryType.Brave, new sbyte[7] { 1, 1, 1, 1, 1, 1, 1 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }));
		_dataArray.Add(new RefiningEffectItem(11, ERefiningEffectWeaponType.PursueAttackFactor, ERefiningEffectArmorType.CounterAttackPower, ERefiningEffectAccessoryType.Enthusiastic, new sbyte[7] { 15, 15, 15, 15, 15, 15, 15 }, new sbyte[7] { 15, 15, 15, 15, 15, 15, 15 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }));
		_dataArray.Add(new RefiningEffectItem(12, ERefiningEffectWeaponType.ChangeTrickPercent, ERefiningEffectArmorType.CounterDamagePower, ERefiningEffectAccessoryType.Clever, new sbyte[7] { 15, 15, 15, 15, 15, 15, 15 }, new sbyte[7] { 15, 15, 15, 15, 15, 15, 15 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }));
		_dataArray.Add(new RefiningEffectItem(13, ERefiningEffectWeaponType.MaxPower, ERefiningEffectArmorType.MaxPower, ERefiningEffectAccessoryType.Lucky, new sbyte[7] { 10, 10, 10, 10, 10, 10, 10 }, new sbyte[7] { 10, 10, 10, 10, 10, 10, 10 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }));
		_dataArray.Add(new RefiningEffectItem(14, ERefiningEffectWeaponType.UseRequirement, ERefiningEffectArmorType.UseRequirement, ERefiningEffectAccessoryType.Perceptive, new sbyte[7] { -5, -5, -5, -5, -5, -5, -5 }, new sbyte[7] { -5, -5, -5, -5, -5, -5, -5 }, new sbyte[7] { 3, 3, 3, 3, 3, 3, 3 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<RefiningEffectItem>(15);
		CreateItems0();
	}
}
