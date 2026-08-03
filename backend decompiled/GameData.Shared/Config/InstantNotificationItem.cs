using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InstantNotificationItem : ConfigItem<InstantNotificationItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 分类
	/// </summary>
	public readonly EInstantNotificationType Type;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 重要度
	/// - 0: 低, 1: 中, 2: 高
	/// </summary>
	public readonly sbyte Importance;

	/// <summary>
	/// 概述
	/// </summary>
	public readonly string SimpleDesc;

	/// <summary>
	/// 详细描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 允许通过指令添加
	/// </summary>
	public readonly bool AllowByEventFunction;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 可合并参数
	/// - 如果有多条通知, 则合并成一条. 为 null 表示不合并. 不为 null 时, 集合中的元素表示需要合并的参数的索引, 集合外的元素表示需要 "对比多条消息然后判断哪些消息需要合并" 的参数的索引.
	/// </summary>
	public readonly List<sbyte> MergeableParameters;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">分类</param>
	/// <param name="name">名称</param>
	/// <param name="importance">重要度 - 0: 低, 1: 中, 2: 高</param>
	/// <param name="simpleDesc">概述</param>
	/// <param name="desc">详细描述</param>
	/// <param name="allowByEventFunction">允许通过指令添加</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
	/// <param name="mergeableParameters">可合并参数 - 如果有多条通知, 则合并成一条. 为 null 表示不合并. 不为 null 时, 集合中的元素表示需要合并的参数的索引, 集合外的元素表示需要 "对比多条消息然后判断哪些消息需要合并" 的参数的索引.</param>
	public InstantNotificationItem(short templateId, EInstantNotificationType type, string name, sbyte importance, string simpleDesc, string desc, bool allowByEventFunction, string[] parameters, List<sbyte> mergeableParameters)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Importance = importance;
		SimpleDesc = simpleDesc;
		Desc = desc;
		AllowByEventFunction = allowByEventFunction;
		Parameters = parameters;
		MergeableParameters = mergeableParameters;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InstantNotificationItem()
	{
		TemplateId = 0;
		Type = EInstantNotificationType.TaiwuVillage;
		Name = null;
		Importance = 0;
		SimpleDesc = null;
		Desc = null;
		AllowByEventFunction = false;
		Parameters = new string[4] { "", "", "", "" };
		MergeableParameters = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InstantNotificationItem(short templateId, InstantNotificationItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Importance = other.Importance;
		SimpleDesc = other.SimpleDesc;
		Desc = other.Desc;
		AllowByEventFunction = other.AllowByEventFunction;
		Parameters = other.Parameters;
		MergeableParameters = other.MergeableParameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override InstantNotificationItem Duplicate(int templateId)
	{
		return new InstantNotificationItem((short)templateId, this);
	}
}
