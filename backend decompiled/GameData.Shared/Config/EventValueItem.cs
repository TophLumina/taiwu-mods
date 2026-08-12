using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventValueItem : ConfigItem<EventValueItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EEventValueType Type;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数盒子Key
	/// </summary>
	public readonly string ArgBoxKey;

	/// <summary>
	/// 参数类型
	/// </summary>
	public readonly int EventArgument;

	/// <summary>
	/// 别名
	/// </summary>
	public readonly string Alias;

	/// <summary>
	/// 字符串常量
	/// </summary>
	public readonly string ConstValue;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">类型</param>
	/// <param name="name">显示名称</param>
	/// <param name="desc">描述</param>
	/// <param name="argBoxKey">参数盒子Key</param>
	/// <param name="eventArgument">参数类型</param>
	/// <param name="alias">别名</param>
	/// <param name="constValue">字符串常量</param>
	public EventValueItem(int templateId, EEventValueType type, string name, string desc, string argBoxKey, int eventArgument, string alias, string constValue)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		ArgBoxKey = argBoxKey;
		EventArgument = eventArgument;
		Alias = alias;
		ConstValue = constValue;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventValueItem()
	{
		TemplateId = 0;
		Type = EEventValueType.Invalid;
		Name = null;
		Desc = null;
		ArgBoxKey = null;
		EventArgument = 0;
		Alias = null;
		ConstValue = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventValueItem(int templateId, EventValueItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		ArgBoxKey = other.ArgBoxKey;
		EventArgument = other.EventArgument;
		Alias = other.Alias;
		ConstValue = other.ConstValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventValueItem Duplicate(int templateId)
	{
		return new EventValueItem(templateId, this);
	}
}
