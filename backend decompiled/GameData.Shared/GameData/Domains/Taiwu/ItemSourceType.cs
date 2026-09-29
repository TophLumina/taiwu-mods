using GameData.Serializer;

namespace GameData.Domains.Taiwu;

[SerializeTo(typeof(sbyte))]
public enum ItemSourceType
{
	Invalid = -1,
	Equipment,
	Inventory,
	Warehouse,
	Treasury,
	Trough,
	Stock,
	EquipmentPlan,
	JiaoPool,
	SettlementTreasury,
	Resources,
	Shop0,
	Shop1,
	Shop2,
	Shop3,
	Shop4,
	Shop5,
	Shop6,
	BuyBack
}
