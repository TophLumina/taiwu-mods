using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TravelingEventItem : ConfigItem<TravelingEventItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 显示类型
	/// </summary>
	public readonly ETravelingEventDisplayType DisplayType;

	/// <summary>
	/// 分类
	/// </summary>
	public readonly ETravelingEventType Type;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 州域
	/// - 输入-1时，表示不限定州域；
	/// </summary>
	public readonly sbyte StateTemplateId;

	/// <summary>
	/// 触发类型
	/// - 与区域处于特定关系时才会触发
	/// </summary>
	public readonly ETravelingEventTriggerType TriggerType;

	/// <summary>
	/// 触发区域类型
	/// - 对于特定区域类型才会触发
	/// </summary>
	public readonly ETravelingEventTriggerAreaType TriggerAreaType;

	/// <summary>
	/// 关联组织
	/// </summary>
	public readonly sbyte OrgTemplateId;

	/// <summary>
	/// 是否唯一
	/// - 唯一旅行事件只会触发一次
	/// </summary>
	public readonly bool IsUnique;

	/// <summary>
	/// 优先级
	/// - 当同时满足触发条件时，该列数值最大的优先触发，如果存在并列，则从中随机抽选
	/// </summary>
	public readonly sbyte OccurOrder;

	/// <summary>
	/// 概率
	/// - 路过每个对应地区，事件发生的基础概率（若同时受名誉/七元/好感影响，则表示名誉/七元/好感最高时的概率），填10意为10%
	/// </summary>
	public readonly sbyte OccurRate;

	/// <summary>
	/// 名誉影响
	/// - 事件发生概率受玩家名誉影响；1：需要玩家名誉为正，名誉越高概率越大；-1：需要玩家名誉为负，名誉越低概率越大；即【实际概率=OccurRate*（±1）*玩家对应名誉数值/100】，0 表示名誉不影响概率
	/// </summary>
	public readonly sbyte FameMultiplier;

	/// <summary>
	/// 名誉范围
	/// </summary>
	public readonly sbyte[] FameLimit;

	/// <summary>
	/// 七元
	/// - 若触发概率受七元影响，视为对应七元达到50时为满概率，其他正常折算，即【实际概率=OccurRate*玩家对应七元数值/50】
	/// </summary>
	public readonly sbyte NeedPersonality;

	/// <summary>
	/// 事件
	/// - 事件id；若不填写，则为通知类，仅出现提示和标记，单独列出，不会触发对话框事件；其他为可触发事件：1.大部分事件可忽略，忽略则不消耗时间；2.战斗类和载具耐久即时触发，不可跳过；
	/// </summary>
	public readonly string Event;

	/// <summary>
	/// 耗时
	/// - 事件中可能消耗的时间点，用于计算事件能否发生，消耗主要在事件中消耗
	/// </summary>
	public readonly sbyte NeedTime;

	/// <summary>
	/// 数值范围
	/// - 如果该事件有随机值则以此为取值范围，两边都包含
	/// </summary>
	public readonly int[] ValueRange;

	/// <summary>
	/// 属性类型
	/// - 该事件关联的角色属性
	/// </summary>
	public readonly short CharacterProperty;

	/// <summary>
	/// 道具筛选类型
	/// - 从人物背包中筛选道具时要求的类型
	/// </summary>
	public readonly sbyte FilterItemType;

	/// <summary>
	/// 道具筛选范围
	/// - 同ItemFilterRules中规则，先定位到道具，以该道具顺次的几个皆在范围内
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> ItemRange;

	/// <summary>
	/// 道具品质权重
	/// - 道具类，为各品质道具的出现权重；
	/// </summary>
	public readonly short[] ItemGradeWeight;

	/// <summary>
	/// 资源类型权重
	/// - 资源类，为{食材，木材，金铁，玉石，织物，药材，银钱，威望，历练} 各类资源出现的几率
	/// </summary>
	public readonly short[] ResourceWeights;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="displayType">显示类型</param>
	/// <param name="type">分类</param>
	/// <param name="desc">描述</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
	/// <param name="stateTemplateId">州域 - 输入-1时，表示不限定州域；</param>
	/// <param name="triggerType">触发类型 - 与区域处于特定关系时才会触发</param>
	/// <param name="triggerAreaType">触发区域类型 - 对于特定区域类型才会触发</param>
	/// <param name="orgTemplateId">关联组织</param>
	/// <param name="isUnique">是否唯一 - 唯一旅行事件只会触发一次</param>
	/// <param name="occurOrder">优先级 - 当同时满足触发条件时，该列数值最大的优先触发，如果存在并列，则从中随机抽选</param>
	/// <param name="occurRate">概率 - 路过每个对应地区，事件发生的基础概率（若同时受名誉/七元/好感影响，则表示名誉/七元/好感最高时的概率），填10意为10%</param>
	/// <param name="fameMultiplier">名誉影响 - 事件发生概率受玩家名誉影响；1：需要玩家名誉为正，名誉越高概率越大；-1：需要玩家名誉为负，名誉越低概率越大；即【实际概率=OccurRate*（±1）*玩家对应名誉数值/100】，0 表示名誉不影响概率</param>
	/// <param name="fameLimit">名誉范围</param>
	/// <param name="needPersonality">七元 - 若触发概率受七元影响，视为对应七元达到50时为满概率，其他正常折算，即【实际概率=OccurRate*玩家对应七元数值/50】</param>
	/// <param name="stringEvent">事件 - 事件id；若不填写，则为通知类，仅出现提示和标记，单独列出，不会触发对话框事件；其他为可触发事件：1.大部分事件可忽略，忽略则不消耗时间；2.战斗类和载具耐久即时触发，不可跳过；</param>
	/// <param name="needTime">耗时 - 事件中可能消耗的时间点，用于计算事件能否发生，消耗主要在事件中消耗</param>
	/// <param name="valueRange">数值范围 - 如果该事件有随机值则以此为取值范围，两边都包含</param>
	/// <param name="characterProperty">属性类型 - 该事件关联的角色属性</param>
	/// <param name="filterItemType">道具筛选类型 - 从人物背包中筛选道具时要求的类型</param>
	/// <param name="itemRange">道具筛选范围 - 同ItemFilterRules中规则，先定位到道具，以该道具顺次的几个皆在范围内</param>
	/// <param name="itemGradeWeight">道具品质权重 - 道具类，为各品质道具的出现权重；</param>
	/// <param name="resourceWeights">资源类型权重 - 资源类，为{食材，木材，金铁，玉石，织物，药材，银钱，威望，历练} 各类资源出现的几率</param>
	public TravelingEventItem(short templateId, string name, ETravelingEventDisplayType displayType, ETravelingEventType type, string desc, string[] parameters, sbyte stateTemplateId, ETravelingEventTriggerType triggerType, ETravelingEventTriggerAreaType triggerAreaType, sbyte orgTemplateId, bool isUnique, sbyte occurOrder, sbyte occurRate, sbyte fameMultiplier, sbyte[] fameLimit, sbyte needPersonality, string stringEvent, sbyte needTime, int[] valueRange, short characterProperty, sbyte filterItemType, List<PresetItemTemplateIdGroup> itemRange, short[] itemGradeWeight, short[] resourceWeights)
	{
		TemplateId = templateId;
		Name = name;
		DisplayType = displayType;
		Type = type;
		Desc = desc;
		Parameters = parameters;
		StateTemplateId = stateTemplateId;
		TriggerType = triggerType;
		TriggerAreaType = triggerAreaType;
		OrgTemplateId = orgTemplateId;
		IsUnique = isUnique;
		OccurOrder = occurOrder;
		OccurRate = occurRate;
		FameMultiplier = fameMultiplier;
		FameLimit = fameLimit;
		NeedPersonality = needPersonality;
		Event = stringEvent;
		NeedTime = needTime;
		ValueRange = valueRange;
		CharacterProperty = characterProperty;
		FilterItemType = filterItemType;
		ItemRange = itemRange;
		ItemGradeWeight = itemGradeWeight;
		ResourceWeights = resourceWeights;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TravelingEventItem()
	{
		TemplateId = 0;
		Name = null;
		DisplayType = ETravelingEventDisplayType.TravelingEvent_0;
		Type = ETravelingEventType.Invalid;
		Desc = null;
		Parameters = new string[5] { "", "", "", "", "" };
		StateTemplateId = 0;
		TriggerType = ETravelingEventTriggerType.Invalid;
		TriggerAreaType = ETravelingEventTriggerAreaType.Invalid;
		OrgTemplateId = 0;
		IsUnique = false;
		OccurOrder = 0;
		OccurRate = 0;
		FameMultiplier = 0;
		FameLimit = new sbyte[2] { -100, 100 };
		NeedPersonality = -1;
		Event = null;
		NeedTime = 0;
		ValueRange = null;
		CharacterProperty = 0;
		FilterItemType = -1;
		ItemRange = new List<PresetItemTemplateIdGroup>();
		ItemGradeWeight = null;
		ResourceWeights = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TravelingEventItem(short templateId, TravelingEventItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		DisplayType = other.DisplayType;
		Type = other.Type;
		Desc = other.Desc;
		Parameters = other.Parameters;
		StateTemplateId = other.StateTemplateId;
		TriggerType = other.TriggerType;
		TriggerAreaType = other.TriggerAreaType;
		OrgTemplateId = other.OrgTemplateId;
		IsUnique = other.IsUnique;
		OccurOrder = other.OccurOrder;
		OccurRate = other.OccurRate;
		FameMultiplier = other.FameMultiplier;
		FameLimit = other.FameLimit;
		NeedPersonality = other.NeedPersonality;
		Event = other.Event;
		NeedTime = other.NeedTime;
		ValueRange = other.ValueRange;
		CharacterProperty = other.CharacterProperty;
		FilterItemType = other.FilterItemType;
		ItemRange = other.ItemRange;
		ItemGradeWeight = other.ItemGradeWeight;
		ResourceWeights = other.ResourceWeights;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TravelingEventItem Duplicate(int templateId)
	{
		return new TravelingEventItem((short)templateId, this);
	}
}
