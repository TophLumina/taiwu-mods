namespace GameData.Domains.Combat;

/// <summary>
/// 终结技中的选择
/// </summary>
public enum EShowMercySelect : sbyte
{
	/// <summary>
	/// 尚未选择
	/// </summary>
	Unselected = -1,
	/// <summary>
	/// 手下留情 or 取消解救
	/// </summary>
	Cancel,
	/// <summary>
	/// 痛下杀手 or 执行解救
	/// </summary>
	Confirm
}
