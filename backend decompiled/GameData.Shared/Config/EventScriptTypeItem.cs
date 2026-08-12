using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventScriptTypeItem : ConfigItem<EventScriptTypeItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 条件列表
	/// - 是否为条件列表. 条件列表中只能使用条件指令.
	/// </summary>
	public readonly bool IsConditionList;

	/// <summary>
	/// 引用源
	/// </summary>
	public readonly EEventScriptTypeSource Source;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="isConditionList">条件列表 - 是否为条件列表. 条件列表中只能使用条件指令.</param>
	/// <param name="source">引用源</param>
	public EventScriptTypeItem(sbyte templateId, string name, bool isConditionList, EEventScriptTypeSource source)
	{
		TemplateId = templateId;
		Name = name;
		IsConditionList = isConditionList;
		Source = source;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventScriptTypeItem()
	{
		TemplateId = 0;
		Name = null;
		IsConditionList = false;
		Source = EEventScriptTypeSource.Global;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventScriptTypeItem(sbyte templateId, EventScriptTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IsConditionList = other.IsConditionList;
		Source = other.Source;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventScriptTypeItem Duplicate(int templateId)
	{
		return new EventScriptTypeItem((sbyte)templateId, this);
	}
}
