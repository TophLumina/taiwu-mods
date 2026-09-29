using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterPropertyDisplayItem : ConfigItem<CharacterPropertyDisplayItem, short>
{
	public readonly short TemplateId;

	public readonly ECharacterPropertyDisplayType Type;

	public readonly string Name;

	public readonly string ShortName;

	public readonly string Desc;

	public readonly string Icon;

	public readonly string TipsBigIcon;

	public readonly string TipsIcon;

	public readonly bool IsPercent;

	public readonly string PositiveColor;

	public readonly string NegativeColor;

	public readonly bool IsInverse;

	public readonly int DisplayFix;

	public readonly bool IsDisplaySpecially;

	public CharacterPropertyDisplayItem(short templateId, ECharacterPropertyDisplayType type, string name, string shortName, string desc, string icon, string tipsBigIcon, string tipsIcon, bool isPercent, string positiveColor, string negativeColor, bool isInverse, int displayFix, bool isDisplaySpecially)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		ShortName = shortName;
		Desc = desc;
		Icon = icon;
		TipsBigIcon = tipsBigIcon;
		TipsIcon = tipsIcon;
		IsPercent = isPercent;
		PositiveColor = positiveColor;
		NegativeColor = negativeColor;
		IsInverse = isInverse;
		DisplayFix = displayFix;
		IsDisplaySpecially = isDisplaySpecially;
	}

	public CharacterPropertyDisplayItem()
	{
		TemplateId = 0;
		Type = ECharacterPropertyDisplayType.Strength;
		Name = null;
		ShortName = null;
		Desc = null;
		Icon = null;
		TipsBigIcon = null;
		TipsIcon = null;
		IsPercent = false;
		PositiveColor = null;
		NegativeColor = null;
		IsInverse = false;
		DisplayFix = 0;
		IsDisplaySpecially = false;
	}

	public CharacterPropertyDisplayItem(short templateId, CharacterPropertyDisplayItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		ShortName = other.ShortName;
		Desc = other.Desc;
		Icon = other.Icon;
		TipsBigIcon = other.TipsBigIcon;
		TipsIcon = other.TipsIcon;
		IsPercent = other.IsPercent;
		PositiveColor = other.PositiveColor;
		NegativeColor = other.NegativeColor;
		IsInverse = other.IsInverse;
		DisplayFix = other.DisplayFix;
		IsDisplaySpecially = other.IsDisplaySpecially;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterPropertyDisplayItem Duplicate(int templateId)
	{
		return new CharacterPropertyDisplayItem((short)templateId, this);
	}
}
