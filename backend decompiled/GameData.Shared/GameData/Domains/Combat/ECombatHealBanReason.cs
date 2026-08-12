namespace GameData.Domains.Combat;

/// <summary>
/// 战中疗伤驱毒禁用原因
/// </summary>
public enum ECombatHealBanReason
{
	/// <summary>
	/// 无需治疗或驱毒
	/// </summary>
	NonTarget,
	/// <summary>
	/// 疗伤驱毒次数不足
	/// </summary>
	CountLack,
	/// <summary>
	/// 药材数量不足
	/// </summary>
	HerbLack,
	/// <summary>
	/// 造诣不足
	/// </summary>
	AttainmentLack
}
