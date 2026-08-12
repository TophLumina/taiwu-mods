/// <summary>
/// ProfessionFormula -&gt; Type
/// </summary>
public enum EProfessionFormulaType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// arg0
	/// </summary>
	SeniorityGainFormula0,
	/// <summary>
	/// c0 * arg0
	/// </summary>
	SeniorityGainFormula1,
	/// <summary>
	/// c0 * arg0 * arg1
	/// </summary>
	SeniorityGainFormula2,
	/// <summary>
	/// c0 * (arg0 + c1) ^ c2
	/// </summary>
	SeniorityGainFormula3,
	/// <summary>
	/// c0 * arg0 * (arg1 + c1) ^ c2
	/// </summary>
	SeniorityGainFormula4,
	/// <summary>
	/// c0 * (arg0 + c1) ^ c2 * (c3 - c3 * arg1 / arg2) / c3
	/// </summary>
	SeniorityGainFormula5,
	/// <summary>
	/// arg0 / c0
	/// </summary>
	SeniorityGainFormula6,
	/// <summary>
	/// (arg0 / c0) ^ c1
	/// </summary>
	SeniorityGainFormula7,
	/// <summary>
	/// c0 * (c1 - arg0) ^ c2
	/// </summary>
	SeniorityGainFormula8,
	/// <summary>
	/// c0
	/// </summary>
	SeniorityGainFormula9,
	/// <summary>
	/// constants[arg0]
	/// </summary>
	SeniorityGainFormula10,
	/// <summary>
	/// c0 * (arg0 * c1 / arg1) / c2
	/// </summary>
	SeniorityGainFormula11,
	/// <summary>
	/// arg0 * c0 / c1
	/// </summary>
	SeniorityGainFormula12,
	Count
}
