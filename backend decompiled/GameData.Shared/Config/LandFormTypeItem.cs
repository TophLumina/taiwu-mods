using System;
using Config.Common;

namespace Config;

[Serializable]
public class LandFormTypeItem : ConfigItem<LandFormTypeItem, sbyte>
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
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 普通资源
	/// - 用于计算初始生成及成长扩张。由辅助配置列H-Q、R-AA组合，不可直接配置此列
	/// - H-Q、R-AA的配置列必须填写所有单元格，没有资源就写0。否则这里的配置组合结果会出错
	/// </summary>
	public readonly byte[] NormalResource;

	/// <summary>
	/// 特殊资源
	/// </summary>
	public readonly byte[] SpecialResource;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="normalResource">普通资源 - 用于计算初始生成及成长扩张。由辅助配置列H-Q、R-AA组合，不可直接配置此列 H-Q、R-AA的配置列必须填写所有单元格，没有资源就写0。否则这里的配置组合结果会出错</param>
	/// <param name="specialResource">特殊资源</param>
	public LandFormTypeItem(sbyte templateId, string name, string desc, byte[] normalResource, byte[] specialResource)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		NormalResource = normalResource;
		SpecialResource = specialResource;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LandFormTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		NormalResource = new byte[10];
		SpecialResource = new byte[10];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LandFormTypeItem(sbyte templateId, LandFormTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		NormalResource = other.NormalResource;
		SpecialResource = other.SpecialResource;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LandFormTypeItem Duplicate(int templateId)
	{
		return new LandFormTypeItem((sbyte)templateId, this);
	}
}
