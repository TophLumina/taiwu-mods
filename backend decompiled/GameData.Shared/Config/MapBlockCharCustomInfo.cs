using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomInfo : ConfigData<MapBlockCharCustomInfoItem, short>
{
	public static class DefKey
	{
		public const short Age = 0;

		public const short Title = 1;

		public const short Health = 2;

		public const short Fame = 3;

		public const short Gender = 4;

		public const short Organization = 5;

		public const short Charm = 6;

		public const short Happiness = 7;

		public const short BehaviorType = 8;

		public const short Favorability = 9;

		public const short Special = 10;

		public const short Jiexin = 11;

		public const short Need = 12;

		public const short Relation = 13;
	}

	public static class DefValue
	{
		public static MapBlockCharCustomInfoItem Age => Instance[(short)0];

		public static MapBlockCharCustomInfoItem Title => Instance[(short)1];

		public static MapBlockCharCustomInfoItem Health => Instance[(short)2];

		public static MapBlockCharCustomInfoItem Fame => Instance[(short)3];

		public static MapBlockCharCustomInfoItem Gender => Instance[(short)4];

		public static MapBlockCharCustomInfoItem Organization => Instance[(short)5];

		public static MapBlockCharCustomInfoItem Charm => Instance[(short)6];

		public static MapBlockCharCustomInfoItem Happiness => Instance[(short)7];

		public static MapBlockCharCustomInfoItem BehaviorType => Instance[(short)8];

		public static MapBlockCharCustomInfoItem Favorability => Instance[(short)9];

		public static MapBlockCharCustomInfoItem Special => Instance[(short)10];

		public static MapBlockCharCustomInfoItem Jiexin => Instance[(short)11];

		public static MapBlockCharCustomInfoItem Need => Instance[(short)12];

		public static MapBlockCharCustomInfoItem Relation => Instance[(short)13];
	}

	public static MapBlockCharCustomInfo Instance = new MapBlockCharCustomInfo();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TipContent", "TemplateId" };

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
		_dataArray.Add(new MapBlockCharCustomInfoItem(0, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_0"), EMapBlockCharCustomInfoDisplayType.Text, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_0")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(1, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_1"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_1")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(2, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_2"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_2")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(3, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_3"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_3")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(4, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_4"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_4")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(5, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_5"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_5")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(6, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_6"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_6")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(7, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_7"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_7")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(8, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_8"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_8")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(9, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_9"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_9")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(10, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_10"), EMapBlockCharCustomInfoDisplayType.Text, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_10")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(11, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_11"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_11")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(12, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_12"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_12")));
		_dataArray.Add(new MapBlockCharCustomInfoItem(13, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "Name_13"), EMapBlockCharCustomInfoDisplayType.Icon, LocalStringManager.GetConfig("MapBlockCharCustomInfo_language", "TipContent_13")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapBlockCharCustomInfoItem>(14);
		CreateItems0();
	}
}
