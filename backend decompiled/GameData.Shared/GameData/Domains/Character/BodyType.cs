using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 体型
/// </summary>
public static class BodyType
{
	/// <summary>
	/// 未知 / 不限制
	/// </summary>
	public const sbyte Unknown = -1;

	/// <summary>
	/// 瘦
	/// </summary>
	public const sbyte Thin = 0;

	/// <summary>
	/// 普通
	/// </summary>
	public const sbyte Normal = 1;

	/// <summary>
	/// 胖
	/// </summary>
	public const sbyte Fat = 2;

	/// <summary>
	/// 体型的个数
	/// </summary>
	public const int Count = 3;

	/// <summary>
	/// 获取随机体型
	/// </summary>
	public static sbyte GetRandom(IRandomSource random)
	{
		return (sbyte)random.Next(3);
	}
}
