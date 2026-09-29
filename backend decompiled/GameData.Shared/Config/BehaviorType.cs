using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BehaviorType : ConfigData<BehaviorTypeItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Just = 0;

		public const sbyte Kind = 1;

		public const sbyte Even = 2;

		public const sbyte Rebel = 3;

		public const sbyte Egoistic = 4;
	}

	public static class DefValue
	{
		public static BehaviorTypeItem Just => Instance[(sbyte)0];

		public static BehaviorTypeItem Kind => Instance[(sbyte)1];

		public static BehaviorTypeItem Even => Instance[(sbyte)2];

		public static BehaviorTypeItem Rebel => Instance[(sbyte)3];

		public static BehaviorTypeItem Egoistic => Instance[(sbyte)4];
	}

	public static BehaviorType Instance = new BehaviorType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "BetrayTips", "TemplateId", "ExchangeBook", "Icon" };

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
		_dataArray.Add(new BehaviorTypeItem(0, LocalStringManager.GetConfig("BehaviorType_language", "Name_0"), LocalStringManager.GetConfig("BehaviorType_language", "Desc_0"), 4, "ui9_icon_behavior_type_0", new string[3]
		{
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_0_0"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_0_1"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_0_2")
		}));
		_dataArray.Add(new BehaviorTypeItem(1, LocalStringManager.GetConfig("BehaviorType_language", "Name_1"), LocalStringManager.GetConfig("BehaviorType_language", "Desc_1"), 4, "ui9_icon_behavior_type_1", new string[3]
		{
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_1_0"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_1_1"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_1_2")
		}));
		_dataArray.Add(new BehaviorTypeItem(2, LocalStringManager.GetConfig("BehaviorType_language", "Name_2"), LocalStringManager.GetConfig("BehaviorType_language", "Desc_2"), 4, "ui9_icon_behavior_type_2", new string[3]
		{
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_2_0"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_2_1"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_2_2")
		}));
		_dataArray.Add(new BehaviorTypeItem(3, LocalStringManager.GetConfig("BehaviorType_language", "Name_3"), LocalStringManager.GetConfig("BehaviorType_language", "Desc_3"), 4, "ui9_icon_behavior_type_3", new string[3]
		{
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_3_0"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_3_1"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_3_2")
		}));
		_dataArray.Add(new BehaviorTypeItem(4, LocalStringManager.GetConfig("BehaviorType_language", "Name_4"), LocalStringManager.GetConfig("BehaviorType_language", "Desc_4"), 4, "ui9_icon_behavior_type_4", new string[3]
		{
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_4_0"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_4_1"),
			LocalStringManager.GetConfig("BehaviorType_language", "BetrayTips_4_2")
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BehaviorTypeItem>(5);
		CreateItems0();
	}
}
