using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketAffixesItem : ConfigItem<CricketAffixesItem, short>
{
	/// <summary>
	/// 词条ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 词条名称
	/// - 显示在tips中的词条名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 词条描述
	/// - 显示在促织tips中对词条的说明文案
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 成长权重
	/// </summary>
	public readonly short[] Weights;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">词条ID</param>
	/// <param name="name">词条名称 - 显示在tips中的词条名称</param>
	/// <param name="desc">词条描述 - 显示在促织tips中对词条的说明文案</param>
	/// <param name="weights">成长权重</param>
	public CricketAffixesItem(short templateId, string name, string desc, short[] weights)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Weights = weights;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CricketAffixesItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Weights = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CricketAffixesItem(short templateId, CricketAffixesItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Weights = other.Weights;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CricketAffixesItem Duplicate(int templateId)
	{
		return new CricketAffixesItem((short)templateId, this);
	}
}
