namespace GameData.Domains.Item;

/// <summary>
/// 物品对象的变动类型
/// 注意同步修改<see cref="!:GameData.Domains.Character.CharacterDomain.CreateItemDisplayData" />
/// </summary>
public static class ModificationType
{
	/// <summary>
	/// 淬毒
	/// </summary>
	public const byte Poisoning = 1;

	/// <summary>
	/// 精制
	/// </summary>
	public const byte Refining = 2;

	/// <summary>
	/// 定情信物
	/// </summary>
	public const byte LoveToken = 4;

	/// <summary>
	/// 额外商品
	/// </summary>
	public const byte ExtraGoods = 8;
}
