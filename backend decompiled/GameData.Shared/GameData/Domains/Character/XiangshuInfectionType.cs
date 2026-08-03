namespace GameData.Domains.Character;

/// <summary>
/// 相枢化类型
/// </summary>
public static class XiangshuInfectionType
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 未相枢化
	/// </summary>
	public const sbyte NotInfected = 0;

	/// <summary>
	/// 相枢入邪
	/// </summary>
	public const sbyte PartlyInfected = 1;

	/// <summary>
	/// 相枢入魔
	/// </summary>
	public const sbyte CompletelyInfected = 2;

	/// <summary>
	/// 最小值
	/// </summary>
	public const byte MinValue = 0;

	/// <summary>
	/// 最大值
	/// </summary>
	public const byte MaxValue = 200;

	/// <summary>
	/// 入邪阈值
	/// </summary>
	public const byte PartlyInfectedThresholdValue = 100;

	/// <summary>
	/// 入魔阈值
	/// </summary>
	public const byte CompletelyInfectedThresholdValue = 200;

	/// <summary>
	/// 计算角色应该成为的相枢化类型 (现在不一定是此类型, 但已满足条件).
	/// 此值只对智能角色有意义.
	/// </summary>
	/// <param name="xiangshuInfection"></param>
	/// <returns></returns>
	public static sbyte GetInfectionTypeThatShouldBe(byte xiangshuInfection)
	{
		if (xiangshuInfection < 100)
		{
			return 0;
		}
		if (xiangshuInfection < 200)
		{
			return 1;
		}
		return 2;
	}
}
