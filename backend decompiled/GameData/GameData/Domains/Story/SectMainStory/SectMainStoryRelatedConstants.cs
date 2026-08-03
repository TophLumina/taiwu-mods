using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.Story.SectMainStory;

public static class SectMainStoryRelatedConstants
{
	public const short KongsangProsperousEndCountDown = 1;

	public const short XuehouProsperousEndCountDown = 1;

	public const short ShaolinProsperousEndCountDown = 1;

	public const short XuannvProsperousEndCountDown = 1;

	public const short WudangProsperousEndCountDown = 1;

	public const short YuanshanProsperousEndCountDown = 1;

	public const short RanshanProsperousEndCountDown = 1;

	public const short EmeiProsperousEndCountDown = 1;

	public const short ShixiangProsperousEndCountDown = 1;

	public const short JingangProsperousEndCountDown = 1;

	public const short WuxianProsperousEndCountDown = 1;

	public const short JieqingProsperousEndCountDown = 1;

	public const short ZhujianProsperousEndCountDown = 1;

	public const short BaihuaProsperousEndCountDown = 1;

	public const short FulongProsperousEndCountDown = 1;

	public const short KongsangFailingEndCountDown = 1;

	public const short XuehouFailingEndCountDown = 1;

	public const short ShaolinFailingEndCountDown = 1;

	public const short XuannvFailingEndCountDown = 1;

	public const short WudangFailingEndCountDown = 1;

	public const short YuanshanFailingEndCountDown = 1;

	public const short RanshanFailingEndCountDown = 1;

	public const short EmeiFailingEndCountDown = 1;

	public const short ShixiangFailingEndCountDown = 1;

	public const short JingangFailingEndCountDown = 1;

	public const short WuxianFailingEndCountDown = 1;

	public const short JieqingFailingEndCountDown = 1;

	public const short ZhujianFailingEndCountDown = 1;

	public const short BaihuaFailingEndCountDown = 1;

	public const short FulongFailingEndCountDown = 1;

	public const int EndingFavorabilityChange = 12000;

	public const int SendGiftCostTime = 3;

	public const sbyte EndGetInformationLevel = 8;

	public const short KongsangAdventureCountDown = 240;

	public const short LiaoWumingSendMessageCountDown1 = 3;

	public const short LiaoWumingSendMessageCountDown2 = 1;

	public const int KongsangAdventureCreateDistance = 5;

	public const int KongsangMonthEventAttainmentRequire = 100;

	public const int KongsangEnding0GetMedicineCount = 9;

	public const int KongsangEnding1GetPoisonCount = 1;

	public const int KongsangAdventureGetPoisonCount = 99;

	public const int TripodVesselOfMedicineCost = 5000;

	public const int TripodVesselActionCooldown = 2;

	public const int TripodVesselOfMedicineHealthIncrease = 360;

	public const int TryPoisonChangeFavorabilityValue = 3000;

	public const int LiaoWumingInitialFavorabilityValue = 9999;

	public static readonly int[] TripodVesselOfMedicineProb = new int[9] { 10, 20, 31, 51, 71, 81, 91, 97, 100 };

	public static readonly int[] LiaoWumingAi2TaskInfo = new int[8] { 103, 106, 109, 104, 107, 102, 105, 108 };

	public static readonly int[] CanNotMeetSkeletonCharacters = new int[1] { 749 };

	public static readonly int[] CanNotGraveInteractionCharavters = new int[1] { 856 };

	public static readonly short[][] MakeMixedPoison = new short[20][]
	{
		new short[3] { 0, 27, 36 },
		new short[3] { 0, 36, 45 },
		new short[3] { 0, 36, 9 },
		new short[3] { 0, 36, 18 },
		new short[3] { 27, 36, 45 },
		new short[3] { 27, 36, 9 },
		new short[3] { 27, 36, 18 },
		new short[3] { 0, 27, 45 },
		new short[3] { 0, 27, 9 },
		new short[3] { 0, 27, 18 },
		new short[3] { 9, 18, 45 },
		new short[3] { 36, 9, 18 },
		new short[3] { 0, 9, 18 },
		new short[3] { 27, 9, 18 },
		new short[3] { 36, 18, 45 },
		new short[3] { 0, 18, 45 },
		new short[3] { 27, 18, 45 },
		new short[3] { 36, 9, 45 },
		new short[3] { 0, 9, 45 },
		new short[3] { 27, 9, 45 }
	};

	public const short GetBellTriggerEventCountDown = 3;

	public const int MeetXuehouSkeletonProb = 30;

	public const short DefeatXuehouOldManCountDown = 3;

	public const short GiveBellToXuehouOldManCountDown = 3;

	public const short XuehouAdventureThreeCountDown = 3;

	public const short XuehouAdventureFourCountDown = 3;

	public const short JixiAdventureDuration = 9;

	public const short JixiAdventureFourDuration = 6;

	public const short VillagerCountConst = 3;

	public const short XuehouComingCoolDownTime = 3;

	public const short JixiAdventureOneAddDisorderOfQi = 1000;

	public const short JixiFavorChangeToTaiwuOne = 4000;

	public const short JixiFavorChangeToTaiwuTwo = 1000;

	public const sbyte JixiTruthClueConst = 2;

	public const short TaiwuCookNeedFoodResource = 1000;

	public const short TaiwuCookAttainmentThreshold = 300;

	public const short MonthEventChangeFavorability = 600;

	public const short XuehouAdventure1Cost = 50;

	[Obsolete]
	public const int ShaolinLifeCombatPracticeLevel = 30;

	public const int ShaolinSutraPavilionCost = 30;

	public const int ShaolinRepairPagodaCost = 20;

	public const int ShaolinRepairPagodaSpiritualDebt = 500;

	public const int CombatSkillBreakoutTimeCost = 10;

	public const int HighestGradeSutraDurability = 15;

	public const short ShaolinStudyForBodhidharmaChallengeInterval = 6;

	public const short ShaolinReadSutraNeedPageCount = 3;

	public const int WaitForTaoistMonkCountDown = 3;

	public static (short, short)[] SnakeItemInfo = new(short, short)[10]
	{
		(603, 334),
		(615, 338),
		(621, 340),
		(609, 336),
		(612, 337),
		(606, 335),
		(618, 339),
		(624, 341),
		(627, 342),
		(630, 343)
	};

	public const int ModifySkillBookTimeCost = 10;

	public const short WudangXiangshuMinionHealthReduction = 60;

	public const int WudangHeavenlyTreeClearEnemyIncreaseGrowPoint = 10;

	public const short MaxGetExtraSeedCount = 7;

	public const sbyte MythInYuanshanMoveDelay = 1;

	public const sbyte InfectedAbsorbance = 10;

	public const sbyte PowerTranslateMultiplier = 2;

	public const int DemonDistanceToSettlement = 5;

	public const int DemonDistanceToOther = 4;

	public const int DemonMinionStep = 2;

	public const int DemonFightStep = 2;

	public const int DemonFightCountMin = 5;

	public const int DemonFightCountMax = 10;

	public const int DemonFightWinScore = 50;

	public const int DemonFightAttackCountWin = 2;

	public const int DemonFightAttackCountTie = 3;

	public const int DemonFightAttackCountLose = 4;

	public const int DemonFightDefenseCountWin = 2;

	public const int DemonFightDefenseCountTie = 1;

	public const int DemonFightDefenseCountLose = 0;

	public const int DemonFightCooldownWin = 1;

	public const int DemonFightCooldownTie = 3;

	public const int DemonFightCooldownLose = 6;

	public const int DemonFightPowerReductionRateWin = 3;

	public const int DemonFightPowerReductionRateTie = 1;

	public const int ShixiangKilledCountLimitMin = 6;

	public const int ShixiangKilledCountLimitMax = 12;

	public const int ShixiangFightAttackCount = 2;

	public const int ShixiangFightDefenseCount = 2;

	public const int ShixiangAdventureDuration = 3;

	public const int ShixiangEnemyCountFloor = 10;

	public const int ShixiangEnemyCountCeiling = 15;

	public const int ShixiangTraitorCountFloor = 15;

	public const int ShixiangTraitorCountCeiling = 20;

	public const int ShixiangKillTraitorTaskTimeLimit = 36;

	public const int ShixiangBarbarianMasterCountFloor = 30;

	public const int ShixiangBarbarianMasterCountCeiling = 40;

	public const int MockShixiangEventThresholdCount = 3;

	public const int EclecticAttainmentNeed = 150;

	public const int MonthEventRequestBookAuthorityChange = 250;

	public const int MonthEventRequestSkillBookFavorChange = 3000;

	public const int MonthEventTalkRightFavorChange = 1500;

	public const int MonthEventTalkWrongFavorChange = -500;

	public const int SelectCombatWithBarbariansFavorChange = 3000;

	public const int ShixiangMemberFavorChange = 3000;

	public const int ShixiangNormalWorldProb = 1;

	public const int ShixiangMemberInteractChance = 30;

	public static short[] BarbarianMasterHairColorTemplateId = new short[3] { 6, 12, 42 };

	public const int EmeiAdventureTwoDuration = 6;

	public const int EmeiBreakBonusCostExpBaseValue = 500;

	public const int EmeiBreakBonusCostExpPerTimes = 500;

	public const int EmeiBreakBonusCountPerRefresh = 5;

	public const int EmeiAdventureTwoPathEventTriggerCountLimit = 6;

	public static (short, short)[] XuannvUnlockMusicCountToFavorability = new(short, short)[5]
	{
		(0, 14000),
		(10, 18000),
		(20, 22000),
		(30, 26000),
		(40, 30000)
	};

	public const int JingangWrongdoingFrequency = 2;

	public static int JingangEventFrequency1 = 3;

	public static int JingangEventFrequency2 = 6;

	public const int RanXinduFavorabilityInitial = 10000;

	public const int RanXinDuFavorabilityDeltaGood = 1000;

	public const int RanXinDuFavorabilityDeltaBad = -1000;

	public const int RanXinDuFavorabilityDeltaAgreed = 3000;

	public const int RanXinDuFavorabilityDeltaRefused = -3000;

	public const int DisorderOfQiDeltaAfterDrunk = 2000;

	public const int RanXinduFavorabilityDeltaRamble = 500;

	public const int RanXinduFavorabilityDeltaGuard = 3000;

	public const int RanXinduFavorabilityDeltaPlaySerious = 1000;

	public const int RanXinduFavorabilityDeltaPlayNormal = 500;

	public const sbyte LiceWugInjuryDelta = 1;

	public const sbyte BambooStripsWugInjuryDelta = 1;

	public const int AphrodisiacWugDisorderOfQiDelta = 1000;

	public const int NewParanoiaCharacterChance = 25;

	public const int WuxianBadEnding0CountDown = 3;

	public const int WuxianBadEnding1CountDown = 1;

	public const int WuxianHappyEndingCountDown = 1;

	public const int WuxianHappyEndingEventCountDown = 3;

	public static List<string[]> RanXinduFairyTexts = new List<string[]>
	{
		new string[15]
		{
			"Event_SectStoryWuxian_RanXinduFairy_0_1", "Event_SectStoryWuxian_RanXinduFairy_0_2", "Event_SectStoryWuxian_RanXinduFairy_0_3", "Event_SectStoryWuxian_RanXinduFairy_0_4", "Event_SectStoryWuxian_RanXinduFairy_0_5", "Event_SectStoryWuxian_RanXinduFairy_0_6", "Event_SectStoryWuxian_RanXinduFairy_0_7", "Event_SectStoryWuxian_RanXinduFairy_0_8", "Event_SectStoryWuxian_RanXinduFairy_0_9", "Event_SectStoryWuxian_RanXinduFairy_0_10",
			"Event_SectStoryWuxian_RanXinduFairy_0_11", "Event_SectStoryWuxian_RanXinduFairy_0_12", "Event_SectStoryWuxian_RanXinduFairy_0_13", "Event_SectStoryWuxian_RanXinduFairy_0_14", "Event_SectStoryWuxian_RanXinduFairy_0_15"
		},
		new string[4] { "Event_SectStoryWuxian_RanXinduFairy_1_1", "Event_SectStoryWuxian_RanXinduFairy_1_2", "Event_SectStoryWuxian_RanXinduFairy_1_3", "Event_SectStoryWuxian_RanXinduFairy_1_4" },
		new string[5] { "Event_SectStoryWuxian_RanXinduFairy_2_1", "Event_SectStoryWuxian_RanXinduFairy_2_2", "Event_SectStoryWuxian_RanXinduFairy_2_3", "Event_SectStoryWuxian_RanXinduFairy_2_4", "Event_SectStoryWuxian_RanXinduFairy_2_5" },
		new string[5] { "Event_SectStoryWuxian_RanXinduFairy_3_1", "Event_SectStoryWuxian_RanXinduFairy_3_2", "Event_SectStoryWuxian_RanXinduFairy_3_3", "Event_SectStoryWuxian_RanXinduFairy_3_4", "Event_SectStoryWuxian_RanXinduFairy_3_5" }
	};

	public static int[] PoisonItemsFromRanXinduCount = new int[7] { 1, 2, 3, 3, 3, 2, 1 };

	public const int ZhangLingFavorabilityInitial = 14000;

	public const int ThreeCorpsesFavorabilityInitial = 10000;

	public const int ThreeCorpsesFavorabilityDeltaPositive1 = 2000;

	public const int ThreeCorpsesFavorabilityDeltaNegative1 = 1000;

	public const int RanshanMenteeFavorabilityDelta = 6000;

	public const int RanshanMenteeHappinessDelta = -20;

	public const int RanshanThreeCorpsesMoveSteps = 2;

	public const int RanshanTeachingDuration = 24;

	public const int RanshanThreeCorpsesFavorabilityDeltaCombat = 1000;

	public static List<short> RanshanThreeCorpsesCharacterTemplateIdList = new List<short> { 698, 699, 700 };

	public const int ThreeCorpsesFollowMaxSteps = 2;

	public const int BaihuaAdventureFourDuration = 1;

	public const int BaihuaDreamAboutPastLastDuration = 3;

	public const int BaihuaAmbushNeedGroupCount = 1;

	public const int BaihuaAnimalsBackToPandemicStart = 6;

	public const int BaihuaManicLowSustain = 6;

	public const int BaihuaManicLowToHighDuration = 3;

	public const int BaihuaManicHighToAdventureDuration = 3;

	public static int FulongZealotStartRobTime = 3;

	public static int FulongAdventureOneFavorabilityChange = 800;

	public static short FulongLazuliStartFavorability = 10000;

	public static int FulongLazuliFavorabilityAdd = 6000;

	public const int FulongOutLawResupplyCooldown = 6;

	public const int FulongOutLawRobCooldown = 1;

	public const int FulongOutlawRobResourceTypeCount = 2;

	public const int FulongOutLawMinimumCount = 5;

	public const int FulongOutLawMaximumCount = 9;

	public const int FulongOutLawMinimumCountTaiwu = 3;

	public const int FulongOutLawMaximumCountTaiwu = 6;

	public const int FulongOutLawVictimFavorabilityChange = 6000;

	public const int FulongOutLawVictimFavorabilityChangeFamily = 8000;

	public static readonly sbyte[] FulongOutLawFightBehaviorBonus = new sbyte[5] { 30, 20, 10, 25, 40 };

	public static readonly sbyte[] FulongOutLawDestination = new sbyte[4] { 16, 35, 33, 29 };

	public static int FulongChickenFeatherNeedCount = 12;

	public const short YuanshanMinionTemplateOffsetMax = 4;

	public static short GetEnemyLevelByXiangshuLevel()
	{
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		if (1 == 0)
		{
		}
		short result = (short)((xiangshuLevel > 3) ? (xiangshuLevel switch
		{
			4 => 1, 
			5 => 2, 
			6 => 3, 
			_ => 4, 
		}) : 0);
		if (1 == 0)
		{
		}
		return result;
	}

	public static short GetEnemyTemplateIdByXiangshuLevel(sbyte orgTemplateId)
	{
		if (1 == 0)
		{
		}
		short num = orgTemplateId switch
		{
			5 => 425, 
			3 => 407, 
			10 => 470, 
			6 => 434, 
			11 => 479, 
			7 => 443, 
			1 => 389, 
			_ => throw new ArgumentOutOfRangeException("orgTemplateId"), 
		};
		if (1 == 0)
		{
		}
		short templateBase = num;
		short level = GetEnemyLevelByXiangshuLevel();
		return (short)(templateBase - level);
	}

	public static short GetTemplateIdOfFixedCharacterCombatWith(short beginTemplateId, short length = 5, bool consummateLevelIncrease = true)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		sbyte consummateLevel = taiwu.GetConsummateLevel();
		if (consummateLevelIncrease)
		{
			for (int i = beginTemplateId; i < beginTemplateId + length; i++)
			{
				CharacterItem config = Config.Character.Instance[i];
				if (config.ConsummateLevel >= consummateLevel)
				{
					return config.TemplateId;
				}
			}
			return (short)(beginTemplateId + length - 1);
		}
		for (int i2 = beginTemplateId + length - 1; i2 >= beginTemplateId; i2--)
		{
			CharacterItem config2 = Config.Character.Instance[i2];
			if (config2.ConsummateLevel >= consummateLevel)
			{
				return config2.TemplateId;
			}
		}
		return beginTemplateId;
	}

	public static short GetTemplateIdOfXiangshuMinionCombatWith()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		sbyte consummateLevel = taiwu.GetConsummateLevel();
		for (int i = 374; i >= 366; i--)
		{
			CharacterItem config = Config.Character.Instance[i];
			if (config.ConsummateLevel < consummateLevel)
			{
				return config.TemplateId;
			}
		}
		return 366;
	}

	public static short GetBeginEnemyTemplateIdByXiangshuLevel()
	{
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		if (1 == 0)
		{
		}
		short result = (short)((xiangshuLevel <= 3) ? 336 : (xiangshuLevel switch
		{
			4 => 341, 
			5 => 346, 
			6 => 351, 
			_ => 356, 
		}));
		if (1 == 0)
		{
		}
		return result;
	}

	public static short GetYuanshanMemberEnemy()
	{
		return GetEnemyTemplateIdByXiangshuLevel(5);
	}

	public static short GetYuanshanDemonMinionFirstTemplateId(short demonTemplateId)
	{
		if (1 == 0)
		{
		}
		short result = demonTemplateId switch
		{
			640 => 651, 
			641 => 656, 
			642 => 661, 
			_ => throw new ArgumentOutOfRangeException("demonTemplateId"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static short GetYuanshanDemonMinionTemplateId(short demonTemplateId)
	{
		short level = GetEnemyLevelByXiangshuLevel();
		short minionTemplate = GetYuanshanDemonMinionFirstTemplateId(demonTemplateId);
		return (short)(minionTemplate + level);
	}

	public static short GetJingangMemberEnemy()
	{
		return GetEnemyTemplateIdByXiangshuLevel(11);
	}

	public static short GetRanshanZhuxianTemplateId()
	{
		sbyte consummateLevel = DomainManager.Taiwu.GetTaiwu().GetConsummateLevel();
		if (1 == 0)
		{
		}
		short result = (short)((consummateLevel <= 14) ? 709 : ((consummateLevel > 16) ? 711 : 710));
		if (1 == 0)
		{
		}
		return result;
	}
}
