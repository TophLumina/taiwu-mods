using System;
using Config.Common;

namespace Config;

[Serializable]
public class ReadingStrategyItem : ConfigItem<ReadingStrategyItem, sbyte>
{
	/// <summary>
	/// 模板ID
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
	/// 使用时会出现的对白
	/// </summary>
	public readonly string Dialog;

	/// <summary>
	/// 抽取分组
	/// </summary>
	public readonly short ExtractGroup;

	/// <summary>
	/// 抽取权重
	/// </summary>
	public readonly short ExtractWeight;

	/// <summary>
	/// 悟性消耗
	/// </summary>
	public readonly short IntelligenceCost;

	/// <summary>
	/// 持续时间
	/// </summary>
	public readonly short Duration;

	/// <summary>
	/// 耐久消耗
	/// - 书籍的耐久消耗
	/// </summary>
	public readonly short DurabilityCost;

	/// <summary>
	/// 研读进度加值最小值
	/// - 使用瞬间生效
	/// </summary>
	public readonly sbyte MinProgressAddValue;

	/// <summary>
	/// 研读进度加值最大值
	/// - 使用瞬间生效
	/// </summary>
	public readonly sbyte MaxProgressAddValue;

	/// <summary>
	/// 当前篇研读效率变化最小值
	/// - 持续生效,为百分比，最大值为100
	/// </summary>
	public readonly sbyte MaxCurrPageEfficiencyChange;

	/// <summary>
	/// 当前篇研读效率变化最大值
	/// - 持续生效,为百分比，最大值为100
	/// </summary>
	public readonly sbyte MinCurrPageEfficiencyChange;

	/// <summary>
	/// 下一篇研读进度变化
	/// - 生效时增加下一篇书篇的研读进度
	/// </summary>
	public readonly sbyte NextPageProgressAddValue;

	/// <summary>
	/// 后续篇研读效率变化
	/// </summary>
	public readonly sbyte FollowingPagesEfficiencyChange;

	/// <summary>
	/// 当前篇悟性消耗变化
	/// </summary>
	public readonly short CurrPageIntCostChange;

	/// <summary>
	/// 跳过当前篇
	/// - 此书篇不会被研读
	/// </summary>
	public readonly bool SkipPage;

	/// <summary>
	/// 清空当前篇策略
	/// - 是否清空，不包含此策略
	/// </summary>
	public readonly bool ClearPageStrategies;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="dialog">使用时会出现的对白</param>
	/// <param name="extractGroup">抽取分组</param>
	/// <param name="extractWeight">抽取权重</param>
	/// <param name="intelligenceCost">悟性消耗</param>
	/// <param name="duration">持续时间</param>
	/// <param name="durabilityCost">耐久消耗 - 书籍的耐久消耗</param>
	/// <param name="minProgressAddValue">研读进度加值最小值 - 使用瞬间生效</param>
	/// <param name="maxProgressAddValue">研读进度加值最大值 - 使用瞬间生效</param>
	/// <param name="maxCurrPageEfficiencyChange">当前篇研读效率变化最小值 - 持续生效,为百分比，最大值为100</param>
	/// <param name="minCurrPageEfficiencyChange">当前篇研读效率变化最大值 - 持续生效,为百分比，最大值为100</param>
	/// <param name="nextPageProgressAddValue">下一篇研读进度变化 - 生效时增加下一篇书篇的研读进度</param>
	/// <param name="followingPagesEfficiencyChange">后续篇研读效率变化</param>
	/// <param name="currPageIntCostChange">当前篇悟性消耗变化</param>
	/// <param name="skipPage">跳过当前篇 - 此书篇不会被研读</param>
	/// <param name="clearPageStrategies">清空当前篇策略 - 是否清空，不包含此策略</param>
	public ReadingStrategyItem(sbyte templateId, string name, string desc, string dialog, short extractGroup, short extractWeight, short intelligenceCost, short duration, short durabilityCost, sbyte minProgressAddValue, sbyte maxProgressAddValue, sbyte maxCurrPageEfficiencyChange, sbyte minCurrPageEfficiencyChange, sbyte nextPageProgressAddValue, sbyte followingPagesEfficiencyChange, short currPageIntCostChange, bool skipPage, bool clearPageStrategies)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Dialog = dialog;
		ExtractGroup = extractGroup;
		ExtractWeight = extractWeight;
		IntelligenceCost = intelligenceCost;
		Duration = duration;
		DurabilityCost = durabilityCost;
		MinProgressAddValue = minProgressAddValue;
		MaxProgressAddValue = maxProgressAddValue;
		MaxCurrPageEfficiencyChange = maxCurrPageEfficiencyChange;
		MinCurrPageEfficiencyChange = minCurrPageEfficiencyChange;
		NextPageProgressAddValue = nextPageProgressAddValue;
		FollowingPagesEfficiencyChange = followingPagesEfficiencyChange;
		CurrPageIntCostChange = currPageIntCostChange;
		SkipPage = skipPage;
		ClearPageStrategies = clearPageStrategies;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ReadingStrategyItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Dialog = null;
		ExtractGroup = 0;
		ExtractWeight = 0;
		IntelligenceCost = 0;
		Duration = 0;
		DurabilityCost = 0;
		MinProgressAddValue = 0;
		MaxProgressAddValue = 0;
		MaxCurrPageEfficiencyChange = 0;
		MinCurrPageEfficiencyChange = 0;
		NextPageProgressAddValue = 0;
		FollowingPagesEfficiencyChange = 0;
		CurrPageIntCostChange = 0;
		SkipPage = false;
		ClearPageStrategies = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ReadingStrategyItem(sbyte templateId, ReadingStrategyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Dialog = other.Dialog;
		ExtractGroup = other.ExtractGroup;
		ExtractWeight = other.ExtractWeight;
		IntelligenceCost = other.IntelligenceCost;
		Duration = other.Duration;
		DurabilityCost = other.DurabilityCost;
		MinProgressAddValue = other.MinProgressAddValue;
		MaxProgressAddValue = other.MaxProgressAddValue;
		MaxCurrPageEfficiencyChange = other.MaxCurrPageEfficiencyChange;
		MinCurrPageEfficiencyChange = other.MinCurrPageEfficiencyChange;
		NextPageProgressAddValue = other.NextPageProgressAddValue;
		FollowingPagesEfficiencyChange = other.FollowingPagesEfficiencyChange;
		CurrPageIntCostChange = other.CurrPageIntCostChange;
		SkipPage = other.SkipPage;
		ClearPageStrategies = other.ClearPageStrategies;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ReadingStrategyItem Duplicate(int templateId)
	{
		return new ReadingStrategyItem((sbyte)templateId, this);
	}
}
