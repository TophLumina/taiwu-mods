using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventConditionOperator : ConfigData<EventConditionOperatorItem, int>
{
	public static class DefKey
	{
		public const int EQ = 0;

		public const int NE = 1;

		public const int GT = 2;

		public const int LT = 3;

		public const int GE = 4;

		public const int LE = 5;
	}

	public static class DefValue
	{
		public static EventConditionOperatorItem EQ => Instance[0];

		public static EventConditionOperatorItem NE => Instance[1];

		public static EventConditionOperatorItem GT => Instance[2];

		public static EventConditionOperatorItem LT => Instance[3];

		public static EventConditionOperatorItem GE => Instance[4];

		public static EventConditionOperatorItem LE => Instance[5];
	}

	public static EventConditionOperator Instance = new EventConditionOperator();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

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
		_dataArray.Add(new EventConditionOperatorItem(0, LocalStringManager.GetConfig("EventConditionOperator_language", "Name_0")));
		_dataArray.Add(new EventConditionOperatorItem(1, LocalStringManager.GetConfig("EventConditionOperator_language", "Name_1")));
		_dataArray.Add(new EventConditionOperatorItem(2, LocalStringManager.GetConfig("EventConditionOperator_language", "Name_2")));
		_dataArray.Add(new EventConditionOperatorItem(3, LocalStringManager.GetConfig("EventConditionOperator_language", "Name_3")));
		_dataArray.Add(new EventConditionOperatorItem(4, LocalStringManager.GetConfig("EventConditionOperator_language", "Name_4")));
		_dataArray.Add(new EventConditionOperatorItem(5, LocalStringManager.GetConfig("EventConditionOperator_language", "Name_5")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventConditionOperatorItem>(6);
		CreateItems0();
	}
}
