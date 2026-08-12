/// <summary>
/// EventFunction -&gt; Type
/// </summary>
public enum EEventFunctionType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 基础指令
	/// </summary>
	Basic,
	/// <summary>
	/// 界面指令
	/// </summary>
	UI,
	/// <summary>
	/// 行为指令
	/// </summary>
	Behavior,
	/// <summary>
	/// 条件指令
	/// </summary>
	Condition,
	/// <summary>
	/// 数据指令
	/// </summary>
	DataRtrieval,
	Count
}
