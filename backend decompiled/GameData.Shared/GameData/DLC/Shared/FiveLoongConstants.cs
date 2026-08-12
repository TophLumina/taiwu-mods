using GameData.Domains.Mod;

namespace GameData.DLC.Shared;

/// <summary>
/// 五方神龙
/// </summary>
public static class FiveLoongConstants
{
	/// <summary>
	/// DLC 对应的 AppId
	/// </summary>
	public const uint AppId = 2764950u;

	/// <summary>
	/// DLC 版本
	/// </summary>
	public const ulong Version = 0uL;

	/// <summary>
	/// DLC 对应的 ModId
	/// </summary>
	public static readonly ModId ModId = new ModId(2764950uL, 0uL, 2);
}
