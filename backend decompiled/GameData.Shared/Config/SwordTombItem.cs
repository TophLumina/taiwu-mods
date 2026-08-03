using System;
using Config.Common;

namespace Config;

[Serializable]
public class SwordTombItem : ConfigItem<SwordTombItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 剑冢奇遇ID
	/// </summary>
	public readonly int AdventureCoreId;

	/// <summary>
	/// 相枢化身起始角色ID
	/// </summary>
	public readonly short XiangshuAvatarBegin;

	/// <summary>
	/// 出冢化身起始角色ID
	/// </summary>
	public readonly short WeakenedXiangshuAvatarBegin;

	/// <summary>
	/// 紫竹化身角色ID
	/// </summary>
	public readonly short JuniorXiangshuAvatar;

	/// <summary>
	/// 木人相枢化身角色ID
	/// </summary>
	public readonly short PuppetXiangshuAvatar;

	/// <summary>
	/// 无敌出冢化身角色ID
	/// </summary>
	public readonly short ImmortalXiangshuAvatar;

	/// <summary>
	/// 战胜剑冢后获得的特性
	/// </summary>
	public readonly short[] Legacies;

	/// <summary>
	/// 拔除后的大事件
	/// </summary>
	public readonly short BigEventWhenRemoved;

	/// <summary>
	/// 神剑碎片
	/// </summary>
	public readonly short SwordFragment;

	/// <summary>
	/// 解之篇过月事件
	/// </summary>
	public readonly short MonthlyEventGood;

	/// <summary>
	/// 灭之篇过月事件
	/// </summary>
	public readonly short MonthlyEventBad;

	/// <summary>
	/// 战胜成就
	/// - 目前实现出于控制时机的便利，是在事件中手动触发而非通用逻辑，只有第一个剑冢会调用该配置.
	/// </summary>
	public readonly short DefeatAchievementStat;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="adventureCoreId">剑冢奇遇ID</param>
	/// <param name="xiangshuAvatarBegin">相枢化身起始角色ID</param>
	/// <param name="weakenedXiangshuAvatarBegin">出冢化身起始角色ID</param>
	/// <param name="juniorXiangshuAvatar">紫竹化身角色ID</param>
	/// <param name="puppetXiangshuAvatar">木人相枢化身角色ID</param>
	/// <param name="immortalXiangshuAvatar">无敌出冢化身角色ID</param>
	/// <param name="legacies">战胜剑冢后获得的特性</param>
	/// <param name="bigEventWhenRemoved">拔除后的大事件</param>
	/// <param name="swordFragment">神剑碎片</param>
	/// <param name="monthlyEventGood">解之篇过月事件</param>
	/// <param name="monthlyEventBad">灭之篇过月事件</param>
	/// <param name="defeatAchievementStat">战胜成就 - 目前实现出于控制时机的便利，是在事件中手动触发而非通用逻辑，只有第一个剑冢会调用该配置.</param>
	public SwordTombItem(sbyte templateId, int adventureCoreId, short xiangshuAvatarBegin, short weakenedXiangshuAvatarBegin, short juniorXiangshuAvatar, short puppetXiangshuAvatar, short immortalXiangshuAvatar, short[] legacies, short bigEventWhenRemoved, short swordFragment, short monthlyEventGood, short monthlyEventBad, short defeatAchievementStat)
	{
		TemplateId = templateId;
		AdventureCoreId = adventureCoreId;
		XiangshuAvatarBegin = xiangshuAvatarBegin;
		WeakenedXiangshuAvatarBegin = weakenedXiangshuAvatarBegin;
		JuniorXiangshuAvatar = juniorXiangshuAvatar;
		PuppetXiangshuAvatar = puppetXiangshuAvatar;
		ImmortalXiangshuAvatar = immortalXiangshuAvatar;
		Legacies = legacies;
		BigEventWhenRemoved = bigEventWhenRemoved;
		SwordFragment = swordFragment;
		MonthlyEventGood = monthlyEventGood;
		MonthlyEventBad = monthlyEventBad;
		DefeatAchievementStat = defeatAchievementStat;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SwordTombItem()
	{
		TemplateId = 0;
		AdventureCoreId = 0;
		XiangshuAvatarBegin = 0;
		WeakenedXiangshuAvatarBegin = 0;
		JuniorXiangshuAvatar = 0;
		PuppetXiangshuAvatar = 0;
		ImmortalXiangshuAvatar = 0;
		Legacies = null;
		BigEventWhenRemoved = 0;
		SwordFragment = 0;
		MonthlyEventGood = 0;
		MonthlyEventBad = 0;
		DefeatAchievementStat = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SwordTombItem(sbyte templateId, SwordTombItem other)
	{
		TemplateId = templateId;
		AdventureCoreId = other.AdventureCoreId;
		XiangshuAvatarBegin = other.XiangshuAvatarBegin;
		WeakenedXiangshuAvatarBegin = other.WeakenedXiangshuAvatarBegin;
		JuniorXiangshuAvatar = other.JuniorXiangshuAvatar;
		PuppetXiangshuAvatar = other.PuppetXiangshuAvatar;
		ImmortalXiangshuAvatar = other.ImmortalXiangshuAvatar;
		Legacies = other.Legacies;
		BigEventWhenRemoved = other.BigEventWhenRemoved;
		SwordFragment = other.SwordFragment;
		MonthlyEventGood = other.MonthlyEventGood;
		MonthlyEventBad = other.MonthlyEventBad;
		DefeatAchievementStat = other.DefeatAchievementStat;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SwordTombItem Duplicate(int templateId)
	{
		return new SwordTombItem((sbyte)templateId, this);
	}
}
