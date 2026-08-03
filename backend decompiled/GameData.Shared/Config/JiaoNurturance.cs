using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class JiaoNurturance : ConfigData<JiaoNurturanceItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 任其成长
		/// </summary>
		public const short NaturalGrowth = 0;

		/// <summary>
		/// 深潭药浴
		/// </summary>
		public const short MedicineBath = 1;

		/// <summary>
		/// 大口进食
		/// </summary>
		public const short Gourmet = 2;

		/// <summary>
		/// 猎牛牧虎
		/// </summary>
		public const short BeastHunting = 3;

		/// <summary>
		/// 增长灵性
		/// </summary>
		public const short SpiritualGrowth = 4;

		/// <summary>
		/// 协助伏魔
		/// </summary>
		public const short DevilHunting = 5;

		/// <summary>
		/// 妆饰财宝
		/// </summary>
		public const short Opulence = 6;

		/// <summary>
		/// 歌舞娱乐
		/// </summary>
		public const short Entertainment = 7;

		/// <summary>
		/// 通情识礼
		/// </summary>
		public const short Literacy = 8;

		/// <summary>
		/// 缠缚教习
		/// </summary>
		public const short WrapTeach = 9;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 任其成长
		/// </summary>
		public static JiaoNurturanceItem NaturalGrowth => Instance[(short)0];

		/// <summary>
		/// 深潭药浴
		/// </summary>
		public static JiaoNurturanceItem MedicineBath => Instance[(short)1];

		/// <summary>
		/// 大口进食
		/// </summary>
		public static JiaoNurturanceItem Gourmet => Instance[(short)2];

		/// <summary>
		/// 猎牛牧虎
		/// </summary>
		public static JiaoNurturanceItem BeastHunting => Instance[(short)3];

		/// <summary>
		/// 增长灵性
		/// </summary>
		public static JiaoNurturanceItem SpiritualGrowth => Instance[(short)4];

		/// <summary>
		/// 协助伏魔
		/// </summary>
		public static JiaoNurturanceItem DevilHunting => Instance[(short)5];

		/// <summary>
		/// 妆饰财宝
		/// </summary>
		public static JiaoNurturanceItem Opulence => Instance[(short)6];

		/// <summary>
		/// 歌舞娱乐
		/// </summary>
		public static JiaoNurturanceItem Entertainment => Instance[(short)7];

		/// <summary>
		/// 通情识礼
		/// </summary>
		public static JiaoNurturanceItem Literacy => Instance[(short)8];

		/// <summary>
		/// 缠缚教习
		/// </summary>
		public static JiaoNurturanceItem WrapTeach => Instance[(short)9];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static JiaoNurturance Instance = new JiaoNurturance();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "EventDesc", "ResourceCostType", "BasePropertyChange", "TemplateId", "NurturanceCostMonth", "NurturanceAnimation" };

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
		_dataArray.Add(new JiaoNurturanceItem(0, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_0"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_0"), -1, -1, 0, 18, new List<IntPair>(), 1, null));
		_dataArray.Add(new JiaoNurturanceItem(1, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_1"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_1"), 5, -1, 2000, 9, new List<IntPair>
		{
			new IntPair(0, 600)
		}, 3, "Loong_yaoyu"));
		_dataArray.Add(new JiaoNurturanceItem(2, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_2"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_2"), 0, -1, 2000, 9, new List<IntPair>
		{
			new IntPair(1, 270000)
		}, 3, "Loong_jinshi"));
		_dataArray.Add(new JiaoNurturanceItem(3, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_3"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_3"), 2, -1, 2000, 9, new List<IntPair>
		{
			new IntPair(4, 300)
		}, 3, "Loong_muhu"));
		_dataArray.Add(new JiaoNurturanceItem(4, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_4"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_4"), 3, -1, 2000, 9, new List<IntPair>
		{
			new IntPair(2, 2400)
		}, 3, "Loong_lingxing"));
		_dataArray.Add(new JiaoNurturanceItem(5, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_5"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_5"), -1, 5000, 5000, 9, new List<IntPair>
		{
			new IntPair(5, 1200)
		}, 3, "Loong_fumo"));
		_dataArray.Add(new JiaoNurturanceItem(6, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_6"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_6"), 6, -1, 10000, 12, new List<IntPair>
		{
			new IntPair(6, 2700000)
		}, 3, "Loong_caibao"));
		_dataArray.Add(new JiaoNurturanceItem(7, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_7"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_7"), 1, -1, 2000, 12, new List<IntPair>
		{
			new IntPair(7, 600)
		}, 3, "Loong_yule"));
		_dataArray.Add(new JiaoNurturanceItem(8, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_8"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_8"), 7, -1, 1000, 12, new List<IntPair>
		{
			new IntPair(8, 324000)
		}, 3, "Loong_shili"));
		_dataArray.Add(new JiaoNurturanceItem(9, LocalStringManager.GetConfig("JiaoNurturance_language", "Name_9"), LocalStringManager.GetConfig("JiaoNurturance_language", "EventDesc_9"), 4, -1, 2000, 9, new List<IntPair>
		{
			new IntPair(3, 2400)
		}, 3, "Loong_zhuabu"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<JiaoNurturanceItem>(10);
		CreateItems0();
	}
}
