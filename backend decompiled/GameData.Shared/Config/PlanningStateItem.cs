using System;
using Config.Common;

namespace Config;

[Serializable]
public class PlanningStateItem : ConfigItem<PlanningStateItem, int>
{
	public readonly int TemplateId;

	public readonly EPlanningStateValueType ValueType;

	public readonly int ParentState;

	public readonly EPlanningStateSensorType SensorType;

	public readonly sbyte InputParamType;

	public readonly sbyte OutputParamType;

	public readonly int OutputParamValue;

	public PlanningStateItem(int templateId, EPlanningStateValueType valueType, int parentState, EPlanningStateSensorType sensorType, sbyte inputParamType, sbyte outputParamType, int outputParamValue)
	{
		TemplateId = templateId;
		ValueType = valueType;
		ParentState = parentState;
		SensorType = sensorType;
		InputParamType = inputParamType;
		OutputParamType = outputParamType;
		OutputParamValue = outputParamValue;
	}

	public PlanningStateItem()
	{
		TemplateId = 0;
		ValueType = EPlanningStateValueType.Int;
		ParentState = 0;
		SensorType = EPlanningStateSensorType.None;
		InputParamType = 0;
		OutputParamType = 0;
		OutputParamValue = 0;
	}

	public PlanningStateItem(int templateId, PlanningStateItem other)
	{
		TemplateId = templateId;
		ValueType = other.ValueType;
		ParentState = other.ParentState;
		SensorType = other.SensorType;
		InputParamType = other.InputParamType;
		OutputParamType = other.OutputParamType;
		OutputParamValue = other.OutputParamValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PlanningStateItem Duplicate(int templateId)
	{
		return new PlanningStateItem(templateId, this);
	}
}
