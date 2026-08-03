using System;
using Config.Common;

namespace Config;

[Serializable]
public class LegacyPointTypeItem : ConfigItem<LegacyPointTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 抽取的卡池
	/// - 决定了获取遗惠的时候，在哪个卡池里面抽取
	/// </summary>
	public readonly sbyte Group;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="group">抽取的卡池 - 决定了获取遗惠的时候，在哪个卡池里面抽取</param>
	public LegacyPointTypeItem(sbyte templateId, string name, sbyte group)
	{
		TemplateId = templateId;
		Name = name;
		Group = group;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LegacyPointTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Group = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LegacyPointTypeItem(sbyte templateId, LegacyPointTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Group = other.Group;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LegacyPointTypeItem Duplicate(int templateId)
	{
		return new LegacyPointTypeItem((sbyte)templateId, this);
	}
}
