using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MonthlyEventItem : ConfigItem<MonthlyEventItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly EMonthlyEventType Type;

	public readonly string Event;

	public readonly string Icon;

	public readonly string Desc;

	public readonly string[] Parameters;

	public readonly List<sbyte> MergeableParameters;

	public readonly int Score;

	public readonly bool Node;

	public readonly int AutoTriggerChance;

	public readonly int AutoTriggerInterval;

	public readonly string[] AutoTriggerArguments;

	public readonly bool AllowByEventFunction;

	public readonly bool AllowInAdventure;

	public readonly uint DlcAppId;

	public MonthlyEventItem(short templateId, string name, EMonthlyEventType type, string stringEvent, string icon, string desc, string[] parameters, List<sbyte> mergeableParameters, int score, bool node, int autoTriggerChance, int autoTriggerInterval, string[] autoTriggerArguments, bool allowByEventFunction, bool allowInAdventure, uint dlcAppId)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Event = stringEvent;
		Icon = icon;
		Desc = desc;
		Parameters = parameters;
		MergeableParameters = mergeableParameters;
		Score = score;
		Node = node;
		AutoTriggerChance = autoTriggerChance;
		AutoTriggerInterval = autoTriggerInterval;
		AutoTriggerArguments = autoTriggerArguments;
		AllowByEventFunction = allowByEventFunction;
		AllowInAdventure = allowInAdventure;
		DlcAppId = dlcAppId;
	}

	public MonthlyEventItem()
	{
		TemplateId = 0;
		Name = null;
		Type = EMonthlyEventType.Invalid;
		Event = null;
		Icon = null;
		Desc = null;
		Parameters = new string[7] { "", "", "", "", "", "", "" };
		MergeableParameters = null;
		Score = 0;
		Node = false;
		AutoTriggerChance = 0;
		AutoTriggerInterval = 0;
		AutoTriggerArguments = null;
		AllowByEventFunction = false;
		AllowInAdventure = true;
		DlcAppId = 0u;
	}

	public MonthlyEventItem(short templateId, MonthlyEventItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Event = other.Event;
		Icon = other.Icon;
		Desc = other.Desc;
		Parameters = other.Parameters;
		MergeableParameters = other.MergeableParameters;
		Score = other.Score;
		Node = other.Node;
		AutoTriggerChance = other.AutoTriggerChance;
		AutoTriggerInterval = other.AutoTriggerInterval;
		AutoTriggerArguments = other.AutoTriggerArguments;
		AllowByEventFunction = other.AllowByEventFunction;
		AllowInAdventure = other.AllowInAdventure;
		DlcAppId = other.DlcAppId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MonthlyEventItem Duplicate(int templateId)
	{
		return new MonthlyEventItem((short)templateId, this);
	}
}
