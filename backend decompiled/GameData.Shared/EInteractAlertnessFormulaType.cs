/// <summary>
/// InteractAlertnessFormula -&gt; Type
/// </summary>
public enum EInteractAlertnessFormulaType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// c0
	/// </summary>
	Formula0,
	/// <summary>
	/// c0 * arg0
	/// </summary>
	Formula1,
	/// <summary>
	/// c0 * (arg0 + c1) * c2 / c3
	/// </summary>
	Formula2,
	/// <summary>
	/// arg0 * c0 * c1 / c2
	/// </summary>
	Formula3,
	Count
}
