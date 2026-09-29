using System;
using Config.Common;

namespace Config;

[Serializable]
public class RelationDisplayTypeItem : ConfigItem<RelationDisplayTypeItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte[] RelationTypeIds;

	public readonly byte TipDisplayOrder;

	public readonly byte TipToTaiwuDisplayOrder;

	public RelationDisplayTypeItem(short templateId, string name, sbyte[] relationTypeIds, byte tipDisplayOrder, byte tipToTaiwuDisplayOrder)
	{
		TemplateId = templateId;
		Name = name;
		RelationTypeIds = relationTypeIds;
		TipDisplayOrder = tipDisplayOrder;
		TipToTaiwuDisplayOrder = tipToTaiwuDisplayOrder;
	}

	public RelationDisplayTypeItem()
	{
		TemplateId = 0;
		Name = null;
		RelationTypeIds = new sbyte[0];
		TipDisplayOrder = 0;
		TipToTaiwuDisplayOrder = 0;
	}

	public RelationDisplayTypeItem(short templateId, RelationDisplayTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		RelationTypeIds = other.RelationTypeIds;
		TipDisplayOrder = other.TipDisplayOrder;
		TipToTaiwuDisplayOrder = other.TipToTaiwuDisplayOrder;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override RelationDisplayTypeItem Duplicate(int templateId)
	{
		return new RelationDisplayTypeItem((short)templateId, this);
	}
}
