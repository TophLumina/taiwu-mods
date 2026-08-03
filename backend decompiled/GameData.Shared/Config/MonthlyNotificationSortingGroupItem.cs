using System;
using Config.Common;

namespace Config;

[Serializable]
public class MonthlyNotificationSortingGroupItem : ConfigItem<MonthlyNotificationSortingGroupItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 显示排序
	/// - 以序号从低到高显示，如排序序号相同，则按配置表中的顺序排序
	/// </summary>
	public readonly int Priority;

	/// <summary>
	/// 可关注
	/// - 在事件回顾界面，是否可置顶此过月通知
	/// </summary>
	public readonly bool OnTop;

	/// <summary>
	/// 可屏蔽
	/// - 在事件回顾界面，是否可不显示此过月通知
	/// </summary>
	public readonly bool Hidden;

	/// <summary>
	/// 所属DLC
	/// - 必须存在对应的dlc才会出现
	/// </summary>
	public readonly uint DlcAppId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="priority">显示排序 - 以序号从低到高显示，如排序序号相同，则按配置表中的顺序排序</param>
	/// <param name="onTop">可关注 - 在事件回顾界面，是否可置顶此过月通知</param>
	/// <param name="hidden">可屏蔽 - 在事件回顾界面，是否可不显示此过月通知</param>
	/// <param name="dlcAppId">所属DLC - 必须存在对应的dlc才会出现</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MonthlyNotificationSortingGroupItem Duplicate(int templateId)
	{
		return new MonthlyNotificationSortingGroupItem((short)templateId, this);
	}
}
