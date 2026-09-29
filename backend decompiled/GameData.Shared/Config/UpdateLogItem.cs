using System;
using Config.Common;

namespace Config;

[Serializable]
public class UpdateLogItem : ConfigItem<UpdateLogItem, byte>
{
	public readonly byte TemplateId;

	public readonly sbyte IncrementSortOrder;

	public readonly string VersionTagBackground;

	public readonly string VersionTagIcon;

	public readonly string VersionTitle;

	public readonly string VersionPublishDate;

	public readonly string OfficialLink;

	public readonly string[] SubentryTitles;

	public readonly string[] SubentryIcons;

	public readonly string[] SubentryDescriptions;

	public readonly string SubentryTitleIcon;

	public UpdateLogItem(byte templateId, sbyte incrementSortOrder, string versionTagBackground, string versionTagIcon, string versionTitle, string versionPublishDate, string officialLink, string[] subentryTitles, string[] subentryIcons, string[] subentryDescriptions, string subentryTitleIcon)
	{
		TemplateId = templateId;
		IncrementSortOrder = incrementSortOrder;
		VersionTagBackground = versionTagBackground;
		VersionTagIcon = versionTagIcon;
		VersionTitle = versionTitle;
		VersionPublishDate = versionPublishDate;
		OfficialLink = officialLink;
		SubentryTitles = subentryTitles;
		SubentryIcons = subentryIcons;
		SubentryDescriptions = subentryDescriptions;
		SubentryTitleIcon = subentryTitleIcon;
	}

	public UpdateLogItem()
	{
		TemplateId = 0;
		IncrementSortOrder = 0;
		VersionTagBackground = null;
		VersionTagIcon = null;
		VersionTitle = null;
		VersionPublishDate = null;
		OfficialLink = null;
		SubentryTitles = null;
		SubentryIcons = null;
		SubentryDescriptions = null;
		SubentryTitleIcon = null;
	}

	public UpdateLogItem(byte templateId, UpdateLogItem other)
	{
		TemplateId = templateId;
		IncrementSortOrder = other.IncrementSortOrder;
		VersionTagBackground = other.VersionTagBackground;
		VersionTagIcon = other.VersionTagIcon;
		VersionTitle = other.VersionTitle;
		VersionPublishDate = other.VersionPublishDate;
		OfficialLink = other.OfficialLink;
		SubentryTitles = other.SubentryTitles;
		SubentryIcons = other.SubentryIcons;
		SubentryDescriptions = other.SubentryDescriptions;
		SubentryTitleIcon = other.SubentryTitleIcon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override UpdateLogItem Duplicate(int templateId)
	{
		return new UpdateLogItem((byte)templateId, this);
	}
}
