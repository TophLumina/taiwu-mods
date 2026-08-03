/// <summary>
/// DebateRecord -&gt; ParamType
/// </summary>
public enum EDebateRecordParamType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 数值
	/// </summary>
	IntValue,
	/// <summary>
	/// 结论
	/// </summary>
	GamePoint,
	/// <summary>
	/// 策略点
	/// </summary>
	StrategyPoint,
	/// <summary>
	/// 可用论据
	/// </summary>
	Bases,
	/// <summary>
	/// 压力
	/// </summary>
	Pressure,
	/// <summary>
	/// 论点
	/// </summary>
	Pawn,
	/// <summary>
	/// 己方论点
	/// </summary>
	SelfPawn,
	/// <summary>
	/// 对方论点
	/// </summary>
	OpponentPawn,
	/// <summary>
	/// 策略名
	/// </summary>
	Strategy,
	/// <summary>
	/// 心怀格
	/// </summary>
	BottomNode,
	/// <summary>
	/// 特殊格名
	/// </summary>
	NodeEffect,
	/// <summary>
	/// 人物名
	/// </summary>
	Character,
	/// <summary>
	/// 观众名
	/// </summary>
	Spectator,
	/// <summary>
	/// 评价名
	/// </summary>
	Comment,
	/// <summary>
	/// 待用卡组
	/// </summary>
	OwnedCards,
	/// <summary>
	/// 弃用卡组
	/// </summary>
	UsedCards,
	/// <summary>
	/// 论点数
	/// </summary>
	PawnCount,
	Count
}
