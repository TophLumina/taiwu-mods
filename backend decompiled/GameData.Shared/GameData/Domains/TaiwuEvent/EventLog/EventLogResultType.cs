namespace GameData.Domains.TaiwuEvent.EventLog;

/// <summary>
/// 事件记录类型
/// </summary>
public class EventLogResultType
{
	public const sbyte None = -1;

	/// <summary>
	/// 对话
	/// </summary>
	public const sbyte Dialog = 0;

	/// <summary>
	/// 商人对话
	/// </summary>
	public const sbyte MerchantDialog = 1;

	/// <summary>
	/// 玩家选择的回复
	/// </summary>
	public const sbyte Response = 2;

	/// <summary>
	/// 心情
	/// </summary>
	public const sbyte Happiness = 3;

	/// <summary>
	/// 名誉
	/// </summary>
	public const sbyte Fame = 4;

	/// <summary>
	/// 好感度
	/// </summary>
	public const sbyte FavorabilityToTaiwu = 5;

	/// <summary>
	/// 入魔值
	/// </summary>
	public const sbyte Infection = 6;

	/// <summary>
	/// 入魔状态
	/// </summary>
	public const sbyte InfectionStatus = 7;

	/// <summary>
	/// 进入战斗
	/// </summary>
	public const sbyte InCombat = 8;

	/// <summary>
	/// 进入较艺
	/// </summary>
	public const sbyte InLifeCombat = 9;

	/// <summary>
	/// 进入促织决斗
	/// </summary>
	public const sbyte InCricketCombat = 10;

	/// <summary>
	/// 物品
	/// </summary>
	public const sbyte Item = 11;

	/// <summary>
	/// 资源
	/// </summary>
	public const sbyte Resource = 12;

	/// <summary>
	/// 恩义
	/// </summary>
	public const sbyte SpiritualDebt = 13;

	/// <summary>
	/// 同道
	/// </summary>
	public const sbyte Teammate = 14;

	/// <summary>
	/// 健康
	/// </summary>
	public const sbyte Health = 15;

	/// <summary>
	/// 基础属性
	/// </summary>
	public const sbyte MainAttribute = 16;

	/// <summary>
	/// 内伤
	/// </summary>
	public const sbyte InnerInjury = 17;

	/// <summary>
	/// 外伤
	/// </summary>
	public const sbyte OuterInjury = 18;

	/// <summary>
	/// 中毒
	/// </summary>
	public const sbyte Poison = 19;

	/// <summary>
	/// 内息
	/// </summary>
	public const sbyte DisorderOfQi = 20;

	/// <summary>
	/// 习得功法
	/// </summary>
	public const sbyte CombatSkill = 21;

	/// <summary>
	/// 习得技艺
	/// </summary>
	public const sbyte LifeSkill = 22;

	/// <summary>
	/// 门派支持度
	/// </summary>
	public const sbyte ApprovedTaiwu = 23;

	/// <summary>
	/// 关系
	/// </summary>
	public const sbyte Relation = 24;

	/// <summary>
	/// 角色特性
	/// </summary>
	public const sbyte Feature = 25;

	/// <summary>
	/// 志向
	/// </summary>
	public const sbyte Profession = 26;

	/// <summary>
	/// 历练
	/// </summary>
	public const sbyte Exp = 27;

	/// <summary>
	/// 见闻
	/// </summary>
	public const sbyte NormalInformation = 28;

	/// <summary>
	/// 秘闻
	/// </summary>
	public const sbyte SecretInformation = 29;

	/// <summary>
	/// 收尾
	/// </summary>
	public const sbyte End = 30;

	public const sbyte Count = 31;
}
