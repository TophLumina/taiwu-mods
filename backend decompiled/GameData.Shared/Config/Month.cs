using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Month : ConfigData<MonthItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte January = 0;

		public const sbyte Feburary = 1;

		public const sbyte March = 2;

		public const sbyte April = 3;

		public const sbyte May = 4;

		public const sbyte June = 5;

		public const sbyte July = 6;

		public const sbyte Auguest = 7;

		public const sbyte September = 8;

		public const sbyte October = 9;

		public const sbyte November = 10;

		public const sbyte December = 11;
	}

	public static class DefValue
	{
		public static MonthItem January => Instance[(sbyte)0];

		public static MonthItem Feburary => Instance[(sbyte)1];

		public static MonthItem March => Instance[(sbyte)2];

		public static MonthItem April => Instance[(sbyte)3];

		public static MonthItem May => Instance[(sbyte)4];

		public static MonthItem June => Instance[(sbyte)5];

		public static MonthItem July => Instance[(sbyte)6];

		public static MonthItem Auguest => Instance[(sbyte)7];

		public static MonthItem September => Instance[(sbyte)8];

		public static MonthItem October => Instance[(sbyte)9];

		public static MonthItem November => Instance[(sbyte)10];

		public static MonthItem December => Instance[(sbyte)11];
	}

	public static Month Instance = new Month();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "RecoverResourceType", "FiveElementsTypeDesc", "RecoverBodyParts", "TemplateId", "Texture", "FiveElementsType" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new MonthItem(0, LocalStringManager.GetConfig("Month_language", "Name_0"), "tex_month_0", new List<sbyte> { 2, 3 }, 1, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_0"), new List<sbyte> { 0 }));
		_dataArray.Add(new MonthItem(1, LocalStringManager.GetConfig("Month_language", "Name_1"), "tex_month_1", new List<sbyte> { 0, 1, 5 }, 1, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_1"), new List<sbyte> { 1 }));
		_dataArray.Add(new MonthItem(2, LocalStringManager.GetConfig("Month_language", "Name_2"), "tex_month_2", new List<sbyte> { 0, 1, 5 }, 4, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_2"), new List<sbyte> { 3, 4 }));
		_dataArray.Add(new MonthItem(3, LocalStringManager.GetConfig("Month_language", "Name_3"), "tex_month_3", new List<sbyte> { 0, 1, 5 }, 3, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_3"), new List<sbyte> { 5, 6 }));
		_dataArray.Add(new MonthItem(4, LocalStringManager.GetConfig("Month_language", "Name_4"), "tex_month_4", new List<sbyte> { 1, 4 }, 3, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_4"), new List<sbyte>()));
		_dataArray.Add(new MonthItem(5, LocalStringManager.GetConfig("Month_language", "Name_5"), "tex_month_5", new List<sbyte> { 1, 4 }, 4, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_5"), new List<sbyte> { 2 }));
		_dataArray.Add(new MonthItem(6, LocalStringManager.GetConfig("Month_language", "Name_6"), "tex_month_6", new List<sbyte> { 1, 4 }, 0, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_6"), new List<sbyte> { 0 }));
		_dataArray.Add(new MonthItem(7, LocalStringManager.GetConfig("Month_language", "Name_7"), "tex_month_7", new List<sbyte> { 0, 4, 5 }, 0, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_7"), new List<sbyte> { 1 }));
		_dataArray.Add(new MonthItem(8, LocalStringManager.GetConfig("Month_language", "Name_8"), "tex_month_8", new List<sbyte> { 0, 4, 5 }, 4, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_8"), new List<sbyte> { 3, 4 }));
		_dataArray.Add(new MonthItem(9, LocalStringManager.GetConfig("Month_language", "Name_9"), "tex_month_9", new List<sbyte> { 0, 4, 5 }, 2, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_9"), new List<sbyte> { 5, 6 }));
		_dataArray.Add(new MonthItem(10, LocalStringManager.GetConfig("Month_language", "Name_10"), "tex_month_10", new List<sbyte> { 2, 3 }, 2, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_10"), new List<sbyte>()));
		_dataArray.Add(new MonthItem(11, LocalStringManager.GetConfig("Month_language", "Name_11"), "tex_month_11", new List<sbyte> { 2, 3 }, 4, LocalStringManager.GetConfig("Month_language", "FiveElementsTypeDesc_11"), new List<sbyte> { 2 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MonthItem>(12);
		CreateItems0();
	}
}
