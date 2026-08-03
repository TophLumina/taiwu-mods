namespace GameData.Domains.Organization;

/// <summary>
/// 库房/监牢的各页签定义
/// 这个定义必须与前端页签顺序保持一致
/// </summary>
public enum TreasuryOrPrisonPage : sbyte
{
	/// <summary>
	/// 禁止进入监牢，要求前端恢复之前选中页签
	/// </summary>
	Restore = -1,
	/// <summary>
	/// 监牢页签：初级库房/监牢
	/// </summary>
	Low,
	/// <summary>
	/// 监牢页签：中级库房/监牢
	/// </summary>
	Mid,
	/// <summary>
	/// 监牢页签：高级库房/监牢
	/// </summary>
	High,
	/// <summary>
	/// 入魔人监牢
	/// </summary>
	Infected,
	/// <summary>
	/// 请求强闯监牢
	/// </summary>
	Invade
}
