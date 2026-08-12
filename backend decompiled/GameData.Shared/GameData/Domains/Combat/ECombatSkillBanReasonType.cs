namespace GameData.Domains.Combat;

/// <summary>
/// 功法禁用原因类型
/// </summary>
public enum ECombatSkillBanReasonType : sbyte
{
	/// <summary>
	/// 可施展
	/// </summary>
	None = -1,
	/// <summary>
	/// 未定义的原因
	/// </summary>
	Undefined,
	/// <summary>
	/// 架势不足
	/// </summary>
	StanceNotEnough,
	/// <summary>
	/// 提气不足
	/// </summary>
	BreathNotEnough,
	/// <summary>
	/// 脚力不足
	/// </summary>
	MobilityNotEnough,
	/// <summary>
	/// 蓄式不足
	/// </summary>
	TrickNotEnough,
	/// <summary>
	/// 蛊引不足
	/// </summary>
	WugNotEnough,
	/// <summary>
	/// 真气不足
	/// </summary>
	NeiliAllocationNotEnough,
	/// <summary>
	/// 武器式盘不含所需式
	/// </summary>
	WeaponTrickMismatch,
	/// <summary>
	/// 武器已损坏
	/// </summary>
	WeaponDestroyed,
	/// <summary>
	/// 所需身体部位损坏
	/// </summary>
	BodyPartBroken,
	/// <summary>
	/// 特殊效果禁用
	/// </summary>
	SpecialEffectBan,
	/// <summary>
	/// 战斗配置禁用
	/// </summary>
	CombatConfigBan,
	/// <summary>
	/// 封禁中
	/// </summary>
	Silencing
}
