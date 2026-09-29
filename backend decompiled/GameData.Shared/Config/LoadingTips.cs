using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LoadingTips : ConfigData<LoadingTipsItem, int>
{
	public static class DefKey
	{
		public const int PoemBegin = 0;

		public const int PoemEnd = 59;

		public const int CommonTipsBegin = 60;

		public const int CommonTipsEnd = 91;
	}

	public static class DefValue
	{
		public static LoadingTipsItem PoemBegin => Instance[0];

		public static LoadingTipsItem PoemEnd => Instance[59];

		public static LoadingTipsItem CommonTipsBegin => Instance[60];

		public static LoadingTipsItem CommonTipsEnd => Instance[91];
	}

	public static LoadingTips Instance = new LoadingTips();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Title", "Content", "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new LoadingTipsItem(0, LocalStringManager.GetConfig("LoadingTips_language", "Title_0"), LocalStringManager.GetConfig("LoadingTips_language", "Content_0")));
		_dataArray.Add(new LoadingTipsItem(1, LocalStringManager.GetConfig("LoadingTips_language", "Title_1"), LocalStringManager.GetConfig("LoadingTips_language", "Content_1")));
		_dataArray.Add(new LoadingTipsItem(2, LocalStringManager.GetConfig("LoadingTips_language", "Title_2"), LocalStringManager.GetConfig("LoadingTips_language", "Content_2")));
		_dataArray.Add(new LoadingTipsItem(3, LocalStringManager.GetConfig("LoadingTips_language", "Title_3"), LocalStringManager.GetConfig("LoadingTips_language", "Content_3")));
		_dataArray.Add(new LoadingTipsItem(4, LocalStringManager.GetConfig("LoadingTips_language", "Title_4"), LocalStringManager.GetConfig("LoadingTips_language", "Content_4")));
		_dataArray.Add(new LoadingTipsItem(5, LocalStringManager.GetConfig("LoadingTips_language", "Title_5"), LocalStringManager.GetConfig("LoadingTips_language", "Content_5")));
		_dataArray.Add(new LoadingTipsItem(6, LocalStringManager.GetConfig("LoadingTips_language", "Title_6"), LocalStringManager.GetConfig("LoadingTips_language", "Content_6")));
		_dataArray.Add(new LoadingTipsItem(7, LocalStringManager.GetConfig("LoadingTips_language", "Title_7"), LocalStringManager.GetConfig("LoadingTips_language", "Content_7")));
		_dataArray.Add(new LoadingTipsItem(8, LocalStringManager.GetConfig("LoadingTips_language", "Title_8"), LocalStringManager.GetConfig("LoadingTips_language", "Content_8")));
		_dataArray.Add(new LoadingTipsItem(9, LocalStringManager.GetConfig("LoadingTips_language", "Title_9"), LocalStringManager.GetConfig("LoadingTips_language", "Content_9")));
		_dataArray.Add(new LoadingTipsItem(10, LocalStringManager.GetConfig("LoadingTips_language", "Title_10"), LocalStringManager.GetConfig("LoadingTips_language", "Content_10")));
		_dataArray.Add(new LoadingTipsItem(11, LocalStringManager.GetConfig("LoadingTips_language", "Title_11"), LocalStringManager.GetConfig("LoadingTips_language", "Content_11")));
		_dataArray.Add(new LoadingTipsItem(12, LocalStringManager.GetConfig("LoadingTips_language", "Title_12"), LocalStringManager.GetConfig("LoadingTips_language", "Content_12")));
		_dataArray.Add(new LoadingTipsItem(13, LocalStringManager.GetConfig("LoadingTips_language", "Title_13"), LocalStringManager.GetConfig("LoadingTips_language", "Content_13")));
		_dataArray.Add(new LoadingTipsItem(14, LocalStringManager.GetConfig("LoadingTips_language", "Title_14"), LocalStringManager.GetConfig("LoadingTips_language", "Content_14")));
		_dataArray.Add(new LoadingTipsItem(15, LocalStringManager.GetConfig("LoadingTips_language", "Title_15"), LocalStringManager.GetConfig("LoadingTips_language", "Content_15")));
		_dataArray.Add(new LoadingTipsItem(16, LocalStringManager.GetConfig("LoadingTips_language", "Title_16"), LocalStringManager.GetConfig("LoadingTips_language", "Content_16")));
		_dataArray.Add(new LoadingTipsItem(17, LocalStringManager.GetConfig("LoadingTips_language", "Title_17"), LocalStringManager.GetConfig("LoadingTips_language", "Content_17")));
		_dataArray.Add(new LoadingTipsItem(18, LocalStringManager.GetConfig("LoadingTips_language", "Title_18"), LocalStringManager.GetConfig("LoadingTips_language", "Content_18")));
		_dataArray.Add(new LoadingTipsItem(19, LocalStringManager.GetConfig("LoadingTips_language", "Title_19"), LocalStringManager.GetConfig("LoadingTips_language", "Content_19")));
		_dataArray.Add(new LoadingTipsItem(20, LocalStringManager.GetConfig("LoadingTips_language", "Title_20"), LocalStringManager.GetConfig("LoadingTips_language", "Content_20")));
		_dataArray.Add(new LoadingTipsItem(21, LocalStringManager.GetConfig("LoadingTips_language", "Title_21"), LocalStringManager.GetConfig("LoadingTips_language", "Content_21")));
		_dataArray.Add(new LoadingTipsItem(22, LocalStringManager.GetConfig("LoadingTips_language", "Title_22"), LocalStringManager.GetConfig("LoadingTips_language", "Content_22")));
		_dataArray.Add(new LoadingTipsItem(23, LocalStringManager.GetConfig("LoadingTips_language", "Title_23"), LocalStringManager.GetConfig("LoadingTips_language", "Content_23")));
		_dataArray.Add(new LoadingTipsItem(24, LocalStringManager.GetConfig("LoadingTips_language", "Title_24"), LocalStringManager.GetConfig("LoadingTips_language", "Content_24")));
		_dataArray.Add(new LoadingTipsItem(25, LocalStringManager.GetConfig("LoadingTips_language", "Title_25"), LocalStringManager.GetConfig("LoadingTips_language", "Content_25")));
		_dataArray.Add(new LoadingTipsItem(26, LocalStringManager.GetConfig("LoadingTips_language", "Title_26"), LocalStringManager.GetConfig("LoadingTips_language", "Content_26")));
		_dataArray.Add(new LoadingTipsItem(27, LocalStringManager.GetConfig("LoadingTips_language", "Title_27"), LocalStringManager.GetConfig("LoadingTips_language", "Content_27")));
		_dataArray.Add(new LoadingTipsItem(28, LocalStringManager.GetConfig("LoadingTips_language", "Title_28"), LocalStringManager.GetConfig("LoadingTips_language", "Content_28")));
		_dataArray.Add(new LoadingTipsItem(29, LocalStringManager.GetConfig("LoadingTips_language", "Title_29"), LocalStringManager.GetConfig("LoadingTips_language", "Content_29")));
		_dataArray.Add(new LoadingTipsItem(30, LocalStringManager.GetConfig("LoadingTips_language", "Title_30"), LocalStringManager.GetConfig("LoadingTips_language", "Content_30")));
		_dataArray.Add(new LoadingTipsItem(31, LocalStringManager.GetConfig("LoadingTips_language", "Title_31"), LocalStringManager.GetConfig("LoadingTips_language", "Content_31")));
		_dataArray.Add(new LoadingTipsItem(32, LocalStringManager.GetConfig("LoadingTips_language", "Title_32"), LocalStringManager.GetConfig("LoadingTips_language", "Content_32")));
		_dataArray.Add(new LoadingTipsItem(33, LocalStringManager.GetConfig("LoadingTips_language", "Title_33"), LocalStringManager.GetConfig("LoadingTips_language", "Content_33")));
		_dataArray.Add(new LoadingTipsItem(34, LocalStringManager.GetConfig("LoadingTips_language", "Title_34"), LocalStringManager.GetConfig("LoadingTips_language", "Content_34")));
		_dataArray.Add(new LoadingTipsItem(35, LocalStringManager.GetConfig("LoadingTips_language", "Title_35"), LocalStringManager.GetConfig("LoadingTips_language", "Content_35")));
		_dataArray.Add(new LoadingTipsItem(36, LocalStringManager.GetConfig("LoadingTips_language", "Title_36"), LocalStringManager.GetConfig("LoadingTips_language", "Content_36")));
		_dataArray.Add(new LoadingTipsItem(37, LocalStringManager.GetConfig("LoadingTips_language", "Title_37"), LocalStringManager.GetConfig("LoadingTips_language", "Content_37")));
		_dataArray.Add(new LoadingTipsItem(38, LocalStringManager.GetConfig("LoadingTips_language", "Title_38"), LocalStringManager.GetConfig("LoadingTips_language", "Content_38")));
		_dataArray.Add(new LoadingTipsItem(39, LocalStringManager.GetConfig("LoadingTips_language", "Title_39"), LocalStringManager.GetConfig("LoadingTips_language", "Content_39")));
		_dataArray.Add(new LoadingTipsItem(40, LocalStringManager.GetConfig("LoadingTips_language", "Title_40"), LocalStringManager.GetConfig("LoadingTips_language", "Content_40")));
		_dataArray.Add(new LoadingTipsItem(41, LocalStringManager.GetConfig("LoadingTips_language", "Title_41"), LocalStringManager.GetConfig("LoadingTips_language", "Content_41")));
		_dataArray.Add(new LoadingTipsItem(42, LocalStringManager.GetConfig("LoadingTips_language", "Title_42"), LocalStringManager.GetConfig("LoadingTips_language", "Content_42")));
		_dataArray.Add(new LoadingTipsItem(43, LocalStringManager.GetConfig("LoadingTips_language", "Title_43"), LocalStringManager.GetConfig("LoadingTips_language", "Content_43")));
		_dataArray.Add(new LoadingTipsItem(44, LocalStringManager.GetConfig("LoadingTips_language", "Title_44"), LocalStringManager.GetConfig("LoadingTips_language", "Content_44")));
		_dataArray.Add(new LoadingTipsItem(45, LocalStringManager.GetConfig("LoadingTips_language", "Title_45"), LocalStringManager.GetConfig("LoadingTips_language", "Content_45")));
		_dataArray.Add(new LoadingTipsItem(46, LocalStringManager.GetConfig("LoadingTips_language", "Title_46"), LocalStringManager.GetConfig("LoadingTips_language", "Content_46")));
		_dataArray.Add(new LoadingTipsItem(47, LocalStringManager.GetConfig("LoadingTips_language", "Title_47"), LocalStringManager.GetConfig("LoadingTips_language", "Content_47")));
		_dataArray.Add(new LoadingTipsItem(48, LocalStringManager.GetConfig("LoadingTips_language", "Title_48"), LocalStringManager.GetConfig("LoadingTips_language", "Content_48")));
		_dataArray.Add(new LoadingTipsItem(49, LocalStringManager.GetConfig("LoadingTips_language", "Title_49"), LocalStringManager.GetConfig("LoadingTips_language", "Content_49")));
		_dataArray.Add(new LoadingTipsItem(50, LocalStringManager.GetConfig("LoadingTips_language", "Title_50"), LocalStringManager.GetConfig("LoadingTips_language", "Content_50")));
		_dataArray.Add(new LoadingTipsItem(51, LocalStringManager.GetConfig("LoadingTips_language", "Title_51"), LocalStringManager.GetConfig("LoadingTips_language", "Content_51")));
		_dataArray.Add(new LoadingTipsItem(52, LocalStringManager.GetConfig("LoadingTips_language", "Title_52"), LocalStringManager.GetConfig("LoadingTips_language", "Content_52")));
		_dataArray.Add(new LoadingTipsItem(53, LocalStringManager.GetConfig("LoadingTips_language", "Title_53"), LocalStringManager.GetConfig("LoadingTips_language", "Content_53")));
		_dataArray.Add(new LoadingTipsItem(54, LocalStringManager.GetConfig("LoadingTips_language", "Title_54"), LocalStringManager.GetConfig("LoadingTips_language", "Content_54")));
		_dataArray.Add(new LoadingTipsItem(55, LocalStringManager.GetConfig("LoadingTips_language", "Title_55"), LocalStringManager.GetConfig("LoadingTips_language", "Content_55")));
		_dataArray.Add(new LoadingTipsItem(56, LocalStringManager.GetConfig("LoadingTips_language", "Title_56"), LocalStringManager.GetConfig("LoadingTips_language", "Content_56")));
		_dataArray.Add(new LoadingTipsItem(57, LocalStringManager.GetConfig("LoadingTips_language", "Title_57"), LocalStringManager.GetConfig("LoadingTips_language", "Content_57")));
		_dataArray.Add(new LoadingTipsItem(58, LocalStringManager.GetConfig("LoadingTips_language", "Title_58"), LocalStringManager.GetConfig("LoadingTips_language", "Content_58")));
		_dataArray.Add(new LoadingTipsItem(59, LocalStringManager.GetConfig("LoadingTips_language", "Title_59"), LocalStringManager.GetConfig("LoadingTips_language", "Content_59")));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new LoadingTipsItem(60, LocalStringManager.GetConfig("LoadingTips_language", "Title_60"), LocalStringManager.GetConfig("LoadingTips_language", "Content_60")));
		_dataArray.Add(new LoadingTipsItem(61, LocalStringManager.GetConfig("LoadingTips_language", "Title_61"), LocalStringManager.GetConfig("LoadingTips_language", "Content_61")));
		_dataArray.Add(new LoadingTipsItem(62, LocalStringManager.GetConfig("LoadingTips_language", "Title_62"), LocalStringManager.GetConfig("LoadingTips_language", "Content_62")));
		_dataArray.Add(new LoadingTipsItem(63, LocalStringManager.GetConfig("LoadingTips_language", "Title_63"), LocalStringManager.GetConfig("LoadingTips_language", "Content_63")));
		_dataArray.Add(new LoadingTipsItem(64, LocalStringManager.GetConfig("LoadingTips_language", "Title_64"), LocalStringManager.GetConfig("LoadingTips_language", "Content_64")));
		_dataArray.Add(new LoadingTipsItem(65, LocalStringManager.GetConfig("LoadingTips_language", "Title_65"), LocalStringManager.GetConfig("LoadingTips_language", "Content_65")));
		_dataArray.Add(new LoadingTipsItem(66, LocalStringManager.GetConfig("LoadingTips_language", "Title_66"), LocalStringManager.GetConfig("LoadingTips_language", "Content_66")));
		_dataArray.Add(new LoadingTipsItem(67, LocalStringManager.GetConfig("LoadingTips_language", "Title_67"), LocalStringManager.GetConfig("LoadingTips_language", "Content_67")));
		_dataArray.Add(new LoadingTipsItem(68, LocalStringManager.GetConfig("LoadingTips_language", "Title_68"), LocalStringManager.GetConfig("LoadingTips_language", "Content_68")));
		_dataArray.Add(new LoadingTipsItem(69, LocalStringManager.GetConfig("LoadingTips_language", "Title_69"), LocalStringManager.GetConfig("LoadingTips_language", "Content_69")));
		_dataArray.Add(new LoadingTipsItem(70, LocalStringManager.GetConfig("LoadingTips_language", "Title_70"), LocalStringManager.GetConfig("LoadingTips_language", "Content_70")));
		_dataArray.Add(new LoadingTipsItem(71, LocalStringManager.GetConfig("LoadingTips_language", "Title_71"), LocalStringManager.GetConfig("LoadingTips_language", "Content_71")));
		_dataArray.Add(new LoadingTipsItem(72, LocalStringManager.GetConfig("LoadingTips_language", "Title_72"), LocalStringManager.GetConfig("LoadingTips_language", "Content_72")));
		_dataArray.Add(new LoadingTipsItem(73, LocalStringManager.GetConfig("LoadingTips_language", "Title_73"), LocalStringManager.GetConfig("LoadingTips_language", "Content_73")));
		_dataArray.Add(new LoadingTipsItem(74, LocalStringManager.GetConfig("LoadingTips_language", "Title_74"), LocalStringManager.GetConfig("LoadingTips_language", "Content_74")));
		_dataArray.Add(new LoadingTipsItem(75, LocalStringManager.GetConfig("LoadingTips_language", "Title_75"), LocalStringManager.GetConfig("LoadingTips_language", "Content_75")));
		_dataArray.Add(new LoadingTipsItem(76, LocalStringManager.GetConfig("LoadingTips_language", "Title_76"), LocalStringManager.GetConfig("LoadingTips_language", "Content_76")));
		_dataArray.Add(new LoadingTipsItem(77, LocalStringManager.GetConfig("LoadingTips_language", "Title_77"), LocalStringManager.GetConfig("LoadingTips_language", "Content_77")));
		_dataArray.Add(new LoadingTipsItem(78, LocalStringManager.GetConfig("LoadingTips_language", "Title_78"), LocalStringManager.GetConfig("LoadingTips_language", "Content_78")));
		_dataArray.Add(new LoadingTipsItem(79, LocalStringManager.GetConfig("LoadingTips_language", "Title_79"), LocalStringManager.GetConfig("LoadingTips_language", "Content_79")));
		_dataArray.Add(new LoadingTipsItem(80, LocalStringManager.GetConfig("LoadingTips_language", "Title_80"), LocalStringManager.GetConfig("LoadingTips_language", "Content_80")));
		_dataArray.Add(new LoadingTipsItem(81, LocalStringManager.GetConfig("LoadingTips_language", "Title_81"), LocalStringManager.GetConfig("LoadingTips_language", "Content_81")));
		_dataArray.Add(new LoadingTipsItem(82, LocalStringManager.GetConfig("LoadingTips_language", "Title_82"), LocalStringManager.GetConfig("LoadingTips_language", "Content_82")));
		_dataArray.Add(new LoadingTipsItem(83, LocalStringManager.GetConfig("LoadingTips_language", "Title_83"), LocalStringManager.GetConfig("LoadingTips_language", "Content_83")));
		_dataArray.Add(new LoadingTipsItem(84, LocalStringManager.GetConfig("LoadingTips_language", "Title_84"), LocalStringManager.GetConfig("LoadingTips_language", "Content_84")));
		_dataArray.Add(new LoadingTipsItem(85, LocalStringManager.GetConfig("LoadingTips_language", "Title_85"), LocalStringManager.GetConfig("LoadingTips_language", "Content_85")));
		_dataArray.Add(new LoadingTipsItem(86, LocalStringManager.GetConfig("LoadingTips_language", "Title_86"), LocalStringManager.GetConfig("LoadingTips_language", "Content_86")));
		_dataArray.Add(new LoadingTipsItem(87, LocalStringManager.GetConfig("LoadingTips_language", "Title_87"), LocalStringManager.GetConfig("LoadingTips_language", "Content_87")));
		_dataArray.Add(new LoadingTipsItem(88, LocalStringManager.GetConfig("LoadingTips_language", "Title_88"), LocalStringManager.GetConfig("LoadingTips_language", "Content_88")));
		_dataArray.Add(new LoadingTipsItem(89, LocalStringManager.GetConfig("LoadingTips_language", "Title_89"), LocalStringManager.GetConfig("LoadingTips_language", "Content_89")));
		_dataArray.Add(new LoadingTipsItem(90, LocalStringManager.GetConfig("LoadingTips_language", "Title_90"), LocalStringManager.GetConfig("LoadingTips_language", "Content_90")));
		_dataArray.Add(new LoadingTipsItem(91, LocalStringManager.GetConfig("LoadingTips_language", "Title_91"), LocalStringManager.GetConfig("LoadingTips_language", "Content_91")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LoadingTipsItem>(92);
		CreateItems0();
		CreateItems1();
	}
}
