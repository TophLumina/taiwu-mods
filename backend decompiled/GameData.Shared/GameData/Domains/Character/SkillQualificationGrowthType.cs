namespace GameData.Domains.Character;

/// <summary>
/// 技能资质成长类型
/// </summary>
public static class SkillQualificationGrowthType
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 均衡
	/// </summary>
	public const sbyte Average = 0;

	/// <summary>
	/// 早熟
	/// </summary>
	public const sbyte Precocious = 1;

	/// <summary>
	/// 晚成
	/// </summary>
	public const sbyte LateBlooming = 2;

	/// <summary>
	/// 成长类型总数
	/// </summary>
	public const sbyte Count = 3;
}
