using System;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkillPropertyItem : ConfigItem<CombatSkillPropertyItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly bool IsPercent;

	public readonly string PlusColor;

	public readonly string MinusColor;

	public readonly string TipsSmallIcon;

	public readonly string TipsIcon;

	public readonly bool IsInverse;

	public readonly int DisplayFix;

	public readonly bool IsDisplaySpecially;

	public CombatSkillPropertyItem(sbyte templateId, string name, bool isPercent, string plusColor, string minusColor, string tipsSmallIcon, string tipsIcon, bool isInverse, int displayFix, bool isDisplaySpecially)
	{
		TemplateId = templateId;
		Name = name;
		IsPercent = isPercent;
		PlusColor = plusColor;
		MinusColor = minusColor;
		TipsSmallIcon = tipsSmallIcon;
		TipsIcon = tipsIcon;
		IsInverse = isInverse;
		DisplayFix = displayFix;
		IsDisplaySpecially = isDisplaySpecially;
	}

	public CombatSkillPropertyItem()
	{
		TemplateId = 0;
		Name = null;
		IsPercent = false;
		PlusColor = null;
		MinusColor = null;
		TipsSmallIcon = null;
		TipsIcon = null;
		IsInverse = false;
		DisplayFix = 0;
		IsDisplaySpecially = false;
	}

	public CombatSkillPropertyItem(sbyte templateId, CombatSkillPropertyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IsPercent = other.IsPercent;
		PlusColor = other.PlusColor;
		MinusColor = other.MinusColor;
		TipsSmallIcon = other.TipsSmallIcon;
		TipsIcon = other.TipsIcon;
		IsInverse = other.IsInverse;
		DisplayFix = other.DisplayFix;
		IsDisplaySpecially = other.IsDisplaySpecially;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatSkillPropertyItem Duplicate(int templateId)
	{
		return new CombatSkillPropertyItem((sbyte)templateId, this);
	}
}
