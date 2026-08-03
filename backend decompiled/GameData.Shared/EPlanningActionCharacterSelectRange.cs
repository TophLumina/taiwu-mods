/// <summary>
/// PlanningAction -&gt; CharacterSelectRange
/// </summary>
public enum EPlanningActionCharacterSelectRange
{
	/// <summary>
	/// 无
	/// </summary>
	None = -1,
	/// <summary>
	/// 同队伍
	/// </summary>
	SameGroup,
	/// <summary>
	/// 同地格
	/// </summary>
	SameBlock,
	/// <summary>
	/// 同地区
	/// </summary>
	SameArea,
	/// <summary>
	/// 同州域
	/// </summary>
	SameState,
	/// <summary>
	/// 地格范围
	/// </summary>
	BlockRange,
	/// <summary>
	/// 定居点影响范围
	/// </summary>
	SettlementRange,
	Count
}
