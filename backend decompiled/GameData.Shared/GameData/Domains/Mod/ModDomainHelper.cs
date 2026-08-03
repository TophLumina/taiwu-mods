using System.Collections.Generic;

namespace GameData.Domains.Mod;

public static class ModDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort ArchiveModDataDict = 0;

		public const ushort NonArchiveModDataDict = 1;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
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

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 2;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "ArchiveModDataDict", 0 },
		{ "NonArchiveModDataDict", 1 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[2] { "ArchiveModDataDict", "NonArchiveModDataDict" };

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[2][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
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
