using GameData.Domains.Mod;

namespace GameData.DLC.Shared;

/// <summary>
/// 恋爱互动相关常量
/// </summary>
public static class InteractOfLoveConstants
{
	/// <summary>
	/// DLC 对应的 AppId
	/// </summary>
	public const uint AppId = 2305890u;

	/// <summary>
	/// DLC 版本
	/// </summary>
	public const ulong Version = 0uL;

	/// <summary>
	/// DLC 对应的 ModId
	/// </summary>
	public static readonly ModId ModId = new ModId(2305890uL, 0uL, 2);
}
