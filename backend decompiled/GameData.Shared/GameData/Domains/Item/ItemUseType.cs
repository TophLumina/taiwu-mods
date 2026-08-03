namespace GameData.Domains.Item;

/// <summary>
/// 物品使用类型，仅当道具为药毒时有效
/// </summary>
public static class ItemUseType
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 内服
	/// </summary>
	public const int Eat = 0;

	/// <summary>
	/// 投掷（仅限毒）
	/// </summary>
	public const int Throw = 1;
}
