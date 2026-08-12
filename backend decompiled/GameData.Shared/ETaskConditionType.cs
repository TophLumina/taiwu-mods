/// <summary>
/// TaskCondition -&gt; Type
/// </summary>
public enum ETaskConditionType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 奇遇存在
	/// </summary>
	AdventureVisible,
	/// <summary>
	/// 角色存在
	/// </summary>
	CharacterExists,
	/// <summary>
	/// 角色位于地形
	/// </summary>
	CharacterAtMapBlock,
	/// <summary>
	/// 角色位于区域
	/// </summary>
	CharacterAtMapArea,
	/// <summary>
	/// 角色位于奇遇
	/// </summary>
	CharacterAtAdventure,
	/// <summary>
	/// 角色持有道具
	/// </summary>
	CharacterHasItems,
	/// <summary>
	/// 角色持有道具子类型
	/// </summary>
	CharacterHasItemSubType,
	/// <summary>
	/// 角色对太吾的好感度
	/// </summary>
	FavorabilityToTaiwu,
	/// <summary>
	/// 产业存在建筑
	/// </summary>
	SettlementHasBuilding,
	/// <summary>
	/// 功能解锁
	/// </summary>
	FunctionUnlocked,
	/// <summary>
	/// 紫竹化身任务进度
	/// </summary>
	JuniorXiangshuTaskStatus,
	/// <summary>
	/// 紫竹化身任务完成数量
	/// </summary>
	JuniorXiangshuTaskCompleteAmount,
	/// <summary>
	/// 剑冢攻克状态
	/// </summary>
	SwordTombStatus,
	/// <summary>
	/// 武林大会筹备中
	/// </summary>
	MartialArtTournamentPreparing,
	/// <summary>
	/// 全局参数盒子值范围
	/// </summary>
	GlobalArgBoxValueRange,
	/// <summary>
	/// 全局参数盒子键存在
	/// </summary>
	GlobalArgBoxKeyExists,
	/// <summary>
	/// 组合条件-和
	/// </summary>
	ConditionAnd,
	/// <summary>
	/// 组合条件-或
	/// </summary>
	ConditionOr,
	/// <summary>
	/// 太吾进入指定奇遇
	/// </summary>
	IsInAdventure,
	/// <summary>
	/// 指定志向技能可用
	/// </summary>
	ProfessionSkillValid,
	/// <summary>
	/// 指定州的寺庙被拜访
	/// </summary>
	StateTemplateVisited,
	/// <summary>
	/// 门派功能状态
	/// </summary>
	SectFunctionStatus,
	/// <summary>
	/// 角色为幽墓昔人记录的太吾
	/// </summary>
	CharacterIsTaiwuForJixi,
	/// <summary>
	/// 地区主线参数盒子值范围
	/// </summary>
	SectArgBoxValueRange,
	/// <summary>
	/// 地区主线参数盒子键存在
	/// </summary>
	SectArgBoxKeyExists,
	/// <summary>
	/// 角色位于太吾同道中
	/// </summary>
	CharacterInTaiwuGroup,
	/// <summary>
	/// 剧情角色解锁保管奇书
	/// </summary>
	CorpseCharacterGoodEnd,
	/// <summary>
	/// 存在非剧情神木
	/// </summary>
	NonStoryHeavenlyTreeExists,
	/// <summary>
	/// 角色拥有特性
	/// </summary>
	CharacterHasFeature,
	/// <summary>
	/// 地区剧情结局
	/// </summary>
	SectMainStoryEnding,
	/// <summary>
	/// 触发式任务已完成
	/// </summary>
	ExtraTaskFinished,
	Count
}
