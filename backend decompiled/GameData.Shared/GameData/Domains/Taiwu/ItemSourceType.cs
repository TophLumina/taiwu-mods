using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 物品来源的枚举
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum ItemSourceType
{
	/// <summary>
	/// 无效值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 装备
	/// </summary>
	Equipment,
	/// <summary>
	/// 行囊
	/// </summary>
	Inventory,
	/// <summary>
	/// 仓库
	/// </summary>
	Warehouse,
	/// <summary>
	/// 公库
	/// </summary>
	Treasury,
	/// <summary>
	/// 饲槽
	/// </summary>
	Trough,
	/// <summary>
	/// 货仓
	/// </summary>
	Stock,
	/// <summary>
	/// 装备预设
	/// </summary>
	EquipmentPlan,
	/// <summary>
	/// 蛟池
	/// </summary>
	JiaoPool,
	/// <summary>
	/// 定居点库房（非太吾村）
	/// </summary>
	SettlementTreasury,
	/// <summary>
	/// 人物资源，资源道具化的特殊用法
	/// </summary>
	Resources,
	/// <summary>
	/// 商店物品（非回购），用于ViewShop界面/ShopExchange/ViewSettlementShop
	/// Shop0,Shop1,Shop2 在库房交易时可作为库房Source
	/// </summary>
	Shop0,
	Shop1,
	Shop2,
	Shop3,
	Shop4,
	Shop5,
	Shop6,
	/// <summary>
	/// 回购，用于ViewShop界面/ShopExchange
	/// </summary>
	BuyBack
}
