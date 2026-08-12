/// <summary>
/// PlanningAction -&gt; CharacterSelector
/// </summary>
public enum EPlanningActionCharacterSelector
{
	/// <summary>
	/// 无
	/// </summary>
	None = -1,
	/// <summary>
	/// 随机对象
	/// </summary>
	RandomTarget,
	/// <summary>
	/// 优先对象
	/// </summary>
	MaxPriorityTarget,
	/// <summary>
	/// 请求对象
	/// </summary>
	RequestTarget,
	/// <summary>
	/// 偷窃对象
	/// </summary>
	StealTarget,
	/// <summary>
	/// 唬骗对象
	/// </summary>
	ScamTarget,
	/// <summary>
	/// 夺取对象
	/// </summary>
	RobTarget,
	/// <summary>
	/// 亲近对象
	/// </summary>
	CloseTarget,
	Count
}
