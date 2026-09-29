using System;
using Config.Common;

namespace Config;

[Serializable]
public class MainMenuButtonItem : ConfigItem<MainMenuButtonItem, byte>
{
	public readonly byte TemplateId;

	public readonly string Name;

	public readonly string Summary;

	public readonly string Desc;

	public readonly bool AllowInGuiding;

	public readonly sbyte WorldFunction;

	public readonly string IconPrefix;

	public MainMenuButtonItem(byte templateId, string name, string summary, string desc, bool allowInGuiding, sbyte worldFunction, string iconPrefix)
	{
		TemplateId = templateId;
		Name = name;
		Summary = summary;
		Desc = desc;
		AllowInGuiding = allowInGuiding;
		WorldFunction = worldFunction;
		IconPrefix = iconPrefix;
	}

	public MainMenuButtonItem()
	{
		TemplateId = 0;
		Name = null;
		Summary = null;
		Desc = null;
		AllowInGuiding = false;
		WorldFunction = 0;
		IconPrefix = null;
	}

	public MainMenuButtonItem(byte templateId, MainMenuButtonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Summary = other.Summary;
		Desc = other.Desc;
		AllowInGuiding = other.AllowInGuiding;
		WorldFunction = other.WorldFunction;
		IconPrefix = other.IconPrefix;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MainMenuButtonItem Duplicate(int templateId)
	{
		return new MainMenuButtonItem((byte)templateId, this);
	}
}
