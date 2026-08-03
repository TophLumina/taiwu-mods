using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureType : ConfigData<AdventureTypeItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 未分类
		/// </summary>
		public const sbyte None = 0;

		/// <summary>
		/// 剧情奇遇
		/// </summary>
		public const sbyte MainStoryLine = 1;

		/// <summary>
		/// 地区主线
		/// </summary>
		public const sbyte SectMainStoryLine = 2;

		/// <summary>
		/// 互动奇遇
		/// </summary>
		public const sbyte Interaction = 3;

		/// <summary>
		/// 外道巢穴
		/// </summary>
		public const sbyte HereticStronghold = 4;

		/// <summary>
		/// 义士据点
		/// </summary>
		public const sbyte RighteousStronghold = 5;

		/// <summary>
		/// 四季奇遇
		/// </summary>
		public const sbyte SeasonalEvent = 6;

		/// <summary>
		/// 男版招亲
		/// </summary>
		public const sbyte ContestForBride = 7;

		/// <summary>
		/// 女版招亲
		/// </summary>
		public const sbyte ContestForGroom = 8;

		/// <summary>
		/// 天材地宝食材
		/// </summary>
		public const sbyte MaterialResourceFood = 9;

		/// <summary>
		/// 天材地宝木材
		/// </summary>
		public const sbyte MaterialResourceWood = 10;

		/// <summary>
		/// 天材地宝金铁
		/// </summary>
		public const sbyte MaterialResourceMetal = 11;

		/// <summary>
		/// 天材地宝玉石
		/// </summary>
		public const sbyte MaterialRresourceJade = 12;

		/// <summary>
		/// 天材地宝织物
		/// </summary>
		public const sbyte MaterialResourceFabric = 13;

		/// <summary>
		/// 天材地宝药材
		/// </summary>
		public const sbyte MaterialResourceHerb = 14;

		/// <summary>
		/// 剑冢
		/// </summary>
		public const sbyte SwordTomb = 15;

		/// <summary>
		/// 恋爱DLC奇遇
		/// </summary>
		public const sbyte InteractionOfLove = 16;

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public const sbyte LegendaryBook = 17;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 未分类
		/// </summary>
		public static AdventureTypeItem None => Instance[(sbyte)0];

		/// <summary>
		/// 剧情奇遇
		/// </summary>
		public static AdventureTypeItem MainStoryLine => Instance[(sbyte)1];

		/// <summary>
		/// 地区主线
		/// </summary>
		public static AdventureTypeItem SectMainStoryLine => Instance[(sbyte)2];

		/// <summary>
		/// 互动奇遇
		/// </summary>
		public static AdventureTypeItem Interaction => Instance[(sbyte)3];

		/// <summary>
		/// 外道巢穴
		/// </summary>
		public static AdventureTypeItem HereticStronghold => Instance[(sbyte)4];

		/// <summary>
		/// 义士据点
		/// </summary>
		public static AdventureTypeItem RighteousStronghold => Instance[(sbyte)5];

		/// <summary>
		/// 四季奇遇
		/// </summary>
		public static AdventureTypeItem SeasonalEvent => Instance[(sbyte)6];

		/// <summary>
		/// 男版招亲
		/// </summary>
		public static AdventureTypeItem ContestForBride => Instance[(sbyte)7];

		/// <summary>
		/// 女版招亲
		/// </summary>
		public static AdventureTypeItem ContestForGroom => Instance[(sbyte)8];

		/// <summary>
		/// 天材地宝食材
		/// </summary>
		public static AdventureTypeItem MaterialResourceFood => Instance[(sbyte)9];

		/// <summary>
		/// 天材地宝木材
		/// </summary>
		public static AdventureTypeItem MaterialResourceWood => Instance[(sbyte)10];

		/// <summary>
		/// 天材地宝金铁
		/// </summary>
		public static AdventureTypeItem MaterialResourceMetal => Instance[(sbyte)11];

		/// <summary>
		/// 天材地宝玉石
		/// </summary>
		public static AdventureTypeItem MaterialRresourceJade => Instance[(sbyte)12];

		/// <summary>
		/// 天材地宝织物
		/// </summary>
		public static AdventureTypeItem MaterialResourceFabric => Instance[(sbyte)13];

		/// <summary>
		/// 天材地宝药材
		/// </summary>
		public static AdventureTypeItem MaterialResourceHerb => Instance[(sbyte)14];

		/// <summary>
		/// 剑冢
		/// </summary>
		public static AdventureTypeItem SwordTomb => Instance[(sbyte)15];

		/// <summary>
		/// 恋爱DLC奇遇
		/// </summary>
		public static AdventureTypeItem InteractionOfLove => Instance[(sbyte)16];

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public static AdventureTypeItem LegendaryBook => Instance[(sbyte)17];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AdventureType Instance = new AdventureType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "DisplayName", "TemplateId", "ColorName" };

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
		_dataArray.Add(new AdventureTypeItem(0, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_0"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(1, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_1"), isTrivial: false, "mainstoryadventure"));
		_dataArray.Add(new AdventureTypeItem(2, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_2"), isTrivial: false, "sectstoryadventure"));
		_dataArray.Add(new AdventureTypeItem(3, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_3"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(4, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_4"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(5, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_5"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(6, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_6"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(7, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_7"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(8, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_8"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(9, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_9"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(10, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_10"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(11, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_11"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(12, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_12"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(13, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_13"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(14, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_14"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(15, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_15"), isTrivial: false, "swordtomb"));
		_dataArray.Add(new AdventureTypeItem(16, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_16"), isTrivial: true, "normaladventure"));
		_dataArray.Add(new AdventureTypeItem(17, LocalStringManager.GetConfig("AdventureType_language", "DisplayName_17"), isTrivial: true, "normaladventure"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureTypeItem>(18);
		CreateItems0();
	}
}
