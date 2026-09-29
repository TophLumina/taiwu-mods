using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class MaterialHelper
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

		public const ushort RefiningEffect = 22;

		public const ushort ResourceAmount = 23;

		public const ushort RequiredLifeSkillType = 24;

		public const ushort RequiredAttainment = 25;

		public const ushort RequiredResourceAmount = 26;

		public const ushort CraftableItemTypes = 27;

		public const ushort InnatePoisons = 28;

		public const ushort BaseHappinessChange = 29;

		public const ushort GiftLevel = 30;

		public const ushort BaseFavorabilityChange = 31;

		public const ushort PenetrateResistOfInner = 32;

		public const ushort AvoidRateMind = 33;

		public const ushort PenetrateResistOfOuter = 34;

		public const ushort AvoidRateSpeed = 35;

		public const ushort RecoveryOfBreath = 36;

		public const ushort MoveSpeed = 37;

		public const ushort RecoveryOfFlaw = 38;

		public const ushort CastSpeed = 39;

		public const ushort RecoveryOfBlockedAcupoint = 40;

		public const ushort RecoveryOfStance = 41;

		public const ushort AvoidRateTechnique = 42;

		public const ushort GroupId = 43;

		public const ushort AttackSpeed = 44;

		public const ushort InnerRatio = 45;

		public const ushort RecoveryOfQiDisorder = 46;

		public const ushort ResistOfHotPoison = 47;

		public const ushort ResistOfGloomyPoison = 48;

		public const ushort AvoidRateStrength = 49;

		public const ushort ResistOfColdPoison = 50;

		public const ushort ResistOfRedPoison = 51;

		public const ushort ResistOfRottenPoison = 52;

		public const ushort ResistOfIllusoryPoison = 53;

		public const ushort ConsumedFeatureMedals = 54;

		public const ushort WeaponSwitchSpeed = 55;

		public const ushort PenetrateOfInner = 56;

		public const ushort PrimaryEffectValue = 57;

		public const ushort HitRateMind = 58;

		public const ushort Inheritable = 59;

		public const ushort MerchantLevel = 60;

		public const ushort AllowRandomCreate = 61;

		public const ushort IsSpecial = 62;

		public const ushort Property = 63;

		public const ushort BreakBonusEffect = 64;

		public const ushort DisassembleResultItemList = 65;

		public const ushort DisassembleResultCount = 66;

		public const ushort Duration = 67;

		public const ushort BaseMaxHealthDelta = 68;

		public const ushort PrimaryEffectType = 69;

		public const ushort PrimaryEffectThresholdValue = 70;

		public const ushort PrimaryInjuryRecoveryTimes = 71;

		public const ushort PrimaryRecoverAllInjuries = 72;

		public const ushort SecondaryEffectType = 73;

		public const ushort SecondaryEffectSubType = 74;

		public const ushort SecondaryEffectThresholdValue = 75;

		public const ushort SecondaryEffectValue = 76;

		public const ushort SecondaryInjuryRecoveryTimes = 77;

		public const ushort SecondaryRecoverAllInjuries = 78;

		public const ushort HitRateStrength = 79;

		public const ushort HitRateTechnique = 80;

		public const ushort HitRateSpeed = 81;

		public const ushort PenetrateOfOuter = 82;

		public const ushort PrimaryEffectSubType = 83;

		public const ushort FilterType = 84;

		public const ushort FilterHardness = 85;

		public const ushort UseFrame = 86;

		public const ushort TaskLock = 87;

		public const ushort FunctionDesc = 88;
	}

	public const ushort ArchiveFieldsCount = 5;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 84;

	public const ushort WritableFieldsCount = 5;

	public const ushort ReadonlyFieldsCount = 84;

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
		{ "RefiningEffect", 22 },
		{ "ResourceAmount", 23 },
		{ "RequiredLifeSkillType", 24 },
		{ "RequiredAttainment", 25 },
		{ "RequiredResourceAmount", 26 },
		{ "CraftableItemTypes", 27 },
		{ "InnatePoisons", 28 },
		{ "BaseHappinessChange", 29 },
		{ "GiftLevel", 30 },
		{ "BaseFavorabilityChange", 31 },
		{ "PenetrateResistOfInner", 32 },
		{ "AvoidRateMind", 33 },
		{ "PenetrateResistOfOuter", 34 },
		{ "AvoidRateSpeed", 35 },
		{ "RecoveryOfBreath", 36 },
		{ "MoveSpeed", 37 },
		{ "RecoveryOfFlaw", 38 },
		{ "CastSpeed", 39 },
		{ "RecoveryOfBlockedAcupoint", 40 },
		{ "RecoveryOfStance", 41 },
		{ "AvoidRateTechnique", 42 },
		{ "GroupId", 43 },
		{ "AttackSpeed", 44 },
		{ "InnerRatio", 45 },
		{ "RecoveryOfQiDisorder", 46 },
		{ "ResistOfHotPoison", 47 },
		{ "ResistOfGloomyPoison", 48 },
		{ "AvoidRateStrength", 49 },
		{ "ResistOfColdPoison", 50 },
		{ "ResistOfRedPoison", 51 },
		{ "ResistOfRottenPoison", 52 },
		{ "ResistOfIllusoryPoison", 53 },
		{ "ConsumedFeatureMedals", 54 },
		{ "WeaponSwitchSpeed", 55 },
		{ "PenetrateOfInner", 56 },
		{ "PrimaryEffectValue", 57 },
		{ "HitRateMind", 58 },
		{ "Inheritable", 59 },
		{ "MerchantLevel", 60 },
		{ "AllowRandomCreate", 61 },
		{ "IsSpecial", 62 },
		{ "Property", 63 },
		{ "BreakBonusEffect", 64 },
		{ "DisassembleResultItemList", 65 },
		{ "DisassembleResultCount", 66 },
		{ "Duration", 67 },
		{ "BaseMaxHealthDelta", 68 },
		{ "PrimaryEffectType", 69 },
		{ "PrimaryEffectThresholdValue", 70 },
		{ "PrimaryInjuryRecoveryTimes", 71 },
		{ "PrimaryRecoverAllInjuries", 72 },
		{ "SecondaryEffectType", 73 },
		{ "SecondaryEffectSubType", 74 },
		{ "SecondaryEffectThresholdValue", 75 },
		{ "SecondaryEffectValue", 76 },
		{ "SecondaryInjuryRecoveryTimes", 77 },
		{ "SecondaryRecoverAllInjuries", 78 },
		{ "HitRateStrength", 79 },
		{ "HitRateTechnique", 80 },
		{ "HitRateSpeed", 81 },
		{ "PenetrateOfOuter", 82 },
		{ "PrimaryEffectSubType", 83 },
		{ "FilterType", 84 },
		{ "FilterHardness", 85 },
		{ "UseFrame", 86 },
		{ "TaskLock", 87 },
		{ "FunctionDesc", 88 }
	};

	public static readonly string[] FieldId2FieldName = new string[89]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "Name", "ItemType", "ItemSubType", "Grade", "Icon",
		"Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "DropRate",
		"ResourceType", "PreservationDuration", "RefiningEffect", "ResourceAmount", "RequiredLifeSkillType", "RequiredAttainment", "RequiredResourceAmount", "CraftableItemTypes", "InnatePoisons", "BaseHappinessChange",
		"GiftLevel", "BaseFavorabilityChange", "PenetrateResistOfInner", "AvoidRateMind", "PenetrateResistOfOuter", "AvoidRateSpeed", "RecoveryOfBreath", "MoveSpeed", "RecoveryOfFlaw", "CastSpeed",
		"RecoveryOfBlockedAcupoint", "RecoveryOfStance", "AvoidRateTechnique", "GroupId", "AttackSpeed", "InnerRatio", "RecoveryOfQiDisorder", "ResistOfHotPoison", "ResistOfGloomyPoison", "AvoidRateStrength",
		"ResistOfColdPoison", "ResistOfRedPoison", "ResistOfRottenPoison", "ResistOfIllusoryPoison", "ConsumedFeatureMedals", "WeaponSwitchSpeed", "PenetrateOfInner", "PrimaryEffectValue", "HitRateMind", "Inheritable",
		"MerchantLevel", "AllowRandomCreate", "IsSpecial", "Property", "BreakBonusEffect", "DisassembleResultItemList", "DisassembleResultCount", "Duration", "BaseMaxHealthDelta", "PrimaryEffectType",
		"PrimaryEffectThresholdValue", "PrimaryInjuryRecoveryTimes", "PrimaryRecoverAllInjuries", "SecondaryEffectType", "SecondaryEffectSubType", "SecondaryEffectThresholdValue", "SecondaryEffectValue", "SecondaryInjuryRecoveryTimes", "SecondaryRecoverAllInjuries", "HitRateStrength",
		"HitRateTechnique", "HitRateSpeed", "PenetrateOfOuter", "PrimaryEffectSubType", "FilterType", "FilterHardness", "UseFrame", "TaskLock", "FunctionDesc"
	};
}
