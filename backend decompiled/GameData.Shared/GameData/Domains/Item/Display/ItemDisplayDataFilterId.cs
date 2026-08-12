namespace GameData.Domains.Item.Display;

/// <summary>
/// 物品显示数据筛选id
/// </summary>
public static class ItemDisplayDataFilterId
{
	/// <summary>
	/// 不可用
	/// </summary>
	public const ushort Invalid = 0;

	/// <summary>
	/// 物品是否可以修复
	/// </summary>
	public const ushort IsItemRepairable = 1;

	/// <summary>
	/// 物品是否可以转移
	/// </summary>
	public const ushort IsItemTransferable = 2;

	/// <summary>
	/// 物品是否没有耐久或耐久已满
	/// </summary>
	public const ushort IsItemFullDurability = 3;

	/// <summary>
	/// 物品是否可以作为礼物赠送
	/// </summary>
	public const ushort CanItemAsGift = 4;

	/// <summary>
	/// 物品是否可以转移 或者是奇书
	/// </summary>
	public const ushort IsItemTransferableOrLegendaryBook = 5;
}
