namespace GameData.Domains.Building;

/// <summary>
/// 批量上货操作类型
/// </summary>
public enum MultiSelectOperateType
{
	/// <summary>
	/// 出售到默认位置
	/// </summary>
	SoldToDefault,
	/// <summary>
	/// 行囊移动到出售
	/// </summary>
	InventoryToSold,
	/// <summary>
	/// 出售移动到行囊
	/// </summary>
	SoldToInventory,
	/// <summary>
	/// 仓库移动到出售
	/// </summary>
	WarehouseToSold,
	/// <summary>
	/// 出售移动到仓库
	/// </summary>
	SoldToWarehouse,
	/// <summary>
	/// 公库移动到出售
	/// </summary>
	TreasuryToSold,
	/// <summary>
	/// 出售移动到公库
	/// </summary>
	SoldToTreasury,
	/// <summary>
	/// 货仓-货架移动到出售
	/// </summary>
	StockStorageGoodsShelfToSold,
	/// <summary>
	/// 出售移动到货仓-货架
	/// </summary>
	SoldToStockStorageGoodsShelf
}
