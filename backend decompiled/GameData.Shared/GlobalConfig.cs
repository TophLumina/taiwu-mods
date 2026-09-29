using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Config;
using Config.Common;
using GameData.Domains.Combat;
using GameData.Serializer;

[Serializable]
public class GlobalConfig : IConfigData
{
	public static GlobalConfig Instance = new GlobalConfig();

	public sbyte AbandonBabyToTaiwuVillageChance = 20;

	public sbyte PrimaryGoalActionPointsPerMonth = 40;

	public sbyte SecondaryGoalActionPointsPerMonth = 40;

	public sbyte PrimaryGoalMaxActionPoints = 60;

	public sbyte SecondaryGoalMaxActionPoints = 60;

	public float AdventureDialogContinuousTime = 2f;

	public float AdventureDialogFadeTime = 0.5f;

	public int AlertnessMin = -600000;

	public int AlertnessMax = 600000;

	public int[] AlertnessLevelRange = new int[8] { -600000, -400000, -200000, -10000, 10000, 200000, 400000, 600000 };

	public int[] AlertnessLevelEffectToChangeFavor = new int[7] { 80, 60, 40, 0, -40, -60, -80 };

	public int AlertnessEffectToMaxFavor = 10;

	public int[] AlertnessLevelEffectToInteractSuccessRate = new int[7] { 175, 150, 125, 100, 75, 50, 25 };

	public int[] InitialAlertnessBaseRandomRange = new int[2] { -100000, 10000 };

	public int[] InitialAlertnessForBehaviorTypeJust = new int[5] { -200000, -100000, 0, 100000, 200000 };

	public int[] InitialAlertnessForBehaviorTypeKind = new int[5] { -100000, -200000, 0, 100000, 50000 };

	public int[] InitialAlertnessForBehaviorTypeEven = new int[5] { 50000, 0, 0, 0, 50000 };

	public int[] InitialAlertnessForBehaviorTypeRebel = new int[5] { 50000, 100000, 0, -200000, -100000 };

	public int[] InitialAlertnessForBehaviorTypeEgoistic = new int[5] { 200000, 100000, 0, -100000, -200000 };

	public int[] InitialAlertnessForTaiwuFameByGoodSect = new int[7] { 100000, 50000, 10000, 0, 0, 0, 0 };

	public int[] InitialAlertnessForTaiwuFameByEvilSect = new int[7] { 0, 0, 0, 0, 10000, 50000, 100000 };

	public int[] InitialAlertnessForTaiwuFameByNeutralSect = new int[7] { 50000, 0, 0, 0, 0, 0, 50000 };

	public int[] InitialAlertnessForTaiwuFameByCivilianSettlement = new int[7] { 100000, 10000, 5000, 0, -5000, -10000, -100000 };

	public int InitialAlertnessChallengeModeFactorBase = 6000;

	public int InitialAlertnessChallengeModeFameDifferent = 5;

	public int InitialAlertnessChallengeModeFameConflict = 25;

	public int InitialAlertnessChallengeModeBehaviorDifferent = 5;

	public int InitialAlertnessChallengeModeBehaviorConflict = 25;

	public int[] ChangeAlertnessOnPraise = new int[5] { -5000, -10000, -2000, 5000, -5000 };

	public int[] ChangeAlertnessOnSneer = new int[5] { 5000, 5000, 2000, -10000, 5000 };

	public sbyte BreakoutBaseAvailableStepsCount = 20;

	public sbyte BreakoutMaxAvailableStepsCount = 99;

	public sbyte BreakoutMinAvailableStepsCount = 3;

	public sbyte BreakoutSpecialNpcStepsCount = 30;

	public sbyte BreakoutShowNormalCellBaseOdds = 20;

	public sbyte BreakoutShowSpecialCellBaseOdds = 60;

	public sbyte BreakoutShowBonusCellBaseOdds = 20;

	public sbyte BreakoutBonusAddPowerCorrectionFactor = 50;

	public static readonly int[] BreakoutBonusExpLevelValues = new int[7] { 500, 1000, 2000, 4000, 8000, 16000, 32000 };

	public static readonly int[] BreakoutBonusExpEffectValues = new int[7] { -4, -5, -6, -7, -8, -9, -10 };

	public static readonly int[] BreakoutBonusFriendFavorabilityTypeValues = new int[7] { 0, 50, 100, 150, 200, 250, 300 };

	public const int BreakoutBonusFriendAddPowerBase = 1;

	public const int BreakoutBonusFriendAddPowerDivisor = 10000;

	public const int BreakoutBonusFriendAddPowerExtraMin = 0;

	public const int BreakoutBonusFriendAddPowerExtraMax = 9;

	public const int BreakoutBonusFriendAttainmentGradeDivisor = 50;

	public const int BreakoutBonusFriendAttainmentGradeMinus = 1;

	public int SectStoryEmeiBonusNotFitProgressPercent = 10;

	public int SectStoryEmeiBonusMinProgress = 1;

	public int SectStoryEmeiBonusProgressPerCount = 30750;

	public int SectStoryEmeiBonusProgressRecyclePercent = 50;

	public int SkillProficiencyIsEnoughToGainLegacyPoint = 300;

	public short LuohanRelationTypeAttainment = 450;

	public int LuohanMaxPowerBase = 60;

	public int LuohanMaxPowerGradeFactor = 15;

	public int LuohanMaxPowerQualificationFactor = 20;

	public int LegendaryBookYangAddStepNormal = 5;

	public int LegendaryBookYinAddStepGoneMad = 5;

	public int ChallengeCharacterWealthCreateRate = 50;

	public int ChallengeTreasurySupplyRate = 50;

	public int[] ChallengeShopItemPriceBonus = new int[7] { 25, 50, 75, 100, 150, 250, 400 };

	public int ChallengeExchangeAdvantageBonus = 50;

	public int ChallengeTaiwuVillageBaseSpaceReduce = 20;

	public const int ChallengeTaiwuVillageLevelEffectReduce = 1;

	public const int ChallengeTaiwuVillageBuildCountLimit = 1;

	public int[] ChallengeProfessionSkillLearnScores = new int[4] { 1, 3, 9, 27 };

	public int ChallengeProfessionSkillLearnExpMultiplier = 1000;

	public int ChallengeInfectedDemonMinionPerMonth = 1;

	public int ChallengeInfectedDemonInitMinion = 3;

	public int ChallengeInfectedDemonMaxMinion = 10;

	public int ChallengeInfectedDemonMinionRange = 2;

	public int ChallengeInfectedDemonInterval = 36;

	public int ChallengeCostResourceLeaveVillageThreshold = -10000;

	public float ChallengeCostResourceFavorFactor = 3f;

	public int ChallengeCostResourceResourceFactorFood = 10;

	public int ChallengeCostResourceResourceFactorWood = 10;

	public int ChallengeCostResourceResourceFactorMetal = 10;

	public int ChallengeCostResourceResourceFactorJade = 10;

	public int ChallengeCostResourceResourceFactorFabric = 10;

	public int ChallengeCostResourceResourceFactorHerb = 10;

	public int ChallengeCostResourceResourceFactorMoney = 2;

	public int ChallengeCostResourceResourceFactorAuth = 20;

	public int[] ChallengeCricketFairCombatMaxPointByWagerGrade = new int[9] { 8, 16, 24, 32, 40, 48, 56, 64, 72 };

	public int[] ChallengeCricketFairCombatCostByCricketGrade = new int[9] { 0, 0, 0, 1, 2, 4, 8, 16, 32 };

	public int[] ChallengeExchangeGradeBonusNpc = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };

	public int[] ChallengeExchangeGradeBonusTreasury = new int[9] { 0, 0, 50, 0, 0, 350, 0, 0, 1000 };

	public DamageStepCollection ChallengeEffectDamageFactor = new DamageStepCollection(200, 200, 160, 180, 180, 180, 180, 200, 200, 160, 180, 180, 180, 180, 200, 160);

	public static readonly byte[] NeedDefeatMarkCount = new byte[4] { 12, 24, 36, 24 };

	public static readonly byte[] SurrenderInjuryCount = new byte[4] { 3, 9, 36, 6 };

	public static readonly byte[] ProactiveProficiencyFactor = new byte[4] { 1, 2, 3, 2 };

	public const int PassiveMinProficiency = 1;

	public const int PassiveMaxProficiency = 3;

	public const int MaxProficiency = 999999999;

	public const int ProficiencyRequirement = 300;

	public int MysteryMinCompatibilityPerCombat = 3;

	public int MysteryMaxCompatibilityPerCombat = 5;

	public short DefeatMarkQiDisorderThreshold = 1000;

	public short DefeatMarkQiDisorderFirstExtra = 2000;

	public short DefeatMarkCombatStatePower = 500;

	public sbyte DefeatMarkCombatStateMaxCount = 8;

	public byte AttackRangeMidMinDistance = 3;

	public sbyte RopeRequireMinMarkCountInBeat = 16;

	public sbyte RopeRequireMinMarkCountInDie = 24;

	public sbyte RopeBaseHitOddsInBeat = 6;

	public sbyte RopeBaseHitOddsInDie = 12;

	public short[] PoisonAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	public short[] RepairAttainments = new short[9] { 0, 10, 30, 60, 100, 150, 210, 280, 360 };

	public short[] RepairBaseResourseRequirement = new short[9] { 5, 10, 15, 25, 35, 45, 60, 75, 90 };

	public short[] MakeMadicineAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	public short[] DisassembleAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	public int HealInjuryPoisonSpeedMinPercent = 20;

	public const short BreathMaxValue = 30000;

	public const short StanceMaxValue = 4000;

	public sbyte RecoverBreathBaseValue = 30;

	public sbyte RecoverStanceBaseValue = 60;

	public sbyte[] RecoverStanceDivisorByWeapon = new sbyte[3] { 6, 4, 2 };

	public const short PursueAttackAddStance = 25;

	public sbyte AttackSpeedFactor = 50;

	public sbyte MinPrepareFrame = 9;

	public int UnlockAttackUnit = 18000;

	public const int MaxChangeTrickCount = 12;

	public int MaxChangeTrickProgress = 100;

	public int MaxChangeTrickProgressOnce = 1200;

	public int ChangeTrickMultiplierFlaw = 2;

	public int ChangeTrickMultiplierAcupoint = 3;

	public int FirstAttackAddChangeTrickProgress = 10;

	public int PursueAttackAddChangeTrickProgress = 3;

	public int[] AvoidChangeTrickProgressPercentByWeapon = new int[3] { 33, 66, 100 };

	public int BaseCriticalOdds = 60;

	public int AvoidAddTrickBaseOdds = 10;

	public int AvoidAddTrickHitOddsDivisor = 2;

	public int NormalAttackExtraHitOdds;

	public int BaseAttackDamageValue = 9;

	public int AddBaseAttackDamageValue = 3;

	public int BaseSkillDamageValue = 60;

	public int BaseUnlockDamageValue = 30;

	public int BaseSpiritDamageValue = 30;

	public int BaseAttackOdds = 800;

	public int BaseMindAttackOdds = 30;

	public int BaseSkillAttackOdds = 30;

	public int BaseUnlockAttackOdds = 30;

	public int BaseSpiritAttackOdds = 800;

	public sbyte[] ReduceHealthPerFatalDamageMark = new sbyte[4] { 0, 18, 36, 18 };

	public int MaxFatalMarkCount = 999;

	public short[] AcupointLevelRequireHitOdds = new short[3] { 100, 300, 900 };

	public short[] FlawLevelRequireHitOdds = new short[3] { 100, 600, 1800 };

	public int[] AcupointBaseKeepTime = new int[4] { 90000, 135000, 270000, 540000 };

	public int[] FlawBaseKeepTime = new int[4] { 45000, 67500, 135000, 270000 };

	public int FlawOrAcupointReduceBaseTime = 100;

	public int FlawAddDamagePercent = 40;

	public int ExtraFlawAddDamagePercent = 10;

	public short DefaultJumpThreshold = 10;

	public const short FastMoveMobilityPercent = 75;

	public const short SlowMoveMobilityPercent = 25;

	public short FastWalkDistance = 60;

	public const byte FastMobilityLevel = 2;

	public const byte SlowMobilityLevel = 1;

	public const byte VerySlowMobilityLevel = 0;

	public int MobilityRecoverSpeed = 200;

	public int LockingRecoverSpeed = 400;

	public int MaxMobility = 120000;

	public int ReduceJumpProgressFrame = 6;

	public int ReduceJumpProgressPercent = 10;

	public int MoveCdBase = 32;

	public int MoveCdFactor = 20;

	public int MoveCdDivisorBase = 400;

	public int MoveCdDivisorFactor = 45;

	public int AgileSkillNonJumpDirectionCostMobilityPercent = 10;

	public short AgileSkillBaseAddSpeed = 100;

	public short AgileSkillBaseAddHit = 200;

	public short DefendSkillBaseAddAvoid = 200;

	public short DefendSkillBaseAddPenetrateResist = 400;

	public short DefendSkillBaseFightBackPower = 150;

	public short DefendSkillBaseBouncePower = 25;

	public int DefendSkillClearManualSilenceFrameRatio = 300;

	public short MindMarkBaseKeepTime = 900;

	public int BaseMindRhythm = 6;

	public int BaseMindUpheavalTime = 180;

	public int MindUpheavalAddDamageStepPercent = 50;

	public int ScarMarkBaseKeepTime = 1800;

	public int ScarMarkProgressPerMark = 100;

	public int ScarMarkProgressMin = 40;

	public int ScarMarkProgressMax = 60;

	public short AttackPrepareValueFixedDelayFramePerUnit = 20;

	public short[] AttackChangeTrickHitValueAddPercent = new short[3] { 50, 200, 350 };

	public short[] AttackChangeTrickCostBlockBasePercent = new short[3] { 150, 300, 450 };

	public short MaxWugCount = 90;

	public int[] SpiritualDebtLimit = new int[2] { -999999999, 999999999 };

	public sbyte[] CombatSkillInitialEquipSlotCounts = new sbyte[6] { 6, 1, 1, 1, 1, 0 };

	public short CharacterInitialNeili = 20;

	public short HomelessFavorabilityChangePerMonth = -1200;

	public sbyte HomelessHappinessChangePerMonth = -15;

	public short HouseFavorabilityChangePerMonth = 400;

	public sbyte HouseHappinessChangePerMonth = 5;

	public short[] FavorabilityChangeOnExpel = new short[5] { -20000, -15000, -10000, -15000, -20000 };

	public int StrengthToEquipmentLoadFactor = 10;

	public int EquipmentLoadBaseValue = 1500;

	public int TaiwuVillageForceAreaSize = 38;

	public sbyte CaptureRatePerRopeGrade = 15;

	public int CombatGetNonMainPercent = 25;

	public short[] CombatGetExpBase = new short[19]
	{
		100, 110, 140, 190, 260, 350, 460, 590, 740, 910,
		1100, 1310, 1540, 1790, 2060, 2350, 2660, 2990, 3340
	};

	public short[] CombatGetAuthorityBase = new short[19]
	{
		5, 10, 20, 30, 45, 60, 80, 105, 130, 160,
		190, 230, 280, 340, 410, 500, 610, 760, 950
	};

	public short LifeSkillBattleGainRatio = 50;

	public sbyte UseSwordFragmentAddXiangshuInfection = 20;

	public sbyte CalcApplyItemPoisonParam = 20;

	public sbyte ThrowPoisonParam = 10;

	public float MercyPrepareMaxTime = 2f;

	public float MercyAutoIgnoreTime = 6f;

	public int PowerDamageMax = 500;

	public int PowerDamageOffset = 500;

	public uint TiredMarkAppearFrame = 540u;

	public int MaxPendingChickenCount = 27;

	public int CricketRoomExpPerLowMaterialBaseValue = 50;

	public int CricketRoomExpPerLowMaterialDecreasingValue = 3;

	public int CricketRoomExpPerLowMaterialMinValue = 20;

	public int CricketRoomExpPerHighMaterialBaseValue = 150;

	public int CricketRoomExpPerHighMaterialDecreasingValue = 10;

	public int CricketRoomExpPerHighMaterialMinValue = 50;

	public int CricketRoomRequireExpPerLevel = 1000;

	public int CricketRoomBaseLevel = 1;

	public int CricketRoomMaxLevel = 10;

	public int CricketRoomPolymorphReturnRequireLevel = 3;

	public int CricketRoomMakingWishRequireLevel = 10;

	public int CricketAgeProgressPerYear = 100;

	public int CricketSpiritMax = 1000;

	public int CricketSpiritUnit = 100;

	public int[] CricketSpiritGrowthProperties = new int[11]
	{
		10, 10, 1, 1, 1, 5, 1, 5, 5, 1,
		5
	};

	public short CricketSpiritGrowthDurability = 1;

	public int[] CricketCombatAddSpirit = new int[9] { 1, 2, 3, 6, 9, 12, 18, 24, 32 };

	public int[] CricketBloodDewAddSpirit = new int[9] { 10, 20, 30, 50, 80, 120, 170, 230, 300 };

	public int CricketPolymorphBaseRate = 5;

	public int CricketPolymorphAddRate = 1;

	public short CricketWishingDuration = 3;

	public int CricketWishingCostLuckPoint = 300;

	public int CricketWishingReturnLuckPoint = 150;

	public short CustomProtagonistMainAttributeTotalPoint = 300;

	public short CustomProtagonistMainAttributeMaxPoint = 90;

	public short CustomProtagonistMainAttributeDefaultPoint = 20;

	public short CustomProtagonistLifeSkillQualificationTotalPoint = 800;

	public short CustomProtagonistLifeSkillQualificationMaxPoint = 90;

	public short CustomProtagonistLifeSkillQualificationDefaultPoint = 40;

	public short CustomProtagonistCombatSkillQualificationTotalPoint = 700;

	public short CustomProtagonistCombatSkillQualificationMaxPoint = 90;

	public short CustomProtagonistCombatSkillQualificationDefaultPoint = 40;

	public short CustomProtagonistCharacterFeatureTotalPoint = 7;

	public int DebateMaxGamePoint = 6;

	public int DebateMaxRound = 20;

	public int DebateLineCount = 3;

	public int DebateLineNodeCount = 6;

	public int[] DebateTaiwuVantageNodeCount = new int[3] { 4, 3, 2 };

	public int DebateCardTypeLimit = 4;

	public int DebateMakeMoveLimit = 1;

	public int DebateGetStrategyLimit = 3;

	public int DebatePawnStrategyLimit = 3;

	public int DebateGradeToBasesPercent = 5;

	public int DebatePawnDamageToGamePoint = 1;

	public int DebateSpectatorPickRange = 1;

	public int DebateSurrenderAttainmentFactor = 200;

	public int[] DebateSurrenderBehaviorFactor = new int[5] { 100, 80, 60, 80, 100 };

	public int[] DebateAttainmentToMaxBasesPercent = new int[2] { 85, 116 };

	public int DebateBasesRecoverPercent = 30;

	public int DebateInitialStrategyPoint = 4;

	public int DebateMaxStrategyPoint = 12;

	public int DebateStrategyPointRecover = 2;

	public int DebateMaxPressure = 100;

	public int DebatePressureStrategyRecoverPercent = 50;

	public int DebatePressureBasesRecoverPercent = 50;

	public int DebatePressureAutoIncreaseRound = 10;

	public int DebatePreesureAutoIncreaseValue = 10;

	public int DebateLowPressurePercent = 50;

	public int DebateMidPressurePercent = 75;

	public int DebateHighPressurePercent = 100;

	public int[] DebateReduceStrategyRecoverProb = new int[4] { 0, 0, 100, 100 };

	public int[] DebateReduceBasesRecoverProb = new int[4] { 0, 100, 100, 100 };

	public int[] DebateUseStrategyFailedProb = new int[4] { 0, 0, 0, 50 };

	public int[] DebateMakeMoveFailedProb = new int[4] { 0, 0, 0, 50 };

	public int DebatePressureDeltaInConflict = 5;

	public int DebateCommentStackLimit = 3;

	public int DebateBullyPercent = 50;

	public int DebateOverComePercent = 150;

	public int DebateCommentProb = 50;

	public int DebateSameSideCommentProb = 75;

	public int DebateOtherSideCommentProb = 25;

	public int DebateCommentDivider = 1200;

	public int DebateAddNodeEffectProb = 50;

	public int DebateHelpSameSideProb = 50;

	public int DebateHelpSameSideDivider = 600;

	public int DebateSurrenderFactor = 50;

	public int DebateMaxCanUseCards = 6;

	public int DebateResetCardsPressureLimit = 100;

	public int DebateResetCardsPressureDelta = 25;

	public int DebateMaxShuffleCard = 3;

	public List<int[]> AttackLineWeight = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 2, 3 },
		new int[2] { 3, 4 },
		new int[2] { 1, 4 },
		new int[2] { 3, 4 }
	};

	public List<int[]> MidLineWeight = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 3, 4 },
		new int[2] { 4, 5 },
		new int[2] { 1, 4 },
		new int[2] { 4, 5 }
	};

	public List<int[]> DefenseLineWeight = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 6, 7 },
		new int[2] { 6, 7 },
		new int[2] { 1, 4 },
		new int[2] { 6, 7 }
	};

	public int[] EarlyBases = new int[5] { 50, 60, 55, 50, 40 };

	public int[] MidBases = new int[5] { 40, 50, 45, 40, 35 };

	public int[] LateBases = new int[5] { 35, 45, 40, 35, 30 };

	public List<int[]> EarlyStrategyPoint = new List<int[]>
	{
		new int[2] { 5, 3 },
		new int[2] { 7, 4 },
		new int[2] { 6, 4 },
		new int[2] { 4, 3 },
		new int[2] { 3, 2 }
	};

	public List<int[]> MidStrategyPoint = new List<int[]>
	{
		new int[2] { 4, 1 },
		new int[2] { 5, 2 },
		new int[2] { 3, 2 },
		new int[2] { 2, 1 },
		new int[2] { 1, 1 }
	};

	public List<int[]> LateStrategyPoint = new List<int[]>
	{
		new int[2],
		new int[2],
		new int[2],
		new int[2],
		new int[2]
	};

	public int[] DamageLineWeight = new int[5] { 1, 1, 1, 1, 2 };

	public int[] DamagedLineWeight = new int[5] { 1, 2, 1, 1, 1 };

	public List<int[]> StateGamePointPressureInfluence = new List<int[]>
	{
		new int[2] { 69, 19 },
		new int[2] { 59, 0 },
		new int[2] { 69, 19 },
		new int[2] { 79, 29 },
		new int[2] { 79, 39 }
	};

	public List<int[]> StatePawnCountInfluence = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 4, 5 },
		new int[2] { 3, 4 },
		new int[2] { 2, 3 },
		new int[2] { 1, 2 }
	};

	public int[] StateRoundInfluence = new int[5] { 13, 15, 14, 13, 12 };

	public int EgoisticNodeEffectWeightPercent = 100;

	public int[] EvenNodeEffectMaxGradeProb = new int[5] { 80, 20, 50, 20, 50 };

	public int RoundBeforeEarly = 3;

	public int MinGradeIfEnoughBases = 6;

	public int[] ZeroGradePawnProb = new int[3] { 90, 80, 60 };

	public int MakeMoveOnOverwhelmingLineProb = 80;

	public int RemoveStrategyTargetPawnBasesPercent = 20;

	public int[] Taoism3CanUseCardLimit = new int[3] { 1, 3, 0 };

	public int[] Math1CanUseCardLimit = new int[3] { 3, 0, 0 };

	public int ResetStrategyUsedCardLimit = 3;

	public const int BuyPriceBaseEffect = 200;

	public const int SellPriceBaseEffect = 20;

	public const int ExtraGoodsPriceEffect = 50;

	public static readonly sbyte[] IncreasePriceProb = new sbyte[5] { 0, 0, 20, 40, 40 };

	public static readonly sbyte[] DecreasePriceProb = new sbyte[5] { 0, 40, 20, 40, 0 };

	public const int BehaviorAddDiscount = 25;

	public const int BehaviorReduceDiscount = -25;

	public const int SeniorityToCaravanBuyPrice = -25;

	public const int SeniorityToCaravanSellPrice = 25;

	public short[] MerchantFavorabilityUpperLimits = new short[10] { 0, 0, 1, 2, 3, 4, 5, 6, 6, 6 };

	public short[] MerchantItemDebtGradeUpperLimits = new short[10] { 1, 1, 2, 3, 4, 5, 5, 6, 7, 7 };

	public int[] MerchantFavorabilityMoneyRequirements = new int[10] { 6000, 12000, 24000, 48000, 96000, 192000, 384000, 768000, 1536000, 3072000 };

	public int[] MerchantFavorabilityXiangshuLevelRequirements = new int[10] { 0, 0, 2, 4, 6, 8, 10, 12, 14, 16 };

	public int[] MerchantCharFavorabilityBuyEffect = new int[13]
	{
		25, 20, 15, 10, 5, 0, 0, 0, -5, -10,
		-15, -20, -25
	};

	public int[] MerchantCharFavorabilitySellEffect = new int[13]
	{
		-10, -8, -6, -4, -2, 0, 0, 0, 2, 4,
		6, 8, 10
	};

	public int[] MerchantDebtLevelLimit = new int[7] { -1, 316500, 305700, 274200, 199800, 124200, 0 };

	public short[] MerchantOverFavorBuyCount = new short[7] { -1, 12, 9, 6, 3, 2, 1 };

	public int[] CaravanRobbedEventWinAddMerchantFavorability = new int[7] { 2700, 6750, 13950, 25200, 41400, 36450, 92250 };

	public short CaravanRobbedEventLoseReduceIncomeBonus = 33;

	public short[] CaravanIncomeCriticalResultRange = new short[2] { 150, 300 };

	public sbyte CaravanRobbedEventEndReduceRobbedRate = 50;

	public int[] InvestCaravanNeedMoney = new int[6] { 5000, 10000, 20000, 40000, 80000, 160000 };

	public int[] InvestedCaravanAvoidRobbedNeedAuthorityFactor = new int[6] { 5, 10, 20, 40, 80, 160 };

	public static readonly sbyte[] MerchantLevelNeedFavorabilityLevel = new sbyte[7] { 0, 2, 4, 6, 8, 9, 10 };

	public int[] ExchangeTreasuryLevelGrade = new int[3] { 2, 5, 8 };

	public float ExchangeBarRangeP1 = 72901f;

	public int[] ExchangeFavorLevel = new int[13]
	{
		0, 0, 0, 0, 0, 25, 50, 100, 200, 350,
		550, 700, 1000
	};

	public int[] ExchangeAlertnessLevel = new int[7] { 0, 0, 0, 50, 200, 550, 1000 };

	public int ExchangeMoralitySame;

	public int ExchangeMoralitySimilar = 25;

	public int ExchangeMoralityOpposite = 50;

	public int[] ExchangeFameValueForGood = new int[7] { 0, 0, 0, 0, 0, 50, 100 };

	public int[] ExchangeFameValueForNeutral = new int[7] { 50, 25, 0, 0, 0, 25, 50 };

	public int[] ExchangeFameValueForBad = new int[7] { 100, 50, 0, 0, 0, 0, 0 };

	public int ExchangeSpecialGender = 50;

	public int ExchangeSpecialLackResource = 200;

	public int ExchangeBaseTaiwu = 100;

	public int ExchangeBaseNormalNpc = 200;

	public int ExchangeBaseSectNpc = 300;

	public int ExchangeBaseTreasury = 400;

	public int ExchangeSecretAdvantageBonus = 5;

	public int ExchangeApproveAdvantageBonus = 5;

	public int ExchangeDebtUnit = 5;

	public int[] ExchangeGradeOverProgress = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };

	public int[] GetPrisonerHappinessChange = new int[9] { 2, 4, 6, 8, 10, 12, 14, 16, 18 };

	public int[] GetPrisonerFavorChange = new int[9] { 600, 1200, 1800, 3000, 4200, 5400, 7200, 9000, 10800 };

	public int FeastCount = 3;

	public int FeastDurability = 3;

	public int FeastGiftCount = 30;

	public List<int> FeastBaseHappiness = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

	public List<int> FeastBaseFaovr = new List<int> { 60, 120, 180, 300, 420, 540, 720, 900, 1080 };

	public List<int> FeastBuildingLevelHappinessPercent = new List<int> { 50, 100, 150 };

	public List<int> FeastBuildingLevelFavorPercent = new List<int> { 100, 200, 300 };

	public int FeastLoveItemHappinessPercent = 50;

	public int FeastLoveItemFavorPercent = 100;

	public int FeastLoveItemGiftAddOn = 1;

	public int FeastLowHappiness = 40;

	public int[] FeastGiftGradeFactor = new int[2] { -3, -2 };

	public int[] FeastGiftResourcePercent = new int[2] { 8, 12 };

	public int[] FeastGiftMoneyPercent = new int[2] { 40, 60 };

	public int[] FeastGiftResourceAddon = new int[2] { 50, 100 };

	public WeightsSumDistribution MainAttributeWeightsTable = new WeightsSumDistribution(42, 6, 10, 17, 30, 51, 90, 153, 270, 459);

	public WeightsSumDistribution CombatSkillQualificationWeightsTable = new WeightsSumDistribution(84, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);

	public WeightsSumDistribution LifeSkillQualificationWeightsTable = new WeightsSumDistribution(96, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);

	public int CongenitalMalformationProbability = 50;

	public const int CharacterCreationBaseMainAttributeSum = 168;

	public const int CharacterCreationMainAttributePerLevel = 21;

	public const int CharacterCreationBaseLifeSkillSum = 448;

	public const int CharacterCreationLifeSkillPerLevel = 56;

	public const int CharacterCreationBaseCombatSkillSum = 392;

	public const int CharacterCreationCombatSkillPerLevel = 49;

	public const int CharacterCreationMutationRate = 20;

	public const int CharacterCreationValueSpan = 20;

	public const int DefaultMainAttributeMutateCount = 2;

	public const int DefaultCombatSkillQualificationMutateCount = 3;

	public const int DefaultLifeSkillQualificationMutateCount = 4;

	public static readonly sbyte[] CharacterCreationSectMemberGenerationTypeWeights = new sbyte[3] { 70, 15, 15 };

	public static readonly sbyte[] CharacterCreationCivilianGenerationTypeWeights = new sbyte[3] { 50, 25, 25 };

	public static readonly sbyte[] CharacterCreationAdjustGradeBaseChances = new sbyte[9] { 5, 10, 15, 20, 25, 30, 40, 50, 60 };

	public static readonly short[][] CharacterCreationAdjustGradeWeights = new short[9][]
	{
		new short[9] { 900, 140, 100, 60, 40, 20, 0, 0, 0 },
		new short[9] { 35, 900, 140, 100, 60, 40, 20, 0, 0 },
		new short[9] { 25, 35, 900, 140, 100, 60, 40, 20, 0 },
		new short[9] { 15, 25, 35, 900, 140, 100, 60, 40, 20 },
		new short[9] { 10, 15, 25, 35, 900, 140, 100, 60, 40 },
		new short[9] { 5, 10, 15, 25, 35, 900, 140, 100, 60 },
		new short[9] { 0, 5, 10, 15, 25, 35, 900, 140, 100 },
		new short[9] { 0, 0, 5, 10, 15, 25, 35, 900, 140 },
		new short[9] { 0, 0, 0, 5, 10, 15, 25, 35, 900 }
	};

	public const short SkillAdjustBaseValue = 6;

	public int MaxTaiwuVillageAreaCreateCount = 10;

	public int MaxSwordTombCanSelectCount = 40;

	public int SwordTombRightDirectionPoint = 200;

	public int SwordTombNormalDirectionPoint = 200;

	public int SwordTombNormalDirectionOffset = 10;

	public int SwordTombMinimumDistance = 6;

	public int[] SwordTombFirstBestDistanceRange = new int[2] { 4, 6 };

	public int[] SwordTombNormalBestDistanceRange = new int[2] { 8, 9 };

	public int SwordTombBestDistanceRangePoint = 250;

	public int NormalInformationMaxRemainCount = 99;

	public int NormalInformationDefaultCostableMaxUseCount = 3;

	public int[] MakeAutoSelectToolGradeScore = new int[9] { 3, 4, 5, 7, 9, 11, 14, 18, 23 };

	public int[] MakeAutoSelectToolDestroyScore = new int[9] { 1, 3, 9, 22, 46, 84, 138, 211, 307 };

	public short[] HealInjuryAttainment = new short[6] { 30, 60, 120, 210, 330, 480 };

	public short[] HealPoisonAttainment = new short[3] { 60, 210, 480 };

	public short[] HealQiDisorderAttainment = new short[4] { 60, 210, 480, 480 };

	public short[] HealHealthAttainment = new short[4] { 60, 210, 480, 480 };

	public short HealInjuryBaseHerb = 20;

	public short HealInjuryBaseMoney = 100;

	public short[] HealInjuryExtraHerb = new short[6] { 10, 20, 40, 80, 160, 320 };

	public short[] HealInjuryExtraMoney = new short[6] { 50, 100, 200, 400, 800, 1600 };

	public short[] HealInjuryCostSpiritualDebt = new short[6] { 30, 60, 90, 120, 150, 180 };

	public short HealPoisonBaseHerb = 20;

	public short HealPoisonBaseMoney = 100;

	public short[] HealPoisonExtraHerb = new short[3] { 20, 80, 320 };

	public short[] HealPoisonExtraMoney = new short[3] { 100, 400, 1600 };

	public short[] HealPoisonExtraSpiritualDebt = new short[3] { 60, 120, 180 };

	public short[] HealQiDisorderHerb = new short[5] { 20, 40, 80, 160, 320 };

	public short[] HealQiDisorderMoney = new short[5] { 100, 200, 400, 800, 1600 };

	public short[] HealQiDisorderCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };

	public short[] HealHealthHerb = new short[5] { 40, 80, 160, 320, 1280 };

	public short[] HealHealthMoney = new short[5] { 200, 400, 800, 1600, 6400 };

	public short[] HealHealthCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };

	public short[] HealMoneyPercent = new short[5] { 150, 100, 200, 250, 300 };

	public int HealPoisonAttainmentPercent = 1000;

	public int HealQiDisorderAttainmentPercent = 500;

	public int LocationNaturalDisasterDuration = 12;

	public int HealHealthAttainmentPercent = 100;

	public int MartialArtTournamentPreparationValueDivider = 1000;

	public int MartialArtTournamentCombatPowerValueDivider = 100;

	public (int, int) MartialArtTournamentGoodFameRange = (25, 1000);

	public (int, int) MartialArtTournamentNeutralFameRange = (-25, 25);

	public (int, int) MartialArtTournamentBadFameRange = (-1000, -25);

	public static readonly sbyte[] ResourcesPrice = new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 10 };

	public const sbyte ExpPrice = 5;

	public int[] JiaoMaxProperty = new int[9] { 60, 20000, 150, 150, 12, 123000, 150, 36, 21600 };

	public int ArtisanOrderPricePercent = 33;

	public int ArtisanOrderInterceptPricePercent = 300;

	public int ArtisanOrderInterceptDebatePricePercent = 150;

	public int ExchangeLegendaryBookBasePriceInCoin = 3000000;

	public List<int[]> ExchangeBookBehaviorTypeToValuePercent = new List<int[]>
	{
		new int[2] { 200, 15 },
		new int[2] { 100, 30 },
		new int[2] { 150, 20 },
		new int[2] { 100, 30 },
		new int[2] { 200, 15 }
	};

	public int ExchangeBookValueDivider = 10;

	public int ExchangeBookValueDurabilityBasePercent = 50;

	public int ExchangeBookValueDurabilityFactor = 50;

	public int CaravanExchangeProbPenalize = 50;

	public int ItemContributionPercent = 100;

	public int ResourceContributionPercent = 200;

	public static readonly int[] DreamBackDestroyItemWorthLowerLimit = new int[9] { 100, 200, 600, 1500, 3100, 5600, 9200, 14100, 20500 };

	public int WorthToLegacyPercentage = 40;

	public static readonly short[] XiangshuAddProfessionSeniorityArrayOne = new short[19]
	{
		500, 550, 700, 950, 1300, 1750, 2300, 2950, 3700, 4550,
		5500, 6550, 7700, 8950, 10300, 11750, 13300, 14950, 16700
	};

	public static readonly short[] XiangshuAddProfessionSeniorityArrayTwo = new short[19]
	{
		250, 275, 350, 475, 650, 875, 1150, 1475, 1850, 2275,
		2750, 3275, 3850, 4475, 5150, 5875, 6650, 7475, 8350
	};

	public static readonly short[] XiangshuAddProfessionSeniorityArrayThree = new short[19]
	{
		100, 110, 140, 190, 260, 350, 460, 590, 740, 910,
		1100, 1310, 1540, 1790, 2060, 2350, 2660, 2990, 3340
	};

	public sbyte HusbandAndWifeStartAdoreChance = 25;

	public sbyte HusbandAndWifeStartAdoreCooldown = 6;

	public int[] GoodMarriageAgeRange = new int[2] { 20, 29 };

	public int[] LateMarriageAgeRange = new int[2] { 30, 39 };

	public sbyte DistantMarriageGoodAgeChance = 5;

	public sbyte DistantMarriageLateAgeChance = 15;

	public sbyte[] DistantMarriageGoodAgeTargetGradeRange = new sbyte[2] { 1, 3 };

	public sbyte[] DistantMarriageLateAgeTargetGradeRange = new sbyte[2] { -2, 0 };

	public int[][] DistantMarriageGoodAgeTargetAgeRange = new int[2][]
	{
		new int[2] { 24, 29 },
		new int[2] { 24, 39 }
	};

	public int[][] DistantMarriageLateAgeTargetAgeRange = new int[2][]
	{
		new int[2] { 34, 39 },
		new int[2] { 34, 49 }
	};

	public int AdoptiveRelationAgeRequirement = 14;

	public int BequestBookPageCompleteFactor = 3;

	public int BequestBookPageLostFactor = 5;

	public int[][] BequestBehaviorRelationFactor = new int[5][]
	{
		new int[8] { 10, 9, 8, 7, 6, 5, 4, 3 },
		new int[8] { 10, 9, 5, 6, 8, 7, 3, 4 },
		new int[8] { 9, 10, 6, 5, 8, 7, 4, 3 },
		new int[8] { 4, 5, 7, 3, 9, 8, 6, 10 },
		new int[8] { 8, 7, 5, 6, 4, 10, 3, 9 }
	};

	public int BequestRelationPositiveFinalFactor = 100;

	public int BequestRelationNegativeFinalFactor = 100;

	public int BequestRelationThreshold = 1000;

	public int BequestProbabilityFactor1 = 8;

	public int BequestProbabilityFactor2 = 10;

	public int BequestGenerateBookPercent;

	public int[] BequestPublicPercent = new int[5] { 30, 25, 20, 15, 10 };

	public int[] BequestPrivatePercent = new int[5] { 25, 30, 35, 40, 45 };

	public int TaiwuBaseInitialFavorabilityValue = 3000;

	public int NpcBaseInitialFavorabilityValue = 15000;

	public int SecretInformationNpcPlanDisseminateAmountFactor = 10000;

	public int SecretInformationBroadcastNotifyElementDisplayLimit = 4;

	public int SecretInformationShopCharacterCollectInAreaMaxAmount = 15;

	public sbyte[] SecretInformationDefaultDisplaySettings = new sbyte[5] { 0, 1, 1, 1, 1 };

	public short[] SecretInformationReceivedDisseminateLevels = new short[4] { 0, 30, 50, 80 };

	public short[] SecretInformationShopCharacterFavorabilityChanges = new short[3] { 1000, 2000, 5000 };

	public short SecretInformationSourceCharacterAuthorityGainToCostConfigRate = 20;

	public int SecretInformationInPrivateMaxUseCount = 3;

	public int SecretInformationInBroadcastMaxUseCount = 3;

	public static readonly short[] SecretInformationDisplay_ItemGradeToValue = new short[9] { 0, 0, 0, 3, 6, 9, 33, 66, 99 };

	public static readonly short[] SecretInformationDisplay_PosASectCharGradeToValue = new short[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	public static readonly short[] SecretInformationDisplay_PosANotSectCharGradeToValue = new short[9] { 0, 0, 1, 1, 2, 2, 3, 4, 5 };

	public static readonly short[] SecretInformationDisplay_PosBSectCharGradeToValue = new short[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	public static readonly short[] SecretInformationDisplay_PosBNotSectCharGradeToValue = new short[9] { 0, 0, 1, 1, 2, 2, 3, 4, 5 };

	public static readonly short[] SecretInformationDisplay_PosCSectCharGradeToValue = new short[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	public static readonly short[] SecretInformationDisplay_PosCNotSectCharGradeToValue = new short[9] { 0, 0, 1, 1, 2, 2, 3, 4, 5 };

	public static readonly short[] SecretInformationDisplay_PosASectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	public static readonly short[] SecretInformationDisplay_PosANotSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	public static readonly short[] SecretInformationDisplay_PosBSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	public static readonly short[] SecretInformationDisplay_PosBNotSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	public static readonly short[] SecretInformationDisplay_PosCSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	public static readonly short[] SecretInformationDisplay_PosCNotSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	public static readonly ushort[] SecretInformationDisplay_SizeThresholds = new ushort[3] { 0, 60, 130 };

	public short[] BroadcastSecretInformationHappinessAdjust = new short[5] { 100, 133, 66, 166, 33 };

	public int[] SecretRelationFactor = new int[11]
	{
		99, 15, 99, 99, 1, 12, 3, 9, 6, 99,
		99
	};

	public int[] SecretSectFactor = new int[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	public int[] SecretNonSectFactor = new int[9] { 1, 2, 3, 5, 9, 12, 15, 18, 21 };

	public int[] SecretItemFactor = new int[9] { 0, 0, 0, 3, 6, 7, 33, 66, 99 };

	public int[] SecretRelationScore = new int[3] { 0, 3, 11 };

	public int[] SecretCharScore = new int[3] { 1, 3, 10 };

	public int[] SecretItemScore = new int[3] { 1, 5, 15 };

	public int[] SecretSortValueScore = new int[3] { 1, 6, 22 };

	public int[] SecretLevelRange = new int[2] { 100, 400 };

	public int ThreeVitalsInitInfection = 50;

	public int ThreeVitalsMinInfection;

	public int ThreeVitalsMaxInfection = 100;

	public int ThreeVitalsInfectionDelta = 5;

	public int ThreeVitalsThresholdLow = 20;

	public int ThreeVitalsThresholdHigh = 80;

	public int ThreeVitalsDefectionBase = 50;

	public int ThreeVitalsDefectionExtra = 5;

	public int JieQingPointRequire = 50;

	public sbyte WuxianDriveWugKingCostResourceType = 5;

	public int WuxianDriveWugKingCostResourceCount = 5000;

	public short WuxianDriveWugKingCooldown = 6;

	public short WuxianDriveWugKingCostActionPoint = 50;

	public sbyte BaihuaLifeLinkTargetConsummate = 4;

	public sbyte WordlessStatusChangeDuration = 3;

	public sbyte WordlessStatusStep = 2;

	public const int CreateMirrorCharacterCost = 10;

	public int FeatherValueMax = 6400;

	public int FeatherValuePerFeather = 100;

	public int FeatherValueBaseMonthly = 12;

	public int FeatherValuePerChicken = 2;

	public int InitialFeatherValue = 50;

	public int InitialFeatherChickens = 3;

	public int CultivateFeatherValue = 700;

	public int CultivateCost = 7000;

	public int CultivateEnergyCost = 10;

	public int KingFeatherCount = 2;

	public int MaximumJieQingPoint = 99999;

	public int NormalQiwenXingtaiCount = 3;

	public int AdvancedQiwenXingtaiCount = 9;

	public int GainExtraJieqingXingyunProbability = 20;

	public int GainExtraJieqingXingyunValueMinInclusive = 500;

	public int GainExtraJieqingXingyunValueMaxExclusive = 501;

	public List<short[]> TreasuryResourceSupplyRanges = new List<short[]>
	{
		new short[2] { 100, 150 },
		new short[2] { 200, 300 },
		new short[2] { 300, 450 },
		new short[2] { 400, 600 },
		new short[2] { 500, 750 }
	};

	public List<sbyte[]> TreasuryItemSupplyCounts = new List<sbyte[]>
	{
		new sbyte[9] { 4, 3, 2, 2, 2, 1, 1, 1, 0 },
		new sbyte[9] { 5, 4, 3, 2, 2, 2, 2, 1, 1 },
		new sbyte[9] { 6, 5, 4, 3, 3, 2, 3, 2, 1 },
		new sbyte[9] { 7, 6, 5, 4, 4, 3, 3, 3, 2 },
		new sbyte[9] { 8, 7, 6, 5, 5, 4, 4, 3, 3 }
	};

	public List<int> MemberSelfImproveSpeedFactor = new List<int> { 50, 100, 200 };

	public int[] TreasuryStatusThreshold = new int[2] { 80, 120 };

	public int TreasuryGuardCount = 2;

	public List<sbyte> TreasuryGuardMaxGrade = new List<sbyte> { 2, 4, 6 };

	public List<sbyte> SectTreasuryGuardMaxGrade = new List<sbyte> { 3, 5, 7 };

	public int TreasuryRquireApprovingMid = 40;

	public int TreasuryRquireApprovingHigh = 70;

	public int TreasuryRquireSpiritualDebtMid = 400;

	public int TreasuryRquireSpiritualDebtHigh = 700;

	public int PrisonRequireApprovingMid = 400;

	public int PrisonRequireApprovingHigh = 700;

	public int TreasurySupplyLevelUpPercent = 150;

	public int[] TreasuryAlterTime = new int[3] { 3, 6, 12 };

	public int[] GuardConsummateLevel = new int[3] { 6, 10, 14 };

	public sbyte SolarTermAddCombatSkillPower = 10;

	public sbyte SolarTermAddHealOuterInjury = 20;

	public sbyte SolarTermAddHealInnerInjury = 20;

	public sbyte SolarTermAddRecoverQiDisorder = 10;

	public sbyte SolarTermAddHealPoison = 20;

	public sbyte SolarTermAddPoisonEffect = 20;

	public sbyte SolarTermAddHealth = 20;

	public int[] SolarTermGoodsRate = new int[3] { 80, 60, 40 };

	public int SolarTermGoodsCountMin = 1;

	public int SolarTermGoodsCountMax = 2;

	public const sbyte MonthsPerYear = 12;

	public const sbyte DaysPerMonth = 30;

	public const int ActionPointsPerDay = 10;

	public int ActionPointLimitPerMonth = 600;

	public int ActionPointRecoveryPerMonth = 300;

	public int MoreActionPointLimitPerMonth = 900;

	public int MoreActionPointRecoveryPerMonth = 450;

	public int GameStartDate = 8;

	public int MapNormalBlockRange = 3;

	public byte MapAreaOpenPrestige = 50;

	public sbyte MapInitUnlockStationStateCount = 3;

	public int AgeBaby = 3;

	public const int AgeAdult = 16;

	public const int AgeDarkAsh = 40;

	public const int AgeDarkAshVictim = 70;

	public const int DarkAshWeightAdult = 1;

	public const int DarkAshWeightSemi = 3;

	public const int DarkAshWeightOld = 6;

	public int PopulationLimitRandomRateMax = 120;

	public int MaxAgeOfCreatingChar = 30;

	public int AgeShowBeard1 = 20;

	public int AgeShowBeard2 = 30;

	public int AgeShowWrinkle1 = 60;

	public int AgeShowWrinkle2 = 70;

	public int AgeShowWrinkle3 = 50;

	public int AvatarNoneFeatureObb = 5000;

	public int AvatarHasFeature1Obb = 2500;

	public int AvatarHasFeature2Obb = 2500;

	public int AvatarBadFeatureObb = 500;

	public int AvatarNoneBeardObb = 2500;

	public byte AvatarFurColorSplitObb = 10;

	public byte[] AvatarFurColorSplitObbArray = new byte[4] { 20, 40, 30, 10 };

	public int AvatarChanceMutation = 1000;

	public float EyebrowRatioInBaseCharm = 0.2f;

	public float EyesRatioInBaseCharm = 0.4f;

	public float NoseRatioInBaseCharm = 0.2f;

	public float MouthRatioInBaseCharm = 0.2f;

	public const byte MaxReferenceBookSlotCount = 3;

	public byte[] NameLengthConfig_CN = new byte[2] { 2, 2 };

	public byte[] NameLengthConfig_EN = new byte[2] { 6, 6 };

	public string[] FiveElementsTypeColor = new string[6] { "yellow", "darkpurple", "darkcyan", "red", "lightgreen", "white" };

	public short CombatSkillMaxBasePower = 100;

	public const sbyte CombatSkillMinPower = 10;

	public short CombatSkillMaxPower = 9999;

	public const sbyte CombatSkillRequirementMinPercent = 10;

	public short EquipmentBaseMaxPower = 180;

	public const short EquipmentMaxPower = 9999;

	public sbyte CollectResourcePercent = 33;

	public short RejuvenatedAge = 20;

	public short ImmaturityAttraction = 400;

	public short MaskOrVeilAttraction = 400;

	public byte CricketActiveStartMonth = 7;

	public byte CricketActiveEndMonth = 10;

	public byte[] CricketSingGroupCricketCountMin = new byte[3] { 3, 3, 3 };

	public byte[] CricketSingGroupCricketCountMax = new byte[3] { 6, 6, 6 };

	public float[] CricketSingGroupStartTimeMin = new float[3] { 0.5f, 10f, 12.5f };

	public float[] CricketSingGroupStartTimeMax = new float[3] { 7.5f, 15f, 22.5f };

	public byte[] CricketSingGroupSingCountMin = new byte[3] { 2, 1, 0 };

	public byte[] CricketSingGroupSingCountMax = new byte[3] { 4, 3, 2 };

	public float CricketSingBaseTimeMin = 0.5f;

	public float CricketSingBaseTimeMax = 1f;

	public float CricketSingGradeTime = 0.1f;

	public float CricketSingDelayTimeMin = 0.5f;

	public float CricketSingDelayTimeMax = 2f;

	public short CatchCricketSuccessSingLevel = 95;

	public const sbyte AreaPerState = 9;

	public const sbyte NormalAreaPerState = 3;

	public const byte BrokenAreaWidth = 5;

	public short[] OrgCharBaseInfluencePowers = new short[9] { 10, 20, 30, 50, 70, 90, 120, 160, 210 };

	public const short OrgMaxApprovingRate = 1000;

	public short MarkLocationBaseMaxCount = 10;

	public const sbyte StatesCount = 15;

	public const sbyte LargeSectsCount = 15;

	public short RecoveryOfQiDisorderUnitValue = 40;

	public ushort ShrineAuthorityPerTime = 200;

	public short[] GraveDurabilities = new short[4] { 6, 12, 36, 72 };

	public short[] GraveLevelMoneyCosts = new short[4] { 0, 1000, 3000, 9000 };

	public sbyte ShrineAuthorityAddMonth = 1;

	public const sbyte BuildingOperatorMaxCount = 3;

	public const sbyte ShopManagerMaxCount = 7;

	public const sbyte BuildingOptionAutoGiveMemberPresetCount = 9;

	public const sbyte BuildingOptionAutoGiveMemberPresetActiveCount = 3;

	public sbyte TaiwuVillagerMaxPotential = 36;

	public short MinValueOfMaxMainAttributes = 1;

	public short MaxValueOfMaxMainAttributes = 9999;

	public short MinValueOfAttackAndDefenseAttributes = 20;

	public short MinAValueOfMinorAttributes = 20;

	public const short MaxValueOfMinorAttributes = 1000;

	public sbyte[] AvatarElementGrowthDurations = new sbyte[7] { 18, 12, 12, 0, 0, 0, 18 };

	public sbyte BaseHobbyChangingPeriod = 4;

	public List<short[]> LifeSkillCombatPowerWave = new List<short[]>
	{
		new short[3] { 100, 100, 100 },
		new short[3] { 80, 100, 120 },
		new short[3] { 110, 80, 110 },
		new short[3] { 80, 140, 80 },
		new short[3] { 120, 100, 80 }
	};

	public List<byte[]> LifeSkillCombatAISwingRange = new List<byte[]>
	{
		new byte[2] { 1, 2 },
		new byte[2] { 2, 4 },
		new byte[2] { 1, 4 },
		new byte[2] { 2, 4 },
		new byte[2] { 1, 2 }
	};

	public sbyte DisasterAdventureSpawnChance = 35;

	public sbyte[] DisasterTriggerRanges = new sbyte[4] { 0, 1, 2, 3 };

	public short[] DisasterTriggerNeighborSumThresholds = new short[4] { 100, 155, 290, 425 };

	public sbyte[] DisasterTriggerCurrBlockThresholds = new sbyte[4] { 100, 75, 50, 25 };

	public sbyte[] BrokenAreaEnemyCountLevelDist = new sbyte[3] { 6, 4, 2 };

	public static readonly sbyte[] ResourcesWorth = new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 10 };

	public static readonly short[] UnitsOfResourceTransfer = new short[8] { 20, 20, 20, 20, 20, 20, 100, 10 };

	public short[] WorthFactorsOfGrade = new short[9] { 1, 2, 4, 8, 16, 32, 64, 128, 256 };

	public short MinFavorabilityAfterTransferring = 14000;

	public short KidnapSlotBaseMaxCount = 1;

	public sbyte ResistChangeOnKidnapCharacterTransfer = 20;

	public sbyte AdventureNodePersonalityMinCost = 1;

	public sbyte AdventureNodePersonalityMaxCost = 10;

	public sbyte ChickenMiscTaste = 20;

	public float ChickenEscapeRate = 0.1f;

	public sbyte ChickenDecayMin = 1;

	public sbyte ChickenDecayMax = 2;

	public sbyte SamsaraPlatformMaxProgress = 18;

	public sbyte SamsaraPlatformBornInSectOdds = 75;

	public sbyte SamsaraPlatformAddBasePercent = 2;

	public sbyte SamsaraPlatformAddPercentPerLevel = 3;

	public sbyte[] LegacyGroupLevelThresholds = new sbyte[4] { 0, 30, 60, 120 };

	public int SelectRandomLegacyCost = 500;

	public short MixiangzhenLifeSkillAdjustBonus = 70;

	public int MixiangzhenLifeSkillAdjustTypeCount = 3;

	public short XiuluochangCombatSkillAdjustBonus = 70;

	public int XiuluochangCombatSkillAdjustTypeCount = 3;

	public short RecruitPeopleCost = 3000;

	public sbyte EquipmentWithEffectRate = 25;

	public sbyte ComfortableHouseCapacity = 3;

	public short[] FixBookTotalProgress = new short[9] { 150, 200, 300, 500, 800, 1200, 1800, 2600, 3600 };

	public short[] SwordTombAdventureLastMonthCount = new short[4] { -99, 108, 72, 36 };

	public static readonly short[] SwordTombAdventureCountDownCoolDown = new short[4] { 36, 12, 6, 3 };

	public const sbyte MartialArtTournamentInterval = 108;

	public const sbyte MartialArtTournamentPreparationDuration = 12;

	public const sbyte MartialArtTournamentWaitMaxDuration = 6;

	public short[] SectApprovingRateUpperLimits = new short[10] { 30, 30, 40, 50, 60, 70, 80, 90, 100, 100 };

	public sbyte[] XiangshuInfectionGradeUpperLimits = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };

	public int[] LegacyImageThreshold = new int[5] { 0, 3000, 6000, 9000, 12000 };

	public int[] OtherCombatWinHappiness = new int[5] { 2, 3, 2, 3, 2 };

	public int[] OtherCombatLoseHappiness = new int[5] { -2, -3, -2, -3, -2 };

	public int[] OtherCombatWinFavorability = new int[5] { -1200, -600, 0, -600, -1200 };

	public int[] OtherCombatLoseFavorability = new int[5] { 600, 1200, 600, 1200, 600 };

	public sbyte HarmfulActionCost = 10;

	public short HarmfulActionSuccessGlobalFactor;

	public sbyte HarmfulActionPhaseBaseSuccessRate = 90;

	public sbyte TaiwuShrineAddAuthorityFactor = 5;

	public sbyte[] XiangshuInfectionAddSpeed = new sbyte[3] { 5, 3, 1 };

	public sbyte DirectPageAddInjuryOdds = 40;

	public sbyte ReversePageNoInjuryOdds = 60;

	public sbyte[] AddAttainmentPerGrade = new sbyte[9] { 10, 10, 15, 20, 20, 25, 30, 40, 50 };

	public short TakeItemFromPrisonerMaxCount = 9999;

	public int[] EquipLoadSpeedPercent = new int[3] { 80, 50, 20 };

	public int[] EquipHealSpeedPercent = new int[3] { 110, 125, 140 };

	public const byte NeiliAllocationChangeMinValue = 1;

	public int CombatNeiliAllocationAutoAddTotalProgress = 24000;

	public int CombatNeiliAllocationAutoReduceTotalProgress = 18000;

	public int CombatSkillNeiliAllocationBonusPercent = 25;

	public const int MaxPoisonedValue = 25000;

	public const int MixPoisonAffectCountMin = 1;

	public const int MixPoisonAffectCountMax = 4;

	public int[] TalkByPraiseOrSneerMaxDegree = new int[5] { 5, 4, 3, 5, 5 };

	public int[] TalkByPraiseOrSneerPerDegreeFavorability = new int[5] { 120, 150, 200, 120, 120 };

	public int[] TalkByPraiseBehaviorRate = new int[5] { 2, 3, 4, -2, 3 };

	public int[] TalkBySneerBehaviorRate = new int[5] { -2, -3, -4, 2, -3 };

	public int[] MourningMoneyCost = new int[4] { 50, 100, 300, 900 };

	public int[] UpgradeGraveMoneyCost = new int[3] { 1000, 3000, 9000 };

	public sbyte[] RobGraveEventWeight = new sbyte[3] { 50, 40, 20 };

	public sbyte ReadingFinishedBookExpGainPercent = 20;

	public short WeaponCdExtraWeight = 150;

	public short AgeShowWhiteHair = 60;

	public int ThreatenDifficultyFactorOfGrade = 6;

	public int[] ThreatenDifficultyFactorOfBehaviorType = new int[5] { 18, 12, 6, 12, 18 };

	public int[] ThreatenDifficultyFactorOfPositiveFavorType = new int[5] { 0, -300, -200, 300, 200 };

	public int[] ThreatenDifficultyFactorOfNegativeFavorType = new int[5] { -200, -300, 200, -300, 0 };

	public int ThreatenEffectFactorOfSortValue = 2;

	public int ThreatenEffectFactorOfHolderCount = 30;

	public int ThreatenEffectDenominatorOfCityAndTown = 3;

	public int ThreatenEffectDenominatorOfFame = 2;

	public short RepairInCombatFrameUnit = 6;

	public int GradeFactorOfStartRelationDifficultyByThreadNeedle = 6;

	public int[] BehaviorBonusOfStartRelationDifficultyByThreadNeedle = new int[5] { 18, 6, 12, 6, 18 };

	public int[] BehaviorFactorOfStartRelationDifficultyByThreadNeedle = new int[5] { 0, 300, 200, -300, 100 };

	public int GradeFactorOfEndRelationDifficultyByThreadNeedle = -6;

	public int[] BehaviorBonusOfEndRelationDifficultyByThreadNeedle = new int[5] { -18, -6, -12, -6, -18 };

	public int[] BehaviorFactorOfEndRelationDifficultyByThreadNeedle = new int[5] { 0, -300, -200, 300, -100 };

	public int SortValueFactorOfStartRelationEffectByThreadNeedle = 4;

	public int FameFactorPromotedOfStartRelationEffectByThreadNeedle = 4;

	public int FameFactorNominatedOfStartRelationEffectByThreadNeedle = 2;

	public int LifeSkillBattlePrimaryCardMaxUsedCount = 18;

	public int LifeSkillBattleMiddleCardMaxUsedCount = 9;

	public int LifeSkillBattleHighCardMaxUsedCount = 3;

	public int LegendaryBookUnlockBreakPlateTime = 10;

	public int[] LegendaryBookUnlockExp = new int[24]
	{
		500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000,
		5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000,
		10500, 11000, 11500, 12000
	};

	public sbyte[] LegendaryBookAppearAmounts = new sbyte[6] { 0, 1, 2, 4, 8, 14 };

	public sbyte LegendaryBookAppearChance = 33;

	public int[] RequestLegendaryBookRequireRankWhenOwningBook = new int[5] { 40, 80, 20, 10, 5 };

	public int[] RequestLegendaryBookRequireRankWhenShocked = new int[5] { 24, 48, 12, 6, 3 };

	public int[] AcceptLegendaryBookAsGiftRequireRank = new int[5] { 5, 25, 100, 1000, 500 };

	public sbyte InsectDetectionGenerationCount = 2;

	public sbyte[] FindTreasureGradeRate = new sbyte[9] { 40, 35, 30, 25, 20, 15, 10, 5, 1 };

	public int ChoosyResourceBaseCost = 1000;

	public short[] PoisonLevelThresholds = new short[3] { 500, 3500, 12500 };

	public const int MaxPoisonResistance = 1000;

	public int AccessoryReducePoisonPercent = 100;

	public int AllocatedNeiliEffectPercent = 100;

	public sbyte NpcBreakoutBaseSuccessRate = 40;

	public sbyte SectAccessoryBonusCombatSkillPower = 20;

	public const int VillageWorkQualificationImproveLimit = 30;

	public sbyte AnimalSamsaraChance = 10;

	public short EnemyNestKidnappedCharHealthChange = -12;

	public const int ResourceLimit = 999999999;

	public const int EventLogLimit = 99;

	public const int ConsummateLevelUpperLimit = 18;

	public static readonly short[] CombatSkillPageReverseProb = new short[3] { 50, 25, 75 };

	public sbyte MaxConsummateLevel = 18;

	public int MaxCarrierTamePoint = 100;

	public int LearnCombatSkillPracticeLevelParam = 50;

	public int[] CombatSkillPracticeLevelBonusRequirements = new int[5] { 0, 30, 100, 210, 360 };

	public int[] CombatSkillPracticeLevelBonus = new int[5] { 1, 2, 3, 4, 5 };

	public int[] PersuadePrisonerNeedFrame = new int[9] { 25, 30, 40, 50, 60, 70, 80, 90, 100 };

	public int FiveLoongDlcMinionLoongMaxCount = 12;

	public int FiveLoongDlcMaxDebuffCount = 99;

	public int JiaoEggIncubationTime = 3;

	public int JiaoBreedingTime = 3;

	public int InitJiaoEggDropRate = 20;

	public int InitMaleJiaoEggDropRate = 50;

	public int[] BringUpJiaoCalcParam = new int[3] { 100, 50, 1 };

	public int[] BringUpJiaoBehaviorParam = new int[5] { 60, 40, 80, 150, 120 };

	public int BurriedScalesOfEachLoongArea = 18;

	public int BurriedEggsOfEachLoongArea = 3;

	public int JiaoEggDropRateUpPerMiss = 20;

	public int JiaoTamePointAddWhenCaught = 15;

	public int BuildingResourceYieldLevelAttenuationPercent = 80;

	public int[] JiaoLoongCarrierPropertyFactor = new int[2] { 60, 40 };

	public int[] JiaoLoongGiftPropertyFactor = new int[2] { 45, 30 };

	public int[] JiaoLoongPresentPropertyFactor = new int[2] { 30, 20 };

	public int[] JiaoInitialTamePoint = new int[2] { 50, 70 };

	public int[] JiaoFleeBehaviorInfluence = new int[5] { 60, 40, 80, 150, 120 };

	public int[] JiaoPropertyChangeBehaviorInfluence = new int[5] { 80, 50, 100, 200, 150 };

	public int DefeatLoongGetScaleCount = 9;

	public int RequiredLoongScaleForFirstTimeEvolution = 9;

	public int RequiredLoongScaleForEvolution = 3;

	public int JiaoEggGenderModification = 25;

	public int TaiwuVillageMoneyPrestigeCompensation = 10;

	public int PettingJiaoAddsTamingPoints = 15;

	public int PettingJiaoFunctionCoolDuration = 3;

	public sbyte[] BaseCricketGrade = new sbyte[9] { 0, 0, 0, 1, 2, 3, 4, 4, 5 };

	public sbyte[] BaseCricketWagerGrade = new sbyte[9] { 0, 1, 2, 2, 3, 4, 4, 5, 6 };

	public int EclecticDivisor = 150;

	public int PureEclecticDivisor = 75;

	public int CharGradeDecrement = -2;

	public int[] CombatResourceDropParam = new int[9] { 100, 200, 400, 700, 900, 1400, 2000, 4000, 7000 };

	public int WugJugRefiningCostPoison = 10000;

	public int WugJugRefiningCostPoisonBonusPercent = 100;

	public int WugJugRefiningCostPoisonMonthPercent = -50;

	public int WugJugPoisonDropRatio = 10;

	public int[] FoodGradeAddCarrierDurability = new int[9] { 30, 30, 30, 60, 60, 60, 90, 90, 90 };

	public int LikeFoodAddCarrierDurability = 30;

	public int DislikeFoodAddCarrierDurability = -30;

	public int WuxianSpiritualDebtInteractionRemoveWugCount = 3;

	public short WuxianSpiritualDebtInteractionChangeWugKingDuration = -12;

	public int BuildingTotalAttainmentFinalDivisor = 3;

	public int BuildingSoldItemExtraAddFactor = 40;

	public int BuildingOutputRandomFactorUpperLimit = 120;

	public int BuildingOutputRandomFactorLowerLimit = 80;

	public int[] ReferenceBookSlotUnlockParams = new int[3] { 0, 200, 400 };

	public int RandomEnemyEscapeConsummateLevelGap = 4;

	public sbyte[] ShopManagerLearnSkillMaxGrades = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };

	public sbyte ShopManagerLearnRandomGradeChance = 25;

	public int LifeSkillBookRefBonus = 15;

	public int SameTypeBookRefBonus = 30;

	public int AddMemberFeatureMinGrade = 3;

	public int MaxTreasuryGuardCount = 3;

	public sbyte MaxTreasuryGuardGrade = 7;

	public int TreasuryGuardTeammateCdBonus = -80;

	public int TreasuryGuardPropertyPercent = 75;

	public int TreasuryGuardAttainmentPercent = 150;

	public int HostileOperationTakeItemCostTime = 5;

	public int HostileOperationTakeItemMaxResourceFactor = 5;

	public short MaxActiveReadingProgress = 30;

	public short MaxActiveNeigongLoopingProgress = 30;

	public short MaxExtraNeiliAllocation = 50;

	public short ExtraNeiliAllocationFromProgressRatio = 55;

	public short MaxQiArtStrategyCount = 3;

	public sbyte[] CharacterGradeAlertness = new sbyte[9] { 1, 1, 2, 2, 3, 3, 4, 4, 5 };

	public short ActiveReadingAttributeCost = 3;

	public short ActiveNeigongLoopingAttributeCost = 3;

	public short ActiveReadingTimeCost = 1;

	public short ActiveNeigongLoopingTimeCost = 1;

	public float MouseTipDelayTime = 0.2f;

	public int[] ReferenceSkillSlotUnlockParams = new int[3] { 0, 200, 400 };

	public sbyte BaseLoopingEventProbability = 20;

	public short[] PlotHarmActionAttainmentThresholds = new short[6] { 30, 60, 150, 210, 360, 450 };

	public short[] PoisonActionAttainmentThresholds = new short[3] { 60, 210, 450 };

	public short ExtraNeiliAllocationFromProgressRatioGrowth = 5;

	public short[] ActiveReadProgressAffectedEfficiency = new short[3] { 150, 100, 50 };

	public short[] ActiveLoopProgressAffectedEfficiency = new short[3] { 150, 100, 50 };

	public int InscriptionCharForCreationMaxCount = 100;

	public int SettlementTreasuryGetItemMaxCount = 9;

	public int SettlementTreasuryGiveItemMaxCount = 9;

	public sbyte BaihuaLifeLinkRemoveCharacterCooldown = 6;

	public sbyte FulongFlameDamage = 1;

	public sbyte FulongMineDamage = 2;

	public sbyte FulongMineDamageTaiwu = 4;

	public int SettlementAlterTime = 6;

	public short[] PoisonByToxicologyAttainmentThresholds = new short[9] { 50, 100, 150, 200, 210, 300, 360, 450, 600 };

	public int CondensedPoisonValueBonus = 50;

	public int CondensePoisonRequiredAttainmentBonus = 50;

	public int FulongFlameExtinguishCost = 1;

	public short VillagerRoleFarmerMigrateMinResource = 120;

	public short VillagerRoleFarmerMigrateBaseSuccessRate = 10;

	public int FulongFlameBoomNumber = 6;

	public int FulongFlameExtinguishTime = 5;

	public int ProfessionSkillRecoverActionPointLimit = 300;

	public int[] ConsummateLevelPoints = new int[9] { 5, 10, 15, 20, 25, 30, 35, 45, 55 };

	public int[] ConsummateLevelProgressSpeed = new int[9] { 127, 150, 187, 240, 315, 390, 510, 660, 975 };

	public int[] ConsummateLevelProgressThreshold = new int[18]
	{
		400, 800, 1200, 1600, 2000, 2400, 2800, 3200, 3600, 4000,
		4400, 4800, 5200, 5600, 6000, 6400, 6800, 7200
	};

	public short[] TravelingBuddhistMonkSkill2QualificationDelta = new short[9] { 3, 3, 3, 2, 2, 2, 1, 1, 1 };

	public int TeachSkillBookSelctMaxCount = 9;

	public int TeachSkillCharacterMaxCount = 12;

	public short[] GearMateRepairInjuryAttainmentRequirement = new short[6] { 30, 60, 120, 210, 330, 480 };

	public short[] GearMateRepairPoisonAttainmentRequirement = new short[3] { 60, 210, 480 };

	public short[] GearMateRepairDisorderOfQiAttainmentRequirement = new short[5] { 0, 60, 210, 480, 480 };

	public int BaseRefBonusSpeed = 30;

	public int ProfessionSeniorityPerMonth = 10000;

	public int TaiwuBubbleBoxDisplayRequirement = 15;

	public int HunterSkill2_OddFormulaFactorA = 20;

	public int HunterSkill2_OddFormulaFactorB = 20;

	public List<byte[]> HunterSkill2_AnimalCountIndexToAnimalConsummateLevelList = new List<byte[]>
	{
		new byte[4] { 0, 2, 4, 6 },
		new byte[4] { 4, 6, 8, 10 },
		new byte[4] { 8, 10, 12, 14 }
	};

	public short[] HunterSkill2_SeniorityPercentToAnimalCount = new short[3] { 80, 90, 100 };

	public int[] TeachProfessionSkillSeniority = new int[4] { 3000, 12000, 36000, 72000 };

	public short KidnapResistanceBonusInPrison = 100;

	public short SavageSkill3_OpenItemSelectTimeCost = 10;

	public short GiveProfessionInformationFactorWithExtraSeniority = 50;

	public const short CharacterTeachTaiwuProfessionCoolDown = 12;

	public int DoctorSkill3_HealthTransferPercent = 50;

	public int DoctorSkill3_FavorabilityChangePercent = 500;

	public short[] VillagerInfluencePowerRankingRatio = new short[9] { 1, 2, 3, 5, 8, 12, 17, 22, 30 };

	public int[] TeaWineEffectDisorderOfQiDelta = new int[2] { 50, 150 };

	public short ProfessionInitialFavorabilitiesImprovePercent = 33;

	public short TownPunishmentSeverityCustomizeDuration = 36;

	public short SpiritualDebtInteractionRanshanMaxReadingCount = 9;

	public short SpiritualDebtInteractionRanshanMaxNeigongLoopingCount = 7;

	public int[] KongsangCharacterFeaturePoisonedProbParm = new int[2] { 25, 5 };

	public int[] BaseCombatSkillPracticeProficiencyDelta = new int[2] { 3, 6 };

	public int[] CombatSkillPracticeActionPointCost = new int[2] { 200, 5 };

	public int ImprisonInStoneHouseChance = 33;

	public short MapPickupResourceCountRandomFactor = 25;

	public byte MapPickupItemGradeRandomFactor = 1;

	public byte MapPickupHasXiangshuMinionProbability = 25;

	public int[] MakeItemStageAttainmentFactor = new int[3] { 100, 150, 200 };

	public sbyte ModifySeverityDefaultRange = 1;

	public int ModifySeverityCostFactor = 1000;

	public short[] TeaHorseCaravanLevelToAwareness = new short[20]
	{
		100, 150, 200, 300, 400, 500, 600, 700, 800, 1000,
		1200, 1400, 1600, 1900, 2200, 2500, 2800, 3200, 3600, 4000
	};

	public List<ResourceInfo> ResidentUnlockCost = new List<ResourceInfo>
	{
		new ResourceInfo(1, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(1, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(1, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(1, 1000)
	};

	public List<ResourceInfo> WarehouseUnlockCost = new List<ResourceInfo>
	{
		new ResourceInfo(2, 1000),
		new ResourceInfo(7, 500),
		new ResourceInfo(1, 1000),
		new ResourceInfo(5, 1000),
		new ResourceInfo(0, 1000),
		new ResourceInfo(3, 1000),
		new ResourceInfo(6, 5000),
		new ResourceInfo(4, 1000)
	};

	public List<ResourceInfo> ComfortableHouseUnlockCost = new List<ResourceInfo>
	{
		new ResourceInfo(6, 25000),
		new ResourceInfo(7, 2500)
	};

	public int VowRewardResourceBasePrice = 10000;

	public int VowFinishedSectStoryAuthorityPercent = 50;

	public sbyte[] MainStoryHelpSectApprovedGrades = new sbyte[4] { 0, 1, 2, 3 };

	public int[] MainStoryHelpSectApprovedCounts = new int[4] { 3, 2, 1, 1 };

	public int MainStoryHelpSectAddSpiritualDebt = 1000;

	public int MainStoryNotHelpSectAddSpiritualDebt = -500;

	public int[] TaiwuVillageUpgradeAuthorityCosts = new int[15]
	{
		0, 2500, 5000, 7500, 10000, 12500, 15000, 17500, 20000, 25000,
		30000, 35000, 40000, 45000, 50000
	};

	public int[] RecruitCharacterGradeScoreThresholds = new int[9] { 100, 200, 300, 500, 700, 900, 1200, 1600, 2100 };

	public int ShopManageProgressBaseDelta = 650;

	public int MaxProductionProgress = 10000;

	public int[] MaterialWeightToArtisanOrder = new int[3] { 40, 60, 10 };

	public int[] InitialProductionWeight = new int[3] { 10, 60, 40 };

	public int AddOnAttainmentOfWorker = 50;

	public int AddOnAttainmentOfLeader = 150;

	public int WorkerAttainmentDivider = 3;

	public int ArtisanAttainmentFactor1 = 2;

	public int ArtisanAttainmentFactor2 = 200;

	public int MonthlyOrderProgressBase = 250;

	public int MonthlyOrderProgressFactor = 2;

	public int[] TeaWineArtisanOrderAttainmentRequirement = new int[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	public int[] CollectResourceBuildingProductivityDistanceOne = new int[4] { 100, 80, 60, 40 };

	public int CollectResourceBuildingProductivityDistanceMore = 20;

	public sbyte[] ShopBuildingSharePencent = new sbyte[2] { 20, 10 };

	public sbyte DarkRiverHugeSnakeTamePoint = 95;

	public const int CollectMaterialMinResource = 100;

	public const int CollectMaterialChanceDivider = 10;

	public const int FarmerCollectMaterialChancePercent = 20;

	public sbyte[] ExtendFavorSafetyAndCultureAreaFactor = new sbyte[3] { 20, 15, 10 };

	public int RefreshItemApCost = 50;

	public static readonly List<int[]> BreakoutMaxPowerNameValueArray = new List<int[]>
	{
		new int[9] { 0, 16, 24, 32, 40, 48, 56, 64, 72 },
		new int[9] { 0, 24, 36, 48, 60, 72, 84, 96, 108 },
		new int[9] { 0, 36, 54, 72, 90, 108, 126, 144, 162 }
	};

	public static readonly int[] EquipmentSlotCombatPower = new int[12]
	{
		500, 500, 500, 500, 500, 500, 500, 500, 500, 500,
		500, 500
	};

	public const int VillageCombatInfluenceValueFactor = 80;

	public const int VillageCombatInfluenceValueUnit = 4000;

	public const int SectCombatInfluenceValueFactor = 80;

	public const int SectCombatInfluenceValueUnit = 2000;

	public static readonly int[] CarrierDurationReduceOnRuinBlock = new int[2] { 1, 4 };

	public short VillagerSkillLegacyAttainmentRequirement = 450;

	public const int UpdateProficiencyMaxCount = 9;

	public static readonly int[] UpdateProficiencyMaxDelta = new int[2] { 6, 3 };

	public int MapDestroyedBlockPathingCost = 90;

	public const int MaximumRenameCharactersInSaveSlot = 6;

	public const int MaximumRenameCharactersInBuildings = 6;

	public const int MaximumRenameCharactersInSaveFollowers = 4;

	public const int MaximumRenameCharactersInVillagerRole = 2;

	public int GenerateXiangshuMinionAfterDisasterRangeMax = 3;

	public int GenerateXiangshuMinionAfterDisasterBase = 1;

	public int GenerateXiangshuMinionAfterDisasterGradeMinusMax = 3;

	public int GenerateXiangshuMinionAfterDisasterInDevelopedBlockProbabilityPercentage = 33;

	public const int TaoistMonkSkilll3_AgeIncreaseCooldown = 3;

	public const int TravelingTaoistMonkSkilll3_AgeIncreaseAddon = 2;

	public int TravelingEventRoadBlockDurabilityChange = 10;

	public short FulongServantBaseAttraction = 600;

	public List<int[]> ExtraLegacyPointGain = new List<int[]>
	{
		new int[7] { 200, 150, 100, 0, 0, 0, 0 },
		new int[7] { 0, 0, 0, 0, 100, 150, 200 }
	};

	public sbyte SettlementInfluenceRange = 3;

	public int[] ResourceBlockBuildingCoreProducingCooldown = new int[2] { 3, 6 };

	public int[] ResourceBlockBuildingCoreProducingMaxChance = new int[2] { 10000, 30000 };

	public int GeneratedXiangshuMinionDurationFactor = 100;

	public int BrokenPerformDarkAshInfectorRangeMax = 3;

	public int BrokenPerformDarkAshInfectorBase = 3;

	public int DarkAshDurationOldTaosim = 6;

	public int DarkAshDurationRangeMax = 7;

	public int DarkAshDurationBase = 6;

	public const int DarkAshShouldNotify = 6;

	public const int PopulationFactor = 125;

	public static readonly int[] FuyuFaithLevel = new int[9] { 0, 1, 3, 6, 12, 18, 30, 48, 72 };

	public static readonly int[] FuyuFaithAddLevel = new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

	public static readonly int[] FuyuResourceValueMax = new int[9] { 300, 600, 1800, 4500, 9300, 16800, 27600, 42300, 61500 };

	public static readonly int[] FuyuFaithFavorByLevel = new int[9] { 600, 1200, 1800, 3000, 4200, 5400, 7200, 9000, 10800 };

	public static readonly int[] FuyuFaithAddGiftLevel = new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

	public static readonly int[] FuyuFaithDebtByLevel = new int[9] { 10, 20, 30, 50, 60, 70, 100, 110, 120 };

	public int FuyuFaithDebtFactor = 300;

	public static readonly sbyte[] FuyuFaithCountBySaveInfected = new sbyte[19]
	{
		1, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 12, 14, 17, 20, 24, 28, 33, 38
	};

	public int AppointmentCostDays = 5;

	public sbyte TaiwuVillagerSkillBreakBonusItemGradeLimit = 5;

	public short SwapSkillBreakCostExp = 5;

	public short DistantMarriageInfluencedByTaiwuFavorDelta = 15000;

	public const sbyte LearnInPracticeCountPerMonth = 1;

	public int MonthsMonthNotificationsKept = 12;

	public int SpiritualDebtInteractionChangeMoralityMax = 50;

	public int FameAbsValueForBothGoodAndBad = 50;

	public int WineTasterSkill2Factor = 10;

	public const short RequiredMinimalFavorabilityToRevelRealName = 10000;

	public int AgePercentShowWrinkle1 = 60;

	public int AgePercentShowWrinkle2 = 70;

	public int AgePercentShowWrinkle3 = 50;

	public const int NoMindGuyCount = 6;

	public int[] TaiwuVillagerSkillBreakBonusItemGradeLimitArray = new int[19]
	{
		0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
		5, 5, 6, 6, 7, 7, 8, 8, 8
	};

	public IReadOnlyDictionary<string, int> RefNameMap
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public int GetItemId(string refName)
	{
		throw new NotImplementedException();
	}

	public int AddExtraItem(string identifier, string refName, object configItem)
	{
		throw new NotImplementedException();
	}

	public void Init()
	{
		Init_AdvanceMonth();
		Init_Adventure();
		Init_Alertness();
		Init_Breakout();
		Init_Challenge();
		Init_Combat();
		Init_CricketPolymorph();
		Init_CustomProtagonist();
		Init_Debate();
		Init_EditableMerchantConst();
		Init_Exchange();
		Init_Feast();
		Init_GenTaiwuVillage();
		Init_Genetics();
		Init_Information();
		Init_Make();
		Init_MapAction();
		Init_MartialArtTournament();
		Init_PriceValue();
		Init_Profession();
		Init_Relation();
		Init_SecretInformation();
		Init_SectStory();
		Init_SettlementTreasury();
		Init_SolarTerm();
		Init_Time();
		Init_Unclassified();
	}

	private void Init_AdvanceMonth()
	{
		AbandonBabyToTaiwuVillageChance = 20;
		PrimaryGoalActionPointsPerMonth = 40;
		SecondaryGoalActionPointsPerMonth = 40;
		PrimaryGoalMaxActionPoints = 60;
		SecondaryGoalMaxActionPoints = 60;
	}

	private void Init_Adventure()
	{
		AdventureDialogContinuousTime = 2f;
		AdventureDialogFadeTime = 0.5f;
	}

	private void Init_Alertness()
	{
		AlertnessMin = -600000;
		AlertnessMax = 600000;
		AlertnessLevelRange = new int[8] { -600000, -400000, -200000, -10000, 10000, 200000, 400000, 600000 };
		AlertnessLevelEffectToChangeFavor = new int[7] { 80, 60, 40, 0, -40, -60, -80 };
		AlertnessEffectToMaxFavor = 10;
		AlertnessLevelEffectToInteractSuccessRate = new int[7] { 175, 150, 125, 100, 75, 50, 25 };
		InitialAlertnessBaseRandomRange = new int[2] { -100000, 10000 };
		InitialAlertnessForBehaviorTypeJust = new int[5] { -200000, -100000, 0, 100000, 200000 };
		InitialAlertnessForBehaviorTypeKind = new int[5] { -100000, -200000, 0, 100000, 50000 };
		InitialAlertnessForBehaviorTypeEven = new int[5] { 50000, 0, 0, 0, 50000 };
		InitialAlertnessForBehaviorTypeRebel = new int[5] { 50000, 100000, 0, -200000, -100000 };
		InitialAlertnessForBehaviorTypeEgoistic = new int[5] { 200000, 100000, 0, -100000, -200000 };
		InitialAlertnessForTaiwuFameByGoodSect = new int[7] { 100000, 50000, 10000, 0, 0, 0, 0 };
		InitialAlertnessForTaiwuFameByEvilSect = new int[7] { 0, 0, 0, 0, 10000, 50000, 100000 };
		InitialAlertnessForTaiwuFameByNeutralSect = new int[7] { 50000, 0, 0, 0, 0, 0, 50000 };
		InitialAlertnessForTaiwuFameByCivilianSettlement = new int[7] { 100000, 10000, 5000, 0, -5000, -10000, -100000 };
		InitialAlertnessChallengeModeFactorBase = 6000;
		InitialAlertnessChallengeModeFameDifferent = 5;
		InitialAlertnessChallengeModeFameConflict = 25;
		InitialAlertnessChallengeModeBehaviorDifferent = 5;
		InitialAlertnessChallengeModeBehaviorConflict = 25;
		ChangeAlertnessOnPraise = new int[5] { -5000, -10000, -2000, 5000, -5000 };
		ChangeAlertnessOnSneer = new int[5] { 5000, 5000, 2000, -10000, 5000 };
	}

	private void Init_Breakout()
	{
		BreakoutBaseAvailableStepsCount = 20;
		BreakoutMaxAvailableStepsCount = 99;
		BreakoutMinAvailableStepsCount = 3;
		BreakoutSpecialNpcStepsCount = 30;
		BreakoutShowNormalCellBaseOdds = 20;
		BreakoutShowSpecialCellBaseOdds = 60;
		BreakoutShowBonusCellBaseOdds = 20;
		BreakoutBonusAddPowerCorrectionFactor = 50;
		SectStoryEmeiBonusNotFitProgressPercent = 10;
		SectStoryEmeiBonusMinProgress = 1;
		SectStoryEmeiBonusProgressPerCount = 30750;
		SectStoryEmeiBonusProgressRecyclePercent = 50;
		SkillProficiencyIsEnoughToGainLegacyPoint = 300;
		LuohanRelationTypeAttainment = 450;
		LuohanMaxPowerBase = 60;
		LuohanMaxPowerGradeFactor = 15;
		LuohanMaxPowerQualificationFactor = 20;
		LegendaryBookYangAddStepNormal = 5;
		LegendaryBookYinAddStepGoneMad = 5;
	}

	private void Init_Challenge()
	{
		ChallengeCharacterWealthCreateRate = 50;
		ChallengeTreasurySupplyRate = 50;
		ChallengeShopItemPriceBonus = new int[7] { 25, 50, 75, 100, 150, 250, 400 };
		ChallengeExchangeAdvantageBonus = 50;
		ChallengeTaiwuVillageBaseSpaceReduce = 20;
		ChallengeProfessionSkillLearnScores = new int[4] { 1, 3, 9, 27 };
		ChallengeProfessionSkillLearnExpMultiplier = 1000;
		ChallengeInfectedDemonMinionPerMonth = 1;
		ChallengeInfectedDemonInitMinion = 3;
		ChallengeInfectedDemonMaxMinion = 10;
		ChallengeInfectedDemonMinionRange = 2;
		ChallengeInfectedDemonInterval = 36;
		ChallengeCostResourceLeaveVillageThreshold = -10000;
		ChallengeCostResourceFavorFactor = 3f;
		ChallengeCostResourceResourceFactorFood = 10;
		ChallengeCostResourceResourceFactorWood = 10;
		ChallengeCostResourceResourceFactorMetal = 10;
		ChallengeCostResourceResourceFactorJade = 10;
		ChallengeCostResourceResourceFactorFabric = 10;
		ChallengeCostResourceResourceFactorHerb = 10;
		ChallengeCostResourceResourceFactorMoney = 2;
		ChallengeCostResourceResourceFactorAuth = 20;
		ChallengeCricketFairCombatMaxPointByWagerGrade = new int[9] { 8, 16, 24, 32, 40, 48, 56, 64, 72 };
		ChallengeCricketFairCombatCostByCricketGrade = new int[9] { 0, 0, 0, 1, 2, 4, 8, 16, 32 };
		ChallengeExchangeGradeBonusNpc = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };
		ChallengeExchangeGradeBonusTreasury = new int[9] { 0, 0, 50, 0, 0, 350, 0, 0, 1000 };
		ChallengeEffectDamageFactor = new DamageStepCollection(200, 200, 160, 180, 180, 180, 180, 200, 200, 160, 180, 180, 180, 180, 200, 160);
	}

	private void Init_Combat()
	{
		MysteryMinCompatibilityPerCombat = 3;
		MysteryMaxCompatibilityPerCombat = 5;
		DefeatMarkQiDisorderThreshold = 1000;
		DefeatMarkQiDisorderFirstExtra = 2000;
		DefeatMarkCombatStatePower = 500;
		DefeatMarkCombatStateMaxCount = 8;
		AttackRangeMidMinDistance = 3;
		RopeRequireMinMarkCountInBeat = 16;
		RopeRequireMinMarkCountInDie = 24;
		RopeBaseHitOddsInBeat = 6;
		RopeBaseHitOddsInDie = 12;
		PoisonAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		RepairAttainments = new short[9] { 0, 10, 30, 60, 100, 150, 210, 280, 360 };
		RepairBaseResourseRequirement = new short[9] { 5, 10, 15, 25, 35, 45, 60, 75, 90 };
		MakeMadicineAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		DisassembleAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		HealInjuryPoisonSpeedMinPercent = 20;
		RecoverBreathBaseValue = 30;
		RecoverStanceBaseValue = 60;
		RecoverStanceDivisorByWeapon = new sbyte[3] { 6, 4, 2 };
		AttackSpeedFactor = 50;
		MinPrepareFrame = 9;
		UnlockAttackUnit = 18000;
		MaxChangeTrickProgress = 100;
		MaxChangeTrickProgressOnce = 1200;
		ChangeTrickMultiplierFlaw = 2;
		ChangeTrickMultiplierAcupoint = 3;
		FirstAttackAddChangeTrickProgress = 10;
		PursueAttackAddChangeTrickProgress = 3;
		AvoidChangeTrickProgressPercentByWeapon = new int[3] { 33, 66, 100 };
		BaseCriticalOdds = 60;
		AvoidAddTrickBaseOdds = 10;
		AvoidAddTrickHitOddsDivisor = 2;
		NormalAttackExtraHitOdds = 0;
		BaseAttackDamageValue = 9;
		AddBaseAttackDamageValue = 3;
		BaseSkillDamageValue = 60;
		BaseUnlockDamageValue = 30;
		BaseSpiritDamageValue = 30;
		BaseAttackOdds = 800;
		BaseMindAttackOdds = 30;
		BaseSkillAttackOdds = 30;
		BaseUnlockAttackOdds = 30;
		BaseSpiritAttackOdds = 800;
		ReduceHealthPerFatalDamageMark = new sbyte[4] { 0, 18, 36, 18 };
		MaxFatalMarkCount = 999;
		AcupointLevelRequireHitOdds = new short[3] { 100, 300, 900 };
		FlawLevelRequireHitOdds = new short[3] { 100, 600, 1800 };
		AcupointBaseKeepTime = new int[4] { 90000, 135000, 270000, 540000 };
		FlawBaseKeepTime = new int[4] { 45000, 67500, 135000, 270000 };
		FlawOrAcupointReduceBaseTime = 100;
		FlawAddDamagePercent = 40;
		ExtraFlawAddDamagePercent = 10;
		DefaultJumpThreshold = 10;
		FastWalkDistance = 60;
		MobilityRecoverSpeed = 200;
		LockingRecoverSpeed = 400;
		MaxMobility = 120000;
		ReduceJumpProgressFrame = 6;
		ReduceJumpProgressPercent = 10;
		MoveCdBase = 32;
		MoveCdFactor = 20;
		MoveCdDivisorBase = 400;
		MoveCdDivisorFactor = 45;
		AgileSkillNonJumpDirectionCostMobilityPercent = 10;
		AgileSkillBaseAddSpeed = 100;
		AgileSkillBaseAddHit = 200;
		DefendSkillBaseAddAvoid = 200;
		DefendSkillBaseAddPenetrateResist = 400;
		DefendSkillBaseFightBackPower = 150;
		DefendSkillBaseBouncePower = 25;
		DefendSkillClearManualSilenceFrameRatio = 300;
		MindMarkBaseKeepTime = 900;
		BaseMindRhythm = 6;
		BaseMindUpheavalTime = 180;
		MindUpheavalAddDamageStepPercent = 50;
		ScarMarkBaseKeepTime = 1800;
		ScarMarkProgressPerMark = 100;
		ScarMarkProgressMin = 40;
		ScarMarkProgressMax = 60;
		AttackPrepareValueFixedDelayFramePerUnit = 20;
		AttackChangeTrickHitValueAddPercent = new short[3] { 50, 200, 350 };
		AttackChangeTrickCostBlockBasePercent = new short[3] { 150, 300, 450 };
		MaxWugCount = 90;
		SpiritualDebtLimit = new int[2] { -999999999, 999999999 };
		CombatSkillInitialEquipSlotCounts = new sbyte[6] { 6, 1, 1, 1, 1, 0 };
		CharacterInitialNeili = 20;
		HomelessFavorabilityChangePerMonth = -1200;
		HomelessHappinessChangePerMonth = -15;
		HouseFavorabilityChangePerMonth = 400;
		HouseHappinessChangePerMonth = 5;
		FavorabilityChangeOnExpel = new short[5] { -20000, -15000, -10000, -15000, -20000 };
		StrengthToEquipmentLoadFactor = 10;
		EquipmentLoadBaseValue = 1500;
		TaiwuVillageForceAreaSize = 38;
		CaptureRatePerRopeGrade = 15;
		CombatGetNonMainPercent = 25;
		CombatGetExpBase = new short[19]
		{
			100, 110, 140, 190, 260, 350, 460, 590, 740, 910,
			1100, 1310, 1540, 1790, 2060, 2350, 2660, 2990, 3340
		};
		CombatGetAuthorityBase = new short[19]
		{
			5, 10, 20, 30, 45, 60, 80, 105, 130, 160,
			190, 230, 280, 340, 410, 500, 610, 760, 950
		};
		LifeSkillBattleGainRatio = 50;
		UseSwordFragmentAddXiangshuInfection = 20;
		CalcApplyItemPoisonParam = 20;
		ThrowPoisonParam = 10;
		MercyPrepareMaxTime = 2f;
		MercyAutoIgnoreTime = 6f;
		PowerDamageMax = 500;
		PowerDamageOffset = 500;
		TiredMarkAppearFrame = 540u;
		MaxPendingChickenCount = 27;
	}

	private void Init_CricketPolymorph()
	{
		CricketRoomExpPerLowMaterialBaseValue = 50;
		CricketRoomExpPerLowMaterialDecreasingValue = 3;
		CricketRoomExpPerLowMaterialMinValue = 20;
		CricketRoomExpPerHighMaterialBaseValue = 150;
		CricketRoomExpPerHighMaterialDecreasingValue = 10;
		CricketRoomExpPerHighMaterialMinValue = 50;
		CricketRoomRequireExpPerLevel = 1000;
		CricketRoomBaseLevel = 1;
		CricketRoomMaxLevel = 10;
		CricketRoomPolymorphReturnRequireLevel = 3;
		CricketRoomMakingWishRequireLevel = 10;
		CricketAgeProgressPerYear = 100;
		CricketSpiritMax = 1000;
		CricketSpiritUnit = 100;
		CricketSpiritGrowthProperties = new int[11]
		{
			10, 10, 1, 1, 1, 5, 1, 5, 5, 1,
			5
		};
		CricketSpiritGrowthDurability = 1;
		CricketCombatAddSpirit = new int[9] { 1, 2, 3, 6, 9, 12, 18, 24, 32 };
		CricketBloodDewAddSpirit = new int[9] { 10, 20, 30, 50, 80, 120, 170, 230, 300 };
		CricketPolymorphBaseRate = 5;
		CricketPolymorphAddRate = 1;
		CricketWishingDuration = 3;
		CricketWishingCostLuckPoint = 300;
		CricketWishingReturnLuckPoint = 150;
	}

	private void Init_CustomProtagonist()
	{
		CustomProtagonistMainAttributeTotalPoint = 300;
		CustomProtagonistMainAttributeMaxPoint = 90;
		CustomProtagonistMainAttributeDefaultPoint = 20;
		CustomProtagonistLifeSkillQualificationTotalPoint = 800;
		CustomProtagonistLifeSkillQualificationMaxPoint = 90;
		CustomProtagonistLifeSkillQualificationDefaultPoint = 40;
		CustomProtagonistCombatSkillQualificationTotalPoint = 700;
		CustomProtagonistCombatSkillQualificationMaxPoint = 90;
		CustomProtagonistCombatSkillQualificationDefaultPoint = 40;
		CustomProtagonistCharacterFeatureTotalPoint = 7;
	}

	private void Init_Debate()
	{
		DebateMaxGamePoint = 6;
		DebateMaxRound = 20;
		DebateLineCount = 3;
		DebateLineNodeCount = 6;
		DebateTaiwuVantageNodeCount = new int[3] { 4, 3, 2 };
		DebateCardTypeLimit = 4;
		DebateMakeMoveLimit = 1;
		DebateGetStrategyLimit = 3;
		DebatePawnStrategyLimit = 3;
		DebateGradeToBasesPercent = 5;
		DebatePawnDamageToGamePoint = 1;
		DebateSpectatorPickRange = 1;
		DebateSurrenderAttainmentFactor = 200;
		DebateSurrenderBehaviorFactor = new int[5] { 100, 80, 60, 80, 100 };
		DebateAttainmentToMaxBasesPercent = new int[2] { 85, 116 };
		DebateBasesRecoverPercent = 30;
		DebateInitialStrategyPoint = 4;
		DebateMaxStrategyPoint = 12;
		DebateStrategyPointRecover = 2;
		DebateMaxPressure = 100;
		DebatePressureStrategyRecoverPercent = 50;
		DebatePressureBasesRecoverPercent = 50;
		DebatePressureAutoIncreaseRound = 10;
		DebatePreesureAutoIncreaseValue = 10;
		DebateLowPressurePercent = 50;
		DebateMidPressurePercent = 75;
		DebateHighPressurePercent = 100;
		DebateReduceStrategyRecoverProb = new int[4] { 0, 0, 100, 100 };
		DebateReduceBasesRecoverProb = new int[4] { 0, 100, 100, 100 };
		DebateUseStrategyFailedProb = new int[4] { 0, 0, 0, 50 };
		DebateMakeMoveFailedProb = new int[4] { 0, 0, 0, 50 };
		DebatePressureDeltaInConflict = 5;
		DebateCommentStackLimit = 3;
		DebateBullyPercent = 50;
		DebateOverComePercent = 150;
		DebateCommentProb = 50;
		DebateSameSideCommentProb = 75;
		DebateOtherSideCommentProb = 25;
		DebateCommentDivider = 1200;
		DebateAddNodeEffectProb = 50;
		DebateHelpSameSideProb = 50;
		DebateHelpSameSideDivider = 600;
		DebateSurrenderFactor = 50;
		DebateMaxCanUseCards = 6;
		DebateResetCardsPressureLimit = 100;
		DebateResetCardsPressureDelta = 25;
		DebateMaxShuffleCard = 3;
		AttackLineWeight = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 2, 3 },
			new int[2] { 3, 4 },
			new int[2] { 1, 4 },
			new int[2] { 3, 4 }
		};
		MidLineWeight = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 3, 4 },
			new int[2] { 4, 5 },
			new int[2] { 1, 4 },
			new int[2] { 4, 5 }
		};
		DefenseLineWeight = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 6, 7 },
			new int[2] { 6, 7 },
			new int[2] { 1, 4 },
			new int[2] { 6, 7 }
		};
		EarlyBases = new int[5] { 50, 60, 55, 50, 40 };
		MidBases = new int[5] { 40, 50, 45, 40, 35 };
		LateBases = new int[5] { 35, 45, 40, 35, 30 };
		EarlyStrategyPoint = new List<int[]>
		{
			new int[2] { 5, 3 },
			new int[2] { 7, 4 },
			new int[2] { 6, 4 },
			new int[2] { 4, 3 },
			new int[2] { 3, 2 }
		};
		MidStrategyPoint = new List<int[]>
		{
			new int[2] { 4, 1 },
			new int[2] { 5, 2 },
			new int[2] { 3, 2 },
			new int[2] { 2, 1 },
			new int[2] { 1, 1 }
		};
		LateStrategyPoint = new List<int[]>
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		DamageLineWeight = new int[5] { 1, 1, 1, 1, 2 };
		DamagedLineWeight = new int[5] { 1, 2, 1, 1, 1 };
		StateGamePointPressureInfluence = new List<int[]>
		{
			new int[2] { 69, 19 },
			new int[2] { 59, 0 },
			new int[2] { 69, 19 },
			new int[2] { 79, 29 },
			new int[2] { 79, 39 }
		};
		StatePawnCountInfluence = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 4, 5 },
			new int[2] { 3, 4 },
			new int[2] { 2, 3 },
			new int[2] { 1, 2 }
		};
		StateRoundInfluence = new int[5] { 13, 15, 14, 13, 12 };
		EgoisticNodeEffectWeightPercent = 100;
		EvenNodeEffectMaxGradeProb = new int[5] { 80, 20, 50, 20, 50 };
		RoundBeforeEarly = 3;
		MinGradeIfEnoughBases = 6;
		ZeroGradePawnProb = new int[3] { 90, 80, 60 };
		MakeMoveOnOverwhelmingLineProb = 80;
		RemoveStrategyTargetPawnBasesPercent = 20;
		Taoism3CanUseCardLimit = new int[3] { 1, 3, 0 };
		Math1CanUseCardLimit = new int[3] { 3, 0, 0 };
		ResetStrategyUsedCardLimit = 3;
	}

	private void Init_EditableMerchantConst()
	{
		MerchantFavorabilityUpperLimits = new short[10] { 0, 0, 1, 2, 3, 4, 5, 6, 6, 6 };
		MerchantItemDebtGradeUpperLimits = new short[10] { 1, 1, 2, 3, 4, 5, 5, 6, 7, 7 };
		MerchantFavorabilityMoneyRequirements = new int[10] { 6000, 12000, 24000, 48000, 96000, 192000, 384000, 768000, 1536000, 3072000 };
		MerchantFavorabilityXiangshuLevelRequirements = new int[10] { 0, 0, 2, 4, 6, 8, 10, 12, 14, 16 };
		MerchantCharFavorabilityBuyEffect = new int[13]
		{
			25, 20, 15, 10, 5, 0, 0, 0, -5, -10,
			-15, -20, -25
		};
		MerchantCharFavorabilitySellEffect = new int[13]
		{
			-10, -8, -6, -4, -2, 0, 0, 0, 2, 4,
			6, 8, 10
		};
		MerchantDebtLevelLimit = new int[7] { -1, 316500, 305700, 274200, 199800, 124200, 0 };
		MerchantOverFavorBuyCount = new short[7] { -1, 12, 9, 6, 3, 2, 1 };
		CaravanRobbedEventWinAddMerchantFavorability = new int[7] { 2700, 6750, 13950, 25200, 41400, 36450, 92250 };
		CaravanRobbedEventLoseReduceIncomeBonus = 33;
		CaravanIncomeCriticalResultRange = new short[2] { 150, 300 };
		CaravanRobbedEventEndReduceRobbedRate = 50;
		InvestCaravanNeedMoney = new int[6] { 5000, 10000, 20000, 40000, 80000, 160000 };
		InvestedCaravanAvoidRobbedNeedAuthorityFactor = new int[6] { 5, 10, 20, 40, 80, 160 };
	}

	private void Init_Exchange()
	{
		ExchangeTreasuryLevelGrade = new int[3] { 2, 5, 8 };
		ExchangeBarRangeP1 = 72901f;
		ExchangeFavorLevel = new int[13]
		{
			0, 0, 0, 0, 0, 25, 50, 100, 200, 350,
			550, 700, 1000
		};
		ExchangeAlertnessLevel = new int[7] { 0, 0, 0, 50, 200, 550, 1000 };
		ExchangeMoralitySame = 0;
		ExchangeMoralitySimilar = 25;
		ExchangeMoralityOpposite = 50;
		ExchangeFameValueForGood = new int[7] { 0, 0, 0, 0, 0, 50, 100 };
		ExchangeFameValueForNeutral = new int[7] { 50, 25, 0, 0, 0, 25, 50 };
		ExchangeFameValueForBad = new int[7] { 100, 50, 0, 0, 0, 0, 0 };
		ExchangeSpecialGender = 50;
		ExchangeSpecialLackResource = 200;
		ExchangeBaseTaiwu = 100;
		ExchangeBaseNormalNpc = 200;
		ExchangeBaseSectNpc = 300;
		ExchangeBaseTreasury = 400;
		ExchangeSecretAdvantageBonus = 5;
		ExchangeApproveAdvantageBonus = 5;
		ExchangeDebtUnit = 5;
		ExchangeGradeOverProgress = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };
		GetPrisonerHappinessChange = new int[9] { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
		GetPrisonerFavorChange = new int[9] { 600, 1200, 1800, 3000, 4200, 5400, 7200, 9000, 10800 };
	}

	private void Init_Feast()
	{
		FeastCount = 3;
		FeastDurability = 3;
		FeastGiftCount = 30;
		FeastBaseHappiness = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		FeastBaseFaovr = new List<int> { 60, 120, 180, 300, 420, 540, 720, 900, 1080 };
		FeastBuildingLevelHappinessPercent = new List<int> { 50, 100, 150 };
		FeastBuildingLevelFavorPercent = new List<int> { 100, 200, 300 };
		FeastLoveItemHappinessPercent = 50;
		FeastLoveItemFavorPercent = 100;
		FeastLoveItemGiftAddOn = 1;
		FeastLowHappiness = 40;
		FeastGiftGradeFactor = new int[2] { -3, -2 };
		FeastGiftResourcePercent = new int[2] { 8, 12 };
		FeastGiftMoneyPercent = new int[2] { 40, 60 };
		FeastGiftResourceAddon = new int[2] { 50, 100 };
	}

	private void Init_Genetics()
	{
		MainAttributeWeightsTable = new WeightsSumDistribution(42, 6, 10, 17, 30, 51, 90, 153, 270, 459);
		CombatSkillQualificationWeightsTable = new WeightsSumDistribution(84, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);
		LifeSkillQualificationWeightsTable = new WeightsSumDistribution(96, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);
		CongenitalMalformationProbability = 50;
	}

	private void Init_GenTaiwuVillage()
	{
		MaxTaiwuVillageAreaCreateCount = 10;
		MaxSwordTombCanSelectCount = 40;
		SwordTombRightDirectionPoint = 200;
		SwordTombNormalDirectionPoint = 200;
		SwordTombNormalDirectionOffset = 10;
		SwordTombMinimumDistance = 6;
		SwordTombFirstBestDistanceRange = new int[2] { 4, 6 };
		SwordTombNormalBestDistanceRange = new int[2] { 8, 9 };
		SwordTombBestDistanceRangePoint = 250;
	}

	private void Init_Information()
	{
		NormalInformationMaxRemainCount = 99;
		NormalInformationDefaultCostableMaxUseCount = 3;
	}

	private void Init_Make()
	{
		MakeAutoSelectToolGradeScore = new int[9] { 3, 4, 5, 7, 9, 11, 14, 18, 23 };
		MakeAutoSelectToolDestroyScore = new int[9] { 1, 3, 9, 22, 46, 84, 138, 211, 307 };
	}

	private void Init_MapAction()
	{
		HealInjuryAttainment = new short[6] { 30, 60, 120, 210, 330, 480 };
		HealPoisonAttainment = new short[3] { 60, 210, 480 };
		HealQiDisorderAttainment = new short[4] { 60, 210, 480, 480 };
		HealHealthAttainment = new short[4] { 60, 210, 480, 480 };
		HealInjuryBaseHerb = 20;
		HealInjuryBaseMoney = 100;
		HealInjuryExtraHerb = new short[6] { 10, 20, 40, 80, 160, 320 };
		HealInjuryExtraMoney = new short[6] { 50, 100, 200, 400, 800, 1600 };
		HealInjuryCostSpiritualDebt = new short[6] { 30, 60, 90, 120, 150, 180 };
		HealPoisonBaseHerb = 20;
		HealPoisonBaseMoney = 100;
		HealPoisonExtraHerb = new short[3] { 20, 80, 320 };
		HealPoisonExtraMoney = new short[3] { 100, 400, 1600 };
		HealPoisonExtraSpiritualDebt = new short[3] { 60, 120, 180 };
		HealQiDisorderHerb = new short[5] { 20, 40, 80, 160, 320 };
		HealQiDisorderMoney = new short[5] { 100, 200, 400, 800, 1600 };
		HealQiDisorderCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };
		HealHealthHerb = new short[5] { 40, 80, 160, 320, 1280 };
		HealHealthMoney = new short[5] { 200, 400, 800, 1600, 6400 };
		HealHealthCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };
		HealMoneyPercent = new short[5] { 150, 100, 200, 250, 300 };
		HealPoisonAttainmentPercent = 1000;
		HealQiDisorderAttainmentPercent = 500;
		LocationNaturalDisasterDuration = 12;
		HealHealthAttainmentPercent = 100;
	}

	private void Init_MartialArtTournament()
	{
		MartialArtTournamentPreparationValueDivider = 1000;
		MartialArtTournamentCombatPowerValueDivider = 100;
		MartialArtTournamentGoodFameRange = (25, 1000);
		MartialArtTournamentNeutralFameRange = (-25, 25);
		MartialArtTournamentBadFameRange = (-1000, -25);
	}

	private void Init_PriceValue()
	{
		JiaoMaxProperty = new int[9] { 60, 20000, 150, 150, 12, 123000, 150, 36, 21600 };
		ArtisanOrderPricePercent = 33;
		ArtisanOrderInterceptPricePercent = 300;
		ArtisanOrderInterceptDebatePricePercent = 150;
		ExchangeLegendaryBookBasePriceInCoin = 3000000;
		ExchangeBookBehaviorTypeToValuePercent = new List<int[]>
		{
			new int[2] { 200, 15 },
			new int[2] { 100, 30 },
			new int[2] { 150, 20 },
			new int[2] { 100, 30 },
			new int[2] { 200, 15 }
		};
		ExchangeBookValueDivider = 10;
		ExchangeBookValueDurabilityBasePercent = 50;
		ExchangeBookValueDurabilityFactor = 50;
		CaravanExchangeProbPenalize = 50;
		ItemContributionPercent = 100;
		ResourceContributionPercent = 200;
		WorthToLegacyPercentage = 40;
	}

	private void Init_Profession()
	{
	}

	private void Init_Relation()
	{
		HusbandAndWifeStartAdoreChance = 25;
		HusbandAndWifeStartAdoreCooldown = 6;
		GoodMarriageAgeRange = new int[2] { 20, 29 };
		LateMarriageAgeRange = new int[2] { 30, 39 };
		DistantMarriageGoodAgeChance = 5;
		DistantMarriageLateAgeChance = 15;
		DistantMarriageGoodAgeTargetGradeRange = new sbyte[2] { 1, 3 };
		DistantMarriageLateAgeTargetGradeRange = new sbyte[2] { -2, 0 };
		DistantMarriageGoodAgeTargetAgeRange = new int[2][]
		{
			new int[2] { 24, 29 },
			new int[2] { 24, 39 }
		};
		DistantMarriageLateAgeTargetAgeRange = new int[2][]
		{
			new int[2] { 34, 39 },
			new int[2] { 34, 49 }
		};
		AdoptiveRelationAgeRequirement = 14;
		BequestBookPageCompleteFactor = 3;
		BequestBookPageLostFactor = 5;
		BequestBehaviorRelationFactor = new int[5][]
		{
			new int[8] { 10, 9, 8, 7, 6, 5, 4, 3 },
			new int[8] { 10, 9, 5, 6, 8, 7, 3, 4 },
			new int[8] { 9, 10, 6, 5, 8, 7, 4, 3 },
			new int[8] { 4, 5, 7, 3, 9, 8, 6, 10 },
			new int[8] { 8, 7, 5, 6, 4, 10, 3, 9 }
		};
		BequestRelationPositiveFinalFactor = 100;
		BequestRelationNegativeFinalFactor = 100;
		BequestRelationThreshold = 1000;
		BequestProbabilityFactor1 = 8;
		BequestProbabilityFactor2 = 10;
		BequestGenerateBookPercent = 0;
		BequestPublicPercent = new int[5] { 30, 25, 20, 15, 10 };
		BequestPrivatePercent = new int[5] { 25, 30, 35, 40, 45 };
		TaiwuBaseInitialFavorabilityValue = 3000;
		NpcBaseInitialFavorabilityValue = 15000;
	}

	private void Init_SecretInformation()
	{
		SecretInformationNpcPlanDisseminateAmountFactor = 10000;
		SecretInformationBroadcastNotifyElementDisplayLimit = 4;
		SecretInformationShopCharacterCollectInAreaMaxAmount = 15;
		SecretInformationDefaultDisplaySettings = new sbyte[5] { 0, 1, 1, 1, 1 };
		SecretInformationReceivedDisseminateLevels = new short[4] { 0, 30, 50, 80 };
		SecretInformationShopCharacterFavorabilityChanges = new short[3] { 1000, 2000, 5000 };
		SecretInformationSourceCharacterAuthorityGainToCostConfigRate = 20;
		SecretInformationInPrivateMaxUseCount = 3;
		SecretInformationInBroadcastMaxUseCount = 3;
		BroadcastSecretInformationHappinessAdjust = new short[5] { 100, 133, 66, 166, 33 };
		SecretRelationFactor = new int[11]
		{
			99, 15, 99, 99, 1, 12, 3, 9, 6, 99,
			99
		};
		SecretSectFactor = new int[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };
		SecretNonSectFactor = new int[9] { 1, 2, 3, 5, 9, 12, 15, 18, 21 };
		SecretItemFactor = new int[9] { 0, 0, 0, 3, 6, 7, 33, 66, 99 };
		SecretRelationScore = new int[3] { 0, 3, 11 };
		SecretCharScore = new int[3] { 1, 3, 10 };
		SecretItemScore = new int[3] { 1, 5, 15 };
		SecretSortValueScore = new int[3] { 1, 6, 22 };
		SecretLevelRange = new int[2] { 100, 400 };
	}

	private void Init_SectStory()
	{
		ThreeVitalsInitInfection = 50;
		ThreeVitalsMinInfection = 0;
		ThreeVitalsMaxInfection = 100;
		ThreeVitalsInfectionDelta = 5;
		ThreeVitalsThresholdLow = 20;
		ThreeVitalsThresholdHigh = 80;
		ThreeVitalsDefectionBase = 50;
		ThreeVitalsDefectionExtra = 5;
		JieQingPointRequire = 50;
		WuxianDriveWugKingCostResourceType = 5;
		WuxianDriveWugKingCostResourceCount = 5000;
		WuxianDriveWugKingCooldown = 6;
		WuxianDriveWugKingCostActionPoint = 50;
		BaihuaLifeLinkTargetConsummate = 4;
		WordlessStatusChangeDuration = 3;
		WordlessStatusStep = 2;
		FeatherValueMax = 6400;
		FeatherValuePerFeather = 100;
		FeatherValueBaseMonthly = 12;
		FeatherValuePerChicken = 2;
		InitialFeatherValue = 50;
		InitialFeatherChickens = 3;
		CultivateFeatherValue = 700;
		CultivateCost = 7000;
		CultivateEnergyCost = 10;
		KingFeatherCount = 2;
		MaximumJieQingPoint = 99999;
		NormalQiwenXingtaiCount = 3;
		AdvancedQiwenXingtaiCount = 9;
		GainExtraJieqingXingyunProbability = 20;
		GainExtraJieqingXingyunValueMinInclusive = 500;
		GainExtraJieqingXingyunValueMaxExclusive = 501;
	}

	private void Init_SettlementTreasury()
	{
		TreasuryResourceSupplyRanges = new List<short[]>
		{
			new short[2] { 100, 150 },
			new short[2] { 200, 300 },
			new short[2] { 300, 450 },
			new short[2] { 400, 600 },
			new short[2] { 500, 750 }
		};
		TreasuryItemSupplyCounts = new List<sbyte[]>
		{
			new sbyte[9] { 4, 3, 2, 2, 2, 1, 1, 1, 0 },
			new sbyte[9] { 5, 4, 3, 2, 2, 2, 2, 1, 1 },
			new sbyte[9] { 6, 5, 4, 3, 3, 2, 3, 2, 1 },
			new sbyte[9] { 7, 6, 5, 4, 4, 3, 3, 3, 2 },
			new sbyte[9] { 8, 7, 6, 5, 5, 4, 4, 3, 3 }
		};
		MemberSelfImproveSpeedFactor = new List<int> { 50, 100, 200 };
		TreasuryStatusThreshold = new int[2] { 80, 120 };
		TreasuryGuardCount = 2;
		TreasuryGuardMaxGrade = new List<sbyte> { 2, 4, 6 };
		SectTreasuryGuardMaxGrade = new List<sbyte> { 3, 5, 7 };
		TreasuryRquireApprovingMid = 40;
		TreasuryRquireApprovingHigh = 70;
		TreasuryRquireSpiritualDebtMid = 400;
		TreasuryRquireSpiritualDebtHigh = 700;
		PrisonRequireApprovingMid = 400;
		PrisonRequireApprovingHigh = 700;
		TreasurySupplyLevelUpPercent = 150;
		TreasuryAlterTime = new int[3] { 3, 6, 12 };
		GuardConsummateLevel = new int[3] { 6, 10, 14 };
	}

	private void Init_SolarTerm()
	{
		SolarTermAddCombatSkillPower = 10;
		SolarTermAddHealOuterInjury = 20;
		SolarTermAddHealInnerInjury = 20;
		SolarTermAddRecoverQiDisorder = 10;
		SolarTermAddHealPoison = 20;
		SolarTermAddPoisonEffect = 20;
		SolarTermAddHealth = 20;
		SolarTermGoodsRate = new int[3] { 80, 60, 40 };
		SolarTermGoodsCountMin = 1;
		SolarTermGoodsCountMax = 2;
	}

	private void Init_Time()
	{
		ActionPointLimitPerMonth = 600;
		ActionPointRecoveryPerMonth = 300;
		MoreActionPointLimitPerMonth = 900;
		MoreActionPointRecoveryPerMonth = 450;
		GameStartDate = 8;
	}

	private void Init_Unclassified()
	{
		MapNormalBlockRange = 3;
		MapAreaOpenPrestige = 50;
		MapInitUnlockStationStateCount = 3;
		AgeBaby = 3;
		PopulationLimitRandomRateMax = 120;
		MaxAgeOfCreatingChar = 30;
		AgeShowBeard1 = 20;
		AgeShowBeard2 = 30;
		AgeShowWrinkle1 = 60;
		AgeShowWrinkle2 = 70;
		AgeShowWrinkle3 = 50;
		AvatarNoneFeatureObb = 5000;
		AvatarHasFeature1Obb = 2500;
		AvatarHasFeature2Obb = 2500;
		AvatarBadFeatureObb = 500;
		AvatarNoneBeardObb = 2500;
		AvatarFurColorSplitObb = 10;
		AvatarFurColorSplitObbArray = new byte[4] { 20, 40, 30, 10 };
		AvatarChanceMutation = 1000;
		EyebrowRatioInBaseCharm = 0.2f;
		EyesRatioInBaseCharm = 0.4f;
		NoseRatioInBaseCharm = 0.2f;
		MouthRatioInBaseCharm = 0.2f;
		NameLengthConfig_CN = new byte[2] { 2, 2 };
		NameLengthConfig_EN = new byte[2] { 6, 6 };
		FiveElementsTypeColor = new string[6] { "yellow", "darkpurple", "darkcyan", "red", "lightgreen", "white" };
		CombatSkillMaxBasePower = 100;
		CombatSkillMaxPower = 9999;
		EquipmentBaseMaxPower = 180;
		CollectResourcePercent = 33;
		RejuvenatedAge = 20;
		ImmaturityAttraction = 400;
		MaskOrVeilAttraction = 400;
		CricketActiveStartMonth = 7;
		CricketActiveEndMonth = 10;
		CricketSingGroupCricketCountMin = new byte[3] { 3, 3, 3 };
		CricketSingGroupCricketCountMax = new byte[3] { 6, 6, 6 };
		CricketSingGroupStartTimeMin = new float[3] { 0.5f, 10f, 12.5f };
		CricketSingGroupStartTimeMax = new float[3] { 7.5f, 15f, 22.5f };
		CricketSingGroupSingCountMin = new byte[3] { 2, 1, 0 };
		CricketSingGroupSingCountMax = new byte[3] { 4, 3, 2 };
		CricketSingBaseTimeMin = 0.5f;
		CricketSingBaseTimeMax = 1f;
		CricketSingGradeTime = 0.1f;
		CricketSingDelayTimeMin = 0.5f;
		CricketSingDelayTimeMax = 2f;
		CatchCricketSuccessSingLevel = 95;
		OrgCharBaseInfluencePowers = new short[9] { 10, 20, 30, 50, 70, 90, 120, 160, 210 };
		MarkLocationBaseMaxCount = 10;
		RecoveryOfQiDisorderUnitValue = 40;
		ShrineAuthorityPerTime = 200;
		GraveDurabilities = new short[4] { 6, 12, 36, 72 };
		GraveLevelMoneyCosts = new short[4] { 0, 1000, 3000, 9000 };
		ShrineAuthorityAddMonth = 1;
		TaiwuVillagerMaxPotential = 36;
		MinValueOfMaxMainAttributes = 1;
		MaxValueOfMaxMainAttributes = 9999;
		MinValueOfAttackAndDefenseAttributes = 20;
		MinAValueOfMinorAttributes = 20;
		AvatarElementGrowthDurations = new sbyte[7] { 18, 12, 12, 0, 0, 0, 18 };
		BaseHobbyChangingPeriod = 4;
		LifeSkillCombatPowerWave = new List<short[]>
		{
			new short[3] { 100, 100, 100 },
			new short[3] { 80, 100, 120 },
			new short[3] { 110, 80, 110 },
			new short[3] { 80, 140, 80 },
			new short[3] { 120, 100, 80 }
		};
		LifeSkillCombatAISwingRange = new List<byte[]>
		{
			new byte[2] { 1, 2 },
			new byte[2] { 2, 4 },
			new byte[2] { 1, 4 },
			new byte[2] { 2, 4 },
			new byte[2] { 1, 2 }
		};
		DisasterAdventureSpawnChance = 35;
		DisasterTriggerRanges = new sbyte[4] { 0, 1, 2, 3 };
		DisasterTriggerNeighborSumThresholds = new short[4] { 100, 155, 290, 425 };
		DisasterTriggerCurrBlockThresholds = new sbyte[4] { 100, 75, 50, 25 };
		BrokenAreaEnemyCountLevelDist = new sbyte[3] { 6, 4, 2 };
		WorthFactorsOfGrade = new short[9] { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
		MinFavorabilityAfterTransferring = 14000;
		KidnapSlotBaseMaxCount = 1;
		ResistChangeOnKidnapCharacterTransfer = 20;
		AdventureNodePersonalityMinCost = 1;
		AdventureNodePersonalityMaxCost = 10;
		ChickenMiscTaste = 20;
		ChickenEscapeRate = 0.1f;
		ChickenDecayMin = 1;
		ChickenDecayMax = 2;
		SamsaraPlatformMaxProgress = 18;
		SamsaraPlatformBornInSectOdds = 75;
		SamsaraPlatformAddBasePercent = 2;
		SamsaraPlatformAddPercentPerLevel = 3;
		LegacyGroupLevelThresholds = new sbyte[4] { 0, 30, 60, 120 };
		SelectRandomLegacyCost = 500;
		MixiangzhenLifeSkillAdjustBonus = 70;
		MixiangzhenLifeSkillAdjustTypeCount = 3;
		XiuluochangCombatSkillAdjustBonus = 70;
		XiuluochangCombatSkillAdjustTypeCount = 3;
		RecruitPeopleCost = 3000;
		EquipmentWithEffectRate = 25;
		ComfortableHouseCapacity = 3;
		FixBookTotalProgress = new short[9] { 150, 200, 300, 500, 800, 1200, 1800, 2600, 3600 };
		SwordTombAdventureLastMonthCount = new short[4] { -99, 108, 72, 36 };
		SectApprovingRateUpperLimits = new short[10] { 30, 30, 40, 50, 60, 70, 80, 90, 100, 100 };
		XiangshuInfectionGradeUpperLimits = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };
		LegacyImageThreshold = new int[5] { 0, 3000, 6000, 9000, 12000 };
		OtherCombatWinHappiness = new int[5] { 2, 3, 2, 3, 2 };
		OtherCombatLoseHappiness = new int[5] { -2, -3, -2, -3, -2 };
		OtherCombatWinFavorability = new int[5] { -1200, -600, 0, -600, -1200 };
		OtherCombatLoseFavorability = new int[5] { 600, 1200, 600, 1200, 600 };
		HarmfulActionCost = 10;
		HarmfulActionSuccessGlobalFactor = 0;
		HarmfulActionPhaseBaseSuccessRate = 90;
		TaiwuShrineAddAuthorityFactor = 5;
		XiangshuInfectionAddSpeed = new sbyte[3] { 5, 3, 1 };
		DirectPageAddInjuryOdds = 40;
		ReversePageNoInjuryOdds = 60;
		AddAttainmentPerGrade = new sbyte[9] { 10, 10, 15, 20, 20, 25, 30, 40, 50 };
		TakeItemFromPrisonerMaxCount = 9999;
		EquipLoadSpeedPercent = new int[3] { 80, 50, 20 };
		EquipHealSpeedPercent = new int[3] { 110, 125, 140 };
		CombatNeiliAllocationAutoAddTotalProgress = 24000;
		CombatNeiliAllocationAutoReduceTotalProgress = 18000;
		CombatSkillNeiliAllocationBonusPercent = 25;
		TalkByPraiseOrSneerMaxDegree = new int[5] { 5, 4, 3, 5, 5 };
		TalkByPraiseOrSneerPerDegreeFavorability = new int[5] { 120, 150, 200, 120, 120 };
		TalkByPraiseBehaviorRate = new int[5] { 2, 3, 4, -2, 3 };
		TalkBySneerBehaviorRate = new int[5] { -2, -3, -4, 2, -3 };
		MourningMoneyCost = new int[4] { 50, 100, 300, 900 };
		UpgradeGraveMoneyCost = new int[3] { 1000, 3000, 9000 };
		RobGraveEventWeight = new sbyte[3] { 50, 40, 20 };
		ReadingFinishedBookExpGainPercent = 20;
		WeaponCdExtraWeight = 150;
		AgeShowWhiteHair = 60;
		ThreatenDifficultyFactorOfGrade = 6;
		ThreatenDifficultyFactorOfBehaviorType = new int[5] { 18, 12, 6, 12, 18 };
		ThreatenDifficultyFactorOfPositiveFavorType = new int[5] { 0, -300, -200, 300, 200 };
		ThreatenDifficultyFactorOfNegativeFavorType = new int[5] { -200, -300, 200, -300, 0 };
		ThreatenEffectFactorOfSortValue = 2;
		ThreatenEffectFactorOfHolderCount = 30;
		ThreatenEffectDenominatorOfCityAndTown = 3;
		ThreatenEffectDenominatorOfFame = 2;
		RepairInCombatFrameUnit = 6;
		GradeFactorOfStartRelationDifficultyByThreadNeedle = 6;
		BehaviorBonusOfStartRelationDifficultyByThreadNeedle = new int[5] { 18, 6, 12, 6, 18 };
		BehaviorFactorOfStartRelationDifficultyByThreadNeedle = new int[5] { 0, 300, 200, -300, 100 };
		GradeFactorOfEndRelationDifficultyByThreadNeedle = -6;
		BehaviorBonusOfEndRelationDifficultyByThreadNeedle = new int[5] { -18, -6, -12, -6, -18 };
		BehaviorFactorOfEndRelationDifficultyByThreadNeedle = new int[5] { 0, -300, -200, 300, -100 };
		SortValueFactorOfStartRelationEffectByThreadNeedle = 4;
		FameFactorPromotedOfStartRelationEffectByThreadNeedle = 4;
		FameFactorNominatedOfStartRelationEffectByThreadNeedle = 2;
		LifeSkillBattlePrimaryCardMaxUsedCount = 18;
		LifeSkillBattleMiddleCardMaxUsedCount = 9;
		LifeSkillBattleHighCardMaxUsedCount = 3;
		LegendaryBookUnlockBreakPlateTime = 10;
		LegendaryBookUnlockExp = new int[24]
		{
			500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000,
			5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000,
			10500, 11000, 11500, 12000
		};
		LegendaryBookAppearAmounts = new sbyte[6] { 0, 1, 2, 4, 8, 14 };
		LegendaryBookAppearChance = 33;
		RequestLegendaryBookRequireRankWhenOwningBook = new int[5] { 40, 80, 20, 10, 5 };
		RequestLegendaryBookRequireRankWhenShocked = new int[5] { 24, 48, 12, 6, 3 };
		AcceptLegendaryBookAsGiftRequireRank = new int[5] { 5, 25, 100, 1000, 500 };
		InsectDetectionGenerationCount = 2;
		FindTreasureGradeRate = new sbyte[9] { 40, 35, 30, 25, 20, 15, 10, 5, 1 };
		ChoosyResourceBaseCost = 1000;
		PoisonLevelThresholds = new short[3] { 500, 3500, 12500 };
		AccessoryReducePoisonPercent = 100;
		AllocatedNeiliEffectPercent = 100;
		NpcBreakoutBaseSuccessRate = 40;
		SectAccessoryBonusCombatSkillPower = 20;
		AnimalSamsaraChance = 10;
		EnemyNestKidnappedCharHealthChange = -12;
		MaxConsummateLevel = 18;
		MaxCarrierTamePoint = 100;
		LearnCombatSkillPracticeLevelParam = 50;
		CombatSkillPracticeLevelBonusRequirements = new int[5] { 0, 30, 100, 210, 360 };
		CombatSkillPracticeLevelBonus = new int[5] { 1, 2, 3, 4, 5 };
		PersuadePrisonerNeedFrame = new int[9] { 25, 30, 40, 50, 60, 70, 80, 90, 100 };
		FiveLoongDlcMinionLoongMaxCount = 12;
		FiveLoongDlcMaxDebuffCount = 99;
		JiaoEggIncubationTime = 3;
		JiaoBreedingTime = 3;
		InitJiaoEggDropRate = 20;
		InitMaleJiaoEggDropRate = 50;
		BringUpJiaoCalcParam = new int[3] { 100, 50, 1 };
		BringUpJiaoBehaviorParam = new int[5] { 60, 40, 80, 150, 120 };
		BurriedScalesOfEachLoongArea = 18;
		BurriedEggsOfEachLoongArea = 3;
		JiaoEggDropRateUpPerMiss = 20;
		JiaoTamePointAddWhenCaught = 15;
		BuildingResourceYieldLevelAttenuationPercent = 80;
		JiaoLoongCarrierPropertyFactor = new int[2] { 60, 40 };
		JiaoLoongGiftPropertyFactor = new int[2] { 45, 30 };
		JiaoLoongPresentPropertyFactor = new int[2] { 30, 20 };
		JiaoInitialTamePoint = new int[2] { 50, 70 };
		JiaoFleeBehaviorInfluence = new int[5] { 60, 40, 80, 150, 120 };
		JiaoPropertyChangeBehaviorInfluence = new int[5] { 80, 50, 100, 200, 150 };
		DefeatLoongGetScaleCount = 9;
		RequiredLoongScaleForFirstTimeEvolution = 9;
		RequiredLoongScaleForEvolution = 3;
		JiaoEggGenderModification = 25;
		TaiwuVillageMoneyPrestigeCompensation = 10;
		PettingJiaoAddsTamingPoints = 15;
		PettingJiaoFunctionCoolDuration = 3;
		BaseCricketGrade = new sbyte[9] { 0, 0, 0, 1, 2, 3, 4, 4, 5 };
		BaseCricketWagerGrade = new sbyte[9] { 0, 1, 2, 2, 3, 4, 4, 5, 6 };
		EclecticDivisor = 150;
		PureEclecticDivisor = 75;
		CharGradeDecrement = -2;
		CombatResourceDropParam = new int[9] { 100, 200, 400, 700, 900, 1400, 2000, 4000, 7000 };
		WugJugRefiningCostPoison = 10000;
		WugJugRefiningCostPoisonBonusPercent = 100;
		WugJugRefiningCostPoisonMonthPercent = -50;
		WugJugPoisonDropRatio = 10;
		FoodGradeAddCarrierDurability = new int[9] { 30, 30, 30, 60, 60, 60, 90, 90, 90 };
		LikeFoodAddCarrierDurability = 30;
		DislikeFoodAddCarrierDurability = -30;
		WuxianSpiritualDebtInteractionRemoveWugCount = 3;
		WuxianSpiritualDebtInteractionChangeWugKingDuration = -12;
		BuildingTotalAttainmentFinalDivisor = 3;
		BuildingSoldItemExtraAddFactor = 40;
		BuildingOutputRandomFactorUpperLimit = 120;
		BuildingOutputRandomFactorLowerLimit = 80;
		ReferenceBookSlotUnlockParams = new int[3] { 0, 200, 400 };
		RandomEnemyEscapeConsummateLevelGap = 4;
		ShopManagerLearnSkillMaxGrades = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };
		ShopManagerLearnRandomGradeChance = 25;
		LifeSkillBookRefBonus = 15;
		SameTypeBookRefBonus = 30;
		AddMemberFeatureMinGrade = 3;
		MaxTreasuryGuardCount = 3;
		MaxTreasuryGuardGrade = 7;
		TreasuryGuardTeammateCdBonus = -80;
		TreasuryGuardPropertyPercent = 75;
		TreasuryGuardAttainmentPercent = 150;
		HostileOperationTakeItemCostTime = 5;
		HostileOperationTakeItemMaxResourceFactor = 5;
		MaxActiveReadingProgress = 30;
		MaxActiveNeigongLoopingProgress = 30;
		MaxExtraNeiliAllocation = 50;
		ExtraNeiliAllocationFromProgressRatio = 55;
		MaxQiArtStrategyCount = 3;
		CharacterGradeAlertness = new sbyte[9] { 1, 1, 2, 2, 3, 3, 4, 4, 5 };
		ActiveReadingAttributeCost = 3;
		ActiveNeigongLoopingAttributeCost = 3;
		ActiveReadingTimeCost = 1;
		ActiveNeigongLoopingTimeCost = 1;
		MouseTipDelayTime = 0.2f;
		ReferenceSkillSlotUnlockParams = new int[3] { 0, 200, 400 };
		BaseLoopingEventProbability = 20;
		PlotHarmActionAttainmentThresholds = new short[6] { 30, 60, 150, 210, 360, 450 };
		PoisonActionAttainmentThresholds = new short[3] { 60, 210, 450 };
		ExtraNeiliAllocationFromProgressRatioGrowth = 5;
		ActiveReadProgressAffectedEfficiency = new short[3] { 150, 100, 50 };
		ActiveLoopProgressAffectedEfficiency = new short[3] { 150, 100, 50 };
		InscriptionCharForCreationMaxCount = 100;
		SettlementTreasuryGetItemMaxCount = 9;
		SettlementTreasuryGiveItemMaxCount = 9;
		BaihuaLifeLinkRemoveCharacterCooldown = 6;
		FulongFlameDamage = 1;
		FulongMineDamage = 2;
		FulongMineDamageTaiwu = 4;
		SettlementAlterTime = 6;
		PoisonByToxicologyAttainmentThresholds = new short[9] { 50, 100, 150, 200, 210, 300, 360, 450, 600 };
		CondensedPoisonValueBonus = 50;
		CondensePoisonRequiredAttainmentBonus = 50;
		FulongFlameExtinguishCost = 1;
		VillagerRoleFarmerMigrateMinResource = 120;
		VillagerRoleFarmerMigrateBaseSuccessRate = 10;
		FulongFlameBoomNumber = 6;
		FulongFlameExtinguishTime = 5;
		ProfessionSkillRecoverActionPointLimit = 300;
		ConsummateLevelPoints = new int[9] { 5, 10, 15, 20, 25, 30, 35, 45, 55 };
		ConsummateLevelProgressSpeed = new int[9] { 127, 150, 187, 240, 315, 390, 510, 660, 975 };
		ConsummateLevelProgressThreshold = new int[18]
		{
			400, 800, 1200, 1600, 2000, 2400, 2800, 3200, 3600, 4000,
			4400, 4800, 5200, 5600, 6000, 6400, 6800, 7200
		};
		TravelingBuddhistMonkSkill2QualificationDelta = new short[9] { 3, 3, 3, 2, 2, 2, 1, 1, 1 };
		TeachSkillBookSelctMaxCount = 9;
		TeachSkillCharacterMaxCount = 12;
		GearMateRepairInjuryAttainmentRequirement = new short[6] { 30, 60, 120, 210, 330, 480 };
		GearMateRepairPoisonAttainmentRequirement = new short[3] { 60, 210, 480 };
		GearMateRepairDisorderOfQiAttainmentRequirement = new short[5] { 0, 60, 210, 480, 480 };
		BaseRefBonusSpeed = 30;
		ProfessionSeniorityPerMonth = 10000;
		TaiwuBubbleBoxDisplayRequirement = 15;
		HunterSkill2_OddFormulaFactorA = 20;
		HunterSkill2_OddFormulaFactorB = 20;
		HunterSkill2_AnimalCountIndexToAnimalConsummateLevelList = new List<byte[]>
		{
			new byte[4] { 0, 2, 4, 6 },
			new byte[4] { 4, 6, 8, 10 },
			new byte[4] { 8, 10, 12, 14 }
		};
		HunterSkill2_SeniorityPercentToAnimalCount = new short[3] { 80, 90, 100 };
		TeachProfessionSkillSeniority = new int[4] { 3000, 12000, 36000, 72000 };
		KidnapResistanceBonusInPrison = 100;
		SavageSkill3_OpenItemSelectTimeCost = 10;
		GiveProfessionInformationFactorWithExtraSeniority = 50;
		DoctorSkill3_HealthTransferPercent = 50;
		DoctorSkill3_FavorabilityChangePercent = 500;
		VillagerInfluencePowerRankingRatio = new short[9] { 1, 2, 3, 5, 8, 12, 17, 22, 30 };
		TeaWineEffectDisorderOfQiDelta = new int[2] { 50, 150 };
		ProfessionInitialFavorabilitiesImprovePercent = 33;
		TownPunishmentSeverityCustomizeDuration = 36;
		SpiritualDebtInteractionRanshanMaxReadingCount = 9;
		SpiritualDebtInteractionRanshanMaxNeigongLoopingCount = 7;
		KongsangCharacterFeaturePoisonedProbParm = new int[2] { 25, 5 };
		BaseCombatSkillPracticeProficiencyDelta = new int[2] { 3, 6 };
		CombatSkillPracticeActionPointCost = new int[2] { 200, 5 };
		ImprisonInStoneHouseChance = 33;
		MapPickupResourceCountRandomFactor = 25;
		MapPickupItemGradeRandomFactor = 1;
		MapPickupHasXiangshuMinionProbability = 25;
		MakeItemStageAttainmentFactor = new int[3] { 100, 150, 200 };
		ModifySeverityDefaultRange = 1;
		ModifySeverityCostFactor = 1000;
		TeaHorseCaravanLevelToAwareness = new short[20]
		{
			100, 150, 200, 300, 400, 500, 600, 700, 800, 1000,
			1200, 1400, 1600, 1900, 2200, 2500, 2800, 3200, 3600, 4000
		};
		ResidentUnlockCost = new List<ResourceInfo>
		{
			new ResourceInfo(1, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(1, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(1, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(1, 1000)
		};
		WarehouseUnlockCost = new List<ResourceInfo>
		{
			new ResourceInfo(2, 1000),
			new ResourceInfo(7, 500),
			new ResourceInfo(1, 1000),
			new ResourceInfo(5, 1000),
			new ResourceInfo(0, 1000),
			new ResourceInfo(3, 1000),
			new ResourceInfo(6, 5000),
			new ResourceInfo(4, 1000)
		};
		ComfortableHouseUnlockCost = new List<ResourceInfo>
		{
			new ResourceInfo(6, 25000),
			new ResourceInfo(7, 2500)
		};
		VowRewardResourceBasePrice = 10000;
		VowFinishedSectStoryAuthorityPercent = 50;
		MainStoryHelpSectApprovedGrades = new sbyte[4] { 0, 1, 2, 3 };
		MainStoryHelpSectApprovedCounts = new int[4] { 3, 2, 1, 1 };
		MainStoryHelpSectAddSpiritualDebt = 1000;
		MainStoryNotHelpSectAddSpiritualDebt = -500;
		TaiwuVillageUpgradeAuthorityCosts = new int[15]
		{
			0, 2500, 5000, 7500, 10000, 12500, 15000, 17500, 20000, 25000,
			30000, 35000, 40000, 45000, 50000
		};
		RecruitCharacterGradeScoreThresholds = new int[9] { 100, 200, 300, 500, 700, 900, 1200, 1600, 2100 };
		ShopManageProgressBaseDelta = 650;
		MaxProductionProgress = 10000;
		MaterialWeightToArtisanOrder = new int[3] { 40, 60, 10 };
		InitialProductionWeight = new int[3] { 10, 60, 40 };
		AddOnAttainmentOfWorker = 50;
		AddOnAttainmentOfLeader = 150;
		WorkerAttainmentDivider = 3;
		ArtisanAttainmentFactor1 = 2;
		ArtisanAttainmentFactor2 = 200;
		MonthlyOrderProgressBase = 250;
		MonthlyOrderProgressFactor = 2;
		TeaWineArtisanOrderAttainmentRequirement = new int[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		CollectResourceBuildingProductivityDistanceOne = new int[4] { 100, 80, 60, 40 };
		CollectResourceBuildingProductivityDistanceMore = 20;
		ShopBuildingSharePencent = new sbyte[2] { 20, 10 };
		DarkRiverHugeSnakeTamePoint = 95;
		ExtendFavorSafetyAndCultureAreaFactor = new sbyte[3] { 20, 15, 10 };
		RefreshItemApCost = 50;
		VillagerSkillLegacyAttainmentRequirement = 450;
		MapDestroyedBlockPathingCost = 90;
		GenerateXiangshuMinionAfterDisasterRangeMax = 3;
		GenerateXiangshuMinionAfterDisasterBase = 1;
		GenerateXiangshuMinionAfterDisasterGradeMinusMax = 3;
		GenerateXiangshuMinionAfterDisasterInDevelopedBlockProbabilityPercentage = 33;
		TravelingEventRoadBlockDurabilityChange = 10;
		FulongServantBaseAttraction = 600;
		ExtraLegacyPointGain = new List<int[]>
		{
			new int[7] { 200, 150, 100, 0, 0, 0, 0 },
			new int[7] { 0, 0, 0, 0, 100, 150, 200 }
		};
		SettlementInfluenceRange = 3;
		ResourceBlockBuildingCoreProducingCooldown = new int[2] { 3, 6 };
		ResourceBlockBuildingCoreProducingMaxChance = new int[2] { 10000, 30000 };
		GeneratedXiangshuMinionDurationFactor = 100;
		BrokenPerformDarkAshInfectorRangeMax = 3;
		BrokenPerformDarkAshInfectorBase = 3;
		DarkAshDurationOldTaosim = 6;
		DarkAshDurationRangeMax = 7;
		DarkAshDurationBase = 6;
		FuyuFaithDebtFactor = 300;
		AppointmentCostDays = 5;
		TaiwuVillagerSkillBreakBonusItemGradeLimit = 5;
		SwapSkillBreakCostExp = 5;
		DistantMarriageInfluencedByTaiwuFavorDelta = 15000;
		MonthsMonthNotificationsKept = 12;
		SpiritualDebtInteractionChangeMoralityMax = 50;
		FameAbsValueForBothGoodAndBad = 50;
		WineTasterSkill2Factor = 10;
		AgePercentShowWrinkle1 = 60;
		AgePercentShowWrinkle2 = 70;
		AgePercentShowWrinkle3 = 50;
		TaiwuVillagerSkillBreakBonusItemGradeLimitArray = new int[19]
		{
			0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
			5, 5, 6, 6, 7, 7, 8, 8, 8
		};
	}

	public void ImportFromCollection(IEnumerable enumerable)
	{
	}

	public void ExportToFiles(string directory)
	{
		string path = Path.Combine(directory, GetType().Name + ".json");
		CommonObjectSerializer.Serialize(this, out var content, CommonObjectSerializer.MarshalFormat.Json);
		File.WriteAllText(path, content);
	}

	public void ImportFromFiles(string directory)
	{
		CommonObjectSerializer.Deserialize<GlobalConfig>(File.ReadAllText(Path.Combine(directory, GetType().Name + ".json")), out var globalConfig, CommonObjectSerializer.MarshalFormat.Json);
		Instance = globalConfig;
	}
}
