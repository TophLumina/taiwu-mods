namespace GameData.Domains.Adventure;

/// <summary>
/// 地图上的奇遇点的状态
/// </summary>
public static class AdventureSiteState
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 未激活
	/// </summary>
	public const sbyte WaitingForActivation = 0;

	/// <summary>
	/// 已激活
	/// </summary>
	public const sbyte Activated = 1;

	/// <summary>
	/// 已收服
	/// </summary>
	public const sbyte Conquered = 2;

	/// <summary>
	/// 有贡品
	/// </summary>
	public const sbyte HasTribute = 3;
}
