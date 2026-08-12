using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class ArmorHelper
{
	/// <summary>
	/// 数据字段 ID 集合.
	/// 字段顺序: 档案字段, 缓存字段, 模板字段.
	/// </summary>
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort MaxDurability = 2;

		public const ushort EquipmentEffectId = 3;

		public const ushort CurrDurability = 4;

		public const ushort ModificationState = 5;

		public const ushort EquippedCharId = 6;

		public const ushort MaterialResources = 7;

		public const ushort PenetrationResistFactors = 8;

		public const ushort EquipmentAttack = 9;

		public const ushort EquipmentDefense = 10;

		public const ushort Weight = 11;

		public const ushort InjuryFactor = 12;

		public const ushort EquippedPower = 13;

		public const ushort Name = 14;

		public const ushort ItemType = 15;

		public const ushort ItemSubType = 16;

		public const ushort Grade = 17;

		public const ushort Icon = 18;

		public const ushort Desc = 19;

		public const ushort Transferable = 20;

		public const ushort Stackable = 21;

		public const ushort Wagerable = 22;

		public const ushort Refinable = 23;

		public const ushort Poisonable = 24;

		public const ushort Repairable = 25;

		public const ushort BaseWeight = 26;

		public const ushort BaseValue = 27;

		public const ushort BaseFavorabilityChange = 28;

		public const ushort DropRate = 29;

		public const ushort ResourceType = 30;

		public const ushort PreservationDuration = 31;

		public const ushort EquipmentType = 32;

		public const ushort BaseEquipmentAttack = 33;

		public const ushort BaseEquipmentDefense = 34;

		public const ushort RequiredCharacterProperties = 35;

		public const ushort BaseAvoidFactors = 36;

		public const ushort BasePenetrationResistFactors = 37;

		public const ushort RelatedWeapon = 38;

		public const ushort SkeletonSlotAndAttachment = 39;

		public const ushort MakeItemSubType = 40;

		public const ushort GiftLevel = 41;

		public const ushort BaseHappinessChange = 42;

		public const ushort Detachable = 43;

		public const ushort BaseInjuryFactors = 44;

		public const ushort IsSpecial = 45;

		public const ushort AllowRandomCreate = 46;

		public const ushort MerchantLevel = 47;

		public const ushort GroupId = 48;

		public const ushort AllowCrippledCreate = 49;

		public const ushort Inheritable = 50;

		public const ushort AllowRawCreate = 51;

		public const ushort EquipmentCombatPowerValueFactor = 52;

		public const ushort TaskLock = 53;

		public const ushort EquipmentMasteryId = 54;

		public const ushort FunctionDesc = 55;
	}

	/// <summary>
	/// 档案数据字段数 (可能也是模板数据)
	/// </summary>
	public const ushort ArchiveFieldsCount = 8;

	/// <summary>
	/// 缓存数据字段数
	/// </summary>
	public const ushort CacheFieldsCount = 6;

	/// <summary>
	/// 纯模板数据字段数 (不同时是档案数据)
	/// </summary>
	public const ushort PureTemplateFieldsCount = 42;

	/// <summary>
	/// 可变数据字段数 (档案字段数与缓存字段数之和)
	/// </summary>
	public const ushort WritableFieldsCount = 14;

	/// <summary>
	/// 只读数据字段数 (模板字段数)
	/// </summary>
	public const ushort ReadonlyFieldsCount = 42;

	/// <summary>
	/// 通过字段名获取字段 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "MaxDurability", 2 },
		{ "EquipmentEffectId", 3 },
		{ "CurrDurability", 4 },
		{ "ModificationState", 5 },
		{ "EquippedCharId", 6 },
		{ "MaterialResources", 7 },
		{ "PenetrationResistFactors", 8 },
		{ "EquipmentAttack", 9 },
		{ "EquipmentDefense", 10 },
		{ "Weight", 11 },
		{ "InjuryFactor", 12 },
		{ "EquippedPower", 13 },
		{ "Name", 14 },
		{ "ItemType", 15 },
		{ "ItemSubType", 16 },
		{ "Grade", 17 },
		{ "Icon", 18 },
		{ "Desc", 19 },
		{ "Transferable", 20 },
		{ "Stackable", 21 },
		{ "Wagerable", 22 },
		{ "Refinable", 23 },
		{ "Poisonable", 24 },
		{ "Repairable", 25 },
		{ "BaseWeight", 26 },
		{ "BaseValue", 27 },
		{ "BaseFavorabilityChange", 28 },
		{ "DropRate", 29 },
		{ "ResourceType", 30 },
		{ "PreservationDuration", 31 },
		{ "EquipmentType", 32 },
		{ "BaseEquipmentAttack", 33 },
		{ "BaseEquipmentDefense", 34 },
		{ "RequiredCharacterProperties", 35 },
		{ "BaseAvoidFactors", 36 },
		{ "BasePenetrationResistFactors", 37 },
		{ "RelatedWeapon", 38 },
		{ "SkeletonSlotAndAttachment", 39 },
		{ "MakeItemSubType", 40 },
		{ "GiftLevel", 41 },
		{ "BaseHappinessChange", 42 },
		{ "Detachable", 43 },
		{ "BaseInjuryFactors", 44 },
		{ "IsSpecial", 45 },
		{ "AllowRandomCreate", 46 },
		{ "MerchantLevel", 47 },
		{ "GroupId", 48 },
		{ "AllowCrippledCreate", 49 },
		{ "Inheritable", 50 },
		{ "AllowRawCreate", 51 },
		{ "EquipmentCombatPowerValueFactor", 52 },
		{ "TaskLock", 53 },
		{ "EquipmentMasteryId", 54 },
		{ "FunctionDesc", 55 }
	};

	/// <summary>
	/// 通过字段 ID 获取字段名
	/// </summary>
	public static readonly string[] FieldId2FieldName = new string[56]
	{
		"Id", "TemplateId", "MaxDurability", "EquipmentEffectId", "CurrDurability", "ModificationState", "EquippedCharId", "MaterialResources", "PenetrationResistFactors", "EquipmentAttack",
		"EquipmentDefense", "Weight", "InjuryFactor", "EquippedPower", "Name", "ItemType", "ItemSubType", "Grade", "Icon", "Desc",
		"Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "BaseFavorabilityChange", "DropRate",
		"ResourceType", "PreservationDuration", "EquipmentType", "BaseEquipmentAttack", "BaseEquipmentDefense", "RequiredCharacterProperties", "BaseAvoidFactors", "BasePenetrationResistFactors", "RelatedWeapon", "SkeletonSlotAndAttachment",
		"MakeItemSubType", "GiftLevel", "BaseHappinessChange", "Detachable", "BaseInjuryFactors", "IsSpecial", "AllowRandomCreate", "MerchantLevel", "GroupId", "AllowCrippledCreate",
		"Inheritable", "AllowRawCreate", "EquipmentCombatPowerValueFactor", "TaskLock", "EquipmentMasteryId", "FunctionDesc"
	};
}
