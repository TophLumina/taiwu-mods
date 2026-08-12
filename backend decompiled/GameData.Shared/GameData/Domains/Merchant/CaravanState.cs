namespace GameData.Domains.Merchant;

/// <summary>
/// 商队状态
/// </summary>
public enum CaravanState : sbyte
{
	/// <summary>
	/// 一般情况
	/// </summary>
	Normal,
	/// <summary>
	/// 被抢劫，下次过月要模拟战斗
	/// </summary>
	Robbed,
	/// <summary>
	/// 抢劫完毕，停留一月
	/// </summary>
	RobEnd
}
