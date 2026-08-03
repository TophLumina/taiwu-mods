using System.Collections.Generic;

namespace GameData.Domains.LifeRecord;

public static class LifeRecordDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort LifeRecord = 0;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort Get = 0;

		public const ushort GetByDate = 1;

		public const ushort GetLast = 2;

		public const ushort GetRelated = 3;

		public const ushort GetDead = 4;

		public const ushort GetRecordRenderInfoArguments = 5;

		public const ushort GetReversedRecord = 6;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 1;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort> { { "LifeRecord", 0 } };

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[1] { "LifeRecord" };

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[1][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "Get", 0 },
		{ "GetByDate", 1 },
		{ "GetLast", 2 },
		{ "GetRelated", 3 },
		{ "GetDead", 4 },
		{ "GetRecordRenderInfoArguments", 5 },
		{ "GetReversedRecord", 6 }
	};

	public static readonly string[] MethodId2MethodName = new string[7] { "Get", "GetByDate", "GetLast", "GetRelated", "GetDead", "GetRecordRenderInfoArguments", "GetReversedRecord" };
}
