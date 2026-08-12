using GameData.Domains.Mod;

namespace GameData.DLC.Shared;

/// <summary>
/// 碧霄蛇影相关常量
/// </summary>
public static class HappyNewYear2025Constants
{
	/// <summary>
	/// DLC 对应的 AppId
	/// </summary>
	public const uint AppId = 3464590u;

	/// <summary>
	/// DLC 版本
	/// </summary>
	public const ulong Version = 0uL;

	/// <summary>
	/// DLC 对应的 ModId
	/// </summary>
	public static readonly ModId ModId = new ModId(3464590uL, 0uL, 2);

	/// <summary>
	/// 碧霄蛇影获得奖励的标记
	/// </summary>
	public static string ClothGetFlag = "HappyNewYear2025ClothGetFlag";

	/// <summary>
	/// 碧霄蛇影获得奖励的标记 - 附加衣装
	/// </summary>
	public static string ClothGetFlagExtra = "HappyNewYear2025ClothGetFlagExtra";
}
