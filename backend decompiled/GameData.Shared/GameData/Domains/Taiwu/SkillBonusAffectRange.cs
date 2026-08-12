namespace GameData.Domains.Taiwu;

/// <summary>
/// 功法属性加成效果影响范围
/// </summary>
public static class SkillBonusAffectRange
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 仅影响本功法
	/// </summary>
	public const sbyte Self = 0;

	/// <summary>
	/// 指定五行属性功法
	/// </summary>
	public const sbyte FiveElementsType = 1;

	/// <summary>
	/// 指定类型功法
	/// </summary>
	public const sbyte CombatSkillType = 2;
}
