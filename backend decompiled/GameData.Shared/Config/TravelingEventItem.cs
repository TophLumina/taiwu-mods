using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TravelingEventItem : ConfigItem<TravelingEventItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly ETravelingEventDisplayType DisplayType;

	public readonly ETravelingEventType Type;

	public readonly string Desc;

	public readonly string[] Parameters;

	public readonly sbyte StateTemplateId;

	public readonly ETravelingEventTriggerType TriggerType;

	public readonly ETravelingEventTriggerAreaType TriggerAreaType;

	public readonly sbyte OrgTemplateId;

	public readonly bool IsUnique;

	public readonly sbyte OccurOrder;

	public readonly sbyte OccurRate;

	public readonly sbyte FameMultiplier;

	public readonly sbyte[] FameLimit;

	public readonly sbyte NeedPersonality;

	public readonly string Event;

	public readonly sbyte NeedTime;

	public readonly int[] ValueRange;

	public readonly short CharacterProperty;

	public readonly sbyte FilterItemType;

	public readonly List<PresetItemTemplateIdGroup> ItemRange;

	public readonly short[] ItemGradeWeight;

	public readonly short[] ResourceWeights;

	public MapStateItem StateTemplate
	{
		[return: MaybeNull]
		get
		{
			return MapState.Instance.GetItemOrDefault(StateTemplateId);
		}
	}

	public OrganizationItem OrgTemplate
	{
		[return: MaybeNull]
		get
		{
			return Organization.Instance.GetItemOrDefault(OrgTemplateId);
		}
	}

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

	public override TravelingEventItem Duplicate(int templateId)
	{
		return new TravelingEventItem((short)templateId, this);
	}
}
