using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class QiDisorderEffect : ConfigData<QiDisorderEffectItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 顺畅
		/// </summary>
		public const sbyte Smooth = 0;

		/// <summary>
		/// 滞碍
		/// </summary>
		public const sbyte Sluggish = 1;

		/// <summary>
		/// 逆阻
		/// </summary>
		public const sbyte Blocked = 2;

		/// <summary>
		/// 紊乱
		/// </summary>
		public const sbyte Disordered = 3;

		/// <summary>
		/// 绝断
		/// </summary>
		public const sbyte Cutoff = 4;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 顺畅
		/// </summary>
		public static QiDisorderEffectItem Smooth => Instance[(sbyte)0];

		/// <summary>
		/// 滞碍
		/// </summary>
		public static QiDisorderEffectItem Sluggish => Instance[(sbyte)1];

		/// <summary>
		/// 逆阻
		/// </summary>
		public static QiDisorderEffectItem Blocked => Instance[(sbyte)2];

		/// <summary>
		/// 紊乱
		/// </summary>
		public static QiDisorderEffectItem Disordered => Instance[(sbyte)3];

		/// <summary>
		/// 绝断
		/// </summary>
		public static QiDisorderEffectItem Cutoff => Instance[(sbyte)4];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static QiDisorderEffect Instance = new QiDisorderEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "ThresholdMin", "ThresholdMax", "HealthRecovery", "BreakCostHealth", "InjuredRate", "NeiliCostInCombat", "PoisonResistChange" };

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
		_dataArray.Add(new QiDisorderEffectItem(0, LocalStringManager.GetConfig("QiDisorderEffect_language", "Name_0"), LocalStringManager.GetConfig("QiDisorderEffect_language", "Desc_0"), 0, 1000, 12, 0, 0, 0, 0));
		_dataArray.Add(new QiDisorderEffectItem(1, LocalStringManager.GetConfig("QiDisorderEffect_language", "Name_1"), LocalStringManager.GetConfig("QiDisorderEffect_language", "Desc_1"), 1000, 3000, 0, 0, 15, 25, -15));
		_dataArray.Add(new QiDisorderEffectItem(2, LocalStringManager.GetConfig("QiDisorderEffect_language", "Name_2"), LocalStringManager.GetConfig("QiDisorderEffect_language", "Desc_2"), 3000, 5000, -6, -2, 30, 50, -30));
		_dataArray.Add(new QiDisorderEffectItem(3, LocalStringManager.GetConfig("QiDisorderEffect_language", "Name_3"), LocalStringManager.GetConfig("QiDisorderEffect_language", "Desc_3"), 5000, 7000, -12, -4, 45, 75, -45));
		_dataArray.Add(new QiDisorderEffectItem(4, LocalStringManager.GetConfig("QiDisorderEffect_language", "Name_4"), LocalStringManager.GetConfig("QiDisorderEffect_language", "Desc_4"), 7000, 8000, -18, -6, 60, 100, -60));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<QiDisorderEffectItem>(5);
		CreateItems0();
	}
}
