using System.Collections.Generic;

namespace GameData.Domains.Taiwu.VillagerRole;

public class SharedData
{
	private static readonly IReadOnlyList<VillagerRoleActionType> MerchantActionTypeList = new List<VillagerRoleActionType>
	{
		VillagerRoleActionType.SellToMoney,
		VillagerRoleActionType.BuyItem,
		VillagerRoleActionType.BuyTool,
		VillagerRoleActionType.BuyMaterial
	};

	private static readonly IReadOnlyList<VillagerRoleActionType> CraftsmanActionTypeList = new List<VillagerRoleActionType>
	{
		VillagerRoleActionType.CraftEquipment,
		VillagerRoleActionType.RepairItem,
		VillagerRoleActionType.DisassembleCraftItemToItem,
		VillagerRoleActionType.DisassembleCraftItemToResource
	};

	private static readonly IReadOnlyList<VillagerRoleActionType> DoctorActionTypeList = new List<VillagerRoleActionType>
	{
		VillagerRoleActionType.CraftMedicine,
		VillagerRoleActionType.DetoxItem,
		VillagerRoleActionType.AddPoisonToItem
	};

	private static readonly IReadOnlyList<VillagerRoleActionType> FarmerActionTypeList = new List<VillagerRoleActionType> { VillagerRoleActionType.CookFood };

	public static readonly IReadOnlyDictionary<TaiwuVillageStorageType, IReadOnlyList<VillagerRoleActionType>> ActionDict = new Dictionary<TaiwuVillageStorageType, IReadOnlyList<VillagerRoleActionType>> { 
	{
		TaiwuVillageStorageType.Stock,
		MerchantActionTypeList
	} };

	private static readonly IReadOnlyList<VillagerRoleStorageType> SellToMoneyStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Inventory,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> BuyItemStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageWarehouse,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.CraftStorageToDisassemble,
		VillagerRoleStorageType.MedicineStorageToAddPoison
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> BuyToolStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageWarehouse,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.AutoStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> BuyMaterialStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageWarehouse,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.AutoStorageMaterial
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> CraftEquipmentStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.CraftStorageWarehouse,
		VillagerRoleStorageType.CraftStorageToDisassemble,
		VillagerRoleStorageType.MedicineStorageToAddPoison
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> RepairItemStorageList = CraftEquipmentStorageList;

	private static readonly IReadOnlyList<VillagerRoleStorageType> DisassembleItemToItemStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.CraftStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> DisassembleItemToResourceStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Inventory,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.CraftStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> CraftMedicineStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.MedicineStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> DetoxItemStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.CraftStorageToDisassemble,
		VillagerRoleStorageType.MedicineStorageWarehouse,
		VillagerRoleStorageType.MedicineStorageToAddPoison,
		VillagerRoleStorageType.FoodStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> AddPoisonToItemStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.CraftStorageToDisassemble,
		VillagerRoleStorageType.MedicineStorageWarehouse,
		VillagerRoleStorageType.MedicineStorageToDetox,
		VillagerRoleStorageType.FoodStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> CookFoodStorageList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.MedicineStorageToAddPoison,
		VillagerRoleStorageType.FoodStorageWarehouse
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> CollectFoodStorageTypeList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.FoodStorageMaterial
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> CollectHerbStorageTypeList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.MedicineStorageMaterial
	};

	private static readonly IReadOnlyList<VillagerRoleStorageType> CollectDefaultStorageTypeList = new List<VillagerRoleStorageType>
	{
		VillagerRoleStorageType.Warehouse,
		VillagerRoleStorageType.Treasury,
		VillagerRoleStorageType.StockStorageGoodsShelf,
		VillagerRoleStorageType.CraftStorageMaterial,
		VillagerRoleStorageType.CraftStorageToDisassemble
	};

	public static readonly IReadOnlyDictionary<VillagerRoleActionType, IReadOnlyList<VillagerRoleStorageType>> StorageDict = new Dictionary<VillagerRoleActionType, IReadOnlyList<VillagerRoleStorageType>>
	{
		{
			VillagerRoleActionType.SellToMoney,
			SellToMoneyStorageList
		},
		{
			VillagerRoleActionType.BuyItem,
			BuyItemStorageList
		},
		{
			VillagerRoleActionType.BuyTool,
			BuyToolStorageList
		},
		{
			VillagerRoleActionType.BuyMaterial,
			BuyMaterialStorageList
		},
		{
			VillagerRoleActionType.CraftEquipment,
			CraftEquipmentStorageList
		},
		{
			VillagerRoleActionType.RepairItem,
			RepairItemStorageList
		},
		{
			VillagerRoleActionType.DisassembleCraftItemToItem,
			DisassembleItemToItemStorageList
		},
		{
			VillagerRoleActionType.DisassembleCraftItemToResource,
			DisassembleItemToResourceStorageList
		},
		{
			VillagerRoleActionType.CraftMedicine,
			CraftMedicineStorageList
		},
		{
			VillagerRoleActionType.DetoxItem,
			DetoxItemStorageList
		},
		{
			VillagerRoleActionType.AddPoisonToItem,
			AddPoisonToItemStorageList
		},
		{
			VillagerRoleActionType.CookFood,
			CookFoodStorageList
		}
	};

	public static readonly IReadOnlyDictionary<VillagerRoleActionType, VillagerRoleStorageType> StorageDefaultDict = new Dictionary<VillagerRoleActionType, VillagerRoleStorageType>
	{
		{
			VillagerRoleActionType.SellToMoney,
			VillagerRoleStorageType.StockStorageWarehouse
		},
		{
			VillagerRoleActionType.BuyItem,
			VillagerRoleStorageType.StockStorageWarehouse
		},
		{
			VillagerRoleActionType.BuyTool,
			VillagerRoleStorageType.StockStorageWarehouse
		},
		{
			VillagerRoleActionType.BuyMaterial,
			VillagerRoleStorageType.StockStorageWarehouse
		},
		{
			VillagerRoleActionType.CraftEquipment,
			VillagerRoleStorageType.CraftStorageWarehouse
		},
		{
			VillagerRoleActionType.RepairItem,
			VillagerRoleStorageType.CraftStorageWarehouse
		},
		{
			VillagerRoleActionType.DisassembleCraftItemToItem,
			VillagerRoleStorageType.CraftStorageWarehouse
		},
		{
			VillagerRoleActionType.DisassembleCraftItemToResource,
			VillagerRoleStorageType.CraftStorageWarehouse
		},
		{
			VillagerRoleActionType.CraftMedicine,
			VillagerRoleStorageType.MedicineStorageWarehouse
		},
		{
			VillagerRoleActionType.DetoxItem,
			VillagerRoleStorageType.MedicineStorageWarehouse
		},
		{
			VillagerRoleActionType.AddPoisonToItem,
			VillagerRoleStorageType.MedicineStorageWarehouse
		},
		{
			VillagerRoleActionType.CookFood,
			VillagerRoleStorageType.FoodStorageWarehouse
		}
	};

	public static readonly IReadOnlyDictionary<sbyte, IReadOnlyList<VillagerRoleStorageType>> CollectStorageDict = new Dictionary<sbyte, IReadOnlyList<VillagerRoleStorageType>>
	{
		{ 0, CollectFoodStorageTypeList },
		{ 1, CollectDefaultStorageTypeList },
		{ 2, CollectDefaultStorageTypeList },
		{ 3, CollectDefaultStorageTypeList },
		{ 4, CollectDefaultStorageTypeList },
		{ 5, CollectHerbStorageTypeList }
	};
}
