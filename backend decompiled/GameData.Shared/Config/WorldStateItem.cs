using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldStateItem : ConfigItem<WorldStateItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public readonly string[] SectStoryCondition;

	public readonly string[] SectStoryConditionTaiwuAsXiangshu;

	public readonly sbyte Sect;

	public readonly short TriggerArea;

	public readonly short[] MonthlyEvents;

	public WorldStateItem(sbyte templateId, string name, string desc, string icon, string[] sectStoryCondition, string[] sectStoryConditionTaiwuAsXiangshu, sbyte sect, short triggerArea, short[] monthlyEvents)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		SectStoryCondition = sectStoryCondition;
		SectStoryConditionTaiwuAsXiangshu = sectStoryConditionTaiwuAsXiangshu;
		Sect = sect;
		TriggerArea = triggerArea;
		MonthlyEvents = monthlyEvents;
	}

	public WorldStateItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		SectStoryCondition = new string[0];
		SectStoryConditionTaiwuAsXiangshu = new string[0];
		Sect = 0;
		TriggerArea = 0;
		MonthlyEvents = null;
	}

	public WorldStateItem(sbyte templateId, WorldStateItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		SectStoryCondition = other.SectStoryCondition;
		SectStoryConditionTaiwuAsXiangshu = other.SectStoryConditionTaiwuAsXiangshu;
		Sect = other.Sect;
		TriggerArea = other.TriggerArea;
		MonthlyEvents = other.MonthlyEvents;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override WorldStateItem Duplicate(int templateId)
	{
		return new WorldStateItem((sbyte)templateId, this);
	}
}
