using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class AccessoryHelper
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

		public const ushort MaterialResources = 7;

		public const ushort EquippedPower = 8;

		public const ushort Name = 9;

		public const ushort ItemType = 10;

		public const ushort ItemSubType = 11;

		public const ushort Grade = 12;

		public const ushort Icon = 13;

		public const ushort Desc = 14;

		public const ushort Transferable = 15;

		public const ushort Stackable = 16;

		public const ushort Wagerable = 17;

		public const ushort Refinable = 18;

		public const ushort Poisonable = 19;

		public const ushort Repairable = 20;

		public const ushort BaseWeight = 21;

		public const ushort BaseValue = 22;

		public const ushort BaseFavorabilityChange = 23;

		public const ushort DropRate = 24;

		public const ushort ResourceType = 25;

		public const ushort PreservationDuration = 26;

		public const ushort EquipmentType = 27;

		public const ushort DropRateBonus = 28;

		public const ushort MaxInventoryLoadBonus = 29;

		public const ushort Strength = 30;

		public const ushort Dexterity = 31;

		public const ushort Concentration = 32;

		public const ushort Vitality = 33;

		public const ushort Energy = 34;

		public const ushort Intelligence = 35;

		public const ushort HitRateStrength = 36;

		public const ushort HitRateTechnique = 37;

		public const ushort HitRateSpeed = 38;

		public const ushort PenetrateOfOuter = 39;

		public const ushort PenetrateOfInner = 40;

		public const ushort AvoidRateStrength = 41;

		public const ushort AvoidRateTechnique = 42;

		public const ushort AvoidRateSpeed = 43;

		public const ushort PenetrateResistOfOuter = 44;

		public const ushort PenetrateResistOfInner = 45;

		public const ushort RecoveryOfStance = 46;

		public const ushort RecoveryOfBreath = 47;

		public const ushort MoveSpeed = 48;

		public const ushort RecoveryOfFlaw = 49;

		public const ushort CastSpeed = 50;

		public const ushort RecoveryOfBlockedAcupoint = 51;

		public const ushort WeaponSwitchSpeed = 52;

		public const ushort AttackSpeed = 53;

		public const ushort InnerRatio = 54;

		public const ushort RecoveryOfQiDisorder = 55;

		public const ushort ResistOfHotPoison = 56;

		public const ushort ResistOfGloomyPoison = 57;

		public const ushort ResistOfColdPoison = 58;

		public const ushort ResistOfRedPoison = 59;

		public const ushort ResistOfRottenPoison = 60;

		public const ushort ResistOfIllusoryPoison = 61;

		public const ushort BonusCombatSkillSect = 62;

		public const ushort MakeItemSubType = 63;

		public const ushort GiftLevel = 64;

		public const ushort BaseHappinessChange = 65;

		public const ushort Detachable = 66;

		public const ushort GroupId = 67;

		public const ushort IsSpecial = 68;

		public const ushort AllowRawCreate = 69;

		public const ushort AllowRandomCreate = 70;

		public const ushort AvoidRateMind = 71;

		public const ushort CombatSkillAddMaxPower = 72;

		public const ushort MerchantLevel = 73;

		public const ushort Inheritable = 74;

		public const ushort HitRateMind = 75;

		public const ushort EquipmentCombatPowerValueFactor = 76;

		public const ushort BaseCaptureRateBonus = 77;

		public const ushort BaseExploreBonusRate = 78;

		public const ushort TaskLock = 79;

		public const ushort MysteryEffectId = 80;

		public const ushort RequiredCharacterProperties = 81;

		public const ushort FunctionDesc = 82;
	}

	public const ushort ArchiveFieldsCount = 8;

	public const ushort CacheFieldsCount = 1;

	public const ushort PureTemplateFieldsCount = 74;

	public const ushort WritableFieldsCount = 9;

	public const ushort ReadonlyFieldsCount = 74;

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
		{ "EquippedPower", 8 },
		{ "Name", 9 },
		{ "ItemType", 10 },
		{ "ItemSubType", 11 },
		{ "Grade", 12 },
		{ "Icon", 13 },
		{ "Desc", 14 },
		{ "Transferable", 15 },
		{ "Stackable", 16 },
		{ "Wagerable", 17 },
		{ "Refinable", 18 },
		{ "Poisonable", 19 },
		{ "Repairable", 20 },
		{ "BaseWeight", 21 },
		{ "BaseValue", 22 },
		{ "BaseFavorabilityChange", 23 },
		{ "DropRate", 24 },
		{ "ResourceType", 25 },
		{ "PreservationDuration", 26 },
		{ "EquipmentType", 27 },
		{ "DropRateBonus", 28 },
		{ "MaxInventoryLoadBonus", 29 },
		{ "Strength", 30 },
		{ "Dexterity", 31 },
		{ "Concentration", 32 },
		{ "Vitality", 33 },
		{ "Energy", 34 },
		{ "Intelligence", 35 },
		{ "HitRateStrength", 36 },
		{ "HitRateTechnique", 37 },
		{ "HitRateSpeed", 38 },
		{ "PenetrateOfOuter", 39 },
		{ "PenetrateOfInner", 40 },
		{ "AvoidRateStrength", 41 },
		{ "AvoidRateTechnique", 42 },
		{ "AvoidRateSpeed", 43 },
		{ "PenetrateResistOfOuter", 44 },
		{ "PenetrateResistOfInner", 45 },
		{ "RecoveryOfStance", 46 },
		{ "RecoveryOfBreath", 47 },
		{ "MoveSpeed", 48 },
		{ "RecoveryOfFlaw", 49 },
		{ "CastSpeed", 50 },
		{ "RecoveryOfBlockedAcupoint", 51 },
		{ "WeaponSwitchSpeed", 52 },
		{ "AttackSpeed", 53 },
		{ "InnerRatio", 54 },
		{ "RecoveryOfQiDisorder", 55 },
		{ "ResistOfHotPoison", 56 },
		{ "ResistOfGloomyPoison", 57 },
		{ "ResistOfColdPoison", 58 },
		{ "ResistOfRedPoison", 59 },
		{ "ResistOfRottenPoison", 60 },
		{ "ResistOfIllusoryPoison", 61 },
		{ "BonusCombatSkillSect", 62 },
		{ "MakeItemSubType", 63 },
		{ "GiftLevel", 64 },
		{ "BaseHappinessChange", 65 },
		{ "Detachable", 66 },
		{ "GroupId", 67 },
		{ "IsSpecial", 68 },
		{ "AllowRawCreate", 69 },
		{ "AllowRandomCreate", 70 },
		{ "AvoidRateMind", 71 },
		{ "CombatSkillAddMaxPower", 72 },
		{ "MerchantLevel", 73 },
		{ "Inheritable", 74 },
		{ "HitRateMind", 75 },
		{ "EquipmentCombatPowerValueFactor", 76 },
		{ "BaseCaptureRateBonus", 77 },
		{ "BaseExploreBonusRate", 78 },
		{ "TaskLock", 79 },
		{ "MysteryEffectId", 80 },
		{ "RequiredCharacterProperties", 81 },
		{ "FunctionDesc", 82 }
	};

	public static readonly string[] FieldId2FieldName = new string[83]
	{
		"Id", "TemplateId", "MaxDurability", "EquipmentEffectId", "CurrDurability", "ModificationState", "EquippedCharId", "MaterialResources", "EquippedPower", "Name",
		"ItemType", "ItemSubType", "Grade", "Icon", "Desc", "Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable",
		"Repairable", "BaseWeight", "BaseValue", "BaseFavorabilityChange", "DropRate", "ResourceType", "PreservationDuration", "EquipmentType", "DropRateBonus", "MaxInventoryLoadBonus",
		"Strength", "Dexterity", "Concentration", "Vitality", "Energy", "Intelligence", "HitRateStrength", "HitRateTechnique", "HitRateSpeed", "PenetrateOfOuter",
		"PenetrateOfInner", "AvoidRateStrength", "AvoidRateTechnique", "AvoidRateSpeed", "PenetrateResistOfOuter", "PenetrateResistOfInner", "RecoveryOfStance", "RecoveryOfBreath", "MoveSpeed", "RecoveryOfFlaw",
		"CastSpeed", "RecoveryOfBlockedAcupoint", "WeaponSwitchSpeed", "AttackSpeed", "InnerRatio", "RecoveryOfQiDisorder", "ResistOfHotPoison", "ResistOfGloomyPoison", "ResistOfColdPoison", "ResistOfRedPoison",
		"ResistOfRottenPoison", "ResistOfIllusoryPoison", "BonusCombatSkillSect", "MakeItemSubType", "GiftLevel", "BaseHappinessChange", "Detachable", "GroupId", "IsSpecial", "AllowRawCreate",
		"AllowRandomCreate", "AvoidRateMind", "CombatSkillAddMaxPower", "MerchantLevel", "Inheritable", "HitRateMind", "EquipmentCombatPowerValueFactor", "BaseCaptureRateBonus", "BaseExploreBonusRate", "TaskLock",
		"MysteryEffectId", "RequiredCharacterProperties", "FunctionDesc"
	};
}
