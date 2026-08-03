using GameData.Domains.Mod;

namespace GameData.DLC.Shared;

/// <summary>
///
/// </summary>
public static class GiftFromConchShip2Constants
{
	/// <summary>
	/// DLC 对应的 AppId
	/// </summary>
	public const uint AppId = 2172690u;

	/// <summary>
	/// DLC 版本
	/// </summary>
	public const ulong Version = 0uL;

	/// <summary>
	/// DLC 对应的 ModId
	/// </summary>
	public static readonly ModId ModId = new ModId(2172690uL, 0uL, 2);

	/// <summary>
	/// 获得奖励的标记
	/// </summary>
	public static string ClothGetFlag = "GiftFromConchShip2ClothGetFlag";
}
