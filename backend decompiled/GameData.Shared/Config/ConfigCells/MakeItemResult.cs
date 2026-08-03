using System;
using GameData.Domains.Item;

namespace Config.ConfigCells;

/// <summary>
/// 用于MakeItemSubType里表示具体制造的东西，格式为{"Weapon",袖里箭}
/// </summary>
[Serializable]
public struct MakeItemResult(string typeName, short templateId)
{
	public sbyte ItemType = GameData.Domains.Item.ItemType.TypeName2TypeId[typeName];

	public short TemplateId = templateId;
}
