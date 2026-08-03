using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiGroupItem : ConfigItem<AiGroupItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 包含组
	/// </summary>
	public readonly List<int> GroupIds;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="groupIds">包含组</param>
	public AiGroupItem(int templateId, List<int> groupIds)
	{
		TemplateId = templateId;
		GroupIds = groupIds;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AiGroupItem()
	{
		TemplateId = 0;
		GroupIds = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AiGroupItem(int templateId, AiGroupItem other)
	{
		TemplateId = templateId;
		GroupIds = other.GroupIds;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AiGroupItem Duplicate(int templateId)
	{
		return new AiGroupItem(templateId, this);
	}
}
