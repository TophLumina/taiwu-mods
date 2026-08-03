using System;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanTerrainItem : ConfigItem<TeaHorseCaravanTerrainItem, short>
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
	/// 出现权重
	/// </summary>
	public readonly sbyte Weighted;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="weighted">出现权重</param>
	public TeaHorseCaravanTerrainItem(short templateId, string name, string desc, sbyte weighted)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Weighted = weighted;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TeaHorseCaravanTerrainItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Weighted = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TeaHorseCaravanTerrainItem(short templateId, TeaHorseCaravanTerrainItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Weighted = other.Weighted;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TeaHorseCaravanTerrainItem Duplicate(int templateId)
	{
		return new TeaHorseCaravanTerrainItem((short)templateId, this);
	}
}
