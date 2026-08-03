using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Taiwu;

namespace Config;

[Serializable]
public class CombatEvaluation : ConfigData<CombatEvaluationItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 驱魔除邪1
		/// </summary>
		public const sbyte SaveInfection0 = 23;

		/// <summary>
		/// 驱魔除邪2
		/// </summary>
		public const sbyte SaveInfection1 = 24;

		/// <summary>
		/// 返璞归真
		/// </summary>
		public const sbyte TaiZuChangQuan = 32;

		/// <summary>
		/// 实战领悟
		/// </summary>
		public const sbyte ReadInCombat = 33;

		/// <summary>
		/// 实战周天
		/// </summary>
		public const sbyte QiArtInCombat = 43;

		/// <summary>
		/// 屈膝束手
		/// </summary>
		public const sbyte SurrenderInCombat = 45;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 驱魔除邪1
		/// </summary>
		public static CombatEvaluationItem SaveInfection0 => Instance[(sbyte)23];

		/// <summary>
		/// 驱魔除邪2
		/// </summary>
		public static CombatEvaluationItem SaveInfection1 => Instance[(sbyte)24];

		/// <summary>
		/// 返璞归真
		/// </summary>
		public static CombatEvaluationItem TaiZuChangQuan => Instance[(sbyte)32];

		/// <summary>
		/// 实战领悟
		/// </summary>
		public static CombatEvaluationItem ReadInCombat => Instance[(sbyte)33];

		/// <summary>
		/// 实战周天
		/// </summary>
		public static CombatEvaluationItem QiArtInCombat => Instance[(sbyte)43];

		/// <summary>
		/// 屈膝束手
		/// </summary>
		public static CombatEvaluationItem SurrenderInCombat => Instance[(sbyte)45];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CombatEvaluation Instance = new CombatEvaluation();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "SmallVillageDesc", "RequireCombatConfigs", "FameAction", "AddLegacyPoint", "TemplateId" };

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
		_dataArray.Add(new CombatEvaluationItem(0, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_0"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_0"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_0"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Fail, 0, -25, 0, -100, allowProficiency: true, 0, -1, -50, -50, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(1, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_1"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_1"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_1"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Draw, 0, 0, 0, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(2, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_2"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_2"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_2"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Flee, 0, -50, 0, -100, allowProficiency: true, 0, 33, -1000, -1000, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(3, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_3"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_3"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_3"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Win, 0, 0, 0, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(4, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_4"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_4"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_4"), new List<short>(), new sbyte[1], needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightSameLevel, 0, 0, 0, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, 50, 0),
			new LegacyPointReference(9, -9999, 0),
			new LegacyPointReference(10, -9999, 0),
			new LegacyPointReference(11, -9999, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(5, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_5"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_5"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_5"), new List<short>(), new sbyte[1] { 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightSameLevel, 0, 25, 0, 25, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, -9999, 0),
			new LegacyPointReference(9, 50, 0),
			new LegacyPointReference(10, -9999, 0),
			new LegacyPointReference(11, -9999, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(6, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_6"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_6"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_6"), new List<short>(), new sbyte[1] { 1 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightSameLevel, 0, 50, 0, 50, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, -9999, 0),
			new LegacyPointReference(9, -9999, 0),
			new LegacyPointReference(10, 50, 0),
			new LegacyPointReference(11, -9999, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(7, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_7"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_7"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_7"), new List<short>(), new sbyte[1] { 2 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightSameLevel, 0, 100, 0, 100, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, -9999, 0),
			new LegacyPointReference(9, -9999, 0),
			new LegacyPointReference(10, -9999, 0),
			new LegacyPointReference(11, 50, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(8, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_8"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_8"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_8"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.BeatXiangShu, 5000, 0, 5000, 0, allowProficiency: true, 0, -1, 100, 100, new List<LegacyPointReference>
		{
			new LegacyPointReference(41, 100, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(9, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_9"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_9"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_9"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: true, availableInPlayground: false, ECombatEvaluationExtraCheck.WinLess, -25, 0, -25, 0, allowProficiency: true, 0, -1, -25, -25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(10, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_10"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_10"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_10"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: true, availableInPlayground: false, ECombatEvaluationExtraCheck.WinChild, -25, 0, -25, 0, allowProficiency: true, 0, 34, -25, -25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(11, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_11"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_11"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_11"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinWorseEquip, -25, 0, -25, 0, allowProficiency: true, 0, -1, -25, -25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(12, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_12"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_12"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_12"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinLessNeili, -25, 0, -25, 0, allowProficiency: true, 0, -1, -25, -25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(13, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_13"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_13"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_13"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinWorseSkill, -25, 0, -25, 0, allowProficiency: true, 0, -1, -25, -25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(14, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_14"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_14"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_14"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinLessConsummate, -50, 0, -50, 0, allowProficiency: true, 0, -1, -25, -25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(15, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_15"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_15"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_15"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinPregnant, -75, 0, -75, 0, allowProficiency: true, 0, 35, -25, -25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(16, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_16"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_16"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_16"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: true, availableInPlayground: false, ECombatEvaluationExtraCheck.WinMore, 25, 0, 25, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(17, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_17"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_17"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_17"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: true, availableInPlayground: false, ECombatEvaluationExtraCheck.WinOlder, 25, 0, 25, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, 20, 0),
			new LegacyPointReference(9, 20, 0),
			new LegacyPointReference(10, 20, 0),
			new LegacyPointReference(11, 20, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(18, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_18"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_18"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_18"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinBetterEquip, 25, 0, 25, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, 20, 0),
			new LegacyPointReference(9, 20, 0),
			new LegacyPointReference(10, 20, 0),
			new LegacyPointReference(11, 20, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(19, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_19"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_19"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_19"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinMoreNeili, 25, 0, 25, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, 20, 0),
			new LegacyPointReference(9, 20, 0),
			new LegacyPointReference(10, 20, 0),
			new LegacyPointReference(11, 20, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(20, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_20"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_20"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_20"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinBetterSkill, 25, 0, 25, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, 20, 0),
			new LegacyPointReference(9, 20, 0),
			new LegacyPointReference(10, 20, 0),
			new LegacyPointReference(11, 20, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(21, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_21"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_21"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_21"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinMoreConsummate, 50, 0, 50, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, 20, 0),
			new LegacyPointReference(9, 20, 0),
			new LegacyPointReference(10, 20, 0),
			new LegacyPointReference(11, 20, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(22, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_22"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_22"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_22"), new List<short>(), new sbyte[2] { 1, 2 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinInPregnant, 75, 0, 75, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(23, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_23"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_23"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_23"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Extern, 25, 0, 25, 0, allowProficiency: true, 25, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(24, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_24"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_24"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_24"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Extern, 100, 0, 100, 0, allowProficiency: true, 100, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(25, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_25"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_25"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_25"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.KillBad0, 0, 0, 50, 0, allowProficiency: true, 0, 59, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(26, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_26"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_26"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_26"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.KillBad1, 0, 0, 100, 0, allowProficiency: true, 0, 59, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(27, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_27"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_27"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_27"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.KillGood0, 0, 0, -100, 0, allowProficiency: true, 0, 60, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(28, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_28"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_28"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_28"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.KillGood1, 0, 0, -50, 0, allowProficiency: true, 0, 60, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(29, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_29"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_29"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_29"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.ShixiangBuff0, 0, 0, 50, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(30, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_30"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_30"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_30"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.ShixiangBuff1, 0, 0, 75, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(31, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_31"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_31"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_31"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.ShixiangBuff2, 0, 0, 100, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(32, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_32"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_32"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_32"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Extern, 0, 0, 100, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(33, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_33"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_33"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_33"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Extern, 0, 0, 0, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(34, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_34"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_34"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_34"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.PuppetCombat, 0, -75, 0, -100, allowProficiency: true, 0, -1, 50, 50, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(35, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_35"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_35"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_35"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.WinLoong, 1500, 0, 1500, 0, allowProficiency: true, 0, 78, 100, 100, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(36, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_36"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_36"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_36"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.CombatHard, 100, 0, 100, 0, allowProficiency: true, 0, -1, 25, 25, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(37, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_37"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_37"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_37"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.CombatVeryHard, 200, 0, 200, 0, allowProficiency: true, 0, -1, 50, 50, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(38, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_38"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_38"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_38"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.OutBossCombat, 500, 0, 500, 0, allowProficiency: true, 0, -1, 20, 20, new List<LegacyPointReference>
		{
			new LegacyPointReference(40, 100, 50)
		}));
		_dataArray.Add(new CombatEvaluationItem(39, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_39"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_39"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_39"), new List<short>(), new sbyte[1], needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightLessLevel, 0, -75, 0, -75, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, -9999, 0),
			new LegacyPointReference(9, -9999, 0),
			new LegacyPointReference(10, -9999, 0),
			new LegacyPointReference(11, -9999, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(40, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_40"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_40"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_40"), new List<short>(), new sbyte[1] { 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightLessLevel, 0, -50, 0, -50, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, -9999, 0),
			new LegacyPointReference(9, -9999, 0),
			new LegacyPointReference(10, -9999, 0),
			new LegacyPointReference(11, -9999, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(41, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_41"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_41"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_41"), new List<short>(), new sbyte[1] { 1 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightLessLevel, 0, -25, 0, -25, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, -9999, 0),
			new LegacyPointReference(9, -9999, 0),
			new LegacyPointReference(10, -9999, 0),
			new LegacyPointReference(11, -9999, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(42, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_42"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_42"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_42"), new List<short>(), new sbyte[1] { 2 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.FightLessLevel, 0, 0, 0, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>
		{
			new LegacyPointReference(8, -9999, 0),
			new LegacyPointReference(9, -9999, 0),
			new LegacyPointReference(10, -9999, 0),
			new LegacyPointReference(11, -9999, 0)
		}));
		_dataArray.Add(new CombatEvaluationItem(43, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_43"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_43"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_43"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Extern, 0, 0, 0, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(44, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_44"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_44"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_44"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: true, ECombatEvaluationExtraCheck.None, 0, 0, 0, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(45, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_45"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_45"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_45"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Extern, 0, -75, 0, -100, allowProficiency: true, 0, 84, -1000, -1000, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(46, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_46"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_46"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_46"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.KillMinion0, 25, 0, 25, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(47, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_47"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_47"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_47"), new List<short>(), new sbyte[4] { 0, 1, 2, 3 }, needWin: true, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.KillMinion1, 100, 0, 100, 0, allowProficiency: true, 0, -1, 0, 0, new List<LegacyPointReference>()));
		_dataArray.Add(new CombatEvaluationItem(48, LocalStringManager.GetConfig("CombatEvaluation_language", "Name_48"), LocalStringManager.GetConfig("CombatEvaluation_language", "Desc_48"), LocalStringManager.GetConfig("CombatEvaluation_language", "SmallVillageDesc_48"), new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, new sbyte[4] { 0, 1, 2, 3 }, needWin: false, requireNotBoss: false, availableInPlayground: false, ECombatEvaluationExtraCheck.Fail, 0, -1000, 0, -1000, allowProficiency: false, 0, -1, 0, 0, new List<LegacyPointReference>()));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatEvaluationItem>(49);
		CreateItems0();
	}
}
