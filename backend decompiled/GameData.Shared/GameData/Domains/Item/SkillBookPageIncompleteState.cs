namespace GameData.Domains.Item;

/// <summary>
/// 技能书的书页的残缺程度
/// </summary>
public static class SkillBookPageIncompleteState
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 完整
	/// </summary>
	public const sbyte Complete = 0;

	/// <summary>
	/// 残缺
	/// </summary>
	public const sbyte Incomplete = 1;

	/// <summary>
	/// 亡佚
	/// </summary>
	public const sbyte Lost = 2;

	/// <summary>
	/// 每种残缺程度的基础研读速度
	/// </summary>
	public static readonly sbyte[] BaseReadingSpeed = new sbyte[3] { 50, 10, 1 };

	/// <summary>
	/// 研读点数消耗
	/// </summary>
	public static readonly sbyte[] ReadingPointCost = new sbyte[3] { 30, 60, 100 };

	/// <summary>
	/// 每种残缺程度对应的NPC研读成功率
	/// </summary>
	public static readonly sbyte[] BaseReadingSuccessRate = new sbyte[3] { 100, 50, 25 };

	/// <summary>
	/// 机关人的每种残缺程度的研读速度
	/// </summary>
	public static readonly sbyte[] GearMateReadingSpeed = new sbyte[3] { 100, 40, 10 };
}
