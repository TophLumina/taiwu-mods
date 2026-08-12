/// <summary>
/// SecretInformationSpecialCondition -&gt; Calculate
/// </summary>
public enum ESecretInformationSpecialConditionCalculate
{
	/// <summary>
	/// 无效
	/// </summary>
	None = -1,
	/// <summary>
	/// 同门相残
	/// </summary>
	SameSect,
	/// <summary>
	/// 门派行道
	/// </summary>
	SectJustice,
	/// <summary>
	/// 敌对门派
	/// </summary>
	SectBecomeEnemy,
	/// <summary>
	/// 违背门规
	/// </summary>
	ForbidMarriage,
	/// <summary>
	/// 相关秘闻公开
	/// </summary>
	IsPublished,
	/// <summary>
	/// 违背伦理
	/// </summary>
	IsRevealed,
	/// <summary>
	/// 未婚
	/// </summary>
	IsRevealedSingle,
	/// <summary>
	/// 恋人出轨
	/// </summary>
	HasCouple,
	/// <summary>
	/// 名誉为负
	/// </summary>
	NotFame,
	/// <summary>
	/// 已出家
	/// </summary>
	IsMonk,
	/// <summary>
	/// 违背门规饮酒
	/// </summary>
	ForbidWine,
	/// <summary>
	/// 违背门规淬毒
	/// </summary>
	ForbidPoison,
	/// <summary>
	/// 违背门规饮食
	/// </summary>
	ForbidItem,
	/// <summary>
	/// 有恋爱关系
	/// </summary>
	HasLove,
	/// <summary>
	/// 有特殊关系
	/// </summary>
	HasRelation,
	/// <summary>
	/// 被劫持
	/// </summary>
	IsKidnapped,
	/// <summary>
	/// 玩家战斗
	/// </summary>
	TaiwuFight,
	/// <summary>
	/// 玩家窃取
	/// </summary>
	TaiwuSteal,
	/// <summary>
	/// 玩家唬骗
	/// </summary>
	TaiwuScam,
	/// <summary>
	/// 玩家抢夺
	/// </summary>
	TaiwuRob,
	/// <summary>
	/// 玩家解救逃脱
	/// </summary>
	TaiwuRescueEscape,
	/// <summary>
	/// 对方解救逃脱
	/// </summary>
	CharRescueEscape,
	/// <summary>
	/// 战力比拼
	/// </summary>
	CompareCombatPoint,
	/// <summary>
	/// 对方战斗
	/// </summary>
	CharFight,
	/// <summary>
	/// 拒绝保密开战
	/// </summary>
	RefuseKeep,
	/// <summary>
	/// 对方解救
	/// </summary>
	CharRescue,
	/// <summary>
	/// 对方处置
	/// </summary>
	CharWin,
	/// <summary>
	/// 对方惩戒处置
	/// </summary>
	CharJudge,
	/// <summary>
	/// 对方抢人处置
	/// </summary>
	CharKidnap,
	/// <summary>
	/// 玩家逃跑
	/// </summary>
	TaiwuEscape,
	/// <summary>
	/// 对方逃跑
	/// </summary>
	CharEscape,
	/// <summary>
	/// 战斗
	/// </summary>
	StartFight,
	/// <summary>
	/// 较艺
	/// </summary>
	StartLifeSkillCombat,
	/// <summary>
	/// 选择绳索
	/// </summary>
	ChooseRope,
	/// <summary>
	/// 捕捉人物
	/// </summary>
	KidnapWithRope,
	/// <summary>
	/// 对方爱慕玩家
	/// </summary>
	CharAdore,
	/// <summary>
	/// 玩家爱慕对方
	/// </summary>
	TaiwuAdore,
	/// <summary>
	/// 玩家删除秘闻
	/// </summary>
	TaiwuDeleteInfomation,
	/// <summary>
	/// 对方删除秘闻
	/// </summary>
	CharDeleteInfomation,
	/// <summary>
	/// 对方断绝情爱
	/// </summary>
	CharBreakUp,
	/// <summary>
	/// 玩家解除爱慕
	/// </summary>
	TaiwuEndAdored,
	/// <summary>
	/// 对方解除爱慕
	/// </summary>
	CharEndAdored,
	/// <summary>
	/// 原谅处置
	/// </summary>
	Forgive,
	/// <summary>
	/// 情难处置
	/// </summary>
	NotForgiveRape,
	/// <summary>
	/// 掌门回应
	/// </summary>
	ApplyOfLeader,
	/// <summary>
	/// 真实违背门规
	/// </summary>
	LawBreaker,
	/// <summary>
	/// 要求保密
	/// </summary>
	AskCharKeep,
	/// <summary>
	/// 要求俘虏
	/// </summary>
	AskCharRelease,
	/// <summary>
	/// 要求分手
	/// </summary>
	AskCharBreakup,
	/// <summary>
	/// 背恩绝情
	/// </summary>
	BreakupWithChar,
	/// <summary>
	/// 执意断情
	/// </summary>
	ForceBreakupWithChar,
	/// <summary>
	/// 显示初级回应
	/// </summary>
	ShowFristContent,
	/// <summary>
	/// 当事人存活
	/// </summary>
	ActorAlive,
	/// <summary>
	/// 违法犯罪
	/// </summary>
	BreakTheLaw,
	/// <summary>
	/// 被害者为门派人物
	/// </summary>
	CasualtyInSect,
	/// <summary>
	/// 杀害指定名誉的人
	/// </summary>
	KillFameLine,
	/// <summary>
	/// 关押指定名誉的人
	/// </summary>
	KidnapFameLine,
	/// <summary>
	/// 结交门派弟子
	/// </summary>
	AlliedSectMember,
	/// <summary>
	/// 和门派弟子拍拖
	/// </summary>
	BeLoverSectMember,
	/// <summary>
	/// 和门派弟子结义
	/// </summary>
	BeKyodaiSectMember,
	/// <summary>
	/// 拜认门派弟子为义亲
	/// </summary>
	GainParentSectMember,
	/// <summary>
	/// 收养门派弟子
	/// </summary>
	GainChildSectMember,
	/// <summary>
	/// 和门派弟子约会
	/// </summary>
	DateSectMember,
	/// <summary>
	/// 寻回从属门派的子女
	/// </summary>
	ReFoundChildSectMember,
	/// <summary>
	/// 禁忌男女关系
	/// </summary>
	BanSexualMate,
	/// <summary>
	/// 饮食破戒
	/// </summary>
	BanEating,
	Count
}
