/// <summary>
/// VillagerRoleFormula -&gt; Type
/// </summary>
public enum EVillagerRoleFormulaType
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
	/// c0 + arg0
	/// </summary>
	Formula1,
	/// <summary>
	/// c0 * arg0
	/// </summary>
	Formula2,
	/// <summary>
	/// arg0 / c0
	/// </summary>
	Formula3,
	/// <summary>
	/// c0 + arg0 / c1
	/// </summary>
	Formula4,
	/// <summary>
	/// arg0 / c0 * arg1 / c1
	/// </summary>
	Formula5,
	/// <summary>
	/// (c0 + arg0) * arg1 / c1
	/// </summary>
	Formula6,
	/// <summary>
	/// arg0 * arg1 / c0 / c1
	/// </summary>
	Formula7,
	/// <summary>
	/// arg0 * rand(c0,c1) / c2
	/// </summary>
	Formula8,
	/// <summary>
	/// c0 + arg0 / c1 * arg1 / c2
	/// </summary>
	Formula9,
	/// <summary>
	/// c[arg0]
	/// </summary>
	Formula10,
	/// <summary>
	/// arg0 * c0% * (c1 - arg1 / c2) / c3
	/// </summary>
	Formula11,
	/// <summary>
	/// arg0 * (c0 + arg1)
	/// </summary>
	Formula12,
	/// <summary>
	/// arg0 * (c0 + arg1 / c1 * arg2) / c2
	/// </summary>
	Formula13,
	/// <summary>
	/// (c0 + arg0 / c1) * arg1 / c2
	/// </summary>
	Formula14,
	Count
}
