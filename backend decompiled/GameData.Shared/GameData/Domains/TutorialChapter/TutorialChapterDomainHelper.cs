using System.Collections.Generic;

namespace GameData.Domains.TutorialChapter;

public static class TutorialChapterDomainHelper
{
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

	public static class MethodIds
	{
		public const ushort StartChapter = 0;

		public const ushort GetNextForceMoveToLocation = 1;
	}

	public const ushort DataCount = 10;

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

	public static readonly string[] DataId2FieldName = new string[10] { "CurProgress", "TutorialChapter", "GuidVideoName", "NextForceLocation", "NeiliAllocateFitChapter7", "HuanxinDying", "HuanxinSurprised", "TutorialFunctionStatuses", "ForcePathIndex", "GuidVideoTemplateId" };

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[10][];

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "StartChapter", 0 },
		{ "GetNextForceMoveToLocation", 1 }
	};

	public static readonly string[] MethodId2MethodName = new string[2] { "StartChapter", "GetNextForceMoveToLocation" };
}
