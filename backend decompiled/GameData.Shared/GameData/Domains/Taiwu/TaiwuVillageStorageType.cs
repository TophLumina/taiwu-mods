using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 太吾村库房类型，存档数据，只能增加，不可修改
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum TaiwuVillageStorageType : sbyte
{
	/// <summary>
	/// 行囊
	/// </summary>
	Inventory,
	/// <summary>
	/// 私库
	/// </summary>
	Warehouse,
	/// <summary>
	/// 公库
	/// </summary>
	Treasury,
	/// <summary>
	/// 货仓
	/// </summary>
	Stock,
	/// <summary>
	/// 饲槽
	/// </summary>
	Trough,
	/// <summary>
	/// 数量
	/// </summary>
	Count
}
