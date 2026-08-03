using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakOutlineEffectItem : ConfigItem<SkillBreakOutlineEffectItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 天资上限倍率
	/// </summary>
	public readonly int StepBonusNormal;

	/// <summary>
	/// 入魔上限倍率
	/// </summary>
	public readonly int StepBonusGoneMad;

	/// <summary>
	/// 威力分布修正
	/// - 影响分布于中心区域的概率，取值范围 [-50,50]
	/// </summary>
	public readonly int PowerAddCenterRate;

	/// <summary>
	/// 玄机获取威力加成
	/// </summary>
	public readonly int BonusAddMaxPower;

	/// <summary>
	/// 未走火入魔格玄机获取威力加成
	/// </summary>
	public readonly int BonusAddMaxPowerNormal;

	/// <summary>
	/// 已走火入魔格玄机获取威力加成
	/// </summary>
	public readonly int BonusAddMaxPowerGoneMad;

	/// <summary>
	/// 单格威力上限
	/// </summary>
	public readonly int MaxPowerPerGrid;

	/// <summary>
	/// 未走火入魔时历练消耗倍率
	/// </summary>
	public readonly int AddExpCostNormal;

	/// <summary>
	/// 已走火入魔时历练消耗倍率
	/// </summary>
	public readonly int AddExpCostGoneMad;

	/// <summary>
	/// 中心区域突破格历练消耗倍率
	/// </summary>
	public readonly int AddExpCostCenter;

	/// <summary>
	/// 周边区域突破格历练消耗倍率
	/// </summary>
	public readonly int AddExpCostEdge;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string DescShort;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="desc">描述</param>
	/// <param name="stepBonusNormal">天资上限倍率</param>
	/// <param name="stepBonusGoneMad">入魔上限倍率</param>
	/// <param name="powerAddCenterRate">威力分布修正 - 影响分布于中心区域的概率，取值范围 [-50,50]</param>
	/// <param name="bonusAddMaxPower">玄机获取威力加成</param>
	/// <param name="bonusAddMaxPowerNormal">未走火入魔格玄机获取威力加成</param>
	/// <param name="bonusAddMaxPowerGoneMad">已走火入魔格玄机获取威力加成</param>
	/// <param name="maxPowerPerGrid">单格威力上限</param>
	/// <param name="addExpCostNormal">未走火入魔时历练消耗倍率</param>
	/// <param name="addExpCostGoneMad">已走火入魔时历练消耗倍率</param>
	/// <param name="addExpCostCenter">中心区域突破格历练消耗倍率</param>
	/// <param name="addExpCostEdge">周边区域突破格历练消耗倍率</param>
	/// <param name="descShort">名称</param>
	public SkillBreakOutlineEffectItem(sbyte templateId, string desc, int stepBonusNormal, int stepBonusGoneMad, int powerAddCenterRate, int bonusAddMaxPower, int bonusAddMaxPowerNormal, int bonusAddMaxPowerGoneMad, int maxPowerPerGrid, int addExpCostNormal, int addExpCostGoneMad, int addExpCostCenter, int addExpCostEdge, string descShort)
	{
		TemplateId = templateId;
		Desc = desc;
		StepBonusNormal = stepBonusNormal;
		StepBonusGoneMad = stepBonusGoneMad;
		PowerAddCenterRate = powerAddCenterRate;
		BonusAddMaxPower = bonusAddMaxPower;
		BonusAddMaxPowerNormal = bonusAddMaxPowerNormal;
		BonusAddMaxPowerGoneMad = bonusAddMaxPowerGoneMad;
		MaxPowerPerGrid = maxPowerPerGrid;
		AddExpCostNormal = addExpCostNormal;
		AddExpCostGoneMad = addExpCostGoneMad;
		AddExpCostCenter = addExpCostCenter;
		AddExpCostEdge = addExpCostEdge;
		DescShort = descShort;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakOutlineEffectItem()
	{
		TemplateId = 0;
		Desc = null;
		StepBonusNormal = 0;
		StepBonusGoneMad = 0;
		PowerAddCenterRate = 0;
		BonusAddMaxPower = 0;
		BonusAddMaxPowerNormal = 0;
		BonusAddMaxPowerGoneMad = 0;
		MaxPowerPerGrid = 3;
		AddExpCostNormal = 0;
		AddExpCostGoneMad = 0;
		AddExpCostCenter = 0;
		AddExpCostEdge = 0;
		DescShort = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakOutlineEffectItem(sbyte templateId, SkillBreakOutlineEffectItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		StepBonusNormal = other.StepBonusNormal;
		StepBonusGoneMad = other.StepBonusGoneMad;
		PowerAddCenterRate = other.PowerAddCenterRate;
		BonusAddMaxPower = other.BonusAddMaxPower;
		BonusAddMaxPowerNormal = other.BonusAddMaxPowerNormal;
		BonusAddMaxPowerGoneMad = other.BonusAddMaxPowerGoneMad;
		MaxPowerPerGrid = other.MaxPowerPerGrid;
		AddExpCostNormal = other.AddExpCostNormal;
		AddExpCostGoneMad = other.AddExpCostGoneMad;
		AddExpCostCenter = other.AddExpCostCenter;
		AddExpCostEdge = other.AddExpCostEdge;
		DescShort = other.DescShort;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakOutlineEffectItem Duplicate(int templateId)
	{
		return new SkillBreakOutlineEffectItem((sbyte)templateId, this);
	}
}
