using System.Collections.Generic;

namespace GameData.Domains.Map;

public static class MapDomainHelper
{
	public static class DataIds
	{
		public const ushort Areas = 0;

		public const ushort AreaBlocks0 = 1;

		public const ushort AreaBlocks1 = 2;

		public const ushort AreaBlocks2 = 3;

		public const ushort AreaBlocks3 = 4;

		public const ushort AreaBlocks4 = 5;

		public const ushort AreaBlocks5 = 6;

		public const ushort AreaBlocks6 = 7;

		public const ushort AreaBlocks7 = 8;

		public const ushort AreaBlocks8 = 9;

		public const ushort AreaBlocks9 = 10;

		public const ushort AreaBlocks10 = 11;

		public const ushort AreaBlocks11 = 12;

		public const ushort AreaBlocks12 = 13;

		public const ushort AreaBlocks13 = 14;

		public const ushort AreaBlocks14 = 15;

		public const ushort AreaBlocks15 = 16;

		public const ushort AreaBlocks16 = 17;

		public const ushort AreaBlocks17 = 18;

		public const ushort AreaBlocks18 = 19;

		public const ushort AreaBlocks19 = 20;

		public const ushort AreaBlocks20 = 21;

		public const ushort AreaBlocks21 = 22;

		public const ushort AreaBlocks22 = 23;

		public const ushort AreaBlocks23 = 24;

		public const ushort AreaBlocks24 = 25;

		public const ushort AreaBlocks25 = 26;

		public const ushort AreaBlocks26 = 27;

		public const ushort AreaBlocks27 = 28;

		public const ushort AreaBlocks28 = 29;

		public const ushort AreaBlocks29 = 30;

		public const ushort AreaBlocks30 = 31;

		public const ushort AreaBlocks31 = 32;

		public const ushort AreaBlocks32 = 33;

		public const ushort AreaBlocks33 = 34;

		public const ushort AreaBlocks34 = 35;

		public const ushort AreaBlocks35 = 36;

		public const ushort AreaBlocks36 = 37;

		public const ushort AreaBlocks37 = 38;

		public const ushort AreaBlocks38 = 39;

		public const ushort AreaBlocks39 = 40;

		public const ushort AreaBlocks40 = 41;

		public const ushort AreaBlocks41 = 42;

		public const ushort AreaBlocks42 = 43;

		public const ushort AreaBlocks43 = 44;

		public const ushort AreaBlocks44 = 45;

		public const ushort BrokenAreaBlocks = 46;

		public const ushort BornAreaBlocks = 47;

		public const ushort GuideAreaBlocks = 48;

		public const ushort SecretVillageAreaBlocks = 49;

		public const ushort BrokenPerformAreaBlocks = 50;

		public const ushort TravelRouteDict = 51;

		public const ushort BornStateTravelRouteDict = 52;

		public const ushort CricketPlaceData = 53;

		public const ushort RegularAreaNearList = 54;

		public const ushort SwordTombLocations = 55;

		public const ushort TravelInfo = 56;

		public const ushort OnHandlingTravelingEventBlock = 57;

		public const ushort HunterAnimals = 58;

		public const ushort MoveBanned = 59;

		public const ushort CrossArchiveLockMoveTime = 60;

		public const ushort FleeBeasts = 61;

		public const ushort FleeLoongs = 62;

		public const ushort LoongLocations = 63;

		public const ushort AlterSettlementLocations = 64;

		public const ushort IsTaiwuInFulongFlameArea = 65;

		public const ushort VisibleMapPickups = 66;

		public const ushort BrokenAreaEnemies = 67;

		public const ushort StateXiangshuInfectedDemons = 68;

		public const ushort MapBlockFindDataPresets = 69;

		public const ushort PastTaiwuVillageAreaBlocks = 70;

		public const ushort PastTaiwuVillageLockMoveTime = 71;

		public const ushort ChaishanAreaBlocks = 72;

		public const ushort ArrivedSize2Blocks = 73;

		public const ushort LocationNaturalDisasterDate = 74;

		public const ushort LocationNaturalDisasterDateNew = 75;
	}

	public static class MethodIds
	{
		public const ushort GmCmd_SetLockTime = 0;

		public const ushort GmCmd_SetTeleportMove = 1;

		public const ushort GmCmd_ShowAllMapBlock = 2;

		public const ushort GmCmd_UnlockAllStation = 3;

		public const ushort GmCmd_ChangeSpiritualDebt = 4;

		public const ushort GmCmd_SetMapBlockData = 5;

		public const ushort GmCmd_CreateFixedCharacterAtCurrentBlock = 6;

		public const ushort Move = 7;

		public const ushort MoveFinish = 8;

		public const ushort IsContinuousMovingBreak = 9;

		public const ushort UnlockStation = 10;

		public const ushort GetTravelCost = 11;

		public const ushort StartTravel = 12;

		public const ushort ContinueTravel = 13;

		public const ushort StopTravel = 14;

		public const ushort RecordTravelCostedDays = 15;

		public const ushort GetAllAreaCompletelyInfectedCharCount = 16;

		public const ushort GetTravelRoutesInState = 17;

		public const ushort TryTriggerCricketCatch = 18;

		public const ushort GetBlockData = 19;

		public const ushort CollectResource = 20;

		public const ushort GetMapBlockDataList = 21;

		public const ushort GetBelongBlockTemplateIdList = 22;

		public const ushort GetLocationNameRelatedData = 23;

		public const ushort GetLocationNameRelatedDataList = 24;

		public const ushort ChangeBlockTemplate = 25;

		public const ushort IsContainsPurpleBamboo = 26;

		public const ushort GetAllStateCompletelyInfectedCharCount = 27;

		public const ushort GetBlockFullName = 28;

		public const ushort GetMapBlockDataListOptional = 29;

		public const ushort IsLocationInBuildingEffectRange = 30;

		public const ushort ContinueTravelWithDetectTravelingEvent = 31;

		public const ushort CollectAllResourcesFree = 32;

		public const ushort QuickTravel = 33;

		public const ushort QueryFixedCharacterLocation = 34;

		public const ushort GetAllAreaDisplayData = 35;

		public const ushort QueryTemplateBlockLocation = 36;

		public const ushort GetBlockDisplayDataInArea = 37;

		public const ushort UnlockTravelPath = 38;

		public const ushort GmCmd_HideAllMapBlock = 39;

		public const ushort GetPathInAreaWithoutCost = 40;

		public const ushort GetTravelPreview = 41;

		public const ushort RetrieveDreamBackLocation = 42;

		public const ushort GetAreaByAreaId = 43;

		public const ushort GmCmd_AddAnimal = 44;

		public const ushort GetTeammateBubbleCollection = 45;

		public const ushort GmCmd_AddRandomEnemyOnMap = 46;

		public const ushort GMCmd_ThrowBackend = 47;

		public const ushort SimulateHealCost = 48;

		public const ushort HealOnMap = 49;

		public const ushort TeleportByTraveler = 50;

		public const ushort BuildTravelerPalace = 51;

		public const ushort TeleportOnTravelerPalace = 52;

		public const ushort ChangeTravelerPalaceName = 53;

		public const ushort DestroyTravelerPalace = 54;

		public const ushort GmCmd_ChangeAllSpiritualDebt = 55;

		public const ushort TaiwuBeKidnapped = 56;

		public const ushort DirectTravelToTaiwuVillage = 57;

		public const ushort QueryTemplateBlockLocationInArea = 58;

		public const ushort QueryFixedCharacterLocationInArea = 59;

		public const ushort GmCmd_TurnMapBlockIntoAshes = 60;

		public const ushort GmCmd_TriggerTravelingEvent = 61;

		public const ushort GmCmd_GetTreasuryValueByTaiwuLocation = 62;

		public const ushort RequestMapBlockCharacterList = 63;

		public const ushort GetMapBlockCharacterCountData = 64;

		public const ushort GetMapBlockFindDataPreset = 65;

		public const ushort SetMapBlockFindDataPreset = 66;

		public const ushort GetReversedTeammateBubble = 67;

		public const ushort RemoveSwordTombFromLocation = 68;

		public const ushort SetBlockAndViewRangeVisibleByBlockTemplateId = 69;

		public const ushort GetPathInAreaWithAvoidSettings = 70;
	}

	public const ushort DataCount = 76;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "Areas", 0 },
		{ "AreaBlocks0", 1 },
		{ "AreaBlocks1", 2 },
		{ "AreaBlocks2", 3 },
		{ "AreaBlocks3", 4 },
		{ "AreaBlocks4", 5 },
		{ "AreaBlocks5", 6 },
		{ "AreaBlocks6", 7 },
		{ "AreaBlocks7", 8 },
		{ "AreaBlocks8", 9 },
		{ "AreaBlocks9", 10 },
		{ "AreaBlocks10", 11 },
		{ "AreaBlocks11", 12 },
		{ "AreaBlocks12", 13 },
		{ "AreaBlocks13", 14 },
		{ "AreaBlocks14", 15 },
		{ "AreaBlocks15", 16 },
		{ "AreaBlocks16", 17 },
		{ "AreaBlocks17", 18 },
		{ "AreaBlocks18", 19 },
		{ "AreaBlocks19", 20 },
		{ "AreaBlocks20", 21 },
		{ "AreaBlocks21", 22 },
		{ "AreaBlocks22", 23 },
		{ "AreaBlocks23", 24 },
		{ "AreaBlocks24", 25 },
		{ "AreaBlocks25", 26 },
		{ "AreaBlocks26", 27 },
		{ "AreaBlocks27", 28 },
		{ "AreaBlocks28", 29 },
		{ "AreaBlocks29", 30 },
		{ "AreaBlocks30", 31 },
		{ "AreaBlocks31", 32 },
		{ "AreaBlocks32", 33 },
		{ "AreaBlocks33", 34 },
		{ "AreaBlocks34", 35 },
		{ "AreaBlocks35", 36 },
		{ "AreaBlocks36", 37 },
		{ "AreaBlocks37", 38 },
		{ "AreaBlocks38", 39 },
		{ "AreaBlocks39", 40 },
		{ "AreaBlocks40", 41 },
		{ "AreaBlocks41", 42 },
		{ "AreaBlocks42", 43 },
		{ "AreaBlocks43", 44 },
		{ "AreaBlocks44", 45 },
		{ "BrokenAreaBlocks", 46 },
		{ "BornAreaBlocks", 47 },
		{ "GuideAreaBlocks", 48 },
		{ "SecretVillageAreaBlocks", 49 },
		{ "BrokenPerformAreaBlocks", 50 },
		{ "TravelRouteDict", 51 },
		{ "BornStateTravelRouteDict", 52 },
		{ "CricketPlaceData", 53 },
		{ "RegularAreaNearList", 54 },
		{ "SwordTombLocations", 55 },
		{ "TravelInfo", 56 },
		{ "OnHandlingTravelingEventBlock", 57 },
		{ "HunterAnimals", 58 },
		{ "MoveBanned", 59 },
		{ "CrossArchiveLockMoveTime", 60 },
		{ "FleeBeasts", 61 },
		{ "FleeLoongs", 62 },
		{ "LoongLocations", 63 },
		{ "AlterSettlementLocations", 64 },
		{ "IsTaiwuInFulongFlameArea", 65 },
		{ "VisibleMapPickups", 66 },
		{ "BrokenAreaEnemies", 67 },
		{ "StateXiangshuInfectedDemons", 68 },
		{ "MapBlockFindDataPresets", 69 },
		{ "PastTaiwuVillageAreaBlocks", 70 },
		{ "PastTaiwuVillageLockMoveTime", 71 },
		{ "ChaishanAreaBlocks", 72 },
		{ "ArrivedSize2Blocks", 73 },
		{ "LocationNaturalDisasterDate", 74 },
		{ "LocationNaturalDisasterDateNew", 75 }
	};

	public static readonly string[] DataId2FieldName = new string[76]
	{
		"Areas", "AreaBlocks0", "AreaBlocks1", "AreaBlocks2", "AreaBlocks3", "AreaBlocks4", "AreaBlocks5", "AreaBlocks6", "AreaBlocks7", "AreaBlocks8",
		"AreaBlocks9", "AreaBlocks10", "AreaBlocks11", "AreaBlocks12", "AreaBlocks13", "AreaBlocks14", "AreaBlocks15", "AreaBlocks16", "AreaBlocks17", "AreaBlocks18",
		"AreaBlocks19", "AreaBlocks20", "AreaBlocks21", "AreaBlocks22", "AreaBlocks23", "AreaBlocks24", "AreaBlocks25", "AreaBlocks26", "AreaBlocks27", "AreaBlocks28",
		"AreaBlocks29", "AreaBlocks30", "AreaBlocks31", "AreaBlocks32", "AreaBlocks33", "AreaBlocks34", "AreaBlocks35", "AreaBlocks36", "AreaBlocks37", "AreaBlocks38",
		"AreaBlocks39", "AreaBlocks40", "AreaBlocks41", "AreaBlocks42", "AreaBlocks43", "AreaBlocks44", "BrokenAreaBlocks", "BornAreaBlocks", "GuideAreaBlocks", "SecretVillageAreaBlocks",
		"BrokenPerformAreaBlocks", "TravelRouteDict", "BornStateTravelRouteDict", "CricketPlaceData", "RegularAreaNearList", "SwordTombLocations", "TravelInfo", "OnHandlingTravelingEventBlock", "HunterAnimals", "MoveBanned",
		"CrossArchiveLockMoveTime", "FleeBeasts", "FleeLoongs", "LoongLocations", "AlterSettlementLocations", "IsTaiwuInFulongFlameArea", "VisibleMapPickups", "BrokenAreaEnemies", "StateXiangshuInfectedDemons", "MapBlockFindDataPresets",
		"PastTaiwuVillageAreaBlocks", "PastTaiwuVillageLockMoveTime", "ChaishanAreaBlocks", "ArrivedSize2Blocks", "LocationNaturalDisasterDate", "LocationNaturalDisasterDateNew"
	};

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[76][];

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GmCmd_SetLockTime", 0 },
		{ "GmCmd_SetTeleportMove", 1 },
		{ "GmCmd_ShowAllMapBlock", 2 },
		{ "GmCmd_UnlockAllStation", 3 },
		{ "GmCmd_ChangeSpiritualDebt", 4 },
		{ "GmCmd_SetMapBlockData", 5 },
		{ "GmCmd_CreateFixedCharacterAtCurrentBlock", 6 },
		{ "Move", 7 },
		{ "MoveFinish", 8 },
		{ "IsContinuousMovingBreak", 9 },
		{ "UnlockStation", 10 },
		{ "GetTravelCost", 11 },
		{ "StartTravel", 12 },
		{ "ContinueTravel", 13 },
		{ "StopTravel", 14 },
		{ "RecordTravelCostedDays", 15 },
		{ "GetAllAreaCompletelyInfectedCharCount", 16 },
		{ "GetTravelRoutesInState", 17 },
		{ "TryTriggerCricketCatch", 18 },
		{ "GetBlockData", 19 },
		{ "CollectResource", 20 },
		{ "GetMapBlockDataList", 21 },
		{ "GetBelongBlockTemplateIdList", 22 },
		{ "GetLocationNameRelatedData", 23 },
		{ "GetLocationNameRelatedDataList", 24 },
		{ "ChangeBlockTemplate", 25 },
		{ "IsContainsPurpleBamboo", 26 },
		{ "GetAllStateCompletelyInfectedCharCount", 27 },
		{ "GetBlockFullName", 28 },
		{ "GetMapBlockDataListOptional", 29 },
		{ "IsLocationInBuildingEffectRange", 30 },
		{ "ContinueTravelWithDetectTravelingEvent", 31 },
		{ "CollectAllResourcesFree", 32 },
		{ "QuickTravel", 33 },
		{ "QueryFixedCharacterLocation", 34 },
		{ "GetAllAreaDisplayData", 35 },
		{ "QueryTemplateBlockLocation", 36 },
		{ "GetBlockDisplayDataInArea", 37 },
		{ "UnlockTravelPath", 38 },
		{ "GmCmd_HideAllMapBlock", 39 },
		{ "GetPathInAreaWithoutCost", 40 },
		{ "GetTravelPreview", 41 },
		{ "RetrieveDreamBackLocation", 42 },
		{ "GetAreaByAreaId", 43 },
		{ "GmCmd_AddAnimal", 44 },
		{ "GetTeammateBubbleCollection", 45 },
		{ "GmCmd_AddRandomEnemyOnMap", 46 },
		{ "GMCmd_ThrowBackend", 47 },
		{ "SimulateHealCost", 48 },
		{ "HealOnMap", 49 },
		{ "TeleportByTraveler", 50 },
		{ "BuildTravelerPalace", 51 },
		{ "TeleportOnTravelerPalace", 52 },
		{ "ChangeTravelerPalaceName", 53 },
		{ "DestroyTravelerPalace", 54 },
		{ "GmCmd_ChangeAllSpiritualDebt", 55 },
		{ "TaiwuBeKidnapped", 56 },
		{ "DirectTravelToTaiwuVillage", 57 },
		{ "QueryTemplateBlockLocationInArea", 58 },
		{ "QueryFixedCharacterLocationInArea", 59 },
		{ "GmCmd_TurnMapBlockIntoAshes", 60 },
		{ "GmCmd_TriggerTravelingEvent", 61 },
		{ "GmCmd_GetTreasuryValueByTaiwuLocation", 62 },
		{ "RequestMapBlockCharacterList", 63 },
		{ "GetMapBlockCharacterCountData", 64 },
		{ "GetMapBlockFindDataPreset", 65 },
		{ "SetMapBlockFindDataPreset", 66 },
		{ "GetReversedTeammateBubble", 67 },
		{ "RemoveSwordTombFromLocation", 68 },
		{ "SetBlockAndViewRangeVisibleByBlockTemplateId", 69 },
		{ "GetPathInAreaWithAvoidSettings", 70 }
	};

	public static readonly string[] MethodId2MethodName = new string[71]
	{
		"GmCmd_SetLockTime", "GmCmd_SetTeleportMove", "GmCmd_ShowAllMapBlock", "GmCmd_UnlockAllStation", "GmCmd_ChangeSpiritualDebt", "GmCmd_SetMapBlockData", "GmCmd_CreateFixedCharacterAtCurrentBlock", "Move", "MoveFinish", "IsContinuousMovingBreak",
		"UnlockStation", "GetTravelCost", "StartTravel", "ContinueTravel", "StopTravel", "RecordTravelCostedDays", "GetAllAreaCompletelyInfectedCharCount", "GetTravelRoutesInState", "TryTriggerCricketCatch", "GetBlockData",
		"CollectResource", "GetMapBlockDataList", "GetBelongBlockTemplateIdList", "GetLocationNameRelatedData", "GetLocationNameRelatedDataList", "ChangeBlockTemplate", "IsContainsPurpleBamboo", "GetAllStateCompletelyInfectedCharCount", "GetBlockFullName", "GetMapBlockDataListOptional",
		"IsLocationInBuildingEffectRange", "ContinueTravelWithDetectTravelingEvent", "CollectAllResourcesFree", "QuickTravel", "QueryFixedCharacterLocation", "GetAllAreaDisplayData", "QueryTemplateBlockLocation", "GetBlockDisplayDataInArea", "UnlockTravelPath", "GmCmd_HideAllMapBlock",
		"GetPathInAreaWithoutCost", "GetTravelPreview", "RetrieveDreamBackLocation", "GetAreaByAreaId", "GmCmd_AddAnimal", "GetTeammateBubbleCollection", "GmCmd_AddRandomEnemyOnMap", "GMCmd_ThrowBackend", "SimulateHealCost", "HealOnMap",
		"TeleportByTraveler", "BuildTravelerPalace", "TeleportOnTravelerPalace", "ChangeTravelerPalaceName", "DestroyTravelerPalace", "GmCmd_ChangeAllSpiritualDebt", "TaiwuBeKidnapped", "DirectTravelToTaiwuVillage", "QueryTemplateBlockLocationInArea", "QueryFixedCharacterLocationInArea",
		"GmCmd_TurnMapBlockIntoAshes", "GmCmd_TriggerTravelingEvent", "GmCmd_GetTreasuryValueByTaiwuLocation", "RequestMapBlockCharacterList", "GetMapBlockCharacterCountData", "GetMapBlockFindDataPreset", "SetMapBlockFindDataPreset", "GetReversedTeammateBubble", "RemoveSwordTombFromLocation", "SetBlockAndViewRangeVisibleByBlockTemplateId",
		"GetPathInAreaWithAvoidSettings"
	};
}
