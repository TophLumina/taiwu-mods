namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 辩论回合阶段
/// </summary>
public class DebateState
{
	/// <summary>
	/// 准备阶段
	/// </summary>
	public const sbyte Prepare = -1;

	/// <summary>
	/// 先手方行动
	/// </summary>
	public const sbyte FirstMove = 0;

	/// <summary>
	/// 后手方行动
	/// </summary>
	public const sbyte LastMove = 1;

	/// <summary>
	/// 结算
	/// </summary>
	public const sbyte Settle = 2;

	/// <summary>
	///
	/// </summary>
	public const sbyte Count = 3;
}
