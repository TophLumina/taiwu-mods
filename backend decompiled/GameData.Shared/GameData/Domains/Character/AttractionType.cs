using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 魅力类型
/// </summary>
public static class AttractionType
{
	/// <summary>
	/// 非人
	/// </summary>
	public const sbyte NonHuman = 0;

	/// <summary>
	/// 可憎
	/// </summary>
	public const sbyte Odious = 1;

	/// <summary>
	/// 不扬
	/// </summary>
	public const sbyte Ugly = 2;

	/// <summary>
	/// 寻常
	/// </summary>
	public const sbyte Normal = 3;

	/// <summary>
	/// 出众
	/// </summary>
	public const sbyte Outstanding = 4;

	/// <summary>
	/// 瑾瑜 / 瑶碧
	/// </summary>
	public const sbyte Beautiful = 5;

	/// <summary>
	/// 龙姿 / 凤仪
	/// </summary>
	public const sbyte Brilliant = 6;

	/// <summary>
	/// 绝世 / 出尘
	/// </summary>
	public const sbyte Stunning = 7;

	/// <summary>
	/// 天人
	/// </summary>
	public const sbyte Godlike = 8;

	/// <summary>
	/// 最小值
	/// </summary>
	public const short MinValue = 0;

	/// <summary>
	/// 最大值
	/// </summary>
	public const short MaxValue = 900;

	/// <summary>
	/// 默认值，用于在没有好感数据时计算关联数据
	/// </summary>
	public const short DefaultValue = 450;

	/// <summary>
	/// 计算魅力类型
	/// </summary>
	/// <param name="attraction">
	/// 取值范围 [0, 900].
	/// [0, 100): 非人, [100, 200): 可憎, [200, 300): 不扬,
	/// [300, 400): 寻常, [400, 500): 出众, [500, 600): 瑾瑜/瑶碧,
	/// [600, 700): 龙姿/凤仪, [700, 800): 绝世/出尘, [800, 900]: 天人.
	/// </param>
	/// <returns></returns>
	public static sbyte GetAttractionType(short attraction)
	{
		return (sbyte)MathUtils.Clamp(attraction / 100, 0, 8);
	}
}
