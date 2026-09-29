using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedRelationItem : ConfigItem<SecretInformationAppliedRelationItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public SecretInformationAppliedRelationItem(sbyte templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	public SecretInformationAppliedRelationItem()
	{
		TemplateId = 0;
		Name = null;
	}

	public SecretInformationAppliedRelationItem(sbyte templateId, SecretInformationAppliedRelationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationAppliedRelationItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedRelationItem((sbyte)templateId, this);
	}
}
