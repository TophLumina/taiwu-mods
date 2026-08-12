using System;
using GameData.Domains.Item;

namespace Config.ConfigCells.Character;

[Serializable]
public struct PresetInventoryItem
{
	public sbyte Type;

	public short TemplateId;

	public int Amount;

	public sbyte SpawnChance;

	public PresetInventoryItem(string typeName, short templateId, int amount, sbyte spawnChance = 100)
	{
		Type = ItemType.TypeName2TypeId[typeName];
		TemplateId = templateId;
		Amount = amount;
		SpawnChance = spawnChance;
	}

	public PresetInventoryItem(sbyte type, short templateId, int amount, sbyte spawnChance = 100)
	{
		Type = type;
		TemplateId = templateId;
		Amount = amount;
		SpawnChance = spawnChance;
	}
}
