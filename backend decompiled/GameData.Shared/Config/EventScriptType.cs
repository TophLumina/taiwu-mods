using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventScriptType : ConfigData<EventScriptTypeItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte GlobalScript = 0;

		public const sbyte EventEnterScript = 1;

		public const sbyte EventConditionList = 2;

		public const sbyte OptionScript = 3;

		public const sbyte OptionAvailableConditionList = 4;

		public const sbyte OptionVisibleConditionList = 5;

		public const sbyte AdventureRemakeTriggerCondition = 6;

		public const sbyte AdventureRemakeAdvanceMonth = 7;

		public const sbyte OnMajorEventActive = 8;

		public const sbyte OnMajorEventRemove = 9;

		public const sbyte FixAbnormalAction = 10;
	}

	public static class DefValue
	{
		public static EventScriptTypeItem GlobalScript => Instance[(sbyte)0];

		public static EventScriptTypeItem EventEnterScript => Instance[(sbyte)1];

		public static EventScriptTypeItem EventConditionList => Instance[(sbyte)2];

		public static EventScriptTypeItem OptionScript => Instance[(sbyte)3];

		public static EventScriptTypeItem OptionAvailableConditionList => Instance[(sbyte)4];

		public static EventScriptTypeItem OptionVisibleConditionList => Instance[(sbyte)5];

		public static EventScriptTypeItem AdventureRemakeTriggerCondition => Instance[(sbyte)6];

		public static EventScriptTypeItem AdventureRemakeAdvanceMonth => Instance[(sbyte)7];

		public static EventScriptTypeItem OnMajorEventActive => Instance[(sbyte)8];

		public static EventScriptTypeItem OnMajorEventRemove => Instance[(sbyte)9];

		public static EventScriptTypeItem FixAbnormalAction => Instance[(sbyte)10];
	}

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
