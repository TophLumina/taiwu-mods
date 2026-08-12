using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanWeatherItem : ConfigItem<TeaHorseCaravanWeatherItem, short>
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
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 天气出现的节气
	/// </summary>
	public readonly List<sbyte> NeedSolarTerms;

	/// <summary>
	/// 天气出现的地形
	/// </summary>
	public readonly List<sbyte> NeedTerrain;

	/// <summary>
	/// 补给消耗变化
	/// </summary>
	public readonly sbyte ReplenishmentChange;

	/// <summary>
	/// 丢失货品几率变化
	/// </summary>
	public readonly sbyte LoseItemProb;

	/// <summary>
	/// 出现权重
	/// </summary>
	public readonly sbyte Weighted;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="icon">图标</param>
	/// <param name="needSolarTerms">天气出现的节气</param>
	/// <param name="needTerrain">天气出现的地形</param>
	/// <param name="replenishmentChange">补给消耗变化</param>
	/// <param name="loseItemProb">丢失货品几率变化</param>
	/// <param name="weighted">出现权重</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TeaHorseCaravanWeatherItem Duplicate(int templateId)
	{
		return new TeaHorseCaravanWeatherItem((short)templateId, this);
	}
}
