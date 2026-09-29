using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerTypeItem : ConfigItem<EventTriggerTypeItem, int>
{
	public readonly int TemplateId;

	public readonly int[] Parameters;

	public readonly string KeyCode;

	public readonly bool CanTriggerInAdvanceMonth;

	public readonly bool CanTriggerInCombat;

	public readonly bool CanTriggerInCombatBegin;

	public readonly bool AllowExternal;

	public EventTriggerTypeItem(int templateId, int[] parameters, string keyCode, bool canTriggerInAdvanceMonth, bool canTriggerInCombat, bool canTriggerInCombatBegin, bool allowExternal)
	{
		TemplateId = templateId;
		Parameters = parameters;
		KeyCode = keyCode;
		CanTriggerInAdvanceMonth = canTriggerInAdvanceMonth;
		CanTriggerInCombat = canTriggerInCombat;
		CanTriggerInCombatBegin = canTriggerInCombatBegin;
		AllowExternal = allowExternal;
	}

	public EventTriggerTypeItem()
	{
		TemplateId = 0;
		Parameters = new int[0];
		KeyCode = null;
		CanTriggerInAdvanceMonth = false;
		CanTriggerInCombat = false;
		CanTriggerInCombatBegin = false;
		AllowExternal = true;
	}

	public EventTriggerTypeItem(int templateId, EventTriggerTypeItem other)
	{
		TemplateId = templateId;
		Parameters = other.Parameters;
		KeyCode = other.KeyCode;
		CanTriggerInAdvanceMonth = other.CanTriggerInAdvanceMonth;
		CanTriggerInCombat = other.CanTriggerInCombat;
		CanTriggerInCombatBegin = other.CanTriggerInCombatBegin;
		AllowExternal = other.AllowExternal;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventTriggerTypeItem Duplicate(int templateId)
	{
		return new EventTriggerTypeItem(templateId, this);
	}
}
