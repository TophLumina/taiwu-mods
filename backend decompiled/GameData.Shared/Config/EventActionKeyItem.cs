using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventActionKeyItem : ConfigItem<EventActionKeyItem, int>, IEventArgumentFormatter
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 监听行为Key
	/// </summary>
	public readonly string KeyCode;

	/// <summary>
	/// 监听参数
	/// </summary>
	public readonly int[] Parameters;

	/// <summary>
	/// 拦截触发
	/// - 是否拦截触发点.
	/// </summary>
	public readonly bool BlockTrigger;

	/// <summary>
	/// 指令监听
	/// - 可以通过事件编辑器指令系统手动注册监听.
	/// </summary>
	public readonly bool RegisterByEventFunction;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="keyCode">监听行为Key</param>
	/// <param name="parameters">监听参数</param>
	/// <param name="blockTrigger">拦截触发 - 是否拦截触发点.</param>
	/// <param name="registerByEventFunction">指令监听 - 可以通过事件编辑器指令系统手动注册监听.</param>
	public EventActionKeyItem(int templateId, string keyCode, int[] parameters, bool blockTrigger, bool registerByEventFunction)
	{
		TemplateId = templateId;
		KeyCode = keyCode;
		Parameters = parameters;
		BlockTrigger = blockTrigger;
		RegisterByEventFunction = registerByEventFunction;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventActionKeyItem()
	{
		TemplateId = 0;
		KeyCode = null;
		Parameters = null;
		BlockTrigger = false;
		RegisterByEventFunction = true;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventActionKeyItem(int templateId, EventActionKeyItem other)
	{
		TemplateId = templateId;
		KeyCode = other.KeyCode;
		Parameters = other.Parameters;
		BlockTrigger = other.BlockTrigger;
		RegisterByEventFunction = other.RegisterByEventFunction;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventActionKeyItem Duplicate(int templateId)
	{
		return new EventActionKeyItem(templateId, this);
	}

	public static implicit operator string(EventActionKeyItem item)
	{
		return item.KeyCode;
	}

	string IEventArgumentFormatter.ToArgString()
	{
		return KeyCode;
	}
}
