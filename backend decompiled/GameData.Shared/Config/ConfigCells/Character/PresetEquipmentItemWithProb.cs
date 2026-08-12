using System;
using GameData.Domains.Item;

namespace Config.ConfigCells.Character;

/// <summary>
/// 带概率的预设装备物品.
/// 生成物品时, 会根据概率生成或不生成该物品.
/// </summary>
[Serializable]
public struct PresetEquipmentItemWithProb(string typeName, short templateId, sbyte prob)
{
	public sbyte Type = ItemType.TypeName2TypeId[typeName];

	public short TemplateId = templateId;

	public sbyte Prob = prob;
}
