using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class FeastItem : ConfigItem<FeastItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 条件说明
	/// </summary>
	public readonly string ConditionDesc;

	/// <summary>
	/// 效果说明
	/// </summary>
	public readonly string EffectDesc;

	/// <summary>
	/// 优先级
	/// </summary>
	public readonly int Priority;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EFeastType Type;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 心情
	/// </summary>
	public readonly int HappinessPercent;

	/// <summary>
	/// 好感
	/// </summary>
	public readonly int FavorPercent;

	/// <summary>
	/// 回礼品级增幅
	/// </summary>
	public readonly sbyte GiftBonus;

	/// <summary>
	/// 历练
	/// - 好感度增加值的百分比
	/// </summary>
	public readonly int ExpPercent;

	/// <summary>
	/// 对随机宴会上角色的好感增加
	/// - 好感度增加值的百分比
	/// </summary>
	public readonly int OtherFavorPercent;

	/// <summary>
	/// 研读功法书籍效率
	/// - 心情增加值的百分比
	/// </summary>
	public readonly int ReadCombatSkillBook;

	/// <summary>
	/// 研读技艺书籍效率
	/// - 心情增加值的百分比
	/// </summary>
	public readonly int ReadLifeSkillBook;

	/// <summary>
	/// 周天运转效率
	/// - 心情增加值的百分比
	/// </summary>
	public readonly int Loop;

	/// <summary>
	/// 无视厌恶
	/// </summary>
	public readonly bool IgnoreHate;

	/// <summary>
	/// 强制喜爱
	/// </summary>
	public readonly bool ForceLove;

	/// <summary>
	/// 需求物品类型
	/// </summary>
	public readonly List<EFeastRequirementType> RequirementType;

	/// <summary>
	/// 需求物品数据
	/// - 数量，等级
	/// </summary>
	public readonly List<int[]> RequirementData;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="conditionDesc">条件说明</param>
	/// <param name="effectDesc">效果说明</param>
	/// <param name="priority">优先级</param>
	/// <param name="type">类型</param>
	/// <param name="icon">图标</param>
	/// <param name="happinessPercent">心情</param>
	/// <param name="favorPercent">好感</param>
	/// <param name="giftBonus">回礼品级增幅</param>
	/// <param name="expPercent">历练 - 好感度增加值的百分比</param>
	/// <param name="otherFavorPercent">对随机宴会上角色的好感增加 - 好感度增加值的百分比</param>
	/// <param name="readCombatSkillBook">研读功法书籍效率 - 心情增加值的百分比</param>
	/// <param name="readLifeSkillBook">研读技艺书籍效率 - 心情增加值的百分比</param>
	/// <param name="loop">周天运转效率 - 心情增加值的百分比</param>
	/// <param name="ignoreHate">无视厌恶</param>
	/// <param name="forceLove">强制喜爱</param>
	/// <param name="requirementType">需求物品类型</param>
	/// <param name="requirementData">需求物品数据 - 数量，等级</param>
	public FeastItem(short templateId, string name, string desc, string conditionDesc, string effectDesc, int priority, EFeastType type, string icon, int happinessPercent, int favorPercent, sbyte giftBonus, int expPercent, int otherFavorPercent, int readCombatSkillBook, int readLifeSkillBook, int loop, bool ignoreHate, bool forceLove, List<EFeastRequirementType> requirementType, List<int[]> requirementData)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ConditionDesc = conditionDesc;
		EffectDesc = effectDesc;
		Priority = priority;
		Type = type;
		Icon = icon;
		HappinessPercent = happinessPercent;
		FavorPercent = favorPercent;
		GiftBonus = giftBonus;
		ExpPercent = expPercent;
		OtherFavorPercent = otherFavorPercent;
		ReadCombatSkillBook = readCombatSkillBook;
		ReadLifeSkillBook = readLifeSkillBook;
		Loop = loop;
		IgnoreHate = ignoreHate;
		ForceLove = forceLove;
		RequirementType = requirementType;
		RequirementData = requirementData;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public FeastItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ConditionDesc = null;
		EffectDesc = null;
		Priority = 0;
		Type = EFeastType.Invalid;
		Icon = null;
		HappinessPercent = 0;
		FavorPercent = 0;
		GiftBonus = 0;
		ExpPercent = 0;
		OtherFavorPercent = 0;
		ReadCombatSkillBook = 0;
		ReadLifeSkillBook = 0;
		Loop = 0;
		IgnoreHate = false;
		ForceLove = false;
		RequirementType = null;
		RequirementData = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public FeastItem(short templateId, FeastItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		ConditionDesc = other.ConditionDesc;
		EffectDesc = other.EffectDesc;
		Priority = other.Priority;
		Type = other.Type;
		Icon = other.Icon;
		HappinessPercent = other.HappinessPercent;
		FavorPercent = other.FavorPercent;
		GiftBonus = other.GiftBonus;
		ExpPercent = other.ExpPercent;
		OtherFavorPercent = other.OtherFavorPercent;
		ReadCombatSkillBook = other.ReadCombatSkillBook;
		ReadLifeSkillBook = other.ReadLifeSkillBook;
		Loop = other.Loop;
		IgnoreHate = other.IgnoreHate;
		ForceLove = other.ForceLove;
		RequirementType = other.RequirementType;
		RequirementData = other.RequirementData;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override FeastItem Duplicate(int templateId)
	{
		return new FeastItem((short)templateId, this);
	}
}
