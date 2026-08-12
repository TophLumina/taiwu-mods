using System;
using Config.Common;

namespace Config;

[Serializable]
public class UpdateLogItem : ConfigItem<UpdateLogItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 显示排序
	/// - 数字越大的越靠前
	/// </summary>
	public readonly sbyte IncrementSortOrder;

	/// <summary>
	/// 版本页签背景
	/// </summary>
	public readonly string VersionTagBackground;

	/// <summary>
	/// 版本页签图标
	/// </summary>
	public readonly string VersionTagIcon;

	/// <summary>
	/// 版本页签标题
	/// </summary>
	public readonly string VersionTitle;

	/// <summary>
	/// 版本发布时间
	/// - ”[版本发布时间] [版本页签标题]版本”作为具体标题
	/// </summary>
	public readonly string VersionPublishDate;

	/// <summary>
	/// 跳转官网页面链接
	/// - 如当期更新无对应页面，则直接置入更新日志主链接
	/// </summary>
	public readonly string OfficialLink;

	/// <summary>
	/// 子条目标题
	/// </summary>
	public readonly string[] SubentryTitles;

	/// <summary>
	/// 子条目图片
	/// </summary>
	public readonly string[] SubentryIcons;

	/// <summary>
	/// 子条目描述
	/// </summary>
	public readonly string[] SubentryDescriptions;

	/// <summary>
	/// 子条目标题大图片
	/// </summary>
	public readonly string SubentryTitleIcon;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="incrementSortOrder">显示排序 - 数字越大的越靠前</param>
	/// <param name="versionTagBackground">版本页签背景</param>
	/// <param name="versionTagIcon">版本页签图标</param>
	/// <param name="versionTitle">版本页签标题</param>
	/// <param name="versionPublishDate">版本发布时间 - ”[版本发布时间] [版本页签标题]版本”作为具体标题</param>
	/// <param name="officialLink">跳转官网页面链接 - 如当期更新无对应页面，则直接置入更新日志主链接</param>
	/// <param name="subentryTitles">子条目标题</param>
	/// <param name="subentryIcons">子条目图片</param>
	/// <param name="subentryDescriptions">子条目描述</param>
	/// <param name="subentryTitleIcon">子条目标题大图片</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override UpdateLogItem Duplicate(int templateId)
	{
		return new UpdateLogItem((byte)templateId, this);
	}
}
