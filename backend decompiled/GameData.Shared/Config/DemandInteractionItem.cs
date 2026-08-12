using System;
using Config.Common;

namespace Config;

[Serializable]
public class DemandInteractionItem : ConfigItem<DemandInteractionItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 首事件
	/// </summary>
	public readonly string HeadEvent;

	/// <summary>
	/// 首事件同意选项
	/// </summary>
	public readonly string AgreeSelect;

	/// <summary>
	/// 同意后续
	/// </summary>
	public readonly string AfterAgree;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="name">名称</param>
	/// <param name="headEvent">首事件</param>
	/// <param name="agreeSelect">首事件同意选项</param>
	/// <param name="afterAgree">同意后续</param>
	public DemandInteractionItem(short templateId, string name, string headEvent, string agreeSelect, string afterAgree)
	{
		TemplateId = templateId;
		Name = name;
		HeadEvent = headEvent;
		AgreeSelect = agreeSelect;
		AfterAgree = afterAgree;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DemandInteractionItem()
	{
		TemplateId = 0;
		Name = null;
		HeadEvent = null;
		AgreeSelect = null;
		AfterAgree = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DemandInteractionItem(short templateId, DemandInteractionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HeadEvent = other.HeadEvent;
		AgreeSelect = other.AgreeSelect;
		AfterAgree = other.AfterAgree;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DemandInteractionItem Duplicate(int templateId)
	{
		return new DemandInteractionItem((short)templateId, this);
	}
}
