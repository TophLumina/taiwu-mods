using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerParameterItem : ConfigItem<EventTriggerParameterItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 参数数据类型
	/// </summary>
	public readonly string DataTypeName;

	/// <summary>
	/// 参数盒子Key
	/// </summary>
	public readonly string ArgBoxKey;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="dataTypeName">参数数据类型</param>
	/// <param name="argBoxKey">参数盒子Key</param>
	public EventTriggerParameterItem(int templateId, string dataTypeName, string argBoxKey)
	{
		TemplateId = templateId;
		DataTypeName = dataTypeName;
		ArgBoxKey = argBoxKey;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventTriggerParameterItem()
	{
		TemplateId = 0;
		DataTypeName = null;
		ArgBoxKey = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventTriggerParameterItem(int templateId, EventTriggerParameterItem other)
	{
		TemplateId = templateId;
		DataTypeName = other.DataTypeName;
		ArgBoxKey = other.ArgBoxKey;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventTriggerParameterItem Duplicate(int templateId)
	{
		return new EventTriggerParameterItem(templateId, this);
	}
}
