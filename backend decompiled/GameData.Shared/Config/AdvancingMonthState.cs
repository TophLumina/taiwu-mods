using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthState : ConfigData<AdvancingMonthStateItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 非过月流程
		/// </summary>
		public const int NotInProcess = 0;

		/// <summary>
		/// 上月结束
		/// </summary>
		public const int PreAdvancingLastMonthEnding = 1;

		/// <summary>
		/// 角色状态变化
		/// </summary>
		public const int PeriAdvancingUpdateCharacterStatus = 2;

		/// <summary>
		/// 随机敌人行动
		/// </summary>
		public const int PeriAdvancingUpdateRandomEnemies = 3;

		/// <summary>
		/// 角色成长
		/// </summary>
		public const int PeriAdvancingCharacterSelfImprovement = 4;

		/// <summary>
		/// 主动整备
		/// </summary>
		public const int PeriAdvancingCharacterActivePreparation = 5;

		/// <summary>
		/// 被动整备
		/// </summary>
		public const int PeriAdvancingCharacterPassivePreparation = 6;

		/// <summary>
		/// 关系阶段
		/// </summary>
		public const int PeriAdvancingCharacterRelationsUpdate = 7;

		/// <summary>
		/// 思考阶段
		/// </summary>
		public const int PeriAdvancingCharacterPersonalNeedsProcessing = 8;

		/// <summary>
		/// 优先行动
		/// </summary>
		public const int PeriAdvancingCharacterPrioritizedAction = 9;

		/// <summary>
		/// 通常行动
		/// </summary>
		public const int PeriAdvancingCharacterGeneralAction = 10;

		/// <summary>
		/// 固定行动
		/// </summary>
		public const int PeriAdvancingCharacterFixedAction = 11;

		/// <summary>
		/// 见闻传播
		/// </summary>
		public const int PeriAdvancingInformationSpreading = 12;

		/// <summary>
		/// 下月开始
		/// </summary>
		public const int PostAdvancingEnterNewMonth = 13;

		/// <summary>
		/// 展示过月通知
		/// </summary>
		public const int DisplayingMonthlyNotifications = 14;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 非过月流程
		/// </summary>
		public static AdvancingMonthStateItem NotInProcess => Instance[0];

		/// <summary>
		/// 上月结束
		/// </summary>
		public static AdvancingMonthStateItem PreAdvancingLastMonthEnding => Instance[1];

		/// <summary>
		/// 角色状态变化
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingUpdateCharacterStatus => Instance[2];

		/// <summary>
		/// 随机敌人行动
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingUpdateRandomEnemies => Instance[3];

		/// <summary>
		/// 角色成长
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterSelfImprovement => Instance[4];

		/// <summary>
		/// 主动整备
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterActivePreparation => Instance[5];

		/// <summary>
		/// 被动整备
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterPassivePreparation => Instance[6];

		/// <summary>
		/// 关系阶段
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterRelationsUpdate => Instance[7];

		/// <summary>
		/// 思考阶段
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterPersonalNeedsProcessing => Instance[8];

		/// <summary>
		/// 优先行动
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterPrioritizedAction => Instance[9];

		/// <summary>
		/// 通常行动
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterGeneralAction => Instance[10];

		/// <summary>
		/// 固定行动
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingCharacterFixedAction => Instance[11];

		/// <summary>
		/// 见闻传播
		/// </summary>
		public static AdvancingMonthStateItem PeriAdvancingInformationSpreading => Instance[12];

		/// <summary>
		/// 下月开始
		/// </summary>
		public static AdvancingMonthStateItem PostAdvancingEnterNewMonth => Instance[13];

		/// <summary>
		/// 展示过月通知
		/// </summary>
		public static AdvancingMonthStateItem DisplayingMonthlyNotifications => Instance[14];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AdvancingMonthState Instance = new AdvancingMonthState();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "HintText", "TemplateId" };

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
		_dataArray.Add(new AdvancingMonthStateItem(0, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_0")));
		_dataArray.Add(new AdvancingMonthStateItem(1, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_1")));
		_dataArray.Add(new AdvancingMonthStateItem(2, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_2")));
		_dataArray.Add(new AdvancingMonthStateItem(3, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_3")));
		_dataArray.Add(new AdvancingMonthStateItem(4, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_4")));
		_dataArray.Add(new AdvancingMonthStateItem(5, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_5")));
		_dataArray.Add(new AdvancingMonthStateItem(6, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_6")));
		_dataArray.Add(new AdvancingMonthStateItem(7, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_7")));
		_dataArray.Add(new AdvancingMonthStateItem(8, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_8")));
		_dataArray.Add(new AdvancingMonthStateItem(9, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_9")));
		_dataArray.Add(new AdvancingMonthStateItem(10, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_10")));
		_dataArray.Add(new AdvancingMonthStateItem(11, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_11")));
		_dataArray.Add(new AdvancingMonthStateItem(12, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_12")));
		_dataArray.Add(new AdvancingMonthStateItem(13, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_13")));
		_dataArray.Add(new AdvancingMonthStateItem(14, LocalStringManager.GetConfig("AdvancingMonthState_language", "HintText_14")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdvancingMonthStateItem>(15);
		CreateItems0();
	}
}
