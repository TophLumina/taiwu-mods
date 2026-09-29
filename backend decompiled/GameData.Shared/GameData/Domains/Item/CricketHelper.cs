using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class CricketHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort MaxDurability = 2;

		public const ushort CurrDurability = 3;

		public const ushort ModificationState = 4;

		public const ushort ColorId = 5;

		public const ushort PartId = 6;

		public const ushort Injuries = 7;

		public const ushort WinsCount = 8;

		public const ushort LossesCount = 9;

		public const ushort BestEnemyColorId = 10;

		public const ushort BestEnemyPartId = 11;

		public const ushort AgeObsolete = 12;

		public const ushort AgeProgress = 13;

		public const ushort Spirit = 14;

		public const ushort SpiritAddProperties = 15;

		public const ushort OriginState = 16;

		public const ushort PolymorphRateFix = 17;

		public const ushort NameId = 18;

		public const ushort Name = 19;

		public const ushort ItemType = 20;

		public const ushort ItemSubType = 21;

		public const ushort Grade = 22;

		public const ushort Icon = 23;

		public const ushort Desc = 24;

		public const ushort Transferable = 25;

		public const ushort Stackable = 26;

		public const ushort Wagerable = 27;

		public const ushort Refinable = 28;

		public const ushort Poisonable = 29;

		public const ushort Repairable = 30;

		public const ushort BaseWeight = 31;

		public const ushort BaseValue = 32;

		public const ushort DropRate = 33;

		public const ushort ResourceType = 34;

		public const ushort PreservationDuration = 35;

		public const ushort GiftLevel = 36;

		public const ushort BaseFavorabilityChange = 37;

		public const ushort BaseHappinessChange = 38;

		public const ushort IsSpecial = 39;

		public const ushort AllowRandomCreate = 40;

		public const ushort Inheritable = 41;

		public const ushort GroupId = 42;

		public const ushort MerchantLevel = 43;

		public const ushort TaskLock = 44;
	}

	public const ushort ArchiveFieldsCount = 19;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 26;

	public const ushort WritableFieldsCount = 19;

	public const ushort ReadonlyFieldsCount = 26;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "MaxDurability", 2 },
		{ "CurrDurability", 3 },
		{ "ModificationState", 4 },
		{ "ColorId", 5 },
		{ "PartId", 6 },
		{ "Injuries", 7 },
		{ "WinsCount", 8 },
		{ "LossesCount", 9 },
		{ "BestEnemyColorId", 10 },
		{ "BestEnemyPartId", 11 },
		{ "AgeObsolete", 12 },
		{ "AgeProgress", 13 },
		{ "Spirit", 14 },
		{ "SpiritAddProperties", 15 },
		{ "OriginState", 16 },
		{ "PolymorphRateFix", 17 },
		{ "NameId", 18 },
		{ "Name", 19 },
		{ "ItemType", 20 },
		{ "ItemSubType", 21 },
		{ "Grade", 22 },
		{ "Icon", 23 },
		{ "Desc", 24 },
		{ "Transferable", 25 },
		{ "Stackable", 26 },
		{ "Wagerable", 27 },
		{ "Refinable", 28 },
		{ "Poisonable", 29 },
		{ "Repairable", 30 },
		{ "BaseWeight", 31 },
		{ "BaseValue", 32 },
		{ "DropRate", 33 },
		{ "ResourceType", 34 },
		{ "PreservationDuration", 35 },
		{ "GiftLevel", 36 },
		{ "BaseFavorabilityChange", 37 },
		{ "BaseHappinessChange", 38 },
		{ "IsSpecial", 39 },
		{ "AllowRandomCreate", 40 },
		{ "Inheritable", 41 },
		{ "GroupId", 42 },
		{ "MerchantLevel", 43 },
		{ "TaskLock", 44 }
	};

	public static readonly string[] FieldId2FieldName = new string[45]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "ColorId", "PartId", "Injuries", "WinsCount", "LossesCount",
		"BestEnemyColorId", "BestEnemyPartId", "AgeObsolete", "AgeProgress", "Spirit", "SpiritAddProperties", "OriginState", "PolymorphRateFix", "NameId", "Name",
		"ItemType", "ItemSubType", "Grade", "Icon", "Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable",
		"Repairable", "BaseWeight", "BaseValue", "DropRate", "ResourceType", "PreservationDuration", "GiftLevel", "BaseFavorabilityChange", "BaseHappinessChange", "IsSpecial",
		"AllowRandomCreate", "Inheritable", "GroupId", "MerchantLevel", "TaskLock"
	};
}
