using System.Collections.Generic;

namespace GameData.Domains.LifeRecord;

public static class LifeRecordDomainHelper
{
	public static class DataIds
	{
		public const ushort LifeRecord = 0;
	}

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

	public const ushort DataCount = 1;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort> { { "LifeRecord", 0 } };

	public static readonly string[] DataId2FieldName = new string[1] { "LifeRecord" };

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[1][];

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
