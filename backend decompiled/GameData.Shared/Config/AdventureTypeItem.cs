using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureTypeItem : ConfigItem<AdventureTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string DisplayName;

	public readonly bool IsTrivial;

	public readonly string ColorName;

	public AdventureTypeItem(sbyte templateId, string displayName, bool isTrivial, string colorName)
	{
		TemplateId = templateId;
		DisplayName = displayName;
		IsTrivial = isTrivial;
		ColorName = colorName;
	}

	public AdventureTypeItem()
	{
		TemplateId = 0;
		DisplayName = null;
		IsTrivial = true;
		ColorName = null;
	}

	public AdventureTypeItem(sbyte templateId, AdventureTypeItem other)
	{
		TemplateId = templateId;
		DisplayName = other.DisplayName;
		IsTrivial = other.IsTrivial;
		ColorName = other.ColorName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureTypeItem Duplicate(int templateId)
	{
		return new AdventureTypeItem((sbyte)templateId, this);
	}
}
