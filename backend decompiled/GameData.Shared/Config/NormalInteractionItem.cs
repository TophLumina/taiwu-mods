using System;
using Config.Common;

namespace Config;

[Serializable]
public class NormalInteractionItem : ConfigItem<NormalInteractionItem, short>
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
	/// 这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错
	/// </summary>
	public readonly string[] HeadEvent;

	/// <summary>
	/// 这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错
	/// </summary>
	public readonly string[] AgreeAndSuccess;

	/// <summary>
	/// 这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错
	/// </summary>
	public readonly string[] AgreeAndFail;

	/// <summary>
	/// 这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错
	/// </summary>
	public readonly string[] Disagree;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="name">名称</param>
	/// <param name="headEvent">这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错</param>
	/// <param name="agreeAndSuccess">这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错</param>
	/// <param name="agreeAndFail">这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错</param>
	/// <param name="disagree">这一列不应有默认值，由前面生成，如果此列没有内容，会导致引用了该内容的事件报错</param>
	public NormalInteractionItem(short templateId, string name, string[] headEvent, string[] agreeAndSuccess, string[] agreeAndFail, string[] disagree)
	{
		TemplateId = templateId;
		Name = name;
		HeadEvent = headEvent;
		AgreeAndSuccess = agreeAndSuccess;
		AgreeAndFail = agreeAndFail;
		Disagree = disagree;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public NormalInteractionItem()
	{
		TemplateId = 0;
		Name = null;
		HeadEvent = null;
		AgreeAndSuccess = null;
		AgreeAndFail = null;
		Disagree = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public NormalInteractionItem(short templateId, NormalInteractionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HeadEvent = other.HeadEvent;
		AgreeAndSuccess = other.AgreeAndSuccess;
		AgreeAndFail = other.AgreeAndFail;
		Disagree = other.Disagree;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override NormalInteractionItem Duplicate(int templateId)
	{
		return new NormalInteractionItem((short)templateId, this);
	}
}
