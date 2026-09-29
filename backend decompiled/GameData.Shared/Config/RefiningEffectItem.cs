using System;
using Config.Common;

namespace Config;

[Serializable]
public class RefiningEffectItem : ConfigItem<RefiningEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly ERefiningEffectWeaponType WeaponType;

	public readonly ERefiningEffectArmorType ArmorType;

	public readonly ERefiningEffectAccessoryType AccessoryType;

	public readonly sbyte[] WeaponBonusValues;

	public readonly sbyte[] ArmorBonusValues;

	public readonly sbyte[] AccessoryBonusValues;

	public RefiningEffectItem(sbyte templateId, ERefiningEffectWeaponType weaponType, ERefiningEffectArmorType armorType, ERefiningEffectAccessoryType accessoryType, sbyte[] weaponBonusValues, sbyte[] armorBonusValues, sbyte[] accessoryBonusValues)
	{
		TemplateId = templateId;
		WeaponType = weaponType;
		ArmorType = armorType;
		AccessoryType = accessoryType;
		WeaponBonusValues = weaponBonusValues;
		ArmorBonusValues = armorBonusValues;
		AccessoryBonusValues = accessoryBonusValues;
	}

	public RefiningEffectItem()
	{
		TemplateId = 0;
		WeaponType = ERefiningEffectWeaponType.HitRateStrength;
		ArmorType = ERefiningEffectArmorType.AvoidRateStrength;
		AccessoryType = ERefiningEffectAccessoryType.HitRateStrength;
		WeaponBonusValues = new sbyte[0];
		ArmorBonusValues = new sbyte[0];
		AccessoryBonusValues = new sbyte[0];
	}

	public RefiningEffectItem(sbyte templateId, RefiningEffectItem other)
	{
		TemplateId = templateId;
		WeaponType = other.WeaponType;
		ArmorType = other.ArmorType;
		AccessoryType = other.AccessoryType;
		WeaponBonusValues = other.WeaponBonusValues;
		ArmorBonusValues = other.ArmorBonusValues;
		AccessoryBonusValues = other.AccessoryBonusValues;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override RefiningEffectItem Duplicate(int templateId)
	{
		return new RefiningEffectItem((sbyte)templateId, this);
	}
}
