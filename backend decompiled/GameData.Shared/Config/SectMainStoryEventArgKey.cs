using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectMainStoryEventArgKey : ConfigData<SectMainStoryEventArgKeyItem, int>, IEventArgumentCollectionFormatter
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// IsKillLiaoWuming
		/// </summary>
		public const int IsKillLiaoWuming = 0;

		/// <summary>
		/// IsKilledByLiaoWuming
		/// </summary>
		public const int IsKilledByLiaoWuming = 1;

		/// <summary>
		/// LiaoWumingQuestStartDate
		/// </summary>
		public const int LiaoWumingQuestStartDate = 2;

		/// <summary>
		/// LiaoWumingGetPoison
		/// </summary>
		public const int LiaoWumingGetPoison = 3;

		/// <summary>
		/// TheNameGivePoisonToLiaoWuming
		/// </summary>
		public const int TheNameGivePoisonToLiaoWuming = 4;

		/// <summary>
		/// KongsangAdventureCountDown
		/// </summary>
		public const int KongsangAdventureCountDown = 5;

		/// <summary>
		/// GetKongsangInformation1
		/// </summary>
		public const int GetKongsangInformation1 = 6;

		/// <summary>
		/// GetKongsangInformation2
		/// </summary>
		public const int GetKongsangInformation2 = 7;

		/// <summary>
		/// InteractWithLiaoWumingAi2
		/// </summary>
		public const int InteractWithLiaoWumingAi2 = 8;

		/// <summary>
		/// KongsangAcceptTaskTaiwuId
		/// </summary>
		public const int KongsangAcceptTaskTaiwuId = 9;

		/// <summary>
		/// KongsangFirstPassingLegacyTaiwuId
		/// </summary>
		public const int KongsangFirstPassingLegacyTaiwuId = 10;

		/// <summary>
		/// KongsangFirstPassingLegacyDialogTriggered
		/// </summary>
		public const int KongsangFirstPassingLegacyDialogTriggered = 11;

		/// <summary>
		/// KongsangSecondPassingLegacyDialogCharId
		/// </summary>
		public const int KongsangSecondPassingLegacyDialogCharId = 12;

		/// <summary>
		/// KongsangStoryPartOneTriggered
		/// </summary>
		public const int KongsangStoryPartOneTriggered = 13;

		/// <summary>
		/// KongsangPart3TaiwuId
		/// </summary>
		public const int KongsangPart3TaiwuId = 14;

		/// <summary>
		/// FirstTryPoisonIsFailure
		/// </summary>
		public const int FirstTryPoisonIsFailure = 15;

		/// <summary>
		/// SecondTryPoisonIsFailure
		/// </summary>
		public const int SecondTryPoisonIsFailure = 16;

		/// <summary>
		/// ThirdTryPoisonIsFailure
		/// </summary>
		public const int ThirdTryPoisonIsFailure = 17;

		/// <summary>
		/// TripodVesselOfMedicineAreaId
		/// </summary>
		public const int TripodVesselOfMedicineAreaId = 18;

		/// <summary>
		/// ActingHeadActorData
		/// </summary>
		public const int ActingHeadActorData = 19;

		/// <summary>
		/// KongsangSectLeaderId
		/// </summary>
		public const int KongsangSectLeaderId = 20;

		/// <summary>
		/// BeforePoisonTest0EventTriggered
		/// </summary>
		public const int BeforePoisonTest0EventTriggered = 21;

		/// <summary>
		/// BeforePoisonTest0EventFirstTriggered
		/// </summary>
		public const int BeforePoisonTest0EventFirstTriggered = 22;

		/// <summary>
		/// BeforePoisonTest1EventTriggered
		/// </summary>
		public const int BeforePoisonTest1EventTriggered = 23;

		/// <summary>
		/// MissionUnacceptedEventTriggeredSameMonth
		/// </summary>
		public const int MissionUnacceptedEventTriggeredSameMonth = 24;

		/// <summary>
		/// KongsangTargetFoundEventTriggered
		/// </summary>
		public const int KongsangTargetFoundEventTriggered = 25;

		/// <summary>
		/// XuehouStoryPartOneTriggered
		/// </summary>
		public const int XuehouStoryPartOneTriggered = 26;

		/// <summary>
		/// StillAtYangzhou
		/// </summary>
		public const int StillAtYangzhou = 27;

		/// <summary>
		/// FirstGotBellTime
		/// </summary>
		public const int FirstGotBellTime = 28;

		/// <summary>
		/// MeetSkeletonWithBellExtraProb
		/// </summary>
		public const int MeetSkeletonWithBellExtraProb = 29;

		/// <summary>
		/// XuehouGraveDiggingEventTriggered
		/// </summary>
		public const int XuehouGraveDiggingEventTriggered = 30;

		/// <summary>
		/// DefeatXuehouOldManTime
		/// </summary>
		public const int DefeatXuehouOldManTime = 31;

		/// <summary>
		/// GiveBellToXuehouOldManTime
		/// </summary>
		public const int GiveBellToXuehouOldManTime = 32;

		/// <summary>
		/// XuehouOldManGraveDisappearTriggered
		/// </summary>
		public const int XuehouOldManGraveDisappearTriggered = 33;

		/// <summary>
		/// XuehouOldManCharacterId
		/// </summary>
		public const int XuehouOldManCharacterId = 34;

		/// <summary>
		/// OldManZombieInteractTriggered
		/// </summary>
		public const int OldManZombieInteractTriggered = 35;

		/// <summary>
		/// AwakeJixiTaiwuId
		/// </summary>
		public const int AwakeJixiTaiwuId = 36;

		/// <summary>
		/// AwakeJixiTaiwuGender
		/// </summary>
		public const int AwakeJixiTaiwuGender = 37;

		/// <summary>
		/// AwakeJixiAndPassLegacy
		/// </summary>
		public const int AwakeJixiAndPassLegacy = 38;

		/// <summary>
		/// PassXuehouAdventure1Time
		/// </summary>
		public const int PassXuehouAdventure1Time = 39;

		/// <summary>
		/// XuehouEmptyCaveTriggered
		/// </summary>
		public const int XuehouEmptyCaveTriggered = 40;

		/// <summary>
		/// XuehouFindPeopleTriggered
		/// </summary>
		public const int XuehouFindPeopleTriggered = 41;

		/// <summary>
		/// XuehouComingTime
		/// </summary>
		public const int XuehouComingTime = 42;

		/// <summary>
		/// XuehouComingTriggeredCount
		/// </summary>
		public const int XuehouComingTriggeredCount = 43;

		/// <summary>
		/// JixiArrivedTaiwuDate
		/// </summary>
		public const int JixiArrivedTaiwuDate = 44;

		/// <summary>
		/// JixiArrivedTaiwuMonthlyEventTriggeredCount
		/// </summary>
		public const int JixiArrivedTaiwuMonthlyEventTriggeredCount = 45;

		/// <summary>
		/// JixiAdventureOnePassDate
		/// </summary>
		public const int JixiAdventureOnePassDate = 46;

		/// <summary>
		/// JixiAdventureTwoPassDate
		/// </summary>
		public const int JixiAdventureTwoPassDate = 47;

		/// <summary>
		/// JixiAdventureThreePassDate
		/// </summary>
		public const int JixiAdventureThreePassDate = 48;

		/// <summary>
		/// JixiAdventureOneStartDate
		/// </summary>
		public const int JixiAdventureOneStartDate = 49;

		/// <summary>
		/// JixiAdventureTwoStartDate
		/// </summary>
		public const int JixiAdventureTwoStartDate = 50;

		/// <summary>
		/// JixiAdventureThreeStartDate
		/// </summary>
		public const int JixiAdventureThreeStartDate = 51;

		/// <summary>
		/// JixiAdventureFourStartDate
		/// </summary>
		public const int JixiAdventureFourStartDate = 52;

		/// <summary>
		/// ProtectedJixiEventTriggered
		/// </summary>
		public const int ProtectedJixiEventTriggered = 53;

		/// <summary>
		/// JixiFeedChickenEventTriggered
		/// </summary>
		public const int JixiFeedChickenEventTriggered = 54;

		/// <summary>
		/// JixiHarmVillagerEventTriggered
		/// </summary>
		public const int JixiHarmVillagerEventTriggered = 55;

		/// <summary>
		/// HaveJixiTruthClueCount
		/// </summary>
		public const int HaveJixiTruthClueCount = 56;

		/// <summary>
		/// HaveJixiFalseClueCount
		/// </summary>
		public const int HaveJixiFalseClueCount = 57;

		/// <summary>
		/// JixiWaitingMonthKey
		/// </summary>
		public const int JixiWaitingMonthKey = 58;

		/// <summary>
		/// JixiStayAtGraveMonthKey
		/// </summary>
		public const int JixiStayAtGraveMonthKey = 59;

		/// <summary>
		/// JixiKilledCountKey
		/// </summary>
		public const int JixiKilledCountKey = 60;

		/// <summary>
		/// CombatWithUltimateZombieTriggered
		/// </summary>
		public const int CombatWithUltimateZombieTriggered = 61;

		/// <summary>
		/// JixiLegacyPassFirstTalkTriggered
		/// </summary>
		public const int JixiLegacyPassFirstTalkTriggered = 62;

		/// <summary>
		/// JixiSoulTransformFirstTalkTriggered
		/// </summary>
		public const int JixiSoulTransformFirstTalkTriggered = 63;

		/// <summary>
		/// PassLegacyMonthlyNotificationTriggered
		/// </summary>
		public const int PassLegacyMonthlyNotificationTriggered = 64;

		/// <summary>
		/// NeedTriggerPassLegacyMonthlyNotification
		/// </summary>
		public const int NeedTriggerPassLegacyMonthlyNotification = 65;

		/// <summary>
		/// XuehouOldManHasBell
		/// </summary>
		public const int XuehouOldManHasBell = 66;

		/// <summary>
		/// JixiHasAntiqueJadeBat
		/// </summary>
		public const int JixiHasAntiqueJadeBat = 67;

		/// <summary>
		/// JixiHasAntiqueJadeFox
		/// </summary>
		public const int JixiHasAntiqueJadeFox = 68;

		/// <summary>
		/// JixiHasAntiqueJadeButterfly
		/// </summary>
		public const int JixiHasAntiqueJadeButterfly = 69;

		/// <summary>
		/// JixiFavorite1TalkTriggered
		/// </summary>
		public const int JixiFavorite1TalkTriggered = 70;

		/// <summary>
		/// JixiFavorite2TalkTriggered
		/// </summary>
		public const int JixiFavorite2TalkTriggered = 71;

		/// <summary>
		/// JixiFavorite3TalkTriggered
		/// </summary>
		public const int JixiFavorite3TalkTriggered = 72;

		/// <summary>
		/// JixiFavorite4TalkTriggered
		/// </summary>
		public const int JixiFavorite4TalkTriggered = 73;

		/// <summary>
		/// JixiFavorite5TalkTriggered
		/// </summary>
		public const int JixiFavorite5TalkTriggered = 74;

		/// <summary>
		/// JixiLikeKillTalkTriggered
		/// </summary>
		public const int JixiLikeKillTalkTriggered = 75;

		/// <summary>
		/// JixiPassLegacyTalkTriggered
		/// </summary>
		public const int JixiPassLegacyTalkTriggered = 76;

		/// <summary>
		/// JixiKillEnemyTalkTriggered
		/// </summary>
		public const int JixiKillEnemyTalkTriggered = 77;

		/// <summary>
		/// JixiKilledEnemy
		/// </summary>
		public const int JixiKilledEnemy = 78;

		/// <summary>
		/// JixiFollowOpen
		/// </summary>
		public const int JixiFollowOpen = 79;

		/// <summary>
		/// XuehouSelectFreeJixi
		/// </summary>
		public const int XuehouSelectFreeJixi = 80;

		/// <summary>
		/// XuehouGraveDiggingNormalTriggerTime
		/// </summary>
		public const int XuehouGraveDiggingNormalTriggerTime = 81;

		/// <summary>
		/// JixiAnimalTalkOpen
		/// </summary>
		public const int JixiAnimalTalkOpen = 82;

		/// <summary>
		/// XuannvStoryTriggerFirstTrack
		/// </summary>
		public const int XuannvStoryTriggerFirstTrack = 83;

		/// <summary>
		/// XuannvStoryPartOneTriggered
		/// </summary>
		public const int XuannvStoryPartOneTriggered = 84;

		/// <summary>
		/// XuannvStoryTaiwuCharId
		/// </summary>
		public const int XuannvStoryTaiwuCharId = 85;

		/// <summary>
		/// XuannvStoryPartOneIsReceivingLetter
		/// </summary>
		public const int XuannvStoryPartOneIsReceivingLetter = 86;

		/// <summary>
		/// XuannvStoryPartOneLetterCountA
		/// </summary>
		public const int XuannvStoryPartOneLetterCountA = 87;

		/// <summary>
		/// XuannvStoryPartOneLetterCountB
		/// </summary>
		public const int XuannvStoryPartOneLetterCountB = 88;

		/// <summary>
		/// XuannvStoryPartOneLetterCountC
		/// </summary>
		public const int XuannvStoryPartOneLetterCountC = 89;

		/// <summary>
		/// XuannvStoryPartOneOptionMarkKey
		/// </summary>
		public const int XuannvStoryPartOneOptionMarkKey = 90;

		/// <summary>
		/// XuannvStoryPartOneLegendaryDoctor
		/// </summary>
		public const int XuannvStoryPartOneLegendaryDoctor = 91;

		/// <summary>
		/// XuannvStoryPartOneWaitSecretGuestEvent
		/// </summary>
		public const int XuannvStoryPartOneWaitSecretGuestEvent = 92;

		/// <summary>
		/// XuannvStoryPartOneSecretGuestActorKey
		/// </summary>
		public const int XuannvStoryPartOneSecretGuestActorKey = 93;

		/// <summary>
		/// XuannvStoryPartOneGuessGenderKey
		/// </summary>
		public const int XuannvStoryPartOneGuessGenderKey = 94;

		/// <summary>
		/// XuannvStoryPartOneOptionInjectFlag
		/// </summary>
		public const int XuannvStoryPartOneOptionInjectFlag = 95;

		/// <summary>
		/// XuannvStoryPartOneNoneSectNpcInquireSecretGuest1
		/// </summary>
		public const int XuannvStoryPartOneNoneSectNpcInquireSecretGuest1 = 96;

		/// <summary>
		/// XuannvStoryPartOneNoneSectNpcInquireSecretGuest2
		/// </summary>
		public const int XuannvStoryPartOneNoneSectNpcInquireSecretGuest2 = 97;

		/// <summary>
		/// XuannvStoryPartOneNoneSectNpcInquireSecretGuest3
		/// </summary>
		public const int XuannvStoryPartOneNoneSectNpcInquireSecretGuest3 = 98;

		/// <summary>
		/// XuannvStoryPartTwoOptionInjectFlag
		/// </summary>
		public const int XuannvStoryPartTwoOptionInjectFlag = 99;

		/// <summary>
		/// XuannvStoryPartTwoCombatSkillType
		/// </summary>
		public const int XuannvStoryPartTwoCombatSkillType = 100;

		/// <summary>
		/// XuannvStoryPartThreeLearningSkill
		/// </summary>
		public const int XuannvStoryPartThreeLearningSkill = 101;

		/// <summary>
		/// XuannvStoryPartThreeLearningSkillId0
		/// </summary>
		public const int XuannvStoryPartThreeLearningSkillId0 = 102;

		/// <summary>
		/// XuannvStoryPartThreeLearningSkillId1
		/// </summary>
		public const int XuannvStoryPartThreeLearningSkillId1 = 103;

		/// <summary>
		/// XuannvStoryPartThreeLearningSkillId2
		/// </summary>
		public const int XuannvStoryPartThreeLearningSkillId2 = 104;

		/// <summary>
		/// XuannvStoryPartTwoRefuseToHelpCount
		/// </summary>
		public const int XuannvStoryPartTwoRefuseToHelpCount = 105;

		/// <summary>
		/// XuannvStoryPartThreeSearchLoverCount
		/// </summary>
		public const int XuannvStoryPartThreeSearchLoverCount = 106;

		/// <summary>
		/// XuannvStoryPartThreeSearchLoverSecondTakeLoverDate
		/// </summary>
		public const int XuannvStoryPartThreeSearchLoverSecondTakeLoverDate = 107;

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateSettlementId1
		/// </summary>
		public const int XuannvStoryPartThreeLoverReincarnateSettlementId1 = 108;

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateSettlementId2
		/// </summary>
		public const int XuannvStoryPartThreeLoverReincarnateSettlementId2 = 109;

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateSettlementId3
		/// </summary>
		public const int XuannvStoryPartThreeLoverReincarnateSettlementId3 = 110;

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateLocation
		/// </summary>
		public const int XuannvStoryPartThreeLoverReincarnateLocation = 111;

		/// <summary>
		/// XuannvStoryPartThreeWaitLoverNameKey
		/// </summary>
		public const int XuannvStoryPartThreeWaitLoverNameKey = 112;

		/// <summary>
		/// XuannvStoryMonthlyEventWithSisterTriggered
		/// </summary>
		public const int XuannvStoryMonthlyEventWithSisterTriggered = 113;

		/// <summary>
		/// XuannvStoryPartThreeHasTalkToShiWeizhi
		/// </summary>
		public const int XuannvStoryPartThreeHasTalkToShiWeizhi = 114;

		/// <summary>
		/// XuannvStoryPartThreeActorSisterOfShiWeizhi
		/// </summary>
		public const int XuannvStoryPartThreeActorSisterOfShiWeizhi = 115;

		/// <summary>
		/// XuannvStoryPartThreeGirlGodIllusion
		/// </summary>
		public const int XuannvStoryPartThreeGirlGodIllusion = 116;

		/// <summary>
		/// XuannvStoryOptionReadFlag1
		/// </summary>
		public const int XuannvStoryOptionReadFlag1 = 117;

		/// <summary>
		/// XuannvStoryOptionReadFlag2
		/// </summary>
		public const int XuannvStoryOptionReadFlag2 = 118;

		/// <summary>
		/// XuannvStoryOptionReadFlag3
		/// </summary>
		public const int XuannvStoryOptionReadFlag3 = 119;

		/// <summary>
		/// XuannvStoryOptionReadFlag4
		/// </summary>
		public const int XuannvStoryOptionReadFlag4 = 120;

		/// <summary>
		/// XuannvStoryHeYouyuanCharId
		/// </summary>
		public const int XuannvStoryHeYouyuanCharId = 121;

		/// <summary>
		/// XuannvStorySecretReincarnationNpcCharId
		/// </summary>
		public const int XuannvStorySecretReincarnationNpcCharId = 122;

		/// <summary>
		/// XuannvStoryIsJunerAtXuannvSect
		/// </summary>
		public const int XuannvStoryIsJunerAtXuannvSect = 123;

		/// <summary>
		/// XuannvStoryMusicUnlock10FirstFlag
		/// </summary>
		public const int XuannvStoryMusicUnlock10FirstFlag = 124;

		/// <summary>
		/// XuannvStoryMusicUnlock40FirstFlag
		/// </summary>
		public const int XuannvStoryMusicUnlock40FirstFlag = 125;

		/// <summary>
		/// XuannvStoryMusicUnlock45MusicWeaponFlag
		/// </summary>
		public const int XuannvStoryMusicUnlock45MusicWeaponFlag = 126;

		/// <summary>
		/// XuannvLastDateOfAdventureIllusionOfMirror
		/// </summary>
		public const int XuannvLastDateOfAdventureIllusionOfMirror = 127;

		/// <summary>
		/// ShaolinMythinLowMemberTalked
		/// </summary>
		public const int ShaolinMythinLowMemberTalked = 128;

		/// <summary>
		/// ShaolinMythinMiddleMemberTalked
		/// </summary>
		public const int ShaolinMythinMiddleMemberTalked = 129;

		/// <summary>
		/// ShaolinStatueReturnTriggered
		/// </summary>
		public const int ShaolinStatueReturnTriggered = 130;

		/// <summary>
		/// ShaolinMonthlyEventNotEnoughDate
		/// </summary>
		public const int ShaolinMonthlyEventNotEnoughDate = 131;

		/// <summary>
		/// DamoDreamMeetTaiwuId
		/// </summary>
		public const int DamoDreamMeetTaiwuId = 132;

		/// <summary>
		/// ShaolinCombatSkillType
		/// </summary>
		public const int ShaolinCombatSkillType = 133;

		/// <summary>
		/// ShaolinLearnedAny
		/// </summary>
		public const int ShaolinLearnedAny = 134;

		/// <summary>
		/// ShaolinDamoFightTimes
		/// </summary>
		public const int ShaolinDamoFightTimes = 135;

		/// <summary>
		/// ShaolinDamoFightWinDate
		/// </summary>
		public const int ShaolinDamoFightWinDate = 136;

		/// <summary>
		/// ShaolinStudyForBodhidharmaChallenge
		/// </summary>
		public const int ShaolinStudyForBodhidharmaChallenge = 137;

		/// <summary>
		/// ShaolinDamoTrialTriggered
		/// </summary>
		public const int ShaolinDamoTrialTriggered = 138;

		/// <summary>
		/// ShaolinDamoFightTriggered
		/// </summary>
		public const int ShaolinDamoFightTriggered = 139;

		/// <summary>
		/// ShaolinDamoVisitTimes
		/// </summary>
		public const int ShaolinDamoVisitTimes = 140;

		/// <summary>
		/// ShaolinReadingMaxGradeSutra
		/// </summary>
		public const int ShaolinReadingMaxGradeSutra = 141;

		/// <summary>
		/// ShaolinSutraPavilionGuardDate
		/// </summary>
		public const int ShaolinSutraPavilionGuardDate = 142;

		/// <summary>
		/// ShaolinDamoLearnedFightTimes
		/// </summary>
		public const int ShaolinDamoLearnedFightTimes = 143;

		/// <summary>
		/// ShaolinComprehendedTheZen
		/// </summary>
		public const int ShaolinComprehendedTheZen = 144;

		/// <summary>
		/// ShaolinMeditationInteractionFinished
		/// </summary>
		public const int ShaolinMeditationInteractionFinished = 145;

		/// <summary>
		/// ShaolinInteractionChangeTip1Triggered
		/// </summary>
		public const int ShaolinInteractionChangeTip1Triggered = 146;

		/// <summary>
		/// ShaolinInteractionChangeTip2Triggered
		/// </summary>
		public const int ShaolinInteractionChangeTip2Triggered = 147;

		/// <summary>
		/// WudangSkillReverseBreakCount
		/// </summary>
		public const int WudangSkillReverseBreakCount = 148;

		/// <summary>
		/// CombatWithTaoistMonkDate
		/// </summary>
		public const int CombatWithTaoistMonkDate = 149;

		/// <summary>
		/// CombatWithTaoistMonkTaiwuName
		/// </summary>
		public const int CombatWithTaoistMonkTaiwuName = 150;

		/// <summary>
		/// AtLastCombatWithTaoistMonkTaiwuName
		/// </summary>
		public const int AtLastCombatWithTaoistMonkTaiwuName = 151;

		/// <summary>
		/// BlackSnakeCustomName
		/// </summary>
		public const int BlackSnakeCustomName = 152;

		/// <summary>
		/// GiveTaoistTreasureCount
		/// </summary>
		public const int GiveTaoistTreasureCount = 153;

		/// <summary>
		/// GiveTaoistTreasureItemKey
		/// </summary>
		public const int GiveTaoistTreasureItemKey = 154;

		/// <summary>
		/// WudangChatEventTriggeredCount
		/// </summary>
		public const int WudangChatEventTriggeredCount = 155;

		/// <summary>
		/// WudangSankeFighted
		/// </summary>
		public const int WudangSankeFighted = 156;

		/// <summary>
		/// WudangFrontEventTriggered
		/// </summary>
		public const int WudangFrontEventTriggered = 157;

		/// <summary>
		/// LastEventSloppyTaoistMonkFavor
		/// </summary>
		public const int LastEventSloppyTaoistMonkFavor = 158;

		/// <summary>
		/// GetExtraSeedCount
		/// </summary>
		public const int GetExtraSeedCount = 159;

		/// <summary>
		/// FinishFairylandStoryCount
		/// </summary>
		public const int FinishFairylandStoryCount = 160;

		/// <summary>
		/// TriggeredFailureEvent
		/// </summary>
		public const int TriggeredFailureEvent = 161;

		/// <summary>
		/// WudangKillRandomEnemyTriggered
		/// </summary>
		public const int WudangKillRandomEnemyTriggered = 162;

		/// <summary>
		/// GivenMonkSnakeItemKey
		/// </summary>
		public const int GivenMonkSnakeItemKey = 163;

		/// <summary>
		/// GivenMonkSnakeList
		/// </summary>
		public const int GivenMonkSnakeList = 164;

		/// <summary>
		/// WudangEasterEggTriggered
		/// </summary>
		public const int WudangEasterEggTriggered = 165;

		/// <summary>
		/// WudangHeavenlyTreeSeedTalkTriggered
		/// </summary>
		public const int WudangHeavenlyTreeSeedTalkTriggered = 166;

		/// <summary>
		/// WudangFairylandTalkTriggered
		/// </summary>
		public const int WudangFairylandTalkTriggered = 167;

		/// <summary>
		/// WudangTortoiseSnakeTalkTriggered
		/// </summary>
		public const int WudangTortoiseSnakeTalkTriggered = 168;

		/// <summary>
		/// WudangEmperorTalkTriggered
		/// </summary>
		public const int WudangEmperorTalkTriggered = 169;

		/// <summary>
		/// MeetImmortalEventCount
		/// </summary>
		public const int MeetImmortalEventCount = 170;

		/// <summary>
		/// CollectHeavenlyTreeSeedFirstTriggered
		/// </summary>
		public const int CollectHeavenlyTreeSeedFirstTriggered = 171;

		/// <summary>
		/// YuanshanDemonOutOfJail
		/// </summary>
		public const int YuanshanDemonOutOfJail = 172;

		/// <summary>
		/// TaiwuReleasedYuanshanDemon
		/// </summary>
		public const int TaiwuReleasedYuanshanDemon = 173;

		/// <summary>
		/// YuanshanLeaderFirmDate
		/// </summary>
		public const int YuanshanLeaderFirmDate = 174;

		/// <summary>
		/// YuanshanDemonDormantDate
		/// </summary>
		public const int YuanshanDemonDormantDate = 175;

		/// <summary>
		/// MythInYuanshanTriggeredDate
		/// </summary>
		public const int MythInYuanshanTriggeredDate = 176;

		/// <summary>
		/// YuanshanInteractionTriggeredCount
		/// </summary>
		public const int YuanshanInteractionTriggeredCount = 177;

		/// <summary>
		/// YuanshanThoughtsTriggeredCount
		/// </summary>
		public const int YuanshanThoughtsTriggeredCount = 178;

		/// <summary>
		/// YuanshanThoughtsInteractable
		/// </summary>
		public const int YuanshanThoughtsInteractable = 179;

		/// <summary>
		/// YuanshanLobbyTalkInteractable
		/// </summary>
		public const int YuanshanLobbyTalkInteractable = 180;

		/// <summary>
		/// YuanshanDemonPower
		/// </summary>
		public const int YuanshanDemonPower = 181;

		/// <summary>
		/// KilledYuanshanDemonCount
		/// </summary>
		public const int KilledYuanshanDemonCount = 182;

		/// <summary>
		/// YuanshanCaelumDemonDefeatedTaiwu
		/// </summary>
		public const int YuanshanCaelumDemonDefeatedTaiwu = 183;

		/// <summary>
		/// YuanshanTerraDemonDefeatedTaiwu
		/// </summary>
		public const int YuanshanTerraDemonDefeatedTaiwu = 184;

		/// <summary>
		/// YuanshanAnthropDemonDefeatedTaiwu
		/// </summary>
		public const int YuanshanAnthropDemonDefeatedTaiwu = 185;

		/// <summary>
		/// YuanshanDemonMeetTaiwuCharId
		/// </summary>
		public const int YuanshanDemonMeetTaiwuCharId = 186;

		/// <summary>
		/// YuanshanDemonLast
		/// </summary>
		public const int YuanshanDemonLast = 187;

		/// <summary>
		/// YuanshanToFightDemon
		/// </summary>
		public const int YuanshanToFightDemon = 188;

		/// <summary>
		/// YuanshanMiniGameStage
		/// </summary>
		public const int YuanshanMiniGameStage = 189;

		/// <summary>
		/// AreVitalsDemon
		/// </summary>
		public const int AreVitalsDemon = 190;

		/// <summary>
		/// ShixiangAdventureAppearDate
		/// </summary>
		public const int ShixiangAdventureAppearDate = 191;

		/// <summary>
		/// ShixiangFirstLetterDate
		/// </summary>
		public const int ShixiangFirstLetterDate = 192;

		/// <summary>
		/// ShixiangLetterCount
		/// </summary>
		public const int ShixiangLetterCount = 193;

		/// <summary>
		/// ShixiangToFightEnemy
		/// </summary>
		public const int ShixiangToFightEnemy = 194;

		/// <summary>
		/// MockShixiangEventTriggeredSettlementId
		/// </summary>
		public const int MockShixiangEventTriggeredSettlementId = 195;

		/// <summary>
		/// MockShixiangEventTriggered
		/// </summary>
		public const int MockShixiangEventTriggered = 196;

		/// <summary>
		/// MockShixiangEventCount
		/// </summary>
		public const int MockShixiangEventCount = 197;

		/// <summary>
		/// ShixiangStoryPartOneTriggered
		/// </summary>
		public const int ShixiangStoryPartOneTriggered = 198;

		/// <summary>
		/// ShixiangAdventureWon
		/// </summary>
		public const int ShixiangAdventureWon = 199;

		/// <summary>
		/// TaiwuKillBarbarianMasterCount
		/// </summary>
		public const int TaiwuKillBarbarianMasterCount = 200;

		/// <summary>
		/// ShixiangKillBarbarianMasterCount
		/// </summary>
		public const int ShixiangKillBarbarianMasterCount = 201;

		/// <summary>
		/// TaiwuKillBarbarianMasterCount2
		/// </summary>
		public const int TaiwuKillBarbarianMasterCount2 = 202;

		/// <summary>
		/// ShixiangKillBarbarianMasterCount2
		/// </summary>
		public const int ShixiangKillBarbarianMasterCount2 = 203;

		/// <summary>
		/// ArriveLotusMountainEventTriggered
		/// </summary>
		public const int ArriveLotusMountainEventTriggered = 204;

		/// <summary>
		/// ArriveShixiangEventTriggered
		/// </summary>
		public const int ArriveShixiangEventTriggered = 205;

		/// <summary>
		/// StartFightShixiangTraitorsDate
		/// </summary>
		public const int StartFightShixiangTraitorsDate = 206;

		/// <summary>
		/// FailFinishKillTraitorOnTime
		/// </summary>
		public const int FailFinishKillTraitorOnTime = 207;

		/// <summary>
		/// SelectGoodEnd
		/// </summary>
		public const int SelectGoodEnd = 208;

		/// <summary>
		/// LeikunAvatarData
		/// </summary>
		public const int LeikunAvatarData = 209;

		/// <summary>
		/// KilledByLeiKunTaiwuName
		/// </summary>
		public const int KilledByLeiKunTaiwuName = 210;

		/// <summary>
		/// ShixiangAdventureLiteratiCharId
		/// </summary>
		public const int ShixiangAdventureLiteratiCharId = 211;

		/// <summary>
		/// EmeiSelectGoodEndCount
		/// </summary>
		public const int EmeiSelectGoodEndCount = 212;

		/// <summary>
		/// EmeiSelectBadEndCount
		/// </summary>
		public const int EmeiSelectBadEndCount = 213;

		/// <summary>
		/// EmeiFourthSelectResult
		/// </summary>
		public const int EmeiFourthSelectResult = 214;

		/// <summary>
		/// WhiteApeBlockId
		/// </summary>
		public const int WhiteApeBlockId = 215;

		/// <summary>
		/// WhiteApeBlockIdTmpSave
		/// </summary>
		public const int WhiteApeBlockIdTmpSave = 216;

		/// <summary>
		/// HomocideCase0Time
		/// </summary>
		public const int HomocideCase0Time = 217;

		/// <summary>
		/// HomocideCase1Time
		/// </summary>
		public const int HomocideCase1Time = 218;

		/// <summary>
		/// HomocideCase0Triggered
		/// </summary>
		public const int HomocideCase0Triggered = 219;

		/// <summary>
		/// HomocideCase1Triggered
		/// </summary>
		public const int HomocideCase1Triggered = 220;

		/// <summary>
		/// HomocideCase2Triggered
		/// </summary>
		public const int HomocideCase2Triggered = 221;

		/// <summary>
		/// EmeiRoleJia
		/// </summary>
		public const int EmeiRoleJia = 222;

		/// <summary>
		/// EmeiRoleYi
		/// </summary>
		public const int EmeiRoleYi = 223;

		/// <summary>
		/// EmeiRoleBing
		/// </summary>
		public const int EmeiRoleBing = 224;

		/// <summary>
		/// EmeiRoleDing
		/// </summary>
		public const int EmeiRoleDing = 225;

		/// <summary>
		/// EmeiRoleWu
		/// </summary>
		public const int EmeiRoleWu = 226;

		/// <summary>
		/// EmeiRoleSi
		/// </summary>
		public const int EmeiRoleSi = 227;

		/// <summary>
		/// EmeiRoleGeng
		/// </summary>
		public const int EmeiRoleGeng = 228;

		/// <summary>
		/// EmeiRoleXin
		/// </summary>
		public const int EmeiRoleXin = 229;

		/// <summary>
		/// TaiwuJumpCliffInjuryType
		/// </summary>
		public const int TaiwuJumpCliffInjuryType = 230;

		/// <summary>
		/// EmeiKillEachOtherStage
		/// </summary>
		public const int EmeiKillEachOtherStage = 231;

		/// <summary>
		/// EmeiHomocideCasesInteractionCount
		/// </summary>
		public const int EmeiHomocideCasesInteractionCount = 232;

		/// <summary>
		/// EmeiEmeiHomocideCasesInteractionIds
		/// </summary>
		public const int EmeiEmeiHomocideCasesInteractionIds = 233;

		/// <summary>
		/// FirstClickWhiteGibbonDate
		/// </summary>
		public const int FirstClickWhiteGibbonDate = 234;

		/// <summary>
		/// SecondClickWhiteGibbonDate
		/// </summary>
		public const int SecondClickWhiteGibbonDate = 235;

		/// <summary>
		/// ThirdClickWhiteGibbonDate
		/// </summary>
		public const int ThirdClickWhiteGibbonDate = 236;

		/// <summary>
		/// FourthClickWhiteGibbonDate
		/// </summary>
		public const int FourthClickWhiteGibbonDate = 237;

		/// <summary>
		/// FifthClickWhiteGibbonDate
		/// </summary>
		public const int FifthClickWhiteGibbonDate = 238;

		/// <summary>
		/// SixthClickWhiteGibbonDate
		/// </summary>
		public const int SixthClickWhiteGibbonDate = 239;

		/// <summary>
		/// EmeiOptionReclusiveElderVisible
		/// </summary>
		public const int EmeiOptionReclusiveElderVisible = 240;

		/// <summary>
		/// EmeiOptionWhoIsOrthodoxVisible
		/// </summary>
		public const int EmeiOptionWhoIsOrthodoxVisible = 241;

		/// <summary>
		/// EmeiLeaderOriginalLocation
		/// </summary>
		public const int EmeiLeaderOriginalLocation = 242;

		/// <summary>
		/// EmeiLeaderOriginalId
		/// </summary>
		public const int EmeiLeaderOriginalId = 243;

		/// <summary>
		/// EmeiAdventureTwoAppearDate
		/// </summary>
		public const int EmeiAdventureTwoAppearDate = 244;

		/// <summary>
		/// EmeiEnterAdventureTwo
		/// </summary>
		public const int EmeiEnterAdventureTwo = 245;

		/// <summary>
		/// EmeiPassAdventureTwoTaiwuId
		/// </summary>
		public const int EmeiPassAdventureTwoTaiwuId = 246;

		/// <summary>
		/// EmeiAdventureTwoPathEventTriggerCount
		/// </summary>
		public const int EmeiAdventureTwoPathEventTriggerCount = 247;

		/// <summary>
		/// EmeiSelectGiveUpTrace
		/// </summary>
		public const int EmeiSelectGiveUpTrace = 248;

		/// <summary>
		/// EmeiDefeatShiHoujiu
		/// </summary>
		public const int EmeiDefeatShiHoujiu = 249;

		/// <summary>
		/// EmeiWhiteGibbonFollowOpen
		/// </summary>
		public const int EmeiWhiteGibbonFollowOpen = 250;

		/// <summary>
		/// EmeiShiHoujiuFollowOpen
		/// </summary>
		public const int EmeiShiHoujiuFollowOpen = 251;

		/// <summary>
		/// EmeiBreakBonusRefreshTimes
		/// </summary>
		public const int EmeiBreakBonusRefreshTimes = 252;

		/// <summary>
		/// EmeiBreakBonusSaved
		/// </summary>
		public const int EmeiBreakBonusSaved = 253;

		/// <summary>
		/// EmeiBreakBonusTemplateIds
		/// </summary>
		public const int EmeiBreakBonusTemplateIds = 254;

		/// <summary>
		/// EmeiBreakBonusExtraPoints
		/// </summary>
		public const int EmeiBreakBonusExtraPoints = 255;

		/// <summary>
		/// EmeiGiveInShiHoujiu
		/// </summary>
		public const int EmeiGiveInShiHoujiu = 256;

		/// <summary>
		/// WuxianPrologueWugEventRecord
		/// </summary>
		public const int WuxianPrologueWugEventRecord = 257;

		/// <summary>
		/// WuxianPrologueTaiwuId
		/// </summary>
		public const int WuxianPrologueTaiwuId = 258;

		/// <summary>
		/// WuxianPrologueAddedWug
		/// </summary>
		public const int WuxianPrologueAddedWug = 259;

		/// <summary>
		/// WuxianPrologueWugAttacked
		/// </summary>
		public const int WuxianPrologueWugAttacked = 260;

		/// <summary>
		/// WuxianChapter1VisitCount
		/// </summary>
		public const int WuxianChapter1VisitCount = 261;

		/// <summary>
		/// WuxianChapter1Wish1
		/// </summary>
		public const int WuxianChapter1Wish1 = 262;

		/// <summary>
		/// WuxianChapter1Wish2
		/// </summary>
		public const int WuxianChapter1Wish2 = 263;

		/// <summary>
		/// WuxianChapter1Wish3
		/// </summary>
		public const int WuxianChapter1Wish3 = 264;

		/// <summary>
		/// WuxianChapter1WishCount
		/// </summary>
		public const int WuxianChapter1WishCount = 265;

		/// <summary>
		/// WuxianChapter1WishComeTrueCount
		/// </summary>
		public const int WuxianChapter1WishComeTrueCount = 266;

		/// <summary>
		/// WuxianChapter1Refused
		/// </summary>
		public const int WuxianChapter1Refused = 267;

		/// <summary>
		/// WuxianChapter1RanXinduLocation
		/// </summary>
		public const int WuxianChapter1RanXinduLocation = 268;

		/// <summary>
		/// WuxianChapter2Adventure1Selection
		/// </summary>
		public const int WuxianChapter2Adventure1Selection = 269;

		/// <summary>
		/// WuxianChapter2Adventure2Selection
		/// </summary>
		public const int WuxianChapter2Adventure2Selection = 270;

		/// <summary>
		/// WuxianChapter3AbleToStart
		/// </summary>
		public const int WuxianChapter3AbleToStart = 271;

		/// <summary>
		/// WuxianChapter3MailReceivedCount
		/// </summary>
		public const int WuxianChapter3MailReceivedCount = 272;

		/// <summary>
		/// WuxianChapter4AdventureComplete
		/// </summary>
		public const int WuxianChapter4AdventureComplete = 273;

		/// <summary>
		/// WuxianChapter4FinalBossBeaten
		/// </summary>
		public const int WuxianChapter4FinalBossBeaten = 274;

		/// <summary>
		/// WuxianChapter4HappyEndingEventDate
		/// </summary>
		public const int WuxianChapter4HappyEndingEventDate = 275;

		/// <summary>
		/// WuxianChapter4EndingEventTriggered
		/// </summary>
		public const int WuxianChapter4EndingEventTriggered = 276;

		/// <summary>
		/// WuxianPassLegacyEventTriggered
		/// </summary>
		public const int WuxianPassLegacyEventTriggered = 277;

		/// <summary>
		/// JingangMonkMurderedTriggeredDate
		/// </summary>
		public const int JingangMonkMurderedTriggeredDate = 278;

		/// <summary>
		/// JingangAfterMonkMurderedTriggeredMoveCount
		/// </summary>
		public const int JingangAfterMonkMurderedTriggeredMoveCount = 279;

		/// <summary>
		/// JingangGiveVillagerFood
		/// </summary>
		public const int JingangGiveVillagerFood = 280;

		/// <summary>
		/// JingangGiveVillagerFoodEventTriggered
		/// </summary>
		public const int JingangGiveVillagerFoodEventTriggered = 281;

		/// <summary>
		/// JingangGiveVillagerFoodActorData
		/// </summary>
		public const int JingangGiveVillagerFoodActorData = 282;

		/// <summary>
		/// JingangGiveVillagerMoney
		/// </summary>
		public const int JingangGiveVillagerMoney = 283;

		/// <summary>
		/// JingangGiveVillagerMoneyEventTriggered
		/// </summary>
		public const int JingangGiveVillagerMoneyEventTriggered = 284;

		/// <summary>
		/// JingangGiveVillagerMoneyActorData
		/// </summary>
		public const int JingangGiveVillagerMoneyActorData = 285;

		/// <summary>
		/// JingangGiveVillagerPromise
		/// </summary>
		public const int JingangGiveVillagerPromise = 286;

		/// <summary>
		/// JingangGiveVillagerPromiseEventTriggered
		/// </summary>
		public const int JingangGiveVillagerPromiseEventTriggered = 287;

		/// <summary>
		/// JingangGiveVillagerHelp
		/// </summary>
		public const int JingangGiveVillagerHelp = 288;

		/// <summary>
		/// JingangGiveVillagerHelpEventTriggered
		/// </summary>
		public const int JingangGiveVillagerHelpEventTriggered = 289;

		/// <summary>
		/// JingangGiveVillagerHelpActorData
		/// </summary>
		public const int JingangGiveVillagerHelpActorData = 290;

		/// <summary>
		/// JingangPersuadeVillagerCount
		/// </summary>
		public const int JingangPersuadeVillagerCount = 291;

		/// <summary>
		/// JingangTriggeredPeopleSufferingCount
		/// </summary>
		public const int JingangTriggeredPeopleSufferingCount = 292;

		/// <summary>
		/// JingangTriggeredInteractionVillagers
		/// </summary>
		public const int JingangTriggeredInteractionVillagers = 293;

		/// <summary>
		/// JingangTriggerMonthlyEventVillagerSuffer
		/// </summary>
		public const int JingangTriggerMonthlyEventVillagerSuffer = 294;

		/// <summary>
		/// JingangMonthlyEventVillagerEscapeTriggered
		/// </summary>
		public const int JingangMonthlyEventVillagerEscapeTriggered = 295;

		/// <summary>
		/// JingangAdventureNearestSettlementId
		/// </summary>
		public const int JingangAdventureNearestSettlementId = 296;

		/// <summary>
		/// JingangSecInfoSpreadingSelectCombat
		/// </summary>
		public const int JingangSecInfoSpreadingSelectCombat = 297;

		/// <summary>
		/// JingangCreateCentralPlainsMonkTaiwuAreaId
		/// </summary>
		public const int JingangCreateCentralPlainsMonkTaiwuAreaId = 298;

		/// <summary>
		/// JingangKnowSecInfoIdList
		/// </summary>
		public const int JingangKnowSecInfoIdList = 299;

		/// <summary>
		/// JingangSpreadSecInfoTotalCount
		/// </summary>
		public const int JingangSpreadSecInfoTotalCount = 300;

		/// <summary>
		/// JingangMonkSoulEnterDreamCount
		/// </summary>
		public const int JingangMonkSoulEnterDreamCount = 301;

		/// <summary>
		/// JingangSamsaraMonkSoulDreamTalkCount
		/// </summary>
		public const int JingangSamsaraMonkSoulDreamTalkCount = 302;

		/// <summary>
		/// JingangSecInfoMetaDataId
		/// </summary>
		public const int JingangSecInfoMetaDataId = 303;

		/// <summary>
		/// JingangSecInfoOccurenceId
		/// </summary>
		public const int JingangSecInfoOccurenceId = 304;

		/// <summary>
		/// JingangTalkedCentralPlainsMonkId
		/// </summary>
		public const int JingangTalkedCentralPlainsMonkId = 305;

		/// <summary>
		/// JingangSamsaraMonkSoulTalked
		/// </summary>
		public const int JingangSamsaraMonkSoulTalked = 306;

		/// <summary>
		/// JingangSamsaraMonkSoulTalkSelectBehavior
		/// </summary>
		public const int JingangSamsaraMonkSoulTalkSelectBehavior = 307;

		/// <summary>
		/// JingangAttackDate
		/// </summary>
		public const int JingangAttackDate = 308;

		/// <summary>
		/// JingangFamousFakeMonkDate
		/// </summary>
		public const int JingangFamousFakeMonkDate = 309;

		/// <summary>
		/// JingangPrayDate
		/// </summary>
		public const int JingangPrayDate = 310;

		/// <summary>
		/// JingangLettersFromJingangDate
		/// </summary>
		public const int JingangLettersFromJingangDate = 311;

		/// <summary>
		/// JingangFameDistributionDate
		/// </summary>
		public const int JingangFameDistributionDate = 312;

		/// <summary>
		/// JingangPietyCount
		/// </summary>
		public const int JingangPietyCount = 313;

		/// <summary>
		/// JingangSelectHelpWestMonk
		/// </summary>
		public const int JingangSelectHelpWestMonk = 314;

		/// <summary>
		/// JingangSecInfoSpreadingSelectBetray
		/// </summary>
		public const int JingangSecInfoSpreadingSelectBetray = 315;

		/// <summary>
		/// JingangHelpMonkEndSelectOption
		/// </summary>
		public const int JingangHelpMonkEndSelectOption = 316;

		/// <summary>
		/// JingangMonkSoulBtnDisappear
		/// </summary>
		public const int JingangMonkSoulBtnDisappear = 317;

		/// <summary>
		/// JingangDefeatShmashanaAdhipati
		/// </summary>
		public const int JingangDefeatShmashanaAdhipati = 318;

		/// <summary>
		/// JingangMonkReincarnationTriggered
		/// </summary>
		public const int JingangMonkReincarnationTriggered = 319;

		/// <summary>
		/// JingangMonkGhostVanishesTriggered
		/// </summary>
		public const int JingangMonkGhostVanishesTriggered = 320;

		/// <summary>
		/// JingangEndPartOneRefuseGiveSutra
		/// </summary>
		public const int JingangEndPartOneRefuseGiveSutra = 321;

		/// <summary>
		/// JingangWesternBuddhistMonkTalkOneTriggered
		/// </summary>
		public const int JingangWesternBuddhistMonkTalkOneTriggered = 322;

		/// <summary>
		/// JingangWesternBuddhistMonkTalkTwoTriggered
		/// </summary>
		public const int JingangWesternBuddhistMonkTalkTwoTriggered = 323;

		/// <summary>
		/// JingangWesternBuddhistMonkTalkThreeTriggered
		/// </summary>
		public const int JingangWesternBuddhistMonkTalkThreeTriggered = 324;

		/// <summary>
		/// JingangWesternBuddhistMonkPassLegacyTaiwuId
		/// </summary>
		public const int JingangWesternBuddhistMonkPassLegacyTaiwuId = 325;

		/// <summary>
		/// JingangImpersonatorBuddhistMonkPassLegacyTaiwuId
		/// </summary>
		public const int JingangImpersonatorBuddhistMonkPassLegacyTaiwuId = 326;

		/// <summary>
		/// JingangStillAtJingang
		/// </summary>
		public const int JingangStillAtJingang = 327;

		/// <summary>
		/// JingangFinishSecondSpreadSutra
		/// </summary>
		public const int JingangFinishSecondSpreadSutra = 328;

		/// <summary>
		/// JingangTriggeredChapter1Patch
		/// </summary>
		public const int JingangTriggeredChapter1Patch = 329;

		/// <summary>
		/// JingangMonkSoulResolveDreamCount
		/// </summary>
		public const int JingangMonkSoulResolveDreamCount = 330;

		/// <summary>
		/// JingangMonkSoulResolveDreamChatCount
		/// </summary>
		public const int JingangMonkSoulResolveDreamChatCount = 331;

		/// <summary>
		/// JingangGiveFakeBook
		/// </summary>
		public const int JingangGiveFakeBook = 332;

		/// <summary>
		/// JingangHelpSect
		/// </summary>
		public const int JingangHelpSect = 333;

		/// <summary>
		/// RanshanSpecialInteractionToggle
		/// </summary>
		public const int RanshanSpecialInteractionToggle = 334;

		/// <summary>
		/// RanshanChapter1MonthlyEventTriggeredCount
		/// </summary>
		public const int RanshanChapter1MonthlyEventTriggeredCount = 335;

		/// <summary>
		/// RanshanChapter1MonthlyEventTriggeredDate
		/// </summary>
		public const int RanshanChapter1MonthlyEventTriggeredDate = 336;

		/// <summary>
		/// RanshanChapter2TeachStartDate
		/// </summary>
		public const int RanshanChapter2TeachStartDate = 337;

		/// <summary>
		/// RanshanChapter2HuajuCombatPlayDecision
		/// </summary>
		public const int RanshanChapter2HuajuCombatPlayDecision = 338;

		/// <summary>
		/// RanshanChapter2XuanzhiCombatPlayDecision
		/// </summary>
		public const int RanshanChapter2XuanzhiCombatPlayDecision = 339;

		/// <summary>
		/// RanshanChapter2YingjiaoCombatPlayDecision
		/// </summary>
		public const int RanshanChapter2YingjiaoCombatPlayDecision = 340;

		/// <summary>
		/// RanshanChapter2HuajuCombatPlayDate
		/// </summary>
		public const int RanshanChapter2HuajuCombatPlayDate = 341;

		/// <summary>
		/// RanshanChapter2XuanzhiCombatPlayDate
		/// </summary>
		public const int RanshanChapter2XuanzhiCombatPlayDate = 342;

		/// <summary>
		/// RanshanChapter2YingjiaoCombatPlayDate
		/// </summary>
		public const int RanshanChapter2YingjiaoCombatPlayDate = 343;

		/// <summary>
		/// RanshanChapter2YingjiaoSelection1
		/// </summary>
		public const int RanshanChapter2YingjiaoSelection1 = 344;

		/// <summary>
		/// RanshanChapter2YingjiaoSelection2
		/// </summary>
		public const int RanshanChapter2YingjiaoSelection2 = 345;

		/// <summary>
		/// RanshanSanZongBiWuCountDown
		/// </summary>
		public const int RanshanSanZongBiWuCountDown = 346;

		/// <summary>
		/// RanshanChapter3WillingToBeImmortal
		/// </summary>
		public const int RanshanChapter3WillingToBeImmortal = 347;

		/// <summary>
		/// BaihuaVillageSettlementIdSelection
		/// </summary>
		public const int BaihuaVillageSettlementIdSelection = 348;

		/// <summary>
		/// BaihuaEndenmicTriggered
		/// </summary>
		public const int BaihuaEndenmicTriggered = 349;

		/// <summary>
		/// BaihuaDreamAboutPastFirstTriggered
		/// </summary>
		public const int BaihuaDreamAboutPastFirstTriggered = 350;

		/// <summary>
		/// BaihuaLeukorpusArrivedEventTriggered
		/// </summary>
		public const int BaihuaLeukorpusArrivedEventTriggered = 351;

		/// <summary>
		/// BaihuaMelanpsycheArrivedEventTriggered
		/// </summary>
		public const int BaihuaMelanpsycheArrivedEventTriggered = 352;

		/// <summary>
		/// BaihuaSelectDenounceSuperstitious
		/// </summary>
		public const int BaihuaSelectDenounceSuperstitious = 353;

		/// <summary>
		/// BaihuaAdventureFourAppearDate
		/// </summary>
		public const int BaihuaAdventureFourAppearDate = 354;

		/// <summary>
		/// BaihuaAnonymTaiwuIsMale
		/// </summary>
		public const int BaihuaAnonymTaiwuIsMale = 355;

		/// <summary>
		/// BaihuaDreamAboutPastLastTriggered
		/// </summary>
		public const int BaihuaDreamAboutPastLastTriggered = 356;

		/// <summary>
		/// BaihuaDreamAboutPastLastDate
		/// </summary>
		public const int BaihuaDreamAboutPastLastDate = 357;

		/// <summary>
		/// BaihuaLeMeMeetTaiwuId
		/// </summary>
		public const int BaihuaLeMeMeetTaiwuId = 358;

		/// <summary>
		/// BaihuaLeukoKillsMonthEventTriggered
		/// </summary>
		public const int BaihuaLeukoKillsMonthEventTriggered = 359;

		/// <summary>
		/// BaihuaLeukoKillsMonthEventSettlementId
		/// </summary>
		public const int BaihuaLeukoKillsMonthEventSettlementId = 360;

		/// <summary>
		/// BaihuaLeukoKillsMonthEventSettlementIdLock
		/// </summary>
		public const int BaihuaLeukoKillsMonthEventSettlementIdLock = 361;

		/// <summary>
		/// BaihuaLeukoKillsInteractOpen
		/// </summary>
		public const int BaihuaLeukoKillsInteractOpen = 362;

		/// <summary>
		/// BaihuaLeukoKillsCalledCharIds
		/// </summary>
		public const int BaihuaLeukoKillsCalledCharIds = 363;

		/// <summary>
		/// BaihuaLeukoKillsFiveElementsType
		/// </summary>
		public const int BaihuaLeukoKillsFiveElementsType = 364;

		/// <summary>
		/// BaihuaLeukoKillsOptionSelectDate
		/// </summary>
		public const int BaihuaLeukoKillsOptionSelectDate = 365;

		/// <summary>
		/// BaihuaLeukoKillsCombatWin
		/// </summary>
		public const int BaihuaLeukoKillsCombatWin = 366;

		/// <summary>
		/// BaihuaMelanoKillsMonthEventTriggered
		/// </summary>
		public const int BaihuaMelanoKillsMonthEventTriggered = 367;

		/// <summary>
		/// BaihuaMelanoKillsMonthEventSettlementId
		/// </summary>
		public const int BaihuaMelanoKillsMonthEventSettlementId = 368;

		/// <summary>
		/// BaihuaMelanoKillsMonthEventSettlementIdLock
		/// </summary>
		public const int BaihuaMelanoKillsMonthEventSettlementIdLock = 369;

		/// <summary>
		/// BaihuaMelanoKillsInteractOpen
		/// </summary>
		public const int BaihuaMelanoKillsInteractOpen = 370;

		/// <summary>
		/// BaihuaMelanoKillsCalledCharIds
		/// </summary>
		public const int BaihuaMelanoKillsCalledCharIds = 371;

		/// <summary>
		/// BaihuaMelanoKillsFiveElementsType
		/// </summary>
		public const int BaihuaMelanoKillsFiveElementsType = 372;

		/// <summary>
		/// BaihuaMelanoKillsOptionSelectDate
		/// </summary>
		public const int BaihuaMelanoKillsOptionSelectDate = 373;

		/// <summary>
		/// BaihuaMelanoKillsCombatWin
		/// </summary>
		public const int BaihuaMelanoKillsCombatWin = 374;

		/// <summary>
		/// BaihuaSpecialDebuffIntList
		/// </summary>
		public const int BaihuaSpecialDebuffIntList = 375;

		/// <summary>
		/// BaihuaCureSpecialDebuffIntList
		/// </summary>
		public const int BaihuaCureSpecialDebuffIntList = 376;

		/// <summary>
		/// BaihuaAnimalsBackDate
		/// </summary>
		public const int BaihuaAnimalsBackDate = 377;

		/// <summary>
		/// BaihuaLeukoAssistedMelano
		/// </summary>
		public const int BaihuaLeukoAssistedMelano = 378;

		/// <summary>
		/// BaihuaMelanoAssistedLeuko
		/// </summary>
		public const int BaihuaMelanoAssistedLeuko = 379;

		/// <summary>
		/// BaihuaManicLowDate
		/// </summary>
		public const int BaihuaManicLowDate = 380;

		/// <summary>
		/// BaihuaManicHighDate
		/// </summary>
		public const int BaihuaManicHighDate = 381;

		/// <summary>
		/// BaihuaTriggerFinaleTaskDate
		/// </summary>
		public const int BaihuaTriggerFinaleTaskDate = 382;

		/// <summary>
		/// BaihuaBaiLuFirstInteractTriggered
		/// </summary>
		public const int BaihuaBaiLuFirstInteractTriggered = 383;

		/// <summary>
		/// BaihuaXuanXiaoFirstInteractTriggered
		/// </summary>
		public const int BaihuaXuanXiaoFirstInteractTriggered = 384;

		/// <summary>
		/// BaihuaAdventureFinialWinSect
		/// </summary>
		public const int BaihuaAdventureFinialWinSect = 385;

		/// <summary>
		/// BaihuaLeukoDialogNotTriggered
		/// </summary>
		public const int BaihuaLeukoDialogNotTriggered = 386;

		/// <summary>
		/// BaihuaMelanoDialogNotTriggered
		/// </summary>
		public const int BaihuaMelanoDialogNotTriggered = 387;

		/// <summary>
		/// BaihuaLeukoPlayCount
		/// </summary>
		public const int BaihuaLeukoPlayCount = 388;

		/// <summary>
		/// BaihuaMelanoPlayCount
		/// </summary>
		public const int BaihuaMelanoPlayCount = 389;

		/// <summary>
		/// BaihuaLMPlayCount
		/// </summary>
		public const int BaihuaLMPlayCount = 390;

		/// <summary>
		/// BaihuaLMNewsTalkedCharIds
		/// </summary>
		public const int BaihuaLMNewsTalkedCharIds = 391;

		/// <summary>
		/// BaihuaLMTransferAnimalDate
		/// </summary>
		public const int BaihuaLMTransferAnimalDate = 392;

		/// <summary>
		/// BaihuaFixedLMFavor
		/// </summary>
		public const int BaihuaFixedLMFavor = 393;

		/// <summary>
		/// FulongDisasterStart
		/// </summary>
		public const int FulongDisasterStart = 394;

		/// <summary>
		/// FulongDisasterMonthlyEventTriggered
		/// </summary>
		public const int FulongDisasterMonthlyEventTriggered = 395;

		/// <summary>
		/// FulongDisasterStartProb
		/// </summary>
		public const int FulongDisasterStartProb = 396;

		/// <summary>
		/// FulongFireFightingGuideTriggered
		/// </summary>
		public const int FulongFireFightingGuideTriggered = 397;

		/// <summary>
		/// FulongAdventureOneCountDown
		/// </summary>
		public const int FulongAdventureOneCountDown = 398;

		/// <summary>
		/// FulongAdventureThreeCountDown
		/// </summary>
		public const int FulongAdventureThreeCountDown = 399;

		/// <summary>
		/// FulongAdventureStartTime
		/// </summary>
		public const int FulongAdventureStartTime = 400;

		/// <summary>
		/// FulongAdventureTwoTaiwuId
		/// </summary>
		public const int FulongAdventureTwoTaiwuId = 401;

		/// <summary>
		/// FulongShadowEventTriggeredCount
		/// </summary>
		public const int FulongShadowEventTriggeredCount = 402;

		/// <summary>
		/// FulongShadowEventOneTriggered
		/// </summary>
		public const int FulongShadowEventOneTriggered = 403;

		/// <summary>
		/// FulongShadowEventTwoTriggered
		/// </summary>
		public const int FulongShadowEventTwoTriggered = 404;

		/// <summary>
		/// FulongReudhLazuliChatMysteryOpen
		/// </summary>
		public const int FulongReudhLazuliChatMysteryOpen = 405;

		/// <summary>
		/// FulongReudhLazuliChatMysteryCount
		/// </summary>
		public const int FulongReudhLazuliChatMysteryCount = 406;

		/// <summary>
		/// FulongReudhLazuliAI2
		/// </summary>
		public const int FulongReudhLazuliAI2 = 407;

		/// <summary>
		/// FulongTravelWithLazuliWorldViewTriggered
		/// </summary>
		public const int FulongTravelWithLazuliWorldViewTriggered = 408;

		/// <summary>
		/// FulongSpecialInteractOpen
		/// </summary>
		public const int FulongSpecialInteractOpen = 409;

		/// <summary>
		/// FulongTravelWithLazuliCityTriggered
		/// </summary>
		public const int FulongTravelWithLazuliCityTriggered = 410;

		/// <summary>
		/// FulongTravelWithLazuliTaiwuVillageTriggered
		/// </summary>
		public const int FulongTravelWithLazuliTaiwuVillageTriggered = 411;

		/// <summary>
		/// FulongTravelWithLazuliSectTriggered
		/// </summary>
		public const int FulongTravelWithLazuliSectTriggered = 412;

		/// <summary>
		/// FulongTravelWithLazuliTownTriggered
		/// </summary>
		public const int FulongTravelWithLazuliTownTriggered = 413;

		/// <summary>
		/// FulongTravelWithLazuliStockadeTriggered
		/// </summary>
		public const int FulongTravelWithLazuliStockadeTriggered = 414;

		/// <summary>
		/// FulongTravelWithLazuliVillageTriggered
		/// </summary>
		public const int FulongTravelWithLazuliVillageTriggered = 415;

		/// <summary>
		/// FulongTravelWithLazuliXiangshuMinionTriggered
		/// </summary>
		public const int FulongTravelWithLazuliXiangshuMinionTriggered = 416;

		/// <summary>
		/// FulongTravelWithLazuliAnimalTriggered
		/// </summary>
		public const int FulongTravelWithLazuliAnimalTriggered = 417;

		/// <summary>
		/// FulongTravelWithLazuliRandomEnemyTriggered
		/// </summary>
		public const int FulongTravelWithLazuliRandomEnemyTriggered = 418;

		/// <summary>
		/// FulongTravelWithLazuliMonvTalkTriggered
		/// </summary>
		public const int FulongTravelWithLazuliMonvTalkTriggered = 419;

		/// <summary>
		/// FulongTravelWithLazuliMoveCount
		/// </summary>
		public const int FulongTravelWithLazuliMoveCount = 420;

		/// <summary>
		/// FulongChickenKingLetterMoveCount
		/// </summary>
		public const int FulongChickenKingLetterMoveCount = 421;

		/// <summary>
		/// FulongTravelWithLazuliMoveAreaId
		/// </summary>
		public const int FulongTravelWithLazuliMoveAreaId = 422;

		/// <summary>
		/// FulongTravelWithLazuliChicken1
		/// </summary>
		public const int FulongTravelWithLazuliChicken1 = 423;

		/// <summary>
		/// FulongTravelWithLazuliChicken2
		/// </summary>
		public const int FulongTravelWithLazuliChicken2 = 424;

		/// <summary>
		/// FulongTravelWithLazuliFinished
		/// </summary>
		public const int FulongTravelWithLazuliFinished = 425;

		/// <summary>
		/// FulongLazuliIsFriend
		/// </summary>
		public const int FulongLazuliIsFriend = 426;

		/// <summary>
		/// FulongSelectFalling
		/// </summary>
		public const int FulongSelectFalling = 427;

		/// <summary>
		/// FulongSelectFallingDate
		/// </summary>
		public const int FulongSelectFallingDate = 428;

		/// <summary>
		/// FulongReudhLazuliFeatherFollowOpen
		/// </summary>
		public const int FulongReudhLazuliFeatherFollowOpen = 429;

		/// <summary>
		/// FulongMessengerAppearTime
		/// </summary>
		public const int FulongMessengerAppearTime = 430;

		/// <summary>
		/// FulongLoseChickenFeatherInteractionSettlements
		/// </summary>
		public const int FulongLoseChickenFeatherInteractionSettlements = 431;

		/// <summary>
		/// FulongLazuliLetterTriggered
		/// </summary>
		public const int FulongLazuliLetterTriggered = 432;

		/// <summary>
		/// FulongLazuliLetterEventA
		/// </summary>
		public const int FulongLazuliLetterEventA = 433;

		/// <summary>
		/// FulongLazuliLetterEventB
		/// </summary>
		public const int FulongLazuliLetterEventB = 434;

		/// <summary>
		/// FulongLazuliLetterEventC
		/// </summary>
		public const int FulongLazuliLetterEventC = 435;

		/// <summary>
		/// FulongPutOutFireCount
		/// </summary>
		public const int FulongPutOutFireCount = 436;

		/// <summary>
		/// FulongFireStartTime
		/// </summary>
		public const int FulongFireStartTime = 437;

		/// <summary>
		/// FulongPutOutFire
		/// </summary>
		public const int FulongPutOutFire = 438;

		/// <summary>
		/// FulongPutOutFireOnce
		/// </summary>
		public const int FulongPutOutFireOnce = 439;

		/// <summary>
		/// FulongChickenFeatherLackCount
		/// </summary>
		public const int FulongChickenFeatherLackCount = 440;

		/// <summary>
		/// FulongLazuliFindFlowerDialogLevel
		/// </summary>
		public const int FulongLazuliFindFlowerDialogLevel = 441;

		/// <summary>
		/// FulongStayWithLazuliTaskTriggerDate
		/// </summary>
		public const int FulongStayWithLazuliTaskTriggerDate = 442;

		/// <summary>
		/// FulongMessengerIdList
		/// </summary>
		public const int FulongMessengerIdList = 443;

		/// <summary>
		/// FulongChickenKingLeaveHome
		/// </summary>
		public const int FulongChickenKingLeaveHome = 444;

		/// <summary>
		/// FulongChickenFeatherDropList
		/// </summary>
		public const int FulongChickenFeatherDropList = 445;

		/// <summary>
		/// ZhujianCatchThiefTimes
		/// </summary>
		public const int ZhujianCatchThiefTimes = 446;

		/// <summary>
		/// EmeiStrangerTriggerDate
		/// </summary>
		public const int EmeiStrangerTriggerDate = 447;

		/// <summary>
		/// EmeiInteractionOneTriggeredList
		/// </summary>
		public const int EmeiInteractionOneTriggeredList = 448;

		/// <summary>
		/// EmeiInteractionTwoTriggeredList
		/// </summary>
		public const int EmeiInteractionTwoTriggeredList = 449;

		/// <summary>
		/// EmeiFirstMonthlyEventTriggered
		/// </summary>
		public const int EmeiFirstMonthlyEventTriggered = 450;

		/// <summary>
		/// XuehouKillJixi
		/// </summary>
		public const int XuehouKillJixi = 451;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// IsKillLiaoWuming
		/// </summary>
		public static SectMainStoryEventArgKeyItem IsKillLiaoWuming => Instance[0];

		/// <summary>
		/// IsKilledByLiaoWuming
		/// </summary>
		public static SectMainStoryEventArgKeyItem IsKilledByLiaoWuming => Instance[1];

		/// <summary>
		/// LiaoWumingQuestStartDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem LiaoWumingQuestStartDate => Instance[2];

		/// <summary>
		/// LiaoWumingGetPoison
		/// </summary>
		public static SectMainStoryEventArgKeyItem LiaoWumingGetPoison => Instance[3];

		/// <summary>
		/// TheNameGivePoisonToLiaoWuming
		/// </summary>
		public static SectMainStoryEventArgKeyItem TheNameGivePoisonToLiaoWuming => Instance[4];

		/// <summary>
		/// KongsangAdventureCountDown
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangAdventureCountDown => Instance[5];

		/// <summary>
		/// GetKongsangInformation1
		/// </summary>
		public static SectMainStoryEventArgKeyItem GetKongsangInformation1 => Instance[6];

		/// <summary>
		/// GetKongsangInformation2
		/// </summary>
		public static SectMainStoryEventArgKeyItem GetKongsangInformation2 => Instance[7];

		/// <summary>
		/// InteractWithLiaoWumingAi2
		/// </summary>
		public static SectMainStoryEventArgKeyItem InteractWithLiaoWumingAi2 => Instance[8];

		/// <summary>
		/// KongsangAcceptTaskTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangAcceptTaskTaiwuId => Instance[9];

		/// <summary>
		/// KongsangFirstPassingLegacyTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangFirstPassingLegacyTaiwuId => Instance[10];

		/// <summary>
		/// KongsangFirstPassingLegacyDialogTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangFirstPassingLegacyDialogTriggered => Instance[11];

		/// <summary>
		/// KongsangSecondPassingLegacyDialogCharId
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangSecondPassingLegacyDialogCharId => Instance[12];

		/// <summary>
		/// KongsangStoryPartOneTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangStoryPartOneTriggered => Instance[13];

		/// <summary>
		/// KongsangPart3TaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangPart3TaiwuId => Instance[14];

		/// <summary>
		/// FirstTryPoisonIsFailure
		/// </summary>
		public static SectMainStoryEventArgKeyItem FirstTryPoisonIsFailure => Instance[15];

		/// <summary>
		/// SecondTryPoisonIsFailure
		/// </summary>
		public static SectMainStoryEventArgKeyItem SecondTryPoisonIsFailure => Instance[16];

		/// <summary>
		/// ThirdTryPoisonIsFailure
		/// </summary>
		public static SectMainStoryEventArgKeyItem ThirdTryPoisonIsFailure => Instance[17];

		/// <summary>
		/// TripodVesselOfMedicineAreaId
		/// </summary>
		public static SectMainStoryEventArgKeyItem TripodVesselOfMedicineAreaId => Instance[18];

		/// <summary>
		/// ActingHeadActorData
		/// </summary>
		public static SectMainStoryEventArgKeyItem ActingHeadActorData => Instance[19];

		/// <summary>
		/// KongsangSectLeaderId
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangSectLeaderId => Instance[20];

		/// <summary>
		/// BeforePoisonTest0EventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BeforePoisonTest0EventTriggered => Instance[21];

		/// <summary>
		/// BeforePoisonTest0EventFirstTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BeforePoisonTest0EventFirstTriggered => Instance[22];

		/// <summary>
		/// BeforePoisonTest1EventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BeforePoisonTest1EventTriggered => Instance[23];

		/// <summary>
		/// MissionUnacceptedEventTriggeredSameMonth
		/// </summary>
		public static SectMainStoryEventArgKeyItem MissionUnacceptedEventTriggeredSameMonth => Instance[24];

		/// <summary>
		/// KongsangTargetFoundEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem KongsangTargetFoundEventTriggered => Instance[25];

		/// <summary>
		/// XuehouStoryPartOneTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouStoryPartOneTriggered => Instance[26];

		/// <summary>
		/// StillAtYangzhou
		/// </summary>
		public static SectMainStoryEventArgKeyItem StillAtYangzhou => Instance[27];

		/// <summary>
		/// FirstGotBellTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem FirstGotBellTime => Instance[28];

		/// <summary>
		/// MeetSkeletonWithBellExtraProb
		/// </summary>
		public static SectMainStoryEventArgKeyItem MeetSkeletonWithBellExtraProb => Instance[29];

		/// <summary>
		/// XuehouGraveDiggingEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouGraveDiggingEventTriggered => Instance[30];

		/// <summary>
		/// DefeatXuehouOldManTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem DefeatXuehouOldManTime => Instance[31];

		/// <summary>
		/// GiveBellToXuehouOldManTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem GiveBellToXuehouOldManTime => Instance[32];

		/// <summary>
		/// XuehouOldManGraveDisappearTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouOldManGraveDisappearTriggered => Instance[33];

		/// <summary>
		/// XuehouOldManCharacterId
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouOldManCharacterId => Instance[34];

		/// <summary>
		/// OldManZombieInteractTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem OldManZombieInteractTriggered => Instance[35];

		/// <summary>
		/// AwakeJixiTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem AwakeJixiTaiwuId => Instance[36];

		/// <summary>
		/// AwakeJixiTaiwuGender
		/// </summary>
		public static SectMainStoryEventArgKeyItem AwakeJixiTaiwuGender => Instance[37];

		/// <summary>
		/// AwakeJixiAndPassLegacy
		/// </summary>
		public static SectMainStoryEventArgKeyItem AwakeJixiAndPassLegacy => Instance[38];

		/// <summary>
		/// PassXuehouAdventure1Time
		/// </summary>
		public static SectMainStoryEventArgKeyItem PassXuehouAdventure1Time => Instance[39];

		/// <summary>
		/// XuehouEmptyCaveTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouEmptyCaveTriggered => Instance[40];

		/// <summary>
		/// XuehouFindPeopleTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouFindPeopleTriggered => Instance[41];

		/// <summary>
		/// XuehouComingTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouComingTime => Instance[42];

		/// <summary>
		/// XuehouComingTriggeredCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouComingTriggeredCount => Instance[43];

		/// <summary>
		/// JixiArrivedTaiwuDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiArrivedTaiwuDate => Instance[44];

		/// <summary>
		/// JixiArrivedTaiwuMonthlyEventTriggeredCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiArrivedTaiwuMonthlyEventTriggeredCount => Instance[45];

		/// <summary>
		/// JixiAdventureOnePassDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAdventureOnePassDate => Instance[46];

		/// <summary>
		/// JixiAdventureTwoPassDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAdventureTwoPassDate => Instance[47];

		/// <summary>
		/// JixiAdventureThreePassDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAdventureThreePassDate => Instance[48];

		/// <summary>
		/// JixiAdventureOneStartDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAdventureOneStartDate => Instance[49];

		/// <summary>
		/// JixiAdventureTwoStartDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAdventureTwoStartDate => Instance[50];

		/// <summary>
		/// JixiAdventureThreeStartDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAdventureThreeStartDate => Instance[51];

		/// <summary>
		/// JixiAdventureFourStartDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAdventureFourStartDate => Instance[52];

		/// <summary>
		/// ProtectedJixiEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ProtectedJixiEventTriggered => Instance[53];

		/// <summary>
		/// JixiFeedChickenEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiFeedChickenEventTriggered => Instance[54];

		/// <summary>
		/// JixiHarmVillagerEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiHarmVillagerEventTriggered => Instance[55];

		/// <summary>
		/// HaveJixiTruthClueCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem HaveJixiTruthClueCount => Instance[56];

		/// <summary>
		/// HaveJixiFalseClueCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem HaveJixiFalseClueCount => Instance[57];

		/// <summary>
		/// JixiWaitingMonthKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiWaitingMonthKey => Instance[58];

		/// <summary>
		/// JixiStayAtGraveMonthKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiStayAtGraveMonthKey => Instance[59];

		/// <summary>
		/// JixiKilledCountKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiKilledCountKey => Instance[60];

		/// <summary>
		/// CombatWithUltimateZombieTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem CombatWithUltimateZombieTriggered => Instance[61];

		/// <summary>
		/// JixiLegacyPassFirstTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiLegacyPassFirstTalkTriggered => Instance[62];

		/// <summary>
		/// JixiSoulTransformFirstTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiSoulTransformFirstTalkTriggered => Instance[63];

		/// <summary>
		/// PassLegacyMonthlyNotificationTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem PassLegacyMonthlyNotificationTriggered => Instance[64];

		/// <summary>
		/// NeedTriggerPassLegacyMonthlyNotification
		/// </summary>
		public static SectMainStoryEventArgKeyItem NeedTriggerPassLegacyMonthlyNotification => Instance[65];

		/// <summary>
		/// XuehouOldManHasBell
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouOldManHasBell => Instance[66];

		/// <summary>
		/// JixiHasAntiqueJadeBat
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiHasAntiqueJadeBat => Instance[67];

		/// <summary>
		/// JixiHasAntiqueJadeFox
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiHasAntiqueJadeFox => Instance[68];

		/// <summary>
		/// JixiHasAntiqueJadeButterfly
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiHasAntiqueJadeButterfly => Instance[69];

		/// <summary>
		/// JixiFavorite1TalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiFavorite1TalkTriggered => Instance[70];

		/// <summary>
		/// JixiFavorite2TalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiFavorite2TalkTriggered => Instance[71];

		/// <summary>
		/// JixiFavorite3TalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiFavorite3TalkTriggered => Instance[72];

		/// <summary>
		/// JixiFavorite4TalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiFavorite4TalkTriggered => Instance[73];

		/// <summary>
		/// JixiFavorite5TalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiFavorite5TalkTriggered => Instance[74];

		/// <summary>
		/// JixiLikeKillTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiLikeKillTalkTriggered => Instance[75];

		/// <summary>
		/// JixiPassLegacyTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiPassLegacyTalkTriggered => Instance[76];

		/// <summary>
		/// JixiKillEnemyTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiKillEnemyTalkTriggered => Instance[77];

		/// <summary>
		/// JixiKilledEnemy
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiKilledEnemy => Instance[78];

		/// <summary>
		/// JixiFollowOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiFollowOpen => Instance[79];

		/// <summary>
		/// XuehouSelectFreeJixi
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouSelectFreeJixi => Instance[80];

		/// <summary>
		/// XuehouGraveDiggingNormalTriggerTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouGraveDiggingNormalTriggerTime => Instance[81];

		/// <summary>
		/// JixiAnimalTalkOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem JixiAnimalTalkOpen => Instance[82];

		/// <summary>
		/// XuannvStoryTriggerFirstTrack
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryTriggerFirstTrack => Instance[83];

		/// <summary>
		/// XuannvStoryPartOneTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneTriggered => Instance[84];

		/// <summary>
		/// XuannvStoryTaiwuCharId
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryTaiwuCharId => Instance[85];

		/// <summary>
		/// XuannvStoryPartOneIsReceivingLetter
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneIsReceivingLetter => Instance[86];

		/// <summary>
		/// XuannvStoryPartOneLetterCountA
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLetterCountA => Instance[87];

		/// <summary>
		/// XuannvStoryPartOneLetterCountB
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLetterCountB => Instance[88];

		/// <summary>
		/// XuannvStoryPartOneLetterCountC
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLetterCountC => Instance[89];

		/// <summary>
		/// XuannvStoryPartOneOptionMarkKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneOptionMarkKey => Instance[90];

		/// <summary>
		/// XuannvStoryPartOneLegendaryDoctor
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLegendaryDoctor => Instance[91];

		/// <summary>
		/// XuannvStoryPartOneWaitSecretGuestEvent
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneWaitSecretGuestEvent => Instance[92];

		/// <summary>
		/// XuannvStoryPartOneSecretGuestActorKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneSecretGuestActorKey => Instance[93];

		/// <summary>
		/// XuannvStoryPartOneGuessGenderKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneGuessGenderKey => Instance[94];

		/// <summary>
		/// XuannvStoryPartOneOptionInjectFlag
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneOptionInjectFlag => Instance[95];

		/// <summary>
		/// XuannvStoryPartOneNoneSectNpcInquireSecretGuest1
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneNoneSectNpcInquireSecretGuest1 => Instance[96];

		/// <summary>
		/// XuannvStoryPartOneNoneSectNpcInquireSecretGuest2
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneNoneSectNpcInquireSecretGuest2 => Instance[97];

		/// <summary>
		/// XuannvStoryPartOneNoneSectNpcInquireSecretGuest3
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneNoneSectNpcInquireSecretGuest3 => Instance[98];

		/// <summary>
		/// XuannvStoryPartTwoOptionInjectFlag
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartTwoOptionInjectFlag => Instance[99];

		/// <summary>
		/// XuannvStoryPartTwoCombatSkillType
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartTwoCombatSkillType => Instance[100];

		/// <summary>
		/// XuannvStoryPartThreeLearningSkill
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkill => Instance[101];

		/// <summary>
		/// XuannvStoryPartThreeLearningSkillId0
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkillId0 => Instance[102];

		/// <summary>
		/// XuannvStoryPartThreeLearningSkillId1
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkillId1 => Instance[103];

		/// <summary>
		/// XuannvStoryPartThreeLearningSkillId2
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkillId2 => Instance[104];

		/// <summary>
		/// XuannvStoryPartTwoRefuseToHelpCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartTwoRefuseToHelpCount => Instance[105];

		/// <summary>
		/// XuannvStoryPartThreeSearchLoverCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeSearchLoverCount => Instance[106];

		/// <summary>
		/// XuannvStoryPartThreeSearchLoverSecondTakeLoverDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeSearchLoverSecondTakeLoverDate => Instance[107];

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateSettlementId1
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateSettlementId1 => Instance[108];

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateSettlementId2
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateSettlementId2 => Instance[109];

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateSettlementId3
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateSettlementId3 => Instance[110];

		/// <summary>
		/// XuannvStoryPartThreeLoverReincarnateLocation
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateLocation => Instance[111];

		/// <summary>
		/// XuannvStoryPartThreeWaitLoverNameKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeWaitLoverNameKey => Instance[112];

		/// <summary>
		/// XuannvStoryMonthlyEventWithSisterTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryMonthlyEventWithSisterTriggered => Instance[113];

		/// <summary>
		/// XuannvStoryPartThreeHasTalkToShiWeizhi
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeHasTalkToShiWeizhi => Instance[114];

		/// <summary>
		/// XuannvStoryPartThreeActorSisterOfShiWeizhi
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeActorSisterOfShiWeizhi => Instance[115];

		/// <summary>
		/// XuannvStoryPartThreeGirlGodIllusion
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeGirlGodIllusion => Instance[116];

		/// <summary>
		/// XuannvStoryOptionReadFlag1
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag1 => Instance[117];

		/// <summary>
		/// XuannvStoryOptionReadFlag2
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag2 => Instance[118];

		/// <summary>
		/// XuannvStoryOptionReadFlag3
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag3 => Instance[119];

		/// <summary>
		/// XuannvStoryOptionReadFlag4
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag4 => Instance[120];

		/// <summary>
		/// XuannvStoryHeYouyuanCharId
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryHeYouyuanCharId => Instance[121];

		/// <summary>
		/// XuannvStorySecretReincarnationNpcCharId
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStorySecretReincarnationNpcCharId => Instance[122];

		/// <summary>
		/// XuannvStoryIsJunerAtXuannvSect
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryIsJunerAtXuannvSect => Instance[123];

		/// <summary>
		/// XuannvStoryMusicUnlock10FirstFlag
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryMusicUnlock10FirstFlag => Instance[124];

		/// <summary>
		/// XuannvStoryMusicUnlock40FirstFlag
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryMusicUnlock40FirstFlag => Instance[125];

		/// <summary>
		/// XuannvStoryMusicUnlock45MusicWeaponFlag
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvStoryMusicUnlock45MusicWeaponFlag => Instance[126];

		/// <summary>
		/// XuannvLastDateOfAdventureIllusionOfMirror
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuannvLastDateOfAdventureIllusionOfMirror => Instance[127];

		/// <summary>
		/// ShaolinMythinLowMemberTalked
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinMythinLowMemberTalked => Instance[128];

		/// <summary>
		/// ShaolinMythinMiddleMemberTalked
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinMythinMiddleMemberTalked => Instance[129];

		/// <summary>
		/// ShaolinStatueReturnTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinStatueReturnTriggered => Instance[130];

		/// <summary>
		/// ShaolinMonthlyEventNotEnoughDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinMonthlyEventNotEnoughDate => Instance[131];

		/// <summary>
		/// DamoDreamMeetTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem DamoDreamMeetTaiwuId => Instance[132];

		/// <summary>
		/// ShaolinCombatSkillType
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinCombatSkillType => Instance[133];

		/// <summary>
		/// ShaolinLearnedAny
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinLearnedAny => Instance[134];

		/// <summary>
		/// ShaolinDamoFightTimes
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinDamoFightTimes => Instance[135];

		/// <summary>
		/// ShaolinDamoFightWinDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinDamoFightWinDate => Instance[136];

		/// <summary>
		/// ShaolinStudyForBodhidharmaChallenge
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinStudyForBodhidharmaChallenge => Instance[137];

		/// <summary>
		/// ShaolinDamoTrialTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinDamoTrialTriggered => Instance[138];

		/// <summary>
		/// ShaolinDamoFightTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinDamoFightTriggered => Instance[139];

		/// <summary>
		/// ShaolinDamoVisitTimes
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinDamoVisitTimes => Instance[140];

		/// <summary>
		/// ShaolinReadingMaxGradeSutra
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinReadingMaxGradeSutra => Instance[141];

		/// <summary>
		/// ShaolinSutraPavilionGuardDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinSutraPavilionGuardDate => Instance[142];

		/// <summary>
		/// ShaolinDamoLearnedFightTimes
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinDamoLearnedFightTimes => Instance[143];

		/// <summary>
		/// ShaolinComprehendedTheZen
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinComprehendedTheZen => Instance[144];

		/// <summary>
		/// ShaolinMeditationInteractionFinished
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinMeditationInteractionFinished => Instance[145];

		/// <summary>
		/// ShaolinInteractionChangeTip1Triggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinInteractionChangeTip1Triggered => Instance[146];

		/// <summary>
		/// ShaolinInteractionChangeTip2Triggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShaolinInteractionChangeTip2Triggered => Instance[147];

		/// <summary>
		/// WudangSkillReverseBreakCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangSkillReverseBreakCount => Instance[148];

		/// <summary>
		/// CombatWithTaoistMonkDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem CombatWithTaoistMonkDate => Instance[149];

		/// <summary>
		/// CombatWithTaoistMonkTaiwuName
		/// </summary>
		public static SectMainStoryEventArgKeyItem CombatWithTaoistMonkTaiwuName => Instance[150];

		/// <summary>
		/// AtLastCombatWithTaoistMonkTaiwuName
		/// </summary>
		public static SectMainStoryEventArgKeyItem AtLastCombatWithTaoistMonkTaiwuName => Instance[151];

		/// <summary>
		/// BlackSnakeCustomName
		/// </summary>
		public static SectMainStoryEventArgKeyItem BlackSnakeCustomName => Instance[152];

		/// <summary>
		/// GiveTaoistTreasureCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem GiveTaoistTreasureCount => Instance[153];

		/// <summary>
		/// GiveTaoistTreasureItemKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem GiveTaoistTreasureItemKey => Instance[154];

		/// <summary>
		/// WudangChatEventTriggeredCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangChatEventTriggeredCount => Instance[155];

		/// <summary>
		/// WudangSankeFighted
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangSankeFighted => Instance[156];

		/// <summary>
		/// WudangFrontEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangFrontEventTriggered => Instance[157];

		/// <summary>
		/// LastEventSloppyTaoistMonkFavor
		/// </summary>
		public static SectMainStoryEventArgKeyItem LastEventSloppyTaoistMonkFavor => Instance[158];

		/// <summary>
		/// GetExtraSeedCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem GetExtraSeedCount => Instance[159];

		/// <summary>
		/// FinishFairylandStoryCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem FinishFairylandStoryCount => Instance[160];

		/// <summary>
		/// TriggeredFailureEvent
		/// </summary>
		public static SectMainStoryEventArgKeyItem TriggeredFailureEvent => Instance[161];

		/// <summary>
		/// WudangKillRandomEnemyTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangKillRandomEnemyTriggered => Instance[162];

		/// <summary>
		/// GivenMonkSnakeItemKey
		/// </summary>
		public static SectMainStoryEventArgKeyItem GivenMonkSnakeItemKey => Instance[163];

		/// <summary>
		/// GivenMonkSnakeList
		/// </summary>
		public static SectMainStoryEventArgKeyItem GivenMonkSnakeList => Instance[164];

		/// <summary>
		/// WudangEasterEggTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangEasterEggTriggered => Instance[165];

		/// <summary>
		/// WudangHeavenlyTreeSeedTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangHeavenlyTreeSeedTalkTriggered => Instance[166];

		/// <summary>
		/// WudangFairylandTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangFairylandTalkTriggered => Instance[167];

		/// <summary>
		/// WudangTortoiseSnakeTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangTortoiseSnakeTalkTriggered => Instance[168];

		/// <summary>
		/// WudangEmperorTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WudangEmperorTalkTriggered => Instance[169];

		/// <summary>
		/// MeetImmortalEventCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem MeetImmortalEventCount => Instance[170];

		/// <summary>
		/// CollectHeavenlyTreeSeedFirstTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem CollectHeavenlyTreeSeedFirstTriggered => Instance[171];

		/// <summary>
		/// YuanshanDemonOutOfJail
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanDemonOutOfJail => Instance[172];

		/// <summary>
		/// TaiwuReleasedYuanshanDemon
		/// </summary>
		public static SectMainStoryEventArgKeyItem TaiwuReleasedYuanshanDemon => Instance[173];

		/// <summary>
		/// YuanshanLeaderFirmDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanLeaderFirmDate => Instance[174];

		/// <summary>
		/// YuanshanDemonDormantDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanDemonDormantDate => Instance[175];

		/// <summary>
		/// MythInYuanshanTriggeredDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem MythInYuanshanTriggeredDate => Instance[176];

		/// <summary>
		/// YuanshanInteractionTriggeredCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanInteractionTriggeredCount => Instance[177];

		/// <summary>
		/// YuanshanThoughtsTriggeredCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanThoughtsTriggeredCount => Instance[178];

		/// <summary>
		/// YuanshanThoughtsInteractable
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanThoughtsInteractable => Instance[179];

		/// <summary>
		/// YuanshanLobbyTalkInteractable
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanLobbyTalkInteractable => Instance[180];

		/// <summary>
		/// YuanshanDemonPower
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanDemonPower => Instance[181];

		/// <summary>
		/// KilledYuanshanDemonCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem KilledYuanshanDemonCount => Instance[182];

		/// <summary>
		/// YuanshanCaelumDemonDefeatedTaiwu
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanCaelumDemonDefeatedTaiwu => Instance[183];

		/// <summary>
		/// YuanshanTerraDemonDefeatedTaiwu
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanTerraDemonDefeatedTaiwu => Instance[184];

		/// <summary>
		/// YuanshanAnthropDemonDefeatedTaiwu
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanAnthropDemonDefeatedTaiwu => Instance[185];

		/// <summary>
		/// YuanshanDemonMeetTaiwuCharId
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanDemonMeetTaiwuCharId => Instance[186];

		/// <summary>
		/// YuanshanDemonLast
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanDemonLast => Instance[187];

		/// <summary>
		/// YuanshanToFightDemon
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanToFightDemon => Instance[188];

		/// <summary>
		/// YuanshanMiniGameStage
		/// </summary>
		public static SectMainStoryEventArgKeyItem YuanshanMiniGameStage => Instance[189];

		/// <summary>
		/// AreVitalsDemon
		/// </summary>
		public static SectMainStoryEventArgKeyItem AreVitalsDemon => Instance[190];

		/// <summary>
		/// ShixiangAdventureAppearDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangAdventureAppearDate => Instance[191];

		/// <summary>
		/// ShixiangFirstLetterDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangFirstLetterDate => Instance[192];

		/// <summary>
		/// ShixiangLetterCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangLetterCount => Instance[193];

		/// <summary>
		/// ShixiangToFightEnemy
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangToFightEnemy => Instance[194];

		/// <summary>
		/// MockShixiangEventTriggeredSettlementId
		/// </summary>
		public static SectMainStoryEventArgKeyItem MockShixiangEventTriggeredSettlementId => Instance[195];

		/// <summary>
		/// MockShixiangEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem MockShixiangEventTriggered => Instance[196];

		/// <summary>
		/// MockShixiangEventCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem MockShixiangEventCount => Instance[197];

		/// <summary>
		/// ShixiangStoryPartOneTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangStoryPartOneTriggered => Instance[198];

		/// <summary>
		/// ShixiangAdventureWon
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangAdventureWon => Instance[199];

		/// <summary>
		/// TaiwuKillBarbarianMasterCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem TaiwuKillBarbarianMasterCount => Instance[200];

		/// <summary>
		/// ShixiangKillBarbarianMasterCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangKillBarbarianMasterCount => Instance[201];

		/// <summary>
		/// TaiwuKillBarbarianMasterCount2
		/// </summary>
		public static SectMainStoryEventArgKeyItem TaiwuKillBarbarianMasterCount2 => Instance[202];

		/// <summary>
		/// ShixiangKillBarbarianMasterCount2
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangKillBarbarianMasterCount2 => Instance[203];

		/// <summary>
		/// ArriveLotusMountainEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ArriveLotusMountainEventTriggered => Instance[204];

		/// <summary>
		/// ArriveShixiangEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem ArriveShixiangEventTriggered => Instance[205];

		/// <summary>
		/// StartFightShixiangTraitorsDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem StartFightShixiangTraitorsDate => Instance[206];

		/// <summary>
		/// FailFinishKillTraitorOnTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem FailFinishKillTraitorOnTime => Instance[207];

		/// <summary>
		/// SelectGoodEnd
		/// </summary>
		public static SectMainStoryEventArgKeyItem SelectGoodEnd => Instance[208];

		/// <summary>
		/// LeikunAvatarData
		/// </summary>
		public static SectMainStoryEventArgKeyItem LeikunAvatarData => Instance[209];

		/// <summary>
		/// KilledByLeiKunTaiwuName
		/// </summary>
		public static SectMainStoryEventArgKeyItem KilledByLeiKunTaiwuName => Instance[210];

		/// <summary>
		/// ShixiangAdventureLiteratiCharId
		/// </summary>
		public static SectMainStoryEventArgKeyItem ShixiangAdventureLiteratiCharId => Instance[211];

		/// <summary>
		/// EmeiSelectGoodEndCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiSelectGoodEndCount => Instance[212];

		/// <summary>
		/// EmeiSelectBadEndCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiSelectBadEndCount => Instance[213];

		/// <summary>
		/// EmeiFourthSelectResult
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiFourthSelectResult => Instance[214];

		/// <summary>
		/// WhiteApeBlockId
		/// </summary>
		public static SectMainStoryEventArgKeyItem WhiteApeBlockId => Instance[215];

		/// <summary>
		/// WhiteApeBlockIdTmpSave
		/// </summary>
		public static SectMainStoryEventArgKeyItem WhiteApeBlockIdTmpSave => Instance[216];

		/// <summary>
		/// HomocideCase0Time
		/// </summary>
		public static SectMainStoryEventArgKeyItem HomocideCase0Time => Instance[217];

		/// <summary>
		/// HomocideCase1Time
		/// </summary>
		public static SectMainStoryEventArgKeyItem HomocideCase1Time => Instance[218];

		/// <summary>
		/// HomocideCase0Triggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem HomocideCase0Triggered => Instance[219];

		/// <summary>
		/// HomocideCase1Triggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem HomocideCase1Triggered => Instance[220];

		/// <summary>
		/// HomocideCase2Triggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem HomocideCase2Triggered => Instance[221];

		/// <summary>
		/// EmeiRoleJia
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleJia => Instance[222];

		/// <summary>
		/// EmeiRoleYi
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleYi => Instance[223];

		/// <summary>
		/// EmeiRoleBing
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleBing => Instance[224];

		/// <summary>
		/// EmeiRoleDing
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleDing => Instance[225];

		/// <summary>
		/// EmeiRoleWu
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleWu => Instance[226];

		/// <summary>
		/// EmeiRoleSi
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleSi => Instance[227];

		/// <summary>
		/// EmeiRoleGeng
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleGeng => Instance[228];

		/// <summary>
		/// EmeiRoleXin
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiRoleXin => Instance[229];

		/// <summary>
		/// TaiwuJumpCliffInjuryType
		/// </summary>
		public static SectMainStoryEventArgKeyItem TaiwuJumpCliffInjuryType => Instance[230];

		/// <summary>
		/// EmeiKillEachOtherStage
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiKillEachOtherStage => Instance[231];

		/// <summary>
		/// EmeiHomocideCasesInteractionCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiHomocideCasesInteractionCount => Instance[232];

		/// <summary>
		/// EmeiEmeiHomocideCasesInteractionIds
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiEmeiHomocideCasesInteractionIds => Instance[233];

		/// <summary>
		/// FirstClickWhiteGibbonDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem FirstClickWhiteGibbonDate => Instance[234];

		/// <summary>
		/// SecondClickWhiteGibbonDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem SecondClickWhiteGibbonDate => Instance[235];

		/// <summary>
		/// ThirdClickWhiteGibbonDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem ThirdClickWhiteGibbonDate => Instance[236];

		/// <summary>
		/// FourthClickWhiteGibbonDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem FourthClickWhiteGibbonDate => Instance[237];

		/// <summary>
		/// FifthClickWhiteGibbonDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem FifthClickWhiteGibbonDate => Instance[238];

		/// <summary>
		/// SixthClickWhiteGibbonDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem SixthClickWhiteGibbonDate => Instance[239];

		/// <summary>
		/// EmeiOptionReclusiveElderVisible
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiOptionReclusiveElderVisible => Instance[240];

		/// <summary>
		/// EmeiOptionWhoIsOrthodoxVisible
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiOptionWhoIsOrthodoxVisible => Instance[241];

		/// <summary>
		/// EmeiLeaderOriginalLocation
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiLeaderOriginalLocation => Instance[242];

		/// <summary>
		/// EmeiLeaderOriginalId
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiLeaderOriginalId => Instance[243];

		/// <summary>
		/// EmeiAdventureTwoAppearDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiAdventureTwoAppearDate => Instance[244];

		/// <summary>
		/// EmeiEnterAdventureTwo
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiEnterAdventureTwo => Instance[245];

		/// <summary>
		/// EmeiPassAdventureTwoTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiPassAdventureTwoTaiwuId => Instance[246];

		/// <summary>
		/// EmeiAdventureTwoPathEventTriggerCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiAdventureTwoPathEventTriggerCount => Instance[247];

		/// <summary>
		/// EmeiSelectGiveUpTrace
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiSelectGiveUpTrace => Instance[248];

		/// <summary>
		/// EmeiDefeatShiHoujiu
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiDefeatShiHoujiu => Instance[249];

		/// <summary>
		/// EmeiWhiteGibbonFollowOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiWhiteGibbonFollowOpen => Instance[250];

		/// <summary>
		/// EmeiShiHoujiuFollowOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiShiHoujiuFollowOpen => Instance[251];

		/// <summary>
		/// EmeiBreakBonusRefreshTimes
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiBreakBonusRefreshTimes => Instance[252];

		/// <summary>
		/// EmeiBreakBonusSaved
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiBreakBonusSaved => Instance[253];

		/// <summary>
		/// EmeiBreakBonusTemplateIds
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiBreakBonusTemplateIds => Instance[254];

		/// <summary>
		/// EmeiBreakBonusExtraPoints
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiBreakBonusExtraPoints => Instance[255];

		/// <summary>
		/// EmeiGiveInShiHoujiu
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiGiveInShiHoujiu => Instance[256];

		/// <summary>
		/// WuxianPrologueWugEventRecord
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianPrologueWugEventRecord => Instance[257];

		/// <summary>
		/// WuxianPrologueTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianPrologueTaiwuId => Instance[258];

		/// <summary>
		/// WuxianPrologueAddedWug
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianPrologueAddedWug => Instance[259];

		/// <summary>
		/// WuxianPrologueWugAttacked
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianPrologueWugAttacked => Instance[260];

		/// <summary>
		/// WuxianChapter1VisitCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1VisitCount => Instance[261];

		/// <summary>
		/// WuxianChapter1Wish1
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1Wish1 => Instance[262];

		/// <summary>
		/// WuxianChapter1Wish2
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1Wish2 => Instance[263];

		/// <summary>
		/// WuxianChapter1Wish3
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1Wish3 => Instance[264];

		/// <summary>
		/// WuxianChapter1WishCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1WishCount => Instance[265];

		/// <summary>
		/// WuxianChapter1WishComeTrueCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1WishComeTrueCount => Instance[266];

		/// <summary>
		/// WuxianChapter1Refused
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1Refused => Instance[267];

		/// <summary>
		/// WuxianChapter1RanXinduLocation
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter1RanXinduLocation => Instance[268];

		/// <summary>
		/// WuxianChapter2Adventure1Selection
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter2Adventure1Selection => Instance[269];

		/// <summary>
		/// WuxianChapter2Adventure2Selection
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter2Adventure2Selection => Instance[270];

		/// <summary>
		/// WuxianChapter3AbleToStart
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter3AbleToStart => Instance[271];

		/// <summary>
		/// WuxianChapter3MailReceivedCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter3MailReceivedCount => Instance[272];

		/// <summary>
		/// WuxianChapter4AdventureComplete
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter4AdventureComplete => Instance[273];

		/// <summary>
		/// WuxianChapter4FinalBossBeaten
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter4FinalBossBeaten => Instance[274];

		/// <summary>
		/// WuxianChapter4HappyEndingEventDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter4HappyEndingEventDate => Instance[275];

		/// <summary>
		/// WuxianChapter4EndingEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianChapter4EndingEventTriggered => Instance[276];

		/// <summary>
		/// WuxianPassLegacyEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem WuxianPassLegacyEventTriggered => Instance[277];

		/// <summary>
		/// JingangMonkMurderedTriggeredDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonkMurderedTriggeredDate => Instance[278];

		/// <summary>
		/// JingangAfterMonkMurderedTriggeredMoveCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangAfterMonkMurderedTriggeredMoveCount => Instance[279];

		/// <summary>
		/// JingangGiveVillagerFood
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerFood => Instance[280];

		/// <summary>
		/// JingangGiveVillagerFoodEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerFoodEventTriggered => Instance[281];

		/// <summary>
		/// JingangGiveVillagerFoodActorData
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerFoodActorData => Instance[282];

		/// <summary>
		/// JingangGiveVillagerMoney
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerMoney => Instance[283];

		/// <summary>
		/// JingangGiveVillagerMoneyEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerMoneyEventTriggered => Instance[284];

		/// <summary>
		/// JingangGiveVillagerMoneyActorData
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerMoneyActorData => Instance[285];

		/// <summary>
		/// JingangGiveVillagerPromise
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerPromise => Instance[286];

		/// <summary>
		/// JingangGiveVillagerPromiseEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerPromiseEventTriggered => Instance[287];

		/// <summary>
		/// JingangGiveVillagerHelp
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerHelp => Instance[288];

		/// <summary>
		/// JingangGiveVillagerHelpEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerHelpEventTriggered => Instance[289];

		/// <summary>
		/// JingangGiveVillagerHelpActorData
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveVillagerHelpActorData => Instance[290];

		/// <summary>
		/// JingangPersuadeVillagerCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangPersuadeVillagerCount => Instance[291];

		/// <summary>
		/// JingangTriggeredPeopleSufferingCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangTriggeredPeopleSufferingCount => Instance[292];

		/// <summary>
		/// JingangTriggeredInteractionVillagers
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangTriggeredInteractionVillagers => Instance[293];

		/// <summary>
		/// JingangTriggerMonthlyEventVillagerSuffer
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangTriggerMonthlyEventVillagerSuffer => Instance[294];

		/// <summary>
		/// JingangMonthlyEventVillagerEscapeTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonthlyEventVillagerEscapeTriggered => Instance[295];

		/// <summary>
		/// JingangAdventureNearestSettlementId
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangAdventureNearestSettlementId => Instance[296];

		/// <summary>
		/// JingangSecInfoSpreadingSelectCombat
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSecInfoSpreadingSelectCombat => Instance[297];

		/// <summary>
		/// JingangCreateCentralPlainsMonkTaiwuAreaId
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangCreateCentralPlainsMonkTaiwuAreaId => Instance[298];

		/// <summary>
		/// JingangKnowSecInfoIdList
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangKnowSecInfoIdList => Instance[299];

		/// <summary>
		/// JingangSpreadSecInfoTotalCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSpreadSecInfoTotalCount => Instance[300];

		/// <summary>
		/// JingangMonkSoulEnterDreamCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonkSoulEnterDreamCount => Instance[301];

		/// <summary>
		/// JingangSamsaraMonkSoulDreamTalkCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSamsaraMonkSoulDreamTalkCount => Instance[302];

		/// <summary>
		/// JingangSecInfoMetaDataId
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSecInfoMetaDataId => Instance[303];

		/// <summary>
		/// JingangSecInfoOccurenceId
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSecInfoOccurenceId => Instance[304];

		/// <summary>
		/// JingangTalkedCentralPlainsMonkId
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangTalkedCentralPlainsMonkId => Instance[305];

		/// <summary>
		/// JingangSamsaraMonkSoulTalked
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSamsaraMonkSoulTalked => Instance[306];

		/// <summary>
		/// JingangSamsaraMonkSoulTalkSelectBehavior
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSamsaraMonkSoulTalkSelectBehavior => Instance[307];

		/// <summary>
		/// JingangAttackDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangAttackDate => Instance[308];

		/// <summary>
		/// JingangFamousFakeMonkDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangFamousFakeMonkDate => Instance[309];

		/// <summary>
		/// JingangPrayDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangPrayDate => Instance[310];

		/// <summary>
		/// JingangLettersFromJingangDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangLettersFromJingangDate => Instance[311];

		/// <summary>
		/// JingangFameDistributionDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangFameDistributionDate => Instance[312];

		/// <summary>
		/// JingangPietyCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangPietyCount => Instance[313];

		/// <summary>
		/// JingangSelectHelpWestMonk
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSelectHelpWestMonk => Instance[314];

		/// <summary>
		/// JingangSecInfoSpreadingSelectBetray
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangSecInfoSpreadingSelectBetray => Instance[315];

		/// <summary>
		/// JingangHelpMonkEndSelectOption
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangHelpMonkEndSelectOption => Instance[316];

		/// <summary>
		/// JingangMonkSoulBtnDisappear
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonkSoulBtnDisappear => Instance[317];

		/// <summary>
		/// JingangDefeatShmashanaAdhipati
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangDefeatShmashanaAdhipati => Instance[318];

		/// <summary>
		/// JingangMonkReincarnationTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonkReincarnationTriggered => Instance[319];

		/// <summary>
		/// JingangMonkGhostVanishesTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonkGhostVanishesTriggered => Instance[320];

		/// <summary>
		/// JingangEndPartOneRefuseGiveSutra
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangEndPartOneRefuseGiveSutra => Instance[321];

		/// <summary>
		/// JingangWesternBuddhistMonkTalkOneTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkTalkOneTriggered => Instance[322];

		/// <summary>
		/// JingangWesternBuddhistMonkTalkTwoTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkTalkTwoTriggered => Instance[323];

		/// <summary>
		/// JingangWesternBuddhistMonkTalkThreeTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkTalkThreeTriggered => Instance[324];

		/// <summary>
		/// JingangWesternBuddhistMonkPassLegacyTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkPassLegacyTaiwuId => Instance[325];

		/// <summary>
		/// JingangImpersonatorBuddhistMonkPassLegacyTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangImpersonatorBuddhistMonkPassLegacyTaiwuId => Instance[326];

		/// <summary>
		/// JingangStillAtJingang
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangStillAtJingang => Instance[327];

		/// <summary>
		/// JingangFinishSecondSpreadSutra
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangFinishSecondSpreadSutra => Instance[328];

		/// <summary>
		/// JingangTriggeredChapter1Patch
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangTriggeredChapter1Patch => Instance[329];

		/// <summary>
		/// JingangMonkSoulResolveDreamCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonkSoulResolveDreamCount => Instance[330];

		/// <summary>
		/// JingangMonkSoulResolveDreamChatCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangMonkSoulResolveDreamChatCount => Instance[331];

		/// <summary>
		/// JingangGiveFakeBook
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangGiveFakeBook => Instance[332];

		/// <summary>
		/// JingangHelpSect
		/// </summary>
		public static SectMainStoryEventArgKeyItem JingangHelpSect => Instance[333];

		/// <summary>
		/// RanshanSpecialInteractionToggle
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanSpecialInteractionToggle => Instance[334];

		/// <summary>
		/// RanshanChapter1MonthlyEventTriggeredCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter1MonthlyEventTriggeredCount => Instance[335];

		/// <summary>
		/// RanshanChapter1MonthlyEventTriggeredDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter1MonthlyEventTriggeredDate => Instance[336];

		/// <summary>
		/// RanshanChapter2TeachStartDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2TeachStartDate => Instance[337];

		/// <summary>
		/// RanshanChapter2HuajuCombatPlayDecision
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2HuajuCombatPlayDecision => Instance[338];

		/// <summary>
		/// RanshanChapter2XuanzhiCombatPlayDecision
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2XuanzhiCombatPlayDecision => Instance[339];

		/// <summary>
		/// RanshanChapter2YingjiaoCombatPlayDecision
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoCombatPlayDecision => Instance[340];

		/// <summary>
		/// RanshanChapter2HuajuCombatPlayDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2HuajuCombatPlayDate => Instance[341];

		/// <summary>
		/// RanshanChapter2XuanzhiCombatPlayDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2XuanzhiCombatPlayDate => Instance[342];

		/// <summary>
		/// RanshanChapter2YingjiaoCombatPlayDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoCombatPlayDate => Instance[343];

		/// <summary>
		/// RanshanChapter2YingjiaoSelection1
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoSelection1 => Instance[344];

		/// <summary>
		/// RanshanChapter2YingjiaoSelection2
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoSelection2 => Instance[345];

		/// <summary>
		/// RanshanSanZongBiWuCountDown
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanSanZongBiWuCountDown => Instance[346];

		/// <summary>
		/// RanshanChapter3WillingToBeImmortal
		/// </summary>
		public static SectMainStoryEventArgKeyItem RanshanChapter3WillingToBeImmortal => Instance[347];

		/// <summary>
		/// BaihuaVillageSettlementIdSelection
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaVillageSettlementIdSelection => Instance[348];

		/// <summary>
		/// BaihuaEndenmicTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaEndenmicTriggered => Instance[349];

		/// <summary>
		/// BaihuaDreamAboutPastFirstTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaDreamAboutPastFirstTriggered => Instance[350];

		/// <summary>
		/// BaihuaLeukorpusArrivedEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukorpusArrivedEventTriggered => Instance[351];

		/// <summary>
		/// BaihuaMelanpsycheArrivedEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanpsycheArrivedEventTriggered => Instance[352];

		/// <summary>
		/// BaihuaSelectDenounceSuperstitious
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaSelectDenounceSuperstitious => Instance[353];

		/// <summary>
		/// BaihuaAdventureFourAppearDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaAdventureFourAppearDate => Instance[354];

		/// <summary>
		/// BaihuaAnonymTaiwuIsMale
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaAnonymTaiwuIsMale => Instance[355];

		/// <summary>
		/// BaihuaDreamAboutPastLastTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaDreamAboutPastLastTriggered => Instance[356];

		/// <summary>
		/// BaihuaDreamAboutPastLastDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaDreamAboutPastLastDate => Instance[357];

		/// <summary>
		/// BaihuaLeMeMeetTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeMeMeetTaiwuId => Instance[358];

		/// <summary>
		/// BaihuaLeukoKillsMonthEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsMonthEventTriggered => Instance[359];

		/// <summary>
		/// BaihuaLeukoKillsMonthEventSettlementId
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsMonthEventSettlementId => Instance[360];

		/// <summary>
		/// BaihuaLeukoKillsMonthEventSettlementIdLock
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsMonthEventSettlementIdLock => Instance[361];

		/// <summary>
		/// BaihuaLeukoKillsInteractOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsInteractOpen => Instance[362];

		/// <summary>
		/// BaihuaLeukoKillsCalledCharIds
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsCalledCharIds => Instance[363];

		/// <summary>
		/// BaihuaLeukoKillsFiveElementsType
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsFiveElementsType => Instance[364];

		/// <summary>
		/// BaihuaLeukoKillsOptionSelectDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsOptionSelectDate => Instance[365];

		/// <summary>
		/// BaihuaLeukoKillsCombatWin
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsCombatWin => Instance[366];

		/// <summary>
		/// BaihuaMelanoKillsMonthEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsMonthEventTriggered => Instance[367];

		/// <summary>
		/// BaihuaMelanoKillsMonthEventSettlementId
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsMonthEventSettlementId => Instance[368];

		/// <summary>
		/// BaihuaMelanoKillsMonthEventSettlementIdLock
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsMonthEventSettlementIdLock => Instance[369];

		/// <summary>
		/// BaihuaMelanoKillsInteractOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsInteractOpen => Instance[370];

		/// <summary>
		/// BaihuaMelanoKillsCalledCharIds
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsCalledCharIds => Instance[371];

		/// <summary>
		/// BaihuaMelanoKillsFiveElementsType
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsFiveElementsType => Instance[372];

		/// <summary>
		/// BaihuaMelanoKillsOptionSelectDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsOptionSelectDate => Instance[373];

		/// <summary>
		/// BaihuaMelanoKillsCombatWin
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsCombatWin => Instance[374];

		/// <summary>
		/// BaihuaSpecialDebuffIntList
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaSpecialDebuffIntList => Instance[375];

		/// <summary>
		/// BaihuaCureSpecialDebuffIntList
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaCureSpecialDebuffIntList => Instance[376];

		/// <summary>
		/// BaihuaAnimalsBackDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaAnimalsBackDate => Instance[377];

		/// <summary>
		/// BaihuaLeukoAssistedMelano
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoAssistedMelano => Instance[378];

		/// <summary>
		/// BaihuaMelanoAssistedLeuko
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoAssistedLeuko => Instance[379];

		/// <summary>
		/// BaihuaManicLowDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaManicLowDate => Instance[380];

		/// <summary>
		/// BaihuaManicHighDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaManicHighDate => Instance[381];

		/// <summary>
		/// BaihuaTriggerFinaleTaskDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaTriggerFinaleTaskDate => Instance[382];

		/// <summary>
		/// BaihuaBaiLuFirstInteractTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaBaiLuFirstInteractTriggered => Instance[383];

		/// <summary>
		/// BaihuaXuanXiaoFirstInteractTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaXuanXiaoFirstInteractTriggered => Instance[384];

		/// <summary>
		/// BaihuaAdventureFinialWinSect
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaAdventureFinialWinSect => Instance[385];

		/// <summary>
		/// BaihuaLeukoDialogNotTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoDialogNotTriggered => Instance[386];

		/// <summary>
		/// BaihuaMelanoDialogNotTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoDialogNotTriggered => Instance[387];

		/// <summary>
		/// BaihuaLeukoPlayCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLeukoPlayCount => Instance[388];

		/// <summary>
		/// BaihuaMelanoPlayCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaMelanoPlayCount => Instance[389];

		/// <summary>
		/// BaihuaLMPlayCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLMPlayCount => Instance[390];

		/// <summary>
		/// BaihuaLMNewsTalkedCharIds
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLMNewsTalkedCharIds => Instance[391];

		/// <summary>
		/// BaihuaLMTransferAnimalDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaLMTransferAnimalDate => Instance[392];

		/// <summary>
		/// BaihuaFixedLMFavor
		/// </summary>
		public static SectMainStoryEventArgKeyItem BaihuaFixedLMFavor => Instance[393];

		/// <summary>
		/// FulongDisasterStart
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongDisasterStart => Instance[394];

		/// <summary>
		/// FulongDisasterMonthlyEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongDisasterMonthlyEventTriggered => Instance[395];

		/// <summary>
		/// FulongDisasterStartProb
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongDisasterStartProb => Instance[396];

		/// <summary>
		/// FulongFireFightingGuideTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongFireFightingGuideTriggered => Instance[397];

		/// <summary>
		/// FulongAdventureOneCountDown
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongAdventureOneCountDown => Instance[398];

		/// <summary>
		/// FulongAdventureThreeCountDown
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongAdventureThreeCountDown => Instance[399];

		/// <summary>
		/// FulongAdventureStartTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongAdventureStartTime => Instance[400];

		/// <summary>
		/// FulongAdventureTwoTaiwuId
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongAdventureTwoTaiwuId => Instance[401];

		/// <summary>
		/// FulongShadowEventTriggeredCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongShadowEventTriggeredCount => Instance[402];

		/// <summary>
		/// FulongShadowEventOneTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongShadowEventOneTriggered => Instance[403];

		/// <summary>
		/// FulongShadowEventTwoTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongShadowEventTwoTriggered => Instance[404];

		/// <summary>
		/// FulongReudhLazuliChatMysteryOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongReudhLazuliChatMysteryOpen => Instance[405];

		/// <summary>
		/// FulongReudhLazuliChatMysteryCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongReudhLazuliChatMysteryCount => Instance[406];

		/// <summary>
		/// FulongReudhLazuliAI2
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongReudhLazuliAI2 => Instance[407];

		/// <summary>
		/// FulongTravelWithLazuliWorldViewTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliWorldViewTriggered => Instance[408];

		/// <summary>
		/// FulongSpecialInteractOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongSpecialInteractOpen => Instance[409];

		/// <summary>
		/// FulongTravelWithLazuliCityTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliCityTriggered => Instance[410];

		/// <summary>
		/// FulongTravelWithLazuliTaiwuVillageTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliTaiwuVillageTriggered => Instance[411];

		/// <summary>
		/// FulongTravelWithLazuliSectTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliSectTriggered => Instance[412];

		/// <summary>
		/// FulongTravelWithLazuliTownTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliTownTriggered => Instance[413];

		/// <summary>
		/// FulongTravelWithLazuliStockadeTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliStockadeTriggered => Instance[414];

		/// <summary>
		/// FulongTravelWithLazuliVillageTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliVillageTriggered => Instance[415];

		/// <summary>
		/// FulongTravelWithLazuliXiangshuMinionTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliXiangshuMinionTriggered => Instance[416];

		/// <summary>
		/// FulongTravelWithLazuliAnimalTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliAnimalTriggered => Instance[417];

		/// <summary>
		/// FulongTravelWithLazuliRandomEnemyTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliRandomEnemyTriggered => Instance[418];

		/// <summary>
		/// FulongTravelWithLazuliMonvTalkTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliMonvTalkTriggered => Instance[419];

		/// <summary>
		/// FulongTravelWithLazuliMoveCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliMoveCount => Instance[420];

		/// <summary>
		/// FulongChickenKingLetterMoveCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongChickenKingLetterMoveCount => Instance[421];

		/// <summary>
		/// FulongTravelWithLazuliMoveAreaId
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliMoveAreaId => Instance[422];

		/// <summary>
		/// FulongTravelWithLazuliChicken1
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliChicken1 => Instance[423];

		/// <summary>
		/// FulongTravelWithLazuliChicken2
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliChicken2 => Instance[424];

		/// <summary>
		/// FulongTravelWithLazuliFinished
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliFinished => Instance[425];

		/// <summary>
		/// FulongLazuliIsFriend
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongLazuliIsFriend => Instance[426];

		/// <summary>
		/// FulongSelectFalling
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongSelectFalling => Instance[427];

		/// <summary>
		/// FulongSelectFallingDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongSelectFallingDate => Instance[428];

		/// <summary>
		/// FulongReudhLazuliFeatherFollowOpen
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongReudhLazuliFeatherFollowOpen => Instance[429];

		/// <summary>
		/// FulongMessengerAppearTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongMessengerAppearTime => Instance[430];

		/// <summary>
		/// FulongLoseChickenFeatherInteractionSettlements
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongLoseChickenFeatherInteractionSettlements => Instance[431];

		/// <summary>
		/// FulongLazuliLetterTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongLazuliLetterTriggered => Instance[432];

		/// <summary>
		/// FulongLazuliLetterEventA
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongLazuliLetterEventA => Instance[433];

		/// <summary>
		/// FulongLazuliLetterEventB
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongLazuliLetterEventB => Instance[434];

		/// <summary>
		/// FulongLazuliLetterEventC
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongLazuliLetterEventC => Instance[435];

		/// <summary>
		/// FulongPutOutFireCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongPutOutFireCount => Instance[436];

		/// <summary>
		/// FulongFireStartTime
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongFireStartTime => Instance[437];

		/// <summary>
		/// FulongPutOutFire
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongPutOutFire => Instance[438];

		/// <summary>
		/// FulongPutOutFireOnce
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongPutOutFireOnce => Instance[439];

		/// <summary>
		/// FulongChickenFeatherLackCount
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongChickenFeatherLackCount => Instance[440];

		/// <summary>
		/// FulongLazuliFindFlowerDialogLevel
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongLazuliFindFlowerDialogLevel => Instance[441];

		/// <summary>
		/// FulongStayWithLazuliTaskTriggerDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongStayWithLazuliTaskTriggerDate => Instance[442];

		/// <summary>
		/// FulongMessengerIdList
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongMessengerIdList => Instance[443];

		/// <summary>
		/// FulongChickenKingLeaveHome
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongChickenKingLeaveHome => Instance[444];

		/// <summary>
		/// FulongChickenFeatherDropList
		/// </summary>
		public static SectMainStoryEventArgKeyItem FulongChickenFeatherDropList => Instance[445];

		/// <summary>
		/// ZhujianCatchThiefTimes
		/// </summary>
		public static SectMainStoryEventArgKeyItem ZhujianCatchThiefTimes => Instance[446];

		/// <summary>
		/// EmeiStrangerTriggerDate
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiStrangerTriggerDate => Instance[447];

		/// <summary>
		/// EmeiInteractionOneTriggeredList
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiInteractionOneTriggeredList => Instance[448];

		/// <summary>
		/// EmeiInteractionTwoTriggeredList
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiInteractionTwoTriggeredList => Instance[449];

		/// <summary>
		/// EmeiFirstMonthlyEventTriggered
		/// </summary>
		public static SectMainStoryEventArgKeyItem EmeiFirstMonthlyEventTriggered => Instance[450];

		/// <summary>
		/// XuehouKillJixi
		/// </summary>
		public static SectMainStoryEventArgKeyItem XuehouKillJixi => Instance[451];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SectMainStoryEventArgKey Instance = new SectMainStoryEventArgKey();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Sect", "TemplateId", "ArgBoxKey" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(0, 10, "ConchShip_PresetKey_IsKillLiaoWuming"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(1, 10, "ConchShip_PresetKey_IsKilledByLiaoWuming"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(2, 10, "ConchShip_PresetKey_LiaoWumingQuestStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(3, 10, "ConchShip_PresetKey_LiaoWumingGetPoison"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(4, 10, "ConchShip_PresetKey_TheNameGivePoisonToLiaoWuming"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(5, 10, "ConchShip_PresetKey_KongsangAdventureCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(6, 10, "ConchShip_PresetKey_GetKongsangInformation1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(7, 10, "ConchShip_PresetKey_GetKongsangInformation2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(8, 10, "ConchShip_PresetKey_InteractWithLiaoWumingAi2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(9, 10, "ConchShip_PresetKey_KongsangAcceptTaskTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(10, 10, "ConchShip_PresetKey_KongsangFirstPassingLegacyTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(11, 10, "ConchShip_PresetKey_KongsangFirstPassingLegacyDialogTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(12, 10, "ConchShip_PresetKey_KongsangSecondPassingLegacyDialogCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(13, 10, "ConchShip_PresetKey_KongsangStoryParyOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(14, 10, "ConchShip_PresetKey_KongsangPart3TaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(15, 10, "ConchShip_PresetKey_FirstTryPoisonIsFailure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(16, 10, "ConchShip_PresetKey_SecondTryPoisonIsFailure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(17, 10, "ConchShip_PresetKey_ThirdTryPoisonIsFailure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(18, 10, "ConchShip_PresetKey_TripodVesselOfMedicineAreaId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(19, 10, "ConchShip_PresetKey_ActingHeadActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(20, 10, "ConchShip_PresetKey_KongsangSectLeaderId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(21, 10, "ConchShip_PresetKey_BeforePoisonTest0EventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(22, 10, "ConchShip_PresetKey_BeforePoisonTest0EventFirstTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(23, 10, "ConchShip_PresetKey_BeforePoisonTest1EventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(24, 10, "ConchShip_PresetKey_MissionUnacceptedEventTriggeredSameMonth"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(25, 10, "ConchShip_PresetKey_KongsangTargetFoundEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(26, 15, "ConchShip_PresetKey_XuehouStoryPartOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(27, 15, "ConchShip_PresetKey_StillAtYangzhou"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(28, 15, "ConchShip_PresetKey_FirstGotBellTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(29, 15, "ConchShip_PresetKey_MeetSkeletonWithBellExtraProb"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(30, 15, "ConchShip_PresetKey_XuehouGraveDiggingEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(31, 15, "ConchShip_PresetKey_DefeatXuehouOldManTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(32, 15, "ConchShip_PresetKey_GiveBellToXuehouOldManTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(33, 15, "ConchShip_PresetKey_XuehouOldManGraveDisappearTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(34, 15, "ConchShip_PresetKey_XuehouOldManCharacterId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(35, 15, "ConchShip_PresetKey_OldManZombieInteractTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(36, 15, "ConchShip_PresetKey_AwakeJixiTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(37, 15, "ConchShip_PresetKey_AwakeJixiTaiwuGender"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(38, 15, "ConchShip_PresetKey_AwakeJixiAndPassLegacy"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(39, 15, "ConchShip_PresetKey_PassXuehouAdventure1Time"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(40, 15, "ConchShip_PresetKey_XuehouEmptyCaveTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(41, 15, "ConchShip_PresetKey_XuehouFindPeopleTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(42, 15, "ConchShip_PresetKey_XuehouComingTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(43, 15, "ConchShip_PresetKey_XuehouComingTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(44, 15, "ConchShip_PresetKey_JixiArrivedTaiwuDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(45, 15, "ConchShip_PresetKey_JixiArrivedTaiwuMonthlyEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(46, 15, "ConchShip_PresetKey_JixiAdventureOnePassDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(47, 15, "ConchShip_PresetKey_JixiAdventureTwoPassDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(48, 15, "ConchShip_PresetKey_JixiAdventureThreePassDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(49, 15, "ConchShip_PresetKey_JixiAdventureOneStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(50, 15, "ConchShip_PresetKey_JixiAdventureTwoStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(51, 15, "ConchShip_PresetKey_JixiAdventureThreeStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(52, 15, "ConchShip_PresetKey_JixiAdventureFourStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(53, 15, "ConchShip_PresetKey_ProtectedJixiTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(54, 15, "ConchShip_PresetKey_JixiFeedChickenEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(55, 15, "ConchShip_PresetKey_JixiHarmvillagerEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(56, 15, "ConchShip_PresetKey_HaveJixiTruthClueCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(57, 15, "ConchShip_PresetKey_HaveJixiFalseClueCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(58, 15, "ConchShip_PresetKey_SectStory_Xuehou_Jixi_WaitingMonth"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(59, 15, "ConchShip_PresetKey_SectStory_Xuehou_Jixi_StayAtGraveMonthKey"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(60, 15, "ConchShip_PresetKey_SectStory_Xuehou_Jixi_KilledCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(61, 15, "ConchShip_PresetKey_CombatWithUltimateZombieTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(62, 15, "ConchShip_PresetKey_JixiLegacyPassFirstTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(63, 15, "ConchShip_PresetKey_JixiSoulTransformFirstTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(64, 15, "ConchShip_PresetKey_PassLegacyMonthlyNotificationTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(65, 15, "ConchShip_PresetKey_NeedTriggerPassLegacyMonthlyNotification"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(66, 15, "ConchShip_PresetKey_XuehouOldManHasBell"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(67, 15, "ConchShip_PresetKey_JixiHasAntiqueJadeBat"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(68, 15, "ConchShip_PresetKey_JixiHasAntiqueJadeFox"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(69, 15, "ConchShip_PresetKey_JixiHasAntiqueJadeButterfly"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(70, 15, "ConchShip_PresetKey_JixiFavorite1TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(71, 15, "ConchShip_PresetKey_JixiFavorite2TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(72, 15, "ConchShip_PresetKey_JixiFavorite3TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(73, 15, "ConchShip_PresetKey_JixiFavorite4TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(74, 15, "ConchShip_PresetKey_JixiFavorite5TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(75, 15, "ConchShip_PresetKey_JixiFavorite6TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(76, 15, "ConchShip_PresetKey_JixiPassLegacyTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(77, 15, "ConchShip_PresetKey_JixiKillEnemyTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(78, 15, "ConchShip_PresetKey_JixiKilledEnemy"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(79, 15, "ConchShip_PresetKey_JixiFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(80, 15, "ConchShip_PresetKey_XuehouSelectFreeJixi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(81, 15, "ConchShip_PresetKey_XuehouGraveDiggingNormalTriggerTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(82, 15, "ConchShip_PresetKey_JixiAnimalTalkOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(83, 8, "ConchShip_PresetKey_XuannvStoryTriggerFirstTrack"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(84, 8, "ConchShip_PresetKey_XuannvStoryPartOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(85, 8, "ConchShip_PresetKey_XuannStory_TaiwuCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(86, 8, "ConchShip_PresetKey_XuannStoryPartOneReceivingLetter"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(87, 8, "ConchShip_PresetKey_XuannStoryPartOneLetter_CountA"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(88, 8, "ConchShip_PresetKey_XuannStoryPartOneLetter_CountB"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(89, 8, "ConchShip_PresetKey_XuannStoryPartOneLetter_CountC"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(90, 8, "ConchShip_PresetKey_XuannStoryPartOne_OptionMarkKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(91, 8, "ConchShip_PresetKey_XuannStoryPartOne_LegendaryDoctor"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(92, 8, "ConchShip_PresetKey_XuannStoryPartOne_WaitSecretGuestEvent"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(93, 8, "ConchShip_PresetKey_XuannStoryPartOne_SecretGuest_ActorKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(94, 8, "ConchShip_PresetKey_XuannStoryPartOne_GuessGenderKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(95, 8, "ConchShip_PresetKey_XuannvStoryPartOne_OptionInject"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(96, 8, "ConchShip_PresetKey_Xuannv_NoneSectNpcInquireSecretGuest1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(97, 8, "ConchShip_PresetKey_Xuannv_NoneSectNpcInquireSecretGuest2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(98, 8, "ConchShip_PresetKey_Xuannv_NoneSectNpcInquireSecretGuest3"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(99, 8, "ConchShip_PresetKey_XuannvPartTwo_OptionInject"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(100, 8, "ConchShip_PresetKey_XuannvPartTwo_SelectedCombatSkillType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(101, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkill"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(102, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_0"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(103, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(104, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(105, 8, "ConchShip_PresetKey_Xuannv_PartTwoRefuseToHelpCountKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(106, 8, "ConchShip_PresetKey_Xuannv_PartThreeSearchLoverCountKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(107, 8, "ConchShip_PresetKey_Xuannv_PartThree_TakeLoverDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(108, 8, "ConchShip_PresetKey_Xuannv_PartThree_LoverReincarnateLocation1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(109, 8, "ConchShip_PresetKey_Xuannv_PartThree_LoverReincarnateLocation2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(110, 8, "ConchShip_PresetKey_Xuannv_PartThree_LoverReincarnateLocation3"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(111, 8, "ConchShip_PresetKey_Xuannv_LoverReincarnateLocation"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(112, 8, "ConchShip_PresetKey_Xuannv_WaitLoverNameKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(113, 8, "ConchShip_PresetKey_Xuannv_MonthlyEventTrigger_WithSister"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(114, 8, "ConchShip_PresetKey_Xuannv_PartThree_HasTalkToShiWeizhi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(115, 8, "ConchShip_PresetKey_Xuannv_PartThree_ActorSisterOfShiWeizhi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(116, 8, "ConchShip_PresetKey_Xuannv_PartThree_GirlGodIllusion"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(117, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(118, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(119, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_3"));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(120, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_41"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(121, 8, "ConchShip_PresetKey_XuannvStory_HeYouyuan_CharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(122, 8, "ConchShip_PresetKey_XuannvStory_SecretReincarnationNPC_CharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(123, 8, "ConchShip_PresetKey_XuannvStory_IsJunerAtXuannvSect"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(124, 8, "ConchShip_PresetKey_XuannvStory_MusicUnlock10_FirstFlag"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(125, 8, "ConchShip_PresetKey_XuannvStory_MusicUnlock40_FirstFlag"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(126, 8, "ConchShip_PresetKey_XuannvStory_MusicUnlock45_WeaponFlag"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(127, 8, "ConchShip_PresetKey_XuannvStory_PartThree_LastDateOfAdventureIllusionOfMirror"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(128, 1, "ConchShip_PresetKey_ShaolinMythinLowMemberTalked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(129, 1, "ConchShip_PresetKey_ShaolinMythinMiddleMemberTalked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(130, 1, "ConchShip_PresetKey_ShaolinStatueReturnTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(131, 1, "ConchShip_PresetKey_ShaolinMonthlyEventNotEnoughDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(132, 1, "ConchShip_PresetKey_DamoDreamMeetTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(133, 1, "ConchShip_PresetKey_ShaolinCombatSkillType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(134, 1, "ConchShip_PresetKey_ShaolinLearnedAny"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(135, 1, "ConchShip_PresetKey_ShaolinDamoFightTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(136, 1, "ConchShip_PresetKey_ShaolinDamoFightWinDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(137, 1, "ConchShip_PresetKey_StudyForBodhidharmaChallenge"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(138, 1, "ConchShip_PresetKey_ShaolinDamoTrialTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(139, 1, "ConchShip_PresetKey_ShaolinDamoFightTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(140, 1, "ConchShip_PresetKey_ShaolinDamoVisitTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(141, 1, "ConchShip_PresetKey_ShaolinReadingMaxGradeSutra"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(142, 1, "ConchShip_PresetKey_ShaolinSutraPavilionGuardDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(143, 1, "ConchShip_PresetKey_ShaolinDamoLearnedFightTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(144, 1, "ConchShip_PresetKey_ShaolinComprehendedTheZen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(145, 1, "ConchShip_PresetKey_ShaolinMeditationInteractionFinished"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(146, 1, "ConchShip_PresetKey_ShaolinInteractionChangeTip1Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(147, 1, "ConchShip_PresetKey_ShaolinInteractionChangeTip2Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(148, 4, "ConchShip_PresetKey_WudangSkillReverseBreakCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(149, 4, "ConchShip_PresetKey_CombatWithTaoistMonkDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(150, 4, "ConchShip_PresetKey_CombatWithTaoistMonkTaiwuName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(151, 4, "ConchShip_PresetKey_AtLastCombatWithTaoistMonkTaiwuName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(152, 4, "ConchShip_PresetKey_BlackSnakeCustomName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(153, 4, "ConchShip_PresetKey_GiveTaoistTreasureCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(154, 4, "ConchShip_PresetKey_GiveTaoistTreasureItemKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(155, 4, "ConchShip_PresetKey_WudangChatEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(156, 4, "ConchShip_PresetKey_WudangSankeFighted"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(157, 4, "ConchShip_PresetKey_WudangFrontEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(158, 4, "ConchShip_PresetKey_LastEventSloppyTaoistMonkFavor"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(159, 4, "ConchShip_PresetKey_GetExtraSeedCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(160, 4, "ConchShip_PresetKey_FinishFairylandStoryCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(161, 4, "ConchShip_PresetKey_TriggeredFailureEvent"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(162, 4, "ConchShip_PresetKey_WudangKillRandomEnemyTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(163, 4, "ConchShip_PresetKey_GivenMonkSnakeItemKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(164, 4, "ConchShip_PresetKey_GivenMonkSnakeList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(165, 4, "ConchShip_PresetKey_WudangEasterEggTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(166, 4, "ConchShip_PresetKey_WudangHeavenlyTreeSeedTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(167, 4, "ConchShip_PresetKey_WudangFairylandTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(168, 4, "ConchShip_PresetKey_WudangTortoiseSnakeTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(169, 4, "ConchShip_PresetKey_WudangEmperorTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(170, 4, "ConchShip_PresetKey_MeetImmortalEventCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(171, 4, "ConchShip_PresetKey_CollectHeavenlyTreeSeedFirstTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(172, 5, "ConchShip_PresetKey_YuanshanDemonOutOfJail"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(173, 5, "ConchShip_PresetKey_TaiwuReleasedYuanshanDemon"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(174, 5, "ConchShip_PresetKey_YuanshanLeaderFirmDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(175, 5, "ConchShip_PresetKey_YuanshanDemonDormantDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(176, 5, "ConchShip_PresetKey_MythInYuanshanTriggeredDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(177, 5, "ConchShip_PresetKey_YuanshanInteractionTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(178, 5, "ConchShip_PresetKey_YuanshanThoughtsTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(179, 5, "ConchShip_PresetKey_YuanshanThoughtsInteractable"));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(180, 5, "ConchShip_PresetKey_YuanshanLobbyTalkInteractable"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(181, 5, "ConchShip_PresetKey_YuanshanDemonPower"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(182, 5, "ConchShip_PresetKey_KilledYuanshanDemonCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(183, 5, "ConchShip_PresetKey_YuanshanCaelumDemonDefeatedTaiwu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(184, 5, "ConchShip_PresetKey_YuanshanTerraDemonDefeatedTaiwu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(185, 5, "ConchShip_PresetKey_YuanshanAnthropDemonDefeatedTaiwu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(186, 5, "ConchShip_PresetKey_YuanshanDemonMeetTaiwuCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(187, 5, "ConchShip_PresetKey_YuanshanDemonLast"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(188, 5, "ConchShip_PresetKey_YuanshanToFightDemon"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(189, 5, "YuanshanMiniGameStage"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(190, 5, "Adventure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(191, 6, "ConchShip_PresetKey_ShixiangAdventureAppearDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(192, 6, "ConchShip_PresetKey_ShixiangFirstLetterDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(193, 6, "ConchShip_PresetKey_ShixiangLetterCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(194, 6, "ConchShip_PresetKey_ShixiangToFightEnemy"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(195, 6, "ConchShip_PresetKey_MockShixiangEventTriggeredSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(196, 6, "ConchShip_PresetKey_MockShixiangEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(197, 6, "ConchShip_PresetKey_MockShixiangEventCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(198, 6, "ConchShip_PresetKey_ShixiangStoryPartOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(199, 6, "ConchShip_PresetKey_ShixiangAdventureWon"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(200, 6, "ConchShip_PresetKey_TaiwuKillBarbarianMasterCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(201, 6, "ConchShip_PresetKey_ShixiangKillBarbarianMasterCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(202, 6, "ConchShip_PresetKey_TaiwuKillBarbarianMasterCount2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(203, 6, "ConchShip_PresetKey_ShixiangKillBarbarianMasterCount2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(204, 6, "ConchShip_PresetKey_ArriveLotusMountainEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(205, 6, "ConchShip_PresetKey_ArriveShixiangEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(206, 6, "ConchShip_PresetKey_StartFightShixiangTraitorsDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(207, 6, "ConchShip_PresetKey_FailFinishKillTraitorOnTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(208, 6, "ConchShip_PresetKey_SelectGoodEnd"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(209, 6, "ConchShip_PresetKey_LeikunAvatarData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(210, 6, "ConchShip_PresetKey_KilledByLeiKunTaiwuName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(211, 6, "ConchShip_PresetKey_ShixiangAdventureLiteratiCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(212, 2, "ConchShip_PresetKey_EmeiSelectGoodEndCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(213, 2, "ConchShip_PresetKey_EmeiSelectBadEndCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(214, 2, "ConchShip_PresetKey_EmeiFourthSelectResult"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(215, 2, "ConchShip_PresetKey_WhiteApeBlockId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(216, 2, "ConchShip_PresetKey_WhiteApeBlockIdTmpSave"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(217, 2, "ConchShip_PresetKey_HomocideCase0Time"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(218, 2, "ConchShip_PresetKey_HomocideCase1Time"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(219, 2, "ConchShip_PresetKey_HomocideCase0Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(220, 2, "ConchShip_PresetKey_HomocideCase1Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(221, 2, "ConchShip_PresetKey_HomocideCase2Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(222, 2, "ConchShip_PresetKey_EmeiRoleJia"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(223, 2, "ConchShip_PresetKey_EmeiRoleYi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(224, 2, "ConchShip_PresetKey_EmeiRoleBing"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(225, 2, "ConchShip_PresetKey_EmeiRoleDing"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(226, 2, "ConchShip_PresetKey_EmeiRoleWu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(227, 2, "ConchShip_PresetKey_EmeiRoleSi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(228, 2, "ConchShip_PresetKey_EmeiRoleGeng"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(229, 2, "ConchShip_PresetKey_EmeiRoleXin"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(230, 2, "ConchShip_PresetKey_TaiwuJumpCliffInjuryType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(231, 2, "ConchShip_PresetKey_EmeiKillEachOtherStage"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(232, 2, "ConchShip_PresetKey_EmeiHomocideCasesInteractionCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(233, 2, "ConchShip_PresetKey_EmeiEmeiHomocideCasesInteractionIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(234, 2, "ConchShip_PresetKey_FirstClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(235, 2, "ConchShip_PresetKey_SecondClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(236, 2, "ConchShip_PresetKey_ThirdClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(237, 2, "ConchShip_PresetKey_FourthClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(238, 2, "ConchShip_PresetKey_FifthClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(239, 2, "ConchShip_PresetKey_SixthClickWhiteGibbonDate"));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(240, 2, "ConchShip_PresetKey_EmeiOptionReclusiveElderVisible"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(241, 2, "ConchShip_PresetKey_EmeiOptionWhoIsOrthodoxVisible"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(242, 2, "ConchShip_PresetKey_EmeiLeaderOriginalLocation"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(243, 2, "ConchShip_PresetKey_EmeiLeaderOriginalId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(244, 2, "ConchShip_PresetKey_EmeiAdventureTwoAppearDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(245, 2, "ConchShip_PresetKey_EmeiEnterAdventureTwo"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(246, 2, "ConchShip_PresetKey_EmeiPassAdventureTwoTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(247, 2, "ConchShip_PresetKey_EmeiAdventureTwoPathEventTriggerCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(248, 2, "ConchShip_PresetKey_EmeiSelectGiveUpTrace"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(249, 2, "ConchShip_PresetKey_EmeiDefeatShiHoujiu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(250, 2, "ConchShip_PresetKey_EmeiWhiteGibbonFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(251, 2, "ConchShip_PresetKey_EmeiShiHoujiuFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(252, 2, "ConchShip_PresetKey_EmeiBreakBonusRefreshTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(253, 2, "ConchShip_PresetKey_EmeiBreakBonusSaved"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(254, 2, "ConchShip_PresetKey_EmeiBreakBonusTemplateIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(255, 2, "ConchShip_PresetKey_EmeiBreakBonusExtraPoints"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(256, 2, "ConchShip_PresetKey_EmeiGiveInShiHoujiu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(257, 12, "ConchShip_PresetKey_Wuxian_Prologue_WugEventRecord"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(258, 12, "ConchShip_PresetKey_Wuxian_Prologue_TaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(259, 12, "ConchShip_PresetKey_Wuxian_Prologue_AddedWug"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(260, 12, "ConchShip_PresetKey_Wuxian_Prologue_WugAttacked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(261, 12, "ConchShip_PresetKey_Wuxian_Chapter1_VisitCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(262, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Wish1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(263, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Wish2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(264, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Wish3"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(265, 12, "ConchShip_PresetKey_Wuxian_Chapter1_WuxianChapter1WishCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(266, 12, "ConchShip_PresetKey_Wuxian_Chapter1_WishComeTrueCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(267, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Refused"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(268, 12, "ConchShip_PresetKey_Wuxian_Chapter1_RanXinduLocation"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(269, 12, "ConchShip_PresetKey_Wuxian_Chapter2_Adventure1Selection"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(270, 12, "ConchShip_PresetKey_Wuxian_Chapter2_Adventure2Selection"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(271, 12, "ConchShip_PresetKey_Wuxian_Chapter3_AbleToStart"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(272, 12, "ConchShip_PresetKey_Wuxian_Chapter3_MailReceivedCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(273, 12, "ConchShip_PresetKey_Wuxian_Chapter4_AdventureComplete"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(274, 12, "ConchShip_PresetKey_Wuxian_Chapter4_FinalBossBeaten"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(275, 12, "ConchShip_PresetKey_Wuxian_Chapter4_HappyEndingEventDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(276, 12, "ConchShip_PresetKey_Wuxian_Chapter4_EndingEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(277, 12, "ConchShip_PresetKey_Wuxian_PassLegacyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(278, 11, "ConchShip_PresetKey_JingangMonkMurderedTriggeredDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(279, 11, "ConchShip_PresetKey_JingangAfterMonkMurderedTriggeredMoveCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(280, 11, "ConchShip_PresetKey_JingangGiveVillagerFood"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(281, 11, "ConchShip_PresetKey_JingangGiveVillagerFoodEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(282, 11, "ConchShip_PresetKey_JingangGiveVillagerFoodActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(283, 11, "ConchShip_PresetKey_JingangGiveVillagerMoney"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(284, 11, "ConchShip_PresetKey_JingangGiveVillagerMoneyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(285, 11, "ConchShip_PresetKey_JingangGiveVillagerMoneyActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(286, 11, "ConchShip_PresetKey_JingangGiveVillagerPromise"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(287, 11, "ConchShip_PresetKey_JingangGiveVillagerPromiseEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(288, 11, "ConchShip_PresetKey_JingangGiveVillagerHelp"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(289, 11, "ConchShip_PresetKey_JingangGiveVillagerHelpEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(290, 11, "ConchShip_PresetKey_JingangGiveVillagerHelpActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(291, 11, "ConchShip_PresetKey_JingangPersuadeVillagerCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(292, 11, "ConchShip_PresetKey_JingangTriggeredPeopleSufferingCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(293, 11, "ConchShip_PresetKey_JingangTriggeredInteractionVillagers"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(294, 11, "ConchShip_PresetKey_JingangTriggerMonthlyEventVillagerSuffer"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(295, 11, "ConchShip_PresetKey_JingangMonthlyEventVillagerEscapeTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(296, 11, "ConchShip_PresetKey_JingangAdventureNearestSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(297, 11, "ConchShip_PresetKey_JingangSecInfoSpreadingSelectCombat"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(298, 11, "ConchShip_PresetKey_JingangCreateCentralPlainsMonkTaiwuAreaId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(299, 11, "ConchShip_PresetKey_JingangKnowSecInfoIdList"));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(300, 11, "ConchShip_PresetKey_JingangSpreadSecInfoTotalCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(301, 11, "ConchShip_PresetKey_JingangMonkSoulEnterDreamCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(302, 11, "ConchShip_PresetKey_JingangSamsaraMonkSoulDreamTalkCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(303, 11, "ConchShip_PresetKey_JingangSecInfoMetaDataId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(304, 11, "ConchShip_PresetKey_JingangSecInfoOccurenceId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(305, 11, "ConchShip_PresetKey_JingangTalkedCentralPlainsMonkId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(306, 11, "ConchShip_PresetKey_JingangSamsaraMonkSoulTalked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(307, 11, "ConchShip_PresetKey_JingangSamsaraMonkSoulTalkSelectBehavior"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(308, 11, "ConchShip_PresetKey_JingangAttackDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(309, 11, "ConchShip_PresetKey_JingangFamousFakeMonkDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(310, 11, "ConchShip_PresetKey_JingangPrayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(311, 11, "ConchShip_PresetKey_JingangLettersFromJingangDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(312, 11, "ConchShip_PresetKey_JingangFameDistributionDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(313, 11, "ConchShip_PresetKey_JingangPietyCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(314, 11, "ConchShip_PresetKey_JingangSelectHelpWestMonk"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(315, 11, "ConchShip_PresetKey_JingangSecInfoSpreadingSelectBetray"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(316, 11, "ConchShip_PresetKey_JingangHelpMonkEndSelectOption"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(317, 11, "ConchShip_PresetKey_JingangMonkSoulBtnDisappear"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(318, 11, "ConchShip_PresetKey_JingangDefeatShmashanaAdhipati"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(319, 11, "ConchShip_PresetKey_JingangSoulTransformOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(320, 11, "ConchShip_PresetKey_JingangMonkGhostVanishesTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(321, 11, "ConchShip_PresetKey_JingangEndPartOneRefuseGiveSutra"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(322, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkTalkOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(323, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkTalkTwoTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(324, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkTalkThreeTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(325, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkPassLegacyTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(326, 11, "ConchShip_PresetKey_JingangImpersonatorBuddhistMonkPassLegacyTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(327, 11, "ConchShip_PresetKey_JingangStillAtJingang"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(328, 11, "ConchShip_PresetKey_JingangFinishSecondSpreadSutra"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(329, 11, "ConchShip_PresetKey_JingangTriggeredChapter1Patch"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(330, 11, "ConchShip_PresetKey_JingangMonkSoulResolveDreamCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(331, 11, "ConchShip_PresetKey_JingangMonkSoulResolveDreamChatCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(332, 11, "ConchShip_PresetKey_JingangGiveFakeBook"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(333, 11, "ConchShip_PresetKey_JingangHelpSect"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(334, 7, "ConchShip_PresetKey_Ranshan_SpecialInteractionToggle"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(335, 7, "ConchShip_PresetKey_Ranshan_Chapter1_MonthlyEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(336, 7, "ConchShip_PresetKey_Ranshan_Chapter1_MonthlyEventTriggeredDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(337, 7, "ConchShip_PresetKey_Ranshan_Chapter2_TeachStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(338, 7, "ConchShip_PresetKey_Ranshan_Chapter2_HuajuCombatPlayDecision"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(339, 7, "ConchShip_PresetKey_Ranshan_Chapter2_XuanzhiCombatPlayDecision"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(340, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoCombatPlayDecision"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(341, 7, "ConchShip_PresetKey_Ranshan_Chapter2_HuajuCombatPlayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(342, 7, "ConchShip_PresetKey_Ranshan_Chapter2_XuanzhiCombatPlayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(343, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoCombatPlayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(344, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoSelection1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(345, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoSelection2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(346, 7, "ConchShip_PresetKey_SanZongBiWuCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(347, 7, "ConchShip_PresetKey_Ranshan_Chapter3_WillingToBeImmortal"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(348, 3, "ConchShip_PresetKey_BaihuaVillageSettlementIdSelection"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(349, 3, "ConchShip_PresetKey_BaihuaEndenmicTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(350, 3, "ConchShip_PresetKey_BaihuaDreamAboutPastFirstTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(351, 3, "ConchShip_PresetKey_BaihuaLeukorpusArrivedEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(352, 3, "ConchShip_PresetKey_BaihuaMelanpsycheArrivedEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(353, 3, "ConchShip_PresetKey_BaihuaSelectDenounceSuperstitious"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(354, 3, "ConchShip_PresetKey_BaihuaAdventureFourAppearDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(355, 3, "ConchShip_PresetKey_BaihuaAnonymTaiwuIsMale"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(356, 3, "ConchShip_PresetKey_BaihuaDreamAboutPastLastTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(357, 3, "ConchShip_PresetKey_BaihuaDreamAboutPastLastDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(358, 3, "ConchShip_PresetKey_BaihuaLeMeMeetTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(359, 3, "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventTriggered"));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(360, 3, "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(361, 3, "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventSettlementIdLock"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(362, 3, "ConchShip_PresetKey_BaihuaLeukoKillsInteractOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(363, 3, "ConchShip_PresetKey_BaihuaLeukoKillsCalledCharIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(364, 3, "ConchShip_PresetKey_BaihuaLeukoKillsFiveElementsType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(365, 3, "ConchShipEventArgBoxKey_PresetKey_BaihuaLeukoKillsOptionSelectDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(366, 3, "ConchShip_PresetKey_BaihuaLeukoKillsCombatWin"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(367, 3, "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(368, 3, "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(369, 3, "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventSettlementIdLock"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(370, 3, "ConchShip_PresetKey_BaihuaMelanoKillsInteractOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(371, 3, "ConchShip_PresetKey_BaihuaMelanoKillsCalledCharIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(372, 3, "ConchShip_PresetKey_BaihuaMelanoKillsFiveElementsType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(373, 3, "ConchShip_PresetKey_BaihuaMelanoKillsOptionSelectDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(374, 3, "ConchShip_PresetKey_BaihuaMelanoKillsCombatWin"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(375, 3, "ConchShip_PresetKey_BaihuaSpecialDebuffIntList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(376, 3, "ConchShip_PresetKey_BaihuaCureSpecialDebuffIntList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(377, 3, "ConchShip_PresetKey_BaihuaAnimalsBackDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(378, 3, "ConchShip_PresetKey_BaihuaLeukoAssistedMelano"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(379, 3, "ConchShip_PresetKey_BaihuaMelanoAssistedLeuko"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(380, 3, "ConchShip_PresetKey_BaihuaManicLowDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(381, 3, "ConchShip_PresetKey_BaihuaManicHighDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(382, 3, "ConchShip_PresetKey_BaihuaTriggerFinaleTaskDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(383, 3, "ConchShip_PresetKey_BaihuaBaiLuFirstInteractTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(384, 3, "ConchShip_PresetKey_BaihuaXuanXiaoFirstInteractTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(385, 3, "ConchShip_PresetKey_BaihuaAdventureFinialWinSect"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(386, 3, "ConchShip_PresetKey_BaihuaLeukoDialogNotTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(387, 3, "ConchShip_PresetKey_BaihuaMelanoDialogNotTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(388, 3, "ConchShip_PresetKey_BaihuaLeukoPlayCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(389, 3, "ConchShip_PresetKey_BaihuaMelanoPlayCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(390, 3, "ConchShip_PresetKey_BaihuaLMPlayCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(391, 3, "ConchShip_PresetKey_BaihuaLMNewsTalkedCharIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(392, 3, "ConchShip_PresetKey_BaihuaLMTransferAnimalDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(393, 3, "ConchShip_PresetKey_BaihuaFixedLMFavor"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(394, 14, "ConchShip_PresetKey_FulongDisasterStart"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(395, 14, "ConchShip_PresetKey_FulongDisasterMonthlyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(396, 14, "ConchShip_PresetKey_FulongDisasterStartProb"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(397, 14, "ConchShip_PresetKey_FulongFireFightingGuideTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(398, 14, "ConchShip_PresetKey_FulongAdventureOneCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(399, 14, "ConchShip_PresetKey_FulongAdventureThreeCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(400, 14, "ConchShip_PresetKey_FulongAdventureStartTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(401, 14, "ConchShip_PresetKey_FulongAdventureTwoTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(402, 14, "ConchShip_PresetKey_FulongShadowEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(403, 14, "ConchShip_PresetKey_FulongShadowEventOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(404, 14, "ConchShip_PresetKey_FulongShadowEventTwoTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(405, 14, "ConchShip_PresetKey_FulongReudhLazuliChatMysteryOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(406, 14, "ConchShip_PresetKey_FulongReudhLazuliChatMysteryCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(407, 14, "ConchShip_PresetKey_FulongReudhLazuliAI2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(408, 14, "ConchShip_PresetKey_FulongTravelWithLazuliWorldViewTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(409, 14, "ConchShip_PresetKey_FulongSpecialInteractOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(410, 14, "ConchShip_PresetKey_FulongTravelWithLazuliCityTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(411, 14, "ConchShip_PresetKey_FulongTravelWithLazuliTaiwuVillageTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(412, 14, "ConchShip_PresetKey_FulongTravelWithLazuliSectTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(413, 14, "ConchShip_PresetKey_FulongTravelWithLazuliTownTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(414, 14, "ConchShip_PresetKey_FulongTravelWithLazuliStockadeTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(415, 14, "ConchShip_PresetKey_FulongTravelWithLazuliVillageTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(416, 14, "ConchShip_PresetKey_FulongTravelWithLazuliXiangshuMinionTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(417, 14, "ConchShip_PresetKey_FulongTravelWithLazuliAnimalTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(418, 14, "ConchShip_PresetKey_FulongTravelWithLazuliRandomEnemyTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(419, 14, "ConchShip_PresetKey_FulongTravelWithLazuliMonvTalkTriggered"));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(420, 14, "ConchShip_PresetKey_FulongTravelWithLazuliMoveCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(421, 14, "ConchShip_PresetKey_FulongChickenKingLetterMoveCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(422, 14, "ConchShip_PresetKey_FulongTravelWithLazuliMoveAreaId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(423, 14, "ConchShip_PresetKey_FulongTravelWithLazuliChicken1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(424, 14, "ConchShip_PresetKey_FulongTravelWithLazuliChicken2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(425, 14, "ConchShip_PresetKey_FulongTravelWithLazuliFinished"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(426, 14, "ConchShip_PresetKey_FulongLazuliIsFriend"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(427, 14, "ConchShip_PresetKey_FulongSelectFalling"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(428, 14, "ConchShip_PresetKey_FulongSelectFallingDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(429, 14, "ConchShip_PresetKey_FulongReudhLazuliFeatherFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(430, 14, "ConchShip_PresetKey_FulongMessengerAppearTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(431, 14, "ConchShip_PresetKey_FulongLoseChickenFeatherInteractionSettlements"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(432, 14, "ConchShip_PresetKey_FulongLazuliLetterTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(433, 14, "ConchShip_PresetKey_FulongLazuliLetterEventA"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(434, 14, "ConchShip_PresetKey_FulongLazuliLetterEventB"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(435, 14, "ConchShip_PresetKey_FulongLazuliLetterEventC"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(436, 14, "ConchShip_PresetKey_FulongPutOutFireCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(437, 14, "ConchShip_PresetKey_FulongFireStartTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(438, 14, "ConchShip_PresetKey_FulongPutOutFire"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(439, 14, "ConchShip_PresetKey_FulongPutOutFireOnce"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(440, 14, "ConchShip_PresetKey_FulongChickenFeatherLackCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(441, 14, "ConchShip_PresetKey_FulongLazuliFindFlowerDialogLevel"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(442, 14, "ConchShip_PresetKey_FulongStayWithLazuliTaskTriggerDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(443, 14, "ConchShip_PresetKey_FulongMessengerIdList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(444, 14, "ConchShip_PresetKey_FulongChickenKingLeaveHome"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(445, 14, "ConchShip_PresetKey_FulongChickenFeatherDropList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(446, 9, "ConchShip_PresetKey_ZhujianCatchThiefTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(447, 2, "ConchShip_PresetKey_StrangerTriggerDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(448, 2, "ConchShip_PresetKey_EmeiInteractionOneTriggeredList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(449, 2, "ConchShip_PresetKey_EmeiInteractionTwoTriggeredList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(450, 2, "ConchShip_PresetKey_EmeiFirstMonthlyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(451, 15, "ConchShip_PresetKey_XuehouKillJixi"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SectMainStoryEventArgKeyItem>(452);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
	}

	public int ToTemplateId(string str)
	{
		foreach (SectMainStoryEventArgKeyItem item in (IEnumerable<SectMainStoryEventArgKeyItem>)this)
		{
			if (item.ArgBoxKey == str)
			{
				return item.TemplateId;
			}
		}
		return -1;
	}

	public string ToArgString(int templateId)
	{
		return GetItem(templateId)?.ArgBoxKey;
	}
}
