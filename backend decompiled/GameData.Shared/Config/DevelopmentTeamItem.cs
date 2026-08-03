using System;
using Config.Common;

namespace Config;

[Serializable]
public class DevelopmentTeamItem : ConfigItem<DevelopmentTeamItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 标题
	/// </summary>
	public readonly string Title;

	/// <summary>
	/// 人员信息
	/// </summary>
	public readonly string[] TeamInfo;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="title">标题</param>
	/// <param name="teamInfo">人员信息</param>
	public DevelopmentTeamItem(short templateId, string title, string[] teamInfo)
	{
		TemplateId = templateId;
		Title = title;
		TeamInfo = teamInfo;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DevelopmentTeamItem()
	{
		TemplateId = 0;
		Title = null;
		TeamInfo = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DevelopmentTeamItem Duplicate(int templateId)
	{
		return new DevelopmentTeamItem((short)templateId, this);
	}
}
