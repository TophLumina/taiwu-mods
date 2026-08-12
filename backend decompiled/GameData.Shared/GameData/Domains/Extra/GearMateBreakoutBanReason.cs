namespace GameData.Domains.Extra;

/// <summary>
/// 机关人不能传输武学原因的枚举
/// </summary>
public enum GearMateBreakoutBanReason
{
	/// <summary>
	/// 没有研读完对应的功法书
	/// </summary>
	NotLearnedBook,
	/// <summary>
	/// 已经突破过并且相同
	/// </summary>
	SameBreakResult
}
