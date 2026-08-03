using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventScriptType : ConfigData<EventScriptTypeItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 全局脚本
		/// </summary>
		public const sbyte GlobalScript = 0;

		/// <summary>
		/// 事件页脚本
		/// </summary>
		public const sbyte EventEnterScript = 1;

		/// <summary>
		/// 事件页条件
		/// </summary>
		public const sbyte EventConditionList = 2;

		/// <summary>
		/// 选项脚本
		/// </summary>
		public const sbyte OptionScript = 3;

		/// <summary>
		/// 选项可用条件
		/// </summary>
		public const sbyte OptionAvailableConditionList = 4;

		/// <summary>
		/// 选项可见条件
		/// </summary>
		public const sbyte OptionVisibleConditionList = 5;

		/// <summary>
		/// 新版奇遇触发条件
		/// </summary>
		public const sbyte AdventureRemakeTriggerCondition = 6;

		/// <summary>
		/// 新版奇遇过月脚本
		/// </summary>
		public const sbyte AdventureRemakeAdvanceMonth = 7;

		/// <summary>
		/// 大事件激活时脚本
		/// </summary>
		public const sbyte OnMajorEventActive = 8;

		/// <summary>
		/// 大事件移除时脚本
		/// </summary>
		public const sbyte OnMajorEventRemove = 9;

		/// <summary>
		/// 奇遇修复脚本
		/// </summary>
		public const sbyte FixAbnormalAction = 10;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 全局脚本
		/// </summary>
		public static EventScriptTypeItem GlobalScript => Instance[(sbyte)0];

		/// <summary>
		/// 事件页脚本
		/// </summary>
		public static EventScriptTypeItem EventEnterScript => Instance[(sbyte)1];

		/// <summary>
		/// 事件页条件
		/// </summary>
		public static EventScriptTypeItem EventConditionList => Instance[(sbyte)2];

		/// <summary>
		/// 选项脚本
		/// </summary>
		public static EventScriptTypeItem OptionScript => Instance[(sbyte)3];

		/// <summary>
		/// 选项可用条件
		/// </summary>
		public static EventScriptTypeItem OptionAvailableConditionList => Instance[(sbyte)4];

		/// <summary>
		/// 选项可见条件
		/// </summary>
		public static EventScriptTypeItem OptionVisibleConditionList => Instance[(sbyte)5];

		/// <summary>
		/// 新版奇遇触发条件
		/// </summary>
		public static EventScriptTypeItem AdventureRemakeTriggerCondition => Instance[(sbyte)6];

		/// <summary>
		/// 新版奇遇过月脚本
		/// </summary>
		public static EventScriptTypeItem AdventureRemakeAdvanceMonth => Instance[(sbyte)7];

		/// <summary>
		/// 大事件激活时脚本
		/// </summary>
		public static EventScriptTypeItem OnMajorEventActive => Instance[(sbyte)8];

		/// <summary>
		/// 大事件移除时脚本
		/// </summary>
		public static EventScriptTypeItem OnMajorEventRemove => Instance[(sbyte)9];

		/// <summary>
		/// 奇遇修复脚本
		/// </summary>
		public static EventScriptTypeItem FixAbnormalAction => Instance[(sbyte)10];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventScriptType Instance = new EventScriptType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId", "Source" };

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
		_dataArray.Add(new EventScriptTypeItem(0, LocalStringManager.GetConfig("EventScriptType_language", "Name_0"), isConditionList: false, EEventScriptTypeSource.Global));
		_dataArray.Add(new EventScriptTypeItem(1, LocalStringManager.GetConfig("EventScriptType_language", "Name_1"), isConditionList: false, EEventScriptTypeSource.Event));
		_dataArray.Add(new EventScriptTypeItem(2, LocalStringManager.GetConfig("EventScriptType_language", "Name_2"), isConditionList: true, EEventScriptTypeSource.Event));
		_dataArray.Add(new EventScriptTypeItem(3, LocalStringManager.GetConfig("EventScriptType_language", "Name_3"), isConditionList: false, EEventScriptTypeSource.Event));
		_dataArray.Add(new EventScriptTypeItem(4, LocalStringManager.GetConfig("EventScriptType_language", "Name_4"), isConditionList: true, EEventScriptTypeSource.Event));
		_dataArray.Add(new EventScriptTypeItem(5, LocalStringManager.GetConfig("EventScriptType_language", "Name_5"), isConditionList: true, EEventScriptTypeSource.Event));
		_dataArray.Add(new EventScriptTypeItem(6, LocalStringManager.GetConfig("EventScriptType_language", "Name_6"), isConditionList: true, EEventScriptTypeSource.Adventure));
		_dataArray.Add(new EventScriptTypeItem(7, LocalStringManager.GetConfig("EventScriptType_language", "Name_7"), isConditionList: false, EEventScriptTypeSource.Adventure));
		_dataArray.Add(new EventScriptTypeItem(8, LocalStringManager.GetConfig("EventScriptType_language", "Name_8"), isConditionList: false, EEventScriptTypeSource.Adventure));
		_dataArray.Add(new EventScriptTypeItem(9, LocalStringManager.GetConfig("EventScriptType_language", "Name_9"), isConditionList: false, EEventScriptTypeSource.Adventure));
		_dataArray.Add(new EventScriptTypeItem(10, LocalStringManager.GetConfig("EventScriptType_language", "Name_10"), isConditionList: false, EEventScriptTypeSource.Adventure));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventScriptTypeItem>(11);
		CreateItems0();
	}
}
