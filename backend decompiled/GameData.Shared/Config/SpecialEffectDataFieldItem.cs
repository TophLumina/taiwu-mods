using System;
using Config.Common;

namespace Config;

[Serializable]
public class SpecialEffectDataFieldItem : ConfigItem<SpecialEffectDataFieldItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示名称
	/// - 主要用于战斗状态提示文字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 数据字段名
	/// - 对应GameData.Domains.SpecialEffect.AffectedDataHelper.FieldName2FieldId中的Key
	/// </summary>
	public readonly string FieldName;

	/// <summary>
	/// 生效所需自定义参数customParam值，为-1表示无要求
	/// </summary>
	public readonly int[] RequireCustomParam;

	/// <summary>
	/// 表现除数
	/// </summary>
	public readonly int DisplayDivisor;

	/// <summary>
	/// 表现格式
	/// </summary>
	public readonly string DisplayFormat;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">显示名称 - 主要用于战斗状态提示文字</param>
	/// <param name="fieldName">数据字段名 - 对应GameData.Domains.SpecialEffect.AffectedDataHelper.FieldName2FieldId中的Key</param>
	/// <param name="requireCustomParam">生效所需自定义参数customParam值，为-1表示无要求</param>
	/// <param name="displayDivisor">表现除数</param>
	/// <param name="displayFormat">表现格式</param>
	public SpecialEffectDataFieldItem(short templateId, string name, string fieldName, int[] requireCustomParam, int displayDivisor, string displayFormat)
	{
		TemplateId = templateId;
		Name = name;
		FieldName = fieldName;
		RequireCustomParam = requireCustomParam;
		DisplayDivisor = displayDivisor;
		DisplayFormat = displayFormat;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SpecialEffectDataFieldItem()
	{
		TemplateId = 0;
		Name = null;
		FieldName = null;
		RequireCustomParam = new int[3] { -1, -1, -1 };
		DisplayDivisor = -1;
		DisplayFormat = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SpecialEffectDataFieldItem Duplicate(int templateId)
	{
		return new SpecialEffectDataFieldItem((short)templateId, this);
	}
}
