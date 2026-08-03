using System;
using AiEditor;
using Config.Common;

namespace Config;

[Serializable]
public class AiNodeItem : ConfigItem<AiNodeItem, int>, IAiConfigTuple
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EAiNodeType Type;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 是否行为节点
	/// </summary>
	public readonly bool IsAction;

	int IAiConfigTuple.TemplateId => TemplateId;

	int IAiConfigTuple.GroupId => 0;

	string IAiConfigTuple.Name => Name;

	string IAiConfigTuple.Desc => Desc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">类型</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="isAction">是否行为节点</param>
	public AiNodeItem(int templateId, EAiNodeType type, string name, string desc, bool isAction)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		IsAction = isAction;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AiNodeItem()
	{
		TemplateId = 0;
		Type = EAiNodeType.Linear;
		Name = null;
		Desc = null;
		IsAction = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AiNodeItem(int templateId, AiNodeItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		IsAction = other.IsAction;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AiNodeItem Duplicate(int templateId)
	{
		return new AiNodeItem(templateId, this);
	}
}
