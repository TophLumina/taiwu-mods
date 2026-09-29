using System;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class LegendaryBookPropertyBonusTypeItem : ConfigItem<LegendaryBookPropertyBonusTypeItem, short>
{
	public readonly short TemplateId;

	public readonly PropertyAndValue[] PropertyBonusList;

	public LegendaryBookPropertyBonusTypeItem(short templateId, PropertyAndValue[] propertyBonusList)
	{
		TemplateId = templateId;
		PropertyBonusList = propertyBonusList;
	}

	public LegendaryBookPropertyBonusTypeItem()
	{
		TemplateId = 0;
		PropertyBonusList = new PropertyAndValue[0];
	}

	public LegendaryBookPropertyBonusTypeItem(short templateId, LegendaryBookPropertyBonusTypeItem other)
	{
		TemplateId = templateId;
		PropertyBonusList = other.PropertyBonusList;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LegendaryBookPropertyBonusTypeItem Duplicate(int templateId)
	{
		return new LegendaryBookPropertyBonusTypeItem((short)templateId, this);
	}
}
