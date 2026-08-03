using System;
using GameData.Domains.Item;

namespace Config.ConfigCells;

[Serializable]
public struct PresetItemTemplateIdGroup(string typeName, short startId, sbyte groupLength)
{
	public sbyte ItemType = GameData.Domains.Item.ItemType.TypeName2TypeId[typeName];

	public short StartId = startId;

	public sbyte GroupLength = groupLength;
}
