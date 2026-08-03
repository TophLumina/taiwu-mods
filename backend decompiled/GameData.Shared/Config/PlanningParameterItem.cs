using System;
using Config.Common;

namespace Config;

[Serializable]
public class PlanningParameterItem : ConfigItem<PlanningParameterItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 参数类型
	/// </summary>
	public readonly EPlanningParameterType Type;

	/// <summary>
	/// 参数数值类型
	/// </summary>
	public readonly EPlanningParameterValueType ValueType;

	/// <summary>
	/// 是否在UI上隐藏
	/// </summary>
	public readonly bool HideInUI;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">参数类型</param>
	/// <param name="valueType">参数数值类型</param>
	/// <param name="hideInUI">是否在UI上隐藏</param>
	public PlanningParameterItem(sbyte templateId, EPlanningParameterType type, EPlanningParameterValueType valueType, bool hideInUI)
	{
		TemplateId = templateId;
		Type = type;
		ValueType = valueType;
		HideInUI = hideInUI;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PlanningParameterItem()
	{
		TemplateId = 0;
		Type = EPlanningParameterType.Integer;
		ValueType = EPlanningParameterValueType.Int;
		HideInUI = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PlanningParameterItem Duplicate(int templateId)
	{
		return new PlanningParameterItem((sbyte)templateId, this);
	}
}
