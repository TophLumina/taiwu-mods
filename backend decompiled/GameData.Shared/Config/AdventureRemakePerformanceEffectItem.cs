using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakePerformanceEffectItem : ConfigItem<AdventureRemakePerformanceEffectItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly List<short> Effects;

	public AdventureRemakePerformanceEffectItem(short templateId, string name, string desc, List<short> effects)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Effects = effects;
	}

	public AdventureRemakePerformanceEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Effects = null;
	}

	public AdventureRemakePerformanceEffectItem(short templateId, AdventureRemakePerformanceEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Effects = other.Effects;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureRemakePerformanceEffectItem Duplicate(int templateId)
	{
		return new AdventureRemakePerformanceEffectItem((short)templateId, this);
	}
}
