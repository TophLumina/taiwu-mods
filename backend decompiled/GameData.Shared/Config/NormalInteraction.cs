using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class NormalInteraction : ConfigData<NormalInteractionItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 切磋请求
		/// </summary>
		public const short RequestPlayCombat = 0;

		/// <summary>
		/// 挑战请求
		/// </summary>
		public const short RequestNormalCombat = 1;

		/// <summary>
		/// 较艺请求
		/// </summary>
		public const short RequestLifeSkillBattle = 2;

		/// <summary>
		/// 促织决斗请求
		/// </summary>
		public const short RequestCricketBattle = 3;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 切磋请求
		/// </summary>
		public static NormalInteractionItem RequestPlayCombat => Instance[(short)0];

		/// <summary>
		/// 挑战请求
		/// </summary>
		public static NormalInteractionItem RequestNormalCombat => Instance[(short)1];

		/// <summary>
		/// 较艺请求
		/// </summary>
		public static NormalInteractionItem RequestLifeSkillBattle => Instance[(short)2];

		/// <summary>
		/// 促织决斗请求
		/// </summary>
		public static NormalInteractionItem RequestCricketBattle => Instance[(short)3];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static NormalInteraction Instance = new NormalInteraction();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "HeadEvent", "AgreeAndSuccess", "AgreeAndFail", "Disagree", "TemplateId" };

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
		_dataArray.Add(new NormalInteractionItem(0, LocalStringManager.GetConfig("NormalInteraction_language", "Name_0"), new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_0_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_0_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_0_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_0_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_0_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_0_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_0_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_0_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_0_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_0_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_0_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_0_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_0_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_0_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_0_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_0_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_0_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_0_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_0_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_0_4")
		}));
		_dataArray.Add(new NormalInteractionItem(1, LocalStringManager.GetConfig("NormalInteraction_language", "Name_1"), new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_1_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_1_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_1_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_1_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_1_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_1_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_1_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_1_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_1_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_1_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_1_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_1_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_1_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_1_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_1_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_1_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_1_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_1_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_1_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_1_4")
		}));
		_dataArray.Add(new NormalInteractionItem(2, LocalStringManager.GetConfig("NormalInteraction_language", "Name_2"), new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_2_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_2_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_2_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_2_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_2_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_2_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_2_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_2_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_2_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_2_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_2_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_2_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_2_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_2_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_2_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_2_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_2_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_2_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_2_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_2_4")
		}));
		_dataArray.Add(new NormalInteractionItem(3, LocalStringManager.GetConfig("NormalInteraction_language", "Name_3"), new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_3_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_3_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_3_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_3_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "HeadEvent_3_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_3_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_3_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_3_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_3_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndSuccess_3_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_3_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_3_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_3_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_3_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "AgreeAndFail_3_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_3_0"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_3_1"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_3_2"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_3_3"),
			LocalStringManager.GetConfig("NormalInteraction_language", "Disagree_3_4")
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<NormalInteractionItem>(4);
		CreateItems0();
	}
}
