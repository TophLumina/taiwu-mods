using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class DebateNodeEffectItem : ConfigItem<DebateNodeEffectItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string BubbleContent;

	public readonly sbyte BehaviorType;

	public readonly short DebateRecord;

	public readonly List<IntPair> InstantEffectList;

	public readonly List<IntPair> TriggerEffectList;

	public readonly List<IntPair> SpecialEffectList;

	public readonly int Cooldown;

	public readonly int Duration;

	public readonly List<EDebateNodeEffectRemoveType> RemoveType;

	public readonly string LoopSound;

	public readonly string TriggerSound;

	public readonly string ExtraTriggerSound;

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

	public override DebateNodeEffectItem Duplicate(int templateId)
	{
		return new DebateNodeEffectItem((short)templateId, this);
	}
}
