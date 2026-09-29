using System;
using Config.Common;

namespace Config;

[Serializable]
public class BecomeEnemyTypeItem : ConfigItem<BecomeEnemyTypeItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short DefaultLifeRecord;

	public readonly short DefaultMonthlyNotification;

	public readonly bool NotifyTaiwuPeopleOnly;

	public BecomeEnemyTypeItem(short templateId, string name, short defaultLifeRecord, short defaultMonthlyNotification, bool notifyTaiwuPeopleOnly)
	{
		TemplateId = templateId;
		Name = name;
		DefaultLifeRecord = defaultLifeRecord;
		DefaultMonthlyNotification = defaultMonthlyNotification;
		NotifyTaiwuPeopleOnly = notifyTaiwuPeopleOnly;
	}

	public BecomeEnemyTypeItem()
	{
		TemplateId = 0;
		Name = null;
		DefaultLifeRecord = 0;
		DefaultMonthlyNotification = 0;
		NotifyTaiwuPeopleOnly = false;
	}

	public BecomeEnemyTypeItem(short templateId, BecomeEnemyTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		DefaultLifeRecord = other.DefaultLifeRecord;
		DefaultMonthlyNotification = other.DefaultMonthlyNotification;
		NotifyTaiwuPeopleOnly = other.NotifyTaiwuPeopleOnly;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override BecomeEnemyTypeItem Duplicate(int templateId)
	{
		return new BecomeEnemyTypeItem((short)templateId, this);
	}
}
