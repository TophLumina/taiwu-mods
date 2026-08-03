using GameData.Domains.Mod;

namespace GameData.DLC.Shared;

/// <summary>
/// 八载同舟
/// </summary>
public static class EightYearsConstants
{
	/// <summary>
	/// DLC 对应的 AppId
	/// </summary>
	public const uint AppId = 4834440u;

	/// <summary>
	/// DLC 版本
	/// </summary>
	public const ulong Version = 0uL;

	/// <summary>
	/// DLC 对应的 ModId
	/// </summary>
	public static readonly ModId ModId = new ModId(4834440uL, 0uL, 2);

	/// <summary>
	/// 获得奖励的标记
	/// </summary>
	public static string ClothGetFlag = "EightYearsClothGetFlag";
}
