/// <summary>
/// CombatConfig -&gt; ForceDefeatType
/// </summary>
public enum ECombatConfigForceDefeatType
{
	/// <summary>
	/// 不限时
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 己方胜利
	/// </summary>
	LeftWin,
	/// <summary>
	/// 敌方胜利
	/// </summary>
	RightWin,
	/// <summary>
	/// 终局机制
	/// </summary>
	TiredMark,
	Count
}
