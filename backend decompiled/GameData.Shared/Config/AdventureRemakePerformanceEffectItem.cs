using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakePerformanceEffectItem : ConfigItem<AdventureRemakePerformanceEffectItem, short>
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
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 包含的特效
	/// </summary>
	public readonly List<short> Effects;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="effects">包含的特效</param>
	public AdventureRemakePerformanceEffectItem(short templateId, string name, string desc, List<short> effects)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Effects = effects;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureRemakePerformanceEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Effects = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureRemakePerformanceEffectItem(short templateId, AdventureRemakePerformanceEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Effects = other.Effects;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureRemakePerformanceEffectItem Duplicate(int templateId)
	{
		return new AdventureRemakePerformanceEffectItem((short)templateId, this);
	}
}
