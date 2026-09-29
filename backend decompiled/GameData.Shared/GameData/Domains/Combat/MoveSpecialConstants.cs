using GameData.Combat.Math;

namespace GameData.Domains.Combat;

public static class MoveSpecialConstants
{
	public static int MaxMobility => GlobalConfig.Instance.MaxMobility;

	public static int MobilityRecoverSpeed => GlobalConfig.Instance.MobilityRecoverSpeed;

	public static int LockingRecoverSpeed => GlobalConfig.Instance.LockingRecoverSpeed;

	public static int ReduceJumpProgressFrame => GlobalConfig.Instance.ReduceJumpProgressFrame;

	public static CValuePercent ReduceJumpProgressPercent => GlobalConfig.Instance.ReduceJumpProgressPercent;

	public static int MoveCdBase => GlobalConfig.Instance.MoveCdBase;

	public static int MoveCdFactor => GlobalConfig.Instance.MoveCdFactor;

	public static int MoveCdDivisorBase => GlobalConfig.Instance.MoveCdDivisorBase;

	public static int MoveCdDivisorFactor => GlobalConfig.Instance.MoveCdDivisorFactor;
}
