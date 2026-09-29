using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class FoodHelper
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

		public const ushort Duration = 22;

		public const ushort ConsumedFeatureMedals = 23;

		public const ushort MainAttributesRegen = 24;

		public const ushort Strength = 25;

		public const ushort Dexterity = 26;

		public const ushort Concentration = 27;

		public const ushort Vitality = 28;

		public const ushort Energy = 29;

		public const ushort Intelligence = 30;

		public const ushort HitRateStrength = 31;

		public const ushort HitRateTechnique = 32;

		public const ushort HitRateSpeed = 33;

		public const ushort HitRateMind = 34;

		public const ushort PenetrateOfOuter = 35;

		public const ushort PenetrateOfInner = 36;

		public const ushort AvoidRateStrength = 37;

		public const ushort AvoidRateTechnique = 38;

		public const ushort AvoidRateSpeed = 39;

		public const ushort AvoidRateMind = 40;

		public const ushort PenetrateResistOfOuter = 41;

		public const ushort PenetrateResistOfInner = 42;

		public const ushort RecoveryOfStance = 43;

		public const ushort RecoveryOfBreath = 44;

		public const ushort MoveSpeed = 45;

		public const ushort RecoveryOfFlaw = 46;

		public const ushort CastSpeed = 47;

		public const ushort RecoveryOfBlockedAcupoint = 48;

		public const ushort WeaponSwitchSpeed = 49;

		public const ushort AttackSpeed = 50;

		public const ushort InnerRatio = 51;

		public const ushort RecoveryOfQiDisorder = 52;

		public const ushort ResistOfHotPoison = 53;

		public const ushort ResistOfGloomyPoison = 54;

		public const ushort ResistOfColdPoison = 55;

		public const ushort ResistOfRedPoison = 56;

		public const ushort ResistOfRottenPoison = 57;

		public const ushort ResistOfIllusoryPoison = 58;

		public const ushort BaseFavorabilityChange = 59;

		public const ushort BaseHappinessChange = 60;

		public const ushort GiftLevel = 61;

		public const ushort Inheritable = 62;

		public const ushort IsSpecial = 63;

		public const ushort MerchantLevel = 64;

		public const ushort AllowRandomCreate = 65;

		public const ushort BreakBonusEffect = 66;

		public const ushort GroupId = 67;

		public const ushort FoodType = 68;

		public const ushort BigIcon = 69;

		public const ushort TaskLock = 70;

		public const ushort FunctionDesc = 71;

		public const ushort MainAttributesRegenMonthly = 72;
	}

	public const ushort ArchiveFieldsCount = 5;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 68;

	public const ushort WritableFieldsCount = 5;

	public const ushort ReadonlyFieldsCount = 68;

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
		{ "Duration", 22 },
		{ "ConsumedFeatureMedals", 23 },
		{ "MainAttributesRegen", 24 },
		{ "Strength", 25 },
		{ "Dexterity", 26 },
		{ "Concentration", 27 },
		{ "Vitality", 28 },
		{ "Energy", 29 },
		{ "Intelligence", 30 },
		{ "HitRateStrength", 31 },
		{ "HitRateTechnique", 32 },
		{ "HitRateSpeed", 33 },
		{ "HitRateMind", 34 },
		{ "PenetrateOfOuter", 35 },
		{ "PenetrateOfInner", 36 },
		{ "AvoidRateStrength", 37 },
		{ "AvoidRateTechnique", 38 },
		{ "AvoidRateSpeed", 39 },
		{ "AvoidRateMind", 40 },
		{ "PenetrateResistOfOuter", 41 },
		{ "PenetrateResistOfInner", 42 },
		{ "RecoveryOfStance", 43 },
		{ "RecoveryOfBreath", 44 },
		{ "MoveSpeed", 45 },
		{ "RecoveryOfFlaw", 46 },
		{ "CastSpeed", 47 },
		{ "RecoveryOfBlockedAcupoint", 48 },
		{ "WeaponSwitchSpeed", 49 },
		{ "AttackSpeed", 50 },
		{ "InnerRatio", 51 },
		{ "RecoveryOfQiDisorder", 52 },
		{ "ResistOfHotPoison", 53 },
		{ "ResistOfGloomyPoison", 54 },
		{ "ResistOfColdPoison", 55 },
		{ "ResistOfRedPoison", 56 },
		{ "ResistOfRottenPoison", 57 },
		{ "ResistOfIllusoryPoison", 58 },
		{ "BaseFavorabilityChange", 59 },
		{ "BaseHappinessChange", 60 },
		{ "GiftLevel", 61 },
		{ "Inheritable", 62 },
		{ "IsSpecial", 63 },
		{ "MerchantLevel", 64 },
		{ "AllowRandomCreate", 65 },
		{ "BreakBonusEffect", 66 },
		{ "GroupId", 67 },
		{ "FoodType", 68 },
		{ "BigIcon", 69 },
		{ "TaskLock", 70 },
		{ "FunctionDesc", 71 },
		{ "MainAttributesRegenMonthly", 72 }
	};

	public static readonly string[] FieldId2FieldName = new string[73]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "Name", "ItemType", "ItemSubType", "Grade", "Icon",
		"Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "DropRate",
		"ResourceType", "PreservationDuration", "Duration", "ConsumedFeatureMedals", "MainAttributesRegen", "Strength", "Dexterity", "Concentration", "Vitality", "Energy",
		"Intelligence", "HitRateStrength", "HitRateTechnique", "HitRateSpeed", "HitRateMind", "PenetrateOfOuter", "PenetrateOfInner", "AvoidRateStrength", "AvoidRateTechnique", "AvoidRateSpeed",
		"AvoidRateMind", "PenetrateResistOfOuter", "PenetrateResistOfInner", "RecoveryOfStance", "RecoveryOfBreath", "MoveSpeed", "RecoveryOfFlaw", "CastSpeed", "RecoveryOfBlockedAcupoint", "WeaponSwitchSpeed",
		"AttackSpeed", "InnerRatio", "RecoveryOfQiDisorder", "ResistOfHotPoison", "ResistOfGloomyPoison", "ResistOfColdPoison", "ResistOfRedPoison", "ResistOfRottenPoison", "ResistOfIllusoryPoison", "BaseFavorabilityChange",
		"BaseHappinessChange", "GiftLevel", "Inheritable", "IsSpecial", "MerchantLevel", "AllowRandomCreate", "BreakBonusEffect", "GroupId", "FoodType", "BigIcon",
		"TaskLock", "FunctionDesc", "MainAttributesRegenMonthly"
	};
}
