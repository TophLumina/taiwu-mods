using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventCommonOption : ConfigData<EventCommonOptionItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 交谈
		/// </summary>
		public const short Talk = 0;

		/// <summary>
		/// 比试
		/// </summary>
		public const short Competition = 1;

		/// <summary>
		/// 修习
		/// </summary>
		public const short Practice = 2;

		/// <summary>
		/// 亲近
		/// </summary>
		public const short Intimate = 3;

		/// <summary>
		/// 敌对
		/// </summary>
		public const short Enemy = 4;

		/// <summary>
		/// 互动
		/// </summary>
		public const short Interact = 5;

		/// <summary>
		/// 结束
		/// </summary>
		public const short Finish = 6;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 交谈
		/// </summary>
		public static EventCommonOptionItem Talk => Instance[(short)0];

		/// <summary>
		/// 比试
		/// </summary>
		public static EventCommonOptionItem Competition => Instance[(short)1];

		/// <summary>
		/// 修习
		/// </summary>
		public static EventCommonOptionItem Practice => Instance[(short)2];

		/// <summary>
		/// 亲近
		/// </summary>
		public static EventCommonOptionItem Intimate => Instance[(short)3];

		/// <summary>
		/// 敌对
		/// </summary>
		public static EventCommonOptionItem Enemy => Instance[(short)4];

		/// <summary>
		/// 互动
		/// </summary>
		public static EventCommonOptionItem Interact => Instance[(short)5];

		/// <summary>
		/// 结束
		/// </summary>
		public static EventCommonOptionItem Finish => Instance[(short)6];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventCommonOption Instance = new EventCommonOption();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "OptionTitle", "OptionRecordText", "RequiredTask", "TemplateId", "EventGuid" };

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
		_dataArray.Add(new EventCommonOptionItem(0, "05e87c45-f14e-49ef-8769-cbaced4753ae", LocalStringManager.GetConfig("EventCommonOption_language", "OptionTitle_0"), LocalStringManager.GetConfig("EventCommonOption_language", "OptionRecordText_0"), -1));
		_dataArray.Add(new EventCommonOptionItem(1, "9dce4f27-347c-4588-9be4-08c1c7f1f4a3", LocalStringManager.GetConfig("EventCommonOption_language", "OptionTitle_1"), LocalStringManager.GetConfig("EventCommonOption_language", "OptionRecordText_1"), -1));
		_dataArray.Add(new EventCommonOptionItem(2, "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371", LocalStringManager.GetConfig("EventCommonOption_language", "OptionTitle_2"), LocalStringManager.GetConfig("EventCommonOption_language", "OptionRecordText_2"), -1));
		_dataArray.Add(new EventCommonOptionItem(3, "bad63f08-115a-45aa-970c-fa203dd85e2b", LocalStringManager.GetConfig("EventCommonOption_language", "OptionTitle_3"), LocalStringManager.GetConfig("EventCommonOption_language", "OptionRecordText_3"), -1));
		_dataArray.Add(new EventCommonOptionItem(4, "7c70ce0c-577a-4049-bcad-e593c63d62d4", LocalStringManager.GetConfig("EventCommonOption_language", "OptionTitle_4"), LocalStringManager.GetConfig("EventCommonOption_language", "OptionRecordText_4"), -1));
		_dataArray.Add(new EventCommonOptionItem(5, "fb38f657-6ed0-41e4-a0c2-c82afb49762f", LocalStringManager.GetConfig("EventCommonOption_language", "OptionTitle_5"), LocalStringManager.GetConfig("EventCommonOption_language", "OptionRecordText_5"), -1));
		_dataArray.Add(new EventCommonOptionItem(6, null, LocalStringManager.GetConfig("EventCommonOption_language", "OptionTitle_6"), LocalStringManager.GetConfig("EventCommonOption_language", "OptionRecordText_6"), -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventCommonOptionItem>(7);
		CreateItems0();
	}
}
