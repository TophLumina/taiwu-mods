namespace GameData.Domains.Character.Relation;

/// <summary>
/// 血缘关系类型
/// </summary>
public static class BloodRelatedRelationType
{
	/// <summary>
	/// 父母
	/// </summary>
	public const sbyte Parent = 0;

	/// <summary>
	/// 子女
	/// </summary>
	public const sbyte Child = 1;

	/// <summary>
	/// 手足
	/// </summary>
	public const sbyte BrotherOrSister = 2;

	/// <summary>
	/// 血缘关系类型的数量
	/// </summary>
	public const int Count = 3;
}
