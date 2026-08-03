using System;
using Config.Common;

namespace Config;

[Serializable]
public class QiDisorderEffectItem : ConfigItem<QiDisorderEffectItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// - 内息紊乱阶段
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 状态的紊乱阈值（最小值）
	/// - 当紊乱&gt;=该值时，判定为对应的状态
	/// </summary>
	public readonly short ThresholdMin;

	public readonly short ThresholdMax;

	/// <summary>
	/// 健康恢复
	/// </summary>
	public readonly sbyte HealthRecovery;

	/// <summary>
	/// 走火入魔
	/// - 突破时，走火入魔每走1步，在加完紊乱后，判断一次紊乱级别，读取紊乱表的走火入魔列，减少人物健康
	/// </summary>
	public readonly sbyte BreakCostHealth;

	/// <summary>
	/// 运功反噬几率
	/// - 运功时受到功法反噬的几率，反噬伤害根据功法的不同而有不同
	/// </summary>
	public readonly sbyte InjuredRate;

	/// <summary>
	/// 战斗真气恢复消耗内力百分比
	/// </summary>
	public readonly sbyte NeiliCostInCombat;

	/// <summary>
	/// 毒抗的降低
	/// - C类降低人物的所有毒抗
	/// </summary>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override QiDisorderEffectItem Duplicate(int templateId)
	{
		return new QiDisorderEffectItem((sbyte)templateId, this);
	}
}
