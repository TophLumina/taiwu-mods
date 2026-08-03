namespace GameData.Domains.World;

/// <summary>
/// 剑冢相枢化身的完成状态
/// </summary>
public static class SwordTombStatus
{
	/// <summary>
	/// 未完成
	/// </summary>
	public const sbyte Unfinished = 0;

	/// <summary>
	/// 完成一阶段
	/// </summary>
	public const sbyte PhaseOneDefeated = 1;

	/// <summary>
	/// 完成二阶段
	/// </summary>
	public const sbyte PhaseTwoDefeated = 2;
}
