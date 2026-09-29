namespace GameData.Domains.Taiwu.Debate;

public class DebateConstants
{
	public static int MaxGamePoint => GlobalConfig.Instance.DebateMaxGamePoint;

	public static int MaxRound => GlobalConfig.Instance.DebateMaxRound;

	public static int DebateLineCount => GlobalConfig.Instance.DebateLineCount;

	public static int DebateLineNodeCount => GlobalConfig.Instance.DebateLineNodeCount;

	public static int[] TaiwuVantageNodeCount => GlobalConfig.Instance.DebateTaiwuVantageNodeCount;

	public static int CardTypeLimit => GlobalConfig.Instance.DebateCardTypeLimit;

	public static int MakeMoveLimit => GlobalConfig.Instance.DebateMakeMoveLimit;

	public static int GetStrategyLimit => GlobalConfig.Instance.DebateGetStrategyLimit;

	public static int PawnStrategyLimit => GlobalConfig.Instance.DebatePawnStrategyLimit;

	public static int GradeToBasesPercent => GlobalConfig.Instance.DebateGradeToBasesPercent;

	public static int PawnDamageToGamePoint => GlobalConfig.Instance.DebatePawnDamageToGamePoint;

	public static int SpectatorPickRange => GlobalConfig.Instance.DebateSpectatorPickRange;

	public static int SurrenderAttainmentFactor => GlobalConfig.Instance.DebateSurrenderAttainmentFactor;

	public static int[] SurrenderBehaviorFactor => GlobalConfig.Instance.DebateSurrenderBehaviorFactor;

	public static int[] AttainmentToBasesPercent => GlobalConfig.Instance.DebateAttainmentToMaxBasesPercent;

	public static int BasesRecoverPercent => GlobalConfig.Instance.DebateBasesRecoverPercent;

	public static int InitialStrategyPoint => GlobalConfig.Instance.DebateInitialStrategyPoint;

	public static int MaxStrategyPoint => GlobalConfig.Instance.DebateMaxStrategyPoint;

	public static int StrategyPointRecover => GlobalConfig.Instance.DebateStrategyPointRecover;

	public static int MaxPressure => GlobalConfig.Instance.DebateMaxPressure;

	public static int PressureStrategyRecoverPercent => GlobalConfig.Instance.DebatePressureStrategyRecoverPercent;

	public static int PressureBasesRecoverPercent => GlobalConfig.Instance.DebatePressureBasesRecoverPercent;

	public static int PressureAutoIncreaseRound => GlobalConfig.Instance.DebatePressureAutoIncreaseRound;

	public static int PressureAutoIncreaseValue => GlobalConfig.Instance.DebatePreesureAutoIncreaseValue;

	public static int LowPressurePercent => GlobalConfig.Instance.DebateLowPressurePercent;

	public static int MidPressurePercent => GlobalConfig.Instance.DebateMidPressurePercent;

	public static int HighPressurePercent => GlobalConfig.Instance.DebateHighPressurePercent;

	public static int[] ReduceStrategyRecoverProb => GlobalConfig.Instance.DebateReduceStrategyRecoverProb;

	public static int[] ReduceBasesRecoverProb => GlobalConfig.Instance.DebateReduceBasesRecoverProb;

	public static int[] UseStrategyFailedProb => GlobalConfig.Instance.DebateUseStrategyFailedProb;

	public static int[] MakeMoveFailedProb => GlobalConfig.Instance.DebateMakeMoveFailedProb;

	public static int PressureDeltaInConflict => GlobalConfig.Instance.DebatePressureDeltaInConflict;

	public static int CommentStackLimit => GlobalConfig.Instance.DebateCommentStackLimit;

	public static int BullyPercent => GlobalConfig.Instance.DebateBullyPercent;

	public static int OverComePercent => GlobalConfig.Instance.DebateOverComePercent;

	public static int CommentProb => GlobalConfig.Instance.DebateCommentProb;

	public static int SameSideCommentProb => GlobalConfig.Instance.DebateSameSideCommentProb;

	public static int OtherSideCommentProb => GlobalConfig.Instance.DebateOtherSideCommentProb;

	public static int CommentDivider => GlobalConfig.Instance.DebateCommentDivider;

	public static int AddNodeEffectProb => GlobalConfig.Instance.DebateAddNodeEffectProb;

	public static int SpectatorHelpSameSideBase => GlobalConfig.Instance.DebateHelpSameSideProb;

	public static int SpectatorHelpSameSideDivider => GlobalConfig.Instance.DebateHelpSameSideDivider;
}
