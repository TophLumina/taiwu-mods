/// <summary>
/// BuildingFormula -&gt; Type
/// </summary>
public enum EBuildingFormulaType
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
	/// arg0
	/// </summary>
	Formula1,
	/// <summary>
	/// c0 + arg0 / c1
	/// </summary>
	Formula2,
	/// <summary>
	/// c0 * arg0 / c1
	/// </summary>
	Formula3,
	/// <summary>
	/// c0 + c1 * arg0 / c2
	/// </summary>
	Formula4,
	/// <summary>
	/// (c0 + c1 * arg0) * arg1 / c2
	/// </summary>
	Formula5,
	/// <summary>
	/// rand(c0, c1)
	/// </summary>
	Formula6,
	/// <summary>
	/// roll(c0%) ? c1 ? rand(c2, c3)
	/// </summary>
	Formula7,
	/// <summary>
	/// c0 * arg0
	/// </summary>
	Formula8,
	/// <summary>
	/// arg0 + rand(c0, c1)
	/// </summary>
	Formula9,
	Count
}
