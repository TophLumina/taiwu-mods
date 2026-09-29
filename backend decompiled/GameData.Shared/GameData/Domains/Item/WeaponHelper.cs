using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class WeaponHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort MaxDurability = 2;

		public const ushort EquipmentEffectId = 3;

		public const ushort Tricks = 4;

		public const ushort CurrDurability = 5;

		public const ushort ModificationState = 6;

		public const ushort EquippedCharId = 7;

		public const ushort MaterialResources = 8;

		public const ushort PenetrationFactor = 9;

		public const ushort EquipmentAttack = 10;

		public const ushort EquipmentDefense = 11;

		public const ushort Weight = 12;

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

		public const ushort InnatePoisons = 35;

		public const ushort RequiredCharacterProperties = 36;

		public const ushort WeaponAction = 37;

		public const ushort CombatPictureR = 38;

		public const ushort CombatPictureL = 39;

		public const ushort HitSounds = 40;

		public const ushort SwingSoundsSuffix = 41;

		public const ushort PlayArmorHitSound = 42;

		public const ushort TrickDistanceAdjusts = 43;

		public const ushort RandomTrick = 44;

		public const ushort CanChangeTrick = 45;

		public const ushort PursueAttackFactor = 46;

		public const ushort AttackPreparePointCost = 47;

		public const ushort MinDistance = 48;

		public const ushort MaxDistance = 49;

		public const ushort BaseHitFactors = 50;

		public const ushort BasePenetrationFactor = 51;

		public const ushort StanceIncrement = 52;

		public const ushort DefaultInnerRatio = 53;

		public const ushort InnerRatioAdjustRange = 54;

		public const ushort BlockParticles = 55;

		public const ushort BaseHappinessChange = 56;

		public const ushort GiftLevel = 57;

		public const ushort MakeItemSubType = 58;

		public const ushort IdleAni = 59;

		public const ushort ForwardAni = 60;

		public const ushort BackwardAni = 61;

		public const ushort FastBackwardAni = 62;

		public const ushort AvoidAnis = 63;

		public const ushort HittedAnis = 64;

		public const ushort FatalParticle = 65;

		public const ushort TeammateCmdAniPostfix = 66;

		public const ushort BlockAnis = 67;

		public const ushort BlockSounds = 68;

		public const ushort ChangeTrickPercent = 69;

		public const ushort FastForwardAni = 70;

		public const ushort Detachable = 71;

		public const ushort UnlockEffect = 72;

		public const ushort IsSpecial = 73;

		public const ushort AllowRawCreate = 74;

		public const ushort GroupId = 75;

		public const ushort AllowRandomCreate = 76;

		public const ushort MerchantLevel = 77;

		public const ushort Inheritable = 78;

		public const ushort AllowCrippledCreate = 79;

		public const ushort EquipmentCombatPowerValueFactor = 80;

		public const ushort BaseStartupFrames = 81;

		public const ushort BaseRecoveryFrames = 82;

		public const ushort TaskLock = 83;

		public const ushort EquipmentMasteryId = 84;

		public const ushort FunctionDesc = 85;
	}

	public const ushort ArchiveFieldsCount = 9;

	public const ushort CacheFieldsCount = 5;

	public const ushort PureTemplateFieldsCount = 72;

	public const ushort WritableFieldsCount = 14;

	public const ushort ReadonlyFieldsCount = 72;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "TemplateId", 1 },
		{ "MaxDurability", 2 },
		{ "EquipmentEffectId", 3 },
		{ "Tricks", 4 },
		{ "CurrDurability", 5 },
		{ "ModificationState", 6 },
		{ "EquippedCharId", 7 },
		{ "MaterialResources", 8 },
		{ "PenetrationFactor", 9 },
		{ "EquipmentAttack", 10 },
		{ "EquipmentDefense", 11 },
		{ "Weight", 12 },
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
		{ "InnatePoisons", 35 },
		{ "RequiredCharacterProperties", 36 },
		{ "WeaponAction", 37 },
		{ "CombatPictureR", 38 },
		{ "CombatPictureL", 39 },
		{ "HitSounds", 40 },
		{ "SwingSoundsSuffix", 41 },
		{ "PlayArmorHitSound", 42 },
		{ "TrickDistanceAdjusts", 43 },
		{ "RandomTrick", 44 },
		{ "CanChangeTrick", 45 },
		{ "PursueAttackFactor", 46 },
		{ "AttackPreparePointCost", 47 },
		{ "MinDistance", 48 },
		{ "MaxDistance", 49 },
		{ "BaseHitFactors", 50 },
		{ "BasePenetrationFactor", 51 },
		{ "StanceIncrement", 52 },
		{ "DefaultInnerRatio", 53 },
		{ "InnerRatioAdjustRange", 54 },
		{ "BlockParticles", 55 },
		{ "BaseHappinessChange", 56 },
		{ "GiftLevel", 57 },
		{ "MakeItemSubType", 58 },
		{ "IdleAni", 59 },
		{ "ForwardAni", 60 },
		{ "BackwardAni", 61 },
		{ "FastBackwardAni", 62 },
		{ "AvoidAnis", 63 },
		{ "HittedAnis", 64 },
		{ "FatalParticle", 65 },
		{ "TeammateCmdAniPostfix", 66 },
		{ "BlockAnis", 67 },
		{ "BlockSounds", 68 },
		{ "ChangeTrickPercent", 69 },
		{ "FastForwardAni", 70 },
		{ "Detachable", 71 },
		{ "UnlockEffect", 72 },
		{ "IsSpecial", 73 },
		{ "AllowRawCreate", 74 },
		{ "GroupId", 75 },
		{ "AllowRandomCreate", 76 },
		{ "MerchantLevel", 77 },
		{ "Inheritable", 78 },
		{ "AllowCrippledCreate", 79 },
		{ "EquipmentCombatPowerValueFactor", 80 },
		{ "BaseStartupFrames", 81 },
		{ "BaseRecoveryFrames", 82 },
		{ "TaskLock", 83 },
		{ "EquipmentMasteryId", 84 },
		{ "FunctionDesc", 85 }
	};

	public static readonly string[] FieldId2FieldName = new string[86]
	{
		"Id", "TemplateId", "MaxDurability", "EquipmentEffectId", "Tricks", "CurrDurability", "ModificationState", "EquippedCharId", "MaterialResources", "PenetrationFactor",
		"EquipmentAttack", "EquipmentDefense", "Weight", "EquippedPower", "Name", "ItemType", "ItemSubType", "Grade", "Icon", "Desc",
		"Transferable", "Stackable", "Wagerable", "Refinable", "Poisonable", "Repairable", "BaseWeight", "BaseValue", "BaseFavorabilityChange", "DropRate",
		"ResourceType", "PreservationDuration", "EquipmentType", "BaseEquipmentAttack", "BaseEquipmentDefense", "InnatePoisons", "RequiredCharacterProperties", "WeaponAction", "CombatPictureR", "CombatPictureL",
		"HitSounds", "SwingSoundsSuffix", "PlayArmorHitSound", "TrickDistanceAdjusts", "RandomTrick", "CanChangeTrick", "PursueAttackFactor", "AttackPreparePointCost", "MinDistance", "MaxDistance",
		"BaseHitFactors", "BasePenetrationFactor", "StanceIncrement", "DefaultInnerRatio", "InnerRatioAdjustRange", "BlockParticles", "BaseHappinessChange", "GiftLevel", "MakeItemSubType", "IdleAni",
		"ForwardAni", "BackwardAni", "FastBackwardAni", "AvoidAnis", "HittedAnis", "FatalParticle", "TeammateCmdAniPostfix", "BlockAnis", "BlockSounds", "ChangeTrickPercent",
		"FastForwardAni", "Detachable", "UnlockEffect", "IsSpecial", "AllowRawCreate", "GroupId", "AllowRandomCreate", "MerchantLevel", "Inheritable", "AllowCrippledCreate",
		"EquipmentCombatPowerValueFactor", "BaseStartupFrames", "BaseRecoveryFrames", "TaskLock", "EquipmentMasteryId", "FunctionDesc"
	};
}
