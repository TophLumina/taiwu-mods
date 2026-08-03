namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 辩论行为类型
/// </summary>
public class DebateOperationType
{
	/// <summary>
	/// 论战
	/// </summary>
	public const sbyte Conflict = 0;

	/// <summary>
	/// 论点移动
	/// </summary>
	public const sbyte PawnMove = 1;

	/// <summary>
	/// 落子
	/// </summary>
	public const sbyte MakeMove = 2;

	/// <summary>
	/// 论点移除
	/// </summary>
	public const sbyte Die = 3;

	/// <summary>
	/// 到达终点
	/// </summary>
	public const sbyte Arrive = 4;

	/// <summary>
	/// 增加评论
	/// </summary>
	public const sbyte AddComment = 5;

	/// <summary>
	/// 附着论点策略
	/// </summary>
	public const sbyte AddPawnStrategy = 6;

	/// <summary>
	/// 触发策略
	/// </summary>
	public const sbyte TriggerStrategy = 7;

	/// <summary>
	/// 太吾的可用策略卡片发生变化
	/// </summary>
	public const sbyte CanUseCardChanged = 8;

	/// <summary>
	/// 压力导致结论点变化
	/// </summary>
	public const sbyte PressureReducePoint = 9;

	/// <summary>
	/// 论点基础论据发生变化
	/// </summary>
	public const sbyte PawnBasesChanged = 10;

	/// <summary>
	/// 结论变化，用于非棋子到达的情况，如加血、玉石俱焚策略给另一方的扣血
	/// </summary>
	public const sbyte GamePointChanged = 11;

	/// <summary>
	/// 一次性论点策略消耗
	/// </summary>
	public const sbyte OneTimeUsed = 12;

	/// <summary>
	/// 论点策略被移除
	/// </summary>
	public const sbyte PawnStrategyRemoved = 13;

	/// <summary>
	/// 使用策略
	/// </summary>
	public const sbyte CastStrategy = 14;

	/// <summary>
	/// 添加格子效果
	/// </summary>
	public const sbyte AddNodeEffect = 15;

	/// <summary>
	/// 移除格子效果
	/// </summary>
	public const sbyte RemoveNodeEffect = 16;

	/// <summary>
	/// 触发格子效果
	/// </summary>
	public const sbyte TriggerNodeEffect = 19;

	/// <summary>
	/// 添加记录
	/// </summary>
	public const sbyte AddRecord = 20;

	/// <summary>
	/// 玩家论据被场地特效改变
	/// </summary>
	public const sbyte PlayerBasesChangedByNodeEffect = 21;

	/// <summary>
	/// 重置策略
	/// </summary>
	public const sbyte ResetStrategy = 22;
}
