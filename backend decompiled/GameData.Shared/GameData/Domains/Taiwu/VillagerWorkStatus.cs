namespace GameData.Domains.Taiwu;

/// <summary>
/// 太吾村民的工作状态
/// </summary>
public static class VillagerWorkStatus
{
	/// <summary>
	/// 空闲
	/// </summary>
	public const byte Unemployed = 0;

	/// <summary>
	/// 同道
	/// </summary>
	public const byte InTaiwuGroup = 1;

	/// <summary>
	/// 工作
	/// </summary>
	public const byte Working = 2;

	/// <summary>
	/// 年幼
	/// </summary>
	public const byte NotOldEnough = 3;

	/// <summary>
	/// 入魔出走
	/// </summary>
	public const byte XiangshuInfected = 4;

	/// <summary>
	/// 阻御妖魔
	/// </summary>
	public const byte ProtectingTaiwuVillage = 5;

	/// <summary>
	/// 被绑架或困于奇遇
	/// </summary>
	public const byte Trapped = 6;
}
