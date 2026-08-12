using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent;

public static class TaiwuEventDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
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

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort GetMonthlyActionStateAndTime = 0;

		public const ushort InitConchShipEvents = 1;

		public const ushort TriggerListener = 2;

		public const ushort SetItemSelectResult = 3;

		public const ushort SetCharacterSelectResult = 4;

		public const ushort SetSecretInformationSelectResult = 5;

		public const ushort SetNormalInformationSelectResult = 6;

		public const ushort StartHandleEventDuringAdvance = 7;

		public const ushort GetTriggeredEventSummaryDisplayData = 8;

		public const ushort SetEventInProcessing = 9;

		public const ushort EventSelect = 10;

		public const ushort GetEventDisplayData = 11;

		public const ushort GmCmd_SaveMonthlyActionManager = 12;

		public const ushort OnCharacterClicked = 13;

		public const ushort OnLetTeammateLeaveGroup = 14;

		public const ushort OnInteractCaravan = 15;

		public const ushort OnInteractKidnappedCharacter = 16;

		public const ushort OnSectBuildingClicked = 17;

		public const ushort OnRecordEnterGame = 18;

		public const ushort OnNewGameMonth = 19;

		public const ushort OnCombatWithXiangshuMinionComplete = 20;

		public const ushort OnBlackMaskAnimationComplete = 21;

		public const ushort OnMakingSystemOpened = 22;

		public const ushort OnCollectedMakingSystemItem = 23;

		public const ushort OnSectSpecialBuildingClicked = 24;

		public const ushort AnimalAvatarClicked = 25;

		public const ushort MainStoryFinishCatchCricket = 26;

		public const ushort LoadEventsFromPath = 27;

		public const ushort NpcTombClicked = 28;

		public const ushort SetLifeSkillSelectResult = 29;

		public const ushort SetCombatSkillSelectResult = 30;

		public const ushort OnLifeSkillCombatForceSilent = 31;

		public const ushort TryMoveWhenMoveDisable = 32;

		public const ushort TryMoveToInvalidLocationInTutorial = 33;

		public const ushort SetCharacterSetSelectResult = 34;

		public const ushort OnCharacterTemplateClicked = 35;

		public const ushort CloseUI = 36;

		public const ushort SetIsQuickStartGame = 37;

		public const ushort TaiwuCollectWudangHeavenlyTreeSeed = 38;

		public const ushort GetEventLogData = 39;

		public const ushort StartNewDialog = 40;

		public const ushort TaiwuVillagerExpelled = 41;

		public const ushort GmCmd_TaiwuCrossArchive = 42;

		public const ushort TaiwuCrossArchiveFindMemory = 43;

		public const ushort UserLoadDreamBackArchive = 44;

		public const ushort OperateInventoryItem = 45;

		public const ushort SetItemSelectCount = 46;

		public const ushort SettlementTreasuryBuildingClicked = 47;

		public const ushort SetListenerEventActionISerializableArg = 48;

		public const ushort SetListenerEventActionIntArg = 49;

		public const ushort SetListenerEventActionBoolArg = 50;

		public const ushort SetListenerEventActionStringArg = 51;

		public const ushort GetValidInteractionEventOptions = 52;

		public const ushort SetListenerEventActionIntListArg = 53;

		public const ushort SetListenerEventActionItemKeyArg = 54;

		public const ushort TriggerShixiangDrumEasterEgg = 55;

		public const ushort InteractPrisoner = 56;

		public const ushort OnClickedSendPrisonBtn = 57;

		public const ushort OnClickedPrisonBtn = 58;

		public const ushort SetCharacterMultSelectResult = 59;

		public const ushort SetCricketBettingResult = 60;

		public const ushort GetImplementedFunctionIds = 61;

		public const ushort SetEventScriptExecutionPause = 62;

		public const ushort EventScriptExecuteNext = 63;

		public const ushort GmCmd_TaiwuWantedSectPunished = 64;

		public const ushort EventSelectContinue = 65;

		public const ushort SetSelectCount = 66;

		public const ushort SetListenerEventActionShortListArg = 67;

		public const ushort SetShowingEventShortListArg = 68;

		public const ushort OnClickMapPickupEvent = 69;

		public const ushort OnClickMapPickupNormalEvent = 70;

		public const ushort OnClickDeportButton = 71;

		public const ushort OnSwitchToGuardedPage = 72;

		public const ushort GmCmd_AddJieqingMaskCharId = 73;

		public const ushort GmCmd_RemoveJieqingMaskCharId = 74;

		public const ushort EventCommonOptionSelect = 75;

		public const ushort JumpToInteractionEventOption = 76;

		public const ushort JumpToInteractionEventOptionByInteractionId = 77;

		public const ushort OnTaiwuTryInvite = 78;

		public const ushort ReloadConchShipEvents = 79;

		public const ushort OnClickMapPickupBatchEvent = 80;

		public const ushort GmCmd_GetGlobalArgBoxInt = 81;

		public const ushort GmCmd_SetGlobalArgBoxInt = 82;

		public const ushort CheckIsShowingEvent = 83;

		public const ushort OnClickChickenCoop = 84;

		public const ushort SetShowingEventItemKeyArg = 85;

		public const ushort SetShowingEventShortArg = 86;

		public const ushort OnEnterBuildingArea = 87;

		public const ushort UpdateShowingEventTaiwuCharacterDisplayData = 88;

		public const ushort EventCommonOptionPreview = 89;

		public const ushort GmCmd_TravelToPastTaiwuVillage = 90;

		public const ushort GmCmd_BackFromPastTaiwuVillage = 91;

		public const ushort EventCommonOptionHaveAvailableOption = 92;

		public const ushort GmCmd_TriggerOvercomeCombatOver = 93;

		public const ushort MeetTaiwu = 94;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 30;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
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

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[30]
	{
		"GlobalArgBox", "MonthlyEventActionManager", "CgName", "NotifyData", "HasListeningEvent", "SelectInformationData", "TaiwuLocationChangeFlag", "SecretVillageOnFire", "TaiwuVillageShowShrine", "HideAllTeammates",
		"LeftRoleAlternativeName", "RightRoleAlternativeName", "RightRoleXiangshuDisplayData", "SelectCombatSkillData", "SelectLifeSkillData", "ItemListOfLeft", "ItemListOfRight", "ShowItemWithCricketBattleGuess", "DisplayingEventData", "TempCreateItemList",
		"CoverCricketJarGradeListForRight", "MarriageLook1CharIdList", "MarriageLook2CharIdList", "AllCombatGroupChars", "CricketBettingData", "JieqingMaskCharIdList", "HandledOneShotEvents", "HideAllMapBlockCharacters", "NeedToNotifyNewMonth", "CommonOptionPreviewEventOptionInfos"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[30][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetMonthlyActionStateAndTime", 0 },
		{ "InitConchShipEvents", 1 },
		{ "TriggerListener", 2 },
		{ "SetItemSelectResult", 3 },
		{ "SetCharacterSelectResult", 4 },
		{ "SetSecretInformationSelectResult", 5 },
		{ "SetNormalInformationSelectResult", 6 },
		{ "StartHandleEventDuringAdvance", 7 },
		{ "GetTriggeredEventSummaryDisplayData", 8 },
		{ "SetEventInProcessing", 9 },
		{ "EventSelect", 10 },
		{ "GetEventDisplayData", 11 },
		{ "GmCmd_SaveMonthlyActionManager", 12 },
		{ "OnCharacterClicked", 13 },
		{ "OnLetTeammateLeaveGroup", 14 },
		{ "OnInteractCaravan", 15 },
		{ "OnInteractKidnappedCharacter", 16 },
		{ "OnSectBuildingClicked", 17 },
		{ "OnRecordEnterGame", 18 },
		{ "OnNewGameMonth", 19 },
		{ "OnCombatWithXiangshuMinionComplete", 20 },
		{ "OnBlackMaskAnimationComplete", 21 },
		{ "OnMakingSystemOpened", 22 },
		{ "OnCollectedMakingSystemItem", 23 },
		{ "OnSectSpecialBuildingClicked", 24 },
		{ "AnimalAvatarClicked", 25 },
		{ "MainStoryFinishCatchCricket", 26 },
		{ "LoadEventsFromPath", 27 },
		{ "NpcTombClicked", 28 },
		{ "SetLifeSkillSelectResult", 29 },
		{ "SetCombatSkillSelectResult", 30 },
		{ "OnLifeSkillCombatForceSilent", 31 },
		{ "TryMoveWhenMoveDisable", 32 },
		{ "TryMoveToInvalidLocationInTutorial", 33 },
		{ "SetCharacterSetSelectResult", 34 },
		{ "OnCharacterTemplateClicked", 35 },
		{ "CloseUI", 36 },
		{ "SetIsQuickStartGame", 37 },
		{ "TaiwuCollectWudangHeavenlyTreeSeed", 38 },
		{ "GetEventLogData", 39 },
		{ "StartNewDialog", 40 },
		{ "TaiwuVillagerExpelled", 41 },
		{ "GmCmd_TaiwuCrossArchive", 42 },
		{ "TaiwuCrossArchiveFindMemory", 43 },
		{ "UserLoadDreamBackArchive", 44 },
		{ "OperateInventoryItem", 45 },
		{ "SetItemSelectCount", 46 },
		{ "SettlementTreasuryBuildingClicked", 47 },
		{ "SetListenerEventActionISerializableArg", 48 },
		{ "SetListenerEventActionIntArg", 49 },
		{ "SetListenerEventActionBoolArg", 50 },
		{ "SetListenerEventActionStringArg", 51 },
		{ "GetValidInteractionEventOptions", 52 },
		{ "SetListenerEventActionIntListArg", 53 },
		{ "SetListenerEventActionItemKeyArg", 54 },
		{ "TriggerShixiangDrumEasterEgg", 55 },
		{ "InteractPrisoner", 56 },
		{ "OnClickedSendPrisonBtn", 57 },
		{ "OnClickedPrisonBtn", 58 },
		{ "SetCharacterMultSelectResult", 59 },
		{ "SetCricketBettingResult", 60 },
		{ "GetImplementedFunctionIds", 61 },
		{ "SetEventScriptExecutionPause", 62 },
		{ "EventScriptExecuteNext", 63 },
		{ "GmCmd_TaiwuWantedSectPunished", 64 },
		{ "EventSelectContinue", 65 },
		{ "SetSelectCount", 66 },
		{ "SetListenerEventActionShortListArg", 67 },
		{ "SetShowingEventShortListArg", 68 },
		{ "OnClickMapPickupEvent", 69 },
		{ "OnClickMapPickupNormalEvent", 70 },
		{ "OnClickDeportButton", 71 },
		{ "OnSwitchToGuardedPage", 72 },
		{ "GmCmd_AddJieqingMaskCharId", 73 },
		{ "GmCmd_RemoveJieqingMaskCharId", 74 },
		{ "EventCommonOptionSelect", 75 },
		{ "JumpToInteractionEventOption", 76 },
		{ "JumpToInteractionEventOptionByInteractionId", 77 },
		{ "OnTaiwuTryInvite", 78 },
		{ "ReloadConchShipEvents", 79 },
		{ "OnClickMapPickupBatchEvent", 80 },
		{ "GmCmd_GetGlobalArgBoxInt", 81 },
		{ "GmCmd_SetGlobalArgBoxInt", 82 },
		{ "CheckIsShowingEvent", 83 },
		{ "OnClickChickenCoop", 84 },
		{ "SetShowingEventItemKeyArg", 85 },
		{ "SetShowingEventShortArg", 86 },
		{ "OnEnterBuildingArea", 87 },
		{ "UpdateShowingEventTaiwuCharacterDisplayData", 88 },
		{ "EventCommonOptionPreview", 89 },
		{ "GmCmd_TravelToPastTaiwuVillage", 90 },
		{ "GmCmd_BackFromPastTaiwuVillage", 91 },
		{ "EventCommonOptionHaveAvailableOption", 92 },
		{ "GmCmd_TriggerOvercomeCombatOver", 93 },
		{ "MeetTaiwu", 94 }
	};

	public static readonly string[] MethodId2MethodName = new string[95]
	{
		"GetMonthlyActionStateAndTime", "InitConchShipEvents", "TriggerListener", "SetItemSelectResult", "SetCharacterSelectResult", "SetSecretInformationSelectResult", "SetNormalInformationSelectResult", "StartHandleEventDuringAdvance", "GetTriggeredEventSummaryDisplayData", "SetEventInProcessing",
		"EventSelect", "GetEventDisplayData", "GmCmd_SaveMonthlyActionManager", "OnCharacterClicked", "OnLetTeammateLeaveGroup", "OnInteractCaravan", "OnInteractKidnappedCharacter", "OnSectBuildingClicked", "OnRecordEnterGame", "OnNewGameMonth",
		"OnCombatWithXiangshuMinionComplete", "OnBlackMaskAnimationComplete", "OnMakingSystemOpened", "OnCollectedMakingSystemItem", "OnSectSpecialBuildingClicked", "AnimalAvatarClicked", "MainStoryFinishCatchCricket", "LoadEventsFromPath", "NpcTombClicked", "SetLifeSkillSelectResult",
		"SetCombatSkillSelectResult", "OnLifeSkillCombatForceSilent", "TryMoveWhenMoveDisable", "TryMoveToInvalidLocationInTutorial", "SetCharacterSetSelectResult", "OnCharacterTemplateClicked", "CloseUI", "SetIsQuickStartGame", "TaiwuCollectWudangHeavenlyTreeSeed", "GetEventLogData",
		"StartNewDialog", "TaiwuVillagerExpelled", "GmCmd_TaiwuCrossArchive", "TaiwuCrossArchiveFindMemory", "UserLoadDreamBackArchive", "OperateInventoryItem", "SetItemSelectCount", "SettlementTreasuryBuildingClicked", "SetListenerEventActionISerializableArg", "SetListenerEventActionIntArg",
		"SetListenerEventActionBoolArg", "SetListenerEventActionStringArg", "GetValidInteractionEventOptions", "SetListenerEventActionIntListArg", "SetListenerEventActionItemKeyArg", "TriggerShixiangDrumEasterEgg", "InteractPrisoner", "OnClickedSendPrisonBtn", "OnClickedPrisonBtn", "SetCharacterMultSelectResult",
		"SetCricketBettingResult", "GetImplementedFunctionIds", "SetEventScriptExecutionPause", "EventScriptExecuteNext", "GmCmd_TaiwuWantedSectPunished", "EventSelectContinue", "SetSelectCount", "SetListenerEventActionShortListArg", "SetShowingEventShortListArg", "OnClickMapPickupEvent",
		"OnClickMapPickupNormalEvent", "OnClickDeportButton", "OnSwitchToGuardedPage", "GmCmd_AddJieqingMaskCharId", "GmCmd_RemoveJieqingMaskCharId", "EventCommonOptionSelect", "JumpToInteractionEventOption", "JumpToInteractionEventOptionByInteractionId", "OnTaiwuTryInvite", "ReloadConchShipEvents",
		"OnClickMapPickupBatchEvent", "GmCmd_GetGlobalArgBoxInt", "GmCmd_SetGlobalArgBoxInt", "CheckIsShowingEvent", "OnClickChickenCoop", "SetShowingEventItemKeyArg", "SetShowingEventShortArg", "OnEnterBuildingArea", "UpdateShowingEventTaiwuCharacterDisplayData", "EventCommonOptionPreview",
		"GmCmd_TravelToPastTaiwuVillage", "GmCmd_BackFromPastTaiwuVillage", "EventCommonOptionHaveAvailableOption", "GmCmd_TriggerOvercomeCombatOver", "MeetTaiwu"
	};
}
