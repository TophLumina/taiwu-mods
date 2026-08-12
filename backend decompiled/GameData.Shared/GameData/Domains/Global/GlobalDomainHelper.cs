using System.Collections.Generic;

namespace GameData.Domains.Global;

public static class GlobalDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort Global = 0;

		public const ushort LoadedAllArchiveData = 1;

		public const ushort SavingWorld = 2;

		public const ushort InscribedCharacters = 3;

		public const ushort GlobalFlags = 4;

		public const ushort OwnedChickens = 5;

		public const ushort CurrGameWorldType = 6;

		public const ushort InscribedCharacterPinOrders = 7;

		public const ushort Achievements = 8;

		public const ushort GameStats = 9;

		public const ushort CustomProtagonistPreset = 10;

		public const ushort LastTimeOpenAchievements = 11;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort EnterNewWorld = 0;

		public const ushort LoadWorld = 1;

		public const ushort LoadEnding = 2;

		public const ushort SaveWorld = 3;

		public const ushort LeaveWorld = 4;

		public const ushort GetArchivesInfo = 5;

		public const ushort DeleteArchive = 6;

		public const ushort InscribeCharacter = 7;

		public const ushort RemoveInscribedCharacter = 8;

		public const ushort SetGameBuildInfo = 9;

		public const ushort PackAllCrossArchiveGameData = 10;

		public const ushort SetGlobalFlag = 11;

		public const ushort GetGlobalFlag = 12;

		public const ushort CheckDriveSpace = 13;

		public const ushort UpdateSharedGlobalSettings = 14;

		public const ushort ReloadAllConfigData = 15;

		public const ushort SetCompressionType = 16;

		public const ushort EnterInGameGuideWorld = 17;

		public const ushort ExitInGameGuideWorld = 18;

		public const ushort EnterTutorialWorld = 19;

		public const ushort SetInscribedCharacterPinOrder = 20;

		public const ushort RemoveInscribedCharacterPinOrder = 21;

		public const ushort SetCustomProtagonistPreset = 22;

		public const ushort GetAchievementDisplayData = 23;

		public const ushort SetLastTimeOpenAchievements = 24;

		public const ushort InvokeGuidingTrigger = 25;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 12;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "Global", 0 },
		{ "LoadedAllArchiveData", 1 },
		{ "SavingWorld", 2 },
		{ "InscribedCharacters", 3 },
		{ "GlobalFlags", 4 },
		{ "OwnedChickens", 5 },
		{ "CurrGameWorldType", 6 },
		{ "InscribedCharacterPinOrders", 7 },
		{ "Achievements", 8 },
		{ "GameStats", 9 },
		{ "CustomProtagonistPreset", 10 },
		{ "LastTimeOpenAchievements", 11 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[12]
	{
		"Global", "LoadedAllArchiveData", "SavingWorld", "InscribedCharacters", "GlobalFlags", "OwnedChickens", "CurrGameWorldType", "InscribedCharacterPinOrders", "Achievements", "GameStats",
		"CustomProtagonistPreset", "LastTimeOpenAchievements"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[12][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "EnterNewWorld", 0 },
		{ "LoadWorld", 1 },
		{ "LoadEnding", 2 },
		{ "SaveWorld", 3 },
		{ "LeaveWorld", 4 },
		{ "GetArchivesInfo", 5 },
		{ "DeleteArchive", 6 },
		{ "InscribeCharacter", 7 },
		{ "RemoveInscribedCharacter", 8 },
		{ "SetGameBuildInfo", 9 },
		{ "PackAllCrossArchiveGameData", 10 },
		{ "SetGlobalFlag", 11 },
		{ "GetGlobalFlag", 12 },
		{ "CheckDriveSpace", 13 },
		{ "UpdateSharedGlobalSettings", 14 },
		{ "ReloadAllConfigData", 15 },
		{ "SetCompressionType", 16 },
		{ "EnterInGameGuideWorld", 17 },
		{ "ExitInGameGuideWorld", 18 },
		{ "EnterTutorialWorld", 19 },
		{ "SetInscribedCharacterPinOrder", 20 },
		{ "RemoveInscribedCharacterPinOrder", 21 },
		{ "SetCustomProtagonistPreset", 22 },
		{ "GetAchievementDisplayData", 23 },
		{ "SetLastTimeOpenAchievements", 24 },
		{ "InvokeGuidingTrigger", 25 }
	};

	public static readonly string[] MethodId2MethodName = new string[26]
	{
		"EnterNewWorld", "LoadWorld", "LoadEnding", "SaveWorld", "LeaveWorld", "GetArchivesInfo", "DeleteArchive", "InscribeCharacter", "RemoveInscribedCharacter", "SetGameBuildInfo",
		"PackAllCrossArchiveGameData", "SetGlobalFlag", "GetGlobalFlag", "CheckDriveSpace", "UpdateSharedGlobalSettings", "ReloadAllConfigData", "SetCompressionType", "EnterInGameGuideWorld", "ExitInGameGuideWorld", "EnterTutorialWorld",
		"SetInscribedCharacterPinOrder", "RemoveInscribedCharacterPinOrder", "SetCustomProtagonistPreset", "GetAchievementDisplayData", "SetLastTimeOpenAchievements", "InvokeGuidingTrigger"
	};
}
