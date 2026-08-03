using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaskHint : ConfigData<TaskHintItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 探索深谷
		/// </summary>
		public const sbyte ExploringValley = 0;

		/// <summary>
		/// 离开深谷
		/// </summary>
		public const sbyte LeavingValley = 1;

		/// <summary>
		/// 进入小村
		/// </summary>
		public const sbyte EnteringSmallVillage = 2;

		/// <summary>
		/// 探索小村
		/// </summary>
		public const sbyte ExploringSmallVillage = 3;

		/// <summary>
		/// 离开小村
		/// </summary>
		public const sbyte LeavingSmallVillage = 4;

		/// <summary>
		/// 进入亡流
		/// </summary>
		public const sbyte EnteringBrokenPerformArea = 5;

		/// <summary>
		/// 到达太吾
		/// </summary>
		public const sbyte EnteringTaiwuVillage = 6;

		/// <summary>
		/// 继承太吾
		/// </summary>
		public const sbyte InheritingTaiwu = 7;

		/// <summary>
		/// 村庄复兴
		/// </summary>
		public const sbyte DevelopingTaiwuVillage = 8;

		/// <summary>
		/// 化身移动
		/// </summary>
		public const sbyte FirstAppearanceOfXiangshuAvatar = 9;

		/// <summary>
		/// 和尚来访
		/// </summary>
		public const sbyte VisitOfOldMonk = 10;

		/// <summary>
		/// 初涉江湖
		/// </summary>
		public const sbyte ExploringTheState = 11;

		/// <summary>
		/// 拜师学艺
		/// </summary>
		public const sbyte LearningCombatSkill = 12;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 探索深谷
		/// </summary>
		public static TaskHintItem ExploringValley => Instance[(sbyte)0];

		/// <summary>
		/// 离开深谷
		/// </summary>
		public static TaskHintItem LeavingValley => Instance[(sbyte)1];

		/// <summary>
		/// 进入小村
		/// </summary>
		public static TaskHintItem EnteringSmallVillage => Instance[(sbyte)2];

		/// <summary>
		/// 探索小村
		/// </summary>
		public static TaskHintItem ExploringSmallVillage => Instance[(sbyte)3];

		/// <summary>
		/// 离开小村
		/// </summary>
		public static TaskHintItem LeavingSmallVillage => Instance[(sbyte)4];

		/// <summary>
		/// 进入亡流
		/// </summary>
		public static TaskHintItem EnteringBrokenPerformArea => Instance[(sbyte)5];

		/// <summary>
		/// 到达太吾
		/// </summary>
		public static TaskHintItem EnteringTaiwuVillage => Instance[(sbyte)6];

		/// <summary>
		/// 继承太吾
		/// </summary>
		public static TaskHintItem InheritingTaiwu => Instance[(sbyte)7];

		/// <summary>
		/// 村庄复兴
		/// </summary>
		public static TaskHintItem DevelopingTaiwuVillage => Instance[(sbyte)8];

		/// <summary>
		/// 化身移动
		/// </summary>
		public static TaskHintItem FirstAppearanceOfXiangshuAvatar => Instance[(sbyte)9];

		/// <summary>
		/// 和尚来访
		/// </summary>
		public static TaskHintItem VisitOfOldMonk => Instance[(sbyte)10];

		/// <summary>
		/// 初涉江湖
		/// </summary>
		public static TaskHintItem ExploringTheState => Instance[(sbyte)11];

		/// <summary>
		/// 拜师学艺
		/// </summary>
		public static TaskHintItem LearningCombatSkill => Instance[(sbyte)12];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TaskHint Instance = new TaskHint();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Info", "TemplateId" };

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
		_dataArray.Add(new TaskHintItem(0, LocalStringManager.GetConfig("TaskHint_language", "Info_0")));
		_dataArray.Add(new TaskHintItem(1, LocalStringManager.GetConfig("TaskHint_language", "Info_1")));
		_dataArray.Add(new TaskHintItem(2, LocalStringManager.GetConfig("TaskHint_language", "Info_2")));
		_dataArray.Add(new TaskHintItem(3, LocalStringManager.GetConfig("TaskHint_language", "Info_3")));
		_dataArray.Add(new TaskHintItem(4, LocalStringManager.GetConfig("TaskHint_language", "Info_4")));
		_dataArray.Add(new TaskHintItem(5, LocalStringManager.GetConfig("TaskHint_language", "Info_5")));
		_dataArray.Add(new TaskHintItem(6, LocalStringManager.GetConfig("TaskHint_language", "Info_6")));
		_dataArray.Add(new TaskHintItem(7, LocalStringManager.GetConfig("TaskHint_language", "Info_7")));
		_dataArray.Add(new TaskHintItem(8, LocalStringManager.GetConfig("TaskHint_language", "Info_8")));
		_dataArray.Add(new TaskHintItem(9, LocalStringManager.GetConfig("TaskHint_language", "Info_9")));
		_dataArray.Add(new TaskHintItem(10, LocalStringManager.GetConfig("TaskHint_language", "Info_10")));
		_dataArray.Add(new TaskHintItem(11, LocalStringManager.GetConfig("TaskHint_language", "Info_11")));
		_dataArray.Add(new TaskHintItem(12, LocalStringManager.GetConfig("TaskHint_language", "Info_12")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaskHintItem>(13);
		CreateItems0();
	}
}
