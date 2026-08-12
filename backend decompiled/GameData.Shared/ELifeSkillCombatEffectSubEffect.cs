/// <summary>
/// LifeSkillCombatEffect -&gt; SubEffect
/// </summary>
public enum ELifeSkillCombatEffectSubEffect
{
	/// <summary>
	/// 己方可提问在论据低的A方论点周围
	/// </summary>
	SelfExtraQuestionAroundHouseThesisLow,
	/// <summary>
	/// A方该点提问反问时多伪装D本书进入冷却
	/// </summary>
	SelfGridCoverBookStatesWhenAllQuestion,
	/// <summary>
	/// 放置在落子的格子上，对方进行交互时触发效果
	/// </summary>
	SelfTrapedInCell,
	/// <summary>
	/// 己方回合使用，可变更A方D本书籍E回合冷却
	/// </summary>
	SelfChangeBookCd,
	/// <summary>
	/// 己方回合使用，可根据己方论据分数计数抽卡
	/// </summary>
	SelfDoPickByPoint,
	/// <summary>
	/// 己方回合使用，可指定消除己方论点周围一个A方提问反问论点
	/// </summary>
	SelfEraseAroundSelfThesisHouseQuestionThesis,
	/// <summary>
	/// 己方回合使用，可指定消除一个A方提问反问论点上的所有策略
	/// </summary>
	SelfEraseAroundHouseQuestionEffects,
	/// <summary>
	/// 己方可提问在A方论点周围不跨越论据高的对方论点
	/// </summary>
	SelfExtraQuestionAroundHouseThesisBreakWhenAdversaryThesisHigh,
	/// <summary>
	/// 己方可提问在论据低的A方论点上将其转化为己方论点
	/// </summary>
	SelfExtraQuestionOnHouseThesisLowAndTransition,
	/// <summary>
	/// 己方可提问在论据低的己方论点上获得其卡片并替换落子情况
	/// </summary>
	SelfExtraQuestionOnHouseThesisLowAndRecycleCardAndExchangeOperation,
	/// <summary>
	/// 己方论点以因子D变更周围A方所有提问反问解答点数
	/// </summary>
	SelfThesisChangeAroundHouseActivePointWithParam,
	/// <summary>
	/// 己方落子所使用的书籍不进入冷却
	/// </summary>
	SelfNotCostBookStates,
	/// <summary>
	/// 己方提问反问变为己方论点时消除周围所有A方提问反问论点的策略效果
	/// </summary>
	SelfThesisWhenFixedEraseEffectsAroundHouseAllQuestionLowAndThesisLow,
	/// <summary>
	/// 己方提问反问变为己方论点时削除周围A方论据低的提问反问论点
	/// </summary>
	SelfThesisWhenFixedDoCancelAroundHouseAllQuestionLowAndThesisLow,
	/// <summary>
	/// 己方提问反问变为己方论点时以周围己方论点计数抽卡
	/// </summary>
	SelfThesisWhenFixedDoPickWithAroundHouseThesisCount,
	/// <summary>
	/// 本次落子的论据值增加
	/// </summary>
	PointChange,
	Count
}
