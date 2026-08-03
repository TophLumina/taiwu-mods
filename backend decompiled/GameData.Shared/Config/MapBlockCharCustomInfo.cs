using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomInfo : ConfigData<MapBlockCharCustomInfoItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 年龄
		/// </summary>
		public const short Age = 0;

		/// <summary>
		/// 称号
		/// </summary>
		public const short Title = 1;

		/// <summary>
		/// 健康
		/// </summary>
		public const short Health = 2;

		/// <summary>
		/// 名誉
		/// </summary>
		public const short Fame = 3;

		/// <summary>
		/// 性别
		/// </summary>
		public const short Gender = 4;

		/// <summary>
		/// 从属
		/// </summary>
		public const short Organization = 5;

		/// <summary>
		/// 魅力
		/// </summary>
		public const short Charm = 6;

		/// <summary>
		/// 心情
		/// </summary>
		public const short Happiness = 7;

		/// <summary>
		/// 立场
		/// </summary>
		public const short BehaviorType = 8;

		/// <summary>
		/// 好感
		/// </summary>
		public const short Favorability = 9;

		/// <summary>
		/// 专属信息
		/// </summary>
		public const short Special = 10;

		/// <summary>
		/// 戒心
		/// </summary>
		public const short Jiexin = 11;

		/// <summary>
		/// 需求
		/// </summary>
		public const short Need = 12;

		/// <summary>
		/// 关系
		/// </summary>
		public const short Relation = 13;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 年龄
		/// </summary>
		public static MapBlockCharCustomInfoItem Age => Instance[(short)0];

		/// <summary>
		/// 称号
		/// </summary>
		public static MapBlockCharCustomInfoItem Title => Instance[(short)1];

		/// <summary>
		/// 健康
		/// </summary>
		public static MapBlockCharCustomInfoItem Health => Instance[(short)2];

		/// <summary>
		/// 名誉
		/// </summary>
		public static MapBlockCharCustomInfoItem Fame => Instance[(short)3];

		/// <summary>
		/// 性别
		/// </summary>
		public static MapBlockCharCustomInfoItem Gender => Instance[(short)4];

		/// <summary>
		/// 从属
		/// </summary>
		public static MapBlockCharCustomInfoItem Organization => Instance[(short)5];

		/// <summary>
		/// 魅力
		/// </summary>
		public static MapBlockCharCustomInfoItem Charm => Instance[(short)6];

		/// <summary>
		/// 心情
		/// </summary>
		public static MapBlockCharCustomInfoItem Happiness => Instance[(short)7];

		/// <summary>
		/// 立场
		/// </summary>
		public static MapBlockCharCustomInfoItem BehaviorType => Instance[(short)8];

		/// <summary>
		/// 好感
		/// </summary>
		public static MapBlockCharCustomInfoItem Favorability => Instance[(short)9];

		/// <summary>
		/// 专属信息
		/// </summary>
		public static MapBlockCharCustomInfoItem Special => Instance[(short)10];

		/// <summary>
		/// 戒心
		/// </summary>
		public static MapBlockCharCustomInfoItem Jiexin => Instance[(short)11];

		/// <summary>
		/// 需求
		/// </summary>
		public static MapBlockCharCustomInfoItem Need => Instance[(short)12];

		/// <summary>
		/// 关系
		/// </summary>
		public static MapBlockCharCustomInfoItem Relation => Instance[(short)13];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
