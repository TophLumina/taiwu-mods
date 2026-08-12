namespace GameData.Domains.Taiwu.VillagerRole;

/// <summary>
/// 村民身份的产出行为类型，存档数据，只能增加，不可修改
/// </summary>
public enum VillagerRoleActionType : sbyte
{
	/// <summary>
	/// 叫卖获得的银钱
	/// </summary>
	SellToMoney,
	/// <summary>
	/// 采买的其他物品
	/// </summary>
	BuyItem,
	/// <summary>
	/// 采买的工具
	/// </summary>
	BuyTool,
	/// <summary>
	/// 采买的材料
	/// </summary>
	BuyMaterial,
	/// <summary>
	/// 制造装备
	/// </summary>
	CraftEquipment,
	/// <summary>
	/// 修理道具
	/// </summary>
	RepairItem,
	/// <summary>
	/// 拆解工仓道具，获得物品
	/// </summary>
	DisassembleCraftItemToItem,
	/// <summary>
	/// 拆解工仓道具，获得资源
	/// </summary>
	DisassembleCraftItemToResource,
	/// <summary>
	/// 制造药毒
	/// </summary>
	CraftMedicine,
	/// <summary>
	/// 解毒道具
	/// </summary>
	DetoxItem,
	/// <summary>
	/// 淬毒道具
	/// </summary>
	AddPoisonToItem,
	/// <summary>
	/// 烹饪食物
	/// </summary>
	CookFood
}
