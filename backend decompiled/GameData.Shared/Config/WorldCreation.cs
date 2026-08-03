using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldCreation : ConfigData<WorldCreationItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 人物的寿元
		/// </summary>
		public const byte CharacterLifeSpan = 0;

		/// <summary>
		/// 战斗的难度
		/// </summary>
		public const byte CombatDifficulty = 1;

		/// <summary>
		/// 研读的速度
		/// </summary>
		public const byte ReadingDifficulty = 2;

		/// <summary>
		/// 突破的难度
		/// </summary>
		public const byte BreakoutDifficulty = 3;

		/// <summary>
		/// 周天的速度
		/// </summary>
		public const byte NeigongLoopingDifficulty = 4;

		/// <summary>
		/// 外道的数量
		/// </summary>
		public const byte HereticsAmount = 5;

		/// <summary>
		/// 侵袭的速度
		/// </summary>
		public const byte BossInvasionSpeed = 6;

		/// <summary>
		/// 世界的资源
		/// </summary>
		public const byte WorldResourceAmount = 7;

		/// <summary>
		/// 世界的人数
		/// </summary>
		public const byte WorldPopulation = 8;

		/// <summary>
		/// 立场的限制
		/// </summary>
		public const byte RestrictOptionsBehavior = 9;

		/// <summary>
		/// 随机继承人
		/// </summary>
		public const byte AllowRandomTaiwuHeir = 10;

		/// <summary>
		/// 敌人的修习
		/// </summary>
		public const byte EnemyPracticeLevel = 11;

		/// <summary>
		/// 人情的变化
		/// </summary>
		public const byte FavorabilityChange = 12;

		/// <summary>
		/// 志向的成长
		/// </summary>
		public const byte ProfessionUpgrade = 13;

		/// <summary>
		/// 战利品收益
		/// </summary>
		public const byte LootYield = 14;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 人物的寿元
		/// </summary>
		public static WorldCreationItem CharacterLifeSpan => Instance[(byte)0];

		/// <summary>
		/// 战斗的难度
		/// </summary>
		public static WorldCreationItem CombatDifficulty => Instance[(byte)1];

		/// <summary>
		/// 研读的速度
		/// </summary>
		public static WorldCreationItem ReadingDifficulty => Instance[(byte)2];

		/// <summary>
		/// 突破的难度
		/// </summary>
		public static WorldCreationItem BreakoutDifficulty => Instance[(byte)3];

		/// <summary>
		/// 周天的速度
		/// </summary>
		public static WorldCreationItem NeigongLoopingDifficulty => Instance[(byte)4];

		/// <summary>
		/// 外道的数量
		/// </summary>
		public static WorldCreationItem HereticsAmount => Instance[(byte)5];

		/// <summary>
		/// 侵袭的速度
		/// </summary>
		public static WorldCreationItem BossInvasionSpeed => Instance[(byte)6];

		/// <summary>
		/// 世界的资源
		/// </summary>
		public static WorldCreationItem WorldResourceAmount => Instance[(byte)7];

		/// <summary>
		/// 世界的人数
		/// </summary>
		public static WorldCreationItem WorldPopulation => Instance[(byte)8];

		/// <summary>
		/// 立场的限制
		/// </summary>
		public static WorldCreationItem RestrictOptionsBehavior => Instance[(byte)9];

		/// <summary>
		/// 随机继承人
		/// </summary>
		public static WorldCreationItem AllowRandomTaiwuHeir => Instance[(byte)10];

		/// <summary>
		/// 敌人的修习
		/// </summary>
		public static WorldCreationItem EnemyPracticeLevel => Instance[(byte)11];

		/// <summary>
		/// 人情的变化
		/// </summary>
		public static WorldCreationItem FavorabilityChange => Instance[(byte)12];

		/// <summary>
		/// 志向的成长
		/// </summary>
		public static WorldCreationItem ProfessionUpgrade => Instance[(byte)13];

		/// <summary>
		/// 战利品收益
		/// </summary>
		public static WorldCreationItem LootYield => Instance[(byte)14];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static WorldCreation Instance = new WorldCreation();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "Options", "TemplateId", "Icons", "ShowInLegacy", "DifficultyPreset", "SaveFileKey" };

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new WorldCreationItem(0, LocalStringManager.GetConfig("WorldCreation_language", "Name_0"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_0"), new string[4] { "ui9_icon_worldcreation_0_0", "ui9_icon_worldcreation_0_1", "ui9_icon_worldcreation_0_2", "ui9_icon_worldcreation_0_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_0_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_0_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_0_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_0_3")
		}, new short[4] { 50, 75, 100, 125 }, new short[0], new short[0], showInLegacy: false, new sbyte[4] { 1, 1, 1, 1 }, new sbyte[0], "CharacterLifespanType"));
		_dataArray.Add(new WorldCreationItem(1, LocalStringManager.GetConfig("WorldCreation_language", "Name_1"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_1"), new string[4] { "ui9_icon_worldcreation_1_0", "ui9_icon_worldcreation_1_1", "ui9_icon_worldcreation_1_2", "ui9_icon_worldcreation_1_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_1_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_1_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_1_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_1_3")
		}, new short[0], new short[4] { 0, 10, 20, 40 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 2, 3, 5, 10 }, "CombatDifficulty"));
		_dataArray.Add(new WorldCreationItem(2, LocalStringManager.GetConfig("WorldCreation_language", "Name_2"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_2"), new string[4] { "ui9_icon_worldcreation_2_0", "ui9_icon_worldcreation_2_1", "ui9_icon_worldcreation_2_2", "ui9_icon_worldcreation_2_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_2_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_2_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_2_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_2_3")
		}, new short[4] { 200, 100, 75, 50 }, new short[4] { 0, 5, 10, 20 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "ReadingDifficulty"));
		_dataArray.Add(new WorldCreationItem(3, LocalStringManager.GetConfig("WorldCreation_language", "Name_3"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_3"), new string[4] { "ui9_icon_worldcreation_3_0", "ui9_icon_worldcreation_3_1", "ui9_icon_worldcreation_3_2", "ui9_icon_worldcreation_3_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_3_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_3_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_3_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_3_3")
		}, new short[4] { 20, 0, -10, -20 }, new short[4] { 0, 10, 20, 40 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "BreakoutDifficulty"));
		_dataArray.Add(new WorldCreationItem(4, LocalStringManager.GetConfig("WorldCreation_language", "Name_4"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_4"), new string[4] { "ui9_icon_worldcreation_4_0", "ui9_icon_worldcreation_4_1", "ui9_icon_worldcreation_4_2", "ui9_icon_worldcreation_4_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_4_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_4_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_4_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_4_3")
		}, new short[4] { 200, 100, 75, 50 }, new short[4] { 0, 5, 10, 20 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "NeigongLoopingDifficulty"));
		_dataArray.Add(new WorldCreationItem(5, LocalStringManager.GetConfig("WorldCreation_language", "Name_5"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_5"), new string[4] { "ui9_icon_worldcreation_5_0", "ui9_icon_worldcreation_5_1", "ui9_icon_worldcreation_5_2", "ui9_icon_worldcreation_5_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_5_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_5_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_5_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_5_3")
		}, new short[4] { 50, 75, 100, 200 }, new short[4] { 0, 5, 10, 20 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "HereticsAmountType"));
		_dataArray.Add(new WorldCreationItem(6, LocalStringManager.GetConfig("WorldCreation_language", "Name_6"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_6"), new string[4] { "ui9_icon_worldcreation_6_0", "ui9_icon_worldcreation_6_1", "ui9_icon_worldcreation_6_2", "ui9_icon_worldcreation_6_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_6_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_6_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_6_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_6_3")
		}, new short[4] { 120, 36, 24, 12 }, new short[4] { 0, 10, 20, 40 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 4, 5 }, "BossInvasionSpeedType"));
		_dataArray.Add(new WorldCreationItem(7, LocalStringManager.GetConfig("WorldCreation_language", "Name_7"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_7"), new string[4] { "ui9_icon_worldcreation_7_0", "ui9_icon_worldcreation_7_1", "ui9_icon_worldcreation_7_2", "ui9_icon_worldcreation_7_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_7_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_7_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_7_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_7_3")
		}, new short[4] { 4, 3, 2, 1 }, new short[4] { 0, 10, 20, 40 }, new short[4] { 150, 100, 50, 25 }, showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "WorldResourceAmountType"));
		_dataArray.Add(new WorldCreationItem(8, LocalStringManager.GetConfig("WorldCreation_language", "Name_8"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_8"), new string[4] { "ui9_icon_worldcreation_8_0", "ui9_icon_worldcreation_8_1", "ui9_icon_worldcreation_8_2", "ui9_icon_worldcreation_8_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_8_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_8_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_8_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_8_3")
		}, new short[4] { 100, 125, 150, 175 }, new short[0], new short[0], showInLegacy: false, new sbyte[4] { 1, 1, 1, 1 }, new sbyte[0], "WorldPopulation"));
		_dataArray.Add(new WorldCreationItem(9, LocalStringManager.GetConfig("WorldCreation_language", "Name_9"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_9"), new string[2] { "ui9_icon_worldcreation_9_0", "ui9_icon_worldcreation_9_1" }, new string[2]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_9_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_9_1")
		}, new short[0], new short[0], new short[0], showInLegacy: true, new sbyte[4] { 1, 1, 1, 1 }, new sbyte[0], "RestrictOptionsBehaviorType"));
		_dataArray.Add(new WorldCreationItem(10, LocalStringManager.GetConfig("WorldCreation_language", "Name_10"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_10"), new string[2] { "ui9_icon_worldcreation_10_0", "ui9_icon_worldcreation_10_1" }, new string[2]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_10_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_10_1")
		}, new short[0], new short[0], new short[0], showInLegacy: true, new sbyte[4] { 1, 1, 1, 1 }, new sbyte[0], "AllowRandomTaiwuHeir"));
		_dataArray.Add(new WorldCreationItem(11, LocalStringManager.GetConfig("WorldCreation_language", "Name_11"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_11"), new string[4] { "ui9_icon_worldcreation_11_0", "ui9_icon_worldcreation_11_1", "ui9_icon_worldcreation_11_2", "ui9_icon_worldcreation_11_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_11_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_11_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_11_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_11_3")
		}, new short[4] { 0, 1, 3, 5 }, new short[4] { 0, 5, 10, 20 }, new short[4] { 0, 20, 35, 50 }, showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 4, 8 }, "EnemyPracticeLevel"));
		_dataArray.Add(new WorldCreationItem(12, LocalStringManager.GetConfig("WorldCreation_language", "Name_12"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_12"), new string[4] { "ui9_icon_worldcreation_12_0", "ui9_icon_worldcreation_12_1", "ui9_icon_worldcreation_12_2", "ui9_icon_worldcreation_12_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_12_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_12_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_12_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_12_3")
		}, new short[4] { 100, 75, 50, 25 }, new short[4] { 0, 10, 20, 40 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "FavorabilityChange"));
		_dataArray.Add(new WorldCreationItem(13, LocalStringManager.GetConfig("WorldCreation_language", "Name_13"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_13"), new string[4] { "ui9_icon_worldcreation_13_0", "ui9_icon_worldcreation_13_1", "ui9_icon_worldcreation_13_2", "ui9_icon_worldcreation_13_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_13_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_13_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_13_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_13_3")
		}, new short[4] { 200, 100, 75, 50 }, new short[4] { 0, 10, 20, 40 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "ProfessionUpgrade"));
		_dataArray.Add(new WorldCreationItem(14, LocalStringManager.GetConfig("WorldCreation_language", "Name_14"), LocalStringManager.GetConfig("WorldCreation_language", "Desc_14"), new string[4] { "ui9_icon_worldcreation_14_0", "ui9_icon_worldcreation_14_1", "ui9_icon_worldcreation_14_2", "ui9_icon_worldcreation_14_3" }, new string[4]
		{
			LocalStringManager.GetConfig("WorldCreation_language", "Options_14_0"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_14_1"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_14_2"),
			LocalStringManager.GetConfig("WorldCreation_language", "Options_14_3")
		}, new short[4] { 200, 100, 50, 25 }, new short[4] { 0, 10, 20, 40 }, new short[0], showInLegacy: true, new sbyte[4] { 0, 1, 2, 3 }, new sbyte[4] { 1, 2, 3, 4 }, "LootYield"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WorldCreationItem>(15);
		CreateItems0();
	}
}
