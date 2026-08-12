namespace GameData.Domains.Item;

/// <summary>
/// 道具数据接口，主要用于适配一些前后端共用的逻辑
/// </summary>
public interface IItemData
{
	/// <summary>
	/// 道具键
	/// </summary>
	ItemKey Key { get; }

	/// <summary>
	/// 价值
	/// </summary>
	int Value { get; }

	/// <summary>
	/// 当前耐久
	/// </summary>
	short Durability { get; }

	/// <summary>
	/// 耐久上限
	/// </summary>
	short MaxDurability { get; }
}
