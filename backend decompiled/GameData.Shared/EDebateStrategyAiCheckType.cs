/// <summary>
/// DebateStrategy -&gt; AiCheckType
/// </summary>
public enum EDebateStrategyAiCheckType
{
	/// <summary>
	/// 对方弃用卡组大于
	/// </summary>
	OpponentUsedCardCountGreater,
	/// <summary>
	/// 对方待用卡组大于
	/// </summary>
	OpponentOwnedCardCountGreater,
	/// <summary>
	/// 己方可用卡组小于
	/// </summary>
	SelfCanUseCardCountSmaller,
	/// <summary>
	/// 己方可用卡组大于
	/// </summary>
	SelfCanUseCardCountGreater,
	/// <summary>
	/// 己方论点数量大于
	/// </summary>
	SelfPawnCountGreater,
	/// <summary>
	/// 己方论据大于
	/// </summary>
	SelfBasesGreater,
	/// <summary>
	/// 己方策略点小于
	/// </summary>
	SelfStrategyPointSmaller,
	/// <summary>
	/// 可用目标大于
	/// </summary>
	TargetCountGreater,
	/// <summary>
	/// 可用敌方目标大于
	/// </summary>
	OpponentTargetCountGreater,
	/// <summary>
	/// 己方结论小于
	/// </summary>
	SelfGamePointSmaller,
	/// <summary>
	/// 己方结论大于
	/// </summary>
	SelfGamePointGreater,
	/// <summary>
	/// 对方结论大于
	/// </summary>
	OpponentGamePointGreater,
	/// <summary>
	/// 对方结论小于等于己方结论
	/// </summary>
	OpponentGamePointNotGreaterThanSelf,
	/// <summary>
	/// 己方无逼宫
	/// </summary>
	SelfNotCheckMate,
	Count
}
