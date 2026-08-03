using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Chicken : ConfigData<ChickenItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 大王
		/// </summary>
		public const short King = 63;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 大王
		/// </summary>
		public static ChickenItem King => Instance[(short)63];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Chicken Instance = new Chicken();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "PersonalityType", "FeatureId", "EventActorTemplateId", "EventDesc", "TemplateId", "Display", "Grade", "PersonalityValue",
		"ChickenColor"
	};

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
		_dataArray.Add(new ChickenItem(0, LocalStringManager.GetConfig("Chicken_language", "Name_0"), LocalStringManager.GetConfig("Chicken_language", "Desc_0"), "tex_chicken_clever0", 0, 1, 1, 386, 207, LocalStringManager.GetConfig("Chicken_language", "EventDesc_0"), EChickenChickenColor.hui));
		_dataArray.Add(new ChickenItem(1, LocalStringManager.GetConfig("Chicken_language", "Name_1"), LocalStringManager.GetConfig("Chicken_language", "Desc_1"), "tex_chicken_clever1", 1, 1, 2, 387, 208, LocalStringManager.GetConfig("Chicken_language", "EventDesc_1"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(2, LocalStringManager.GetConfig("Chicken_language", "Name_2"), LocalStringManager.GetConfig("Chicken_language", "Desc_2"), "tex_chicken_clever2", 2, 1, 3, 388, 209, LocalStringManager.GetConfig("Chicken_language", "EventDesc_2"), EChickenChickenColor.cai));
		_dataArray.Add(new ChickenItem(3, LocalStringManager.GetConfig("Chicken_language", "Name_3"), LocalStringManager.GetConfig("Chicken_language", "Desc_3"), "tex_chicken_clever3", 3, 1, 5, 389, 210, LocalStringManager.GetConfig("Chicken_language", "EventDesc_3"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(4, LocalStringManager.GetConfig("Chicken_language", "Name_4"), LocalStringManager.GetConfig("Chicken_language", "Desc_4"), "tex_chicken_clever4", 4, 1, 7, 390, 211, LocalStringManager.GetConfig("Chicken_language", "EventDesc_4"), EChickenChickenColor.lan));
		_dataArray.Add(new ChickenItem(5, LocalStringManager.GetConfig("Chicken_language", "Name_5"), LocalStringManager.GetConfig("Chicken_language", "Desc_5"), "tex_chicken_clever5", 5, 1, 9, 391, 212, LocalStringManager.GetConfig("Chicken_language", "EventDesc_5"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(6, LocalStringManager.GetConfig("Chicken_language", "Name_6"), LocalStringManager.GetConfig("Chicken_language", "Desc_6"), "tex_chicken_clever6", 6, 1, 12, 392, 213, LocalStringManager.GetConfig("Chicken_language", "EventDesc_6"), EChickenChickenColor.lan));
		_dataArray.Add(new ChickenItem(7, LocalStringManager.GetConfig("Chicken_language", "Name_7"), LocalStringManager.GetConfig("Chicken_language", "Desc_7"), "tex_chicken_clever7", 7, 1, 15, 393, 214, LocalStringManager.GetConfig("Chicken_language", "EventDesc_7"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(8, LocalStringManager.GetConfig("Chicken_language", "Name_8"), LocalStringManager.GetConfig("Chicken_language", "Desc_8"), "tex_chicken_clever8", 8, 1, 18, 394, 215, LocalStringManager.GetConfig("Chicken_language", "EventDesc_8"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(9, LocalStringManager.GetConfig("Chicken_language", "Name_9"), LocalStringManager.GetConfig("Chicken_language", "Desc_9"), "tex_chicken_lucky0", 0, 5, 1, 395, 216, LocalStringManager.GetConfig("Chicken_language", "EventDesc_9"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(10, LocalStringManager.GetConfig("Chicken_language", "Name_10"), LocalStringManager.GetConfig("Chicken_language", "Desc_10"), "tex_chicken_lucky1", 1, 5, 2, 396, 217, LocalStringManager.GetConfig("Chicken_language", "EventDesc_10"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(11, LocalStringManager.GetConfig("Chicken_language", "Name_11"), LocalStringManager.GetConfig("Chicken_language", "Desc_11"), "tex_chicken_lucky2", 2, 5, 3, 397, 218, LocalStringManager.GetConfig("Chicken_language", "EventDesc_11"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(12, LocalStringManager.GetConfig("Chicken_language", "Name_12"), LocalStringManager.GetConfig("Chicken_language", "Desc_12"), "tex_chicken_lucky3", 3, 5, 5, 398, 219, LocalStringManager.GetConfig("Chicken_language", "EventDesc_12"), EChickenChickenColor.bai));
		_dataArray.Add(new ChickenItem(13, LocalStringManager.GetConfig("Chicken_language", "Name_13"), LocalStringManager.GetConfig("Chicken_language", "Desc_13"), "tex_chicken_lucky4", 4, 5, 7, 399, 220, LocalStringManager.GetConfig("Chicken_language", "EventDesc_13"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(14, LocalStringManager.GetConfig("Chicken_language", "Name_14"), LocalStringManager.GetConfig("Chicken_language", "Desc_14"), "tex_chicken_lucky5", 5, 5, 9, 400, 221, LocalStringManager.GetConfig("Chicken_language", "EventDesc_14"), EChickenChickenColor.cai));
		_dataArray.Add(new ChickenItem(15, LocalStringManager.GetConfig("Chicken_language", "Name_15"), LocalStringManager.GetConfig("Chicken_language", "Desc_15"), "tex_chicken_lucky6", 6, 5, 12, 401, 222, LocalStringManager.GetConfig("Chicken_language", "EventDesc_15"), EChickenChickenColor.cai));
		_dataArray.Add(new ChickenItem(16, LocalStringManager.GetConfig("Chicken_language", "Name_16"), LocalStringManager.GetConfig("Chicken_language", "Desc_16"), "tex_chicken_lucky7", 7, 5, 15, 402, 223, LocalStringManager.GetConfig("Chicken_language", "EventDesc_16"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(17, LocalStringManager.GetConfig("Chicken_language", "Name_17"), LocalStringManager.GetConfig("Chicken_language", "Desc_17"), "tex_chicken_lucky8", 8, 5, 18, 403, 224, LocalStringManager.GetConfig("Chicken_language", "EventDesc_17"), EChickenChickenColor.heilv));
		_dataArray.Add(new ChickenItem(18, LocalStringManager.GetConfig("Chicken_language", "Name_18"), LocalStringManager.GetConfig("Chicken_language", "Desc_18"), "tex_chicken_perceptive0", 0, 6, 1, 404, 225, LocalStringManager.GetConfig("Chicken_language", "EventDesc_18"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(19, LocalStringManager.GetConfig("Chicken_language", "Name_19"), LocalStringManager.GetConfig("Chicken_language", "Desc_19"), "tex_chicken_perceptive1", 1, 6, 2, 405, 226, LocalStringManager.GetConfig("Chicken_language", "EventDesc_19"), EChickenChickenColor.qing));
		_dataArray.Add(new ChickenItem(20, LocalStringManager.GetConfig("Chicken_language", "Name_20"), LocalStringManager.GetConfig("Chicken_language", "Desc_20"), "tex_chicken_perceptive2", 2, 6, 3, 406, 227, LocalStringManager.GetConfig("Chicken_language", "EventDesc_20"), EChickenChickenColor.bai));
		_dataArray.Add(new ChickenItem(21, LocalStringManager.GetConfig("Chicken_language", "Name_21"), LocalStringManager.GetConfig("Chicken_language", "Desc_21"), "tex_chicken_perceptive3", 3, 6, 5, 407, 228, LocalStringManager.GetConfig("Chicken_language", "EventDesc_21"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(22, LocalStringManager.GetConfig("Chicken_language", "Name_22"), LocalStringManager.GetConfig("Chicken_language", "Desc_22"), "tex_chicken_perceptive4", 4, 6, 7, 408, 229, LocalStringManager.GetConfig("Chicken_language", "EventDesc_22"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(23, LocalStringManager.GetConfig("Chicken_language", "Name_23"), LocalStringManager.GetConfig("Chicken_language", "Desc_23"), "tex_chicken_perceptive5", 5, 6, 9, 409, 230, LocalStringManager.GetConfig("Chicken_language", "EventDesc_23"), EChickenChickenColor.hui));
		_dataArray.Add(new ChickenItem(24, LocalStringManager.GetConfig("Chicken_language", "Name_24"), LocalStringManager.GetConfig("Chicken_language", "Desc_24"), "tex_chicken_perceptive6", 6, 6, 12, 410, 231, LocalStringManager.GetConfig("Chicken_language", "EventDesc_24"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(25, LocalStringManager.GetConfig("Chicken_language", "Name_25"), LocalStringManager.GetConfig("Chicken_language", "Desc_25"), "tex_chicken_perceptive7", 7, 6, 15, 411, 232, LocalStringManager.GetConfig("Chicken_language", "EventDesc_25"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(26, LocalStringManager.GetConfig("Chicken_language", "Name_26"), LocalStringManager.GetConfig("Chicken_language", "Desc_26"), "tex_chicken_perceptive8", 8, 6, 18, 412, 233, LocalStringManager.GetConfig("Chicken_language", "EventDesc_26"), EChickenChickenColor.cai));
		_dataArray.Add(new ChickenItem(27, LocalStringManager.GetConfig("Chicken_language", "Name_27"), LocalStringManager.GetConfig("Chicken_language", "Desc_27"), "tex_chicken_firm0", 0, 4, 1, 413, 234, LocalStringManager.GetConfig("Chicken_language", "EventDesc_27"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(28, LocalStringManager.GetConfig("Chicken_language", "Name_28"), LocalStringManager.GetConfig("Chicken_language", "Desc_28"), "tex_chicken_firm1", 1, 4, 2, 414, 235, LocalStringManager.GetConfig("Chicken_language", "EventDesc_28"), EChickenChickenColor.hui));
		_dataArray.Add(new ChickenItem(29, LocalStringManager.GetConfig("Chicken_language", "Name_29"), LocalStringManager.GetConfig("Chicken_language", "Desc_29"), "tex_chicken_firm2", 2, 4, 3, 415, 236, LocalStringManager.GetConfig("Chicken_language", "EventDesc_29"), EChickenChickenColor.cai));
		_dataArray.Add(new ChickenItem(30, LocalStringManager.GetConfig("Chicken_language", "Name_30"), LocalStringManager.GetConfig("Chicken_language", "Desc_30"), "tex_chicken_firm3", 3, 4, 5, 416, 237, LocalStringManager.GetConfig("Chicken_language", "EventDesc_30"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(31, LocalStringManager.GetConfig("Chicken_language", "Name_31"), LocalStringManager.GetConfig("Chicken_language", "Desc_31"), "tex_chicken_firm4", 4, 4, 7, 417, 238, LocalStringManager.GetConfig("Chicken_language", "EventDesc_31"), EChickenChickenColor.bai));
		_dataArray.Add(new ChickenItem(32, LocalStringManager.GetConfig("Chicken_language", "Name_32"), LocalStringManager.GetConfig("Chicken_language", "Desc_32"), "tex_chicken_firm5", 5, 4, 9, 418, 239, LocalStringManager.GetConfig("Chicken_language", "EventDesc_32"), EChickenChickenColor.bai));
		_dataArray.Add(new ChickenItem(33, LocalStringManager.GetConfig("Chicken_language", "Name_33"), LocalStringManager.GetConfig("Chicken_language", "Desc_33"), "tex_chicken_firm6", 6, 4, 12, 419, 240, LocalStringManager.GetConfig("Chicken_language", "EventDesc_33"), EChickenChickenColor.chi));
		_dataArray.Add(new ChickenItem(34, LocalStringManager.GetConfig("Chicken_language", "Name_34"), LocalStringManager.GetConfig("Chicken_language", "Desc_34"), "tex_chicken_firm7", 7, 4, 15, 420, 241, LocalStringManager.GetConfig("Chicken_language", "EventDesc_34"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(35, LocalStringManager.GetConfig("Chicken_language", "Name_35"), LocalStringManager.GetConfig("Chicken_language", "Desc_35"), "tex_chicken_firm8", 8, 4, 18, 421, 242, LocalStringManager.GetConfig("Chicken_language", "EventDesc_35"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(36, LocalStringManager.GetConfig("Chicken_language", "Name_36"), LocalStringManager.GetConfig("Chicken_language", "Desc_36"), "tex_chicken_calm0", 0, 0, 1, 422, 243, LocalStringManager.GetConfig("Chicken_language", "EventDesc_36"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(37, LocalStringManager.GetConfig("Chicken_language", "Name_37"), LocalStringManager.GetConfig("Chicken_language", "Desc_37"), "tex_chicken_calm1", 1, 0, 2, 423, 244, LocalStringManager.GetConfig("Chicken_language", "EventDesc_37"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(38, LocalStringManager.GetConfig("Chicken_language", "Name_38"), LocalStringManager.GetConfig("Chicken_language", "Desc_38"), "tex_chicken_calm2", 2, 0, 3, 424, 245, LocalStringManager.GetConfig("Chicken_language", "EventDesc_38"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(39, LocalStringManager.GetConfig("Chicken_language", "Name_39"), LocalStringManager.GetConfig("Chicken_language", "Desc_39"), "tex_chicken_calm3", 3, 0, 5, 425, 246, LocalStringManager.GetConfig("Chicken_language", "EventDesc_39"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(40, LocalStringManager.GetConfig("Chicken_language", "Name_40"), LocalStringManager.GetConfig("Chicken_language", "Desc_40"), "tex_chicken_calm4", 4, 0, 7, 426, 247, LocalStringManager.GetConfig("Chicken_language", "EventDesc_40"), EChickenChickenColor.hui));
		_dataArray.Add(new ChickenItem(41, LocalStringManager.GetConfig("Chicken_language", "Name_41"), LocalStringManager.GetConfig("Chicken_language", "Desc_41"), "tex_chicken_calm5", 5, 0, 9, 427, 248, LocalStringManager.GetConfig("Chicken_language", "EventDesc_41"), EChickenChickenColor.hui));
		_dataArray.Add(new ChickenItem(42, LocalStringManager.GetConfig("Chicken_language", "Name_42"), LocalStringManager.GetConfig("Chicken_language", "Desc_42"), "tex_chicken_calm6", 6, 0, 12, 428, 249, LocalStringManager.GetConfig("Chicken_language", "EventDesc_42"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(43, LocalStringManager.GetConfig("Chicken_language", "Name_43"), LocalStringManager.GetConfig("Chicken_language", "Desc_43"), "tex_chicken_calm7", 7, 0, 15, 429, 250, LocalStringManager.GetConfig("Chicken_language", "EventDesc_43"), EChickenChickenColor.cai));
		_dataArray.Add(new ChickenItem(44, LocalStringManager.GetConfig("Chicken_language", "Name_44"), LocalStringManager.GetConfig("Chicken_language", "Desc_44"), "tex_chicken_calm8", 8, 0, 18, 430, 251, LocalStringManager.GetConfig("Chicken_language", "EventDesc_44"), EChickenChickenColor.qing));
		_dataArray.Add(new ChickenItem(45, LocalStringManager.GetConfig("Chicken_language", "Name_45"), LocalStringManager.GetConfig("Chicken_language", "Desc_45"), "tex_chicken_enthusiastic0", 0, 2, 1, 431, 252, LocalStringManager.GetConfig("Chicken_language", "EventDesc_45"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(46, LocalStringManager.GetConfig("Chicken_language", "Name_46"), LocalStringManager.GetConfig("Chicken_language", "Desc_46"), "tex_chicken_enthusiastic1", 1, 2, 2, 432, 253, LocalStringManager.GetConfig("Chicken_language", "EventDesc_46"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(47, LocalStringManager.GetConfig("Chicken_language", "Name_47"), LocalStringManager.GetConfig("Chicken_language", "Desc_47"), "tex_chicken_enthusiastic2", 2, 2, 3, 433, 254, LocalStringManager.GetConfig("Chicken_language", "EventDesc_47"), EChickenChickenColor.bai));
		_dataArray.Add(new ChickenItem(48, LocalStringManager.GetConfig("Chicken_language", "Name_48"), LocalStringManager.GetConfig("Chicken_language", "Desc_48"), "tex_chicken_enthusiastic3", 3, 2, 5, 434, 255, LocalStringManager.GetConfig("Chicken_language", "EventDesc_48"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(49, LocalStringManager.GetConfig("Chicken_language", "Name_49"), LocalStringManager.GetConfig("Chicken_language", "Desc_49"), "tex_chicken_enthusiastic4", 4, 2, 7, 435, 256, LocalStringManager.GetConfig("Chicken_language", "EventDesc_49"), EChickenChickenColor.heilv));
		_dataArray.Add(new ChickenItem(50, LocalStringManager.GetConfig("Chicken_language", "Name_50"), LocalStringManager.GetConfig("Chicken_language", "Desc_50"), "tex_chicken_enthusiastic5", 5, 2, 9, 436, 257, LocalStringManager.GetConfig("Chicken_language", "EventDesc_50"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(51, LocalStringManager.GetConfig("Chicken_language", "Name_51"), LocalStringManager.GetConfig("Chicken_language", "Desc_51"), "tex_chicken_enthusiastic6", 6, 2, 12, 437, 258, LocalStringManager.GetConfig("Chicken_language", "EventDesc_51"), EChickenChickenColor.heilv));
		_dataArray.Add(new ChickenItem(52, LocalStringManager.GetConfig("Chicken_language", "Name_52"), LocalStringManager.GetConfig("Chicken_language", "Desc_52"), "tex_chicken_enthusiastic7", 7, 2, 15, 438, 259, LocalStringManager.GetConfig("Chicken_language", "EventDesc_52"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(53, LocalStringManager.GetConfig("Chicken_language", "Name_53"), LocalStringManager.GetConfig("Chicken_language", "Desc_53"), "tex_chicken_enthusiastic8", 8, 2, 18, 439, 260, LocalStringManager.GetConfig("Chicken_language", "EventDesc_53"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(54, LocalStringManager.GetConfig("Chicken_language", "Name_54"), LocalStringManager.GetConfig("Chicken_language", "Desc_54"), "tex_chicken_brave0", 0, 3, 1, 440, 261, LocalStringManager.GetConfig("Chicken_language", "EventDesc_54"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(55, LocalStringManager.GetConfig("Chicken_language", "Name_55"), LocalStringManager.GetConfig("Chicken_language", "Desc_55"), "tex_chicken_brave1", 1, 3, 2, 441, 262, LocalStringManager.GetConfig("Chicken_language", "EventDesc_55"), EChickenChickenColor.hei));
		_dataArray.Add(new ChickenItem(56, LocalStringManager.GetConfig("Chicken_language", "Name_56"), LocalStringManager.GetConfig("Chicken_language", "Desc_56"), "tex_chicken_brave2", 2, 3, 3, 442, 263, LocalStringManager.GetConfig("Chicken_language", "EventDesc_56"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(57, LocalStringManager.GetConfig("Chicken_language", "Name_57"), LocalStringManager.GetConfig("Chicken_language", "Desc_57"), "tex_chicken_brave3", 3, 3, 5, 443, 264, LocalStringManager.GetConfig("Chicken_language", "EventDesc_57"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(58, LocalStringManager.GetConfig("Chicken_language", "Name_58"), LocalStringManager.GetConfig("Chicken_language", "Desc_58"), "tex_chicken_brave4", 4, 3, 7, 444, 265, LocalStringManager.GetConfig("Chicken_language", "EventDesc_58"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(59, LocalStringManager.GetConfig("Chicken_language", "Name_59"), LocalStringManager.GetConfig("Chicken_language", "Desc_59"), "tex_chicken_brave5", 5, 3, 9, 445, 266, LocalStringManager.GetConfig("Chicken_language", "EventDesc_59"), EChickenChickenColor.heilv));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new ChickenItem(60, LocalStringManager.GetConfig("Chicken_language", "Name_60"), LocalStringManager.GetConfig("Chicken_language", "Desc_60"), "tex_chicken_brave6", 6, 3, 12, 446, 267, LocalStringManager.GetConfig("Chicken_language", "EventDesc_60"), EChickenChickenColor.bai));
		_dataArray.Add(new ChickenItem(61, LocalStringManager.GetConfig("Chicken_language", "Name_61"), LocalStringManager.GetConfig("Chicken_language", "Desc_61"), "tex_chicken_brave7", 7, 3, 15, 447, 268, LocalStringManager.GetConfig("Chicken_language", "EventDesc_61"), EChickenChickenColor.hui));
		_dataArray.Add(new ChickenItem(62, LocalStringManager.GetConfig("Chicken_language", "Name_62"), LocalStringManager.GetConfig("Chicken_language", "Desc_62"), "tex_chicken_brave8", 8, 3, 18, 448, 269, LocalStringManager.GetConfig("Chicken_language", "EventDesc_62"), EChickenChickenColor.tuhuang));
		_dataArray.Add(new ChickenItem(63, LocalStringManager.GetConfig("Chicken_language", "Name_63"), LocalStringManager.GetConfig("Chicken_language", "Desc_63"), "tex_chicken_dawang", 8, 5, 18, 385, -1, LocalStringManager.GetConfig("Chicken_language", "EventDesc_63"), EChickenChickenColor.chilv));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ChickenItem>(64);
		CreateItems0();
		CreateItems1();
	}
}
