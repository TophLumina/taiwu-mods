using System;
using GameData.Domains.Item;

namespace Config.ConfigCells.Character;

[Serializable]
public struct PresetEquipmentItemWithProb(string typeName, short templateId, sbyte prob)
{
	public sbyte Type = ItemType.TypeName2TypeId[typeName];

	public short TemplateId = templateId;

	public sbyte Prob = prob;
}
