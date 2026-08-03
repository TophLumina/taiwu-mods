using System.Collections.Generic;

namespace GameData.Domains.LegendaryBook;

public static class LegendaryBookDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort BookOwners = 0;

		public const ushort LegendaryBookOwnerData = 1;

		public const ushort LegendaryBookShockedMonths = 2;

		public const ushort PrevLegendaryBookOwnerCopies = 3;

		public const ushort LegendaryBookConsumedCharIds = 4;

		public const ushort ContestForLegendaryBookChars = 5;

		public const ushort LegendaryBookHiddenCharIds = 6;

		public const ushort FirstLegendaryBookDelay = 7;

		public const ushort PreviousLegendaryBookOwners = 8;

		public const ushort LegendaryBookSkillPresetSlot = 9;

		public const ushort CurrentUnlockedPresetAmount = 10;

		public const ushort CurrentUsingPresetIndex = 11;

		public const ushort LegendaryBookWeaponPresetSlot = 12;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort GmCmd_GetAllLegendaryBookStates = 0;

		public const ushort GmCmd_GiveAllTaiwuLegendaryBookToRandomNpc = 1;

		public const ushort GetLegendaryBookIncrementData = 2;

		public const ushort GetAllLegendaryBooksOwningState = 3;

		public const ushort GetLegendaryBookPresetDisplayData = 4;

		public const ushort AddLegendaryBookSkillEmptyPreset = 5;

		public const ushort DuplicateLegendaryBookSkillPreset = 6;

		public const ushort RemoveLegendaryBookSkillPreset = 7;

		public const ushort ResetLegendaryBookSkillPreset = 8;

		public const ushort SetLegendaryBookSkillPreset = 9;

		public const ushort SaveLegendaryBookSkillPresetSlotCurrent = 10;

		public const ushort ResetLegendaryBookBonus = 11;

		public const ushort SaveLegendaryBookWeaponPresetSlotCurrent = 12;

		public const ushort GmCmd_AddRandomLegendaryBookContestChar = 13;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 13;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "BookOwners", 0 },
		{ "LegendaryBookOwnerData", 1 },
		{ "LegendaryBookShockedMonths", 2 },
		{ "PrevLegendaryBookOwnerCopies", 3 },
		{ "LegendaryBookConsumedCharIds", 4 },
		{ "ContestForLegendaryBookChars", 5 },
		{ "LegendaryBookHiddenCharIds", 6 },
		{ "FirstLegendaryBookDelay", 7 },
		{ "PreviousLegendaryBookOwners", 8 },
		{ "LegendaryBookSkillPresetSlot", 9 },
		{ "CurrentUnlockedPresetAmount", 10 },
		{ "CurrentUsingPresetIndex", 11 },
		{ "LegendaryBookWeaponPresetSlot", 12 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[13]
	{
		"BookOwners", "LegendaryBookOwnerData", "LegendaryBookShockedMonths", "PrevLegendaryBookOwnerCopies", "LegendaryBookConsumedCharIds", "ContestForLegendaryBookChars", "LegendaryBookHiddenCharIds", "FirstLegendaryBookDelay", "PreviousLegendaryBookOwners", "LegendaryBookSkillPresetSlot",
		"CurrentUnlockedPresetAmount", "CurrentUsingPresetIndex", "LegendaryBookWeaponPresetSlot"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[13][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GmCmd_GetAllLegendaryBookStates", 0 },
		{ "GmCmd_GiveAllTaiwuLegendaryBookToRandomNpc", 1 },
		{ "GetLegendaryBookIncrementData", 2 },
		{ "GetAllLegendaryBooksOwningState", 3 },
		{ "GetLegendaryBookPresetDisplayData", 4 },
		{ "AddLegendaryBookSkillEmptyPreset", 5 },
		{ "DuplicateLegendaryBookSkillPreset", 6 },
		{ "RemoveLegendaryBookSkillPreset", 7 },
		{ "ResetLegendaryBookSkillPreset", 8 },
		{ "SetLegendaryBookSkillPreset", 9 },
		{ "SaveLegendaryBookSkillPresetSlotCurrent", 10 },
		{ "ResetLegendaryBookBonus", 11 },
		{ "SaveLegendaryBookWeaponPresetSlotCurrent", 12 },
		{ "GmCmd_AddRandomLegendaryBookContestChar", 13 }
	};

	public static readonly string[] MethodId2MethodName = new string[14]
	{
		"GmCmd_GetAllLegendaryBookStates", "GmCmd_GiveAllTaiwuLegendaryBookToRandomNpc", "GetLegendaryBookIncrementData", "GetAllLegendaryBooksOwningState", "GetLegendaryBookPresetDisplayData", "AddLegendaryBookSkillEmptyPreset", "DuplicateLegendaryBookSkillPreset", "RemoveLegendaryBookSkillPreset", "ResetLegendaryBookSkillPreset", "SetLegendaryBookSkillPreset",
		"SaveLegendaryBookSkillPresetSlotCurrent", "ResetLegendaryBookBonus", "SaveLegendaryBookWeaponPresetSlotCurrent", "GmCmd_AddRandomLegendaryBookContestChar"
	};
}
