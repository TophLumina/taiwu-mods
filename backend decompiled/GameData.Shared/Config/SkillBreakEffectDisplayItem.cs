using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakEffectDisplayItem : ConfigItem<SkillBreakEffectDisplayItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string ShortName;

	public readonly string Icon;

	public readonly string BigIcon;

	public readonly bool IsPercent;

	public readonly string PlusColor;

	public readonly string MinusColor;

	public readonly bool IsInverse;

	public SkillBreakEffectDisplayItem(sbyte templateId, string name, string shortName, string icon, string bigIcon, bool isPercent, string plusColor, string minusColor, bool isInverse)
	{
		TemplateId = templateId;
		Name = name;
		ShortName = shortName;
		Icon = icon;
		BigIcon = bigIcon;
		IsPercent = isPercent;
		PlusColor = plusColor;
		MinusColor = minusColor;
		IsInverse = isInverse;
	}

	public SkillBreakEffectDisplayItem()
	{
		TemplateId = 0;
		Name = null;
		ShortName = null;
		Icon = null;
		BigIcon = null;
		IsPercent = false;
		PlusColor = "brightblue";
		MinusColor = "brightred";
		IsInverse = false;
	}

	public SkillBreakEffectDisplayItem(sbyte templateId, SkillBreakEffectDisplayItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ShortName = other.ShortName;
		Icon = other.Icon;
		BigIcon = other.BigIcon;
		IsPercent = other.IsPercent;
		PlusColor = other.PlusColor;
		MinusColor = other.MinusColor;
		IsInverse = other.IsInverse;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillBreakEffectDisplayItem Duplicate(int templateId)
	{
		return new SkillBreakEffectDisplayItem((sbyte)templateId, this);
	}
}
