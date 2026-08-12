using System.Collections.Generic;

namespace GameData.Domains.Taiwu.DebateAI;

public class DebateAiConstants
{
	public static List<int[]> AttackLineWeight => GlobalConfig.Instance.AttackLineWeight;

	public static List<int[]> MidLineWeight => GlobalConfig.Instance.MidLineWeight;

	public static List<int[]> DefenseLineWeight => GlobalConfig.Instance.DefenseLineWeight;

	public static int[] EarlyBases => GlobalConfig.Instance.EarlyBases;

	public static int[] MidBases => GlobalConfig.Instance.MidBases;

	public static int[] LateBases => GlobalConfig.Instance.LateBases;

	public static List<int[]> EarlyStrategyPoint => GlobalConfig.Instance.EarlyStrategyPoint;

	public static List<int[]> MidStrategyPoint => GlobalConfig.Instance.MidStrategyPoint;

	public static List<int[]> LateStrategyPoint => GlobalConfig.Instance.LateStrategyPoint;

	public static int[] DamageLineWeight => GlobalConfig.Instance.DamageLineWeight;

	public static int[] DamagedLineWeight => GlobalConfig.Instance.DamagedLineWeight;

	public static List<int[]> StateGamePointPressureInfluence => GlobalConfig.Instance.StateGamePointPressureInfluence;

	public static List<int[]> StatePawnCountInfluence => GlobalConfig.Instance.StatePawnCountInfluence;

	public static int[] StateRoundInfluence => GlobalConfig.Instance.StateRoundInfluence;

	public static int EgoisticNodeEffectWeightPercent => GlobalConfig.Instance.EgoisticNodeEffectWeightPercent;

	public static int[] EvenNodeEffectMaxGradeProb => GlobalConfig.Instance.EvenNodeEffectMaxGradeProb;

	public static int RoundBeforeEarly => GlobalConfig.Instance.RoundBeforeEarly;

	public static int MinGradeIfEnoughBases => GlobalConfig.Instance.MinGradeIfEnoughBases;

	public static int[] ZeroGradePawnProb => GlobalConfig.Instance.ZeroGradePawnProb;

	public static int MakeMoveOnOverwhelmingLineProb => GlobalConfig.Instance.MakeMoveOnOverwhelmingLineProb;

	public static int RemoveStrategyTargetPawnBasesPercent => GlobalConfig.Instance.RemoveStrategyTargetPawnBasesPercent;
}
