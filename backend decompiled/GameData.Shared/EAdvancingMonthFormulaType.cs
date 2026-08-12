/// <summary>
/// AdvancingMonthFormula -&gt; Type
/// </summary>
public enum EAdvancingMonthFormulaType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// c0
	/// </summary>
	ConstantFunction,
	/// <summary>
	/// arg0
	/// </summary>
	IdentityFunction,
	/// <summary>
	/// arg0 + c0
	/// </summary>
	OffsetFunction,
	/// <summary>
	/// c0 * arg0
	/// </summary>
	ProportionalFunction,
	/// <summary>
	/// c0 * arg0 + c1
	/// </summary>
	LinearFunction,
	/// <summary>
	/// c0 / arg0
	/// </summary>
	InverseVariationFunction,
	/// <summary>
	/// arg0 % c0
	/// </summary>
	ModularFunction,
	/// <summary>
	/// rand(c0, c1)
	/// </summary>
	ConstantRangeRandom,
	/// <summary>
	/// c[arg0]
	/// </summary>
	ArrayElement,
	/// <summary>
	/// arg0 / c0
	/// </summary>
	Formula0,
	/// <summary>
	/// (arg0 -arg1) * c0
	/// </summary>
	Formula1,
	/// <summary>
	/// arg0 / c0 + c1
	/// </summary>
	Formula2,
	Count
}
