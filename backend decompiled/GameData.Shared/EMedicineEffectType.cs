/// <summary>
/// Medicine -&gt; EffectType
/// </summary>
public enum EMedicineEffectType
{
	/// <summary>
	/// Invalid
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 治愈外伤
	/// </summary>
	RecoverOuterInjury,
	/// <summary>
	/// 治愈内伤
	/// </summary>
	RecoverInnerInjury,
	/// <summary>
	/// 恢复健康
	/// </summary>
	RecoverHealth,
	/// <summary>
	/// 调理内息
	/// </summary>
	ChangeDisorderOfQi,
	/// <summary>
	/// 解毒
	/// </summary>
	DetoxPoison,
	/// <summary>
	/// 解蛊
	/// </summary>
	DetoxWug,
	/// <summary>
	/// 毒药
	/// </summary>
	ApplyPoison,
	Count
}
