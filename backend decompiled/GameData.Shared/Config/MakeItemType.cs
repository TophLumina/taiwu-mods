using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MakeItemType : ConfigData<MakeItemTypeItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MakeItemType Instance = new MakeItemType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "ItemSubType", "TypeName", "MakeItemSubTypes", "TemplateId", "TypeBigIcon" };

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
		_dataArray.Add(new MakeItemTypeItem(0, LocalStringManager.GetConfig("MakeItemType_language", "Name_0"), 1, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_0"), null, new List<short> { 0 }));
		_dataArray.Add(new MakeItemTypeItem(1, LocalStringManager.GetConfig("MakeItemType_language", "Name_1"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_1"), null, new List<short> { 1 }));
		_dataArray.Add(new MakeItemTypeItem(2, LocalStringManager.GetConfig("MakeItemType_language", "Name_2"), 14, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_2"), "ui9_icon_make_item_type_poisonweaponsand", new List<short> { 2 }));
		_dataArray.Add(new MakeItemTypeItem(3, LocalStringManager.GetConfig("MakeItemType_language", "Name_3"), 15, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_3"), "ui9_icon_make_item_type_poisonweaponcream", new List<short> { 3 }));
		_dataArray.Add(new MakeItemTypeItem(4, LocalStringManager.GetConfig("MakeItemType_language", "Name_4"), 12, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_4"), "ui9_icon_make_item_type_mechanicweapon", new List<short> { 4 }));
		_dataArray.Add(new MakeItemTypeItem(5, LocalStringManager.GetConfig("MakeItemType_language", "Name_5"), 12, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_5"), "ui9_icon_make_item_type_mechanicweapon", new List<short> { 5 }));
		_dataArray.Add(new MakeItemTypeItem(6, LocalStringManager.GetConfig("MakeItemType_language", "Name_6"), 13, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_6"), "ui9_icon_make_item_type_magicsymbol", new List<short> { 6 }));
		_dataArray.Add(new MakeItemTypeItem(7, LocalStringManager.GetConfig("MakeItemType_language", "Name_7"), 13, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_7"), "ui9_icon_make_item_type_magicsymbol", new List<short> { 7 }));
		_dataArray.Add(new MakeItemTypeItem(8, LocalStringManager.GetConfig("MakeItemType_language", "Name_8"), 0, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_8"), "ui9_icon_make_item_type_needlebox", new List<short> { 8 }));
		_dataArray.Add(new MakeItemTypeItem(9, LocalStringManager.GetConfig("MakeItemType_language", "Name_9"), 0, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_9"), "ui9_icon_make_item_type_needlebox", new List<short> { 9 }));
		_dataArray.Add(new MakeItemTypeItem(10, LocalStringManager.GetConfig("MakeItemType_language", "Name_10"), 0, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_10"), "ui9_icon_make_item_type_needlebox", new List<short> { 10 }));
		_dataArray.Add(new MakeItemTypeItem(11, LocalStringManager.GetConfig("MakeItemType_language", "Name_11"), 0, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_11"), "ui9_icon_make_item_type_needlebox", new List<short> { 11 }));
		_dataArray.Add(new MakeItemTypeItem(12, LocalStringManager.GetConfig("MakeItemType_language", "Name_12"), 0, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_12"), "ui9_icon_make_item_type_needlebox", new List<short> { 12 }));
		_dataArray.Add(new MakeItemTypeItem(13, LocalStringManager.GetConfig("MakeItemType_language", "Name_13"), 0, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_13"), "ui9_icon_make_item_type_needlebox", new List<short> { 13 }));
		_dataArray.Add(new MakeItemTypeItem(14, LocalStringManager.GetConfig("MakeItemType_language", "Name_14"), 1, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_14"), "ui9_icon_make_item_type_doubledaggers", new List<short> { 14 }));
		_dataArray.Add(new MakeItemTypeItem(15, LocalStringManager.GetConfig("MakeItemType_language", "Name_15"), 1, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_15"), "ui9_icon_make_item_type_doubledaggers", new List<short> { 15 }));
		_dataArray.Add(new MakeItemTypeItem(16, LocalStringManager.GetConfig("MakeItemType_language", "Name_16"), 1, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_16"), "ui9_icon_make_item_type_doubledaggers", new List<short> { 16 }));
		_dataArray.Add(new MakeItemTypeItem(17, LocalStringManager.GetConfig("MakeItemType_language", "Name_17"), 1, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_17"), "ui9_icon_make_item_type_doubledaggers", new List<short> { 17 }));
		_dataArray.Add(new MakeItemTypeItem(18, LocalStringManager.GetConfig("MakeItemType_language", "Name_18"), 1, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_18"), "ui9_icon_make_item_type_doubledaggers", new List<short> { 18 }));
		_dataArray.Add(new MakeItemTypeItem(19, LocalStringManager.GetConfig("MakeItemType_language", "Name_19"), 1, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_19"), "ui9_icon_make_item_type_doubledaggers", new List<short> { 19 }));
		_dataArray.Add(new MakeItemTypeItem(20, LocalStringManager.GetConfig("MakeItemType_language", "Name_20"), 2, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_20"), "ui9_icon_make_item_type_hidden", new List<short> { 20 }));
		_dataArray.Add(new MakeItemTypeItem(21, LocalStringManager.GetConfig("MakeItemType_language", "Name_21"), 2, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_21"), "ui9_icon_make_item_type_hidden", new List<short> { 21 }));
		_dataArray.Add(new MakeItemTypeItem(22, LocalStringManager.GetConfig("MakeItemType_language", "Name_22"), 2, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_22"), "ui9_icon_make_item_type_hidden", new List<short> { 22 }));
		_dataArray.Add(new MakeItemTypeItem(23, LocalStringManager.GetConfig("MakeItemType_language", "Name_23"), 2, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_23"), "ui9_icon_make_item_type_hidden", new List<short> { 23 }));
		_dataArray.Add(new MakeItemTypeItem(24, LocalStringManager.GetConfig("MakeItemType_language", "Name_24"), 2, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_24"), "ui9_icon_make_item_type_hidden", new List<short> { 24 }));
		_dataArray.Add(new MakeItemTypeItem(25, LocalStringManager.GetConfig("MakeItemType_language", "Name_25"), 2, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_25"), "ui9_icon_make_item_type_hidden", new List<short> { 25 }));
		_dataArray.Add(new MakeItemTypeItem(26, LocalStringManager.GetConfig("MakeItemType_language", "Name_26"), 3, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_26"), "ui9_icon_make_item_type_flute", new List<short> { 26 }));
		_dataArray.Add(new MakeItemTypeItem(27, LocalStringManager.GetConfig("MakeItemType_language", "Name_27"), 3, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_27"), "ui9_icon_make_item_type_flute", new List<short> { 27 }));
		_dataArray.Add(new MakeItemTypeItem(28, LocalStringManager.GetConfig("MakeItemType_language", "Name_28"), 3, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_28"), "ui9_icon_make_item_type_flute", new List<short> { 28 }));
		_dataArray.Add(new MakeItemTypeItem(29, LocalStringManager.GetConfig("MakeItemType_language", "Name_29"), 3, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_29"), "ui9_icon_make_item_type_flute", new List<short> { 29 }));
		_dataArray.Add(new MakeItemTypeItem(30, LocalStringManager.GetConfig("MakeItemType_language", "Name_30"), 3, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_30"), "ui9_icon_make_item_type_flute", new List<short> { 30 }));
		_dataArray.Add(new MakeItemTypeItem(31, LocalStringManager.GetConfig("MakeItemType_language", "Name_31"), 3, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_31"), "ui9_icon_make_item_type_flute", new List<short> { 31 }));
		_dataArray.Add(new MakeItemTypeItem(32, LocalStringManager.GetConfig("MakeItemType_language", "Name_32"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_32"), "ui9_icon_make_item_type_gloves", new List<short> { 32, 33 }));
		_dataArray.Add(new MakeItemTypeItem(33, LocalStringManager.GetConfig("MakeItemType_language", "Name_33"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_33"), "ui9_icon_make_item_type_gloves", new List<short> { 34 }));
		_dataArray.Add(new MakeItemTypeItem(34, LocalStringManager.GetConfig("MakeItemType_language", "Name_34"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_34"), "ui9_icon_make_item_type_gloves", new List<short> { 35 }));
		_dataArray.Add(new MakeItemTypeItem(35, LocalStringManager.GetConfig("MakeItemType_language", "Name_35"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_35"), "ui9_icon_make_item_type_gloves", new List<short> { 36, 37 }));
		_dataArray.Add(new MakeItemTypeItem(36, LocalStringManager.GetConfig("MakeItemType_language", "Name_36"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_36"), "ui9_icon_make_item_type_gloves", new List<short> { 38, 39 }));
		_dataArray.Add(new MakeItemTypeItem(37, LocalStringManager.GetConfig("MakeItemType_language", "Name_37"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_37"), "ui9_icon_make_item_type_gloves", new List<short> { 40 }));
		_dataArray.Add(new MakeItemTypeItem(38, LocalStringManager.GetConfig("MakeItemType_language", "Name_38"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_38"), "ui9_icon_make_item_type_gloves", new List<short> { 41 }));
		_dataArray.Add(new MakeItemTypeItem(39, LocalStringManager.GetConfig("MakeItemType_language", "Name_39"), 4, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_39"), "ui9_icon_make_item_type_gloves", new List<short> { 42, 43 }));
		_dataArray.Add(new MakeItemTypeItem(40, LocalStringManager.GetConfig("MakeItemType_language", "Name_40"), 5, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_40"), "ui9_icon_make_item_type_pestle", new List<short> { 44 }));
		_dataArray.Add(new MakeItemTypeItem(41, LocalStringManager.GetConfig("MakeItemType_language", "Name_41"), 5, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_41"), "ui9_icon_make_item_type_pestle", new List<short> { 45 }));
		_dataArray.Add(new MakeItemTypeItem(42, LocalStringManager.GetConfig("MakeItemType_language", "Name_42"), 5, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_42"), "ui9_icon_make_item_type_pestle", new List<short> { 46 }));
		_dataArray.Add(new MakeItemTypeItem(43, LocalStringManager.GetConfig("MakeItemType_language", "Name_43"), 5, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_43"), "ui9_icon_make_item_type_pestle", new List<short> { 47 }));
		_dataArray.Add(new MakeItemTypeItem(44, LocalStringManager.GetConfig("MakeItemType_language", "Name_44"), 5, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_44"), "ui9_icon_make_item_type_pestle", new List<short> { 48 }));
		_dataArray.Add(new MakeItemTypeItem(45, LocalStringManager.GetConfig("MakeItemType_language", "Name_45"), 5, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_45"), "ui9_icon_make_item_type_pestle", new List<short> { 49 }));
		_dataArray.Add(new MakeItemTypeItem(46, LocalStringManager.GetConfig("MakeItemType_language", "Name_46"), 8, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_46"), "ui9_icon_make_item_type_sword", new List<short> { 50, 51, 52 }));
		_dataArray.Add(new MakeItemTypeItem(47, LocalStringManager.GetConfig("MakeItemType_language", "Name_47"), 8, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_47"), "ui9_icon_make_item_type_sword", new List<short> { 53 }));
		_dataArray.Add(new MakeItemTypeItem(48, LocalStringManager.GetConfig("MakeItemType_language", "Name_48"), 8, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_48"), "ui9_icon_make_item_type_sword", new List<short> { 54 }));
		_dataArray.Add(new MakeItemTypeItem(49, LocalStringManager.GetConfig("MakeItemType_language", "Name_49"), 8, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_49"), "ui9_icon_make_item_type_sword", new List<short> { 55, 56, 57 }));
		_dataArray.Add(new MakeItemTypeItem(50, LocalStringManager.GetConfig("MakeItemType_language", "Name_50"), 8, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_50"), "ui9_icon_make_item_type_sword", new List<short> { 58 }));
		_dataArray.Add(new MakeItemTypeItem(51, LocalStringManager.GetConfig("MakeItemType_language", "Name_51"), 8, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_51"), "ui9_icon_make_item_type_sword", new List<short> { 59 }));
		_dataArray.Add(new MakeItemTypeItem(52, LocalStringManager.GetConfig("MakeItemType_language", "Name_52"), 9, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_52"), "ui9_icon_make_item_type_blade", new List<short> { 60, 61, 62 }));
		_dataArray.Add(new MakeItemTypeItem(53, LocalStringManager.GetConfig("MakeItemType_language", "Name_53"), 9, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_53"), "ui9_icon_make_item_type_blade", new List<short> { 63 }));
		_dataArray.Add(new MakeItemTypeItem(54, LocalStringManager.GetConfig("MakeItemType_language", "Name_54"), 9, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_54"), "ui9_icon_make_item_type_blade", new List<short> { 64 }));
		_dataArray.Add(new MakeItemTypeItem(55, LocalStringManager.GetConfig("MakeItemType_language", "Name_55"), 9, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_55"), "ui9_icon_make_item_type_blade", new List<short> { 65, 66, 67 }));
		_dataArray.Add(new MakeItemTypeItem(56, LocalStringManager.GetConfig("MakeItemType_language", "Name_56"), 9, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_56"), "ui9_icon_make_item_type_blade", new List<short> { 68 }));
		_dataArray.Add(new MakeItemTypeItem(57, LocalStringManager.GetConfig("MakeItemType_language", "Name_57"), 9, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_57"), "ui9_icon_make_item_type_blade", new List<short> { 69 }));
		_dataArray.Add(new MakeItemTypeItem(58, LocalStringManager.GetConfig("MakeItemType_language", "Name_58"), 10, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_58"), "ui9_icon_make_item_type_polearm", new List<short> { 70, 71 }));
		_dataArray.Add(new MakeItemTypeItem(59, LocalStringManager.GetConfig("MakeItemType_language", "Name_59"), 10, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_59"), "ui9_icon_make_item_type_polearm", new List<short> { 72, 73 }));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MakeItemTypeItem(60, LocalStringManager.GetConfig("MakeItemType_language", "Name_60"), 10, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_60"), "ui9_icon_make_item_type_polearm", new List<short> { 74 }));
		_dataArray.Add(new MakeItemTypeItem(61, LocalStringManager.GetConfig("MakeItemType_language", "Name_61"), 10, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_61"), "ui9_icon_make_item_type_polearm", new List<short> { 75, 76 }));
		_dataArray.Add(new MakeItemTypeItem(62, LocalStringManager.GetConfig("MakeItemType_language", "Name_62"), 10, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_62"), "ui9_icon_make_item_type_polearm", new List<short> { 77, 78 }));
		_dataArray.Add(new MakeItemTypeItem(63, LocalStringManager.GetConfig("MakeItemType_language", "Name_63"), 10, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_63"), "ui9_icon_make_item_type_polearm", new List<short> { 79 }));
		_dataArray.Add(new MakeItemTypeItem(64, LocalStringManager.GetConfig("MakeItemType_language", "Name_64"), 11, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_64"), "ui9_icon_make_item_type_zither", new List<short> { 80 }));
		_dataArray.Add(new MakeItemTypeItem(65, LocalStringManager.GetConfig("MakeItemType_language", "Name_65"), 11, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_65"), "ui9_icon_make_item_type_zither", new List<short> { 81 }));
		_dataArray.Add(new MakeItemTypeItem(66, LocalStringManager.GetConfig("MakeItemType_language", "Name_66"), 11, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_66"), "ui9_icon_make_item_type_zither", new List<short> { 82 }));
		_dataArray.Add(new MakeItemTypeItem(67, LocalStringManager.GetConfig("MakeItemType_language", "Name_67"), 11, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_67"), "ui9_icon_make_item_type_zither", new List<short> { 83 }));
		_dataArray.Add(new MakeItemTypeItem(68, LocalStringManager.GetConfig("MakeItemType_language", "Name_68"), 11, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_68"), "ui9_icon_make_item_type_zither", new List<short> { 84 }));
		_dataArray.Add(new MakeItemTypeItem(69, LocalStringManager.GetConfig("MakeItemType_language", "Name_69"), 11, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_69"), "ui9_icon_make_item_type_zither", new List<short> { 85 }));
		_dataArray.Add(new MakeItemTypeItem(70, LocalStringManager.GetConfig("MakeItemType_language", "Name_70"), 6, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_70"), "ui9_icon_make_item_type_whisk", new List<short> { 86 }));
		_dataArray.Add(new MakeItemTypeItem(71, LocalStringManager.GetConfig("MakeItemType_language", "Name_71"), 6, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_71"), "ui9_icon_make_item_type_whisk", new List<short> { 87 }));
		_dataArray.Add(new MakeItemTypeItem(72, LocalStringManager.GetConfig("MakeItemType_language", "Name_72"), 6, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_72"), "ui9_icon_make_item_type_whisk", new List<short> { 88 }));
		_dataArray.Add(new MakeItemTypeItem(73, LocalStringManager.GetConfig("MakeItemType_language", "Name_73"), 6, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_73"), "ui9_icon_make_item_type_whisk", new List<short> { 89 }));
		_dataArray.Add(new MakeItemTypeItem(74, LocalStringManager.GetConfig("MakeItemType_language", "Name_74"), 7, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_74"), "ui9_icon_make_item_type_whip", new List<short> { 90 }));
		_dataArray.Add(new MakeItemTypeItem(75, LocalStringManager.GetConfig("MakeItemType_language", "Name_75"), 7, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_75"), "ui9_icon_make_item_type_whip", new List<short> { 91 }));
		_dataArray.Add(new MakeItemTypeItem(76, LocalStringManager.GetConfig("MakeItemType_language", "Name_76"), 7, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_76"), "ui9_icon_make_item_type_whip", new List<short> { 92 }));
		_dataArray.Add(new MakeItemTypeItem(77, LocalStringManager.GetConfig("MakeItemType_language", "Name_77"), 7, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_77"), "ui9_icon_make_item_type_whip", new List<short> { 93 }));
		_dataArray.Add(new MakeItemTypeItem(78, LocalStringManager.GetConfig("MakeItemType_language", "Name_78"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_78"), "ui9_icon_make_item_type_accessory", new List<short> { 94 }));
		_dataArray.Add(new MakeItemTypeItem(79, LocalStringManager.GetConfig("MakeItemType_language", "Name_79"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_79"), "ui9_icon_make_item_type_accessory", new List<short> { 95, 96, 97 }));
		_dataArray.Add(new MakeItemTypeItem(80, LocalStringManager.GetConfig("MakeItemType_language", "Name_80"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_80"), "ui9_icon_make_item_type_accessory", new List<short> { 98, 99, 100, 101, 102, 103, 104 }));
		_dataArray.Add(new MakeItemTypeItem(81, LocalStringManager.GetConfig("MakeItemType_language", "Name_81"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_81"), "ui9_icon_make_item_type_accessory", new List<short> { 105 }));
		_dataArray.Add(new MakeItemTypeItem(82, LocalStringManager.GetConfig("MakeItemType_language", "Name_82"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_82"), "ui9_icon_make_item_type_accessory", new List<short> { 106 }));
		_dataArray.Add(new MakeItemTypeItem(83, LocalStringManager.GetConfig("MakeItemType_language", "Name_83"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_83"), "ui9_icon_make_item_type_accessory", new List<short> { 107, 108, 109 }));
		_dataArray.Add(new MakeItemTypeItem(84, LocalStringManager.GetConfig("MakeItemType_language", "Name_84"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_84"), "ui9_icon_make_item_type_accessory", new List<short> { 110, 111, 112, 113, 114, 115, 116 }));
		_dataArray.Add(new MakeItemTypeItem(85, LocalStringManager.GetConfig("MakeItemType_language", "Name_85"), 200, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_85"), "ui9_icon_make_item_type_accessory", new List<short> { 117 }));
		_dataArray.Add(new MakeItemTypeItem(86, LocalStringManager.GetConfig("MakeItemType_language", "Name_86"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_86"), "ui9_icon_make_item_type_helm", new List<short> { 118 }));
		_dataArray.Add(new MakeItemTypeItem(87, LocalStringManager.GetConfig("MakeItemType_language", "Name_87"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_87"), "ui9_icon_make_item_type_helm", new List<short> { 119 }));
		_dataArray.Add(new MakeItemTypeItem(88, LocalStringManager.GetConfig("MakeItemType_language", "Name_88"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_88"), "ui9_icon_make_item_type_helm", new List<short> { 120 }));
		_dataArray.Add(new MakeItemTypeItem(89, LocalStringManager.GetConfig("MakeItemType_language", "Name_89"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_89"), "ui9_icon_make_item_type_helm", new List<short> { 121, 122, 123, 124 }));
		_dataArray.Add(new MakeItemTypeItem(90, LocalStringManager.GetConfig("MakeItemType_language", "Name_90"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_90"), "ui9_icon_make_item_type_helm", new List<short> { 125 }));
		_dataArray.Add(new MakeItemTypeItem(91, LocalStringManager.GetConfig("MakeItemType_language", "Name_91"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_91"), "ui9_icon_make_item_type_helm", new List<short> { 126 }));
		_dataArray.Add(new MakeItemTypeItem(92, LocalStringManager.GetConfig("MakeItemType_language", "Name_92"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_92"), "ui9_icon_make_item_type_helm", new List<short> { 127 }));
		_dataArray.Add(new MakeItemTypeItem(93, LocalStringManager.GetConfig("MakeItemType_language", "Name_93"), 100, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_93"), "ui9_icon_make_item_type_helm", new List<short> { 128, 129, 130, 131 }));
		_dataArray.Add(new MakeItemTypeItem(94, LocalStringManager.GetConfig("MakeItemType_language", "Name_94"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_94"), "ui9_icon_make_item_type_boots", new List<short> { 132 }));
		_dataArray.Add(new MakeItemTypeItem(95, LocalStringManager.GetConfig("MakeItemType_language", "Name_95"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_95"), "ui9_icon_make_item_type_boots", new List<short> { 133 }));
		_dataArray.Add(new MakeItemTypeItem(96, LocalStringManager.GetConfig("MakeItemType_language", "Name_96"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_96"), "ui9_icon_make_item_type_boots", new List<short> { 134 }));
		_dataArray.Add(new MakeItemTypeItem(97, LocalStringManager.GetConfig("MakeItemType_language", "Name_97"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_97"), "ui9_icon_make_item_type_boots", new List<short> { 135, 136, 137, 138 }));
		_dataArray.Add(new MakeItemTypeItem(98, LocalStringManager.GetConfig("MakeItemType_language", "Name_98"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_98"), "ui9_icon_make_item_type_boots", new List<short> { 139 }));
		_dataArray.Add(new MakeItemTypeItem(99, LocalStringManager.GetConfig("MakeItemType_language", "Name_99"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_99"), "ui9_icon_make_item_type_boots", new List<short> { 140 }));
		_dataArray.Add(new MakeItemTypeItem(100, LocalStringManager.GetConfig("MakeItemType_language", "Name_100"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_100"), "ui9_icon_make_item_type_boots", new List<short> { 141 }));
		_dataArray.Add(new MakeItemTypeItem(101, LocalStringManager.GetConfig("MakeItemType_language", "Name_101"), 103, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_101"), "ui9_icon_make_item_type_boots", new List<short> { 142, 143, 144, 145 }));
		_dataArray.Add(new MakeItemTypeItem(102, LocalStringManager.GetConfig("MakeItemType_language", "Name_102"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_102"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 146, 147 }));
		_dataArray.Add(new MakeItemTypeItem(103, LocalStringManager.GetConfig("MakeItemType_language", "Name_103"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_103"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 148 }));
		_dataArray.Add(new MakeItemTypeItem(104, LocalStringManager.GetConfig("MakeItemType_language", "Name_104"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_104"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 149 }));
		_dataArray.Add(new MakeItemTypeItem(105, LocalStringManager.GetConfig("MakeItemType_language", "Name_105"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_105"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 150, 151, 152, 153 }));
		_dataArray.Add(new MakeItemTypeItem(106, LocalStringManager.GetConfig("MakeItemType_language", "Name_106"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_106"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 154, 155 }));
		_dataArray.Add(new MakeItemTypeItem(107, LocalStringManager.GetConfig("MakeItemType_language", "Name_107"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_107"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 156 }));
		_dataArray.Add(new MakeItemTypeItem(108, LocalStringManager.GetConfig("MakeItemType_language", "Name_108"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_108"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 157 }));
		_dataArray.Add(new MakeItemTypeItem(109, LocalStringManager.GetConfig("MakeItemType_language", "Name_109"), 101, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_109"), "ui9_icon_make_item_type_torsoarmor", new List<short> { 158, 159, 160, 161 }));
		_dataArray.Add(new MakeItemTypeItem(110, LocalStringManager.GetConfig("MakeItemType_language", "Name_110"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_110"), "ui9_icon_make_item_type_bracers", new List<short> { 162 }));
		_dataArray.Add(new MakeItemTypeItem(111, LocalStringManager.GetConfig("MakeItemType_language", "Name_111"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_111"), "ui9_icon_make_item_type_bracers", new List<short> { 163 }));
		_dataArray.Add(new MakeItemTypeItem(112, LocalStringManager.GetConfig("MakeItemType_language", "Name_112"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_112"), "ui9_icon_make_item_type_bracers", new List<short> { 164 }));
		_dataArray.Add(new MakeItemTypeItem(113, LocalStringManager.GetConfig("MakeItemType_language", "Name_113"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_113"), "ui9_icon_make_item_type_bracers", new List<short> { 165, 166, 167, 168 }));
		_dataArray.Add(new MakeItemTypeItem(114, LocalStringManager.GetConfig("MakeItemType_language", "Name_114"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_114"), "ui9_icon_make_item_type_bracers", new List<short> { 169 }));
		_dataArray.Add(new MakeItemTypeItem(115, LocalStringManager.GetConfig("MakeItemType_language", "Name_115"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_115"), "ui9_icon_make_item_type_bracers", new List<short> { 170 }));
		_dataArray.Add(new MakeItemTypeItem(116, LocalStringManager.GetConfig("MakeItemType_language", "Name_116"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_116"), "ui9_icon_make_item_type_bracers", new List<short> { 171 }));
		_dataArray.Add(new MakeItemTypeItem(117, LocalStringManager.GetConfig("MakeItemType_language", "Name_117"), 102, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_117"), "ui9_icon_make_item_type_bracers", new List<short> { 172, 173, 174, 175 }));
		_dataArray.Add(new MakeItemTypeItem(118, LocalStringManager.GetConfig("MakeItemType_language", "Name_118"), 300, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_118"), "ui9_icon_make_item_type_clothing", new List<short> { 176 }));
		_dataArray.Add(new MakeItemTypeItem(119, LocalStringManager.GetConfig("MakeItemType_language", "Name_119"), 300, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_119"), "ui9_icon_make_item_type_clothing", new List<short> { 177, 264 }));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MakeItemTypeItem(120, LocalStringManager.GetConfig("MakeItemType_language", "Name_120"), 400, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_120"), "ui9_icon_make_item_type_carrier", new List<short> { 178 }));
		_dataArray.Add(new MakeItemTypeItem(121, LocalStringManager.GetConfig("MakeItemType_language", "Name_121"), 400, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_121"), "ui9_icon_make_item_type_carrier", new List<short> { 179 }));
		_dataArray.Add(new MakeItemTypeItem(122, LocalStringManager.GetConfig("MakeItemType_language", "Name_122"), 201, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_122"), "building_icon_koudai_0", new List<short> { 180 }));
		_dataArray.Add(new MakeItemTypeItem(123, LocalStringManager.GetConfig("MakeItemType_language", "Name_123"), 1206, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_123"), "ui9_icon_make_item_type_rope", new List<short> { 181 }));
		_dataArray.Add(new MakeItemTypeItem(124, LocalStringManager.GetConfig("MakeItemType_language", "Name_124"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_124"), "building_icon_hunshi_0", new List<short> { 182 }));
		_dataArray.Add(new MakeItemTypeItem(125, LocalStringManager.GetConfig("MakeItemType_language", "Name_125"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_125"), "building_icon_hunshi_0", new List<short> { 183 }));
		_dataArray.Add(new MakeItemTypeItem(126, LocalStringManager.GetConfig("MakeItemType_language", "Name_126"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_126"), "building_icon_hunshi_0", new List<short> { 184 }));
		_dataArray.Add(new MakeItemTypeItem(127, LocalStringManager.GetConfig("MakeItemType_language", "Name_127"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_127"), "building_icon_hunshi_0", new List<short> { 185 }));
		_dataArray.Add(new MakeItemTypeItem(128, LocalStringManager.GetConfig("MakeItemType_language", "Name_128"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_128"), "building_icon_hunshi_0", new List<short> { 186 }));
		_dataArray.Add(new MakeItemTypeItem(129, LocalStringManager.GetConfig("MakeItemType_language", "Name_129"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_129"), "building_icon_hunshi_0", new List<short> { 187 }));
		_dataArray.Add(new MakeItemTypeItem(130, LocalStringManager.GetConfig("MakeItemType_language", "Name_130"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_130"), "building_icon_hunshi_0", new List<short> { 188 }));
		_dataArray.Add(new MakeItemTypeItem(131, LocalStringManager.GetConfig("MakeItemType_language", "Name_131"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_131"), "building_icon_hunshi_0", new List<short> { 189 }));
		_dataArray.Add(new MakeItemTypeItem(132, LocalStringManager.GetConfig("MakeItemType_language", "Name_132"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_132"), "building_icon_hunshi_0", new List<short> { 190 }));
		_dataArray.Add(new MakeItemTypeItem(133, LocalStringManager.GetConfig("MakeItemType_language", "Name_133"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_133"), "building_icon_hunshi_0", new List<short> { 191 }));
		_dataArray.Add(new MakeItemTypeItem(134, LocalStringManager.GetConfig("MakeItemType_language", "Name_134"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_134"), "building_icon_hunshi_0", new List<short> { 192 }));
		_dataArray.Add(new MakeItemTypeItem(135, LocalStringManager.GetConfig("MakeItemType_language", "Name_135"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_135"), "building_icon_hunshi_0", new List<short> { 193 }));
		_dataArray.Add(new MakeItemTypeItem(136, LocalStringManager.GetConfig("MakeItemType_language", "Name_136"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_136"), "building_icon_hunshi_0", new List<short> { 194 }));
		_dataArray.Add(new MakeItemTypeItem(137, LocalStringManager.GetConfig("MakeItemType_language", "Name_137"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_137"), "building_icon_hunshi_0", new List<short> { 195 }));
		_dataArray.Add(new MakeItemTypeItem(138, LocalStringManager.GetConfig("MakeItemType_language", "Name_138"), 700, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_138"), "building_icon_sushi_0", new List<short> { 196 }));
		_dataArray.Add(new MakeItemTypeItem(139, LocalStringManager.GetConfig("MakeItemType_language", "Name_139"), 700, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_139"), "building_icon_sushi_0", new List<short> { 197 }));
		_dataArray.Add(new MakeItemTypeItem(140, LocalStringManager.GetConfig("MakeItemType_language", "Name_140"), 700, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_140"), "building_icon_sushi_0", new List<short> { 198 }));
		_dataArray.Add(new MakeItemTypeItem(141, LocalStringManager.GetConfig("MakeItemType_language", "Name_141"), 700, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_141"), "building_icon_sushi_0", new List<short> { 199 }));
		_dataArray.Add(new MakeItemTypeItem(142, LocalStringManager.GetConfig("MakeItemType_language", "Name_142"), 700, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_142"), "building_icon_sushi_0", new List<short> { 200 }));
		_dataArray.Add(new MakeItemTypeItem(143, LocalStringManager.GetConfig("MakeItemType_language", "Name_143"), 700, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_143"), "building_icon_sushi_0", new List<short> { 201 }));
		_dataArray.Add(new MakeItemTypeItem(144, LocalStringManager.GetConfig("MakeItemType_language", "Name_144"), 700, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_144"), "building_icon_sushi_0", new List<short> { 202 }));
		_dataArray.Add(new MakeItemTypeItem(145, LocalStringManager.GetConfig("MakeItemType_language", "Name_145"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_145"), "building_icon_sushi_0", new List<short> { 203 }));
		_dataArray.Add(new MakeItemTypeItem(146, LocalStringManager.GetConfig("MakeItemType_language", "Name_146"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_146"), "building_icon_sushi_0", new List<short> { 204 }));
		_dataArray.Add(new MakeItemTypeItem(147, LocalStringManager.GetConfig("MakeItemType_language", "Name_147"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_147"), "building_icon_sushi_0", new List<short> { 205 }));
		_dataArray.Add(new MakeItemTypeItem(148, LocalStringManager.GetConfig("MakeItemType_language", "Name_148"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_148"), "building_icon_sushi_0", new List<short> { 206 }));
		_dataArray.Add(new MakeItemTypeItem(149, LocalStringManager.GetConfig("MakeItemType_language", "Name_149"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_149"), "building_icon_sushi_0", new List<short> { 207 }));
		_dataArray.Add(new MakeItemTypeItem(150, LocalStringManager.GetConfig("MakeItemType_language", "Name_150"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_150"), "building_icon_sushi_0", new List<short> { 208 }));
		_dataArray.Add(new MakeItemTypeItem(151, LocalStringManager.GetConfig("MakeItemType_language", "Name_151"), 701, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_151"), "building_icon_sushi_0", new List<short> { 209 }));
		_dataArray.Add(new MakeItemTypeItem(152, LocalStringManager.GetConfig("MakeItemType_language", "Name_152"), 801, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_152"), "ui9_icon_make_item_type_poison", new List<short> { 210 }));
		_dataArray.Add(new MakeItemTypeItem(153, LocalStringManager.GetConfig("MakeItemType_language", "Name_153"), 801, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_153"), "ui9_icon_make_item_type_poison", new List<short> { 211 }));
		_dataArray.Add(new MakeItemTypeItem(154, LocalStringManager.GetConfig("MakeItemType_language", "Name_154"), 801, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_154"), "ui9_icon_make_item_type_poison", new List<short> { 212 }));
		_dataArray.Add(new MakeItemTypeItem(155, LocalStringManager.GetConfig("MakeItemType_language", "Name_155"), 801, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_155"), "ui9_icon_make_item_type_poison", new List<short> { 213 }));
		_dataArray.Add(new MakeItemTypeItem(156, LocalStringManager.GetConfig("MakeItemType_language", "Name_156"), 801, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_156"), "ui9_icon_make_item_type_poison", new List<short> { 214 }));
		_dataArray.Add(new MakeItemTypeItem(157, LocalStringManager.GetConfig("MakeItemType_language", "Name_157"), 801, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_157"), "ui9_icon_make_item_type_poison", new List<short> { 215 }));
		_dataArray.Add(new MakeItemTypeItem(158, LocalStringManager.GetConfig("MakeItemType_language", "Name_158"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_158"), "ui9_icon_make_item_type_medicine", new List<short> { 240, 216 }));
		_dataArray.Add(new MakeItemTypeItem(159, LocalStringManager.GetConfig("MakeItemType_language", "Name_159"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_159"), "ui9_icon_make_item_type_medicine", new List<short> { 241, 217 }));
		_dataArray.Add(new MakeItemTypeItem(160, LocalStringManager.GetConfig("MakeItemType_language", "Name_160"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_160"), "ui9_icon_make_item_type_medicine", new List<short> { 242, 218 }));
		_dataArray.Add(new MakeItemTypeItem(161, LocalStringManager.GetConfig("MakeItemType_language", "Name_161"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_161"), "ui9_icon_make_item_type_medicine", new List<short> { 243, 219 }));
		_dataArray.Add(new MakeItemTypeItem(162, LocalStringManager.GetConfig("MakeItemType_language", "Name_162"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_162"), "ui9_icon_make_item_type_medicine", new List<short> { 244, 220 }));
		_dataArray.Add(new MakeItemTypeItem(163, LocalStringManager.GetConfig("MakeItemType_language", "Name_163"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_163"), "ui9_icon_make_item_type_medicine", new List<short> { 245, 221 }));
		_dataArray.Add(new MakeItemTypeItem(164, LocalStringManager.GetConfig("MakeItemType_language", "Name_164"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_164"), "ui9_icon_make_item_type_medicine", new List<short> { 246, 222 }));
		_dataArray.Add(new MakeItemTypeItem(165, LocalStringManager.GetConfig("MakeItemType_language", "Name_165"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_165"), "ui9_icon_make_item_type_medicine", new List<short> { 247, 223 }));
		_dataArray.Add(new MakeItemTypeItem(166, LocalStringManager.GetConfig("MakeItemType_language", "Name_166"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_166"), "ui9_icon_make_item_type_medicine", new List<short> { 248, 224 }));
		_dataArray.Add(new MakeItemTypeItem(167, LocalStringManager.GetConfig("MakeItemType_language", "Name_167"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_167"), "ui9_icon_make_item_type_medicine", new List<short> { 249, 225 }));
		_dataArray.Add(new MakeItemTypeItem(168, LocalStringManager.GetConfig("MakeItemType_language", "Name_168"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_168"), "ui9_icon_make_item_type_medicine", new List<short> { 250, 226 }));
		_dataArray.Add(new MakeItemTypeItem(169, LocalStringManager.GetConfig("MakeItemType_language", "Name_169"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_169"), "ui9_icon_make_item_type_medicine", new List<short> { 251, 227 }));
		_dataArray.Add(new MakeItemTypeItem(170, LocalStringManager.GetConfig("MakeItemType_language", "Name_170"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_170"), "ui9_icon_make_item_type_medicine", new List<short> { 252, 228 }));
		_dataArray.Add(new MakeItemTypeItem(171, LocalStringManager.GetConfig("MakeItemType_language", "Name_171"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_171"), "ui9_icon_make_item_type_medicine", new List<short> { 253, 229 }));
		_dataArray.Add(new MakeItemTypeItem(172, LocalStringManager.GetConfig("MakeItemType_language", "Name_172"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_172"), "ui9_icon_make_item_type_medicine", new List<short> { 254, 230 }));
		_dataArray.Add(new MakeItemTypeItem(173, LocalStringManager.GetConfig("MakeItemType_language", "Name_173"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_173"), "ui9_icon_make_item_type_medicine", new List<short> { 255, 231 }));
		_dataArray.Add(new MakeItemTypeItem(174, LocalStringManager.GetConfig("MakeItemType_language", "Name_174"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_174"), "ui9_icon_make_item_type_medicine", new List<short> { 256, 232 }));
		_dataArray.Add(new MakeItemTypeItem(175, LocalStringManager.GetConfig("MakeItemType_language", "Name_175"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_175"), "ui9_icon_make_item_type_medicine", new List<short> { 257, 233 }));
		_dataArray.Add(new MakeItemTypeItem(176, LocalStringManager.GetConfig("MakeItemType_language", "Name_176"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_176"), "ui9_icon_make_item_type_medicine", new List<short> { 258, 234 }));
		_dataArray.Add(new MakeItemTypeItem(177, LocalStringManager.GetConfig("MakeItemType_language", "Name_177"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_177"), "ui9_icon_make_item_type_medicine", new List<short> { 259, 235 }));
		_dataArray.Add(new MakeItemTypeItem(178, LocalStringManager.GetConfig("MakeItemType_language", "Name_178"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_178"), "ui9_icon_make_item_type_medicine", new List<short> { 260, 236 }));
		_dataArray.Add(new MakeItemTypeItem(179, LocalStringManager.GetConfig("MakeItemType_language", "Name_179"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_179"), "ui9_icon_make_item_type_medicine", new List<short> { 261, 237 }));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new MakeItemTypeItem(180, LocalStringManager.GetConfig("MakeItemType_language", "Name_180"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_180"), "ui9_icon_make_item_type_medicine", new List<short> { 262, 238 }));
		_dataArray.Add(new MakeItemTypeItem(181, LocalStringManager.GetConfig("MakeItemType_language", "Name_181"), 800, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_181"), "ui9_icon_make_item_type_medicine", new List<short> { 263, 239 }));
		_dataArray.Add(new MakeItemTypeItem(182, LocalStringManager.GetConfig("MakeItemType_language", "Name_182"), 300, LocalStringManager.GetConfig("MakeItemType_language", "TypeName_182"), null, new List<short> { 265 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MakeItemTypeItem>(183);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
	}
}
