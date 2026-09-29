using GameData.Serializer;

namespace GameData.Domains.Taiwu;

[SerializeTo(typeof(sbyte))]
public enum TaiwuVillageStorageType : sbyte
{
	Inventory,
	Warehouse,
	Treasury,
	Stock,
	Trough,
	Count
}
