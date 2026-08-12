using GameData.Combat.Math;

namespace GameData.Domains.Combat;

/// <summary>
/// 移动相关常量配置，为避免 GlobalConfig 合并冲突先临时写代码里
/// </summary>
public static class MoveSpecialConstants
{
	/// <summary>
	/// 脚力值上限
	/// </summary>
	public static int MaxMobility => GlobalConfig.Instance.MaxMobility;

	/// <summary>
	/// 脚力值恢复速度
	/// </summary>
	public static int MobilityRecoverSpeed => GlobalConfig.Instance.MobilityRecoverSpeed;

	/// <summary>
	/// 恢复状态恢复速度
	/// </summary>
	public static int LockingRecoverSpeed => GlobalConfig.Instance.LockingRecoverSpeed;

	/// <summary>
	/// 减少蓄力进度间隔帧数
	/// </summary>
	public static int ReduceJumpProgressFrame => GlobalConfig.Instance.ReduceJumpProgressFrame;

	/// <summary>
	/// 减少蓄力进度百分比
	/// </summary>
	public static CValuePercent ReduceJumpProgressPercent => GlobalConfig.Instance.ReduceJumpProgressPercent;

	/// <summary>
	/// 基础移动间隔
	/// </summary>
	public static int MoveCdBase => GlobalConfig.Instance.MoveCdBase;

	/// <summary>
	/// 移动间隔系数
	/// </summary>
	public static int MoveCdFactor => GlobalConfig.Instance.MoveCdFactor;

	/// <summary>
	/// 移动间隔基础除数
	/// </summary>
	public static int MoveCdDivisorBase => GlobalConfig.Instance.MoveCdDivisorBase;

	/// <summary>
	/// 移动间隔除数系数
	/// </summary>
	public static int MoveCdDivisorFactor => GlobalConfig.Instance.MoveCdDivisorFactor;
}
