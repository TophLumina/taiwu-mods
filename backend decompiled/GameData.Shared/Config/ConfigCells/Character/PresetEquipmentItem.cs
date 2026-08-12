using System;
using GameData.Domains.Item;

namespace Config.ConfigCells.Character;

[Serializable]
public struct PresetEquipmentItem
{
	public sbyte Type;

	public short TemplateId;

	public PresetEquipmentItem(string typeName, short templateId)
	{
		Type = ItemType.TypeName2TypeId[typeName];
		TemplateId = templateId;
	}

	public PresetEquipmentItem(sbyte type, short templateId)
	{
		Type = type;
		TemplateId = templateId;
	}
}
