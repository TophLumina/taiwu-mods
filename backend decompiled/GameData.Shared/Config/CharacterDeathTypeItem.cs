using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterDeathTypeItem : ConfigItem<CharacterDeathTypeItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short DefaultLifeRecord;

	public readonly short DefaultMonthlyNotification;

	public readonly bool NotifyTaiwuPeopleOnly;

	public readonly bool FindUndertaker;

	public CharacterDeathTypeItem(short templateId, string name, short defaultLifeRecord, short defaultMonthlyNotification, bool notifyTaiwuPeopleOnly, bool findUndertaker)
	{
		TemplateId = templateId;
		Name = name;
		DefaultLifeRecord = defaultLifeRecord;
		DefaultMonthlyNotification = defaultMonthlyNotification;
		NotifyTaiwuPeopleOnly = notifyTaiwuPeopleOnly;
		FindUndertaker = findUndertaker;
	}

	public CharacterDeathTypeItem()
	{
		TemplateId = 0;
		Name = null;
		DefaultLifeRecord = 0;
		DefaultMonthlyNotification = 0;
		NotifyTaiwuPeopleOnly = false;
		FindUndertaker = false;
	}

	public CharacterDeathTypeItem(short templateId, CharacterDeathTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		DefaultLifeRecord = other.DefaultLifeRecord;
		DefaultMonthlyNotification = other.DefaultMonthlyNotification;
		NotifyTaiwuPeopleOnly = other.NotifyTaiwuPeopleOnly;
		FindUndertaker = other.FindUndertaker;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterDeathTypeItem Duplicate(int templateId)
	{
		return new CharacterDeathTypeItem((short)templateId, this);
	}
}
