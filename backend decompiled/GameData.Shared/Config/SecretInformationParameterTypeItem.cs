using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationParameterTypeItem : ConfigItem<SecretInformationParameterTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public SecretInformationParameterTypeItem(sbyte templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	public SecretInformationParameterTypeItem()
	{
		TemplateId = 0;
		Name = null;
	}

	public SecretInformationParameterTypeItem(sbyte templateId, SecretInformationParameterTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationParameterTypeItem Duplicate(int templateId)
	{
		return new SecretInformationParameterTypeItem((sbyte)templateId, this);
	}
}
