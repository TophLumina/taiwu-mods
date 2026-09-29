using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationGeneralFilterItem : ConfigItem<SecretInformationGeneralFilterItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly List<short> DetailedFilter;

	public SecretInformationGeneralFilterItem(short templateId, string name, List<short> detailedFilter)
	{
		TemplateId = templateId;
		Name = name;
		DetailedFilter = detailedFilter;
	}

	public SecretInformationGeneralFilterItem()
	{
		TemplateId = 0;
		Name = null;
		DetailedFilter = null;
	}

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

	public override SecretInformationGeneralFilterItem Duplicate(int templateId)
	{
		return new SecretInformationGeneralFilterItem((short)templateId, this);
	}
}
