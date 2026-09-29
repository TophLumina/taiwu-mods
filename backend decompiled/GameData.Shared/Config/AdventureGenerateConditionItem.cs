using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureGenerateConditionItem : ConfigItem<AdventureGenerateConditionItem, int>
{
	public readonly int TemplateId;

	public readonly int TargetId;

	public readonly bool ForceDisable;

	public readonly List<sbyte> EnterMonthList;

	public readonly int MaxCountInArea;

	public readonly int MaxCountInWorld;

	public readonly int MaxCountInMonth;

	public readonly int[] StateWeights;

	public readonly int[] AreaWeights;

	public readonly EMapBlockType[] IncludeTypes;

	public readonly sbyte PreparationDuration;

	public readonly sbyte MinInterval;

	public readonly short ActiveNotification;

	public readonly short PrepareNotification;

	public AdventureGenerateConditionItem(int templateId, int targetId, bool forceDisable, List<sbyte> enterMonthList, int maxCountInArea, int maxCountInWorld, int maxCountInMonth, int[] stateWeights, int[] areaWeights, EMapBlockType[] includeTypes, sbyte preparationDuration, sbyte minInterval, short activeNotification, short prepareNotification)
	{
		TemplateId = templateId;
		TargetId = targetId;
		ForceDisable = forceDisable;
		EnterMonthList = enterMonthList;
		MaxCountInArea = maxCountInArea;
		MaxCountInWorld = maxCountInWorld;
		MaxCountInMonth = maxCountInMonth;
		StateWeights = stateWeights;
		AreaWeights = areaWeights;
		IncludeTypes = includeTypes;
		PreparationDuration = preparationDuration;
		MinInterval = minInterval;
		ActiveNotification = activeNotification;
		PrepareNotification = prepareNotification;
	}

	public AdventureGenerateConditionItem()
	{
		TemplateId = 0;
		TargetId = 0;
		ForceDisable = false;
		EnterMonthList = new List<sbyte>();
		MaxCountInArea = -1;
		MaxCountInWorld = -1;
		MaxCountInMonth = 1;
		StateWeights = null;
		AreaWeights = null;
		IncludeTypes = new EMapBlockType[0];
		PreparationDuration = 3;
		MinInterval = 3;
		ActiveNotification = 0;
		PrepareNotification = 0;
	}

	public AdventureGenerateConditionItem(int templateId, AdventureGenerateConditionItem other)
	{
		TemplateId = templateId;
		TargetId = other.TargetId;
		ForceDisable = other.ForceDisable;
		EnterMonthList = other.EnterMonthList;
		MaxCountInArea = other.MaxCountInArea;
		MaxCountInWorld = other.MaxCountInWorld;
		MaxCountInMonth = other.MaxCountInMonth;
		StateWeights = other.StateWeights;
		AreaWeights = other.AreaWeights;
		IncludeTypes = other.IncludeTypes;
		PreparationDuration = other.PreparationDuration;
		MinInterval = other.MinInterval;
		ActiveNotification = other.ActiveNotification;
		PrepareNotification = other.PrepareNotification;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureGenerateConditionItem Duplicate(int templateId)
	{
		return new AdventureGenerateConditionItem(templateId, this);
	}
}
