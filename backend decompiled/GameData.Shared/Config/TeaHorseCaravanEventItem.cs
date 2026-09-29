using System;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanEventItem : ConfigItem<TeaHorseCaravanEventItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string[] Parameters;

	public readonly sbyte EventType;

	public readonly sbyte Weighted;

	public readonly bool ForwardHappen;

	public readonly bool ReturnHappen;

	public readonly short ExchangeMin;

	public readonly short ExchangeMax;

	public readonly short SearchMin;

	public readonly short SearchMax;

	public readonly short SolarSearchMin;

	public readonly short SolarSearchMax;

	public readonly short AwarenessChange;

	public readonly short GetItemGradeMin;

	public readonly short GetItemGradeMax;

	public readonly short LoseGoodsNumMin;

	public readonly short LoseGoodsNumMax;

	public readonly short ReplenishmentChangeMin;

	public readonly short ReplenishmentChangeMax;

	public readonly short ReplenishmentTrigger;

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

	public override TeaHorseCaravanEventItem Duplicate(int templateId)
	{
		return new TeaHorseCaravanEventItem((short)templateId, this);
	}
}
