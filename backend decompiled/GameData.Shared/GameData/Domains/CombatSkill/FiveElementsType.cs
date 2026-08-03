namespace GameData.Domains.CombatSkill;

/// <summary>
/// 五行属性
/// </summary>
public static class FiveElementsType
{
	/// <summary>
	/// 金刚 (金)
	/// </summary>
	public const sbyte Metal = 0;

	/// <summary>
	/// 紫霞 (木)
	/// </summary>
	public const sbyte Wood = 1;

	/// <summary>
	/// 玄阴 (水)
	/// </summary>
	public const sbyte Water = 2;

	/// <summary>
	/// 纯阳 (火)
	/// </summary>
	public const sbyte Fire = 3;

	/// <summary>
	/// 归元 (土)
	/// </summary>
	public const sbyte Earth = 4;

	/// <summary>
	/// 混元.
	/// 处于五行之外的特殊值.
	/// </summary>
	public const sbyte Mix = 5;

	/// <summary>
	/// 五行的个数
	/// </summary>
	public const int Count = 5;

	/// <summary>
	/// 五行克制 (索引克制值)
	/// </summary>
	public static readonly sbyte[] Countering = new sbyte[5] { 1, 4, 3, 0, 2 };

	/// <summary>
	/// 五行被克 (索引被值克制)
	/// </summary>
	public static readonly sbyte[] Countered = new sbyte[5] { 3, 0, 4, 2, 1 };

	/// <summary>
	/// 五行化生 (索引化生值)
	/// </summary>
	public static readonly sbyte[] Producing = new sbyte[5] { 2, 3, 1, 4, 0 };

	/// <summary>
	/// 五行被生 (索引被值化生)
	/// </summary>
	public static readonly sbyte[] Produced = new sbyte[5] { 4, 2, 0, 1, 3 };
}
