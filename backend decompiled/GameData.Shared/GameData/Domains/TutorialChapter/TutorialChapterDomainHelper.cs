using System.Collections.Generic;

namespace GameData.Domains.TutorialChapter;

public static class TutorialChapterDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort CurProgress = 0;

		public const ushort TutorialChapter = 1;

		public const ushort GuidVideoName = 2;

		public const ushort NextForceLocation = 3;

		public const ushort NeiliAllocateFitChapter7 = 4;

		public const ushort HuanxinDying = 5;

		public const ushort HuanxinSurprised = 6;

		public const ushort TutorialFunctionStatuses = 7;

		public const ushort ForcePathIndex = 8;

		public const ushort GuidVideoTemplateId = 9;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort StartChapter = 0;

		public const ushort GetNextForceMoveToLocation = 1;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 10;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "CurProgress", 0 },
		{ "TutorialChapter", 1 },
		{ "GuidVideoName", 2 },
		{ "NextForceLocation", 3 },
		{ "NeiliAllocateFitChapter7", 4 },
		{ "HuanxinDying", 5 },
		{ "HuanxinSurprised", 6 },
		{ "TutorialFunctionStatuses", 7 },
		{ "ForcePathIndex", 8 },
		{ "GuidVideoTemplateId", 9 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[10] { "CurProgress", "TutorialChapter", "GuidVideoName", "NextForceLocation", "NeiliAllocateFitChapter7", "HuanxinDying", "HuanxinSurprised", "TutorialFunctionStatuses", "ForcePathIndex", "GuidVideoTemplateId" };

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[10][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "StartChapter", 0 },
		{ "GetNextForceMoveToLocation", 1 }
	};

	public static readonly string[] MethodId2MethodName = new string[2] { "StartChapter", "GetNextForceMoveToLocation" };
}
