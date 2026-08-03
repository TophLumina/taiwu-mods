namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

/// <summary>
/// 月度行为状态
/// </summary>
public class MonthlyActionState
{
	/// <summary>
	/// 等待触发状态
	/// </summary>
	public const sbyte WaitTrigger = 0;

	/// <summary>
	/// 已经触发执行
	/// </summary>
	public const sbyte Triggered = 1;

	/// <summary>
	/// 准备关键人物的阶段
	/// </summary>
	public const sbyte MajorCharacterPreparing = 2;

	/// <summary>
	/// 参与人物的准备阶段
	/// </summary>
	public const sbyte ParticipateCharacterPreparing = 3;

	/// <summary>
	/// 预告将要开放阶段
	/// </summary>
	public const sbyte Announce = 4;

	/// <summary>
	/// 准备完毕开放阶段
	/// </summary>
	public const sbyte Ready = 5;

	/// <summary>
	/// 状态总数
	/// </summary>
	public const sbyte Count = 6;
}
