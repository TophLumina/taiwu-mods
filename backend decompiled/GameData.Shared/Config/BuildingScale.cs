using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BuildingScale : ConfigData<BuildingScaleItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾村建设空间
		/// </summary>
		public const short BuildingSpace = 107;

		/// <summary>
		/// 太吾村石屋容量
		/// </summary>
		public const short StoneRoomCapacity = 108;

		/// <summary>
		/// 太吾村蛟池数量
		/// </summary>
		public const short JiaoPoolCount = 109;

		/// <summary>
		/// 饲槽重量上限
		/// </summary>
		public const short TroughLoad = 110;

		/// <summary>
		/// 祠堂收获威望
		/// </summary>
		public const short TaiwuShrineEffect = 111;

		/// <summary>
		/// 仓库重量上限
		/// </summary>
		public const short WareHouseLoad = 112;

		/// <summary>
		/// 居所居住空间
		/// </summary>
		public const short ResidenceCapacity = 113;

		/// <summary>
		/// 厢房容纳人数
		/// </summary>
		public const short ComfortableHouseCapacity = 114;

		/// <summary>
		/// 茶马帮货物栏位
		/// </summary>
		public const short TeaHorseCaravanSlot = 116;

		/// <summary>
		/// 凤凰台内息恢复
		/// </summary>
		public const short PhoenixPlatformPracticalEffect = 225;

		/// <summary>
		/// 方略室同道上限
		/// </summary>
		public const short StrategyRoomEffect = 226;

		/// <summary>
		/// 画影轩初见好感
		/// </summary>
		public const short MakeupRoomPercentEffect = 227;

		/// <summary>
		/// 生灭两星幡生平遗惠
		/// </summary>
		public const short BirthDeathStreamerEffect = 228;

		/// <summary>
		/// 丹房健康恢复
		/// </summary>
		public const short LifeElixirRoomEffect = 229;

		/// <summary>
		/// 阅经阁悟性消耗
		/// </summary>
		public const short SutraReadingRoomEffect = 230;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾村建设空间
		/// </summary>
		public static BuildingScaleItem BuildingSpace => Instance[(short)107];

		/// <summary>
		/// 太吾村石屋容量
		/// </summary>
		public static BuildingScaleItem StoneRoomCapacity => Instance[(short)108];

		/// <summary>
		/// 太吾村蛟池数量
		/// </summary>
		public static BuildingScaleItem JiaoPoolCount => Instance[(short)109];

		/// <summary>
		/// 饲槽重量上限
		/// </summary>
		public static BuildingScaleItem TroughLoad => Instance[(short)110];

		/// <summary>
		/// 祠堂收获威望
		/// </summary>
		public static BuildingScaleItem TaiwuShrineEffect => Instance[(short)111];

		/// <summary>
		/// 仓库重量上限
		/// </summary>
		public static BuildingScaleItem WareHouseLoad => Instance[(short)112];

		/// <summary>
		/// 居所居住空间
		/// </summary>
		public static BuildingScaleItem ResidenceCapacity => Instance[(short)113];

		/// <summary>
		/// 厢房容纳人数
		/// </summary>
		public static BuildingScaleItem ComfortableHouseCapacity => Instance[(short)114];

		/// <summary>
		/// 茶马帮货物栏位
		/// </summary>
		public static BuildingScaleItem TeaHorseCaravanSlot => Instance[(short)116];

		/// <summary>
		/// 凤凰台内息恢复
		/// </summary>
		public static BuildingScaleItem PhoenixPlatformPracticalEffect => Instance[(short)225];

		/// <summary>
		/// 方略室同道上限
		/// </summary>
		public static BuildingScaleItem StrategyRoomEffect => Instance[(short)226];

		/// <summary>
		/// 画影轩初见好感
		/// </summary>
		public static BuildingScaleItem MakeupRoomPercentEffect => Instance[(short)227];

		/// <summary>
		/// 生灭两星幡生平遗惠
		/// </summary>
		public static BuildingScaleItem BirthDeathStreamerEffect => Instance[(short)228];

		/// <summary>
		/// 丹房健康恢复
		/// </summary>
		public static BuildingScaleItem LifeElixirRoomEffect => Instance[(short)229];

		/// <summary>
		/// 阅经阁悟性消耗
		/// </summary>
		public static BuildingScaleItem SutraReadingRoomEffect => Instance[(short)230];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static BuildingScale Instance = new BuildingScale();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "Name", "CombatSkillType", "LifeSkillType", "ResourceType", "Formula", "TemplateId", "LevelEffect" };

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
		_dataArray.Add(new BuildingScaleItem(0, LocalStringManager.GetConfig("BuildingScale_language", "Desc_0"), LocalStringManager.GetConfig("BuildingScale_language", "Name_0"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(1, LocalStringManager.GetConfig("BuildingScale_language", "Desc_1"), LocalStringManager.GetConfig("BuildingScale_language", "Name_1"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(2, LocalStringManager.GetConfig("BuildingScale_language", "Desc_2"), LocalStringManager.GetConfig("BuildingScale_language", "Name_2"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(3, LocalStringManager.GetConfig("BuildingScale_language", "Desc_3"), LocalStringManager.GetConfig("BuildingScale_language", "Name_3"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(4, LocalStringManager.GetConfig("BuildingScale_language", "Desc_4"), LocalStringManager.GetConfig("BuildingScale_language", "Name_4"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(5, LocalStringManager.GetConfig("BuildingScale_language", "Desc_5"), LocalStringManager.GetConfig("BuildingScale_language", "Name_5"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(6, LocalStringManager.GetConfig("BuildingScale_language", "Desc_6"), LocalStringManager.GetConfig("BuildingScale_language", "Name_6"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(7, LocalStringManager.GetConfig("BuildingScale_language", "Desc_7"), LocalStringManager.GetConfig("BuildingScale_language", "Name_7"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(8, LocalStringManager.GetConfig("BuildingScale_language", "Desc_8"), LocalStringManager.GetConfig("BuildingScale_language", "Name_8"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(9, LocalStringManager.GetConfig("BuildingScale_language", "Desc_9"), LocalStringManager.GetConfig("BuildingScale_language", "Name_9"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(10, LocalStringManager.GetConfig("BuildingScale_language", "Desc_10"), LocalStringManager.GetConfig("BuildingScale_language", "Name_10"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(11, LocalStringManager.GetConfig("BuildingScale_language", "Desc_11"), LocalStringManager.GetConfig("BuildingScale_language", "Name_11"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(12, LocalStringManager.GetConfig("BuildingScale_language", "Desc_12"), LocalStringManager.GetConfig("BuildingScale_language", "Name_12"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(13, LocalStringManager.GetConfig("BuildingScale_language", "Desc_13"), LocalStringManager.GetConfig("BuildingScale_language", "Name_13"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(14, LocalStringManager.GetConfig("BuildingScale_language", "Desc_14"), LocalStringManager.GetConfig("BuildingScale_language", "Name_14"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(15, LocalStringManager.GetConfig("BuildingScale_language", "Desc_15"), LocalStringManager.GetConfig("BuildingScale_language", "Name_15"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(16, LocalStringManager.GetConfig("BuildingScale_language", "Desc_16"), LocalStringManager.GetConfig("BuildingScale_language", "Name_16"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(17, LocalStringManager.GetConfig("BuildingScale_language", "Desc_17"), LocalStringManager.GetConfig("BuildingScale_language", "Name_17"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(18, LocalStringManager.GetConfig("BuildingScale_language", "Desc_18"), LocalStringManager.GetConfig("BuildingScale_language", "Name_18"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(19, LocalStringManager.GetConfig("BuildingScale_language", "Desc_19"), LocalStringManager.GetConfig("BuildingScale_language", "Name_19"), EBuildingScaleClass.LevelEffect, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 32, 33, 34, 35, 36, 37, 38, 39, 40
		}));
		_dataArray.Add(new BuildingScaleItem(20, LocalStringManager.GetConfig("BuildingScale_language", "Desc_20"), LocalStringManager.GetConfig("BuildingScale_language", "Name_20"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 0, 13, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(21, LocalStringManager.GetConfig("BuildingScale_language", "Desc_21"), LocalStringManager.GetConfig("BuildingScale_language", "Name_21"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 2, 15, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(22, LocalStringManager.GetConfig("BuildingScale_language", "Desc_22"), LocalStringManager.GetConfig("BuildingScale_language", "Name_22"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 1, 17, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(23, LocalStringManager.GetConfig("BuildingScale_language", "Desc_23"), LocalStringManager.GetConfig("BuildingScale_language", "Name_23"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 2, 20, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(24, LocalStringManager.GetConfig("BuildingScale_language", "Desc_24"), LocalStringManager.GetConfig("BuildingScale_language", "Name_24"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 3, 20, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(25, LocalStringManager.GetConfig("BuildingScale_language", "Desc_25"), LocalStringManager.GetConfig("BuildingScale_language", "Name_25"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 5, 22, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(26, LocalStringManager.GetConfig("BuildingScale_language", "Desc_26"), LocalStringManager.GetConfig("BuildingScale_language", "Name_26"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 5, 24, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(27, LocalStringManager.GetConfig("BuildingScale_language", "Desc_27"), LocalStringManager.GetConfig("BuildingScale_language", "Name_27"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 4, 26, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(28, LocalStringManager.GetConfig("BuildingScale_language", "Desc_28"), LocalStringManager.GetConfig("BuildingScale_language", "Name_28"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 3, 29, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(29, LocalStringManager.GetConfig("BuildingScale_language", "Desc_29"), LocalStringManager.GetConfig("BuildingScale_language", "Name_29"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 0, 31, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(30, LocalStringManager.GetConfig("BuildingScale_language", "Desc_30"), LocalStringManager.GetConfig("BuildingScale_language", "Name_30"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 1, 31, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(31, LocalStringManager.GetConfig("BuildingScale_language", "Desc_31"), LocalStringManager.GetConfig("BuildingScale_language", "Name_31"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 0, 33, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(32, LocalStringManager.GetConfig("BuildingScale_language", "Desc_32"), LocalStringManager.GetConfig("BuildingScale_language", "Name_32"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 4, 33, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(33, LocalStringManager.GetConfig("BuildingScale_language", "Desc_33"), LocalStringManager.GetConfig("BuildingScale_language", "Name_33"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.MigrateSpeedBonusFactor, -1, -1, 0u, -1, 14, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(34, LocalStringManager.GetConfig("BuildingScale_language", "Desc_34"), LocalStringManager.GetConfig("BuildingScale_language", "Name_34"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 7, 16, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(35, LocalStringManager.GetConfig("BuildingScale_language", "Desc_35"), LocalStringManager.GetConfig("BuildingScale_language", "Name_35"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CollectResourceIncomeBonus, -1, -1, 0u, -1, 18, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(36, LocalStringManager.GetConfig("BuildingScale_language", "Desc_36"), LocalStringManager.GetConfig("BuildingScale_language", "Name_36"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CollectResourceGetItemBonus, -1, -1, 0u, -1, 19, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(37, LocalStringManager.GetConfig("BuildingScale_language", "Desc_37"), LocalStringManager.GetConfig("BuildingScale_language", "Name_37"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ProfessionSeniorityBonus, -1, -1, 0u, -1, 21, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(38, LocalStringManager.GetConfig("BuildingScale_language", "Desc_38"), LocalStringManager.GetConfig("BuildingScale_language", "Name_38"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.HealthDecreaseReduction, -1, -1, 0u, -1, 23, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(39, LocalStringManager.GetConfig("BuildingScale_language", "Desc_39"), LocalStringManager.GetConfig("BuildingScale_language", "Name_39"), EBuildingScaleClass.MemberExpIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, 25, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(40, LocalStringManager.GetConfig("BuildingScale_language", "Desc_40"), LocalStringManager.GetConfig("BuildingScale_language", "Name_40"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.FavorIncreaseBonus, -1, -1, 0u, -1, 27, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(41, LocalStringManager.GetConfig("BuildingScale_language", "Desc_41"), LocalStringManager.GetConfig("BuildingScale_language", "Name_41"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.FavorDecreaseReduction, -1, -1, 0u, -1, 28, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(42, LocalStringManager.GetConfig("BuildingScale_language", "Desc_42"), LocalStringManager.GetConfig("BuildingScale_language", "Name_42"), EBuildingScaleClass.MemberResourceIncome, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, 6, 30, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(43, LocalStringManager.GetConfig("BuildingScale_language", "Desc_43"), LocalStringManager.GetConfig("BuildingScale_language", "Name_43"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.MapResourceRegenBonus, -1, -1, 0u, -1, 32, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(44, LocalStringManager.GetConfig("BuildingScale_language", "Desc_44"), LocalStringManager.GetConfig("BuildingScale_language", "Name_44"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.AnimalProgressDelta, -1, -1, 0u, -1, 34, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(45, LocalStringManager.GetConfig("BuildingScale_language", "Desc_45"), LocalStringManager.GetConfig("BuildingScale_language", "Name_45"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopProgressBonus, -1, -1, 0u, -1, 35, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(46, LocalStringManager.GetConfig("BuildingScale_language", "Desc_46"), LocalStringManager.GetConfig("BuildingScale_language", "Name_46"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ArtisanOrderProgressBonus, -1, -1, 0u, -1, 36, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(47, LocalStringManager.GetConfig("BuildingScale_language", "Desc_47"), LocalStringManager.GetConfig("BuildingScale_language", "Name_47"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BuildingMaterialResourceIncomeBonus, -1, -1, 0u, -1, 37, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(48, LocalStringManager.GetConfig("BuildingScale_language", "Desc_48"), LocalStringManager.GetConfig("BuildingScale_language", "Name_48"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.BuildingSpaceBonus, -1, -1, 0u, -1, 38, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(49, LocalStringManager.GetConfig("BuildingScale_language", "Desc_49"), LocalStringManager.GetConfig("BuildingScale_language", "Name_49"), EBuildingScaleClass.Invalid, EBuildingScaleType.MovePoint, EBuildingScaleEffect.ActionPointRegenBonus, -1, -1, 0u, -1, 39, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(50, LocalStringManager.GetConfig("BuildingScale_language", "Desc_50"), LocalStringManager.GetConfig("BuildingScale_language", "Name_50"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BuildingAuthorityIncomeBonus, -1, -1, 0u, -1, 40, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(51, LocalStringManager.GetConfig("BuildingScale_language", "Desc_51"), LocalStringManager.GetConfig("BuildingScale_language", "Name_51"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BuildingMoneyIncomeBonus, -1, -1, 0u, -1, 41, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(52, LocalStringManager.GetConfig("BuildingScale_language", "Desc_52"), LocalStringManager.GetConfig("BuildingScale_language", "Name_52"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.CricketProgressDelta, -1, -1, 0u, -1, 42, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(53, LocalStringManager.GetConfig("BuildingScale_language", "Desc_53"), LocalStringManager.GetConfig("BuildingScale_language", "Name_53"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.AdventureProgressDelta, -1, -1, 0u, -1, 43, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(54, LocalStringManager.GetConfig("BuildingScale_language", "Desc_54"), LocalStringManager.GetConfig("BuildingScale_language", "Name_54"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.RecruitBonus, -1, -1, 0u, -1, 44, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(55, LocalStringManager.GetConfig("BuildingScale_language", "Desc_55"), LocalStringManager.GetConfig("BuildingScale_language", "Name_55"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(56, LocalStringManager.GetConfig("BuildingScale_language", "Desc_56"), LocalStringManager.GetConfig("BuildingScale_language", "Name_56"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(57, LocalStringManager.GetConfig("BuildingScale_language", "Desc_57"), LocalStringManager.GetConfig("BuildingScale_language", "Name_57"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(58, LocalStringManager.GetConfig("BuildingScale_language", "Desc_58"), LocalStringManager.GetConfig("BuildingScale_language", "Name_58"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(59, LocalStringManager.GetConfig("BuildingScale_language", "Desc_59"), LocalStringManager.GetConfig("BuildingScale_language", "Name_59"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new BuildingScaleItem(60, LocalStringManager.GetConfig("BuildingScale_language", "Desc_60"), LocalStringManager.GetConfig("BuildingScale_language", "Name_60"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(61, LocalStringManager.GetConfig("BuildingScale_language", "Desc_61"), LocalStringManager.GetConfig("BuildingScale_language", "Name_61"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(62, LocalStringManager.GetConfig("BuildingScale_language", "Desc_62"), LocalStringManager.GetConfig("BuildingScale_language", "Name_62"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(63, LocalStringManager.GetConfig("BuildingScale_language", "Desc_63"), LocalStringManager.GetConfig("BuildingScale_language", "Name_63"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(64, LocalStringManager.GetConfig("BuildingScale_language", "Desc_64"), LocalStringManager.GetConfig("BuildingScale_language", "Name_64"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(65, LocalStringManager.GetConfig("BuildingScale_language", "Desc_65"), LocalStringManager.GetConfig("BuildingScale_language", "Name_65"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(66, LocalStringManager.GetConfig("BuildingScale_language", "Desc_66"), LocalStringManager.GetConfig("BuildingScale_language", "Name_66"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(67, LocalStringManager.GetConfig("BuildingScale_language", "Desc_67"), LocalStringManager.GetConfig("BuildingScale_language", "Name_67"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(68, LocalStringManager.GetConfig("BuildingScale_language", "Desc_68"), LocalStringManager.GetConfig("BuildingScale_language", "Name_68"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(69, LocalStringManager.GetConfig("BuildingScale_language", "Desc_69"), LocalStringManager.GetConfig("BuildingScale_language", "Name_69"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(70, LocalStringManager.GetConfig("BuildingScale_language", "Desc_70"), LocalStringManager.GetConfig("BuildingScale_language", "Name_70"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(71, LocalStringManager.GetConfig("BuildingScale_language", "Desc_71"), LocalStringManager.GetConfig("BuildingScale_language", "Name_71"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(72, LocalStringManager.GetConfig("BuildingScale_language", "Desc_72"), LocalStringManager.GetConfig("BuildingScale_language", "Name_72"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(73, LocalStringManager.GetConfig("BuildingScale_language", "Desc_73"), LocalStringManager.GetConfig("BuildingScale_language", "Name_73"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(74, LocalStringManager.GetConfig("BuildingScale_language", "Desc_74"), LocalStringManager.GetConfig("BuildingScale_language", "Name_74"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(75, LocalStringManager.GetConfig("BuildingScale_language", "Desc_75"), LocalStringManager.GetConfig("BuildingScale_language", "Name_75"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(76, LocalStringManager.GetConfig("BuildingScale_language", "Desc_76"), LocalStringManager.GetConfig("BuildingScale_language", "Name_76"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(77, LocalStringManager.GetConfig("BuildingScale_language", "Desc_77"), LocalStringManager.GetConfig("BuildingScale_language", "Name_77"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(78, LocalStringManager.GetConfig("BuildingScale_language", "Desc_78"), LocalStringManager.GetConfig("BuildingScale_language", "Name_78"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.BreakOutSteps, -1, -1, 0u, -1, -1, new List<int> { 5 }));
		_dataArray.Add(new BuildingScaleItem(79, LocalStringManager.GetConfig("BuildingScale_language", "Desc_79"), LocalStringManager.GetConfig("BuildingScale_language", "Name_79"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 0, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(80, LocalStringManager.GetConfig("BuildingScale_language", "Desc_80"), LocalStringManager.GetConfig("BuildingScale_language", "Name_80"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 1, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(81, LocalStringManager.GetConfig("BuildingScale_language", "Desc_81"), LocalStringManager.GetConfig("BuildingScale_language", "Name_81"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 2, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(82, LocalStringManager.GetConfig("BuildingScale_language", "Desc_82"), LocalStringManager.GetConfig("BuildingScale_language", "Name_82"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 3, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(83, LocalStringManager.GetConfig("BuildingScale_language", "Desc_83"), LocalStringManager.GetConfig("BuildingScale_language", "Name_83"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 4, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(84, LocalStringManager.GetConfig("BuildingScale_language", "Desc_84"), LocalStringManager.GetConfig("BuildingScale_language", "Name_84"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 5, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(85, LocalStringManager.GetConfig("BuildingScale_language", "Desc_85"), LocalStringManager.GetConfig("BuildingScale_language", "Name_85"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 6, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(86, LocalStringManager.GetConfig("BuildingScale_language", "Desc_86"), LocalStringManager.GetConfig("BuildingScale_language", "Name_86"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 7, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(87, LocalStringManager.GetConfig("BuildingScale_language", "Desc_87"), LocalStringManager.GetConfig("BuildingScale_language", "Name_87"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 8, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(88, LocalStringManager.GetConfig("BuildingScale_language", "Desc_88"), LocalStringManager.GetConfig("BuildingScale_language", "Name_88"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 9, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(89, LocalStringManager.GetConfig("BuildingScale_language", "Desc_89"), LocalStringManager.GetConfig("BuildingScale_language", "Name_89"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 10, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(90, LocalStringManager.GetConfig("BuildingScale_language", "Desc_90"), LocalStringManager.GetConfig("BuildingScale_language", "Name_90"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 11, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(91, LocalStringManager.GetConfig("BuildingScale_language", "Desc_91"), LocalStringManager.GetConfig("BuildingScale_language", "Name_91"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 12, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(92, LocalStringManager.GetConfig("BuildingScale_language", "Desc_92"), LocalStringManager.GetConfig("BuildingScale_language", "Name_92"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.CombatSkillReadingSpeedBonusFactor, 13, -1, 0u, -1, 8, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(93, LocalStringManager.GetConfig("BuildingScale_language", "Desc_93"), LocalStringManager.GetConfig("BuildingScale_language", "Name_93"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 0, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(94, LocalStringManager.GetConfig("BuildingScale_language", "Desc_94"), LocalStringManager.GetConfig("BuildingScale_language", "Name_94"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 1, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(95, LocalStringManager.GetConfig("BuildingScale_language", "Desc_95"), LocalStringManager.GetConfig("BuildingScale_language", "Name_95"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 2, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(96, LocalStringManager.GetConfig("BuildingScale_language", "Desc_96"), LocalStringManager.GetConfig("BuildingScale_language", "Name_96"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 3, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(97, LocalStringManager.GetConfig("BuildingScale_language", "Desc_97"), LocalStringManager.GetConfig("BuildingScale_language", "Name_97"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 4, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(98, LocalStringManager.GetConfig("BuildingScale_language", "Desc_98"), LocalStringManager.GetConfig("BuildingScale_language", "Name_98"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 5, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(99, LocalStringManager.GetConfig("BuildingScale_language", "Desc_99"), LocalStringManager.GetConfig("BuildingScale_language", "Name_99"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 6, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(100, LocalStringManager.GetConfig("BuildingScale_language", "Desc_100"), LocalStringManager.GetConfig("BuildingScale_language", "Name_100"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 7, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(101, LocalStringManager.GetConfig("BuildingScale_language", "Desc_101"), LocalStringManager.GetConfig("BuildingScale_language", "Name_101"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 8, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(102, LocalStringManager.GetConfig("BuildingScale_language", "Desc_102"), LocalStringManager.GetConfig("BuildingScale_language", "Name_102"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 9, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(103, LocalStringManager.GetConfig("BuildingScale_language", "Desc_103"), LocalStringManager.GetConfig("BuildingScale_language", "Name_103"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 10, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(104, LocalStringManager.GetConfig("BuildingScale_language", "Desc_104"), LocalStringManager.GetConfig("BuildingScale_language", "Name_104"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 11, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(105, LocalStringManager.GetConfig("BuildingScale_language", "Desc_105"), LocalStringManager.GetConfig("BuildingScale_language", "Name_105"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 12, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(106, LocalStringManager.GetConfig("BuildingScale_language", "Desc_106"), LocalStringManager.GetConfig("BuildingScale_language", "Name_106"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.BreakOutSuccessRate, 13, -1, 0u, -1, -1, new List<int> { 30 }));
		_dataArray.Add(new BuildingScaleItem(107, LocalStringManager.GetConfig("BuildingScale_language", "Desc_107"), LocalStringManager.GetConfig("BuildingScale_language", "Name_107"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			33, 36, 39, 42, 45, 48, 51, 54, 57, 60,
			63, 66, 69, 72, 75
		}));
		_dataArray.Add(new BuildingScaleItem(108, LocalStringManager.GetConfig("BuildingScale_language", "Desc_108"), LocalStringManager.GetConfig("BuildingScale_language", "Name_108"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			25, 30, 35, 40, 45, 50, 55, 60, 65, 70,
			75, 80, 85, 90, 95
		}));
		_dataArray.Add(new BuildingScaleItem(109, LocalStringManager.GetConfig("BuildingScale_language", "Desc_109"), LocalStringManager.GetConfig("BuildingScale_language", "Name_109"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 2764950u, -1, -1, new List<int>
		{
			0, 2, 3, 3, 4, 4, 5, 5, 6, 6,
			7, 7, 8, 8, 9
		}));
		_dataArray.Add(new BuildingScaleItem(110, LocalStringManager.GetConfig("BuildingScale_language", "Desc_110"), LocalStringManager.GetConfig("BuildingScale_language", "Name_110"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(111, LocalStringManager.GetConfig("BuildingScale_language", "Desc_111"), LocalStringManager.GetConfig("BuildingScale_language", "Name_111"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, 7, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(112, LocalStringManager.GetConfig("BuildingScale_language", "Desc_112"), LocalStringManager.GetConfig("BuildingScale_language", "Name_112"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 50, 100, 150, 200, 250, 300, 350, 400, 450 }));
		_dataArray.Add(new BuildingScaleItem(113, LocalStringManager.GetConfig("BuildingScale_language", "Desc_113"), LocalStringManager.GetConfig("BuildingScale_language", "Name_113"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 7, 14, 21, 28, 35, 42, 49, 56, 63 }));
		_dataArray.Add(new BuildingScaleItem(114, LocalStringManager.GetConfig("BuildingScale_language", "Desc_114"), LocalStringManager.GetConfig("BuildingScale_language", "Name_114"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 1, 2, 3 }));
		_dataArray.Add(new BuildingScaleItem(115, LocalStringManager.GetConfig("BuildingScale_language", "Desc_115"), LocalStringManager.GetConfig("BuildingScale_language", "Name_115"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 1, 2, 3, 4, 5, 6 }));
		_dataArray.Add(new BuildingScaleItem(116, LocalStringManager.GetConfig("BuildingScale_language", "Desc_116"), LocalStringManager.GetConfig("BuildingScale_language", "Name_116"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int>
		{
			2, 4, 6, 8, 10, 12, 14, 16, 18, 20,
			22, 24, 26, 28, 30, 32, 34, 36, 38, 40
		}));
		_dataArray.Add(new BuildingScaleItem(117, LocalStringManager.GetConfig("BuildingScale_language", "Desc_117"), LocalStringManager.GetConfig("BuildingScale_language", "Name_117"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 0, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(118, LocalStringManager.GetConfig("BuildingScale_language", "Desc_118"), LocalStringManager.GetConfig("BuildingScale_language", "Name_118"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 1, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(119, LocalStringManager.GetConfig("BuildingScale_language", "Desc_119"), LocalStringManager.GetConfig("BuildingScale_language", "Name_119"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 2, 0u, -1, 9, new List<int>()));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new BuildingScaleItem(120, LocalStringManager.GetConfig("BuildingScale_language", "Desc_120"), LocalStringManager.GetConfig("BuildingScale_language", "Name_120"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 3, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(121, LocalStringManager.GetConfig("BuildingScale_language", "Desc_121"), LocalStringManager.GetConfig("BuildingScale_language", "Name_121"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 4, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(122, LocalStringManager.GetConfig("BuildingScale_language", "Desc_122"), LocalStringManager.GetConfig("BuildingScale_language", "Name_122"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 5, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(123, LocalStringManager.GetConfig("BuildingScale_language", "Desc_123"), LocalStringManager.GetConfig("BuildingScale_language", "Name_123"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 6, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(124, LocalStringManager.GetConfig("BuildingScale_language", "Desc_124"), LocalStringManager.GetConfig("BuildingScale_language", "Name_124"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 7, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(125, LocalStringManager.GetConfig("BuildingScale_language", "Desc_125"), LocalStringManager.GetConfig("BuildingScale_language", "Name_125"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 8, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(126, LocalStringManager.GetConfig("BuildingScale_language", "Desc_126"), LocalStringManager.GetConfig("BuildingScale_language", "Name_126"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 9, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(127, LocalStringManager.GetConfig("BuildingScale_language", "Desc_127"), LocalStringManager.GetConfig("BuildingScale_language", "Name_127"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 10, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(128, LocalStringManager.GetConfig("BuildingScale_language", "Desc_128"), LocalStringManager.GetConfig("BuildingScale_language", "Name_128"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 11, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(129, LocalStringManager.GetConfig("BuildingScale_language", "Desc_129"), LocalStringManager.GetConfig("BuildingScale_language", "Name_129"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 12, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(130, LocalStringManager.GetConfig("BuildingScale_language", "Desc_130"), LocalStringManager.GetConfig("BuildingScale_language", "Name_130"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 13, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(131, LocalStringManager.GetConfig("BuildingScale_language", "Desc_131"), LocalStringManager.GetConfig("BuildingScale_language", "Name_131"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 14, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(132, LocalStringManager.GetConfig("BuildingScale_language", "Desc_132"), LocalStringManager.GetConfig("BuildingScale_language", "Name_132"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LifeSkillReadingSpeedBonusFactor, -1, 15, 0u, -1, 9, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(133, LocalStringManager.GetConfig("BuildingScale_language", "Desc_133"), LocalStringManager.GetConfig("BuildingScale_language", "Name_133"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(134, LocalStringManager.GetConfig("BuildingScale_language", "Desc_134"), LocalStringManager.GetConfig("BuildingScale_language", "Name_134"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(135, LocalStringManager.GetConfig("BuildingScale_language", "Desc_135"), LocalStringManager.GetConfig("BuildingScale_language", "Name_135"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(136, LocalStringManager.GetConfig("BuildingScale_language", "Desc_136"), LocalStringManager.GetConfig("BuildingScale_language", "Name_136"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(137, LocalStringManager.GetConfig("BuildingScale_language", "Desc_137"), LocalStringManager.GetConfig("BuildingScale_language", "Name_137"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(138, LocalStringManager.GetConfig("BuildingScale_language", "Desc_138"), LocalStringManager.GetConfig("BuildingScale_language", "Name_138"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(139, LocalStringManager.GetConfig("BuildingScale_language", "Desc_139"), LocalStringManager.GetConfig("BuildingScale_language", "Name_139"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(140, LocalStringManager.GetConfig("BuildingScale_language", "Desc_140"), LocalStringManager.GetConfig("BuildingScale_language", "Name_140"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(141, LocalStringManager.GetConfig("BuildingScale_language", "Desc_141"), LocalStringManager.GetConfig("BuildingScale_language", "Name_141"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(142, LocalStringManager.GetConfig("BuildingScale_language", "Desc_142"), LocalStringManager.GetConfig("BuildingScale_language", "Name_142"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(143, LocalStringManager.GetConfig("BuildingScale_language", "Desc_143"), LocalStringManager.GetConfig("BuildingScale_language", "Name_143"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(144, LocalStringManager.GetConfig("BuildingScale_language", "Desc_144"), LocalStringManager.GetConfig("BuildingScale_language", "Name_144"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(145, LocalStringManager.GetConfig("BuildingScale_language", "Desc_145"), LocalStringManager.GetConfig("BuildingScale_language", "Name_145"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(146, LocalStringManager.GetConfig("BuildingScale_language", "Desc_146"), LocalStringManager.GetConfig("BuildingScale_language", "Name_146"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(147, LocalStringManager.GetConfig("BuildingScale_language", "Desc_147"), LocalStringManager.GetConfig("BuildingScale_language", "Name_147"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(148, LocalStringManager.GetConfig("BuildingScale_language", "Desc_148"), LocalStringManager.GetConfig("BuildingScale_language", "Name_148"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(149, LocalStringManager.GetConfig("BuildingScale_language", "Desc_149"), LocalStringManager.GetConfig("BuildingScale_language", "Name_149"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(150, LocalStringManager.GetConfig("BuildingScale_language", "Desc_150"), LocalStringManager.GetConfig("BuildingScale_language", "Name_150"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(151, LocalStringManager.GetConfig("BuildingScale_language", "Desc_151"), LocalStringManager.GetConfig("BuildingScale_language", "Name_151"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(152, LocalStringManager.GetConfig("BuildingScale_language", "Desc_152"), LocalStringManager.GetConfig("BuildingScale_language", "Name_152"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(153, LocalStringManager.GetConfig("BuildingScale_language", "Desc_153"), LocalStringManager.GetConfig("BuildingScale_language", "Name_153"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(154, LocalStringManager.GetConfig("BuildingScale_language", "Desc_154"), LocalStringManager.GetConfig("BuildingScale_language", "Name_154"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(155, LocalStringManager.GetConfig("BuildingScale_language", "Desc_155"), LocalStringManager.GetConfig("BuildingScale_language", "Name_155"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(156, LocalStringManager.GetConfig("BuildingScale_language", "Desc_156"), LocalStringManager.GetConfig("BuildingScale_language", "Name_156"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(157, LocalStringManager.GetConfig("BuildingScale_language", "Desc_157"), LocalStringManager.GetConfig("BuildingScale_language", "Name_157"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(158, LocalStringManager.GetConfig("BuildingScale_language", "Desc_158"), LocalStringManager.GetConfig("BuildingScale_language", "Name_158"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(159, LocalStringManager.GetConfig("BuildingScale_language", "Desc_159"), LocalStringManager.GetConfig("BuildingScale_language", "Name_159"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(160, LocalStringManager.GetConfig("BuildingScale_language", "Desc_160"), LocalStringManager.GetConfig("BuildingScale_language", "Name_160"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(161, LocalStringManager.GetConfig("BuildingScale_language", "Desc_161"), LocalStringManager.GetConfig("BuildingScale_language", "Name_161"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(162, LocalStringManager.GetConfig("BuildingScale_language", "Desc_162"), LocalStringManager.GetConfig("BuildingScale_language", "Name_162"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(163, LocalStringManager.GetConfig("BuildingScale_language", "Desc_163"), LocalStringManager.GetConfig("BuildingScale_language", "Name_163"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(164, LocalStringManager.GetConfig("BuildingScale_language", "Desc_164"), LocalStringManager.GetConfig("BuildingScale_language", "Name_164"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(165, LocalStringManager.GetConfig("BuildingScale_language", "Desc_165"), LocalStringManager.GetConfig("BuildingScale_language", "Name_165"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(166, LocalStringManager.GetConfig("BuildingScale_language", "Desc_166"), LocalStringManager.GetConfig("BuildingScale_language", "Name_166"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(167, LocalStringManager.GetConfig("BuildingScale_language", "Desc_167"), LocalStringManager.GetConfig("BuildingScale_language", "Name_167"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(168, LocalStringManager.GetConfig("BuildingScale_language", "Desc_168"), LocalStringManager.GetConfig("BuildingScale_language", "Name_168"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(169, LocalStringManager.GetConfig("BuildingScale_language", "Desc_169"), LocalStringManager.GetConfig("BuildingScale_language", "Name_169"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(170, LocalStringManager.GetConfig("BuildingScale_language", "Desc_170"), LocalStringManager.GetConfig("BuildingScale_language", "Name_170"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(171, LocalStringManager.GetConfig("BuildingScale_language", "Desc_171"), LocalStringManager.GetConfig("BuildingScale_language", "Name_171"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(172, LocalStringManager.GetConfig("BuildingScale_language", "Desc_172"), LocalStringManager.GetConfig("BuildingScale_language", "Name_172"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(173, LocalStringManager.GetConfig("BuildingScale_language", "Desc_173"), LocalStringManager.GetConfig("BuildingScale_language", "Name_173"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(174, LocalStringManager.GetConfig("BuildingScale_language", "Desc_174"), LocalStringManager.GetConfig("BuildingScale_language", "Name_174"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(175, LocalStringManager.GetConfig("BuildingScale_language", "Desc_175"), LocalStringManager.GetConfig("BuildingScale_language", "Name_175"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(176, LocalStringManager.GetConfig("BuildingScale_language", "Desc_176"), LocalStringManager.GetConfig("BuildingScale_language", "Name_176"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(177, LocalStringManager.GetConfig("BuildingScale_language", "Desc_177"), LocalStringManager.GetConfig("BuildingScale_language", "Name_177"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(178, LocalStringManager.GetConfig("BuildingScale_language", "Desc_178"), LocalStringManager.GetConfig("BuildingScale_language", "Name_178"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(179, LocalStringManager.GetConfig("BuildingScale_language", "Desc_179"), LocalStringManager.GetConfig("BuildingScale_language", "Name_179"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new BuildingScaleItem(180, LocalStringManager.GetConfig("BuildingScale_language", "Desc_180"), LocalStringManager.GetConfig("BuildingScale_language", "Name_180"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(181, LocalStringManager.GetConfig("BuildingScale_language", "Desc_181"), LocalStringManager.GetConfig("BuildingScale_language", "Name_181"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(182, LocalStringManager.GetConfig("BuildingScale_language", "Desc_182"), LocalStringManager.GetConfig("BuildingScale_language", "Name_182"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(183, LocalStringManager.GetConfig("BuildingScale_language", "Desc_183"), LocalStringManager.GetConfig("BuildingScale_language", "Name_183"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(184, LocalStringManager.GetConfig("BuildingScale_language", "Desc_184"), LocalStringManager.GetConfig("BuildingScale_language", "Name_184"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(185, LocalStringManager.GetConfig("BuildingScale_language", "Desc_185"), LocalStringManager.GetConfig("BuildingScale_language", "Name_185"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(186, LocalStringManager.GetConfig("BuildingScale_language", "Desc_186"), LocalStringManager.GetConfig("BuildingScale_language", "Name_186"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 0, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(187, LocalStringManager.GetConfig("BuildingScale_language", "Desc_187"), LocalStringManager.GetConfig("BuildingScale_language", "Name_187"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(188, LocalStringManager.GetConfig("BuildingScale_language", "Desc_188"), LocalStringManager.GetConfig("BuildingScale_language", "Name_188"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 2, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(189, LocalStringManager.GetConfig("BuildingScale_language", "Desc_189"), LocalStringManager.GetConfig("BuildingScale_language", "Name_189"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 3, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(190, LocalStringManager.GetConfig("BuildingScale_language", "Desc_190"), LocalStringManager.GetConfig("BuildingScale_language", "Name_190"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 4, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(191, LocalStringManager.GetConfig("BuildingScale_language", "Desc_191"), LocalStringManager.GetConfig("BuildingScale_language", "Name_191"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 5, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(192, LocalStringManager.GetConfig("BuildingScale_language", "Desc_192"), LocalStringManager.GetConfig("BuildingScale_language", "Name_192"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 6, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(193, LocalStringManager.GetConfig("BuildingScale_language", "Desc_193"), LocalStringManager.GetConfig("BuildingScale_language", "Name_193"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 7, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(194, LocalStringManager.GetConfig("BuildingScale_language", "Desc_194"), LocalStringManager.GetConfig("BuildingScale_language", "Name_194"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 8, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(195, LocalStringManager.GetConfig("BuildingScale_language", "Desc_195"), LocalStringManager.GetConfig("BuildingScale_language", "Name_195"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 9, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(196, LocalStringManager.GetConfig("BuildingScale_language", "Desc_196"), LocalStringManager.GetConfig("BuildingScale_language", "Name_196"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 10, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(197, LocalStringManager.GetConfig("BuildingScale_language", "Desc_197"), LocalStringManager.GetConfig("BuildingScale_language", "Name_197"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 11, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(198, LocalStringManager.GetConfig("BuildingScale_language", "Desc_198"), LocalStringManager.GetConfig("BuildingScale_language", "Name_198"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 12, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(199, LocalStringManager.GetConfig("BuildingScale_language", "Desc_199"), LocalStringManager.GetConfig("BuildingScale_language", "Name_199"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 13, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(200, LocalStringManager.GetConfig("BuildingScale_language", "Desc_200"), LocalStringManager.GetConfig("BuildingScale_language", "Name_200"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 14, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(201, LocalStringManager.GetConfig("BuildingScale_language", "Desc_201"), LocalStringManager.GetConfig("BuildingScale_language", "Name_201"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.ShopManagerQualificationImproveRate, -1, 15, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(202, LocalStringManager.GetConfig("BuildingScale_language", "Desc_202"), LocalStringManager.GetConfig("BuildingScale_language", "Name_202"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 0, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(203, LocalStringManager.GetConfig("BuildingScale_language", "Desc_203"), LocalStringManager.GetConfig("BuildingScale_language", "Name_203"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 1, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(204, LocalStringManager.GetConfig("BuildingScale_language", "Desc_204"), LocalStringManager.GetConfig("BuildingScale_language", "Name_204"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 2, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(205, LocalStringManager.GetConfig("BuildingScale_language", "Desc_205"), LocalStringManager.GetConfig("BuildingScale_language", "Name_205"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 3, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(206, LocalStringManager.GetConfig("BuildingScale_language", "Desc_206"), LocalStringManager.GetConfig("BuildingScale_language", "Name_206"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 4, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(207, LocalStringManager.GetConfig("BuildingScale_language", "Desc_207"), LocalStringManager.GetConfig("BuildingScale_language", "Name_207"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 5, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(208, LocalStringManager.GetConfig("BuildingScale_language", "Desc_208"), LocalStringManager.GetConfig("BuildingScale_language", "Name_208"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 6, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(209, LocalStringManager.GetConfig("BuildingScale_language", "Desc_209"), LocalStringManager.GetConfig("BuildingScale_language", "Name_209"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 7, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(210, LocalStringManager.GetConfig("BuildingScale_language", "Desc_210"), LocalStringManager.GetConfig("BuildingScale_language", "Name_210"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 8, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(211, LocalStringManager.GetConfig("BuildingScale_language", "Desc_211"), LocalStringManager.GetConfig("BuildingScale_language", "Name_211"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 9, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(212, LocalStringManager.GetConfig("BuildingScale_language", "Desc_212"), LocalStringManager.GetConfig("BuildingScale_language", "Name_212"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 10, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(213, LocalStringManager.GetConfig("BuildingScale_language", "Desc_213"), LocalStringManager.GetConfig("BuildingScale_language", "Name_213"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 11, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(214, LocalStringManager.GetConfig("BuildingScale_language", "Desc_214"), LocalStringManager.GetConfig("BuildingScale_language", "Name_214"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 12, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(215, LocalStringManager.GetConfig("BuildingScale_language", "Desc_215"), LocalStringManager.GetConfig("BuildingScale_language", "Name_215"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 13, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(216, LocalStringManager.GetConfig("BuildingScale_language", "Desc_216"), LocalStringManager.GetConfig("BuildingScale_language", "Name_216"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 14, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(217, LocalStringManager.GetConfig("BuildingScale_language", "Desc_217"), LocalStringManager.GetConfig("BuildingScale_language", "Name_217"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.LifeSkillAttainment, -1, 15, 0u, -1, -1, new List<int> { 100 }));
		_dataArray.Add(new BuildingScaleItem(218, LocalStringManager.GetConfig("BuildingScale_language", "Desc_218"), LocalStringManager.GetConfig("BuildingScale_language", "Name_218"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.MakeItemAttainmentRequirementReduction, -1, 6, 0u, -1, -1, new List<int> { 33 }));
		_dataArray.Add(new BuildingScaleItem(219, LocalStringManager.GetConfig("BuildingScale_language", "Desc_219"), LocalStringManager.GetConfig("BuildingScale_language", "Name_219"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.MakeItemAttainmentRequirementReduction, -1, 7, 0u, -1, -1, new List<int> { 33 }));
		_dataArray.Add(new BuildingScaleItem(220, LocalStringManager.GetConfig("BuildingScale_language", "Desc_220"), LocalStringManager.GetConfig("BuildingScale_language", "Name_220"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.MakeItemAttainmentRequirementReduction, -1, 8, 0u, -1, -1, new List<int> { 33 }));
		_dataArray.Add(new BuildingScaleItem(221, LocalStringManager.GetConfig("BuildingScale_language", "Desc_221"), LocalStringManager.GetConfig("BuildingScale_language", "Name_221"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.MakeItemAttainmentRequirementReduction, -1, 9, 0u, -1, -1, new List<int> { 33 }));
		_dataArray.Add(new BuildingScaleItem(222, LocalStringManager.GetConfig("BuildingScale_language", "Desc_222"), LocalStringManager.GetConfig("BuildingScale_language", "Name_222"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.MakeItemAttainmentRequirementReduction, -1, 10, 0u, -1, -1, new List<int> { 33 }));
		_dataArray.Add(new BuildingScaleItem(223, LocalStringManager.GetConfig("BuildingScale_language", "Desc_223"), LocalStringManager.GetConfig("BuildingScale_language", "Name_223"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.MakeItemAttainmentRequirementReduction, -1, 11, 0u, -1, -1, new List<int> { 33 }));
		_dataArray.Add(new BuildingScaleItem(224, LocalStringManager.GetConfig("BuildingScale_language", "Desc_224"), LocalStringManager.GetConfig("BuildingScale_language", "Name_224"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.MakeItemAttainmentRequirementReduction, -1, 14, 0u, -1, -1, new List<int> { 33 }));
		_dataArray.Add(new BuildingScaleItem(225, LocalStringManager.GetConfig("BuildingScale_language", "Desc_225"), LocalStringManager.GetConfig("BuildingScale_language", "Name_225"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.QiDisorderRecovery, -1, -1, 0u, -1, 0, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(226, LocalStringManager.GetConfig("BuildingScale_language", "Desc_226"), LocalStringManager.GetConfig("BuildingScale_language", "Name_226"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.TaiwuGroupMaxCount, -1, -1, 0u, -1, 1, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(227, LocalStringManager.GetConfig("BuildingScale_language", "Desc_227"), LocalStringManager.GetConfig("BuildingScale_language", "Name_227"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.InitialFavorability, -1, -1, 0u, -1, 3, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(228, LocalStringManager.GetConfig("BuildingScale_language", "Desc_228"), LocalStringManager.GetConfig("BuildingScale_language", "Name_228"), EBuildingScaleClass.Invalid, EBuildingScaleType.BonusPercentage, EBuildingScaleEffect.LegacyPointBonusFactor, -1, -1, 0u, -1, 4, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(229, LocalStringManager.GetConfig("BuildingScale_language", "Desc_229"), LocalStringManager.GetConfig("BuildingScale_language", "Name_229"), EBuildingScaleClass.Invalid, EBuildingScaleType.Int, EBuildingScaleEffect.HealthRecovery, -1, -1, 0u, -1, 6, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(230, LocalStringManager.GetConfig("BuildingScale_language", "Desc_230"), LocalStringManager.GetConfig("BuildingScale_language", "Name_230"), EBuildingScaleClass.Invalid, EBuildingScaleType.ReducePercentage, EBuildingScaleEffect.ReadingStrategyCost, -1, -1, 0u, -1, 5, new List<int>()));
		_dataArray.Add(new BuildingScaleItem(231, LocalStringManager.GetConfig("BuildingScale_language", "Desc_231"), LocalStringManager.GetConfig("BuildingScale_language", "Name_231"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(232, LocalStringManager.GetConfig("BuildingScale_language", "Desc_232"), LocalStringManager.GetConfig("BuildingScale_language", "Name_232"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(233, LocalStringManager.GetConfig("BuildingScale_language", "Desc_233"), LocalStringManager.GetConfig("BuildingScale_language", "Name_233"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(234, LocalStringManager.GetConfig("BuildingScale_language", "Desc_234"), LocalStringManager.GetConfig("BuildingScale_language", "Name_234"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(235, LocalStringManager.GetConfig("BuildingScale_language", "Desc_235"), LocalStringManager.GetConfig("BuildingScale_language", "Name_235"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(236, LocalStringManager.GetConfig("BuildingScale_language", "Desc_236"), LocalStringManager.GetConfig("BuildingScale_language", "Name_236"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(237, LocalStringManager.GetConfig("BuildingScale_language", "Desc_237"), LocalStringManager.GetConfig("BuildingScale_language", "Name_237"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(238, LocalStringManager.GetConfig("BuildingScale_language", "Desc_238"), LocalStringManager.GetConfig("BuildingScale_language", "Name_238"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(239, LocalStringManager.GetConfig("BuildingScale_language", "Desc_239"), LocalStringManager.GetConfig("BuildingScale_language", "Name_239"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new BuildingScaleItem(240, LocalStringManager.GetConfig("BuildingScale_language", "Desc_240"), LocalStringManager.GetConfig("BuildingScale_language", "Name_240"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(241, LocalStringManager.GetConfig("BuildingScale_language", "Desc_241"), LocalStringManager.GetConfig("BuildingScale_language", "Name_241"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(242, LocalStringManager.GetConfig("BuildingScale_language", "Desc_242"), LocalStringManager.GetConfig("BuildingScale_language", "Name_242"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(243, LocalStringManager.GetConfig("BuildingScale_language", "Desc_243"), LocalStringManager.GetConfig("BuildingScale_language", "Name_243"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(244, LocalStringManager.GetConfig("BuildingScale_language", "Desc_244"), LocalStringManager.GetConfig("BuildingScale_language", "Name_244"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 10 }));
		_dataArray.Add(new BuildingScaleItem(245, LocalStringManager.GetConfig("BuildingScale_language", "Desc_245"), LocalStringManager.GetConfig("BuildingScale_language", "Name_245"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(246, LocalStringManager.GetConfig("BuildingScale_language", "Desc_246"), LocalStringManager.GetConfig("BuildingScale_language", "Name_246"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
		_dataArray.Add(new BuildingScaleItem(247, LocalStringManager.GetConfig("BuildingScale_language", "Desc_247"), LocalStringManager.GetConfig("BuildingScale_language", "Name_247"), EBuildingScaleClass.Slot, EBuildingScaleType.Int, EBuildingScaleEffect.Invalid, -1, -1, 0u, -1, -1, new List<int> { 20 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BuildingScaleItem>(248);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
