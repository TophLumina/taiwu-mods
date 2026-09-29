using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class AiDataItem : ConfigItem<AiDataItem, int>
{
	public readonly int TemplateId;

	public readonly string Path;

	public readonly int GroupId;

	public AiGroupItem Group
	{
		[return: MaybeNull]
		get
		{
			return AiGroup.Instance.GetItemOrDefault(GroupId);
		}
	}

	public AiDataItem(int templateId, string path, int groupId)
	{
		TemplateId = templateId;
		Path = path;
		GroupId = groupId;
	}

	public AiDataItem()
	{
		TemplateId = 0;
		Path = null;
		GroupId = 0;
	}

	public AiDataItem(int templateId, AiDataItem other)
	{
		TemplateId = templateId;
		Path = other.Path;
		GroupId = other.GroupId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AiDataItem Duplicate(int templateId)
	{
		return new AiDataItem(templateId, this);
	}
}
