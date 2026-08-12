using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionSkillItem : ConfigItem<ProfessionSkillItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 技能名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 立即结算
	/// - 立即触发确认窗口，且没有任何事件
	/// </summary>
	public readonly bool Instant;

	/// <summary>
	/// 所属志向
	/// </summary>
	public readonly int Profession;

	/// <summary>
	/// 技能图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 技能大图标
	/// </summary>
	public readonly string BigIcon;

	/// <summary>
	/// 技能说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 技能功能说明
	/// </summary>
	public readonly string FunctionalDesc;

	/// <summary>
	/// 级别
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 关联的角色属性
	/// </summary>
	public readonly short CharacterProperty;

	/// <summary>
	/// 触发类型
	/// - 通过点击技能直接触发为主动，通过事件窗口触发则为互动
	/// </summary>
	public readonly EProfessionSkillTriggerType TriggerType;

	/// <summary>
	/// 忽略条件检定
	/// - 按钮交互性忽略技能释放条件检定
	/// </summary>
	public readonly bool IgnoreCanExecuteSkill;

	/// <summary>
	/// 结算类型
	/// - 通过事件结算则为互动
	/// </summary>
	public readonly EProfessionSkillType Type;

	/// <summary>
	/// 技能冷却
	/// - 按过月次数计算
	/// </summary>
	public readonly short SkillCoolDown;

	/// <summary>
	/// 时间消耗
	/// - 单位天数
	/// </summary>
	public readonly short TimeCost;

	/// <summary>
	/// 等技能完成才消耗时间
	/// - 用于富商二技能，要先完成，再消耗时间，否则商队会移动导致技能无效
	/// </summary>
	public readonly bool CostTimeWhenFinished;

	/// <summary>
	/// 解锁资历
	/// - 解锁时需要的资历百分比
	/// </summary>
	public readonly short UnlockSeniority;

	/// <summary>
	/// 资历获取
	/// - 最大10000
	/// </summary>
	public readonly short Exp;

	/// <summary>
	/// 失败资历获取
	/// - 技能使用失败资历获取，最大10000
	/// </summary>
	public readonly short FailExp;

	/// <summary>
	/// 消耗历练
	/// </summary>
	public readonly int ExpCost;

	/// <summary>
	/// 消耗资源
	/// - 格式为{资源类型,需求数量}，资源类型对应ResourceType表中的模板ID
	/// </summary>
	public readonly List<ResourceInfo> ResourcesCost;

	/// <summary>
	/// 要求目标对太吾的好感
	/// </summary>
	public readonly short RequiredFavorability;

	/// <summary>
	/// 技能解锁描述
	/// - 播放技能解锁动画时的文本
	/// </summary>
	public readonly string SkillUnlockDesc;

	/// <summary>
	/// 技能解锁说明
	/// - 播放技能解锁动画时的说明
	/// </summary>
	public readonly string SkillUnlockExplain;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">技能名称</param>
	/// <param name="instant">立即结算 - 立即触发确认窗口，且没有任何事件</param>
	/// <param name="profession">所属志向</param>
	/// <param name="icon">技能图标</param>
	/// <param name="bigIcon">技能大图标</param>
	/// <param name="desc">技能说明</param>
	/// <param name="functionalDesc">技能功能说明</param>
	/// <param name="level">级别</param>
	/// <param name="characterProperty">关联的角色属性</param>
	/// <param name="triggerType">触发类型 - 通过点击技能直接触发为主动，通过事件窗口触发则为互动</param>
	/// <param name="ignoreCanExecuteSkill">忽略条件检定 - 按钮交互性忽略技能释放条件检定</param>
	/// <param name="type">结算类型 - 通过事件结算则为互动</param>
	/// <param name="skillCoolDown">技能冷却 - 按过月次数计算</param>
	/// <param name="timeCost">时间消耗 - 单位天数</param>
	/// <param name="costTimeWhenFinished">等技能完成才消耗时间 - 用于富商二技能，要先完成，再消耗时间，否则商队会移动导致技能无效</param>
	/// <param name="unlockSeniority">解锁资历 - 解锁时需要的资历百分比</param>
	/// <param name="exp">资历获取 - 最大10000</param>
	/// <param name="failExp">失败资历获取 - 技能使用失败资历获取，最大10000</param>
	/// <param name="expCost">消耗历练</param>
	/// <param name="resourcesCost">消耗资源 - 格式为{资源类型,需求数量}，资源类型对应ResourceType表中的模板ID</param>
	/// <param name="requiredFavorability">要求目标对太吾的好感</param>
	/// <param name="skillUnlockDesc">技能解锁描述 - 播放技能解锁动画时的文本</param>
	/// <param name="skillUnlockExplain">技能解锁说明 - 播放技能解锁动画时的说明</param>
	public ProfessionSkillItem(int templateId, string name, bool instant, int profession, string icon, string bigIcon, string desc, string functionalDesc, sbyte level, short characterProperty, EProfessionSkillTriggerType triggerType, bool ignoreCanExecuteSkill, EProfessionSkillType type, short skillCoolDown, short timeCost, bool costTimeWhenFinished, short unlockSeniority, short exp, short failExp, int expCost, List<ResourceInfo> resourcesCost, short requiredFavorability, string skillUnlockDesc, string skillUnlockExplain)
	{
		TemplateId = templateId;
		Name = name;
		Instant = instant;
		Profession = profession;
		Icon = icon;
		BigIcon = bigIcon;
		Desc = desc;
		FunctionalDesc = functionalDesc;
		Level = level;
		CharacterProperty = characterProperty;
		TriggerType = triggerType;
		IgnoreCanExecuteSkill = ignoreCanExecuteSkill;
		Type = type;
		SkillCoolDown = skillCoolDown;
		TimeCost = timeCost;
		CostTimeWhenFinished = costTimeWhenFinished;
		UnlockSeniority = unlockSeniority;
		Exp = exp;
		FailExp = failExp;
		ExpCost = expCost;
		ResourcesCost = resourcesCost;
		RequiredFavorability = requiredFavorability;
		SkillUnlockDesc = skillUnlockDesc;
		SkillUnlockExplain = skillUnlockExplain;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ProfessionSkillItem()
	{
		TemplateId = 0;
		Name = null;
		Instant = false;
		Profession = 0;
		Icon = null;
		BigIcon = null;
		Desc = null;
		FunctionalDesc = null;
		Level = 0;
		CharacterProperty = 0;
		TriggerType = EProfessionSkillTriggerType.Invalid;
		IgnoreCanExecuteSkill = false;
		Type = EProfessionSkillType.Invalid;
		SkillCoolDown = 0;
		TimeCost = 0;
		CostTimeWhenFinished = false;
		UnlockSeniority = 0;
		Exp = 0;
		FailExp = 0;
		ExpCost = 0;
		ResourcesCost = new List<ResourceInfo>();
		RequiredFavorability = 0;
		SkillUnlockDesc = null;
		SkillUnlockExplain = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ProfessionSkillItem(int templateId, ProfessionSkillItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Instant = other.Instant;
		Profession = other.Profession;
		Icon = other.Icon;
		BigIcon = other.BigIcon;
		Desc = other.Desc;
		FunctionalDesc = other.FunctionalDesc;
		Level = other.Level;
		CharacterProperty = other.CharacterProperty;
		TriggerType = other.TriggerType;
		IgnoreCanExecuteSkill = other.IgnoreCanExecuteSkill;
		Type = other.Type;
		SkillCoolDown = other.SkillCoolDown;
		TimeCost = other.TimeCost;
		CostTimeWhenFinished = other.CostTimeWhenFinished;
		UnlockSeniority = other.UnlockSeniority;
		Exp = other.Exp;
		FailExp = other.FailExp;
		ExpCost = other.ExpCost;
		ResourcesCost = other.ResourcesCost;
		RequiredFavorability = other.RequiredFavorability;
		SkillUnlockDesc = other.SkillUnlockDesc;
		SkillUnlockExplain = other.SkillUnlockExplain;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ProfessionSkillItem Duplicate(int templateId)
	{
		return new ProfessionSkillItem(templateId, this);
	}
}
