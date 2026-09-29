using System;
using Config.Common;

namespace Config;

[Serializable]
public class SpecialEffectDataFieldItem : ConfigItem<SpecialEffectDataFieldItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string FieldName;

	public readonly int[] RequireCustomParam;

	public readonly int DisplayDivisor;

	public readonly string DisplayFormat;

	public SpecialEffectDataFieldItem(short templateId, string name, string fieldName, int[] requireCustomParam, int displayDivisor, string displayFormat)
	{
		TemplateId = templateId;
		Name = name;
		FieldName = fieldName;
		RequireCustomParam = requireCustomParam;
		DisplayDivisor = displayDivisor;
		DisplayFormat = displayFormat;
	}

	public SpecialEffectDataFieldItem()
	{
		TemplateId = 0;
		Name = null;
		FieldName = null;
		RequireCustomParam = new int[3] { -1, -1, -1 };
		DisplayDivisor = -1;
		DisplayFormat = null;
	}

	public SpecialEffectDataFieldItem(short templateId, SpecialEffectDataFieldItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		FieldName = other.FieldName;
		RequireCustomParam = other.RequireCustomParam;
		DisplayDivisor = other.DisplayDivisor;
		DisplayFormat = other.DisplayFormat;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SpecialEffectDataFieldItem Duplicate(int templateId)
	{
		return new SpecialEffectDataFieldItem((short)templateId, this);
	}
}
