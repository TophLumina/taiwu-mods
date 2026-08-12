using System;
using Config.Common;

namespace Config;

[Serializable]
public class QiArtStrategyItem : ConfigItem<QiArtStrategyItem, sbyte>
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
	/// 图标
	/// </summary>
	public readonly string Icon;

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
	/// 定力消耗
	/// </summary>
	public readonly short ConcentrationCost;

	/// <summary>
	/// 持续时间
	/// </summary>
	public readonly short Duration;

	/// <summary>
	/// 内力消耗
	/// - 启动时需要消耗多少内力，消耗量 = 90*(周天功法的级别+1)*N/100
	/// </summary>
	public readonly short NeiliCost;

	/// <summary>
	/// 唯一启动
	/// - 同参数的特效只能同时启动一个，启动另一个时，提示是否取消此前启动的效果
	/// </summary>
	public readonly short ActiveGroup;

	/// <summary>
	/// 五行保护
	/// - 当人物内力五行属性为指定五行，则周天不会再变化人物内力属性，该效果只能启动一个，-1：无，0金刚，1紫霞，2玄阴，3纯阳，4归元，5混元
	/// </summary>
	public readonly short AnchorFiveElements;

	/// <summary>
	/// 最小
	/// - 获取N%周天运转所能获取的内力
	/// </summary>
	public readonly short MinGainNeili;

	/// <summary>
	/// 最大
	/// </summary>
	public readonly short MaxGainNeili;

	/// <summary>
	/// 最小
	/// - 获取N%周天能获取的五行属性
	/// </summary>
	public readonly short MinGainFiveElements;

	/// <summary>
	/// 最大
	/// </summary>
	public readonly short MaxGainFiveElements;

	/// <summary>
	/// 最小
	/// - 获取N%周天能获取的真气进度
	/// </summary>
	public readonly short MinGainNeiliAllocation;

	/// <summary>
	/// 最大
	/// </summary>
	public readonly short MaxGainNeiliAllocation;

	/// <summary>
	/// 最小
	/// </summary>
	public readonly short MinExtraNeili;

	/// <summary>
	/// 最大
	/// </summary>
	public readonly short MaxExtraNeili;

	/// <summary>
	/// 最小
	/// </summary>
	public readonly short MinExtraFiveElements;

	/// <summary>
	/// 最大
	/// </summary>
	public readonly short MaxExtraFiveElements;

	/// <summary>
	/// 最小
	/// </summary>
	public readonly short MinExtraNeiliAllocation;

	/// <summary>
	/// 最大
	/// </summary>
	public readonly short MaxExtraNeiliAllocation;

	/// <summary>
	/// 移入五行
	/// - 周天运转五行转移时, 转移的方式. 0: 从克制自己的转移到自己, 1: 从被自己克制的转移到自己, 2: 从化生自己的转移到自己, 3: 从被自己化生的转移到自己
	/// </summary>
	public readonly sbyte TransferToFiveElements;

	/// <summary>
	/// 转移方式
	/// </summary>
	public readonly sbyte FiveElementsTransferType;

	/// <summary>
	/// 清空运转效果
	/// </summary>
	public readonly bool ClearOtherEffect;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="icon">图标</param>
	/// <param name="dialog">使用时会出现的对白</param>
	/// <param name="extractGroup">抽取分组</param>
	/// <param name="extractWeight">抽取权重</param>
	/// <param name="concentrationCost">定力消耗</param>
	/// <param name="duration">持续时间</param>
	/// <param name="neiliCost">内力消耗 - 启动时需要消耗多少内力，消耗量 = 90*(周天功法的级别+1)*N/100</param>
	/// <param name="activeGroup">唯一启动 - 同参数的特效只能同时启动一个，启动另一个时，提示是否取消此前启动的效果</param>
	/// <param name="anchorFiveElements">五行保护 - 当人物内力五行属性为指定五行，则周天不会再变化人物内力属性，该效果只能启动一个，-1：无，0金刚，1紫霞，2玄阴，3纯阳，4归元，5混元</param>
	/// <param name="minGainNeili">最小 - 获取N%周天运转所能获取的内力</param>
	/// <param name="maxGainNeili">最大</param>
	/// <param name="minGainFiveElements">最小 - 获取N%周天能获取的五行属性</param>
	/// <param name="maxGainFiveElements">最大</param>
	/// <param name="minGainNeiliAllocation">最小 - 获取N%周天能获取的真气进度</param>
	/// <param name="maxGainNeiliAllocation">最大</param>
	/// <param name="minExtraNeili">最小</param>
	/// <param name="maxExtraNeili">最大</param>
	/// <param name="minExtraFiveElements">最小</param>
	/// <param name="maxExtraFiveElements">最大</param>
	/// <param name="minExtraNeiliAllocation">最小</param>
	/// <param name="maxExtraNeiliAllocation">最大</param>
	/// <param name="transferToFiveElements">移入五行 - 周天运转五行转移时, 转移的方式. 0: 从克制自己的转移到自己, 1: 从被自己克制的转移到自己, 2: 从化生自己的转移到自己, 3: 从被自己化生的转移到自己</param>
	/// <param name="fiveElementsTransferType">转移方式</param>
	/// <param name="clearOtherEffect">清空运转效果</param>
	public QiArtStrategyItem(sbyte templateId, string name, string desc, string icon, string dialog, short extractGroup, short extractWeight, short concentrationCost, short duration, short neiliCost, short activeGroup, short anchorFiveElements, short minGainNeili, short maxGainNeili, short minGainFiveElements, short maxGainFiveElements, short minGainNeiliAllocation, short maxGainNeiliAllocation, short minExtraNeili, short maxExtraNeili, short minExtraFiveElements, short maxExtraFiveElements, short minExtraNeiliAllocation, short maxExtraNeiliAllocation, sbyte transferToFiveElements, sbyte fiveElementsTransferType, bool clearOtherEffect)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		Dialog = dialog;
		ExtractGroup = extractGroup;
		ExtractWeight = extractWeight;
		ConcentrationCost = concentrationCost;
		Duration = duration;
		NeiliCost = neiliCost;
		ActiveGroup = activeGroup;
		AnchorFiveElements = anchorFiveElements;
		MinGainNeili = minGainNeili;
		MaxGainNeili = maxGainNeili;
		MinGainFiveElements = minGainFiveElements;
		MaxGainFiveElements = maxGainFiveElements;
		MinGainNeiliAllocation = minGainNeiliAllocation;
		MaxGainNeiliAllocation = maxGainNeiliAllocation;
		MinExtraNeili = minExtraNeili;
		MaxExtraNeili = maxExtraNeili;
		MinExtraFiveElements = minExtraFiveElements;
		MaxExtraFiveElements = maxExtraFiveElements;
		MinExtraNeiliAllocation = minExtraNeiliAllocation;
		MaxExtraNeiliAllocation = maxExtraNeiliAllocation;
		TransferToFiveElements = transferToFiveElements;
		FiveElementsTransferType = fiveElementsTransferType;
		ClearOtherEffect = clearOtherEffect;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public QiArtStrategyItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		Dialog = null;
		ExtractGroup = 0;
		ExtractWeight = 0;
		ConcentrationCost = 0;
		Duration = 0;
		NeiliCost = 0;
		ActiveGroup = -1;
		AnchorFiveElements = -1;
		MinGainNeili = 0;
		MaxGainNeili = 0;
		MinGainFiveElements = 0;
		MaxGainFiveElements = 0;
		MinGainNeiliAllocation = 0;
		MaxGainNeiliAllocation = 0;
		MinExtraNeili = 0;
		MaxExtraNeili = 0;
		MinExtraFiveElements = 0;
		MaxExtraFiveElements = 0;
		MinExtraNeiliAllocation = 0;
		MaxExtraNeiliAllocation = 0;
		TransferToFiveElements = -1;
		FiveElementsTransferType = -1;
		ClearOtherEffect = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public QiArtStrategyItem(sbyte templateId, QiArtStrategyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		Dialog = other.Dialog;
		ExtractGroup = other.ExtractGroup;
		ExtractWeight = other.ExtractWeight;
		ConcentrationCost = other.ConcentrationCost;
		Duration = other.Duration;
		NeiliCost = other.NeiliCost;
		ActiveGroup = other.ActiveGroup;
		AnchorFiveElements = other.AnchorFiveElements;
		MinGainNeili = other.MinGainNeili;
		MaxGainNeili = other.MaxGainNeili;
		MinGainFiveElements = other.MinGainFiveElements;
		MaxGainFiveElements = other.MaxGainFiveElements;
		MinGainNeiliAllocation = other.MinGainNeiliAllocation;
		MaxGainNeiliAllocation = other.MaxGainNeiliAllocation;
		MinExtraNeili = other.MinExtraNeili;
		MaxExtraNeili = other.MaxExtraNeili;
		MinExtraFiveElements = other.MinExtraFiveElements;
		MaxExtraFiveElements = other.MaxExtraFiveElements;
		MinExtraNeiliAllocation = other.MinExtraNeiliAllocation;
		MaxExtraNeiliAllocation = other.MaxExtraNeiliAllocation;
		TransferToFiveElements = other.TransferToFiveElements;
		FiveElementsTransferType = other.FiveElementsTransferType;
		ClearOtherEffect = other.ClearOtherEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override QiArtStrategyItem Duplicate(int templateId)
	{
		return new QiArtStrategyItem((sbyte)templateId, this);
	}
}
