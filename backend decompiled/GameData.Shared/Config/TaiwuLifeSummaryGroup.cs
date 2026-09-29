using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuLifeSummaryGroup : ConfigData<TaiwuLifeSummaryGroupItem, sbyte>
{
	public static TaiwuLifeSummaryGroup Instance = new TaiwuLifeSummaryGroup();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Type", "Items", "TemplateId", "Size" };

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
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(0, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_0"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 0 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(1, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_1"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 1 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(2, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_2"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 2 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(3, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_3"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 3 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(4, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_4"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 4 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(5, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_5"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 5 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(6, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_6"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 6 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(7, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_7"), 0, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 7 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(8, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_8"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 8 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(9, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_9"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 9 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(10, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_10"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 10 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(11, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_11"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 11 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(12, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_12"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 12 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(13, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_13"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 13 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(14, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_14"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 14 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(15, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_15"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 15 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(16, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_16"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 16 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(17, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_17"), 2, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 39 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(18, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_18"), 2, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 40 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(19, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_19"), 2, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 41 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(20, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_20"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 46 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(21, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_21"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 47 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(22, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_22"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 48 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(23, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_23"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 49 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(24, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_24"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 54 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(25, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_25"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 55 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(26, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_26"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 56 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(27, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_27"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 57 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(28, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_28"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 58 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(29, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_29"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 59 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(30, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_30"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 60 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(31, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_31"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 61 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(32, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_32"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 62 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(33, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_33"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 72 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(34, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_34"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 73 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(35, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_35"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 74 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(36, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_36"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 75 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(37, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_37"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 76 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(38, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_38"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 77 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(39, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_39"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 78 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(40, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_40"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 79 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(41, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_41"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 86 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(42, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_42"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 87 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(43, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_43"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 88 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(44, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_44"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 89 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(45, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_45"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 90 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(46, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_46"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 91 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(47, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_47"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 92 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(48, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_48"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 93 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(49, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_49"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 94 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(50, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_50"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 95 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(51, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_51"), 7, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 69 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(52, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_52"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 17 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(53, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_53"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 18 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(54, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_54"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 19 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(55, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_55"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 20 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(56, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_56"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 21 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(57, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_57"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 22 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(58, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_58"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 23 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(59, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_59"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 24 }));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(60, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_60"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 25 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(61, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_61"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 26 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(62, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_62"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 27 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(63, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_63"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 28 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(64, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_64"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 29 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(65, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_65"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 30 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(66, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_66"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 31 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(67, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_67"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 32 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(68, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_68"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 33 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(69, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_69"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 34 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(70, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_70"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 35 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(71, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_71"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 36 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(72, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_72"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 37 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(73, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_73"), 1, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 38 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(74, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_74"), 2, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 42 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(75, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_75"), 2, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 43 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(76, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_76"), 2, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 44 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(77, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_77"), 2, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 45 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(78, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_78"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 50 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(79, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_79"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 51 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(80, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_80"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 52 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(81, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_81"), 3, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 53 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(82, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_82"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 63 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(83, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_83"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 64 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(84, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_84"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 65 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(85, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_85"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 66 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(86, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_86"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 67 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(87, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_87"), 4, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 68 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(88, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_88"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 80 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(89, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_89"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 81 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(90, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_90"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 82 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(91, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_91"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 83 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(92, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_92"), 5, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 84 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(93, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_93"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 96 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(94, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_94"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 97 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(95, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_95"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 98 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(96, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_96"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 99 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(97, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_97"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 100 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(98, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_98"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 101 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(99, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_99"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 102 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(100, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_100"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 103 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(101, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_101"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 104 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(102, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_102"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 105 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(103, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_103"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 106 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(104, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_104"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 107 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(105, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_105"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 108 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(106, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_106"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 109 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(107, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_107"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 110 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(108, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_108"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 111 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(109, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_109"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 112 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(110, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_110"), 6, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 85 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(111, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_111"), 7, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 70 }));
		_dataArray.Add(new TaiwuLifeSummaryGroupItem(112, LocalStringManager.GetConfig("TaiwuLifeSummaryGroup_language", "Name_112"), 7, ETaiwuLifeSummaryGroupSize.Small, new List<int> { 71 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaiwuLifeSummaryGroupItem>(113);
		CreateItems0();
		CreateItems1();
	}
}
