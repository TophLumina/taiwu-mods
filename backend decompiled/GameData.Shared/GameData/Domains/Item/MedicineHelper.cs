using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class MedicineHelper
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

		public const ushort InjuryRecoveryTimes = 23;

		public const ushort HitRateStrength = 24;

		public const ushort HitRateTechnique = 25;

		public const ushort HitRateSpeed = 26;

		public const ushort HitRateMind = 27;

		public const ushort PenetrateOfOuter = 28;

		public const ushort PenetrateOfInner = 29;

		public const ushort AvoidRateStrength = 30;

		public const ushort AvoidRateTechnique = 31;

		public const ushort AvoidRateSpeed = 32;

		public const ushort AvoidRateMind = 33;

		public const ushort PenetrateResistOfOuter = 34;

		public const ushort PenetrateResistOfInner = 35;

		public const ushort RecoveryOfStance = 36;

		public const ushort RecoveryOfBreath = 37;

		public const ushort MoveSpeed = 38;

		public const ushort RecoveryOfFlaw = 39;

		public const ushort CastSpeed = 40;

		public const ushort RecoveryOfBlockedAcupoint = 41;

		public const ushort WeaponSwitchSpeed = 42;

		public const ushort AttackSpeed = 43;

		public const ushort InnerRatio = 44;

		public const ushort RecoveryOfQiDisorder = 45;

		public const ushort WugType = 46;

		public const ushort WugGrowthType = 47;

		public const ushort SpecialEffectClass = 48;

		public const ushort ConsumedFeatureMedals = 49;

		public const ushort MaxUseDistance = 50;

		public const ushort SpecialEffectDesc = 51;

		public const ushort BuffAndOtherMedicine = 52;

		public const ushort BaseHappinessChange = 53;

		public const ushort GiftLevel = 54;

		public const ushort SpecialEffectId = 55;

		public const ushort BaseFavorabilityChange = 56;

		public const ushort ResistOfRedPoison = 57;

		public const ushort ResistOfIllusoryPoison = 58;

		public const ushort ResistOfRottenPoison = 59;

		public const ushort ResistOfColdPoison = 60;

		public const ushort ResistOfGloomyPoison = 61;

		public const ushort CanUseMultiple = 62;

		public const ushort BreakBonusEffect = 63;

		public const ushort Inheritable = 64;

		public const ushort MerchantLevel = 65;

		public const ushort AllowRandomCreate = 66;

		public const ushort IsSpecial = 67;

		public const ushort ResistOfHotPoison = 68;

		public const ushort GroupId = 69;

		public const ushort DamageStepBonus = 70;

		public const ushort RequiredMainAttributeValue = 71;

		public const ushort RequiredMainAttributeType = 72;

		public const ushort SideEffectValue = 73;

		public const ushort EffectValue = 74;

		public const ushort EffectThresholdValue = 75;

		public const ushort EffectSubType = 76;

		public const ushort HasNormalEatingEffect = 77;

		public const ushort InstantAffect = 78;

		public const ushort CombatUseEffect = 79;

		public const ushort CombatPrepareUseEffect = 80;

		public const ushort EffectType = 81;

		public const ushort UseFrame = 82;

		public const ushort TaskLock = 83;

		public const ushort IsVirtual = 84;

		public const ushort FunctionDesc = 85;
	}

	public const ushort ArchiveFieldsCount = 5;

	public const ushort CacheFieldsCount = 0;

	public const ushort PureTemplateFieldsCount = 81;

	public const ushort WritableFieldsCount = 5;

	public const ushort ReadonlyFieldsCount = 81;

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
		{ "InjuryRecoveryTimes", 23 },
		{ "HitRateStrength", 24 },
		{ "HitRateTechnique", 25 },
		{ "HitRateSpeed", 26 },
		{ "HitRateMind", 27 },
		{ "PenetrateOfOuter", 28 },
		{ "PenetrateOfInner", 29 },
		{ "AvoidRateStrength", 30 },
		{ "AvoidRateTechnique", 31 },
		{ "AvoidRateSpeed", 32 },
		{ "AvoidRateMind", 33 },
		{ "PenetrateResistOfOuter", 34 },
		{ "PenetrateResistOfInner", 35 },
		{ "RecoveryOfStance", 36 },
		{ "RecoveryOfBreath", 37 },
		{ "MoveSpeed", 38 },
		{ "RecoveryOfFlaw", 39 },
		{ "CastSpeed", 40 },
		{ "RecoveryOfBlockedAcupoint", 41 },
		{ "WeaponSwitchSpeed", 42 },
		{ "AttackSpeed", 43 },
		{ "InnerRatio", 44 },
		{ "RecoveryOfQiDisorder", 45 },
		{ "WugType", 46 },
		{ "WugGrowthType", 47 },
		{ "SpecialEffectClass", 48 },
		{ "ConsumedFeatureMedals", 49 },
		{ "MaxUseDistance", 50 },
		{ "SpecialEffectDesc", 51 },
		{ "BuffAndOtherMedicine", 52 },
		{ "BaseHappinessChange", 53 },
		{ "GiftLevel", 54 },
		{ "SpecialEffectId", 55 },
		{ "BaseFavorabilityChange", 56 },
		{ "ResistOfRedPoison", 57 },
		{ "ResistOfIllusoryPoison", 58 },
		{ "ResistOfRottenPoison", 59 },
		{ "ResistOfColdPoison", 60 },
		{ "ResistOfGloomyPoison", 61 },
		{ "CanUseMultiple", 62 },
		{ "BreakBonusEffect", 63 },
		{ "Inheritable", 64 },
		{ "MerchantLevel", 65 },
		{ "AllowRandomCreate", 66 },
		{ "IsSpecial", 67 },
		{ "ResistOfHotPoison", 68 },
		{ "GroupId", 69 },
		{ "DamageStepBonus", 70 },
		{ "RequiredMainAttributeValue", 71 },
		{ "RequiredMainAttributeType", 72 },
		{ "SideEffectValue", 73 },
		{ "EffectValue", 74 },
		{ "EffectThresholdValue", 75 },
		{ "EffectSubType", 76 },
		{ "HasNormalEatingEffect", 77 },
		{ "InstantAffect", 78 },
		{ "CombatUseEffect", 79 },
		{ "CombatPrepareUseEffect", 80 },
		{ "EffectType", 81 },
		{ "UseFrame", 82 },
		{ "TaskLock", 83 },
		{ "IsVirtual", 84 },
		{ "FunctionDesc", 85 }
	};

	public static readonly string[] FieldId2FieldName = new string[86]
	{
		"Id", "TemplateId", "MaxDurability", "CurrDurability", "ModificationState", "Name", "ItemType", "ItemSubType", "Grade", "Icon",
		"Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "DropRate",
		"ResourceType", "PreservationDuration", "Duration", "InjuryRecoveryTimes", "HitRateStrength", "HitRateTechnique", "HitRateSpeed", "HitRateMind", "PenetrateOfOuter", "PenetrateOfInner",
		"AvoidRateStrength", "AvoidRateTechnique", "AvoidRateSpeed", "AvoidRateMind", "PenetrateResistOfOuter", "PenetrateResistOfInner", "RecoveryOfStance", "RecoveryOfBreath", "MoveSpeed", "RecoveryOfFlaw",
		"CastSpeed", "RecoveryOfBlockedAcupoint", "WeaponSwitchSpeed", "AttackSpeed", "InnerRatio", "RecoveryOfQiDisorder", "WugType", "WugGrowthType", "SpecialEffectClass", "ConsumedFeatureMedals",
		"MaxUseDistance", "SpecialEffectDesc", "BuffAndOtherMedicine", "BaseHappinessChange", "GiftLevel", "SpecialEffectId", "BaseFavorabilityChange", "ResistOfRedPoison", "ResistOfIllusoryPoison", "ResistOfRottenPoison",
		"ResistOfColdPoison", "ResistOfGloomyPoison", "CanUseMultiple", "BreakBonusEffect", "Inheritable", "MerchantLevel", "AllowRandomCreate", "IsSpecial", "ResistOfHotPoison", "GroupId",
		"DamageStepBonus", "RequiredMainAttributeValue", "RequiredMainAttributeType", "SideEffectValue", "EffectValue", "EffectThresholdValue", "EffectSubType", "HasNormalEatingEffect", "InstantAffect", "CombatUseEffect",
		"CombatPrepareUseEffect", "EffectType", "UseFrame", "TaskLock", "IsVirtual", "FunctionDesc"
	};
}
