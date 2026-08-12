using System;
using Config.Common;

namespace Config;

[Serializable]
public class MainStoryLineProgressItem : ConfigItem<MainStoryLineProgressItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string MainStoryName;

	/// <summary>
	/// 序号
	/// </summary>
	public readonly short MainStoryOrder;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="mainStoryName">名称</param>
	/// <param name="mainStoryOrder">序号</param>
	public MainStoryLineProgressItem(short templateId, string mainStoryName, short mainStoryOrder)
	{
		TemplateId = templateId;
		MainStoryName = mainStoryName;
		MainStoryOrder = mainStoryOrder;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MainStoryLineProgressItem()
	{
		TemplateId = 0;
		MainStoryName = null;
		MainStoryOrder = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MainStoryLineProgressItem(short templateId, MainStoryLineProgressItem other)
	{
		TemplateId = templateId;
		MainStoryName = other.MainStoryName;
		MainStoryOrder = other.MainStoryOrder;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MainStoryLineProgressItem Duplicate(int templateId)
	{
		return new MainStoryLineProgressItem((short)templateId, this);
	}
}
