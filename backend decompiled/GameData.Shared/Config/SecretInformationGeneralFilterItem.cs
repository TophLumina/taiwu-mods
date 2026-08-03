using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationGeneralFilterItem : ConfigItem<SecretInformationGeneralFilterItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 详细筛选
	/// </summary>
	public readonly List<short> DetailedFilter;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="detailedFilter">详细筛选</param>
	public SecretInformationGeneralFilterItem(short templateId, string name, List<short> detailedFilter)
	{
		TemplateId = templateId;
		Name = name;
		DetailedFilter = detailedFilter;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationGeneralFilterItem()
	{
		TemplateId = 0;
		Name = null;
		DetailedFilter = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationGeneralFilterItem(short templateId, SecretInformationGeneralFilterItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		DetailedFilter = other.DetailedFilter;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationGeneralFilterItem Duplicate(int templateId)
	{
		return new SecretInformationGeneralFilterItem((short)templateId, this);
	}
}
