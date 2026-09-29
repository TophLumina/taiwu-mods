using System;
using Config.Common;

namespace Config;

[Serializable]
public class PlanningParameterItem : ConfigItem<PlanningParameterItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly EPlanningParameterType Type;

	public readonly EPlanningParameterValueType ValueType;

	public readonly bool HideInUI;

	public PlanningParameterItem(sbyte templateId, EPlanningParameterType type, EPlanningParameterValueType valueType, bool hideInUI)
	{
		TemplateId = templateId;
		Type = type;
		ValueType = valueType;
		HideInUI = hideInUI;
	}

	public PlanningParameterItem()
	{
		TemplateId = 0;
		Type = EPlanningParameterType.Integer;
		ValueType = EPlanningParameterValueType.Int;
		HideInUI = false;
	}

	public PlanningParameterItem(sbyte templateId, PlanningParameterItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		ValueType = other.ValueType;
		HideInUI = other.HideInUI;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PlanningParameterItem Duplicate(int templateId)
	{
		return new PlanningParameterItem((sbyte)templateId, this);
	}
}
