using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakeBlockEffectItem : ConfigItem<AdventureRemakeBlockEffectItem, short>
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
	/// 名称
	/// </summary>
	public readonly string LoadName;

	/// <summary>
	/// 层级
	/// </summary>
	public readonly EAdventureRemakeBlockEffectLocation Location;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="loadName">名称</param>
	/// <param name="location">层级</param>
	public AdventureRemakeBlockEffectItem(short templateId, string name, string desc, string loadName, EAdventureRemakeBlockEffectLocation location)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		LoadName = loadName;
		Location = location;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureRemakeBlockEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		LoadName = null;
		Location = EAdventureRemakeBlockEffectLocation.Down;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureRemakeBlockEffectItem(short templateId, AdventureRemakeBlockEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		LoadName = other.LoadName;
		Location = other.Location;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureRemakeBlockEffectItem Duplicate(int templateId)
	{
		return new AdventureRemakeBlockEffectItem((short)templateId, this);
	}
}
