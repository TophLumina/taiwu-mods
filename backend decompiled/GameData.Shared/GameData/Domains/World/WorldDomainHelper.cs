using System.Collections.Generic;

namespace GameData.Domains.World;

public static class WorldDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort WorldId = 0;

		public const ushort XiangshuProgress = 1;

		public const ushort XiangshuAvatarTaskStatuses = 2;

		public const ushort XiangshuAvatarTasksInOrder = 3;

		public const ushort MainStoryLineProgress = 4;

		public const ushort BeatRanChenZi = 5;

		public const ushort WorldFunctionsStatuses = 6;

		public const ushort CustomTexts = 7;

		public const ushort NextCustomTextId = 8;

		public const ushort InstantNotifications = 9;

		public const ushort OnHandingMonthlyEventBlock = 10;

		public const ushort LastMonthlyNotifications = 11;

		public const ushort WorldPopulationType = 12;

		public const ushort CharacterLifespanType = 13;

		public const ushort CombatDifficulty = 14;

		public const ushort HereticsAmountType = 15;

		public const ushort BossInvasionSpeedType = 16;

		public const ushort WorldResourceAmountType = 17;

		public const ushort AllowRandomTaiwuHeir = 18;

		public const ushort RestrictOptionsBehaviorType = 19;

		public const ushort TaiwuVillageStateTemplateId = 20;

		public const ushort TaiwuVillageLandFormType = 21;

		public const ushort HideTaiwuOriginalSurname = 22;

		public const ushort AllowExecute = 23;

		public const ushort ArchiveFilesBackupInterval = 24;

		public const ushort WorldStandardPopulation = 25;

		public const ushort CurrDate = 26;

		public const ushort DaysInCurrMonth = 27;

		public const ushort AdvancingMonthState = 28;

		public const ushort CurrTaskList = 29;

		public const ushort SortedTaskList = 30;

		public const ushort WorldStateData = 31;

		public const ushort ArchiveFilesBackupCount = 32;

		public const ushort SortedMonthlyNotificationSortingGroups = 33;

		public const ushort MonthlyEventLastTriggerDates = 34;

		public const ushort ProfessionUpgrade = 35;

		public const ushort CanResetWorldSettings = 36;

		public const ushort FavorabilityChange = 37;

		public const ushort EnemyPracticeLevel = 38;

		public const ushort LoopingDifficulty = 39;

		public const ushort BreakoutDifficulty = 40;

		public const ushort ReadingDifficulty = 41;

		public const ushort LootYield = 42;

		public const ushort BigEvents = 43;

		public const ushort StateWeathers = 44;

		public const ushort ExtraTriggeredTasks = 45;

		public const ushort TaskSortingOrder = 46;

		public const ushort PinnedOnTopTasks = 47;

		public const ushort WorldVersionInfo = 48;

		public const ushort NewfeatureTriggered = 49;

		public const ushort TaskFinishedDateList = 50;

		public const ushort ChallengeModeData = 51;

		public const ushort ExorcismEnabled = 52;

		public const ushort MonthNotifies = 53;

		public const ushort GameStatSaved = 54;

		public const ushort TriggeredGuidingChapterDictionary = 55;

		public const ushort PermanentMonthNotifies = 56;

		public const ushort AreaStoryWeathers = 57;

		public const ushort WaitForDecideChallengeModeIds = 58;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort CreateWorld = 0;

		public const ushort SetWorldCreationInfo = 1;

		public const ushort GetWorldCreationInfo = 2;

		public const ushort GetJuniorXiangshuLocations = 3;

		public const ushort HandleMonthlyEvent = 4;

		public const ushort GetMonthlyEventCollection = 5;

		public const ushort RemoveAllInvalidMonthlyEvents = 6;

		public const ushort ProcessAllMonthlyEventsWithDefaultOption = 7;

		public const ushort SpecifyWorldPopulationType = 8;

		public const ushort AdvanceDaysInMonth = 9;

		public const ushort AdvanceMonth = 10;

		public const ushort AdvanceMonth_DisplayedMonthlyNotifications = 11;

		public const ushort GmCmd_AddMonthlyEvent = 12;

		public const ushort GmCmd_AddSectJieqingNpcExtraLegacyPoints = 13;

		public const ushort SetTopTask = 14;

		public const ushort GmCmd_AddExtraTask = 15;

		public const ushort GmCmd_RemoveTriggeredExtraTask = 16;

		public const ushort GetAdvanceMonthSoftConditions = 17;

		public const ushort GmCmd_SetWorldFunctionUnlockHint = 18;

		public const ushort RequestWorldStateData = 19;

		public const ushort GmCmd_AddResetWorldSettingsChance = 20;

		public const ushort GetMonthNotifyDisplayData = 21;

		public const ushort TriggeredGuidingChapter = 22;

		public const ushort RequestSetStat = 23;

		public const ushort ResetStatsAndAchievements = 24;

		public const ushort GetNewestMonthNotifyDisplayData = 25;

		public const ushort GmCmd_SetAllGuidingChapter = 26;

		public const ushort OnClickDamageHugeSword = 27;

		public const ushort DecideNewChallengeMode = 28;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 59;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "WorldId", 0 },
		{ "XiangshuProgress", 1 },
		{ "XiangshuAvatarTaskStatuses", 2 },
		{ "XiangshuAvatarTasksInOrder", 3 },
		{ "MainStoryLineProgress", 4 },
		{ "BeatRanChenZi", 5 },
		{ "WorldFunctionsStatuses", 6 },
		{ "CustomTexts", 7 },
		{ "NextCustomTextId", 8 },
		{ "InstantNotifications", 9 },
		{ "OnHandingMonthlyEventBlock", 10 },
		{ "LastMonthlyNotifications", 11 },
		{ "WorldPopulationType", 12 },
		{ "CharacterLifespanType", 13 },
		{ "CombatDifficulty", 14 },
		{ "HereticsAmountType", 15 },
		{ "BossInvasionSpeedType", 16 },
		{ "WorldResourceAmountType", 17 },
		{ "AllowRandomTaiwuHeir", 18 },
		{ "RestrictOptionsBehaviorType", 19 },
		{ "TaiwuVillageStateTemplateId", 20 },
		{ "TaiwuVillageLandFormType", 21 },
		{ "HideTaiwuOriginalSurname", 22 },
		{ "AllowExecute", 23 },
		{ "ArchiveFilesBackupInterval", 24 },
		{ "WorldStandardPopulation", 25 },
		{ "CurrDate", 26 },
		{ "DaysInCurrMonth", 27 },
		{ "AdvancingMonthState", 28 },
		{ "CurrTaskList", 29 },
		{ "SortedTaskList", 30 },
		{ "WorldStateData", 31 },
		{ "ArchiveFilesBackupCount", 32 },
		{ "SortedMonthlyNotificationSortingGroups", 33 },
		{ "MonthlyEventLastTriggerDates", 34 },
		{ "ProfessionUpgrade", 35 },
		{ "CanResetWorldSettings", 36 },
		{ "FavorabilityChange", 37 },
		{ "EnemyPracticeLevel", 38 },
		{ "LoopingDifficulty", 39 },
		{ "BreakoutDifficulty", 40 },
		{ "ReadingDifficulty", 41 },
		{ "LootYield", 42 },
		{ "BigEvents", 43 },
		{ "StateWeathers", 44 },
		{ "ExtraTriggeredTasks", 45 },
		{ "TaskSortingOrder", 46 },
		{ "PinnedOnTopTasks", 47 },
		{ "WorldVersionInfo", 48 },
		{ "NewfeatureTriggered", 49 },
		{ "TaskFinishedDateList", 50 },
		{ "ChallengeModeData", 51 },
		{ "ExorcismEnabled", 52 },
		{ "MonthNotifies", 53 },
		{ "GameStatSaved", 54 },
		{ "TriggeredGuidingChapterDictionary", 55 },
		{ "PermanentMonthNotifies", 56 },
		{ "AreaStoryWeathers", 57 },
		{ "WaitForDecideChallengeModeIds", 58 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[59]
	{
		"WorldId", "XiangshuProgress", "XiangshuAvatarTaskStatuses", "XiangshuAvatarTasksInOrder", "MainStoryLineProgress", "BeatRanChenZi", "WorldFunctionsStatuses", "CustomTexts", "NextCustomTextId", "InstantNotifications",
		"OnHandingMonthlyEventBlock", "LastMonthlyNotifications", "WorldPopulationType", "CharacterLifespanType", "CombatDifficulty", "HereticsAmountType", "BossInvasionSpeedType", "WorldResourceAmountType", "AllowRandomTaiwuHeir", "RestrictOptionsBehaviorType",
		"TaiwuVillageStateTemplateId", "TaiwuVillageLandFormType", "HideTaiwuOriginalSurname", "AllowExecute", "ArchiveFilesBackupInterval", "WorldStandardPopulation", "CurrDate", "DaysInCurrMonth", "AdvancingMonthState", "CurrTaskList",
		"SortedTaskList", "WorldStateData", "ArchiveFilesBackupCount", "SortedMonthlyNotificationSortingGroups", "MonthlyEventLastTriggerDates", "ProfessionUpgrade", "CanResetWorldSettings", "FavorabilityChange", "EnemyPracticeLevel", "LoopingDifficulty",
		"BreakoutDifficulty", "ReadingDifficulty", "LootYield", "BigEvents", "StateWeathers", "ExtraTriggeredTasks", "TaskSortingOrder", "PinnedOnTopTasks", "WorldVersionInfo", "NewfeatureTriggered",
		"TaskFinishedDateList", "ChallengeModeData", "ExorcismEnabled", "MonthNotifies", "GameStatSaved", "TriggeredGuidingChapterDictionary", "PermanentMonthNotifies", "AreaStoryWeathers", "WaitForDecideChallengeModeIds"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[59][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "CreateWorld", 0 },
		{ "SetWorldCreationInfo", 1 },
		{ "GetWorldCreationInfo", 2 },
		{ "GetJuniorXiangshuLocations", 3 },
		{ "HandleMonthlyEvent", 4 },
		{ "GetMonthlyEventCollection", 5 },
		{ "RemoveAllInvalidMonthlyEvents", 6 },
		{ "ProcessAllMonthlyEventsWithDefaultOption", 7 },
		{ "SpecifyWorldPopulationType", 8 },
		{ "AdvanceDaysInMonth", 9 },
		{ "AdvanceMonth", 10 },
		{ "AdvanceMonth_DisplayedMonthlyNotifications", 11 },
		{ "GmCmd_AddMonthlyEvent", 12 },
		{ "GmCmd_AddSectJieqingNpcExtraLegacyPoints", 13 },
		{ "SetTopTask", 14 },
		{ "GmCmd_AddExtraTask", 15 },
		{ "GmCmd_RemoveTriggeredExtraTask", 16 },
		{ "GetAdvanceMonthSoftConditions", 17 },
		{ "GmCmd_SetWorldFunctionUnlockHint", 18 },
		{ "RequestWorldStateData", 19 },
		{ "GmCmd_AddResetWorldSettingsChance", 20 },
		{ "GetMonthNotifyDisplayData", 21 },
		{ "TriggeredGuidingChapter", 22 },
		{ "RequestSetStat", 23 },
		{ "ResetStatsAndAchievements", 24 },
		{ "GetNewestMonthNotifyDisplayData", 25 },
		{ "GmCmd_SetAllGuidingChapter", 26 },
		{ "OnClickDamageHugeSword", 27 },
		{ "DecideNewChallengeMode", 28 }
	};

	public static readonly string[] MethodId2MethodName = new string[29]
	{
		"CreateWorld", "SetWorldCreationInfo", "GetWorldCreationInfo", "GetJuniorXiangshuLocations", "HandleMonthlyEvent", "GetMonthlyEventCollection", "RemoveAllInvalidMonthlyEvents", "ProcessAllMonthlyEventsWithDefaultOption", "SpecifyWorldPopulationType", "AdvanceDaysInMonth",
		"AdvanceMonth", "AdvanceMonth_DisplayedMonthlyNotifications", "GmCmd_AddMonthlyEvent", "GmCmd_AddSectJieqingNpcExtraLegacyPoints", "SetTopTask", "GmCmd_AddExtraTask", "GmCmd_RemoveTriggeredExtraTask", "GetAdvanceMonthSoftConditions", "GmCmd_SetWorldFunctionUnlockHint", "RequestWorldStateData",
		"GmCmd_AddResetWorldSettingsChance", "GetMonthNotifyDisplayData", "TriggeredGuidingChapter", "RequestSetStat", "ResetStatsAndAchievements", "GetNewestMonthNotifyDisplayData", "GmCmd_SetAllGuidingChapter", "OnClickDamageHugeSword", "DecideNewChallengeMode"
	};
}
