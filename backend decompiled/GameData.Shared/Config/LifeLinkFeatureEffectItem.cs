using System;
using Config.Common;

namespace Config;

[Serializable]
public class LifeLinkFeatureEffectItem : ConfigItem<LifeLinkFeatureEffectItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 五行属性
	/// - 0: 金刚, 1: 紫霞、2: 玄阴、3: 纯阳, 4: 归元, 5: 混元.
	/// </summary>
	public readonly byte FiveElements;

	/// <summary>
	/// 特性 ID
	/// </summary>
	public readonly short FeatureId;

	/// <summary>
	/// 反噬暴击概率百分比
	/// - 正数代表生特性，负数代表死特性
	/// </summary>
	public readonly int CriticalProbPercent;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="fiveElements">五行属性 - 0: 金刚, 1: 紫霞、2: 玄阴、3: 纯阳, 4: 归元, 5: 混元.</param>
	/// <param name="featureId">特性 ID</param>
	/// <param name="criticalProbPercent">反噬暴击概率百分比 - 正数代表生特性，负数代表死特性</param>
	public LifeLinkFeatureEffectItem(sbyte templateId, byte fiveElements, short featureId, int criticalProbPercent)
	{
		TemplateId = templateId;
		FiveElements = fiveElements;
		FeatureId = featureId;
		CriticalProbPercent = criticalProbPercent;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LifeLinkFeatureEffectItem()
	{
		TemplateId = 0;
		FiveElements = 0;
		FeatureId = 0;
		CriticalProbPercent = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LifeLinkFeatureEffectItem(sbyte templateId, LifeLinkFeatureEffectItem other)
	{
		TemplateId = templateId;
		FiveElements = other.FiveElements;
		FeatureId = other.FeatureId;
		CriticalProbPercent = other.CriticalProbPercent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LifeLinkFeatureEffectItem Duplicate(int templateId)
	{
		return new LifeLinkFeatureEffectItem((sbyte)templateId, this);
	}
}
