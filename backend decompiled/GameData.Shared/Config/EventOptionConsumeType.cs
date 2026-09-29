using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventOptionConsumeType : ConfigData<EventOptionConsumeTypeItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Food = 0;

		public const sbyte Wood = 1;

		public const sbyte Metal = 2;

		public const sbyte Jade = 3;

		public const sbyte Fabric = 4;

		public const sbyte Herb = 5;

		public const sbyte Money = 6;

		public const sbyte Authority = 7;

		public const sbyte ActionPointTimesOneTenth = 8;

		public const sbyte ActionPointValue = 18;

		public const sbyte SpiritualDebt = 9;

		public const sbyte SpiritualDebtInCurrentArea = 10;

		public const sbyte Exp = 11;

		public const sbyte Strength = 12;

		public const sbyte Dexterity = 13;

		public const sbyte Concentration = 14;

		public const sbyte Vitality = 15;

		public const sbyte Energy = 16;

		public const sbyte Intelligence = 17;
	}

	public static class DefValue
	{
		public static EventOptionConsumeTypeItem Food => Instance[(sbyte)0];

		public static EventOptionConsumeTypeItem Wood => Instance[(sbyte)1];

		public static EventOptionConsumeTypeItem Metal => Instance[(sbyte)2];

		public static EventOptionConsumeTypeItem Jade => Instance[(sbyte)3];

		public static EventOptionConsumeTypeItem Fabric => Instance[(sbyte)4];

		public static EventOptionConsumeTypeItem Herb => Instance[(sbyte)5];

		public static EventOptionConsumeTypeItem Money => Instance[(sbyte)6];

		public static EventOptionConsumeTypeItem Authority => Instance[(sbyte)7];

		public static EventOptionConsumeTypeItem ActionPointTimesOneTenth => Instance[(sbyte)8];

		public static EventOptionConsumeTypeItem ActionPointValue => Instance[(sbyte)18];

		public static EventOptionConsumeTypeItem SpiritualDebt => Instance[(sbyte)9];

		public static EventOptionConsumeTypeItem SpiritualDebtInCurrentArea => Instance[(sbyte)10];

		public static EventOptionConsumeTypeItem Exp => Instance[(sbyte)11];

		public static EventOptionConsumeTypeItem Strength => Instance[(sbyte)12];

		public static EventOptionConsumeTypeItem Dexterity => Instance[(sbyte)13];

		public static EventOptionConsumeTypeItem Concentration => Instance[(sbyte)14];

		public static EventOptionConsumeTypeItem Vitality => Instance[(sbyte)15];

		public static EventOptionConsumeTypeItem Energy => Instance[(sbyte)16];

		public static EventOptionConsumeTypeItem Intelligence => Instance[(sbyte)17];
	}

	public static EventOptionConsumeType Instance = new EventOptionConsumeType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId", "Icon" };

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
		_dataArray.Add(new EventOptionConsumeTypeItem(0, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_0"), "ui9_icon_resource_bar_0"));
		_dataArray.Add(new EventOptionConsumeTypeItem(1, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_1"), "ui9_icon_resource_bar_1"));
		_dataArray.Add(new EventOptionConsumeTypeItem(2, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_2"), "ui9_icon_resource_bar_2"));
		_dataArray.Add(new EventOptionConsumeTypeItem(3, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_3"), "ui9_icon_resource_bar_3"));
		_dataArray.Add(new EventOptionConsumeTypeItem(4, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_4"), "ui9_icon_resource_bar_4"));
		_dataArray.Add(new EventOptionConsumeTypeItem(5, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_5"), "ui9_icon_resource_bar_5"));
		_dataArray.Add(new EventOptionConsumeTypeItem(6, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_6"), "ui9_icon_resource_bar_6"));
		_dataArray.Add(new EventOptionConsumeTypeItem(7, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_7"), "ui9_icon_resource_bar_7"));
		_dataArray.Add(new EventOptionConsumeTypeItem(8, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_8"), "ui9_icon_event_action_point_4"));
		_dataArray.Add(new EventOptionConsumeTypeItem(9, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_9"), "ui9_btn_resource_bar_10_0"));
		_dataArray.Add(new EventOptionConsumeTypeItem(10, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_10"), "ui9_btn_resource_bar_10_0"));
		_dataArray.Add(new EventOptionConsumeTypeItem(11, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_11"), "ui9_icon_resource_big_8"));
		_dataArray.Add(new EventOptionConsumeTypeItem(12, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_12"), "ui9_icon_attribute_major_big_0"));
		_dataArray.Add(new EventOptionConsumeTypeItem(13, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_13"), "ui9_icon_attribute_major_big_1"));
		_dataArray.Add(new EventOptionConsumeTypeItem(14, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_14"), "ui9_icon_attribute_major_big_2"));
		_dataArray.Add(new EventOptionConsumeTypeItem(15, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_15"), "ui9_icon_attribute_major_big_3"));
		_dataArray.Add(new EventOptionConsumeTypeItem(16, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_16"), "ui9_icon_attribute_major_big_4"));
		_dataArray.Add(new EventOptionConsumeTypeItem(17, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_17"), "ui9_icon_attribute_major_big_5"));
		_dataArray.Add(new EventOptionConsumeTypeItem(18, LocalStringManager.GetConfig("EventOptionConsumeType_language", "Name_18"), "ui9_icon_event_action_point_4"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventOptionConsumeTypeItem>(19);
		CreateItems0();
	}
}
