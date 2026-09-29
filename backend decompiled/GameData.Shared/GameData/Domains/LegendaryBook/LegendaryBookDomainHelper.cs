using System.Collections.Generic;

namespace GameData.Domains.LegendaryBook;

public static class LegendaryBookDomainHelper
{
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

	public const ushort DataCount = 13;

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

	public static readonly string[] DataId2FieldName = new string[13]
	{
		"BookOwners", "LegendaryBookOwnerData", "LegendaryBookShockedMonths", "PrevLegendaryBookOwnerCopies", "LegendaryBookConsumedCharIds", "ContestForLegendaryBookChars", "LegendaryBookHiddenCharIds", "FirstLegendaryBookDelay", "PreviousLegendaryBookOwners", "LegendaryBookSkillPresetSlot",
		"CurrentUnlockedPresetAmount", "CurrentUsingPresetIndex", "LegendaryBookWeaponPresetSlot"
	};

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[13][];

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
