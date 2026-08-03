using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ReadingStrategy : ConfigData<ReadingStrategyItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 照猫画虎
		/// </summary>
		public const sbyte DoubleCurrentPageStrategyAddValues = 4;

		/// <summary>
		/// 按图索骥
		/// </summary>
		public const sbyte DoubleCurrentPageStrategyEfficiencyChange = 5;

		/// <summary>
		/// 寻章摘句
		/// </summary>
		public const sbyte CostBookDurabilityToAddReadingProgress = 6;

		/// <summary>
		/// 含英咀华
		/// </summary>
		public const sbyte CostBookDurabilityToAddReadingEfficiency = 7;

		/// <summary>
		/// 春诵夏弦
		/// </summary>
		public const sbyte ReduceIntCostButNoExpGain = 12;

		/// <summary>
		/// 心领得间
		/// </summary>
		public const sbyte IntGainAccordingToStrategies = 14;

		/// <summary>
		/// 义父注解
		/// </summary>
		public const sbyte NotesByAdoptiveFather = 18;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 照猫画虎
		/// </summary>
		public static ReadingStrategyItem DoubleCurrentPageStrategyAddValues => Instance[(sbyte)4];

		/// <summary>
		/// 按图索骥
		/// </summary>
		public static ReadingStrategyItem DoubleCurrentPageStrategyEfficiencyChange => Instance[(sbyte)5];

		/// <summary>
		/// 寻章摘句
		/// </summary>
		public static ReadingStrategyItem CostBookDurabilityToAddReadingProgress => Instance[(sbyte)6];

		/// <summary>
		/// 含英咀华
		/// </summary>
		public static ReadingStrategyItem CostBookDurabilityToAddReadingEfficiency => Instance[(sbyte)7];

		/// <summary>
		/// 春诵夏弦
		/// </summary>
		public static ReadingStrategyItem ReduceIntCostButNoExpGain => Instance[(sbyte)12];

		/// <summary>
		/// 心领得间
		/// </summary>
		public static ReadingStrategyItem IntGainAccordingToStrategies => Instance[(sbyte)14];

		/// <summary>
		/// 义父注解
		/// </summary>
		public static ReadingStrategyItem NotesByAdoptiveFather => Instance[(sbyte)18];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static ReadingStrategy Instance = new ReadingStrategy();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "Dialog", "TemplateId" };

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
		_dataArray.Add(new ReadingStrategyItem(0, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_0"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_0"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_0"), 1, 4, 10, 3, 0, 20, 20, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(1, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_1"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_1"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_1"), 2, 4, 10, 3, 0, 0, 0, 60, 60, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(2, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_2"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_2"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_2"), 1, 2, 15, 3, 0, 10, 30, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(3, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_3"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_3"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_3"), 2, 2, 15, 3, 0, 0, 0, 45, 75, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(4, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_4"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_4"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_4"), 1, 1, 15, 6, 0, 0, 0, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(5, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_5"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_5"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_5"), 2, 1, 15, 6, 0, 0, 0, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(6, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_6"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_6"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_6"), 1, 1, 20, 9, 1, 40, 40, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(7, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_7"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_7"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_7"), 2, 1, 20, 9, 1, 0, 0, 90, 90, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(8, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_8"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_8"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_8"), 1, 1, 20, 3, 0, 0, 0, 0, 0, 15, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(9, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_9"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_9"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_9"), 2, 1, 20, 3, 0, 0, 0, 0, 0, 0, 25, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(10, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_10"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_10"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_10"), 1, 1, 25, 6, 0, 30, 30, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(11, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_11"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_11"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_11"), 2, 1, 25, 6, 0, 0, 0, 75, 75, 0, 0, 0, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(12, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_12"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_12"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_12"), 3, 4, 0, 6, 0, 0, 0, 0, 0, 0, 0, -10, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(13, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_13"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_13"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_13"), 3, 2, 10, 9, 0, 0, 0, 0, 0, 0, 0, -10, skipPage: false, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(14, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_14"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_14"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_14"), 3, 1, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: true));
		_dataArray.Add(new ReadingStrategyItem(15, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_15"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_15"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_15"), 3, 4, 20, 3, 0, 0, 0, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: true));
		_dataArray.Add(new ReadingStrategyItem(16, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_16"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_16"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_16"), 3, 2, 0, 12, 0, 0, 0, 0, 0, 0, -50, 0, skipPage: true, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(17, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_17"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_17"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_17"), 3, 1, 30, 3, 0, 0, 0, 0, 0, 0, 0, 0, skipPage: true, clearPageStrategies: false));
		_dataArray.Add(new ReadingStrategyItem(18, LocalStringManager.GetConfig("ReadingStrategy_language", "Name_18"), LocalStringManager.GetConfig("ReadingStrategy_language", "Desc_18"), LocalStringManager.GetConfig("ReadingStrategy_language", "Dialog_18"), 0, 0, 0, 99, 0, 100, 100, 0, 0, 0, 0, 0, skipPage: false, clearPageStrategies: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ReadingStrategyItem>(19);
		CreateItems0();
	}
}
