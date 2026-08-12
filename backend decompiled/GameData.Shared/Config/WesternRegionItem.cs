using System;
using Config.Common;

namespace Config;

[Serializable]
public class WesternRegionItem : ConfigItem<WesternRegionItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	public WesternRegionItem(short templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WesternRegionItem()
	{
		TemplateId = 0;
		Name = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WesternRegionItem(short templateId, WesternRegionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WesternRegionItem Duplicate(int templateId)
	{
		return new WesternRegionItem((short)templateId, this);
	}
}
