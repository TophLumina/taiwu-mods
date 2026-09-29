using System;
using Config.Common;

namespace Config;

[Serializable]
public class LegacyPointTypeItem : ConfigItem<LegacyPointTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly sbyte Group;

	public LegacyPointTypeItem(sbyte templateId, string name, sbyte group)
	{
		TemplateId = templateId;
		Name = name;
		Group = group;
	}

	public LegacyPointTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Group = 0;
	}

	public LegacyPointTypeItem(sbyte templateId, LegacyPointTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Group = other.Group;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LegacyPointTypeItem Duplicate(int templateId)
	{
		return new LegacyPointTypeItem((sbyte)templateId, this);
	}
}
