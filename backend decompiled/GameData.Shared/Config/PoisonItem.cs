using System;
using Config.Common;

namespace Config;

[Serializable]
public class PoisonItem : ConfigItem<PoisonItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string ShortName;

	public readonly string Desc;

	public readonly sbyte ProduceType;

	public readonly byte ProducePercent;

	public readonly byte[] AffectCostPercent;

	public readonly string FontColor;

	public readonly string Icon;

	public readonly string TipsIcon;

	public readonly short AffectNeedValue;

	public readonly short ReduceOuterResist;

	public readonly short ReduceInnerResist;

	public PoisonItem(sbyte templateId, string name, string shortName, string desc, sbyte produceType, byte producePercent, byte[] affectCostPercent, string fontColor, string icon, string tipsIcon, short affectNeedValue, short reduceOuterResist, short reduceInnerResist)
	{
		TemplateId = templateId;
		Name = name;
		ShortName = shortName;
		Desc = desc;
		ProduceType = produceType;
		ProducePercent = producePercent;
		AffectCostPercent = affectCostPercent;
		FontColor = fontColor;
		Icon = icon;
		TipsIcon = tipsIcon;
		AffectNeedValue = affectNeedValue;
		ReduceOuterResist = reduceOuterResist;
		ReduceInnerResist = reduceInnerResist;
	}

	public PoisonItem()
	{
		TemplateId = 0;
		Name = null;
		ShortName = null;
		Desc = null;
		ProduceType = 0;
		ProducePercent = 0;
		AffectCostPercent = new byte[3];
		FontColor = null;
		Icon = null;
		TipsIcon = null;
		AffectNeedValue = -1;
		ReduceOuterResist = -1;
		ReduceInnerResist = -1;
	}

	public PoisonItem(sbyte templateId, PoisonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ShortName = other.ShortName;
		Desc = other.Desc;
		ProduceType = other.ProduceType;
		ProducePercent = other.ProducePercent;
		AffectCostPercent = other.AffectCostPercent;
		FontColor = other.FontColor;
		Icon = other.Icon;
		TipsIcon = other.TipsIcon;
		AffectNeedValue = other.AffectNeedValue;
		ReduceOuterResist = other.ReduceOuterResist;
		ReduceInnerResist = other.ReduceInnerResist;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PoisonItem Duplicate(int templateId)
	{
		return new PoisonItem((sbyte)templateId, this);
	}
}
