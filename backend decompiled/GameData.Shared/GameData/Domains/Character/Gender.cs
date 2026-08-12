using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 性别
/// </summary>
public static class Gender
{
	/// <summary>
	/// 未知 / 不限制
	/// </summary>
	public const sbyte Unknown = -1;

	/// <summary>
	/// 女
	/// </summary>
	public const sbyte Female = 0;

	/// <summary>
	/// 男
	/// </summary>
	public const sbyte Male = 1;

	/// <summary>
	/// 性别的个数
	/// </summary>
	public const int Count = 2;

	/// <summary>
	/// 获取相反的性别
	/// </summary>
	public static sbyte Flip(sbyte gender)
	{
		return (gender != 1) ? ((sbyte)1) : ((sbyte)0);
	}

	/// <summary>
	/// 获取随机性别
	/// </summary>
	public static sbyte GetRandom(IRandomSource random)
	{
		return (sbyte)random.Next(2);
	}
}
