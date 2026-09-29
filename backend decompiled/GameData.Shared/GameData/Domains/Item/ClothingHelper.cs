using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class ClothingHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort MaxDurability = 2;

		public const ushort EquipmentEffectId = 3;

		public const ushort CurrDurability = 4;

		public const ushort ModificationState = 5;

		public const ushort EquippedCharId = 6;

		public const ushort Gender = 7;

		public const ushort MaterialResources = 8;

		public const ushort EquippedPower = 9;

		public const ushort Name = 10;

		public const ushort ItemType = 11;

		public const ushort ItemSubType = 12;

		public const ushort Grade = 13;

		public const ushort Icon = 14;

		public const ushort Desc = 15;

		public const ushort Transferable = 16;

		public const ushort Stackable = 17;

		public const ushort Wagerable = 18;

		public const ushort Refinable = 19;

		public const ushort Poisonable = 20;

		public const ushort Repairable = 21;

		public const ushort BaseWeight = 22;

		public const ushort BaseValue = 23;

		public const ushort DropRate = 24;

		public const ushort ResourceType = 25;

		public const ushort PreservationDuration = 26;

		public const ushort EquipmentType = 27;

		public const ushort DisplayId = 28;

		public const ushort AgeGroup = 29;

		public const ushort KeepOnPassing = 30;

		public const ushort MakeItemSubType = 31;

		public const ushort GiftLevel = 32;

		public const ushort BaseFavorabilityChange = 33;

		public const ushort BaseHappinessChange = 34;

		public const ushort Detachable = 35;

		public const ushort AllowRandomCreate = 36;

		public const ushort WeaveNeedAttainment = 37;

		public const ushort WeaveType = 38;

		public const ushort DlcName = 39;

		public const ushort SmallVillageDesc = 40;

		public const ushort MerchantLevel = 41;

		public const ushort Inheritable = 42;

		public const ushort GroupId = 43;

		public const ushort IsSpecial = 44;

		public const ushort EquipmentCombatPowerValueFactor = 45;

		public const ushort TaskLock = 46;

		public const ushort FunctionDesc = 47;
	}

	public const ushort ArchiveFieldsCount = 9;

	public const ushort CacheFieldsCount = 1;

	public const ushort PureTemplateFieldsCount = 38;

	public const ushort WritableFieldsCount = 10;

	public const ushort ReadonlyFieldsCount = 38;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "MaxDurability", 2 },
		{ "EquipmentEffectId", 3 },
		{ "CurrDurability", 4 },
		{ "ModificationState", 5 },
		{ "EquippedCharId", 6 },
		{ "Gender", 7 },
		{ "MaterialResources", 8 },
		{ "EquippedPower", 9 },
		{ "Name", 10 },
		{ "ItemType", 11 },
		{ "ItemSubType", 12 },
		{ "Grade", 13 },
		{ "Icon", 14 },
		{ "Desc", 15 },
		{ "Transferable", 16 },
		{ "Stackable", 17 },
		{ "Wagerable", 18 },
		{ "Refinable", 19 },
		{ "Poisonable", 20 },
		{ "Repairable", 21 },
		{ "BaseWeight", 22 },
		{ "BaseValue", 23 },
		{ "DropRate", 24 },
		{ "ResourceType", 25 },
		{ "PreservationDuration", 26 },
		{ "EquipmentType", 27 },
		{ "DisplayId", 28 },
		{ "AgeGroup", 29 },
		{ "KeepOnPassing", 30 },
		{ "MakeItemSubType", 31 },
		{ "GiftLevel", 32 },
		{ "BaseFavorabilityChange", 33 },
		{ "BaseHappinessChange", 34 },
		{ "Detachable", 35 },
		{ "AllowRandomCreate", 36 },
		{ "WeaveNeedAttainment", 37 },
		{ "WeaveType", 38 },
		{ "DlcName", 39 },
		{ "SmallVillageDesc", 40 },
		{ "MerchantLevel", 41 },
		{ "Inheritable", 42 },
		{ "GroupId", 43 },
		{ "IsSpecial", 44 },
		{ "EquipmentCombatPowerValueFactor", 45 },
		{ "TaskLock", 46 },
		{ "FunctionDesc", 47 }
	};

	public static readonly string[] FieldId2FieldName = new string[48]
	{
		"Id", "TemplateId", "MaxDurability", "EquipmentEffectId", "CurrDurability", "ModificationState", "EquippedCharId", "Gender", "MaterialResources", "EquippedPower",
		"Name", "ItemType", "ItemSubType", "Grade", "Icon", "Desc", "Transferable", "Stackable", "Wagerable", "Refinable",
		"Poisonable", "Repairable", "BaseWeight", "BaseValue", "DropRate", "ResourceType", "PreservationDuration", "EquipmentType", "DisplayId", "AgeGroup",
		"KeepOnPassing", "MakeItemSubType", "GiftLevel", "BaseFavorabilityChange", "BaseHappinessChange", "Detachable", "AllowRandomCreate", "WeaveNeedAttainment", "WeaveType", "DlcName",
		"SmallVillageDesc", "MerchantLevel", "Inheritable", "GroupId", "IsSpecial", "EquipmentCombatPowerValueFactor", "TaskLock", "FunctionDesc"
	};
}
