namespace GameData.Domains.Combat;

/// <summary>
/// 战斗中伤害类型
/// </summary>
public enum EDamageType
{
	/// <summary>
	/// 无类型
	/// </summary>
	None,
	/// <summary>
	/// 直接伤害
	/// </summary>
	Direct,
	/// <summary>
	/// 反震伤害
	/// </summary>
	Bounce,
	/// <summary>
	/// 反击伤害
	/// </summary>
	FightBack
}
