using Redzen.Random;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法的正逆练类型
/// </summary>
public static class CombatSkillDirection
{
	/// <summary>
	/// 无
	/// </summary>
	public const sbyte NotInited = -2;

	/// <summary>
	/// 无
	/// </summary>
	public const sbyte None = -1;

	/// <summary>
	/// 正练
	/// </summary>
	public const sbyte Direct = 0;

	/// <summary>
	/// 逆练
	/// </summary>
	public const sbyte Reverse = 1;

	/// <summary>
	/// 正逆练类型的个数
	/// </summary>
	public const int Count = 2;

	/// <summary>
	/// 获取随机的正逆练类型
	/// </summary>
	/// <param name="random"></param>
	/// <returns></returns>
	public static sbyte GetRandomDirection(IRandomSource random)
	{
		return (sbyte)random.Next(2);
	}
}
