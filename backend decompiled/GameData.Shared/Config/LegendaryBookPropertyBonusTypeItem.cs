using System;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class LegendaryBookPropertyBonusTypeItem : ConfigItem<LegendaryBookPropertyBonusTypeItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 属性加成列表
	/// </summary>
	public readonly PropertyAndValue[] PropertyBonusList;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="propertyBonusList">属性加成列表</param>
	public LegendaryBookPropertyBonusTypeItem(short templateId, PropertyAndValue[] propertyBonusList)
	{
		TemplateId = templateId;
		PropertyBonusList = propertyBonusList;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LegendaryBookPropertyBonusTypeItem()
	{
		TemplateId = 0;
		PropertyBonusList = new PropertyAndValue[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LegendaryBookPropertyBonusTypeItem(short templateId, LegendaryBookPropertyBonusTypeItem other)
	{
		TemplateId = templateId;
		PropertyBonusList = other.PropertyBonusList;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LegendaryBookPropertyBonusTypeItem Duplicate(int templateId)
	{
		return new LegendaryBookPropertyBonusTypeItem((short)templateId, this);
	}
}
