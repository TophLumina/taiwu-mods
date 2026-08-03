namespace GameData.Domains.Item;

/// <summary>
/// Tradable类型
/// </summary>
public static class TradableContentType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 物品
	/// </summary>
	public const sbyte Item = 0;

	/// <summary>
	/// 俘虏
	/// </summary>
	public const sbyte Prisoner = 1;

	/// <summary>
	/// 秘闻
	/// </summary>
	public const sbyte Secrect = 2;

	/// <summary>
	/// 见闻
	/// </summary>
	public const sbyte Information = 3;

	/// <summary>
	/// 毒
	/// </summary>
	public const sbyte Toxic = 4;

	/// <summary>
	/// 技能（包括技艺和武学）
	/// </summary>
	public const sbyte Skill = 5;

	/// <summary>
	/// 空ItemKey，用于显示数据
	/// </summary>
	public const sbyte ItemKey = 6;

	/// <summary>
	/// 类型个数
	/// </summary>
	public const int Count = 7;
}
