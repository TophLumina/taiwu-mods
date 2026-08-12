using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuBeHuntedEvent : ConfigData<TaiwuBeHuntedEventItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 少林派
		/// </summary>
		public const short Shaolin = 0;

		/// <summary>
		/// 峨眉派
		/// </summary>
		public const short Emei = 1;

		/// <summary>
		/// 百花谷
		/// </summary>
		public const short Baihua = 2;

		/// <summary>
		/// 武当派
		/// </summary>
		public const short Wudang = 3;

		/// <summary>
		/// 元山派
		/// </summary>
		public const short Yuanshan = 4;

		/// <summary>
		/// 狮相门
		/// </summary>
		public const short Shixiang = 5;

		/// <summary>
		/// 然山派
		/// </summary>
		public const short Ranshan = 6;

		/// <summary>
		/// 璇女派
		/// </summary>
		public const short Xuannv = 7;

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public const short Zhujian = 8;

		/// <summary>
		/// 空桑派
		/// </summary>
		public const short Kongsang = 9;

		/// <summary>
		/// 金刚宗
		/// </summary>
		public const short Jingang = 10;

		/// <summary>
		/// 五仙教
		/// </summary>
		public const short Wuxian = 11;

		/// <summary>
		/// 界青门
		/// </summary>
		public const short Jieqing = 12;

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public const short Fulong = 13;

		/// <summary>
		/// 血犼教
		/// </summary>
		public const short Xuehou = 14;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 少林派
		/// </summary>
		public static TaiwuBeHuntedEventItem Shaolin => Instance[(short)0];

		/// <summary>
		/// 峨眉派
		/// </summary>
		public static TaiwuBeHuntedEventItem Emei => Instance[(short)1];

		/// <summary>
		/// 百花谷
		/// </summary>
		public static TaiwuBeHuntedEventItem Baihua => Instance[(short)2];

		/// <summary>
		/// 武当派
		/// </summary>
		public static TaiwuBeHuntedEventItem Wudang => Instance[(short)3];

		/// <summary>
		/// 元山派
		/// </summary>
		public static TaiwuBeHuntedEventItem Yuanshan => Instance[(short)4];

		/// <summary>
		/// 狮相门
		/// </summary>
		public static TaiwuBeHuntedEventItem Shixiang => Instance[(short)5];

		/// <summary>
		/// 然山派
		/// </summary>
		public static TaiwuBeHuntedEventItem Ranshan => Instance[(short)6];

		/// <summary>
		/// 璇女派
		/// </summary>
		public static TaiwuBeHuntedEventItem Xuannv => Instance[(short)7];

		/// <summary>
		/// 铸剑山庄
		/// </summary>
		public static TaiwuBeHuntedEventItem Zhujian => Instance[(short)8];

		/// <summary>
		/// 空桑派
		/// </summary>
		public static TaiwuBeHuntedEventItem Kongsang => Instance[(short)9];

		/// <summary>
		/// 金刚宗
		/// </summary>
		public static TaiwuBeHuntedEventItem Jingang => Instance[(short)10];

		/// <summary>
		/// 五仙教
		/// </summary>
		public static TaiwuBeHuntedEventItem Wuxian => Instance[(short)11];

		/// <summary>
		/// 界青门
		/// </summary>
		public static TaiwuBeHuntedEventItem Jieqing => Instance[(short)12];

		/// <summary>
		/// 伏龙坛
		/// </summary>
		public static TaiwuBeHuntedEventItem Fulong => Instance[(short)13];

		/// <summary>
		/// 血犼教
		/// </summary>
		public static TaiwuBeHuntedEventItem Xuehou => Instance[(short)14];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TaiwuBeHuntedEvent Instance = new TaiwuBeHuntedEvent();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "HeadEvent", "ResistEvent", "ResistWinEvent", "ResistLoseEvent", "PersuadeEvent", "LifeSkillCombatTypes", "PersuadeWinEvent", "PersuadeLoseEvent", "BribeEvent",
		"BribeConfirmEvent", "SurrenderEvent", "PunishEvent1", "PunishEvent2", "PunishEvent3", "PunishEvent4", "TemplateId"
	};

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
		_dataArray.Add(new TaiwuBeHuntedEventItem(0, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_0"), new List<sbyte> { 13 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_0"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_0")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(1, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_1"), new List<sbyte> { 13, 12 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_1"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_1")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(2, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_2"), new List<sbyte> { 8 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_2"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_2")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(3, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_3"), new List<sbyte> { 12 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_3"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_3")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(4, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_4"), new List<sbyte> { 13, 12 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_4"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_4")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(5, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_5"), new List<sbyte> { 15 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_5"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_5")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(6, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_6"), new List<sbyte> { 4 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_6"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_6")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(7, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_7"), new List<sbyte> { 0 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_7"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_7")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(8, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_8"), new List<sbyte> { 6, 7, 10, 11 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_8"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_8")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(9, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_9"), new List<sbyte> { 8, 9 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_9"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_9")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(10, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_10"), new List<sbyte> { 13 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_10"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_10")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(11, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_11"), new List<sbyte> { 9 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_11"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_11")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(12, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_12"), new List<sbyte> { 1 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_12"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_12")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(13, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_13"), new List<sbyte> { 14 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_13"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_13")));
		_dataArray.Add(new TaiwuBeHuntedEventItem(14, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "Name_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "HeadEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistWinEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "ResistLoseEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeEvent_14"), new List<sbyte> { 15 }, LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeWinEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PersuadeLoseEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "BribeConfirmEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "SurrenderEvent_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent1_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent2_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent3_14"), LocalStringManager.GetConfig("TaiwuBeHuntedEvent_language", "PunishEvent4_14")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaiwuBeHuntedEventItem>(15);
		CreateItems0();
	}
}
