namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 压力影响触发类型
/// </summary>
public class PressureTriggerType
{
	/// <summary>
	/// 无压力
	/// </summary>
	public const sbyte NoPressure = 0;

	/// <summary>
	/// 低压力
	/// </summary>
	public const sbyte LowPressure = 1;

	/// <summary>
	/// 中压力
	/// </summary>
	public const sbyte MidPressure = 2;

	/// <summary>
	/// 高压力
	/// </summary>
	public const sbyte HighPressure = 3;

	/// <summary>
	/// 心浮气躁
	/// </summary>
	public const sbyte NoStrategyRecover = 4;

	/// <summary>
	/// 心烦意乱
	/// </summary>
	public const sbyte NoBasesRecover = 5;

	/// <summary>
	/// 语无伦次
	/// </summary>
	public const sbyte UseStrategy = 6;

	/// <summary>
	/// 失魂落魄
	/// </summary>
	public const sbyte UseBases = 7;
}
