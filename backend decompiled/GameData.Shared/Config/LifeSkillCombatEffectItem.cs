using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillCombatEffectItem : ConfigItem<LifeSkillCombatEffectItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 基础数目
	/// </summary>
	public readonly sbyte BaseAmount;

	/// <summary>
	/// 最大数目
	/// </summary>
	public readonly sbyte MaxAmount;

	/// <summary>
	/// 初始卡组数目
	/// </summary>
	public readonly sbyte UsedCount;

	/// <summary>
	/// 等级
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly ELifeSkillCombatEffectType Type;

	/// <summary>
	/// 分组
	/// </summary>
	public readonly ELifeSkillCombatEffectGroup Group;

	/// <summary>
	/// 是否即时
	/// </summary>
	public readonly bool IsInstant;

	/// <summary>
	/// 是否选中格子
	/// </summary>
	public readonly bool IsSelectGrid;

	/// <summary>
	/// 是否选中书籍
	/// </summary>
	public readonly bool IsSelectBook;

	/// <summary>
	/// 是否存储卡牌
	/// </summary>
	public readonly bool IsSaveCard;

	/// <summary>
	/// 落子是否添加常驻特效
	/// </summary>
	public readonly bool IsDecideAddEffect;

	/// <summary>
	/// 化为论点是否增加常驻特效
	/// </summary>
	public readonly bool IsGetPointAddEffect;

	/// <summary>
	/// 选中或使用后禁止的卡牌
	/// </summary>
	public readonly List<sbyte> BanCardList;

	/// <summary>
	/// 立场影响数目
	/// - 刚正~唯我
	/// </summary>
	public readonly sbyte[] BehaviorTypeAmounts;

	/// <summary>
	/// 七元影响几率
	/// - 冷静~坚毅
	/// </summary>
	public readonly sbyte[] PersonalityTypeRate;

	/// <summary>
	/// 子效果
	/// </summary>
	public readonly ELifeSkillCombatEffectSubEffect SubEffect;

	/// <summary>
	/// 子效果参数
	/// </summary>
	public readonly sbyte[] SubEffectParameters;

	/// <summary>
	/// 插画
	/// </summary>
	public readonly string Imgae;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="baseAmount">基础数目</param>
	/// <param name="maxAmount">最大数目</param>
	/// <param name="usedCount">初始卡组数目</param>
	/// <param name="level">等级</param>
	/// <param name="type">类型</param>
	/// <param name="group">分组</param>
	/// <param name="isInstant">是否即时</param>
	/// <param name="isSelectGrid">是否选中格子</param>
	/// <param name="isSelectBook">是否选中书籍</param>
	/// <param name="isSaveCard">是否存储卡牌</param>
	/// <param name="isDecideAddEffect">落子是否添加常驻特效</param>
	/// <param name="isGetPointAddEffect">化为论点是否增加常驻特效</param>
	/// <param name="banCardList">选中或使用后禁止的卡牌</param>
	/// <param name="behaviorTypeAmounts">立场影响数目 - 刚正~唯我</param>
	/// <param name="personalityTypeRate">七元影响几率 - 冷静~坚毅</param>
	/// <param name="subEffect">子效果</param>
	/// <param name="subEffectParameters">子效果参数</param>
	/// <param name="imgae">插画</param>
	public LifeSkillCombatEffectItem(sbyte templateId, string name, string desc, sbyte baseAmount, sbyte maxAmount, sbyte usedCount, sbyte level, ELifeSkillCombatEffectType type, ELifeSkillCombatEffectGroup group, bool isInstant, bool isSelectGrid, bool isSelectBook, bool isSaveCard, bool isDecideAddEffect, bool isGetPointAddEffect, List<sbyte> banCardList, sbyte[] behaviorTypeAmounts, sbyte[] personalityTypeRate, ELifeSkillCombatEffectSubEffect subEffect, sbyte[] subEffectParameters, string imgae)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		BaseAmount = baseAmount;
		MaxAmount = maxAmount;
		UsedCount = usedCount;
		Level = level;
		Type = type;
		Group = group;
		IsInstant = isInstant;
		IsSelectGrid = isSelectGrid;
		IsSelectBook = isSelectBook;
		IsSaveCard = isSaveCard;
		IsDecideAddEffect = isDecideAddEffect;
		IsGetPointAddEffect = isGetPointAddEffect;
		BanCardList = banCardList;
		BehaviorTypeAmounts = behaviorTypeAmounts;
		PersonalityTypeRate = personalityTypeRate;
		SubEffect = subEffect;
		SubEffectParameters = subEffectParameters;
		Imgae = imgae;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LifeSkillCombatEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		BaseAmount = 0;
		MaxAmount = 0;
		UsedCount = 0;
		Level = 0;
		Type = ELifeSkillCombatEffectType.Common;
		Group = ELifeSkillCombatEffectGroup.FlexibleFall;
		IsInstant = false;
		IsSelectGrid = false;
		IsSelectBook = false;
		IsSaveCard = false;
		IsDecideAddEffect = false;
		IsGetPointAddEffect = false;
		BanCardList = null;
		BehaviorTypeAmounts = null;
		PersonalityTypeRate = new sbyte[5];
		SubEffect = ELifeSkillCombatEffectSubEffect.SelfExtraQuestionAroundHouseThesisLow;
		SubEffectParameters = null;
		Imgae = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LifeSkillCombatEffectItem(sbyte templateId, LifeSkillCombatEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		BaseAmount = other.BaseAmount;
		MaxAmount = other.MaxAmount;
		UsedCount = other.UsedCount;
		Level = other.Level;
		Type = other.Type;
		Group = other.Group;
		IsInstant = other.IsInstant;
		IsSelectGrid = other.IsSelectGrid;
		IsSelectBook = other.IsSelectBook;
		IsSaveCard = other.IsSaveCard;
		IsDecideAddEffect = other.IsDecideAddEffect;
		IsGetPointAddEffect = other.IsGetPointAddEffect;
		BanCardList = other.BanCardList;
		BehaviorTypeAmounts = other.BehaviorTypeAmounts;
		PersonalityTypeRate = other.PersonalityTypeRate;
		SubEffect = other.SubEffect;
		SubEffectParameters = other.SubEffectParameters;
		Imgae = other.Imgae;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LifeSkillCombatEffectItem Duplicate(int templateId)
	{
		return new LifeSkillCombatEffectItem((sbyte)templateId, this);
	}
}
