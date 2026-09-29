using System;
using Config.Common;

namespace Config;

[Serializable]
public class LandFormTypeItem : ConfigItem<LandFormTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly byte[] NormalResource;

	public readonly byte[] SpecialResource;

	public LandFormTypeItem(sbyte templateId, string name, string desc, byte[] normalResource, byte[] specialResource)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		NormalResource = normalResource;
		SpecialResource = specialResource;
	}

	public LandFormTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		NormalResource = new byte[10];
		SpecialResource = new byte[10];
	}

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

	public override LandFormTypeItem Duplicate(int templateId)
	{
		return new LandFormTypeItem((sbyte)templateId, this);
	}
}
