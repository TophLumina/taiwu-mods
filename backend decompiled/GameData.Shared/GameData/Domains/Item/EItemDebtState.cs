namespace GameData.Domains.Item;

/// <summary>
/// 物品对商店恩义的影响
/// </summary>
public enum EItemDebtState
{
	None,
	/// <summary>
	/// 偿还，少欠商店
	/// </summary>
	Remove,
	/// <summary>
	/// 增加，多欠商店
	/// </summary>
	Add
}
