using System;
using Config.Common;

namespace Config;

[Serializable]
public class DevelopmentTeamItem : ConfigItem<DevelopmentTeamItem, short>
{
	public readonly short TemplateId;

	public readonly string Title;

	public readonly string[] TeamInfo;

	public DevelopmentTeamItem(short templateId, string title, string[] teamInfo)
	{
		TemplateId = templateId;
		Title = title;
		TeamInfo = teamInfo;
	}

	public DevelopmentTeamItem()
	{
		TemplateId = 0;
		Title = null;
		TeamInfo = null;
	}

	public DevelopmentTeamItem(short templateId, DevelopmentTeamItem other)
	{
		TemplateId = templateId;
		Title = other.Title;
		TeamInfo = other.TeamInfo;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DevelopmentTeamItem Duplicate(int templateId)
	{
		return new DevelopmentTeamItem((short)templateId, this);
	}
}
