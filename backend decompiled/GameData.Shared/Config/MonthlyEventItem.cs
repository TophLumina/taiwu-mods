using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MonthlyEventItem : ConfigItem<MonthlyEventItem, short>
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
	/// 分类
	/// </summary>
	public readonly EMonthlyEventType Type;

	/// <summary>
	/// 事件
	/// </summary>
	public readonly string Event;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数6" 共 7 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 可合并参数
	/// - 如果有多条通知, 则合并成一条. 为 null 表示不合并. 不为 null 时, 集合中的元素表示需要合并的参数的索引, 集合外的元素表示需要 "对比多条消息然后判断哪些消息需要合并" 的参数的索引.
	/// </summary>
	public readonly List<sbyte> MergeableParameters;

	/// <summary>
	/// 占分
	/// - 用于特殊事件消减, 每次过月时特殊事件占分综合不会超过15分, 优先添加高分事件
	/// </summary>
	public readonly int Score;

	/// <summary>
	/// 节点
	/// - 0为过月，1为月中
	/// </summary>
	public readonly bool Node;

	/// <summary>
	/// 自动触发概率
	/// - 过月时会自动触发, 自动触发的事件不能有参数.
	/// </summary>
	public readonly int AutoTriggerChance;

	/// <summary>
	/// 自动触发频率
	/// - 必须在配置了自动触发概率的情况下才会生效
	/// </summary>
	public readonly int AutoTriggerInterval;

	/// <summary>
	/// 自动触发参数
	/// - 自动触发时填充的参数, 通常为全局参数盒子的Key, RoleTaiwu 为太吾人物, TaiwuLocation 为太吾当前位置.
	/// </summary>
	public readonly string[] AutoTriggerArguments;

	/// <summary>
	/// 允许通过指令添加
	/// </summary>
	public readonly bool AllowByEventFunction;

	/// <summary>
	/// 允许奇遇中触发
	/// </summary>
	public readonly bool AllowInAdventure;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="type">分类</param>
	/// <param name="stringEvent">事件</param>
	/// <param name="icon">图标</param>
	/// <param name="desc">描述</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数6" 共 7 个字段.</param>
	/// <param name="mergeableParameters">可合并参数 - 如果有多条通知, 则合并成一条. 为 null 表示不合并. 不为 null 时, 集合中的元素表示需要合并的参数的索引, 集合外的元素表示需要 "对比多条消息然后判断哪些消息需要合并" 的参数的索引.</param>
	/// <param name="score">占分 - 用于特殊事件消减, 每次过月时特殊事件占分综合不会超过15分, 优先添加高分事件</param>
	/// <param name="node">节点 - 0为过月，1为月中</param>
	/// <param name="autoTriggerChance">自动触发概率 - 过月时会自动触发, 自动触发的事件不能有参数.</param>
	/// <param name="autoTriggerInterval">自动触发频率 - 必须在配置了自动触发概率的情况下才会生效</param>
	/// <param name="autoTriggerArguments">自动触发参数 - 自动触发时填充的参数, 通常为全局参数盒子的Key, RoleTaiwu 为太吾人物, TaiwuLocation 为太吾当前位置.</param>
	/// <param name="allowByEventFunction">允许通过指令添加</param>
	/// <param name="allowInAdventure">允许奇遇中触发</param>
	public MonthlyEventItem(short templateId, string name, EMonthlyEventType type, string stringEvent, string icon, string desc, string[] parameters, List<sbyte> mergeableParameters, int score, bool node, int autoTriggerChance, int autoTriggerInterval, string[] autoTriggerArguments, bool allowByEventFunction, bool allowInAdventure)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Event = stringEvent;
		Icon = icon;
		Desc = desc;
		Parameters = parameters;
		MergeableParameters = mergeableParameters;
		Score = score;
		Node = node;
		AutoTriggerChance = autoTriggerChance;
		AutoTriggerInterval = autoTriggerInterval;
		AutoTriggerArguments = autoTriggerArguments;
		AllowByEventFunction = allowByEventFunction;
		AllowInAdventure = allowInAdventure;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MonthlyEventItem()
	{
		TemplateId = 0;
		Name = null;
		Type = EMonthlyEventType.Invalid;
		Event = null;
		Icon = null;
		Desc = null;
		Parameters = new string[7] { "", "", "", "", "", "", "" };
		MergeableParameters = null;
		Score = 0;
		Node = false;
		AutoTriggerChance = 0;
		AutoTriggerInterval = 0;
		AutoTriggerArguments = null;
		AllowByEventFunction = false;
		AllowInAdventure = true;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MonthlyEventItem(short templateId, MonthlyEventItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Event = other.Event;
		Icon = other.Icon;
		Desc = other.Desc;
		Parameters = other.Parameters;
		MergeableParameters = other.MergeableParameters;
		Score = other.Score;
		Node = other.Node;
		AutoTriggerChance = other.AutoTriggerChance;
		AutoTriggerInterval = other.AutoTriggerInterval;
		AutoTriggerArguments = other.AutoTriggerArguments;
		AllowByEventFunction = other.AllowByEventFunction;
		AllowInAdventure = other.AllowInAdventure;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MonthlyEventItem Duplicate(int templateId)
	{
		return new MonthlyEventItem((short)templateId, this);
	}
}
