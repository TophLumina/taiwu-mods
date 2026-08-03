namespace GameData.Domains.Combat;

/// <summary>
/// 变化耐久来源类型
/// </summary>
public enum EChangeDurabilitySourceType
{
	/// <summary>
	/// 攻击或功法命中时减少耐久
	/// </summary>
	Hit,
	/// <summary>
	/// 施展功法消耗耐久
	/// </summary>
	Cost,
	/// <summary>
	/// 一般特效变化耐久
	/// </summary>
	Effect,
	/// <summary>
	/// 解封消耗耐久
	/// </summary>
	Unlock,
	/// <summary>
	/// 同道指令修复耐久
	/// </summary>
	Teammate,
	/// <summary>
	/// 猎户野兽攻击消耗耐久
	/// </summary>
	Hunter
}
