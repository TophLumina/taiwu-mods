using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventConditionOperator : ConfigData<EventConditionOperatorItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 等于
		/// </summary>
		public const int EQ = 0;

		/// <summary>
		/// 不等于
		/// </summary>
		public const int NE = 1;

		/// <summary>
		/// 大于
		/// </summary>
		public const int GT = 2;

		/// <summary>
		/// 小于
		/// </summary>
		public const int LT = 3;

		/// <summary>
		/// 大于等于
		/// </summary>
		public const int GE = 4;

		/// <summary>
		/// 小于等于
		/// </summary>
		public const int LE = 5;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 等于
		/// </summary>
		public static EventConditionOperatorItem EQ => Instance[0];

		/// <summary>
		/// 不等于
		/// </summary>
		public static EventConditionOperatorItem NE => Instance[1];

		/// <summary>
		/// 大于
		/// </summary>
		public static EventConditionOperatorItem GT => Instance[2];

		/// <summary>
		/// 小于
		/// </summary>
		public static EventConditionOperatorItem LT => Instance[3];

		/// <summary>
		/// 大于等于
		/// </summary>
		public static EventConditionOperatorItem GE => Instance[4];

		/// <summary>
		/// 小于等于
		/// </summary>
		public static EventConditionOperatorItem LE => Instance[5];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
