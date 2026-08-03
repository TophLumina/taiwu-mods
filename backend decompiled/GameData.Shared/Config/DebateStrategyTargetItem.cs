using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateStrategyTargetItem : ConfigItem<DebateStrategyTargetItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EDebateStrategyTargetObjectType ObjectType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="objectType">类型</param>
	public DebateStrategyTargetItem(short templateId, string name, EDebateStrategyTargetObjectType objectType)
	{
		TemplateId = templateId;
		Name = name;
		ObjectType = objectType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateStrategyTargetItem()
	{
		TemplateId = 0;
		Name = null;
		ObjectType = EDebateStrategyTargetObjectType.Invalid;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateStrategyTargetItem(short templateId, DebateStrategyTargetItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ObjectType = other.ObjectType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DebateStrategyTargetItem Duplicate(int templateId)
	{
		return new DebateStrategyTargetItem((short)templateId, this);
	}
}
