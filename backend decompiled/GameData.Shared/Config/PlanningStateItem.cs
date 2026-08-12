using System;
using Config.Common;

namespace Config;

[Serializable]
public class PlanningStateItem : ConfigItem<PlanningStateItem, int>
{
	/// <summary>
	/// 状态模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 状态数值类型
	/// </summary>
	public readonly EPlanningStateValueType ValueType;

	/// <summary>
	/// 父状态
	/// - 子状态可以同时满足父状态,父状态则不一定能满足子状态
	/// </summary>
	public readonly int ParentState;

	/// <summary>
	/// 状态感知器类型
	/// - 用于关联代码中的状态感知器实现. 不填写表示该状态尚未实现, 不会被用于寻路. 该列仅由程序填写.
	/// </summary>
	public readonly EPlanningStateSensorType SensorType;

	/// <summary>
	/// 传入参数类型
	/// </summary>
	public readonly sbyte InputParamType;

	/// <summary>
	/// 产生参数类型
	/// </summary>
	public readonly sbyte OutputParamType;

	/// <summary>
	/// 产生参数值
	/// </summary>
	public readonly int OutputParamValue;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">状态模板 ID</param>
	/// <param name="valueType">状态数值类型</param>
	/// <param name="parentState">父状态 - 子状态可以同时满足父状态,父状态则不一定能满足子状态</param>
	/// <param name="sensorType">状态感知器类型 - 用于关联代码中的状态感知器实现. 不填写表示该状态尚未实现, 不会被用于寻路. 该列仅由程序填写.</param>
	/// <param name="inputParamType">传入参数类型</param>
	/// <param name="outputParamType">产生参数类型</param>
	/// <param name="outputParamValue">产生参数值</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PlanningStateItem Duplicate(int templateId)
	{
		return new PlanningStateItem(templateId, this);
	}
}
