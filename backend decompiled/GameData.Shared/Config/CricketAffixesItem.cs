using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketAffixesItem : ConfigItem<CricketAffixesItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly short[] Weights;

	public CricketAffixesItem(short templateId, string name, string desc, short[] weights)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Weights = weights;
	}

	public CricketAffixesItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Weights = null;
	}

	public CricketAffixesItem(short templateId, CricketAffixesItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Weights = other.Weights;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CricketAffixesItem Duplicate(int templateId)
	{
		return new CricketAffixesItem((short)templateId, this);
	}
}
