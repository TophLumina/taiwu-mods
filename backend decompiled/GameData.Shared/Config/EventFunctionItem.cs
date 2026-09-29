using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventFunctionItem : ConfigItem<EventFunctionItem, int>
{
	public readonly int TemplateId;

	public readonly EEventFunctionType Type;

	public readonly string Name;

	public readonly string Desc;

	public readonly int[] ParameterTypes;

	public readonly string[] ParameterNames;

	public readonly int ReturnValue;

	public readonly bool IndentNext;

	public readonly int FollowUp;

	public readonly bool CanCreateManually;

	public readonly List<int> RequiredPreviousCommands;

	public readonly bool AllowedInCondition;

	public readonly bool IsTransition;

	public readonly bool AllowExternalUsage;

	public readonly string InGameHint;

	public EventFunctionItem(int templateId, EEventFunctionType type, string name, string desc, int[] parameterTypes, string[] parameterNames, int returnValue, bool indentNext, int followUp, bool canCreateManually, List<int> requiredPreviousCommands, bool allowedInCondition, bool isTransition, bool allowExternalUsage, string inGameHint)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		ParameterTypes = parameterTypes;
		ParameterNames = parameterNames;
		ReturnValue = returnValue;
		IndentNext = indentNext;
		FollowUp = followUp;
		CanCreateManually = canCreateManually;
		RequiredPreviousCommands = requiredPreviousCommands;
		AllowedInCondition = allowedInCondition;
		IsTransition = isTransition;
		AllowExternalUsage = allowExternalUsage;
		InGameHint = inGameHint;
	}

	public EventFunctionItem()
	{
		TemplateId = 0;
		Type = EEventFunctionType.Invalid;
		Name = null;
		Desc = null;
		ParameterTypes = new int[0];
		ParameterNames = new string[0];
		ReturnValue = 0;
		IndentNext = false;
		FollowUp = 0;
		CanCreateManually = true;
		RequiredPreviousCommands = new List<int>();
		AllowedInCondition = false;
		IsTransition = false;
		AllowExternalUsage = true;
		InGameHint = null;
	}

	public EventFunctionItem(int templateId, EventFunctionItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		ParameterTypes = other.ParameterTypes;
		ParameterNames = other.ParameterNames;
		ReturnValue = other.ReturnValue;
		IndentNext = other.IndentNext;
		FollowUp = other.FollowUp;
		CanCreateManually = other.CanCreateManually;
		RequiredPreviousCommands = other.RequiredPreviousCommands;
		AllowedInCondition = other.AllowedInCondition;
		IsTransition = other.IsTransition;
		AllowExternalUsage = other.AllowExternalUsage;
		InGameHint = other.InGameHint;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventFunctionItem Duplicate(int templateId)
	{
		return new EventFunctionItem(templateId, this);
	}
}
