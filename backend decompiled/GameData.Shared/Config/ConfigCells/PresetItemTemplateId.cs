using System;
using GameData.Domains.Item;

namespace Config.ConfigCells;

[Serializable]
public struct PresetItemTemplateId(string type, short templateId)
{
	public sbyte ItemType = GameData.Domains.Item.ItemType.TypeName2TypeId[type];

	public short TemplateId = templateId;
}
