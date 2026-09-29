using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class CraftToolHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort MaxDurability = 2;

		public const ushort CurrDurability = 3;

		public const ushort ModificationState = 4;

		public const ushort Name = 5;

		public const ushort ItemType = 6;

		public const ushort ItemSubType = 7;

		public const ushort Grade = 8;

		public const ushort Icon = 9;

		public const ushort Desc = 10;

		public const ushort Transferable = 11;

		public const ushort Stackable = 12;

		public const ushort Wagerable = 13;

		public const ushort Refinable = 14;

		public const ushort Poisonable = 15;

		public const ushort Repairable = 16;

		public const ushort BaseWeight = 17;

		public const ushort BaseValue = 18;

		public const ushort DropRate = 19;

		public const ushort ResourceType = 20;

		public const ushort PreservationDuration = 21;

		public const ushort RequiredLifeSkillTypes = 22;

		public const ushort AttainmentBonus = 23;

		public const ushort GiftLevel = 24;

		public const ushort BaseFavorabilityChange = 25;

		public const ushort BaseHappinessChange = 26;

		public const ushort DurabilityCost = 27;

		public const ushort MerchantLevel = 28;

		public const ushort AllowRandomCreate = 29;

		public const ushort Inheritable = 30;

		public const ushort IsSpecial = 31;

		public const ushort GroupId = 32;

		public const ushort ConsumedFeatureMedals = 33;

		public const ushort TaskLock = 34;

		public const ushort FunctionDesc = 35;
	}

	public const ushort ArchiveFieldsCount = 5;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 31;

	public const ushort WritableFieldsCount = 5;

	public const ushort ReadonlyFieldsCount = 31;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "MaxDurability", 2 },
		{ "CurrDurability", 3 },
		{ "ModificationState", 4 },
		{ "Name", 5 },
		{ "ItemType", 6 },
		{ "ItemSubType", 7 },
		{ "Grade", 8 },
		{ "Icon", 9 },
		{ "Desc", 10 },
		{ "Transferable", 11 },
		{ "Stackable", 12 },
		{ "Wagerable", 13 },
		{ "Refinable", 14 },
		{ "Poisonable", 15 },
		{ "Repairable", 16 },
		{ "BaseWeight", 17 },
		{ "BaseValue", 18 },
		{ "DropRate", 19 },
		{ "ResourceType", 20 },
		{ "PreservationDuration", 21 },
		{ "RequiredLifeSkillTypes", 22 },
		{ "AttainmentBonus", 23 },
		{ "GiftLevel", 24 },
		{ "BaseFavorabilityChange", 25 },
		{ "BaseHappinessChange", 26 },
		{ "DurabilityCost", 27 },
		{ "MerchantLevel", 28 },
		{ "AllowRandomCreate", 29 },
		{ "Inheritable", 30 },
		{ "IsSpecial", 31 },
		{ "GroupId", 32 },
		{ "ConsumedFeatureMedals", 33 },
		{ "TaskLock", 34 },
		{ "FunctionDesc", 35 }
	};

	public static readonly string[] FieldId2FieldName = new string[36]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "Name", "ItemType", "ItemSubType", "Grade", "Icon",
		"Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "DropRate",
		"ResourceType", "PreservationDuration", "RequiredLifeSkillTypes", "AttainmentBonus", "GiftLevel", "BaseFavorabilityChange", "BaseHappinessChange", "DurabilityCost", "MerchantLevel", "AllowRandomCreate",
		"Inheritable", "IsSpecial", "GroupId", "ConsumedFeatureMedals", "TaskLock", "FunctionDesc"
	};
}
