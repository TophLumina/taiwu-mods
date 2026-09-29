using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventScriptTypeItem : ConfigItem<EventScriptTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly bool IsConditionList;

	public readonly EEventScriptTypeSource Source;

	public EventScriptTypeItem(sbyte templateId, string name, bool isConditionList, EEventScriptTypeSource source)
	{
		TemplateId = templateId;
		Name = name;
		IsConditionList = isConditionList;
		Source = source;
	}

	public EventScriptTypeItem()
	{
		TemplateId = 0;
		Name = null;
		IsConditionList = false;
		Source = EEventScriptTypeSource.Global;
	}

	public EventScriptTypeItem(sbyte templateId, EventScriptTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IsConditionList = other.IsConditionList;
		Source = other.Source;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventScriptTypeItem Duplicate(int templateId)
	{
		return new EventScriptTypeItem((sbyte)templateId, this);
	}
}
