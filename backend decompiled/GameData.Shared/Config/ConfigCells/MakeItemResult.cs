using System;
using GameData.Domains.Item;

namespace Config.ConfigCells;

[Serializable]
public struct MakeItemResult(string typeName, short templateId)
{
	public sbyte ItemType = GameData.Domains.Item.ItemType.TypeName2TypeId[typeName];

	public short TemplateId = templateId;
}
