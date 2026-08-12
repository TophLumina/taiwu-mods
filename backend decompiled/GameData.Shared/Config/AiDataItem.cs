using System;
using Config.Common;

namespace Config;

[Serializable]
public class AiDataItem : ConfigItem<AiDataItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 路径
	/// - 此列为蓝图在 combat-ai-blueprints 工程中的路径，不用填蓝图后缀名
	/// </summary>
	public readonly string Path;

	/// <summary>
	/// 所属组
	/// - 蓝图中只允许包含该组的条件与行为
	/// </summary>
	public readonly int GroupId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="path">路径 - 此列为蓝图在 combat-ai-blueprints 工程中的路径，不用填蓝图后缀名</param>
	/// <param name="groupId">所属组 - 蓝图中只允许包含该组的条件与行为</param>
	public AiDataItem(int templateId, string path, int groupId)
	{
		TemplateId = templateId;
		Path = path;
		GroupId = groupId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AiDataItem()
	{
		TemplateId = 0;
		Path = null;
		GroupId = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AiDataItem Duplicate(int templateId)
	{
		return new AiDataItem(templateId, this);
	}
}
