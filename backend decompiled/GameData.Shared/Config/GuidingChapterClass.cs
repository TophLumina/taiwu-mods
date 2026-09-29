using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterClass : ConfigData<GuidingChapterClassItem, short>
{
	public static class DefKey
	{
		public const short Taiwu = 0;

		public const short World = 1;

		public const short InfluencePower = 2;

		public const short Sect = 3;

		public const short Character = 4;

		public const short Interact = 5;

		public const short Practice = 6;

		public const short Combat = 7;

		public const short Building = 8;

		public const short Item = 9;

		public const short Travel = 10;
	}

	public static class DefValue
	{
		public static GuidingChapterClassItem Taiwu => Instance[(short)0];

		public static GuidingChapterClassItem World => Instance[(short)1];

		public static GuidingChapterClassItem InfluencePower => Instance[(short)2];

		public static GuidingChapterClassItem Sect => Instance[(short)3];

		public static GuidingChapterClassItem Character => Instance[(short)4];

		public static GuidingChapterClassItem Interact => Instance[(short)5];

		public static GuidingChapterClassItem Practice => Instance[(short)6];

		public static GuidingChapterClassItem Combat => Instance[(short)7];

		public static GuidingChapterClassItem Building => Instance[(short)8];

		public static GuidingChapterClassItem Item => Instance[(short)9];

		public static GuidingChapterClassItem Travel => Instance[(short)10];
	}

	public static GuidingChapterClass Instance = new GuidingChapterClass();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new GuidingChapterClassItem(0, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_0")));
		_dataArray.Add(new GuidingChapterClassItem(1, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_1")));
		_dataArray.Add(new GuidingChapterClassItem(2, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_2")));
		_dataArray.Add(new GuidingChapterClassItem(3, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_3")));
		_dataArray.Add(new GuidingChapterClassItem(4, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_4")));
		_dataArray.Add(new GuidingChapterClassItem(5, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_5")));
		_dataArray.Add(new GuidingChapterClassItem(6, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_6")));
		_dataArray.Add(new GuidingChapterClassItem(7, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_7")));
		_dataArray.Add(new GuidingChapterClassItem(8, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_8")));
		_dataArray.Add(new GuidingChapterClassItem(9, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_9")));
		_dataArray.Add(new GuidingChapterClassItem(10, LocalStringManager.GetConfig("GuidingChapterClass_language", "Name_10")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<GuidingChapterClassItem>(11);
		CreateItems0();
	}
}
