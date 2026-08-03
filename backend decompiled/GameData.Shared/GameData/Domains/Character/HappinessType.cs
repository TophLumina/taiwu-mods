using System;

namespace GameData.Domains.Character;

/// <summary>
/// 心情类型
/// </summary>
public static class HappinessType
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 悲极
	/// </summary>
	public const sbyte Saddest = 0;

	/// <summary>
	/// 痛苦
	/// </summary>
	public const sbyte Painful = 1;

	/// <summary>
	/// 沮丧
	/// </summary>
	public const sbyte Depressed = 2;

	/// <summary>
	/// 寻常
	/// </summary>
	public const sbyte Normal = 3;

	/// <summary>
	/// 开怀
	/// </summary>
	public const sbyte Pleased = 4;

	/// <summary>
	/// 欢喜
	/// </summary>
	public const sbyte Delighted = 5;

	/// <summary>
	/// 乐极
	/// </summary>
	public const sbyte Happiest = 6;

	/// <summary>
	/// 最小值
	/// </summary>
	public const sbyte MinValue = -119;

	/// <summary>
	/// 最大值
	/// </summary>
	public const sbyte MaxValue = 119;

	/// <summary>
	/// 每个心情类型的取值范围
	/// </summary>
	public static readonly (sbyte min, sbyte max)[] Ranges = new(sbyte, sbyte)[7]
	{
		(-119, -90),
		(-89, -60),
		(-59, -30),
		(-29, 29),
		(30, 59),
		(60, 89),
		(90, 119)
	};

	/// <summary>
	/// 计算心情类型
	/// </summary>
	/// <param name="happiness">
	/// 取值范围 (-120, 120).
	/// (-120, -90]: 悲极, (-90, -60]: 痛苦, (-60, -30]: 沮丧, (-30, 30): 寻常, [30, 60): 开怀, [60, 90): 欢喜, [90, 120): 乐极.
	/// </param>
	/// <returns></returns>
	public static sbyte GetHappinessType(sbyte happiness)
	{
		return (happiness / 30) switch
		{
			-3 => 0, 
			-2 => 1, 
			-1 => 2, 
			0 => 3, 
			1 => 4, 
			2 => 5, 
			3 => 6, 
			_ => throw new ArgumentOutOfRangeException($"Happiness out of range: {happiness}"), 
		};
	}
}
