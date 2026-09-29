using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiGroupItem : ConfigItem<AiGroupItem, int>
{
	public readonly int TemplateId;

	public readonly List<int> GroupIds;

	public AiGroupItem(int templateId, List<int> groupIds)
	{
		TemplateId = templateId;
		GroupIds = groupIds;
	}

	public AiGroupItem()
	{
		TemplateId = 0;
		GroupIds = null;
	}

	public AiGroupItem(int templateId, AiGroupItem other)
	{
		TemplateId = templateId;
		GroupIds = other.GroupIds;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AiGroupItem Duplicate(int templateId)
	{
		return new AiGroupItem(templateId, this);
	}
}
