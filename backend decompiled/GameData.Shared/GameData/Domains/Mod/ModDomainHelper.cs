using System.Collections.Generic;

namespace GameData.Domains.Mod;

public static class ModDomainHelper
{
	public static class DataIds
	{
		public const ushort ArchiveModDataDict = 0;

		public const ushort NonArchiveModDataDict = 1;
	}

	public static class MethodIds
	{
		public const ushort SetInt = 0;

		public const ushort SetBool = 1;

		public const ushort SetString = 2;

		public const ushort SetSerializableModData = 3;

		public const ushort GetInt = 4;

		public const ushort GetBool = 5;

		public const ushort GetString = 6;

		public const ushort GetSerializableModData = 7;

		public const ushort UpdateModSettings = 8;

		public const ushort CallModMethod = 9;

		public const ushort CallModMethodWithParam = 10;

		public const ushort CallModMethodWithRet = 11;

		public const ushort CallModMethodWithParamAndRet = 12;
	}

	public const ushort DataCount = 2;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "ArchiveModDataDict", 0 },
		{ "NonArchiveModDataDict", 1 }
	};

	public static readonly string[] DataId2FieldName = new string[2] { "ArchiveModDataDict", "NonArchiveModDataDict" };

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[2][];

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "SetInt", 0 },
		{ "SetBool", 1 },
		{ "SetString", 2 },
		{ "SetSerializableModData", 3 },
		{ "GetInt", 4 },
		{ "GetBool", 5 },
		{ "GetString", 6 },
		{ "GetSerializableModData", 7 },
		{ "UpdateModSettings", 8 },
		{ "CallModMethod", 9 },
		{ "CallModMethodWithParam", 10 },
		{ "CallModMethodWithRet", 11 },
		{ "CallModMethodWithParamAndRet", 12 }
	};

	public static readonly string[] MethodId2MethodName = new string[13]
	{
		"SetInt", "SetBool", "SetString", "SetSerializableModData", "GetInt", "GetBool", "GetString", "GetSerializableModData", "UpdateModSettings", "CallModMethod",
		"CallModMethodWithParam", "CallModMethodWithRet", "CallModMethodWithParamAndRet"
	};
}
