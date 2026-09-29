using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationDetailedFilterItem : ConfigItem<SecretInformationDetailedFilterItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public SecretInformationDetailedFilterItem(short templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	public SecretInformationDetailedFilterItem()
	{
		TemplateId = 0;
		Name = null;
	}

	public SecretInformationDetailedFilterItem(short templateId, SecretInformationDetailedFilterItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationDetailedFilterItem Duplicate(int templateId)
	{
		return new SecretInformationDetailedFilterItem((short)templateId, this);
	}
}
