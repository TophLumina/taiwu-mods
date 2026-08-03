namespace GameData.Domains.Organization;

/// <summary>
/// 太吾对门派的探索状态
/// </summary>
public static class SectExploreStatus
{
	/// <summary>
	/// 未抵达
	/// </summary>
	public const byte NotArrived = 0;

	/// <summary>
	/// 抵达但未开放学习
	/// </summary>
	public const byte NotAllowedLearning = 1;

	/// <summary>
	/// 抵达且开放学习
	/// </summary>
	public const byte AllowedLearning = 2;
}
