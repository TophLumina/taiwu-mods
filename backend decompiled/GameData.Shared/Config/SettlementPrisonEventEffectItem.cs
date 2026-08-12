using System;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementPrisonEventEffectItem : ConfigItem<SettlementPrisonEventEffectItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 囚犯好感度变化
	/// </summary>
	public readonly int ChangeFavorTeammate;

	/// <summary>
	/// 捕快好感度变化
	/// </summary>
	public readonly int ChangeFavorCaptor;

	/// <summary>
	/// 筛选守卫人数百分比
	/// - 筛选的基本人数百分比
	/// </summary>
	public readonly int ChangeFavorGuardBaseRate;

	/// <summary>
	/// 最小受影响守卫人数
	/// </summary>
	public readonly int MinAffectedGuardCount;

	/// <summary>
	/// 守卫直接好感变化
	/// - 守卫变化的好感度
	/// </summary>
	public readonly int GuardBaseFavorChange;

	/// <summary>
	/// 守卫取消支持比例
	/// - 在筛选出来的人物中百分之多少人取消门派支持
	/// </summary>
	public readonly int GuardDisapproveRate;

	/// <summary>
	/// 守卫获得支持比例
	/// </summary>
	public readonly int GuardApproveRate;

	/// <summary>
	/// 与守卫结仇比例
	/// - 在筛选出来的人物中百分之多少人会和太吾结仇
	/// </summary>
	public readonly int GuardBecomeEnemyRate;

	/// <summary>
	/// 筛选成员人数百分比
	/// </summary>
	public readonly int ChangeFavorMemberBaseRate;

	/// <summary>
	/// 最小受影响其他人数
	/// </summary>
	public readonly int MinAffectedMemberCount;

	/// <summary>
	/// 成员直接好感变化
	/// - 非守卫的其他成员变化的好感度
	/// </summary>
	public readonly int MemberBaseFavorChange;

	/// <summary>
	/// 门派取消支持比例
	/// - 在筛选出来的人物中百分之多少人取消门派支持
	/// </summary>
	public readonly int MemberDisapproveRate;

	/// <summary>
	/// 门派获得支持比例
	/// - 在筛选出来的人物中百分之多少人新增门派支持
	/// </summary>
	public readonly int MemberApproveRate;

	/// <summary>
	/// 与人物结仇比例
	/// - 在筛选出来的人物中百分之多少人会和太吾结仇
	/// </summary>
	public readonly int MemberBecomeEnemyRate;

	/// <summary>
	/// 太吾罪行
	/// - 门派给太吾增加对应罪行
	/// </summary>
	public readonly short TaiwuBounty;

	/// <summary>
	/// 戒严时间
	/// </summary>
	public readonly sbyte AlterTime;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="changeFavorTeammate">囚犯好感度变化</param>
	/// <param name="changeFavorCaptor">捕快好感度变化</param>
	/// <param name="changeFavorGuardBaseRate">筛选守卫人数百分比 - 筛选的基本人数百分比</param>
	/// <param name="minAffectedGuardCount">最小受影响守卫人数</param>
	/// <param name="guardBaseFavorChange">守卫直接好感变化 - 守卫变化的好感度</param>
	/// <param name="guardDisapproveRate">守卫取消支持比例 - 在筛选出来的人物中百分之多少人取消门派支持</param>
	/// <param name="guardApproveRate">守卫获得支持比例</param>
	/// <param name="guardBecomeEnemyRate">与守卫结仇比例 - 在筛选出来的人物中百分之多少人会和太吾结仇</param>
	/// <param name="changeFavorMemberBaseRate">筛选成员人数百分比</param>
	/// <param name="minAffectedMemberCount">最小受影响其他人数</param>
	/// <param name="memberBaseFavorChange">成员直接好感变化 - 非守卫的其他成员变化的好感度</param>
	/// <param name="memberDisapproveRate">门派取消支持比例 - 在筛选出来的人物中百分之多少人取消门派支持</param>
	/// <param name="memberApproveRate">门派获得支持比例 - 在筛选出来的人物中百分之多少人新增门派支持</param>
	/// <param name="memberBecomeEnemyRate">与人物结仇比例 - 在筛选出来的人物中百分之多少人会和太吾结仇</param>
	/// <param name="taiwuBounty">太吾罪行 - 门派给太吾增加对应罪行</param>
	/// <param name="alterTime">戒严时间</param>
	public SettlementPrisonEventEffectItem(short templateId, int changeFavorTeammate, int changeFavorCaptor, int changeFavorGuardBaseRate, int minAffectedGuardCount, int guardBaseFavorChange, int guardDisapproveRate, int guardApproveRate, int guardBecomeEnemyRate, int changeFavorMemberBaseRate, int minAffectedMemberCount, int memberBaseFavorChange, int memberDisapproveRate, int memberApproveRate, int memberBecomeEnemyRate, short taiwuBounty, sbyte alterTime)
	{
		TemplateId = templateId;
		ChangeFavorTeammate = changeFavorTeammate;
		ChangeFavorCaptor = changeFavorCaptor;
		ChangeFavorGuardBaseRate = changeFavorGuardBaseRate;
		MinAffectedGuardCount = minAffectedGuardCount;
		GuardBaseFavorChange = guardBaseFavorChange;
		GuardDisapproveRate = guardDisapproveRate;
		GuardApproveRate = guardApproveRate;
		GuardBecomeEnemyRate = guardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = changeFavorMemberBaseRate;
		MinAffectedMemberCount = minAffectedMemberCount;
		MemberBaseFavorChange = memberBaseFavorChange;
		MemberDisapproveRate = memberDisapproveRate;
		MemberApproveRate = memberApproveRate;
		MemberBecomeEnemyRate = memberBecomeEnemyRate;
		TaiwuBounty = taiwuBounty;
		AlterTime = alterTime;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SettlementPrisonEventEffectItem()
	{
		TemplateId = 0;
		ChangeFavorTeammate = 0;
		ChangeFavorCaptor = 0;
		ChangeFavorGuardBaseRate = 0;
		MinAffectedGuardCount = 0;
		GuardBaseFavorChange = 0;
		GuardDisapproveRate = 0;
		GuardApproveRate = 0;
		GuardBecomeEnemyRate = 0;
		ChangeFavorMemberBaseRate = 0;
		MinAffectedMemberCount = 0;
		MemberBaseFavorChange = 0;
		MemberDisapproveRate = 0;
		MemberApproveRate = 0;
		MemberBecomeEnemyRate = 0;
		TaiwuBounty = 0;
		AlterTime = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SettlementPrisonEventEffectItem(short templateId, SettlementPrisonEventEffectItem other)
	{
		TemplateId = templateId;
		ChangeFavorTeammate = other.ChangeFavorTeammate;
		ChangeFavorCaptor = other.ChangeFavorCaptor;
		ChangeFavorGuardBaseRate = other.ChangeFavorGuardBaseRate;
		MinAffectedGuardCount = other.MinAffectedGuardCount;
		GuardBaseFavorChange = other.GuardBaseFavorChange;
		GuardDisapproveRate = other.GuardDisapproveRate;
		GuardApproveRate = other.GuardApproveRate;
		GuardBecomeEnemyRate = other.GuardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = other.ChangeFavorMemberBaseRate;
		MinAffectedMemberCount = other.MinAffectedMemberCount;
		MemberBaseFavorChange = other.MemberBaseFavorChange;
		MemberDisapproveRate = other.MemberDisapproveRate;
		MemberApproveRate = other.MemberApproveRate;
		MemberBecomeEnemyRate = other.MemberBecomeEnemyRate;
		TaiwuBounty = other.TaiwuBounty;
		AlterTime = other.AlterTime;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SettlementPrisonEventEffectItem Duplicate(int templateId)
	{
		return new SettlementPrisonEventEffectItem((short)templateId, this);
	}
}
