using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LegendaryBookSlot : ConfigData<LegendaryBookSlotItem, short>
{
	public static LegendaryBookSlot Instance = new LegendaryBookSlot();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "ClassName" };

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
		_dataArray.Add(new LegendaryBookSlotItem(0, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_0"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_0"), null));
		_dataArray.Add(new LegendaryBookSlotItem(1, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_1"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_1"), "LegendaryBook.Neigong.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(2, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_2"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_2"), "LegendaryBook.Neigong.YongJi"));
		_dataArray.Add(new LegendaryBookSlotItem(3, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_3"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_3"), "LegendaryBook.Neigong.DaYing"));
		_dataArray.Add(new LegendaryBookSlotItem(4, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_4"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_4"), "LegendaryBook.Neigong.DaCheng"));
		_dataArray.Add(new LegendaryBookSlotItem(5, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_5"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_5"), "LegendaryBook.Neigong.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(6, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_6"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_6"), "LegendaryBook.Neigong.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(7, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_7"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_7"), null));
		_dataArray.Add(new LegendaryBookSlotItem(8, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_8"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_8"), null));
		_dataArray.Add(new LegendaryBookSlotItem(9, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_9"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_9"), null));
		_dataArray.Add(new LegendaryBookSlotItem(10, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_10"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_10"), null));
		_dataArray.Add(new LegendaryBookSlotItem(11, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_11"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_11"), "LegendaryBook.Posing.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(12, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_12"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_12"), "LegendaryBook.Posing.FengShen"));
		_dataArray.Add(new LegendaryBookSlotItem(13, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_13"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_13"), "LegendaryBook.Posing.YunYong"));
		_dataArray.Add(new LegendaryBookSlotItem(14, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_14"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_14"), "LegendaryBook.Posing.JingShui"));
		_dataArray.Add(new LegendaryBookSlotItem(15, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_15"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_15"), "LegendaryBook.Posing.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(16, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_16"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_16"), "LegendaryBook.Posing.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(17, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_17"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_17"), null));
		_dataArray.Add(new LegendaryBookSlotItem(18, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_18"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_18"), null));
		_dataArray.Add(new LegendaryBookSlotItem(19, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_19"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_19"), null));
		_dataArray.Add(new LegendaryBookSlotItem(20, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_20"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_20"), null));
		_dataArray.Add(new LegendaryBookSlotItem(21, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_21"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_21"), "LegendaryBook.Stunt.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(22, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_22"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_22"), "LegendaryBook.Stunt.YuanLiu"));
		_dataArray.Add(new LegendaryBookSlotItem(23, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_23"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_23"), "LegendaryBook.Stunt.ChaNa"));
		_dataArray.Add(new LegendaryBookSlotItem(24, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_24"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_24"), "LegendaryBook.Stunt.ZhouQuan"));
		_dataArray.Add(new LegendaryBookSlotItem(25, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_25"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_25"), "LegendaryBook.Stunt.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(26, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_26"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_26"), "LegendaryBook.Stunt.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(27, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_27"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_27"), null));
		_dataArray.Add(new LegendaryBookSlotItem(28, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_28"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_28"), null));
		_dataArray.Add(new LegendaryBookSlotItem(29, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_29"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_29"), null));
		_dataArray.Add(new LegendaryBookSlotItem(30, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_30"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_30"), "LegendaryBook.FistAndPalm.KeDi"));
		_dataArray.Add(new LegendaryBookSlotItem(31, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_31"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_31"), "LegendaryBook.FistAndPalm.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(32, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_32"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_32"), "LegendaryBook.FistAndPalm.JinSha"));
		_dataArray.Add(new LegendaryBookSlotItem(33, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_33"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_33"), "LegendaryBook.FistAndPalm.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(34, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_34"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_34"), "LegendaryBook.FistAndPalm.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(35, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_35"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_35"), "LegendaryBook.FistAndPalm.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(36, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_36"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_36"), null));
		_dataArray.Add(new LegendaryBookSlotItem(37, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_37"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_37"), null));
		_dataArray.Add(new LegendaryBookSlotItem(38, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_38"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_38"), null));
		_dataArray.Add(new LegendaryBookSlotItem(39, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_39"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_39"), null));
		_dataArray.Add(new LegendaryBookSlotItem(40, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_40"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_40"), "LegendaryBook.Finger.DuanXue"));
		_dataArray.Add(new LegendaryBookSlotItem(41, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_41"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_41"), "LegendaryBook.Finger.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(42, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_42"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_42"), "LegendaryBook.Finger.SiXue"));
		_dataArray.Add(new LegendaryBookSlotItem(43, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_43"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_43"), "LegendaryBook.Finger.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(44, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_44"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_44"), "LegendaryBook.Finger.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(45, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_45"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_45"), "LegendaryBook.Finger.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(46, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_46"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_46"), null));
		_dataArray.Add(new LegendaryBookSlotItem(47, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_47"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_47"), null));
		_dataArray.Add(new LegendaryBookSlotItem(48, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_48"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_48"), null));
		_dataArray.Add(new LegendaryBookSlotItem(49, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_49"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_49"), null));
		_dataArray.Add(new LegendaryBookSlotItem(50, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_50"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_50"), "LegendaryBook.Leg.BingZu"));
		_dataArray.Add(new LegendaryBookSlotItem(51, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_51"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_51"), "LegendaryBook.Leg.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(52, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_52"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_52"), "LegendaryBook.Leg.XianSha"));
		_dataArray.Add(new LegendaryBookSlotItem(53, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_53"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_53"), "LegendaryBook.Leg.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(54, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_54"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_54"), "LegendaryBook.Leg.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(55, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_55"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_55"), "LegendaryBook.Leg.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(56, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_56"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_56"), null));
		_dataArray.Add(new LegendaryBookSlotItem(57, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_57"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_57"), null));
		_dataArray.Add(new LegendaryBookSlotItem(58, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_58"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_58"), null));
		_dataArray.Add(new LegendaryBookSlotItem(59, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_59"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_59"), null));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new LegendaryBookSlotItem(60, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_60"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_60"), "LegendaryBook.Throw.AnSha"));
		_dataArray.Add(new LegendaryBookSlotItem(61, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_61"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_61"), "LegendaryBook.Throw.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(62, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_62"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_62"), "LegendaryBook.Throw.YuanSha"));
		_dataArray.Add(new LegendaryBookSlotItem(63, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_63"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_63"), "LegendaryBook.Throw.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(64, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_64"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_64"), "LegendaryBook.Throw.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(65, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_65"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_65"), "LegendaryBook.Throw.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(66, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_66"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_66"), null));
		_dataArray.Add(new LegendaryBookSlotItem(67, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_67"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_67"), null));
		_dataArray.Add(new LegendaryBookSlotItem(68, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_68"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_68"), null));
		_dataArray.Add(new LegendaryBookSlotItem(69, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_69"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_69"), null));
		_dataArray.Add(new LegendaryBookSlotItem(70, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_70"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_70"), "LegendaryBook.Sword.HuaXi"));
		_dataArray.Add(new LegendaryBookSlotItem(71, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_71"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_71"), "LegendaryBook.Sword.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(72, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_72"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_72"), "LegendaryBook.Sword.ShiSha"));
		_dataArray.Add(new LegendaryBookSlotItem(73, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_73"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_73"), "LegendaryBook.Sword.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(74, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_74"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_74"), "LegendaryBook.Sword.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(75, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_75"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_75"), "LegendaryBook.Sword.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(76, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_76"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_76"), null));
		_dataArray.Add(new LegendaryBookSlotItem(77, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_77"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_77"), null));
		_dataArray.Add(new LegendaryBookSlotItem(78, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_78"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_78"), null));
		_dataArray.Add(new LegendaryBookSlotItem(79, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_79"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_79"), null));
		_dataArray.Add(new LegendaryBookSlotItem(80, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_80"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_80"), "LegendaryBook.Blade.ZhenLie"));
		_dataArray.Add(new LegendaryBookSlotItem(81, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_81"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_81"), "LegendaryBook.Blade.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(82, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_82"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_82"), "LegendaryBook.Blade.PoSha"));
		_dataArray.Add(new LegendaryBookSlotItem(83, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_83"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_83"), "LegendaryBook.Blade.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(84, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_84"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_84"), "LegendaryBook.Blade.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(85, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_85"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_85"), "LegendaryBook.Blade.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(86, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_86"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_86"), null));
		_dataArray.Add(new LegendaryBookSlotItem(87, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_87"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_87"), null));
		_dataArray.Add(new LegendaryBookSlotItem(88, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_88"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_88"), null));
		_dataArray.Add(new LegendaryBookSlotItem(89, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_89"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_89"), null));
		_dataArray.Add(new LegendaryBookSlotItem(90, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_90"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_90"), "LegendaryBook.Polearm.ChuangZhen"));
		_dataArray.Add(new LegendaryBookSlotItem(91, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_91"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_91"), "LegendaryBook.Polearm.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(92, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_92"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_92"), "LegendaryBook.Polearm.JueDou"));
		_dataArray.Add(new LegendaryBookSlotItem(93, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_93"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_93"), "LegendaryBook.Polearm.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(94, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_94"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_94"), "LegendaryBook.Polearm.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(95, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_95"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_95"), "LegendaryBook.Polearm.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(96, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_96"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_96"), null));
		_dataArray.Add(new LegendaryBookSlotItem(97, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_97"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_97"), null));
		_dataArray.Add(new LegendaryBookSlotItem(98, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_98"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_98"), null));
		_dataArray.Add(new LegendaryBookSlotItem(99, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_99"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_99"), null));
		_dataArray.Add(new LegendaryBookSlotItem(100, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_100"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_100"), "LegendaryBook.Special.GuiJi"));
		_dataArray.Add(new LegendaryBookSlotItem(101, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_101"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_101"), "LegendaryBook.Special.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(102, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_102"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_102"), "LegendaryBook.Special.QiShi"));
		_dataArray.Add(new LegendaryBookSlotItem(103, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_103"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_103"), "LegendaryBook.Special.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(104, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_104"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_104"), "LegendaryBook.Special.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(105, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_105"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_105"), "LegendaryBook.Special.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(106, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_106"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_106"), null));
		_dataArray.Add(new LegendaryBookSlotItem(107, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_107"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_107"), null));
		_dataArray.Add(new LegendaryBookSlotItem(108, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_108"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_108"), null));
		_dataArray.Add(new LegendaryBookSlotItem(109, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_109"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_109"), null));
		_dataArray.Add(new LegendaryBookSlotItem(110, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_110"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_110"), "LegendaryBook.Whip.YanSheng"));
		_dataArray.Add(new LegendaryBookSlotItem(111, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_111"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_111"), "LegendaryBook.Whip.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(112, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_112"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_112"), "LegendaryBook.Whip.JieQi"));
		_dataArray.Add(new LegendaryBookSlotItem(113, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_113"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_113"), "LegendaryBook.Whip.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(114, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_114"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_114"), "LegendaryBook.Whip.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(115, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_115"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_115"), "LegendaryBook.Whip.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(116, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_116"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_116"), null));
		_dataArray.Add(new LegendaryBookSlotItem(117, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_117"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_117"), null));
		_dataArray.Add(new LegendaryBookSlotItem(118, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_118"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_118"), null));
		_dataArray.Add(new LegendaryBookSlotItem(119, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_119"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_119"), null));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new LegendaryBookSlotItem(120, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_120"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_120"), "LegendaryBook.ControllableShot.QiBian"));
		_dataArray.Add(new LegendaryBookSlotItem(121, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_121"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_121"), "LegendaryBook.ControllableShot.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(122, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_122"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_122"), "LegendaryBook.ControllableShot.BianJie"));
		_dataArray.Add(new LegendaryBookSlotItem(123, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_123"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_123"), "LegendaryBook.ControllableShot.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(124, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_124"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_124"), "LegendaryBook.ControllableShot.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(125, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_125"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_125"), "LegendaryBook.ControllableShot.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(126, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_126"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_126"), null));
		_dataArray.Add(new LegendaryBookSlotItem(127, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_127"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_127"), null));
		_dataArray.Add(new LegendaryBookSlotItem(128, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_128"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_128"), null));
		_dataArray.Add(new LegendaryBookSlotItem(129, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_129"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_129"), null));
		_dataArray.Add(new LegendaryBookSlotItem(130, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_130"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_130"), "LegendaryBook.CombatMusic.LuanXin"));
		_dataArray.Add(new LegendaryBookSlotItem(131, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_131"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_131"), "LegendaryBook.CombatMusic.ZhuanJie"));
		_dataArray.Add(new LegendaryBookSlotItem(132, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_132"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_132"), "LegendaryBook.CombatMusic.KuangSheng"));
		_dataArray.Add(new LegendaryBookSlotItem(133, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_133"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_133"), "LegendaryBook.CombatMusic.JiePo"));
		_dataArray.Add(new LegendaryBookSlotItem(134, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_134"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_134"), "LegendaryBook.CombatMusic.JueZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(135, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_135"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_135"), "LegendaryBook.CombatMusic.ShouZhi"));
		_dataArray.Add(new LegendaryBookSlotItem(136, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_136"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_136"), null));
		_dataArray.Add(new LegendaryBookSlotItem(137, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_137"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_137"), null));
		_dataArray.Add(new LegendaryBookSlotItem(138, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_138"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_138"), null));
		_dataArray.Add(new LegendaryBookSlotItem(139, LocalStringManager.GetConfig("LegendaryBookSlot_language", "Name_139"), LocalStringManager.GetConfig("LegendaryBookSlot_language", "Desc_139"), null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LegendaryBookSlotItem>(140);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
