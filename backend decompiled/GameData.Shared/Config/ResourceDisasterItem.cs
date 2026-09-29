using System;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceDisasterItem : ConfigItem<ResourceDisasterItem, short>
{
	public readonly short TemplateId;

	public readonly int TargetId;

	public readonly sbyte ResourceType;

	public ResourceDisasterItem(short templateId, int targetId, sbyte resourceType)
	{
		TemplateId = templateId;
		TargetId = targetId;
		ResourceType = resourceType;
	}

	public ResourceDisasterItem()
	{
		TemplateId = 0;
		TargetId = 0;
		ResourceType = 0;
	}

	public ResourceDisasterItem(short templateId, ResourceDisasterItem other)
	{
		TemplateId = templateId;
		TargetId = other.TargetId;
		ResourceType = other.ResourceType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ResourceDisasterItem Duplicate(int templateId)
	{
		return new ResourceDisasterItem((short)templateId, this);
	}
}
