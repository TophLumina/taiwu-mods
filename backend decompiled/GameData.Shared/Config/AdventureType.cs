using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureType : ConfigData<AdventureTypeItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte None = 0;

		public const sbyte MainStoryLine = 1;

		public const sbyte SectMainStoryLine = 2;

		public const sbyte Interaction = 3;

		public const sbyte HereticStronghold = 4;

		public const sbyte RighteousStronghold = 5;

		public const sbyte SeasonalEvent = 6;

		public const sbyte ContestForBride = 7;

		public const sbyte ContestForGroom = 8;

		public const sbyte MaterialResourceFood = 9;

		public const sbyte MaterialResourceWood = 10;

		public const sbyte MaterialResourceMetal = 11;

		public const sbyte MaterialRresourceJade = 12;

		public const sbyte MaterialResourceFabric = 13;

		public const sbyte MaterialResourceHerb = 14;

		public const sbyte SwordTomb = 15;

		public const sbyte InteractionOfLove = 16;

		public const sbyte LegendaryBook = 17;
	}

	public static class DefValue
	{
		public static AdventureTypeItem None => Instance[(sbyte)0];

		public static AdventureTypeItem MainStoryLine => Instance[(sbyte)1];

		public static AdventureTypeItem SectMainStoryLine => Instance[(sbyte)2];

		public static AdventureTypeItem Interaction => Instance[(sbyte)3];

		public static AdventureTypeItem HereticStronghold => Instance[(sbyte)4];

		public static AdventureTypeItem RighteousStronghold => Instance[(sbyte)5];

		public static AdventureTypeItem SeasonalEvent => Instance[(sbyte)6];

		public static AdventureTypeItem ContestForBride => Instance[(sbyte)7];

		public static AdventureTypeItem ContestForGroom => Instance[(sbyte)8];

		public static AdventureTypeItem MaterialResourceFood => Instance[(sbyte)9];

		public static AdventureTypeItem MaterialResourceWood => Instance[(sbyte)10];

		public static AdventureTypeItem MaterialResourceMetal => Instance[(sbyte)11];

		public static AdventureTypeItem MaterialRresourceJade => Instance[(sbyte)12];

		public static AdventureTypeItem MaterialResourceFabric => Instance[(sbyte)13];

		public static AdventureTypeItem MaterialResourceHerb => Instance[(sbyte)14];

		public static AdventureTypeItem SwordTomb => Instance[(sbyte)15];

		public static AdventureTypeItem InteractionOfLove => Instance[(sbyte)16];

		public static AdventureTypeItem LegendaryBook => Instance[(sbyte)17];
	}

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
