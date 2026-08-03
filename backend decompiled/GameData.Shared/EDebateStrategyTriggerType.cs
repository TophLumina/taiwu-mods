/// <summary>
/// DebateStrategy -&gt; TriggerType
/// </summary>
public enum EDebateStrategyTriggerType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 即时效果
	/// </summary>
	Instant,
	/// <summary>
	/// 回合开始
	/// </summary>
	RoundStart,
	/// <summary>
	/// 论战开始
	/// </summary>
	ConflictStart,
	/// <summary>
	/// 论战胜利
	/// </summary>
	ConflictWin,
	/// <summary>
	/// 论战失败
	/// </summary>
	ConflictLose,
	/// <summary>
	/// 论点前进
	/// </summary>
	PawnForward,
	/// <summary>
	/// 论点消除
	/// </summary>
	PawnDead,
	/// <summary>
	/// 论点伤害
	/// </summary>
	PawnDamage,
	/// <summary>
	/// 论点行动
	/// </summary>
	PawnActing,
	Count
}
