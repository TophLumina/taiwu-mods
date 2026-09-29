using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MonthItem : ConfigItem<MonthItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Texture;

	public readonly List<sbyte> RecoverResourceType;

	public readonly sbyte FiveElementsType;

	public readonly string FiveElementsTypeDesc;

	public readonly List<sbyte> RecoverBodyParts;

	public MonthItem(sbyte templateId, string name, string texture, List<sbyte> recoverResourceType, sbyte fiveElementsType, string fiveElementsTypeDesc, List<sbyte> recoverBodyParts)
	{
		TemplateId = templateId;
		Name = name;
		Texture = texture;
		RecoverResourceType = recoverResourceType;
		FiveElementsType = fiveElementsType;
		FiveElementsTypeDesc = fiveElementsTypeDesc;
		RecoverBodyParts = recoverBodyParts;
	}

	public MonthItem()
	{
		TemplateId = 0;
		Name = null;
		Texture = null;
		RecoverResourceType = new List<sbyte>();
		FiveElementsType = 0;
		FiveElementsTypeDesc = null;
		RecoverBodyParts = new List<sbyte>();
	}

	public MonthItem(sbyte templateId, MonthItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Texture = other.Texture;
		RecoverResourceType = other.RecoverResourceType;
		FiveElementsType = other.FiveElementsType;
		FiveElementsTypeDesc = other.FiveElementsTypeDesc;
		RecoverBodyParts = other.RecoverBodyParts;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MonthItem Duplicate(int templateId)
	{
		return new MonthItem((sbyte)templateId, this);
	}
}
