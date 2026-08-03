using System;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class EventArgumentItem : ConfigItem<EventArgumentItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 参数类型
	/// </summary>
	public readonly EEventArgumentType Type;

	/// <summary>
	/// 参数显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 参数描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 默认值
	/// </summary>
	public readonly string DefaultValue;

	/// <summary>
	/// 是否为表达式
	/// - 此处填写为默认值.
	/// </summary>
	public readonly bool IsExpression;

	/// <summary>
	/// 是否允许表达式/常量输入切换
	/// </summary>
	public readonly bool AllowSwitchingExpression;

	/// <summary>
	/// 对应表格
	/// </summary>
	public readonly string ConfigTable;

	/// <summary>
	/// 自定义枚举
	/// </summary>
	public readonly string[] CustomEnumText;

	/// <summary>
	/// 自定义枚举值
	/// - 用于手动指定自定义枚举值序号对应的数值.
	/// </summary>
	public readonly int[] CustomEnumValues;

	/// <summary>
	/// 枚举范围
	/// - 用于对应表格时限定值的范围
	/// </summary>
	public readonly IntPair EnumRange;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">参数类型</param>
	/// <param name="name">参数显示名称</param>
	/// <param name="desc">参数描述</param>
	/// <param name="defaultValue">默认值</param>
	/// <param name="isExpression">是否为表达式 - 此处填写为默认值.</param>
	/// <param name="allowSwitchingExpression">是否允许表达式/常量输入切换</param>
	/// <param name="configTable">对应表格</param>
	/// <param name="customEnumText">自定义枚举</param>
	/// <param name="customEnumValues">自定义枚举值 - 用于手动指定自定义枚举值序号对应的数值.</param>
	/// <param name="enumRange">枚举范围 - 用于对应表格时限定值的范围</param>
	public EventArgumentItem(int templateId, EEventArgumentType type, string name, string desc, string defaultValue, bool isExpression, bool allowSwitchingExpression, string configTable, string[] customEnumText, int[] customEnumValues, IntPair enumRange)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		DefaultValue = defaultValue;
		IsExpression = isExpression;
		AllowSwitchingExpression = allowSwitchingExpression;
		ConfigTable = configTable;
		CustomEnumText = customEnumText;
		CustomEnumValues = customEnumValues;
		EnumRange = enumRange;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventArgumentItem()
	{
		TemplateId = 0;
		Type = EEventArgumentType.Invalid;
		Name = null;
		Desc = null;
		DefaultValue = null;
		IsExpression = false;
		AllowSwitchingExpression = true;
		ConfigTable = null;
		CustomEnumText = new string[0];
		CustomEnumValues = new int[0];
		EnumRange = new IntPair(0, 0);
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventArgumentItem(int templateId, EventArgumentItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		DefaultValue = other.DefaultValue;
		IsExpression = other.IsExpression;
		AllowSwitchingExpression = other.AllowSwitchingExpression;
		ConfigTable = other.ConfigTable;
		CustomEnumText = other.CustomEnumText;
		CustomEnumValues = other.CustomEnumValues;
		EnumRange = other.EnumRange;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventArgumentItem Duplicate(int templateId)
	{
		return new EventArgumentItem(templateId, this);
	}
}
