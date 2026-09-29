using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakeBlockEffectItem : ConfigItem<AdventureRemakeBlockEffectItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string LoadName;

	public readonly EAdventureRemakeBlockEffectLocation Location;

	public AdventureRemakeBlockEffectItem(short templateId, string name, string desc, string loadName, EAdventureRemakeBlockEffectLocation location)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		LoadName = loadName;
		Location = location;
	}

	public AdventureRemakeBlockEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		LoadName = null;
		Location = EAdventureRemakeBlockEffectLocation.Down;
	}

	public AdventureRemakeBlockEffectItem(short templateId, AdventureRemakeBlockEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		LoadName = other.LoadName;
		Location = other.Location;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureRemakeBlockEffectItem Duplicate(int templateId)
	{
		return new AdventureRemakeBlockEffectItem((short)templateId, this);
	}
}
