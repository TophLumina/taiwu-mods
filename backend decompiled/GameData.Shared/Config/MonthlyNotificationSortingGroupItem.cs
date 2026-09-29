using System;
using Config.Common;

namespace Config;

[Serializable]
public class MonthlyNotificationSortingGroupItem : ConfigItem<MonthlyNotificationSortingGroupItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly int Priority;

	public readonly bool OnTop;

	public readonly bool Hidden;

	public readonly uint DlcAppId;

	public MonthlyNotificationSortingGroupItem(short templateId, string name, string desc, int priority, bool onTop, bool hidden, uint dlcAppId)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Priority = priority;
		OnTop = onTop;
		Hidden = hidden;
		DlcAppId = dlcAppId;
	}

	public MonthlyNotificationSortingGroupItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Priority = 0;
		OnTop = true;
		Hidden = true;
		DlcAppId = 0u;
	}

	public MonthlyNotificationSortingGroupItem(short templateId, MonthlyNotificationSortingGroupItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Priority = other.Priority;
		OnTop = other.OnTop;
		Hidden = other.Hidden;
		DlcAppId = other.DlcAppId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MonthlyNotificationSortingGroupItem Duplicate(int templateId)
	{
		return new MonthlyNotificationSortingGroupItem((short)templateId, this);
	}
}
