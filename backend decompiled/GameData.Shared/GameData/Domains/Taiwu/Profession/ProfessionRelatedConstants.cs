using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using Redzen.Random;

namespace GameData.Domains.Taiwu.Profession;

public static class ProfessionRelatedConstants
{
	public static class SettlementType
	{
		public const sbyte Invalid = -1;

		public const sbyte Village = 0;

		public const sbyte WalledTown = 1;

		public const sbyte Town = 2;

		public const sbyte SectCity = 3;
	}

	public const int MaxSeniority = 3000000;

	public const int MaxExtraSeniority = 1500000;

	public static readonly int[] MaxSeniorityAttainmentThresholds = new int[4] { 0, 100, 220, 380 };

	public const int MinSeniority = 0;

	public const int SeniorityGainPerMonth = 20;

	[Obsolete("现在需要看具体的职业技能配置")]
	public static readonly int[] SkillUnlockSeniority = new int[4] { 150000, 600000, 1500000, 3000000 };

	[Obsolete]
	public const int CompatibleProfessionCooldown = 3;

	[Obsolete]
	public const int ProfessionCooldown = 6;

	[Obsolete]
	public const int ConflictingProfessionCooldown = 12;

	public const int SavageSaveResourceRange = 1;

	public const int SavageAddEffectRange = 1;

	public const int CapitalistTradePriceFactor = 500;

	public const int CapitalistAddMerchantFavorFactor = 3;

	public const int CraftRefineEffectFactor = 150;

	public const int TravelerPalaceMaxCount = 3;

	public const int TravelerPalaceTeleportCostActionPoint = 10;

	public const int TravelerPalaceMakePoisonCount = 3;

	public static readonly sbyte[] TempleCountToSkillGrade = new sbyte[16]
	{
		-1, 0, 0, 1, 1, 2, 2, 3, 3, 4,
		4, 5, 5, 6, 7, 8
	};

	public static readonly sbyte[] TaoistMonkSkill2GetSecretSignCount = new sbyte[19]
	{
		1, 1, 1, 1, 2, 2, 3, 3, 4, 4,
		5, 6, 7, 8, 10, 12, 14, 16, 19
	};

	public static readonly sbyte[] TaoistMonkSkill2GetSecretSignCountBySave = GlobalConfig.FuyuFaithCountBySaveInfected;

	public static readonly int[] BehaviorTypeScore = new int[5] { 1, 2, 0, -2, -1 };

	public static readonly int TravelingTaoistMonkSkill2FavorValue = 3000;

	public static readonly int[] BehaviorTypeBecomeEnemyProb = new int[5] { 5, 0, 10, 20, 15 };

	public const sbyte RequiredTianJieFuLuAmount = 99;

	public const sbyte TribulationCount = 4;

	public const sbyte TribulationFuLuCount = 3;

	public const int TreatOthersFavorabilityChange = 6000;

	public const int MonkEatForbiddenFoodPunishment = 300000;

	public const int MonkHaveSexPunishment = 900000;

	public const int BonusSeniorityAttainmentFactor = 3;

	public const int BonusSeniorityAttainmentBase = 100;

	public static readonly CValuePercent BeggarMoneyMaxPercent = 33;

	public static readonly short[] BeggarMoneyBehaviorTypeFactors = new short[5] { 100, 200, 150, 50, 25 };

	public static readonly short[] BeggarSkill2BehaviorTypeFactors = new short[5] { 35, 80, 65, 20, 50 };

	public const int MartialArtistRequiredSafety = 25;

	public const sbyte RemoveEnemyRelationHappinessChange = 20;

	public const sbyte VillagerLearnSectSkillInterval = 3;

	public const sbyte BuddhistMonkSkill3NeedSaveSoulCount = 100;

	public const int HunterGetAnimalRange = 2;

	public const int BeggarUltimateBuffPercent = 50;

	public const int CivilianUltimateBuffPercent = 50;

	public static sbyte[] AristocratGradeRange = new sbyte[2] { 3, 5 };

	public const int DoctorMakeMedicineCostMedicineAmount = 3;

	public const int DoctorMakeMedicineProduceMedicineAmount = 1;

	public static short[] MartialArtistHereticTemplateIds = new short[9] { 310, 330, 335, 340, 345, 350, 355, 360, 365 };

	public const int XiangshuSkill2MaxMinionCount = 20;

	public static readonly (int Percent, int RatioPercent)[] XiangshuSkill2MinionCountRules = new(int, int)[3]
	{
		(50, 50),
		(75, 75),
		(100, 100)
	};

	public static readonly (int Percent, int MinIndex, int MaxIndex)[] XiangshuSkill2MinionTemplateTierRules = new(int, int, int)[3]
	{
		(50, 0, 2),
		(65, 3, 5),
		(80, 6, 8)
	};

	public const int XiangshuSkill1HappinessChange = -30;

	public static readonly (int Percent, int Grade)[] XiangshuSkill0MaxAffectedGradeRules = new(int, int)[9]
	{
		(5, 0),
		(10, 1),
		(20, 2),
		(30, 3),
		(40, 4),
		(50, 5),
		(65, 6),
		(80, 7),
		(100, 8)
	};

	public static readonly IReadOnlyList<int> MainAttributeRecoverProfessionIds = new int[6] { 0, 14, 6, 11, 5, 12 };

	public const int DukeSkill3AdditionalCricketLuckPoint = 300;

	public const int DukeSkill3CricketPlaceLifeTime = 3;

	public static int TravelerPalaceRandomInjuryCount(IRandomSource random)
	{
		return random.Next(3, 10);
	}

	public static int TravelerRandomPoisonValue(IRandomSource random)
	{
		return random.Next(500, 1501);
	}

	public static int TravelerRandomQiDisorderValue(IRandomSource random)
	{
		return random.Next(1000, 3001);
	}

	public static int TravelerRandomHealthValue(IRandomSource random)
	{
		return random.Next(6, 19);
	}
}
