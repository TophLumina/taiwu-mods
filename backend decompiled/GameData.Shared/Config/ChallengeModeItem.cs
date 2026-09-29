using System;
using Config.Common;

namespace Config;

[Serializable]
public class ChallengeModeItem : ConfigItem<ChallengeModeItem, int>
{
	public readonly int TemplateId;

	public readonly EChallengeModeType Type;

	public readonly EChallengeModeImplement Implement;

	public readonly int Point;

	public readonly string Icon;

	public readonly string Name;

	public readonly string Desc;

	public ChallengeModeItem(int templateId, EChallengeModeType type, EChallengeModeImplement implement, int point, string icon, string name, string desc)
	{
		TemplateId = templateId;
		Type = type;
		Implement = implement;
		Point = point;
		Icon = icon;
		Name = name;
		Desc = desc;
	}

	public ChallengeModeItem()
	{
		TemplateId = 0;
		Type = EChallengeModeType.Required;
		Implement = EChallengeModeImplement.Invalid;
		Point = 0;
		Icon = null;
		Name = null;
		Desc = null;
	}

	public ChallengeModeItem(int templateId, ChallengeModeItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Implement = other.Implement;
		Point = other.Point;
		Icon = other.Icon;
		Name = other.Name;
		Desc = other.Desc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ChallengeModeItem Duplicate(int templateId)
	{
		return new ChallengeModeItem(templateId, this);
	}
}
