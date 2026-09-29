using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class SkillBookHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort MaxDurability = 2;

		public const ushort CurrDurability = 3;

		public const ushort ModificationState = 4;

		public const ushort PageTypes = 5;

		public const ushort PageIncompleteState = 6;

		public const ushort Name = 7;

		public const ushort ItemType = 8;

		public const ushort ItemSubType = 9;

		public const ushort Grade = 10;

		public const ushort Icon = 11;

		public const ushort Desc = 12;

		public const ushort Transferable = 13;

		public const ushort Stackable = 14;

		public const ushort Wagerable = 15;

		public const ushort Refinable = 16;

		public const ushort Poisonable = 17;

		public const ushort Repairable = 18;

		public const ushort BaseWeight = 19;

		public const ushort BaseValue = 20;

		public const ushort DropRate = 21;

		public const ushort ResourceType = 22;

		public const ushort PreservationDuration = 23;

		public const ushort LifeSkillType = 24;

		public const ushort LifeSkillTemplateId = 25;

		public const ushort CombatSkillType = 26;

		public const ushort CombatSkillTemplateId = 27;

		public const ushort LegacyPoint = 28;

		public const ushort ReferenceBooksWithBonus = 29;

		public const ushort GiftLevel = 30;

		public const ushort BaseFavorabilityChange = 31;

		public const ushort BaseHappinessChange = 32;

		public const ushort AllowRandomCreate = 33;

		public const ushort IsSpecial = 34;

		public const ushort GroupId = 35;

		public const ushort Inheritable = 36;

		public const ushort BreakBonusEffect = 37;

		public const ushort MerchantLevel = 38;

		public const ushort TaskLock = 39;

		public const ushort FunctionDesc = 40;
	}

	public const ushort ArchiveFieldsCount = 7;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 34;

	public const ushort WritableFieldsCount = 7;

	public const ushort ReadonlyFieldsCount = 34;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "MaxDurability", 2 },
		{ "CurrDurability", 3 },
		{ "ModificationState", 4 },
		{ "PageTypes", 5 },
		{ "PageIncompleteState", 6 },
		{ "Name", 7 },
		{ "ItemType", 8 },
		{ "ItemSubType", 9 },
		{ "Grade", 10 },
		{ "Icon", 11 },
		{ "Desc", 12 },
		{ "Transferable", 13 },
		{ "Stackable", 14 },
		{ "Wagerable", 15 },
		{ "Refinable", 16 },
		{ "Poisonable", 17 },
		{ "Repairable", 18 },
		{ "BaseWeight", 19 },
		{ "BaseValue", 20 },
		{ "DropRate", 21 },
		{ "ResourceType", 22 },
		{ "PreservationDuration", 23 },
		{ "LifeSkillType", 24 },
		{ "LifeSkillTemplateId", 25 },
		{ "CombatSkillType", 26 },
		{ "CombatSkillTemplateId", 27 },
		{ "LegacyPoint", 28 },
		{ "ReferenceBooksWithBonus", 29 },
		{ "GiftLevel", 30 },
		{ "BaseFavorabilityChange", 31 },
		{ "BaseHappinessChange", 32 },
		{ "AllowRandomCreate", 33 },
		{ "IsSpecial", 34 },
		{ "GroupId", 35 },
		{ "Inheritable", 36 },
		{ "BreakBonusEffect", 37 },
		{ "MerchantLevel", 38 },
		{ "TaskLock", 39 },
		{ "FunctionDesc", 40 }
	};

	public static readonly string[] FieldId2FieldName = new string[41]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "PageTypes", "PageIncompleteState", "Name", "ItemType", "ItemSubType",
		"Grade", "Icon", "Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight",
		"BaseValue", "DropRate", "ResourceType", "PreservationDuration", "LifeSkillType", "LifeSkillTemplateId", "CombatSkillType", "CombatSkillTemplateId", "LegacyPoint", "ReferenceBooksWithBonus",
		"GiftLevel", "BaseFavorabilityChange", "BaseHappinessChange", "AllowRandomCreate", "IsSpecial", "GroupId", "Inheritable", "BreakBonusEffect", "MerchantLevel", "TaskLock",
		"FunctionDesc"
	};
}
