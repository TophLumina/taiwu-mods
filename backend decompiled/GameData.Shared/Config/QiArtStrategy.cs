using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class QiArtStrategy : ConfigData<QiArtStrategyItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 祛虚还实
		/// </summary>
		public const sbyte ConcentrationGainAccordingToStrategies = 39;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 祛虚还实
		/// </summary>
		public static QiArtStrategyItem ConcentrationGainAccordingToStrategies => Instance[(sbyte)39];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static QiArtStrategy Instance = new QiArtStrategy();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "Dialog", "TemplateId", "Icon", "ExtractGroup", "ExtractWeight" };

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
		_dataArray.Add(new QiArtStrategyItem(0, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_0"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_0"), "qiartstrategy_icon_0", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_0"), 1, 4, 10, 3, 0, -1, -1, 100, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(1, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_1"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_1"), "qiartstrategy_icon_1", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_1"), 1, 4, 10, 3, 0, -1, -1, 0, 0, 100, 100, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(2, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_2"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_2"), "qiartstrategy_icon_2", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_2"), 1, 4, 10, 3, 0, -1, -1, 0, 0, 0, 0, 100, 100, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(3, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_3"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_3"), "qiartstrategy_icon_3", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_3"), 1, 2, 15, 3, 0, -1, -1, 50, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(4, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_4"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_4"), "qiartstrategy_icon_4", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_4"), 1, 2, 15, 3, 0, -1, -1, 0, 0, 50, 150, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(5, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_5"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_5"), "qiartstrategy_icon_5", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_5"), 1, 2, 15, 3, 0, -1, -1, 0, 0, 0, 0, 50, 150, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(6, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_6"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_6"), "qiartstrategy_icon_6", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_6"), 1, 1, 20, 6, 50, -1, -1, 200, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(7, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_7"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_7"), "qiartstrategy_icon_7", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_7"), 1, 1, 20, 6, 50, -1, -1, 0, 0, 200, 200, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(8, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_8"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_8"), "qiartstrategy_icon_8", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_8"), 1, 1, 20, 6, 50, -1, -1, 0, 0, 0, 0, 200, 200, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(9, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_9"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_9"), "qiartstrategy_icon_9", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_9"), 1, 4, 10, 3, 0, -1, -1, 0, 0, 0, 0, 0, 0, 50, 50, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(10, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_10"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_10"), "qiartstrategy_icon_10", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_10"), 1, 4, 10, 3, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 50, 50, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(11, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_11"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_11"), "qiartstrategy_icon_11", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_11"), 1, 4, 10, 3, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 50, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(12, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_12"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_12"), "qiartstrategy_icon_12", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_12"), 1, 2, 15, 3, 0, -1, -1, 0, 0, 0, 0, 0, 0, 30, 70, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(13, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_13"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_13"), "qiartstrategy_icon_13", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_13"), 1, 2, 15, 3, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 30, 70, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(14, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_14"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_14"), "qiartstrategy_icon_14", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_14"), 1, 2, 15, 3, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 70, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(15, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_15"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_15"), "qiartstrategy_icon_15", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_15"), 1, 1, 20, 6, 100, -1, -1, 0, 0, 0, 0, 0, 0, 100, 100, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(16, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_16"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_16"), "qiartstrategy_icon_16", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_16"), 1, 1, 20, 6, 100, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 100, 100, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(17, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_17"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_17"), "qiartstrategy_icon_17", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_17"), 1, 1, 20, 6, 100, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 100, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(18, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_18"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_18"), "qiartstrategy_icon_18", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_18"), 2, 1, 30, 9, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(19, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_19"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_19"), "qiartstrategy_icon_19", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_19"), 2, 1, 30, 9, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(20, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_20"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_20"), "qiartstrategy_icon_20", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_20"), 2, 1, 30, 9, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(21, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_21"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_21"), "qiartstrategy_icon_21", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_21"), 2, 1, 30, 9, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(22, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_22"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_22"), "qiartstrategy_icon_22", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_22"), 2, 1, 30, 9, 0, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(23, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_23"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_23"), "qiartstrategy_icon_23", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_23"), 2, 1, 30, 9, 0, 1, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(24, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_24"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_24"), "qiartstrategy_icon_24", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_24"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(25, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_25"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_25"), "qiartstrategy_icon_25", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_25"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(26, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_26"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_26"), "qiartstrategy_icon_26", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_26"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(27, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_27"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_27"), "qiartstrategy_icon_27", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_27"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(28, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_28"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_28"), "qiartstrategy_icon_28", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_28"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(29, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_29"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_29"), "qiartstrategy_icon_29", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_29"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(30, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_30"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_30"), "qiartstrategy_icon_30", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_30"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(31, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_31"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_31"), "qiartstrategy_icon_31", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_31"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(32, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_32"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_32"), "qiartstrategy_icon_32", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_32"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(33, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_33"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_33"), "qiartstrategy_icon_33", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_33"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 2, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(34, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_34"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_34"), "qiartstrategy_icon_34", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_34"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(35, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_35"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_35"), "qiartstrategy_icon_35", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_35"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(36, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_36"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_36"), "qiartstrategy_icon_36", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_36"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 2, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(37, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_37"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_37"), "qiartstrategy_icon_37", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_37"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 3, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(38, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_38"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_38"), "qiartstrategy_icon_38", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_38"), 2, 1, 20, 6, 25, 2, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, clearOtherEffect: false));
		_dataArray.Add(new QiArtStrategyItem(39, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_39"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_39"), "qiartstrategy_icon_39", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_39"), 2, 5, 0, 9, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: true));
		_dataArray.Add(new QiArtStrategyItem(40, LocalStringManager.GetConfig("QiArtStrategy_language", "Name_40"), LocalStringManager.GetConfig("QiArtStrategy_language", "Desc_40"), "qiartstrategy_icon_40", LocalStringManager.GetConfig("QiArtStrategy_language", "Dialog_40"), 2, 15, 20, 3, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, clearOtherEffect: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<QiArtStrategyItem>(41);
		CreateItems0();
	}
}
