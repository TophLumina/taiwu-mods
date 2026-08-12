using System;
using Config.Common;

namespace Config;

[Serializable]
public class RefiningEffectItem : ConfigItem<RefiningEffectItem, sbyte>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 武器效果类型
	/// - 该材料精制在武器上对武器本身属性带来的效果，该效果为B类百分比加成。
	/// </summary>
	public readonly ERefiningEffectWeaponType WeaponType;

	/// <summary>
	/// 护具效果类型
	/// - 该材料精制在护具上对护具本身属性带来的效果，该效果为B类百分比加成。
	/// </summary>
	public readonly ERefiningEffectArmorType ArmorType;

	/// <summary>
	/// 宝物效果类型
	/// - 该材料精制在宝物上对人物属性的加成，该效果为A类直接相加。
	/// </summary>
	public readonly ERefiningEffectAccessoryType AccessoryType;

	/// <summary>
	/// 武器各级效果值
	/// </summary>
	public readonly sbyte[] WeaponBonusValues;

	/// <summary>
	/// 护具各级效果值
	/// </summary>
	public readonly sbyte[] ArmorBonusValues;

	/// <summary>
	/// 宝物各级效果值
	/// </summary>
	public readonly sbyte[] AccessoryBonusValues;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="weaponType">武器效果类型 - 该材料精制在武器上对武器本身属性带来的效果，该效果为B类百分比加成。</param>
	/// <param name="armorType">护具效果类型 - 该材料精制在护具上对护具本身属性带来的效果，该效果为B类百分比加成。</param>
	/// <param name="accessoryType">宝物效果类型 - 该材料精制在宝物上对人物属性的加成，该效果为A类直接相加。</param>
	/// <param name="weaponBonusValues">武器各级效果值</param>
	/// <param name="armorBonusValues">护具各级效果值</param>
	/// <param name="accessoryBonusValues">宝物各级效果值</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override RefiningEffectItem Duplicate(int templateId)
	{
		return new RefiningEffectItem((sbyte)templateId, this);
	}
}
