using System;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanEventItem : ConfigItem<TeaHorseCaravanEventItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 事件类型
	/// </summary>
	public readonly sbyte EventType;

	/// <summary>
	/// 出现权重
	/// </summary>
	public readonly sbyte Weighted;

	/// <summary>
	/// 前进中触发
	/// </summary>
	public readonly bool ForwardHappen;

	/// <summary>
	/// 返回中触发
	/// </summary>
	public readonly bool ReturnHappen;

	/// <summary>
	/// 换取补给最小值
	/// </summary>
	public readonly short ExchangeMin;

	/// <summary>
	/// 换取补给最大值
	/// </summary>
	public readonly short ExchangeMax;

	/// <summary>
	/// 搜集补给最小
	/// </summary>
	public readonly short SearchMin;

	/// <summary>
	/// 搜集补给最大
	/// </summary>
	public readonly short SearchMax;

	/// <summary>
	/// 每时节搜集最小
	/// </summary>
	public readonly short SolarSearchMin;

	/// <summary>
	/// 每时节搜集最大
	/// </summary>
	public readonly short SolarSearchMax;

	/// <summary>
	/// 商队知名度变化
	/// </summary>
	public readonly short AwarenessChange;

	/// <summary>
	/// 随机获取物品最小品级
	/// </summary>
	public readonly short GetItemGradeMin;

	/// <summary>
	/// 随机获取物品最大品级
	/// </summary>
	public readonly short GetItemGradeMax;

	/// <summary>
	/// 失去货品最小个数
	/// </summary>
	public readonly short LoseGoodsNumMin;

	/// <summary>
	/// 失去货品最大个数
	/// </summary>
	public readonly short LoseGoodsNumMax;

	/// <summary>
	/// 补给变化最小
	/// </summary>
	public readonly short ReplenishmentChangeMin;

	/// <summary>
	/// 补给变化最大
	/// </summary>
	public readonly short ReplenishmentChangeMax;

	/// <summary>
	/// 补给不为0才会触发这个事件
	/// </summary>
	public readonly short ReplenishmentTrigger;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
	/// <param name="eventType">事件类型</param>
	/// <param name="weighted">出现权重</param>
	/// <param name="forwardHappen">前进中触发</param>
	/// <param name="returnHappen">返回中触发</param>
	/// <param name="exchangeMin">换取补给最小值</param>
	/// <param name="exchangeMax">换取补给最大值</param>
	/// <param name="searchMin">搜集补给最小</param>
	/// <param name="searchMax">搜集补给最大</param>
	/// <param name="solarSearchMin">每时节搜集最小</param>
	/// <param name="solarSearchMax">每时节搜集最大</param>
	/// <param name="awarenessChange">商队知名度变化</param>
	/// <param name="getItemGradeMin">随机获取物品最小品级</param>
	/// <param name="getItemGradeMax">随机获取物品最大品级</param>
	/// <param name="loseGoodsNumMin">失去货品最小个数</param>
	/// <param name="loseGoodsNumMax">失去货品最大个数</param>
	/// <param name="replenishmentChangeMin">补给变化最小</param>
	/// <param name="replenishmentChangeMax">补给变化最大</param>
	/// <param name="replenishmentTrigger">补给不为0才会触发这个事件</param>
	public TeaHorseCaravanEventItem(short templateId, string name, string desc, string[] parameters, sbyte eventType, sbyte weighted, bool forwardHappen, bool returnHappen, short exchangeMin, short exchangeMax, short searchMin, short searchMax, short solarSearchMin, short solarSearchMax, short awarenessChange, short getItemGradeMin, short getItemGradeMax, short loseGoodsNumMin, short loseGoodsNumMax, short replenishmentChangeMin, short replenishmentChangeMax, short replenishmentTrigger)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
		EventType = eventType;
		Weighted = weighted;
		ForwardHappen = forwardHappen;
		ReturnHappen = returnHappen;
		ExchangeMin = exchangeMin;
		ExchangeMax = exchangeMax;
		SearchMin = searchMin;
		SearchMax = searchMax;
		SolarSearchMin = solarSearchMin;
		SolarSearchMax = solarSearchMax;
		AwarenessChange = awarenessChange;
		GetItemGradeMin = getItemGradeMin;
		GetItemGradeMax = getItemGradeMax;
		LoseGoodsNumMin = loseGoodsNumMin;
		LoseGoodsNumMax = loseGoodsNumMax;
		ReplenishmentChangeMin = replenishmentChangeMin;
		ReplenishmentChangeMax = replenishmentChangeMax;
		ReplenishmentTrigger = replenishmentTrigger;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TeaHorseCaravanEventItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = null;
		EventType = -1;
		Weighted = -1;
		ForwardHappen = false;
		ReturnHappen = false;
		ExchangeMin = 0;
		ExchangeMax = 0;
		SearchMin = 0;
		SearchMax = 0;
		SolarSearchMin = 0;
		SolarSearchMax = 0;
		AwarenessChange = 0;
		GetItemGradeMin = 0;
		GetItemGradeMax = 0;
		LoseGoodsNumMin = 0;
		LoseGoodsNumMax = 0;
		ReplenishmentChangeMin = 0;
		ReplenishmentChangeMax = 0;
		ReplenishmentTrigger = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TeaHorseCaravanEventItem(short templateId, TeaHorseCaravanEventItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
		EventType = other.EventType;
		Weighted = other.Weighted;
		ForwardHappen = other.ForwardHappen;
		ReturnHappen = other.ReturnHappen;
		ExchangeMin = other.ExchangeMin;
		ExchangeMax = other.ExchangeMax;
		SearchMin = other.SearchMin;
		SearchMax = other.SearchMax;
		SolarSearchMin = other.SolarSearchMin;
		SolarSearchMax = other.SolarSearchMax;
		AwarenessChange = other.AwarenessChange;
		GetItemGradeMin = other.GetItemGradeMin;
		GetItemGradeMax = other.GetItemGradeMax;
		LoseGoodsNumMin = other.LoseGoodsNumMin;
		LoseGoodsNumMax = other.LoseGoodsNumMax;
		ReplenishmentChangeMin = other.ReplenishmentChangeMin;
		ReplenishmentChangeMax = other.ReplenishmentChangeMax;
		ReplenishmentTrigger = other.ReplenishmentTrigger;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TeaHorseCaravanEventItem Duplicate(int templateId)
	{
		return new TeaHorseCaravanEventItem((short)templateId, this);
	}
}
