using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent;

public static class TaiwuEventDomainHelper
{
	public static class DataIds
	{
		public const ushort GlobalArgBox = 0;

		public const ushort MonthlyEventActionManager = 1;

		public const ushort CgName = 2;

		public const ushort NotifyData = 3;

		public const ushort HasListeningEvent = 4;

		public const ushort SelectInformationData = 5;

		public const ushort TaiwuLocationChangeFlag = 6;

		public const ushort SecretVillageOnFire = 7;

		public const ushort TaiwuVillageShowShrine = 8;

		public const ushort HideAllTeammates = 9;

		public const ushort LeftRoleAlternativeName = 10;

		public const ushort RightRoleAlternativeName = 11;

		public const ushort RightRoleXiangshuDisplayData = 12;

		public const ushort SelectCombatSkillData = 13;

		public const ushort SelectLifeSkillData = 14;

		public const ushort ItemListOfLeft = 15;

		public const ushort ItemListOfRight = 16;

		public const ushort ShowItemWithCricketBattleGuess = 17;

		public const ushort DisplayingEventData = 18;

		public const ushort TempCreateItemList = 19;

		public const ushort CoverCricketJarGradeListForRight = 20;

		public const ushort MarriageLook1CharIdList = 21;

		public const ushort MarriageLook2CharIdList = 22;

		public const ushort AllCombatGroupChars = 23;

		public const ushort CricketBettingData = 24;

		public const ushort JieqingMaskCharIdList = 25;

		public const ushort HandledOneShotEvents = 26;

		public const ushort HideAllMapBlockCharacters = 27;

		public const ushort NeedToNotifyNewMonth = 28;

		public const ushort CommonOptionPreviewEventOptionInfos = 29;
	}

	public static class MethodIds
	{
		public const ushort InitConchShipEvents = 0;

		public const ushort TriggerListener = 1;

		public const ushort SetItemSelectResult = 2;

		public const ushort SetCharacterSelectResult = 3;

		public const ushort SetSecretInformationSelectResult = 4;

		public const ushort SetNormalInformationSelectResult = 5;

		public const ushort StartHandleEventDuringAdvance = 6;

		public const ushort GetTriggeredEventSummaryDisplayData = 7;

		public const ushort SetEventInProcessing = 8;

		public const ushort EventSelect = 9;

		public const ushort GetEventDisplayData = 10;

		public const ushort OnCharacterClicked = 11;

		public const ushort OnLetTeammateLeaveGroup = 12;

		public const ushort OnInteractCaravan = 13;

		public const ushort OnInteractKidnappedCharacter = 14;

		public const ushort OnSectBuildingClicked = 15;

		public const ushort OnRecordEnterGame = 16;

		public const ushort OnNewGameMonth = 17;

		public const ushort OnCombatWithXiangshuMinionComplete = 18;

		public const ushort OnBlackMaskAnimationComplete = 19;

		public const ushort OnMakingSystemOpened = 20;

		public const ushort OnCollectedMakingSystemItem = 21;

		public const ushort OnSectSpecialBuildingClicked = 22;

		public const ushort AnimalAvatarClicked = 23;

		public const ushort MainStoryFinishCatchCricket = 24;

		public const ushort LoadEventsFromPath = 25;

		public const ushort NpcTombClicked = 26;

		public const ushort SetLifeSkillSelectResult = 27;

		public const ushort SetCombatSkillSelectResult = 28;

		public const ushort OnLifeSkillCombatForceSilent = 29;

		public const ushort TryMoveWhenMoveDisable = 30;

		public const ushort TryMoveToInvalidLocationInTutorial = 31;

		public const ushort SetCharacterSetSelectResult = 32;

		public const ushort OnCharacterTemplateClicked = 33;

		public const ushort CloseUI = 34;

		public const ushort SetIsQuickStartGame = 35;

		public const ushort TaiwuCollectWudangHeavenlyTreeSeed = 36;

		public const ushort GetEventLogData = 37;

		public const ushort StartNewDialog = 38;

		public const ushort TaiwuVillagerExpelled = 39;

		public const ushort GmCmd_TaiwuCrossArchive = 40;

		public const ushort TaiwuCrossArchiveFindMemory = 41;

		public const ushort UserLoadDreamBackArchive = 42;

		public const ushort OperateInventoryItem = 43;

		public const ushort SetItemSelectCount = 44;

		public const ushort SettlementTreasuryBuildingClicked = 45;

		public const ushort SetListenerEventActionISerializableArg = 46;

		public const ushort SetListenerEventActionIntArg = 47;

		public const ushort SetListenerEventActionBoolArg = 48;

		public const ushort SetListenerEventActionStringArg = 49;

		public const ushort GetValidInteractionEventOptions = 50;

		public const ushort SetListenerEventActionIntListArg = 51;

		public const ushort SetListenerEventActionItemKeyArg = 52;

		public const ushort TriggerShixiangDrumEasterEgg = 53;

		public const ushort InteractPrisoner = 54;

		public const ushort OnClickedSendPrisonBtn = 55;

		public const ushort OnClickedPrisonBtn = 56;

		public const ushort SetCharacterMultSelectResult = 57;

		public const ushort SetCricketBettingResult = 58;

		public const ushort GetImplementedFunctionIds = 59;

		public const ushort SetEventScriptExecutionPause = 60;

		public const ushort EventScriptExecuteNext = 61;

		public const ushort GmCmd_TaiwuWantedSectPunished = 62;

		public const ushort EventSelectContinue = 63;

		public const ushort SetSelectCount = 64;

		public const ushort SetListenerEventActionShortListArg = 65;

		public const ushort SetShowingEventShortListArg = 66;

		public const ushort OnClickMapPickupEvent = 67;

		public const ushort OnClickMapPickupNormalEvent = 68;

		public const ushort OnClickDeportButton = 69;

		public const ushort OnSwitchToGuardedPage = 70;

		public const ushort GmCmd_AddJieqingMaskCharId = 71;

		public const ushort GmCmd_RemoveJieqingMaskCharId = 72;

		public const ushort EventCommonOptionSelect = 73;

		public const ushort JumpToInteractionEventOption = 74;

		public const ushort JumpToInteractionEventOptionByInteractionId = 75;

		public const ushort OnTaiwuTryInvite = 76;

		public const ushort ReloadConchShipEvents = 77;

		public const ushort OnClickMapPickupBatchEvent = 78;

		public const ushort GmCmd_GetGlobalArgBoxInt = 79;

		public const ushort GmCmd_SetGlobalArgBoxInt = 80;

		public const ushort CheckIsShowingEvent = 81;

		public const ushort OnClickChickenCoop = 82;

		public const ushort SetShowingEventItemKeyArg = 83;

		public const ushort SetShowingEventShortArg = 84;

		public const ushort OnEnterBuildingArea = 85;

		public const ushort EventCommonOptionPreview = 86;

		public const ushort GmCmd_TravelToPastTaiwuVillage = 87;

		public const ushort GmCmd_BackFromPastTaiwuVillage = 88;

		public const ushort EventCommonOptionHaveAvailableOption = 89;

		public const ushort GmCmd_TriggerOvercomeCombatOver = 90;

		public const ushort MeetTaiwu = 91;

		public const ushort OnClickedXiangshuRetrieveDemonHeartBtn = 92;

		public const ushort OnClickedXiangshuFinalBattleTiandiBtn = 93;

		public const ushort UpdateShowingEventCharacterDisplayData = 94;
	}

	public const ushort DataCount = 30;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "GlobalArgBox", 0 },
		{ "MonthlyEventActionManager", 1 },
		{ "CgName", 2 },
		{ "NotifyData", 3 },
		{ "HasListeningEvent", 4 },
		{ "SelectInformationData", 5 },
		{ "TaiwuLocationChangeFlag", 6 },
		{ "SecretVillageOnFire", 7 },
		{ "TaiwuVillageShowShrine", 8 },
		{ "HideAllTeammates", 9 },
		{ "LeftRoleAlternativeName", 10 },
		{ "RightRoleAlternativeName", 11 },
		{ "RightRoleXiangshuDisplayData", 12 },
		{ "SelectCombatSkillData", 13 },
		{ "SelectLifeSkillData", 14 },
		{ "ItemListOfLeft", 15 },
		{ "ItemListOfRight", 16 },
		{ "ShowItemWithCricketBattleGuess", 17 },
		{ "DisplayingEventData", 18 },
		{ "TempCreateItemList", 19 },
		{ "CoverCricketJarGradeListForRight", 20 },
		{ "MarriageLook1CharIdList", 21 },
		{ "MarriageLook2CharIdList", 22 },
		{ "AllCombatGroupChars", 23 },
		{ "CricketBettingData", 24 },
		{ "JieqingMaskCharIdList", 25 },
		{ "HandledOneShotEvents", 26 },
		{ "HideAllMapBlockCharacters", 27 },
		{ "NeedToNotifyNewMonth", 28 },
		{ "CommonOptionPreviewEventOptionInfos", 29 }
	};

	public static readonly string[] DataId2FieldName = new string[30]
	{
		"GlobalArgBox", "MonthlyEventActionManager", "CgName", "NotifyData", "HasListeningEvent", "SelectInformationData", "TaiwuLocationChangeFlag", "SecretVillageOnFire", "TaiwuVillageShowShrine", "HideAllTeammates",
		"LeftRoleAlternativeName", "RightRoleAlternativeName", "RightRoleXiangshuDisplayData", "SelectCombatSkillData", "SelectLifeSkillData", "ItemListOfLeft", "ItemListOfRight", "ShowItemWithCricketBattleGuess", "DisplayingEventData", "TempCreateItemList",
		"CoverCricketJarGradeListForRight", "MarriageLook1CharIdList", "MarriageLook2CharIdList", "AllCombatGroupChars", "CricketBettingData", "JieqingMaskCharIdList", "HandledOneShotEvents", "HideAllMapBlockCharacters", "NeedToNotifyNewMonth", "CommonOptionPreviewEventOptionInfos"
	};

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[30][];

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "InitConchShipEvents", 0 },
		{ "TriggerListener", 1 },
		{ "SetItemSelectResult", 2 },
		{ "SetCharacterSelectResult", 3 },
		{ "SetSecretInformationSelectResult", 4 },
		{ "SetNormalInformationSelectResult", 5 },
		{ "StartHandleEventDuringAdvance", 6 },
		{ "GetTriggeredEventSummaryDisplayData", 7 },
		{ "SetEventInProcessing", 8 },
		{ "EventSelect", 9 },
		{ "GetEventDisplayData", 10 },
		{ "OnCharacterClicked", 11 },
		{ "OnLetTeammateLeaveGroup", 12 },
		{ "OnInteractCaravan", 13 },
		{ "OnInteractKidnappedCharacter", 14 },
		{ "OnSectBuildingClicked", 15 },
		{ "OnRecordEnterGame", 16 },
		{ "OnNewGameMonth", 17 },
		{ "OnCombatWithXiangshuMinionComplete", 18 },
		{ "OnBlackMaskAnimationComplete", 19 },
		{ "OnMakingSystemOpened", 20 },
		{ "OnCollectedMakingSystemItem", 21 },
		{ "OnSectSpecialBuildingClicked", 22 },
		{ "AnimalAvatarClicked", 23 },
		{ "MainStoryFinishCatchCricket", 24 },
		{ "LoadEventsFromPath", 25 },
		{ "NpcTombClicked", 26 },
		{ "SetLifeSkillSelectResult", 27 },
		{ "SetCombatSkillSelectResult", 28 },
		{ "OnLifeSkillCombatForceSilent", 29 },
		{ "TryMoveWhenMoveDisable", 30 },
		{ "TryMoveToInvalidLocationInTutorial", 31 },
		{ "SetCharacterSetSelectResult", 32 },
		{ "OnCharacterTemplateClicked", 33 },
		{ "CloseUI", 34 },
		{ "SetIsQuickStartGame", 35 },
		{ "TaiwuCollectWudangHeavenlyTreeSeed", 36 },
		{ "GetEventLogData", 37 },
		{ "StartNewDialog", 38 },
		{ "TaiwuVillagerExpelled", 39 },
		{ "GmCmd_TaiwuCrossArchive", 40 },
		{ "TaiwuCrossArchiveFindMemory", 41 },
		{ "UserLoadDreamBackArchive", 42 },
		{ "OperateInventoryItem", 43 },
		{ "SetItemSelectCount", 44 },
		{ "SettlementTreasuryBuildingClicked", 45 },
		{ "SetListenerEventActionISerializableArg", 46 },
		{ "SetListenerEventActionIntArg", 47 },
		{ "SetListenerEventActionBoolArg", 48 },
		{ "SetListenerEventActionStringArg", 49 },
		{ "GetValidInteractionEventOptions", 50 },
		{ "SetListenerEventActionIntListArg", 51 },
		{ "SetListenerEventActionItemKeyArg", 52 },
		{ "TriggerShixiangDrumEasterEgg", 53 },
		{ "InteractPrisoner", 54 },
		{ "OnClickedSendPrisonBtn", 55 },
		{ "OnClickedPrisonBtn", 56 },
		{ "SetCharacterMultSelectResult", 57 },
		{ "SetCricketBettingResult", 58 },
		{ "GetImplementedFunctionIds", 59 },
		{ "SetEventScriptExecutionPause", 60 },
		{ "EventScriptExecuteNext", 61 },
		{ "GmCmd_TaiwuWantedSectPunished", 62 },
		{ "EventSelectContinue", 63 },
		{ "SetSelectCount", 64 },
		{ "SetListenerEventActionShortListArg", 65 },
		{ "SetShowingEventShortListArg", 66 },
		{ "OnClickMapPickupEvent", 67 },
		{ "OnClickMapPickupNormalEvent", 68 },
		{ "OnClickDeportButton", 69 },
		{ "OnSwitchToGuardedPage", 70 },
		{ "GmCmd_AddJieqingMaskCharId", 71 },
		{ "GmCmd_RemoveJieqingMaskCharId", 72 },
		{ "EventCommonOptionSelect", 73 },
		{ "JumpToInteractionEventOption", 74 },
		{ "JumpToInteractionEventOptionByInteractionId", 75 },
		{ "OnTaiwuTryInvite", 76 },
		{ "ReloadConchShipEvents", 77 },
		{ "OnClickMapPickupBatchEvent", 78 },
		{ "GmCmd_GetGlobalArgBoxInt", 79 },
		{ "GmCmd_SetGlobalArgBoxInt", 80 },
		{ "CheckIsShowingEvent", 81 },
		{ "OnClickChickenCoop", 82 },
		{ "SetShowingEventItemKeyArg", 83 },
		{ "SetShowingEventShortArg", 84 },
		{ "OnEnterBuildingArea", 85 },
		{ "EventCommonOptionPreview", 86 },
		{ "GmCmd_TravelToPastTaiwuVillage", 87 },
		{ "GmCmd_BackFromPastTaiwuVillage", 88 },
		{ "EventCommonOptionHaveAvailableOption", 89 },
		{ "GmCmd_TriggerOvercomeCombatOver", 90 },
		{ "MeetTaiwu", 91 },
		{ "OnClickedXiangshuRetrieveDemonHeartBtn", 92 },
		{ "OnClickedXiangshuFinalBattleTiandiBtn", 93 },
		{ "UpdateShowingEventCharacterDisplayData", 94 }
	};

	public static readonly string[] MethodId2MethodName = new string[95]
	{
		"InitConchShipEvents", "TriggerListener", "SetItemSelectResult", "SetCharacterSelectResult", "SetSecretInformationSelectResult", "SetNormalInformationSelectResult", "StartHandleEventDuringAdvance", "GetTriggeredEventSummaryDisplayData", "SetEventInProcessing", "EventSelect",
		"GetEventDisplayData", "OnCharacterClicked", "OnLetTeammateLeaveGroup", "OnInteractCaravan", "OnInteractKidnappedCharacter", "OnSectBuildingClicked", "OnRecordEnterGame", "OnNewGameMonth", "OnCombatWithXiangshuMinionComplete", "OnBlackMaskAnimationComplete",
		"OnMakingSystemOpened", "OnCollectedMakingSystemItem", "OnSectSpecialBuildingClicked", "AnimalAvatarClicked", "MainStoryFinishCatchCricket", "LoadEventsFromPath", "NpcTombClicked", "SetLifeSkillSelectResult", "SetCombatSkillSelectResult", "OnLifeSkillCombatForceSilent",
		"TryMoveWhenMoveDisable", "TryMoveToInvalidLocationInTutorial", "SetCharacterSetSelectResult", "OnCharacterTemplateClicked", "CloseUI", "SetIsQuickStartGame", "TaiwuCollectWudangHeavenlyTreeSeed", "GetEventLogData", "StartNewDialog", "TaiwuVillagerExpelled",
		"GmCmd_TaiwuCrossArchive", "TaiwuCrossArchiveFindMemory", "UserLoadDreamBackArchive", "OperateInventoryItem", "SetItemSelectCount", "SettlementTreasuryBuildingClicked", "SetListenerEventActionISerializableArg", "SetListenerEventActionIntArg", "SetListenerEventActionBoolArg", "SetListenerEventActionStringArg",
		"GetValidInteractionEventOptions", "SetListenerEventActionIntListArg", "SetListenerEventActionItemKeyArg", "TriggerShixiangDrumEasterEgg", "InteractPrisoner", "OnClickedSendPrisonBtn", "OnClickedPrisonBtn", "SetCharacterMultSelectResult", "SetCricketBettingResult", "GetImplementedFunctionIds",
		"SetEventScriptExecutionPause", "EventScriptExecuteNext", "GmCmd_TaiwuWantedSectPunished", "EventSelectContinue", "SetSelectCount", "SetListenerEventActionShortListArg", "SetShowingEventShortListArg", "OnClickMapPickupEvent", "OnClickMapPickupNormalEvent", "OnClickDeportButton",
		"OnSwitchToGuardedPage", "GmCmd_AddJieqingMaskCharId", "GmCmd_RemoveJieqingMaskCharId", "EventCommonOptionSelect", "JumpToInteractionEventOption", "JumpToInteractionEventOptionByInteractionId", "OnTaiwuTryInvite", "ReloadConchShipEvents", "OnClickMapPickupBatchEvent", "GmCmd_GetGlobalArgBoxInt",
		"GmCmd_SetGlobalArgBoxInt", "CheckIsShowingEvent", "OnClickChickenCoop", "SetShowingEventItemKeyArg", "SetShowingEventShortArg", "OnEnterBuildingArea", "EventCommonOptionPreview", "GmCmd_TravelToPastTaiwuVillage", "GmCmd_BackFromPastTaiwuVillage", "EventCommonOptionHaveAvailableOption",
		"GmCmd_TriggerOvercomeCombatOver", "MeetTaiwu", "OnClickedXiangshuRetrieveDemonHeartBtn", "OnClickedXiangshuFinalBattleTiandiBtn", "UpdateShowingEventCharacterDisplayData"
	};
}
