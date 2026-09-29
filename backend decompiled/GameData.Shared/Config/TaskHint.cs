using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaskHint : ConfigData<TaskHintItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte ExploringValley = 0;

		public const sbyte LeavingValley = 1;

		public const sbyte EnteringSmallVillage = 2;

		public const sbyte ExploringSmallVillage = 3;

		public const sbyte LeavingSmallVillage = 4;

		public const sbyte EnteringBrokenPerformArea = 5;

		public const sbyte EnteringTaiwuVillage = 6;

		public const sbyte InheritingTaiwu = 7;

		public const sbyte DevelopingTaiwuVillage = 8;

		public const sbyte FirstAppearanceOfXiangshuAvatar = 9;

		public const sbyte VisitOfOldMonk = 10;

		public const sbyte ExploringTheState = 11;

		public const sbyte LearningCombatSkill = 12;
	}

	public static class DefValue
	{
		public static TaskHintItem ExploringValley => Instance[(sbyte)0];

		public static TaskHintItem LeavingValley => Instance[(sbyte)1];

		public static TaskHintItem EnteringSmallVillage => Instance[(sbyte)2];

		public static TaskHintItem ExploringSmallVillage => Instance[(sbyte)3];

		public static TaskHintItem LeavingSmallVillage => Instance[(sbyte)4];

		public static TaskHintItem EnteringBrokenPerformArea => Instance[(sbyte)5];

		public static TaskHintItem EnteringTaiwuVillage => Instance[(sbyte)6];

		public static TaskHintItem InheritingTaiwu => Instance[(sbyte)7];

		public static TaskHintItem DevelopingTaiwuVillage => Instance[(sbyte)8];

		public static TaskHintItem FirstAppearanceOfXiangshuAvatar => Instance[(sbyte)9];

		public static TaskHintItem VisitOfOldMonk => Instance[(sbyte)10];

		public static TaskHintItem ExploringTheState => Instance[(sbyte)11];

		public static TaskHintItem LearningCombatSkill => Instance[(sbyte)12];
	}

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
