using GameData.Domains.Mod;

namespace GameData.DLC.Shared;

/// <summary>
/// 青山依旧
/// </summary>
public static class GreenHillsRemainConstants
{
	/// <summary>
	/// DLC 对应的 AppId
	/// </summary>
	public const uint AppId = 4834450u;

	/// <summary>
	/// DLC 版本
	/// </summary>
	public const ulong Version = 0uL;

	/// <summary>
	/// DLC 对应的 ModId
	/// </summary>
	public static readonly ModId ModId = new ModId(4834450uL, 0uL, 2);

	/// <summary>
	/// 获得奖励的标记
	/// </summary>
	public static string ClothGetFlag = "GreenHillsRemainClothGetFlag";
}
