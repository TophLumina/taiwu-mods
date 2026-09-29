using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanWeatherItem : ConfigItem<TeaHorseCaravanWeatherItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public readonly List<sbyte> NeedSolarTerms;

	public readonly List<sbyte> NeedTerrain;

	public readonly sbyte ReplenishmentChange;

	public readonly sbyte LoseItemProb;

	public readonly sbyte Weighted;

	public TeaHorseCaravanWeatherItem(short templateId, string name, string desc, string icon, List<sbyte> needSolarTerms, List<sbyte> needTerrain, sbyte replenishmentChange, sbyte loseItemProb, sbyte weighted)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		NeedSolarTerms = needSolarTerms;
		NeedTerrain = needTerrain;
		ReplenishmentChange = replenishmentChange;
		LoseItemProb = loseItemProb;
		Weighted = weighted;
	}

	public TeaHorseCaravanWeatherItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		NeedSolarTerms = new List<sbyte>();
		NeedTerrain = new List<sbyte>();
		ReplenishmentChange = -1;
		LoseItemProb = -1;
		Weighted = -1;
	}

	public TeaHorseCaravanWeatherItem(short templateId, TeaHorseCaravanWeatherItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		NeedSolarTerms = other.NeedSolarTerms;
		NeedTerrain = other.NeedTerrain;
		ReplenishmentChange = other.ReplenishmentChange;
		LoseItemProb = other.LoseItemProb;
		Weighted = other.Weighted;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TeaHorseCaravanWeatherItem Duplicate(int templateId)
	{
		return new TeaHorseCaravanWeatherItem((short)templateId, this);
	}
}
