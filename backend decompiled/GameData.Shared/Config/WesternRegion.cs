using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WesternRegion : ConfigData<WesternRegionItem, short>
{
	public static class DefKey
	{
		public const short Tibetan = 0;

		public const short Tintu = 1;

		public const short Persian = 2;

		public const short Rome = 3;

		public const short Greece = 4;

		public const short Turkic = 5;

		public const short Arab = 6;

		public const short Germanic = 7;

		public const short Viking = 8;
	}

	public static class DefValue
	{
		public static WesternRegionItem Tibetan => Instance[(short)0];

		public static WesternRegionItem Tintu => Instance[(short)1];

		public static WesternRegionItem Persian => Instance[(short)2];

		public static WesternRegionItem Rome => Instance[(short)3];

		public static WesternRegionItem Greece => Instance[(short)4];

		public static WesternRegionItem Turkic => Instance[(short)5];

		public static WesternRegionItem Arab => Instance[(short)6];

		public static WesternRegionItem Germanic => Instance[(short)7];

		public static WesternRegionItem Viking => Instance[(short)8];
	}

	public static WesternRegion Instance = new WesternRegion();

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
		_dataArray.Add(new WesternRegionItem(0, LocalStringManager.GetConfig("WesternRegion_language", "Name_0")));
		_dataArray.Add(new WesternRegionItem(1, LocalStringManager.GetConfig("WesternRegion_language", "Name_1")));
		_dataArray.Add(new WesternRegionItem(2, LocalStringManager.GetConfig("WesternRegion_language", "Name_2")));
		_dataArray.Add(new WesternRegionItem(3, LocalStringManager.GetConfig("WesternRegion_language", "Name_3")));
		_dataArray.Add(new WesternRegionItem(4, LocalStringManager.GetConfig("WesternRegion_language", "Name_4")));
		_dataArray.Add(new WesternRegionItem(5, LocalStringManager.GetConfig("WesternRegion_language", "Name_5")));
		_dataArray.Add(new WesternRegionItem(6, LocalStringManager.GetConfig("WesternRegion_language", "Name_6")));
		_dataArray.Add(new WesternRegionItem(7, LocalStringManager.GetConfig("WesternRegion_language", "Name_7")));
		_dataArray.Add(new WesternRegionItem(8, LocalStringManager.GetConfig("WesternRegion_language", "Name_8")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WesternRegionItem>(9);
		CreateItems0();
	}
}
