using System;
using Config.Common;

namespace Config;

[Serializable]
public class PersonalNeedItem : ConfigItem<PersonalNeedItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly bool MatchType;

	public readonly bool Overwrite;

	public readonly bool Combine;

	public readonly sbyte Duration;

	public PersonalNeedItem(sbyte templateId, string name, bool matchType, bool overwrite, bool combine, sbyte duration)
	{
		TemplateId = templateId;
		Name = name;
		MatchType = matchType;
		Overwrite = overwrite;
		Combine = combine;
		Duration = duration;
	}

	public PersonalNeedItem()
	{
		TemplateId = 0;
		Name = null;
		MatchType = false;
		Overwrite = false;
		Combine = false;
		Duration = 3;
	}

	public PersonalNeedItem(sbyte templateId, PersonalNeedItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		MatchType = other.MatchType;
		Overwrite = other.Overwrite;
		Combine = other.Combine;
		Duration = other.Duration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PersonalNeedItem Duplicate(int templateId)
	{
		return new PersonalNeedItem((sbyte)templateId, this);
	}
}
