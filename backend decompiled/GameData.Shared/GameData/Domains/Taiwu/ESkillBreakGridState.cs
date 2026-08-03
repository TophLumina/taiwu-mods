namespace GameData.Domains.Taiwu;

/// <summary>
/// 突破格子状态
/// </summary>
public enum ESkillBreakGridState : sbyte
{
	/// <summary>
	/// 未显示
	/// </summary>
	Invisible = -1,
	/// <summary>
	/// 已显示
	/// </summary>
	Showed,
	/// <summary>
	/// 可选择
	/// </summary>
	CanSelect,
	/// <summary>
	/// 已走过
	/// </summary>
	Selected,
	/// <summary>
	/// 已失败
	/// </summary>
	Failed
}
