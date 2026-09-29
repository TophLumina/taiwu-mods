using System;
using System.Collections.Generic;
using System.Linq;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerType : ConfigData<EventTriggerTypeItem, int>
{
	public static class DefKey
	{
		public const int TaiwuBlockChanged = 0;

		public const int CharacterClicked = 1;

		public const int AnimalAvatarClicked = 2;

		public const int PurpleBambooAvatarClicked = 3;

		public const int FixedCharacterClicked = 4;

		public const int FixedEnemyClicked = 5;

		public const int CharacterTemplateClicked = 6;

		public const int NpcTombClicked = 7;

		public const int InteractPrisoner = 8;

		public const int LetTeammateLeaveGroup = 9;

		public const int NeedToPassLegacy = 10;

		public const int CaravanClicked = 11;

		public const int KidnappedCharacterClicked = 12;

		public const int RecordEnterGame = 13;

		public const int NewGameMonth = 14;

		public const int BlackMaskAnimationComplete = 15;

		public const int CloseUI = 16;

		public const int EnterBuildingArea = 62;

		public const int SectBuildingClicked = 17;

		public const int ConstructComplete = 18;

		public const int CollectedMakingSystemItem = 19;

		public const int OnSectSpecialBuildingClicked = 20;

		public const int OnClickedChickenCoop = 21;

		public const int OnSettlementTreasuryBuildingClicked = 22;

		public const int SwitchToGuardedPage = 23;

		public const int TaiwuVillageDestroyed = 24;

		public const int OnClickedPrisonBtn = 25;

		public const int OnClickedSendPrisonBtn = 26;

		public const int ClickChicken = 27;

		public const int MainStoryFinishCatchCricket = 28;

		public const int UserLoadDreamBackArchive = 29;

		public const int LifeSkillCombatForceSilent = 30;

		public const int CombatOpening = 31;

		public const int ProfessionExperienceChange = 32;

		public const int ProfessionSkillClicked = 33;

		public const int TaiwuGotTianjieFulu = 34;

		public const int TaiwuSaveCountChange = 35;

		public const int TaiwuFindMaterial = 36;

		public const int TaiwuFindExtraTreasure = 37;

		public const int TaiwuVillagerExpelled = 38;

		public const int TaiwuCrossArchive = 39;

		public const int TaiwuCrossArchiveFindMemory = 40;

		public const int OperateInventoryItem = 41;

		public const int ConfirmEnterSwordTomb = 42;

		public const int TaiwuBeHuntedArrivedSect = 43;

		public const int TaiwuBeHuntedHunterDie = 44;

		public const int TriggerBatchMapPickupEvent = 45;

		public const int TriggerMapPickupEvent = 46;

		public const int TaiwuInvite = 47;

		public const int EnterTutorialChapter = 48;

		public const int TryMoveWhenMoveDisabled = 49;

		public const int TryMoveToInvalidLocationInTutorial = 50;

		public const int TaiwuDeportVitals = 51;

		public const int SoulWitheringBellTransfer = 52;

		public const int CatchThief = 53;

		public const int OnShixiangDrumClickedManyTimes = 54;

		public const int JingangSectMainStoryReborn = 55;

		public const int JingangSectMainStoryMonkSoul = 56;

		public const int TaiwuCollectWudangHeavenlyTreeSeed = 57;

		public const int StartSectShaolinDemonSlayer = 58;

		public const int DlcLoongPutJiaoEggs = 59;

		public const int DlcLoongInteractJiao = 60;

		public const int DlcLoongPetJiao = 61;

		public const int OnClickedCultivateFeather = 63;

		public const int OnFinishTravel = 64;

		public const int ClickDamageHugeSword = 65;

		public const int MajorEventPoint = 66;

		public const int TaiwuMiscGift = 67;

		public const int TwelveImmortals2AttackTaiwu = 68;

		public const int FirstIntoTwelveImmortalsImpactRange = 69;

		public const int ClickEmeiGuidance = 70;

		public const int XiangshuTowerRetrieveDemonHeart = 71;

		public const int XiangshuTowerFinalBattleTiandi = 72;

		public const int ChickenPolymorph = 73;

		public const int AdvanceMonthExecute = 74;
	}

	public static class DefValue
	{
		public static EventTriggerTypeItem TaiwuBlockChanged => Instance[0];

		public static EventTriggerTypeItem CharacterClicked => Instance[1];

		public static EventTriggerTypeItem AnimalAvatarClicked => Instance[2];

		public static EventTriggerTypeItem PurpleBambooAvatarClicked => Instance[3];

		public static EventTriggerTypeItem FixedCharacterClicked => Instance[4];

		public static EventTriggerTypeItem FixedEnemyClicked => Instance[5];

		public static EventTriggerTypeItem CharacterTemplateClicked => Instance[6];

		public static EventTriggerTypeItem NpcTombClicked => Instance[7];

		public static EventTriggerTypeItem InteractPrisoner => Instance[8];

		public static EventTriggerTypeItem LetTeammateLeaveGroup => Instance[9];

		public static EventTriggerTypeItem NeedToPassLegacy => Instance[10];

		public static EventTriggerTypeItem CaravanClicked => Instance[11];

		public static EventTriggerTypeItem KidnappedCharacterClicked => Instance[12];

		public static EventTriggerTypeItem RecordEnterGame => Instance[13];

		public static EventTriggerTypeItem NewGameMonth => Instance[14];

		public static EventTriggerTypeItem BlackMaskAnimationComplete => Instance[15];

		public static EventTriggerTypeItem CloseUI => Instance[16];

		public static EventTriggerTypeItem EnterBuildingArea => Instance[62];

		public static EventTriggerTypeItem SectBuildingClicked => Instance[17];

		public static EventTriggerTypeItem ConstructComplete => Instance[18];

		public static EventTriggerTypeItem CollectedMakingSystemItem => Instance[19];

		public static EventTriggerTypeItem OnSectSpecialBuildingClicked => Instance[20];

		public static EventTriggerTypeItem OnClickedChickenCoop => Instance[21];

		public static EventTriggerTypeItem OnSettlementTreasuryBuildingClicked => Instance[22];

		public static EventTriggerTypeItem SwitchToGuardedPage => Instance[23];

		public static EventTriggerTypeItem TaiwuVillageDestroyed => Instance[24];

		public static EventTriggerTypeItem OnClickedPrisonBtn => Instance[25];

		public static EventTriggerTypeItem OnClickedSendPrisonBtn => Instance[26];

		public static EventTriggerTypeItem ClickChicken => Instance[27];

		public static EventTriggerTypeItem MainStoryFinishCatchCricket => Instance[28];

		public static EventTriggerTypeItem UserLoadDreamBackArchive => Instance[29];

		public static EventTriggerTypeItem LifeSkillCombatForceSilent => Instance[30];

		public static EventTriggerTypeItem CombatOpening => Instance[31];

		public static EventTriggerTypeItem ProfessionExperienceChange => Instance[32];

		public static EventTriggerTypeItem ProfessionSkillClicked => Instance[33];

		public static EventTriggerTypeItem TaiwuGotTianjieFulu => Instance[34];

		public static EventTriggerTypeItem TaiwuSaveCountChange => Instance[35];

		public static EventTriggerTypeItem TaiwuFindMaterial => Instance[36];

		public static EventTriggerTypeItem TaiwuFindExtraTreasure => Instance[37];

		public static EventTriggerTypeItem TaiwuVillagerExpelled => Instance[38];

		public static EventTriggerTypeItem TaiwuCrossArchive => Instance[39];

		public static EventTriggerTypeItem TaiwuCrossArchiveFindMemory => Instance[40];

		public static EventTriggerTypeItem OperateInventoryItem => Instance[41];

		public static EventTriggerTypeItem ConfirmEnterSwordTomb => Instance[42];

		public static EventTriggerTypeItem TaiwuBeHuntedArrivedSect => Instance[43];

		public static EventTriggerTypeItem TaiwuBeHuntedHunterDie => Instance[44];

		public static EventTriggerTypeItem TriggerBatchMapPickupEvent => Instance[45];

		public static EventTriggerTypeItem TriggerMapPickupEvent => Instance[46];

		public static EventTriggerTypeItem TaiwuInvite => Instance[47];

		public static EventTriggerTypeItem EnterTutorialChapter => Instance[48];

		public static EventTriggerTypeItem TryMoveWhenMoveDisabled => Instance[49];

		public static EventTriggerTypeItem TryMoveToInvalidLocationInTutorial => Instance[50];

		public static EventTriggerTypeItem TaiwuDeportVitals => Instance[51];

		public static EventTriggerTypeItem SoulWitheringBellTransfer => Instance[52];

		public static EventTriggerTypeItem CatchThief => Instance[53];

		public static EventTriggerTypeItem OnShixiangDrumClickedManyTimes => Instance[54];

		public static EventTriggerTypeItem JingangSectMainStoryReborn => Instance[55];

		public static EventTriggerTypeItem JingangSectMainStoryMonkSoul => Instance[56];

		public static EventTriggerTypeItem TaiwuCollectWudangHeavenlyTreeSeed => Instance[57];

		public static EventTriggerTypeItem StartSectShaolinDemonSlayer => Instance[58];

		public static EventTriggerTypeItem DlcLoongPutJiaoEggs => Instance[59];

		public static EventTriggerTypeItem DlcLoongInteractJiao => Instance[60];

		public static EventTriggerTypeItem DlcLoongPetJiao => Instance[61];

		public static EventTriggerTypeItem OnClickedCultivateFeather => Instance[63];

		public static EventTriggerTypeItem OnFinishTravel => Instance[64];

		public static EventTriggerTypeItem ClickDamageHugeSword => Instance[65];

		public static EventTriggerTypeItem MajorEventPoint => Instance[66];

		public static EventTriggerTypeItem TaiwuMiscGift => Instance[67];

		public static EventTriggerTypeItem TwelveImmortals2AttackTaiwu => Instance[68];

		public static EventTriggerTypeItem FirstIntoTwelveImmortalsImpactRange => Instance[69];

		public static EventTriggerTypeItem ClickEmeiGuidance => Instance[70];

		public static EventTriggerTypeItem XiangshuTowerRetrieveDemonHeart => Instance[71];

		public static EventTriggerTypeItem XiangshuTowerFinalBattleTiandi => Instance[72];

		public static EventTriggerTypeItem ChickenPolymorph => Instance[73];

		public static EventTriggerTypeItem AdvanceMonthExecute => Instance[74];
	}

	public static EventTriggerType Instance = new EventTriggerType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Parameters", "TemplateId", "KeyCode" };

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
		_dataArray.Add(new EventTriggerTypeItem(0, new int[2] { 11, 12 }, "TaiwuBlockChanged", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(1, new int[1], "CharacterClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(2, new int[1] { 3 }, "AnimalAvatarClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(3, new int[2] { 0, 10 }, "PurpleBambooAvatarClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(4, new int[2] { 0, 1 }, "FixedCharacterClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(5, new int[2] { 0, 1 }, "FixedEnemyClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(6, new int[1] { 1 }, "CharacterTemplateClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(7, new int[1] { 2 }, "NpcTombClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(8, new int[3] { 0, 47, 37 }, "InteractPrisoner", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(9, new int[1], "LetTeammateLeaveGroup", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(10, new int[2] { 14, 50 }, "NeedToPassLegacy", canTriggerInAdvanceMonth: true, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(11, new int[1] { 4 }, "CaravanClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(12, new int[1], "KidnappedCharacterClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(13, new int[0], "RecordEnterGame", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(14, new int[0], "NewGameMonth", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(15, new int[1] { 15 }, "BlackMaskAnimationComplete", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(16, new int[3] { 24, 49, 48 }, "CloseUI", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(17, new int[1] { 17 }, "SectBuildingClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(18, new int[3] { 16, 17, 40 }, "ConstructComplete", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(19, new int[3] { 16, 17, 44 }, "CollectedMakingSystemItem", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(20, new int[1] { 17 }, "OnSectSpecialBuildingClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(21, new int[0], "OnClickedChickenCoop", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(22, new int[2] { 17, 37 }, "OnSettlementTreasuryBuildingClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(23, new int[2] { 38, 37 }, "SwitchToGuardedPage", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(24, new int[0], "TaiwuVillageDestroyed", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(25, new int[1] { 17 }, "OnClickedPrisonBtn", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(26, new int[0], "OnClickedSendPrisonBtn", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(27, new int[2] { 5, 6 }, "ClickChicken", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(28, new int[1] { 18 }, "MainStoryFinishCatchCricket", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(29, new int[0], "UserLoadDreamBackArchive", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(30, new int[3] { 0, 45, 46 }, "LifeSkillCombatForceSilent", canTriggerInAdvanceMonth: true, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(31, new int[1], "CombatOpening", canTriggerInAdvanceMonth: true, canTriggerInCombat: true, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(32, new int[1] { 19 }, "ProfessionExperienceChange", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(33, new int[1] { 20 }, "ProfessionSkillClicked", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(34, new int[3] { 0, 42, 43 }, "TaiwuGotTianjieFulu", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(35, new int[1] { 39 }, "TaiwuSaveCountChange", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(36, new int[2] { 27, 28 }, "TaiwuFindMaterial", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(37, new int[1] { 28 }, "TaiwuFindExtraTreasure", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(38, new int[1], "TaiwuVillagerExpelled", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(39, new int[0], "TaiwuCrossArchive", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(40, new int[1] { 29 }, "TaiwuCrossArchiveFindMemory", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(41, new int[4] { 0, 30, 51, 13 }, "OperateInventoryItem", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(42, new int[0], "ConfirmEnterSwordTomb", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(43, new int[1], "TaiwuBeHuntedArrivedSect", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(44, new int[1], "TaiwuBeHuntedHunterDie", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(45, new int[3] { 8, 35, 36 }, "TriggerBatchMapPickupEvent", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(46, new int[2] { 8, 23 }, "TriggerMapPickupEvent", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(47, new int[2] { 0, 9 }, "TaiwuInvite", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(48, new int[1] { 31 }, "EnterTutorialChapter", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(49, new int[0], "TryMoveWhenMoveDisabled", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(50, new int[0], "TryMoveToInvalidLocationInTutorial", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(51, new int[2] { 32, 33 }, "TaiwuDeportVitals", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(52, new int[0], "SoulWitheringBellTransfer", canTriggerInAdvanceMonth: false, canTriggerInCombat: true, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(53, new int[2] { 25, 26 }, "CatchThief", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(54, new int[0], "OnShixiangDrumClickedManyTimes", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(55, new int[0], "JingangSectMainStoryReborn", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(56, new int[0], "JingangSectMainStoryMonkSoul", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(57, new int[1] { 22 }, "TaiwuCollectWudangHeavenlyTreeSeed", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(58, new int[1] { 34 }, "StartSectShaolinDemonSlayer", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(59, new int[2] { 21, 41 }, "DlcLoongPutJiaoEggs", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EventTriggerTypeItem(60, new int[1] { 21 }, "DlcLoongInteractJiao", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(61, new int[1] { 21 }, "DlcLoongPetJiao", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(62, new int[1] { 8 }, "EnterBuildingArea", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(63, new int[0], "OnClickedCultivateFeather", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(64, new int[0], "OnFinishTravel", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(65, new int[0], "ClickDamageHugeSword", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(66, new int[0], "MajorEventPoint", canTriggerInAdvanceMonth: true, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(67, new int[2] { 0, 7 }, "TaiwuMiscGift", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(68, new int[0], "TwelveImmortals2AttackTaiwu", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(69, new int[1], "FirstIntoTwelveImmortalsImpactRange", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: false));
		_dataArray.Add(new EventTriggerTypeItem(70, new int[1], "ClickEmeiGuidance", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(71, new int[0], "XiangshuTowerRetrieveDemonHeart", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(72, new int[0], "XiangshuTowerFinalBattleTiandi", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(73, new int[2] { 54, 55 }, "ChickenPolymorph", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
		_dataArray.Add(new EventTriggerTypeItem(74, new int[0], "AdvanceMonthExecute", canTriggerInAdvanceMonth: false, canTriggerInCombat: false, canTriggerInCombatBegin: false, allowExternal: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventTriggerTypeItem>(75);
		CreateItems0();
		CreateItems1();
	}

	public EventTriggerTypeItem GetByKeyCode(string keyCode)
	{
		return this.FirstOrDefault((EventTriggerTypeItem trigger) => trigger.KeyCode == keyCode);
	}
}
