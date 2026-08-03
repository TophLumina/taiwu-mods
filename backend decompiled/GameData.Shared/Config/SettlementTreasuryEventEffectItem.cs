using System;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementTreasuryEventEffectItem : ConfigItem<SettlementTreasuryEventEffectItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 筛选守卫人数百分比
	/// - 筛选的基本人数百分比。公式：基础人数因子 + 总价值 *价值因子/ 神一宝物的价值
	/// </summary>
	public readonly int ChangeFavorGuardBaseRate;

	/// <summary>
	/// 守卫人数价值因子
	/// - 根据计算公式筛选参与结算的守卫的数量百分比。公式：基础人数百分比 + 总价值 *价值因子/ 神一宝物的价值；最终值超过100时视为100
	/// </summary>
	public readonly int ChangeFavorGuardFactor;

	/// <summary>
	/// 最小受影响守卫人数
	/// </summary>
	public readonly int MinAffectedGuardCount;

	/// <summary>
	/// 守卫直接好感变化
	/// - 发生对应行为时，守卫变化的好感度
	/// </summary>
	public readonly int GuardBaseFavorChange;

	/// <summary>
	/// 守卫好感变化因子
	/// - 发生对应行为时，根据公式计算的好感度变化量参数。公式：总价值 * 因子 / 100
	/// </summary>
	public readonly int GuardFavorChangeFactor;

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
	/// - 筛选除守卫外百分之多少人变化好感度
	/// </summary>
	public readonly int ChangeFavorMemberBaseRate;

	/// <summary>
	/// 筛选成员人数因子
	/// - 根据计算公式筛选除守卫外百分之多少人变化好感度。掠夺公式：（10 + 总价值 * 因子 / 神一宝物的价值）*势力总人数；赠予公式：（0 + 总价值 * 因子 / 神一宝物的价值）*势力总人数
	/// </summary>
	public readonly int ChangeFavorMemberFactor;

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
	/// 成员好感变化因子
	/// - 发生对应行为时，根据公式计算的好感度变化量参数。公式：总价值 * 因子 / 100
	/// </summary>
	public readonly int MemberFavorChangeFactor;

	/// <summary>
	/// 门派取消支持比例
	/// - 在筛选出来的人物中百分之多少人取消门派支持
	/// </summary>
	public readonly int MemberDisapproveRate;

	/// <summary>
	/// 门派获得支持比例
	/// - 在筛选出来的人物中百分之多少人获得门派支持
	/// </summary>
	public readonly int MemberApproveRate;

	/// <summary>
	/// 与人物结仇比例
	/// - 在筛选出来的人物中百分之多少人会和太吾结仇
	/// </summary>
	public readonly int MemberBecomeEnemyRate;

	/// <summary>
	/// 直接恩义变化
	/// - 地区恩义的直接变化量
	/// </summary>
	public readonly int BaseSpiritualDebtChange;

	/// <summary>
	/// 恩义变化因子
	/// - 太吾的地区恩义变化因子。公式：视为存放或窃取的物品价值 * 因子 / 神一宝物的价值。（正数存放，负数窃取）
	/// </summary>
	public readonly int SpiritualDebtChangeFactor;

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
	/// <param name="changeFavorGuardBaseRate">筛选守卫人数百分比 - 筛选的基本人数百分比。公式：基础人数因子 + 总价值 *价值因子/ 神一宝物的价值</param>
	/// <param name="changeFavorGuardFactor">守卫人数价值因子 - 根据计算公式筛选参与结算的守卫的数量百分比。公式：基础人数百分比 + 总价值 *价值因子/ 神一宝物的价值；最终值超过100时视为100</param>
	/// <param name="minAffectedGuardCount">最小受影响守卫人数</param>
	/// <param name="guardBaseFavorChange">守卫直接好感变化 - 发生对应行为时，守卫变化的好感度</param>
	/// <param name="guardFavorChangeFactor">守卫好感变化因子 - 发生对应行为时，根据公式计算的好感度变化量参数。公式：总价值 * 因子 / 100</param>
	/// <param name="guardDisapproveRate">守卫取消支持比例 - 在筛选出来的人物中百分之多少人取消门派支持</param>
	/// <param name="guardApproveRate">守卫获得支持比例</param>
	/// <param name="guardBecomeEnemyRate">与守卫结仇比例 - 在筛选出来的人物中百分之多少人会和太吾结仇</param>
	/// <param name="changeFavorMemberBaseRate">筛选成员人数百分比 - 筛选除守卫外百分之多少人变化好感度</param>
	/// <param name="changeFavorMemberFactor">筛选成员人数因子 - 根据计算公式筛选除守卫外百分之多少人变化好感度。掠夺公式：（10 + 总价值 * 因子 / 神一宝物的价值）*势力总人数；赠予公式：（0 + 总价值 * 因子 / 神一宝物的价值）*势力总人数</param>
	/// <param name="minAffectedMemberCount">最小受影响其他人数</param>
	/// <param name="memberBaseFavorChange">成员直接好感变化 - 非守卫的其他成员变化的好感度</param>
	/// <param name="memberFavorChangeFactor">成员好感变化因子 - 发生对应行为时，根据公式计算的好感度变化量参数。公式：总价值 * 因子 / 100</param>
	/// <param name="memberDisapproveRate">门派取消支持比例 - 在筛选出来的人物中百分之多少人取消门派支持</param>
	/// <param name="memberApproveRate">门派获得支持比例 - 在筛选出来的人物中百分之多少人获得门派支持</param>
	/// <param name="memberBecomeEnemyRate">与人物结仇比例 - 在筛选出来的人物中百分之多少人会和太吾结仇</param>
	/// <param name="baseSpiritualDebtChange">直接恩义变化 - 地区恩义的直接变化量</param>
	/// <param name="spiritualDebtChangeFactor">恩义变化因子 - 太吾的地区恩义变化因子。公式：视为存放或窃取的物品价值 * 因子 / 神一宝物的价值。（正数存放，负数窃取）</param>
	/// <param name="taiwuBounty">太吾罪行 - 门派给太吾增加对应罪行</param>
	/// <param name="alterTime">戒严时间</param>
	public SettlementTreasuryEventEffectItem(short templateId, int changeFavorGuardBaseRate, int changeFavorGuardFactor, int minAffectedGuardCount, int guardBaseFavorChange, int guardFavorChangeFactor, int guardDisapproveRate, int guardApproveRate, int guardBecomeEnemyRate, int changeFavorMemberBaseRate, int changeFavorMemberFactor, int minAffectedMemberCount, int memberBaseFavorChange, int memberFavorChangeFactor, int memberDisapproveRate, int memberApproveRate, int memberBecomeEnemyRate, int baseSpiritualDebtChange, int spiritualDebtChangeFactor, short taiwuBounty, sbyte alterTime)
	{
		TemplateId = templateId;
		ChangeFavorGuardBaseRate = changeFavorGuardBaseRate;
		ChangeFavorGuardFactor = changeFavorGuardFactor;
		MinAffectedGuardCount = minAffectedGuardCount;
		GuardBaseFavorChange = guardBaseFavorChange;
		GuardFavorChangeFactor = guardFavorChangeFactor;
		GuardDisapproveRate = guardDisapproveRate;
		GuardApproveRate = guardApproveRate;
		GuardBecomeEnemyRate = guardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = changeFavorMemberBaseRate;
		ChangeFavorMemberFactor = changeFavorMemberFactor;
		MinAffectedMemberCount = minAffectedMemberCount;
		MemberBaseFavorChange = memberBaseFavorChange;
		MemberFavorChangeFactor = memberFavorChangeFactor;
		MemberDisapproveRate = memberDisapproveRate;
		MemberApproveRate = memberApproveRate;
		MemberBecomeEnemyRate = memberBecomeEnemyRate;
		BaseSpiritualDebtChange = baseSpiritualDebtChange;
		SpiritualDebtChangeFactor = spiritualDebtChangeFactor;
		TaiwuBounty = taiwuBounty;
		AlterTime = alterTime;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SettlementTreasuryEventEffectItem()
	{
		TemplateId = 0;
		ChangeFavorGuardBaseRate = 0;
		ChangeFavorGuardFactor = 0;
		MinAffectedGuardCount = 0;
		GuardBaseFavorChange = 0;
		GuardFavorChangeFactor = 0;
		GuardDisapproveRate = 0;
		GuardApproveRate = 0;
		GuardBecomeEnemyRate = 0;
		ChangeFavorMemberBaseRate = 0;
		ChangeFavorMemberFactor = 0;
		MinAffectedMemberCount = 0;
		MemberBaseFavorChange = 0;
		MemberFavorChangeFactor = 0;
		MemberDisapproveRate = 0;
		MemberApproveRate = 0;
		MemberBecomeEnemyRate = 0;
		BaseSpiritualDebtChange = 0;
		SpiritualDebtChangeFactor = 0;
		TaiwuBounty = 0;
		AlterTime = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SettlementTreasuryEventEffectItem(short templateId, SettlementTreasuryEventEffectItem other)
	{
		TemplateId = templateId;
		ChangeFavorGuardBaseRate = other.ChangeFavorGuardBaseRate;
		ChangeFavorGuardFactor = other.ChangeFavorGuardFactor;
		MinAffectedGuardCount = other.MinAffectedGuardCount;
		GuardBaseFavorChange = other.GuardBaseFavorChange;
		GuardFavorChangeFactor = other.GuardFavorChangeFactor;
		GuardDisapproveRate = other.GuardDisapproveRate;
		GuardApproveRate = other.GuardApproveRate;
		GuardBecomeEnemyRate = other.GuardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = other.ChangeFavorMemberBaseRate;
		ChangeFavorMemberFactor = other.ChangeFavorMemberFactor;
		MinAffectedMemberCount = other.MinAffectedMemberCount;
		MemberBaseFavorChange = other.MemberBaseFavorChange;
		MemberFavorChangeFactor = other.MemberFavorChangeFactor;
		MemberDisapproveRate = other.MemberDisapproveRate;
		MemberApproveRate = other.MemberApproveRate;
		MemberBecomeEnemyRate = other.MemberBecomeEnemyRate;
		BaseSpiritualDebtChange = other.BaseSpiritualDebtChange;
		SpiritualDebtChangeFactor = other.SpiritualDebtChangeFactor;
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
	public override SettlementTreasuryEventEffectItem Duplicate(int templateId)
	{
		return new SettlementTreasuryEventEffectItem((short)templateId, this);
	}
}
