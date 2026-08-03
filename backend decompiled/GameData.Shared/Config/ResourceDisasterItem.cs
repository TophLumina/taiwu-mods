using System;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceDisasterItem : ConfigItem<ResourceDisasterItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 奇遇ID
	/// </summary>
	public readonly int TargetId;

	/// <summary>
	/// 对应资源
	/// </summary>
	public readonly sbyte ResourceType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="targetId">奇遇ID</param>
	/// <param name="resourceType">对应资源</param>
	public ResourceDisasterItem(short templateId, int targetId, sbyte resourceType)
	{
		TemplateId = templateId;
		TargetId = targetId;
		ResourceType = resourceType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ResourceDisasterItem()
	{
		TemplateId = 0;
		TargetId = 0;
		ResourceType = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ResourceDisasterItem Duplicate(int templateId)
	{
		return new ResourceDisasterItem((short)templateId, this);
	}
}
