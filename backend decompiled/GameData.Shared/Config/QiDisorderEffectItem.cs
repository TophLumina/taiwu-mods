using System;
using Config.Common;

namespace Config;

[Serializable]
public class QiDisorderEffectItem : ConfigItem<QiDisorderEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly short ThresholdMin;

	public readonly short ThresholdMax;

	public readonly sbyte HealthRecovery;

	public readonly sbyte BreakCostHealth;

	public readonly sbyte InjuredRate;

	public readonly sbyte NeiliCostInCombat;

	public readonly int PoisonResistChange;

	public QiDisorderEffectItem(sbyte templateId, string name, string desc, short thresholdMin, short thresholdMax, sbyte healthRecovery, sbyte breakCostHealth, sbyte injuredRate, sbyte neiliCostInCombat, int poisonResistChange)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ThresholdMin = thresholdMin;
		ThresholdMax = thresholdMax;
		HealthRecovery = healthRecovery;
		BreakCostHealth = breakCostHealth;
		InjuredRate = injuredRate;
		NeiliCostInCombat = neiliCostInCombat;
		PoisonResistChange = poisonResistChange;
	}

	public QiDisorderEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ThresholdMin = 0;
		ThresholdMax = 0;
		HealthRecovery = 0;
		BreakCostHealth = 0;
		InjuredRate = 0;
		NeiliCostInCombat = 0;
		PoisonResistChange = 0;
	}

	public QiDisorderEffectItem(sbyte templateId, QiDisorderEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		ThresholdMin = other.ThresholdMin;
		ThresholdMax = other.ThresholdMax;
		HealthRecovery = other.HealthRecovery;
		BreakCostHealth = other.BreakCostHealth;
		InjuredRate = other.InjuredRate;
		NeiliCostInCombat = other.NeiliCostInCombat;
		PoisonResistChange = other.PoisonResistChange;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override QiDisorderEffectItem Duplicate(int templateId)
	{
		return new QiDisorderEffectItem((sbyte)templateId, this);
	}
}
