/// <summary>
/// MonthlyEvent -&gt; Type
/// </summary>
public enum EMonthlyEventType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 普通事件
	/// </summary>
	NormalEvent,
	/// <summary>
	/// 特殊事件
	/// </summary>
	SpecialEvent,
	/// <summary>
	/// 锁定事件
	/// </summary>
	LockedEvent,
	Count
}
