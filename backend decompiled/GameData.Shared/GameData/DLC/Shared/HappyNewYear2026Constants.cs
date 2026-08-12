using GameData.Domains.Mod;

namespace GameData.DLC.Shared;

/// <summary>
/// 跃马听香相关常量
/// </summary>
public static class HappyNewYear2026Constants
{
	/// <summary>
	/// DLC 对应的 AppId
	/// </summary>
	public const uint AppId = 4395170u;

	/// <summary>
	/// DLC 版本
	/// </summary>
	public const ulong Version = 0uL;

	/// <summary>
	/// DLC 对应的 ModId
	/// </summary>
	public static readonly ModId ModId = new ModId(4395170uL, 0uL, 2);

	/// <summary>
	/// 跃马听香获得奖励的标记
	/// </summary>
	public static string ClothGetFlag = "HappyNewYear2026ClothGetFlag";
}
