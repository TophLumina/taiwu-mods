/// <summary>
/// TravelingEvent -&gt; TriggerType
/// </summary>
public enum ETravelingEventTriggerType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 任意条件
	/// </summary>
	Any,
	/// <summary>
	/// 到达区域
	/// </summary>
	OnArea,
	/// <summary>
	/// 前往区域
	/// </summary>
	ToArea,
	/// <summary>
	/// 离开区域
	/// </summary>
	FromArea,
	Count
}
