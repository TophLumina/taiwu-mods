/// <summary>
/// PlanningAction -&gt; CharacterSelectCountType
/// </summary>
public enum EPlanningActionCharacterSelectCountType
{
	/// <summary>
	/// 无对象
	/// </summary>
	None = -1,
	/// <summary>
	/// 单个对象
	/// </summary>
	RequiredSingle,
	/// <summary>
	/// 多个对象
	/// </summary>
	RequiredMultiple,
	/// <summary>
	/// 非必要多个对象
	/// </summary>
	OptionalMultiple,
	Count
}
