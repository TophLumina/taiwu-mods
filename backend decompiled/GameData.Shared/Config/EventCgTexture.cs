using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventCgTexture : ConfigData<EventCgTextureItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventCgTexture Instance = new EventCgTexture();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "ResourceFormat" };

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
		_dataArray.Add(new EventCgTextureItem(0, "mainstorytextures_cg_1", 2f));
		_dataArray.Add(new EventCgTextureItem(1, "mainstorytextures_cg_2", 2f));
		_dataArray.Add(new EventCgTextureItem(2, "mainstorytextures_cg_4", 2f));
		_dataArray.Add(new EventCgTextureItem(3, "mainstorytextures_cg_5", 2f));
		_dataArray.Add(new EventCgTextureItem(4, "mainstorytextures_cg_6", 2f));
		_dataArray.Add(new EventCgTextureItem(5, "mainstorytextures_cg_7", 2f));
		_dataArray.Add(new EventCgTextureItem(6, "mainstorytextures_cg_8", 2f));
		_dataArray.Add(new EventCgTextureItem(7, "mainstorytextures_cg_9", 2f));
		_dataArray.Add(new EventCgTextureItem(8, "mainstorytextures_cg_10", 2f));
		_dataArray.Add(new EventCgTextureItem(9, "mainstorytextures_cg_11", 2f));
		_dataArray.Add(new EventCgTextureItem(10, "mainstorytextures_cg_16", 2f));
		_dataArray.Add(new EventCgTextureItem(11, "mainstorytextures_cg_17", 2f));
		_dataArray.Add(new EventCgTextureItem(12, "mainstorytextures_cg_18", 2f));
		_dataArray.Add(new EventCgTextureItem(13, "mainstorytextures_cg_19", 2f));
		_dataArray.Add(new EventCgTextureItem(14, "mainstorytextures_cg_20", 2f));
		_dataArray.Add(new EventCgTextureItem(15, "mainstorytextures_cg_21", 2f));
		_dataArray.Add(new EventCgTextureItem(16, "mainstorytextures_cg_22", 2f));
		_dataArray.Add(new EventCgTextureItem(17, "mainstorytextures_cg_23", 2f));
		_dataArray.Add(new EventCgTextureItem(18, "mainstorytextures_cg_24", 2f));
		_dataArray.Add(new EventCgTextureItem(19, "mainstorytextures_cg_25", 2f));
		_dataArray.Add(new EventCgTextureItem(20, "mainstorytextures_cg_26", 2f));
		_dataArray.Add(new EventCgTextureItem(21, "mainstorytextures_cg_27", 2f));
		_dataArray.Add(new EventCgTextureItem(22, "mainstorytextures_cg_28", 2f));
		_dataArray.Add(new EventCgTextureItem(23, "mainstorytextures_cg_29", 2f));
		_dataArray.Add(new EventCgTextureItem(24, "mainstorytextures_cg_30", 2f));
		_dataArray.Add(new EventCgTextureItem(25, "mainstorytextures_cg_31", 2f));
		_dataArray.Add(new EventCgTextureItem(26, "mainstorytextures_cg_32", 2f));
		_dataArray.Add(new EventCgTextureItem(27, "mainstorytextures_cg_33", 2f));
		_dataArray.Add(new EventCgTextureItem(28, "mainstorytextures_cg_34", 2f));
		_dataArray.Add(new EventCgTextureItem(29, "mainstorytextures_cg_35", 2f));
		_dataArray.Add(new EventCgTextureItem(30, "mainstorytextures_cg_36", 2f));
		_dataArray.Add(new EventCgTextureItem(31, "mainstorytextures_cg_37", 2f));
		_dataArray.Add(new EventCgTextureItem(32, "mainstorytextures_cg_38", 2f));
		_dataArray.Add(new EventCgTextureItem(33, "mainstorytextures_cg_39", 2f));
		_dataArray.Add(new EventCgTextureItem(34, "mainstorytextures_cg_1", 2f));
		_dataArray.Add(new EventCgTextureItem(35, "mainstorytextures_cg_1", 2f));
		_dataArray.Add(new EventCgTextureItem(36, "mainstorytextures_cg_1", 2f));
		_dataArray.Add(new EventCgTextureItem(37, "mainstorytextures_cg_43", 2f));
		_dataArray.Add(new EventCgTextureItem(38, "mainstorytextures_cg_49", 2f));
		_dataArray.Add(new EventCgTextureItem(39, "mainstorytextures_cg_51", 2f));
		_dataArray.Add(new EventCgTextureItem(40, "mainstorytextures_cg_45", 2f));
		_dataArray.Add(new EventCgTextureItem(41, "mainstorytextures_cg_46", 2f));
		_dataArray.Add(new EventCgTextureItem(42, "mainstorytextures_cg_47", 2f));
		_dataArray.Add(new EventCgTextureItem(43, "mainstorytextures_cg_67", 2f));
		_dataArray.Add(new EventCgTextureItem(44, "mainstorytextures_cg_68", 2f));
		_dataArray.Add(new EventCgTextureItem(45, "mainstorytextures_cg_69", 2f));
		_dataArray.Add(new EventCgTextureItem(46, "mainstorytextures_cg_1", 2f));
		_dataArray.Add(new EventCgTextureItem(47, "mainstorytextures_cg_43", 2f));
		_dataArray.Add(new EventCgTextureItem(48, "mainstorytextures_cg_44", 2f));
		_dataArray.Add(new EventCgTextureItem(49, "mainstorytextures_cg_45", 2f));
		_dataArray.Add(new EventCgTextureItem(50, "mainstorytextures_cg_46", 2f));
		_dataArray.Add(new EventCgTextureItem(51, "mainstorytextures_cg_47", 2f));
		_dataArray.Add(new EventCgTextureItem(52, "mainstorytextures_cg_54", 2f));
		_dataArray.Add(new EventCgTextureItem(53, "mainstorytextures_cg_70", 2f));
		_dataArray.Add(new EventCgTextureItem(54, "mainstorytextures_cg_49", 2f));
		_dataArray.Add(new EventCgTextureItem(55, "mainstorytextures_cg_50", 2f));
		_dataArray.Add(new EventCgTextureItem(56, "mainstorytextures_cg_51", 2f));
		_dataArray.Add(new EventCgTextureItem(57, "mainstorytextures_cg_52", 2f));
		_dataArray.Add(new EventCgTextureItem(58, "mainstorytextures_cg_53", 2f));
		_dataArray.Add(new EventCgTextureItem(59, "mainstorytextures_cg_54", 2f));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EventCgTextureItem(60, "mainstorytextures_cg_1", 2f));
		_dataArray.Add(new EventCgTextureItem(61, "mainstorytextures_cg_55", 2f));
		_dataArray.Add(new EventCgTextureItem(62, "mainstorytextures_cg_56", 2f));
		_dataArray.Add(new EventCgTextureItem(63, "mainstorytextures_cg_57", 2f));
		_dataArray.Add(new EventCgTextureItem(64, "mainstorytextures_cg_58", 2f));
		_dataArray.Add(new EventCgTextureItem(65, "mainstorytextures_cg_59", 2f));
		_dataArray.Add(new EventCgTextureItem(66, "mainstorytextures_cg_60", 2f));
		_dataArray.Add(new EventCgTextureItem(67, "mainstorytextures_cg_61", 2f));
		_dataArray.Add(new EventCgTextureItem(68, "mainstorytextures_cg_62", 2f));
		_dataArray.Add(new EventCgTextureItem(69, "mainstorytextures_cg_63", 2f));
		_dataArray.Add(new EventCgTextureItem(70, "mainstorytextures_cg_64", 2f));
		_dataArray.Add(new EventCgTextureItem(71, "mainstorytextures_cg_65", 2f));
		_dataArray.Add(new EventCgTextureItem(72, "mainstorytextures_cg_1", 2f));
		_dataArray.Add(new EventCgTextureItem(73, "mainstorytextures_cg_66", 2f));
		_dataArray.Add(new EventCgTextureItem(74, "mainstorytextures_cg_PreDivineFlame_3", 2f));
		_dataArray.Add(new EventCgTextureItem(75, "mainstorytextures_cg_PreDivineFlame_1", 2f));
		_dataArray.Add(new EventCgTextureItem(76, "mainstorytextures_cg_PreDivineFlame_7", 2f));
		_dataArray.Add(new EventCgTextureItem(77, "mainstorytextures_cg_PreDivineFlame_8", 2f));
		_dataArray.Add(new EventCgTextureItem(78, "mainstorytextures_cg_PreDivineFlame_2", 2f));
		_dataArray.Add(new EventCgTextureItem(79, "mainstorytextures_cg_PreDivineFlame_0", 2f));
		_dataArray.Add(new EventCgTextureItem(80, "mainstorytextures_cg_PreDivineFlame_5", 2f));
		_dataArray.Add(new EventCgTextureItem(81, "mainstorytextures_cg_PreDivineFlame_4", 2f));
		_dataArray.Add(new EventCgTextureItem(82, "mainstorytextures_cg_PreDivineFlame_6", 2f));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventCgTextureItem>(83);
		CreateItems0();
		CreateItems1();
	}
}
