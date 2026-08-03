/// <summary>
/// EventValue -&gt; Type
/// </summary>
public enum EEventValueType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 全局
	/// </summary>
	Global,
	/// <summary>
	/// 事件
	/// </summary>
	Event,
	/// <summary>
	/// 角色
	/// </summary>
	Character,
	/// <summary>
	/// 地格
	/// </summary>
	MapBlock,
	/// <summary>
	/// 常量
	/// </summary>
	Constant,
	Count
}
