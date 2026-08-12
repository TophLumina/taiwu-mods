namespace GameData.Domains.Character.Ai;

/// <summary>
/// 额外优先行为类型
/// </summary>
public static class ExtraPrioritizedActionType
{
	/// <summary>
	/// 奇书争夺
	/// </summary>
	public const sbyte ContestForLegendaryBook = 9;

	/// <summary>
	/// 地区主线 - 元山 - 抗击三魔
	/// </summary>
	public const sbyte SectStoryYuanshanToFightDemon = 10;

	/// <summary>
	/// 地区主线 - 狮相 - 消灭敌人
	/// </summary>
	public const sbyte SectStoryShixiangToFightEnemy = 11;

	/// <summary>
	/// 收养弃婴
	/// </summary>
	public const sbyte AdoptInfant = 12;

	/// <summary>
	/// 地区主线 - 峨眉 - 同门相残
	/// </summary>
	public const sbyte SectStoryEmeiToFightComrade = 13;

	/// <summary>
	/// 似曾相识
	/// </summary>
	public const sbyte DejaVu = 14;

	/// <summary>
	/// 额外优先行为类型总数
	/// </summary>
	public const int Count = 6;
}
