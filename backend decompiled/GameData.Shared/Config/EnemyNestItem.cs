using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EnemyNestItem : ConfigItem<EnemyNestItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 地块TIP的标题
	/// </summary>
	public readonly string TipTitle;

	/// <summary>
	/// 地块TIP的描述
	/// </summary>
	public readonly string TipDesc;

	/// <summary>
	/// 巢穴类型
	/// - 0为外道，1为义士
	/// </summary>
	public readonly sbyte NestType;

	/// <summary>
	/// 成员
	/// - 关联到 Character 表
	/// </summary>
	public readonly List<short> Members;

	/// <summary>
	/// 领袖
	/// </summary>
	public readonly short Leader;

	/// <summary>
	/// 生成系数
	/// - 每次生成奇遇，各个成员在巢穴附近3格范围内的地图上会生成的数量
	/// </summary>
	public readonly List<short> SpawnAmountFactors;

	/// <summary>
	/// 过月事件行为
	/// </summary>
	public readonly short MonthlyActionId;

	/// <summary>
	/// 奇遇
	/// - 对应的奇遇的TemplateId
	/// </summary>
	public readonly int AdventureId;

	/// <summary>
	/// 地区恩义
	/// </summary>
	public readonly short SpiritualDebtChange;

	/// <summary>
	/// 历练
	/// </summary>
	public readonly int ExpReward;

	/// <summary>
	/// 威望
	/// </summary>
	public readonly int AuthorityReward;

	/// <summary>
	/// 银钱
	/// </summary>
	public readonly int MoneyReward;

	/// <summary>
	/// 被占领后持续时间
	/// - 被占领后多久消失，-1表示不会消失
	/// </summary>
	public readonly short ConqueredDuration;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="tipTitle">地块TIP的标题</param>
	/// <param name="tipDesc">地块TIP的描述</param>
	/// <param name="nestType">巢穴类型 - 0为外道，1为义士</param>
	/// <param name="members">成员 - 关联到 Character 表</param>
	/// <param name="leader">领袖</param>
	/// <param name="spawnAmountFactors">生成系数 - 每次生成奇遇，各个成员在巢穴附近3格范围内的地图上会生成的数量</param>
	/// <param name="monthlyActionId">过月事件行为</param>
	/// <param name="adventureId">奇遇 - 对应的奇遇的TemplateId</param>
	/// <param name="spiritualDebtChange">地区恩义</param>
	/// <param name="expReward">历练</param>
	/// <param name="authorityReward">威望</param>
	/// <param name="moneyReward">银钱</param>
	/// <param name="conqueredDuration">被占领后持续时间 - 被占领后多久消失，-1表示不会消失</param>
	public EnemyNestItem(short templateId, string tipTitle, string tipDesc, sbyte nestType, List<short> members, short leader, List<short> spawnAmountFactors, short monthlyActionId, int adventureId, short spiritualDebtChange, int expReward, int authorityReward, int moneyReward, short conqueredDuration)
	{
		TemplateId = templateId;
		TipTitle = tipTitle;
		TipDesc = tipDesc;
		NestType = nestType;
		Members = members;
		Leader = leader;
		SpawnAmountFactors = spawnAmountFactors;
		MonthlyActionId = monthlyActionId;
		AdventureId = adventureId;
		SpiritualDebtChange = spiritualDebtChange;
		ExpReward = expReward;
		AuthorityReward = authorityReward;
		MoneyReward = moneyReward;
		ConqueredDuration = conqueredDuration;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EnemyNestItem()
	{
		TemplateId = 0;
		TipTitle = null;
		TipDesc = null;
		NestType = 0;
		Members = null;
		Leader = 0;
		SpawnAmountFactors = null;
		MonthlyActionId = 0;
		AdventureId = 0;
		SpiritualDebtChange = 0;
		ExpReward = 0;
		AuthorityReward = 0;
		MoneyReward = 0;
		ConqueredDuration = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EnemyNestItem(short templateId, EnemyNestItem other)
	{
		TemplateId = templateId;
		TipTitle = other.TipTitle;
		TipDesc = other.TipDesc;
		NestType = other.NestType;
		Members = other.Members;
		Leader = other.Leader;
		SpawnAmountFactors = other.SpawnAmountFactors;
		MonthlyActionId = other.MonthlyActionId;
		AdventureId = other.AdventureId;
		SpiritualDebtChange = other.SpiritualDebtChange;
		ExpReward = other.ExpReward;
		AuthorityReward = other.AuthorityReward;
		MoneyReward = other.MoneyReward;
		ConqueredDuration = other.ConqueredDuration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EnemyNestItem Duplicate(int templateId)
	{
		return new EnemyNestItem((short)templateId, this);
	}
}
