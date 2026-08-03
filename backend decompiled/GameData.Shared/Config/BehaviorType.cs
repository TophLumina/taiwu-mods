using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BehaviorType : ConfigData<BehaviorTypeItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 刚正
		/// </summary>
		public const short Just = 0;

		/// <summary>
		/// 仁善
		/// </summary>
		public const short Kind = 1;

		/// <summary>
		/// 中庸
		/// </summary>
		public const short Even = 2;

		/// <summary>
		/// 叛逆
		/// </summary>
		public const short Rebel = 3;

		/// <summary>
		/// 唯我
		/// </summary>
		public const short Egoistic = 4;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 刚正
		/// </summary>
		public static BehaviorTypeItem Just => Instance[(short)0];

		/// <summary>
		/// 仁善
		/// </summary>
		public static BehaviorTypeItem Kind => Instance[(short)1];

		/// <summary>
		/// 中庸
		/// </summary>
		public static BehaviorTypeItem Even => Instance[(short)2];

		/// <summary>
		/// 叛逆
		/// </summary>
		public static BehaviorTypeItem Rebel => Instance[(short)3];

		/// <summary>
		/// 唯我
		/// </summary>
		public static BehaviorTypeItem Egoistic => Instance[(short)4];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static BehaviorType Instance = new BehaviorType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "BetrayTips", "TemplateId", "ExchangeBook", "Icon" };

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
