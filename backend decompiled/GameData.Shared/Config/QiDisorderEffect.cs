using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class QiDisorderEffect : ConfigData<QiDisorderEffectItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Smooth = 0;

		public const sbyte Sluggish = 1;

		public const sbyte Blocked = 2;

		public const sbyte Disordered = 3;

		public const sbyte Cutoff = 4;
	}

	public static class DefValue
	{
		public static QiDisorderEffectItem Smooth => Instance[(sbyte)0];

		public static QiDisorderEffectItem Sluggish => Instance[(sbyte)1];

		public static QiDisorderEffectItem Blocked => Instance[(sbyte)2];

		public static QiDisorderEffectItem Disordered => Instance[(sbyte)3];

		public static QiDisorderEffectItem Cutoff => Instance[(sbyte)4];
	}

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
