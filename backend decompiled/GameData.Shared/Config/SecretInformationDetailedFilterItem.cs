using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationDetailedFilterItem : ConfigItem<SecretInformationDetailedFilterItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名字</param>
	public SecretInformationDetailedFilterItem(short templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationDetailedFilterItem()
	{
		TemplateId = 0;
		Name = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationDetailedFilterItem(short templateId, SecretInformationDetailedFilterItem other)
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
	public override SecretInformationDetailedFilterItem Duplicate(int templateId)
	{
		return new SecretInformationDetailedFilterItem((short)templateId, this);
	}
}
