namespace GameData.Domains.Taiwu.VillagerRole;

/// <summary>
/// 村民身份的产出存储类型，存档数据，只能增加，不可修改
/// </summary>
public enum VillagerRoleStorageType
{
	/// <summary>
	/// 行囊
	/// </summary>
	Inventory,
	/// <summary>
	/// 仓库
	/// </summary>
	Warehouse,
	/// <summary>
	/// 公库（新版太吾村库房）
	/// </summary>
	Treasury,
	/// <summary>
	/// 饲槽
	/// </summary>
	Trough,
	/// <summary>
	/// 货仓-储物空间
	/// </summary>
	StockStorageWarehouse,
	/// <summary>
	/// 货仓-货架 (旧公库转移的目标)
	/// </summary>
	StockStorageGoodsShelf,
	/// <summary>
	/// 工库-储物空间
	/// </summary>
	CraftStorageWarehouse,
	/// <summary>
	/// 工库-制造
	/// </summary>
	CraftStorageMaterial,
	/// <summary>
	/// 工库-修理
	/// </summary>
	CraftStorageToFix,
	/// <summary>
	/// 工库-拆解
	/// </summary>
	CraftStorageToDisassemble,
	/// <summary>
	/// 药库-储物空间
	/// </summary>
	MedicineStorageWarehouse,
	/// <summary>
	/// 药库-制药
	/// </summary>
	MedicineStorageMaterial,
	/// <summary>
	/// 药库-解毒
	/// </summary>
	MedicineStorageToDetox,
	/// <summary>
	/// 药库-淬毒
	/// </summary>
	MedicineStorageToAddPoison,
	/// <summary>
	/// 厨仓-储物空间
	/// </summary>
	FoodStorageWarehouse,
	/// <summary>
	/// 厨仓-制药
	/// </summary>
	FoodStorageMaterial,
	/// <summary>
	/// 自动适配存储空间
	/// </summary>
	AutoStorageWarehouse,
	/// <summary>
	/// 自动适配制造空间
	/// </summary>
	AutoStorageMaterial
}
