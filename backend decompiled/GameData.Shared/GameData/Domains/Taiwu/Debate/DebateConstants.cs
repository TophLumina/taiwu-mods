namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 辩论常数
/// </summary>
public class DebateConstants
{
	/// <summary>
	/// 最大结论点
	/// </summary>
	public static int MaxGamePoint => GlobalConfig.Instance.DebateMaxGamePoint;

	/// <summary>
	/// 最大回合数
	/// </summary>
	public static int MaxRound => GlobalConfig.Instance.DebateMaxRound;

	/// <summary>
	/// 三条兵线
	/// </summary>
	public static int DebateLineCount => GlobalConfig.Instance.DebateLineCount;

	/// <summary>
	/// 每条兵线上有六个格子
	/// </summary>
	public static int DebateLineNodeCount => GlobalConfig.Instance.DebateLineNodeCount;

	/// <summary>
	/// 每条兵线上太吾优势的格子数
	/// </summary>
	public static int[] TaiwuVantageNodeCount => GlobalConfig.Instance.DebateTaiwuVantageNodeCount;

	/// <summary>
	/// 卡组类型上限
	/// </summary>
	public static int CardTypeLimit => GlobalConfig.Instance.DebateCardTypeLimit;

	/// <summary>
	/// 每回合落子上限
	/// </summary>
	public static int MakeMoveLimit => GlobalConfig.Instance.DebateMakeMoveLimit;

	/// <summary>
	/// 每回合抽卡上限
	/// </summary>
	public static int GetStrategyLimit => GlobalConfig.Instance.DebateGetStrategyLimit;

	/// <summary>
	/// 每个论点可附着的策略上限
	/// </summary>
	public static int PawnStrategyLimit => GlobalConfig.Instance.DebatePawnStrategyLimit;

	/// <summary>
	/// 选择等级到论点论据的转换百分比
	/// </summary>
	public static int GradeToBasesPercent => GlobalConfig.Instance.DebateGradeToBasesPercent;

	/// <summary>
	/// 每个论点对结论点的伤害值
	/// </summary>
	public static int PawnDamageToGamePoint => GlobalConfig.Instance.DebatePawnDamageToGamePoint;

	/// <summary>
	/// 观众所在地格的范围
	/// </summary>
	public static int SpectatorPickRange => GlobalConfig.Instance.DebateSpectatorPickRange;

	/// <summary>
	/// 迫使投降系数1
	/// </summary>
	public static int SurrenderAttainmentFactor => GlobalConfig.Instance.DebateSurrenderAttainmentFactor;

	/// <summary>
	/// 迫使投降系数2
	/// </summary>
	public static int[] SurrenderBehaviorFactor => GlobalConfig.Instance.DebateSurrenderBehaviorFactor;

	/// <summary>
	/// 造诣到论据的转换比例
	/// </summary>
	public static int[] AttainmentToBasesPercent => GlobalConfig.Instance.DebateAttainmentToMaxBasesPercent;

	/// <summary>
	/// 每轮游戏总论据恢复
	/// </summary>
	public static int BasesRecoverPercent => GlobalConfig.Instance.DebateBasesRecoverPercent;

	/// <summary>
	/// 初始策略点
	/// </summary>
	public static int InitialStrategyPoint => GlobalConfig.Instance.DebateInitialStrategyPoint;

	/// <summary>
	/// 最大策略点
	/// </summary>
	public static int MaxStrategyPoint => GlobalConfig.Instance.DebateMaxStrategyPoint;

	/// <summary>
	/// 每轮游戏策略点恢复
	/// </summary>
	public static int StrategyPointRecover => GlobalConfig.Instance.DebateStrategyPointRecover;

	/// <summary>
	/// 压力上限
	/// </summary>
	public static int MaxPressure => GlobalConfig.Instance.DebateMaxPressure;

	/// <summary>
	/// 压力导致的策略点恢复百分比
	/// </summary>
	public static int PressureStrategyRecoverPercent => GlobalConfig.Instance.DebatePressureStrategyRecoverPercent;

	/// <summary>
	/// 压力导致的论据恢复百分比
	/// </summary>
	public static int PressureBasesRecoverPercent => GlobalConfig.Instance.DebatePressureBasesRecoverPercent;

	/// <summary>
	/// 压力自动升高所需的回合数
	/// </summary>
	public static int PressureAutoIncreaseRound => GlobalConfig.Instance.DebatePressureAutoIncreaseRound;

	/// <summary>
	/// 压力自动升高数值
	/// </summary>
	public static int PressureAutoIncreaseValue => GlobalConfig.Instance.DebatePreesureAutoIncreaseValue;

	/// <summary>
	/// 低压力百分比
	/// </summary>
	public static int LowPressurePercent => GlobalConfig.Instance.DebateLowPressurePercent;

	/// <summary>
	/// 中压力百分比
	/// </summary>
	public static int MidPressurePercent => GlobalConfig.Instance.DebateMidPressurePercent;

	/// <summary>
	/// 高压力百分比
	/// </summary>
	public static int HighPressurePercent => GlobalConfig.Instance.DebateHighPressurePercent;

	/// <summary>
	/// 心浮气躁概率
	/// </summary>
	public static int[] ReduceStrategyRecoverProb => GlobalConfig.Instance.DebateReduceStrategyRecoverProb;

	/// <summary>
	/// 心烦意乱概率
	/// </summary>
	public static int[] ReduceBasesRecoverProb => GlobalConfig.Instance.DebateReduceBasesRecoverProb;

	/// <summary>
	/// 语无伦次概率
	/// </summary>
	public static int[] UseStrategyFailedProb => GlobalConfig.Instance.DebateUseStrategyFailedProb;

	/// <summary>
	/// 失魂落魄概率
	/// </summary>
	public static int[] MakeMoveFailedProb => GlobalConfig.Instance.DebateMakeMoveFailedProb;

	/// <summary>
	/// 论战导致的压力变化
	/// </summary>
	public static int PressureDeltaInConflict => GlobalConfig.Instance.DebatePressureDeltaInConflict;

	/// <summary>
	/// 同一评价最大数量
	/// </summary>
	public static int CommentStackLimit => GlobalConfig.Instance.DebateCommentStackLimit;

	/// <summary>
	/// 以大欺小对手造诣百分比
	/// </summary>
	public static int BullyPercent => GlobalConfig.Instance.DebateBullyPercent;

	/// <summary>
	/// 以小博大对手造诣百分比
	/// </summary>
	public static int OverComePercent => GlobalConfig.Instance.DebateOverComePercent;

	/// <summary>
	/// 观众发表评价几率
	/// </summary>
	public static int CommentProb => GlobalConfig.Instance.DebateCommentProb;

	/// <summary>
	/// 己方观众发表正面评价几率
	/// </summary>
	public static int SameSideCommentProb => GlobalConfig.Instance.DebateSameSideCommentProb;

	/// <summary>
	/// 对方观众发表正面评价几率
	/// </summary>
	public static int OtherSideCommentProb => GlobalConfig.Instance.DebateOtherSideCommentProb;

	/// <summary>
	/// 观众发表评价好感度参数
	/// </summary>
	public static int CommentDivider => GlobalConfig.Instance.DebateCommentDivider;

	/// <summary>
	/// 观众使用场地效果的几率
	/// </summary>
	public static int AddNodeEffectProb => GlobalConfig.Instance.DebateAddNodeEffectProb;

	/// <summary>
	/// 观众帮助己方的基础几率
	/// </summary>
	public static int SpectatorHelpSameSideBase => GlobalConfig.Instance.DebateHelpSameSideProb;

	/// <summary>
	/// 观众帮助己方的系数
	/// </summary>
	public static int SpectatorHelpSameSideDivider => GlobalConfig.Instance.DebateHelpSameSideDivider;
}
