using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class DebateNodeEffectItem : ConfigItem<DebateNodeEffectItem, short>
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
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 台词
	/// </summary>
	public readonly string BubbleContent;

	/// <summary>
	/// 发表立场
	/// - 指定立场的角色才会进行该评价
	/// </summary>
	public readonly sbyte BehaviorType;

	/// <summary>
	/// 较艺记录
	/// </summary>
	public readonly short DebateRecord;

	/// <summary>
	/// 即时效果列表
	/// - 效果名,值
	/// </summary>
	public readonly List<IntPair> InstantEffectList;

	/// <summary>
	/// 触发效果列表
	/// - 效果名,值
	/// </summary>
	public readonly List<IntPair> TriggerEffectList;

	/// <summary>
	/// 特殊效果列表
	/// - 效果名,值
	/// </summary>
	public readonly List<IntPair> SpecialEffectList;

	/// <summary>
	/// 冷却时间
	/// </summary>
	public readonly int Cooldown;

	/// <summary>
	/// 持续时间
	/// </summary>
	public readonly int Duration;

	/// <summary>
	/// 移除类型
	/// </summary>
	public readonly List<EDebateNodeEffectRemoveType> RemoveType;

	/// <summary>
	/// 循环音效
	/// </summary>
	public readonly string LoopSound;

	/// <summary>
	/// 触发音效
	/// </summary>
	public readonly string TriggerSound;

	/// <summary>
	/// 额外触发音效
	/// </summary>
	public readonly string ExtraTriggerSound;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="bubbleContent">台词</param>
	/// <param name="behaviorType">发表立场 - 指定立场的角色才会进行该评价</param>
	/// <param name="debateRecord">较艺记录</param>
	/// <param name="instantEffectList">即时效果列表 - 效果名,值</param>
	/// <param name="triggerEffectList">触发效果列表 - 效果名,值</param>
	/// <param name="specialEffectList">特殊效果列表 - 效果名,值</param>
	/// <param name="cooldown">冷却时间</param>
	/// <param name="duration">持续时间</param>
	/// <param name="removeType">移除类型</param>
	/// <param name="loopSound">循环音效</param>
	/// <param name="triggerSound">触发音效</param>
	/// <param name="extraTriggerSound">额外触发音效</param>
	public DebateNodeEffectItem(short templateId, string name, string desc, string bubbleContent, sbyte behaviorType, short debateRecord, List<IntPair> instantEffectList, List<IntPair> triggerEffectList, List<IntPair> specialEffectList, int cooldown, int duration, List<EDebateNodeEffectRemoveType> removeType, string loopSound, string triggerSound, string extraTriggerSound)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		BubbleContent = bubbleContent;
		BehaviorType = behaviorType;
		DebateRecord = debateRecord;
		InstantEffectList = instantEffectList;
		TriggerEffectList = triggerEffectList;
		SpecialEffectList = specialEffectList;
		Cooldown = cooldown;
		Duration = duration;
		RemoveType = removeType;
		LoopSound = loopSound;
		TriggerSound = triggerSound;
		ExtraTriggerSound = extraTriggerSound;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateNodeEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		BubbleContent = null;
		BehaviorType = 0;
		DebateRecord = 0;
		InstantEffectList = null;
		TriggerEffectList = null;
		SpecialEffectList = null;
		Cooldown = 3;
		Duration = 3;
		RemoveType = null;
		LoopSound = null;
		TriggerSound = null;
		ExtraTriggerSound = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateNodeEffectItem(short templateId, DebateNodeEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		BubbleContent = other.BubbleContent;
		BehaviorType = other.BehaviorType;
		DebateRecord = other.DebateRecord;
		InstantEffectList = other.InstantEffectList;
		TriggerEffectList = other.TriggerEffectList;
		SpecialEffectList = other.SpecialEffectList;
		Cooldown = other.Cooldown;
		Duration = other.Duration;
		RemoveType = other.RemoveType;
		LoopSound = other.LoopSound;
		TriggerSound = other.TriggerSound;
		ExtraTriggerSound = other.ExtraTriggerSound;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DebateNodeEffectItem Duplicate(int templateId)
	{
		return new DebateNodeEffectItem((short)templateId, this);
	}
}
