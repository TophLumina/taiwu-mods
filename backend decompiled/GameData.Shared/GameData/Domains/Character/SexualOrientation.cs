namespace GameData.Domains.Character;

/// <summary>
/// 性取向
/// </summary>
public static class SexualOrientation
{
	/// <summary>
	/// 未知 / 不限制
	/// </summary>
	public const sbyte Unknown = -1;

	/// <summary>
	/// 异性恋
	/// </summary>
	public const sbyte Heterosexuality = 0;

	/// <summary>
	/// 双性恋
	/// </summary>
	public const sbyte Bisexual = 1;

	/// <summary>
	/// 性取向的个数
	/// </summary>
	public const int Count = 2;
}
