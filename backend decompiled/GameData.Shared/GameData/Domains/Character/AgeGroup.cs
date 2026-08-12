namespace GameData.Domains.Character;

/// <summary>
/// 年龄段
/// </summary>
public static class AgeGroup
{
	/// <summary>
	/// 婴儿
	/// </summary>
	public const sbyte Baby = 0;

	/// <summary>
	/// 孩童
	/// </summary>
	public const sbyte Child = 1;

	/// <summary>
	/// 成年
	/// </summary>
	public const sbyte Adult = 2;

	/// <summary>
	/// 获取指定年龄的年龄段.
	/// 若年龄未知 (小于零), 则当作已成年.
	/// </summary>
	/// <param name="age"></param>
	/// <returns></returns>
	public static sbyte GetAgeGroup(short age)
	{
		if (age >= 16)
		{
			return 2;
		}
		if (age >= GlobalConfig.Instance.AgeBaby)
		{
			return 1;
		}
		if (age >= 0)
		{
			return 0;
		}
		return 2;
	}
}
