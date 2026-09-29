using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class MiscHelper
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

		public const ushort Neili = 22;

		public const ushort CricketHealInjuryOdds = 23;

		public const ushort ConsumedFeatureMedals = 24;

		public const ushort MaxUseDistance = 25;

		public const ushort BaseHappinessChange = 26;

		public const ushort MakeItemSubType = 27;

		public const ushort StateBuryAmount = 28;

		public const ushort Consumable = 29;

		public const ushort BaseFavorabilityChange = 30;

		public const ushort GiftLevel = 31;

		public const ushort RequireCombatConfig = 32;

		public const ushort GroupId = 33;

		public const ushort IsSpecial = 34;

		public const ushort AllowRandomCreate = 35;

		public const ushort Inheritable = 36;

		public const ushort BreakBonusEffect = 37;

		public const ushort MerchantLevel = 38;

		public const ushort AllowBrokenLevels = 39;

		public const ushort GenerateType = 40;

		public const ushort FilterType = 41;

		public const ushort ReduceEscapeRate = 42;

		public const ushort CombatUseEffect = 43;

		public const ushort CombatPrepareUseEffect = 44;

		public const ushort GainExp = 45;

		public const ushort CanUseOnPrepareCombat = 46;

		public const ushort UseFrame = 47;

		public const ushort ResourceAmount = 48;

		public const ushort AllowUseInPlayAndTest = 49;

		public const ushort TaskLock = 50;

		public const ushort FiveElementTransfer = 51;

		public const ushort MaxNeili = 52;

		public const ushort CanTriggerCommonEvent = 53;

		public const ushort FunctionDesc = 54;

		public const ushort ResourceMaterialType = 55;

		public const ushort HasGiftEvent = 56;
	}

	public const ushort ArchiveFieldsCount = 5;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 52;

	public const ushort WritableFieldsCount = 5;

	public const ushort ReadonlyFieldsCount = 52;

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
		{ "Neili", 22 },
		{ "CricketHealInjuryOdds", 23 },
		{ "ConsumedFeatureMedals", 24 },
		{ "MaxUseDistance", 25 },
		{ "BaseHappinessChange", 26 },
		{ "MakeItemSubType", 27 },
		{ "StateBuryAmount", 28 },
		{ "Consumable", 29 },
		{ "BaseFavorabilityChange", 30 },
		{ "GiftLevel", 31 },
		{ "RequireCombatConfig", 32 },
		{ "GroupId", 33 },
		{ "IsSpecial", 34 },
		{ "AllowRandomCreate", 35 },
		{ "Inheritable", 36 },
		{ "BreakBonusEffect", 37 },
		{ "MerchantLevel", 38 },
		{ "AllowBrokenLevels", 39 },
		{ "GenerateType", 40 },
		{ "FilterType", 41 },
		{ "ReduceEscapeRate", 42 },
		{ "CombatUseEffect", 43 },
		{ "CombatPrepareUseEffect", 44 },
		{ "GainExp", 45 },
		{ "CanUseOnPrepareCombat", 46 },
		{ "UseFrame", 47 },
		{ "ResourceAmount", 48 },
		{ "AllowUseInPlayAndTest", 49 },
		{ "TaskLock", 50 },
		{ "FiveElementTransfer", 51 },
		{ "MaxNeili", 52 },
		{ "CanTriggerCommonEvent", 53 },
		{ "FunctionDesc", 54 },
		{ "ResourceMaterialType", 55 },
		{ "HasGiftEvent", 56 }
	};

	public static readonly string[] FieldId2FieldName = new string[57]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "Name", "ItemType", "ItemSubType", "Grade", "Icon",
		"Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "DropRate",
		"ResourceType", "PreservationDuration", "Neili", "CricketHealInjuryOdds", "ConsumedFeatureMedals", "MaxUseDistance", "BaseHappinessChange", "MakeItemSubType", "StateBuryAmount", "Consumable",
		"BaseFavorabilityChange", "GiftLevel", "RequireCombatConfig", "GroupId", "IsSpecial", "AllowRandomCreate", "Inheritable", "BreakBonusEffect", "MerchantLevel", "AllowBrokenLevels",
		"GenerateType", "FilterType", "ReduceEscapeRate", "CombatUseEffect", "CombatPrepareUseEffect", "GainExp", "CanUseOnPrepareCombat", "UseFrame", "ResourceAmount", "AllowUseInPlayAndTest",
		"TaskLock", "FiveElementTransfer", "MaxNeili", "CanTriggerCommonEvent", "FunctionDesc", "ResourceMaterialType", "HasGiftEvent"
	};
}
