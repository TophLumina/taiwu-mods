namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

/// <summary>
/// 过月行为的类型
/// </summary>
public static class MonthlyActionType
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 通常的配置
	/// </summary>
	public const sbyte ConfigMonthlyAction = 0;

	/// <summary>
	/// 外道巢穴
	/// </summary>
	public const sbyte EnemyNestMonthlyAction = 1;

	/// <summary>
	/// 武林大会
	/// </summary>
	public const sbyte MartialArtTournamentMonthlyAction = 2;

	/// <summary>
	/// 自定义
	/// </summary>
	public const sbyte CustomMonthlyAction = 3;

	/// <summary>
	/// 手动管理触发的配置行为包装
	/// </summary>
	public const sbyte WrappedConfigAction = 4;

	/// <summary>
	/// 季节性
	/// </summary>
	public const sbyte SeasonalMonthlyAction = 5;

	/// <summary>
	/// 临时存在的动态行为 - 该类型的行为可能随时增加和移除
	/// </summary>
	public const sbyte TempDynamicAction = 6;
}
