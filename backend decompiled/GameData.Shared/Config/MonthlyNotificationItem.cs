using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MonthlyNotificationItem : ConfigItem<MonthlyNotificationItem, short>
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
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

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
	/// 月报隶属板块
	/// - 若为空，则代表不属于任何一个版块；若存在数据，则根据如下标准判定属于哪个版块（太吾札记：太吾札记、太吾札记：太吾札记、太吾村志：太吾村志、天下风云：天下风云）
	/// </summary>
	public readonly EMonthlyNotificationSectionType SectionType;

	/// <summary>
	/// 显示格数大小
	/// - 显示为1格与1/4格大小，1/4格默认排在所有1格通知之后（0为默认1格大小，1为默认1/4格大小，2为根据公式计算重要度）
	/// </summary>
	public readonly sbyte DisplaySize;

	/// <summary>
	/// 设置分组
	/// - 未设置分组参数的，不显示在设置面板
	/// </summary>
	public readonly short SortingGroup;

	/// <summary>
	/// 查值参数
	/// - 合并时需要保证值也相同的参数，为null时表示不需要检查参数值
	/// </summary>
	public readonly List<sbyte> ValueCheckParameters;

	/// <summary>
	/// 合并数量上限
	/// - 参数合并的数量上限，超过后触发特殊处理，即可能存在的不同格式的合并替换文本
	/// </summary>
	public readonly int MergeLimit;

	/// <summary>
	/// 合并替换文本
	/// - 合并数量超过上限后使用的替换文本
	/// </summary>
	public readonly string MergeDesc;

	/// <summary>
	/// 合并替换文本类型
	/// - 若合并后的替换文本格式发生改变，使用合并的类型。0为不特殊处理，1为增加数量参数，2为模糊化处理， 3为同名去重
	/// </summary>
	public readonly sbyte MergeType;

	/// <summary>
	/// 重要程度
	/// </summary>
	public readonly int Priority;

	/// <summary>
	/// 能否上首页
	/// </summary>
	public readonly bool CanFirstPage;

	/// <summary>
	/// 首页图片
	/// </summary>
	public readonly string FirstPageBg;

	/// <summary>
	/// 允许通过指令添加
	/// </summary>
	public readonly bool AllowByEventFunction;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="icon">图标</param>
	/// <param name="desc">描述</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
	/// <param name="mergeableParameters">可合并参数 - 如果有多条通知, 则合并成一条. 为 null 表示不合并. 不为 null 时, 集合中的元素表示需要合并的参数的索引, 集合外的元素表示需要 "对比多条消息然后判断哪些消息需要合并" 的参数的索引.</param>
	/// <param name="sectionType">月报隶属板块 - 若为空，则代表不属于任何一个版块；若存在数据，则根据如下标准判定属于哪个版块（太吾札记：太吾札记、太吾札记：太吾札记、太吾村志：太吾村志、天下风云：天下风云）</param>
	/// <param name="displaySize">显示格数大小 - 显示为1格与1/4格大小，1/4格默认排在所有1格通知之后（0为默认1格大小，1为默认1/4格大小，2为根据公式计算重要度）</param>
	/// <param name="sortingGroup">设置分组 - 未设置分组参数的，不显示在设置面板</param>
	/// <param name="valueCheckParameters">查值参数 - 合并时需要保证值也相同的参数，为null时表示不需要检查参数值</param>
	/// <param name="mergeLimit">合并数量上限 - 参数合并的数量上限，超过后触发特殊处理，即可能存在的不同格式的合并替换文本</param>
	/// <param name="mergeDesc">合并替换文本 - 合并数量超过上限后使用的替换文本</param>
	/// <param name="mergeType">合并替换文本类型 - 若合并后的替换文本格式发生改变，使用合并的类型。0为不特殊处理，1为增加数量参数，2为模糊化处理， 3为同名去重</param>
	/// <param name="priority">重要程度</param>
	/// <param name="canFirstPage">能否上首页</param>
	/// <param name="firstPageBg">首页图片</param>
	/// <param name="allowByEventFunction">允许通过指令添加</param>
	public MonthlyNotificationItem(short templateId, string name, string icon, string desc, string[] parameters, List<sbyte> mergeableParameters, EMonthlyNotificationSectionType sectionType, sbyte displaySize, short sortingGroup, List<sbyte> valueCheckParameters, int mergeLimit, string mergeDesc, sbyte mergeType, int priority, bool canFirstPage, string firstPageBg, bool allowByEventFunction)
	{
		TemplateId = templateId;
		Name = name;
		Icon = icon;
		Desc = desc;
		Parameters = parameters;
		MergeableParameters = mergeableParameters;
		SectionType = sectionType;
		DisplaySize = displaySize;
		SortingGroup = sortingGroup;
		ValueCheckParameters = valueCheckParameters;
		MergeLimit = mergeLimit;
		MergeDesc = mergeDesc;
		MergeType = mergeType;
		Priority = priority;
		CanFirstPage = canFirstPage;
		FirstPageBg = firstPageBg;
		AllowByEventFunction = allowByEventFunction;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MonthlyNotificationItem()
	{
		TemplateId = 0;
		Name = null;
		Icon = null;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
		MergeableParameters = null;
		SectionType = EMonthlyNotificationSectionType.None;
		DisplaySize = 0;
		SortingGroup = 0;
		ValueCheckParameters = null;
		MergeLimit = -1;
		MergeDesc = null;
		MergeType = 0;
		Priority = 0;
		CanFirstPage = false;
		FirstPageBg = null;
		AllowByEventFunction = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MonthlyNotificationItem(short templateId, MonthlyNotificationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Icon = other.Icon;
		Desc = other.Desc;
		Parameters = other.Parameters;
		MergeableParameters = other.MergeableParameters;
		SectionType = other.SectionType;
		DisplaySize = other.DisplaySize;
		SortingGroup = other.SortingGroup;
		ValueCheckParameters = other.ValueCheckParameters;
		MergeLimit = other.MergeLimit;
		MergeDesc = other.MergeDesc;
		MergeType = other.MergeType;
		Priority = other.Priority;
		CanFirstPage = other.CanFirstPage;
		FirstPageBg = other.FirstPageBg;
		AllowByEventFunction = other.AllowByEventFunction;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MonthlyNotificationItem Duplicate(int templateId)
	{
		return new MonthlyNotificationItem((short)templateId, this);
	}
}
