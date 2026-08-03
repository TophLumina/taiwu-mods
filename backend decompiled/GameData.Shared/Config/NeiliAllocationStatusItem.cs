using System;
using Config.Common;

namespace Config;

[Serializable]
public class NeiliAllocationStatusItem : ConfigItem<NeiliAllocationStatusItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 类型
	/// - 此项需与 TemplateId 逐一对应，由程序维护相关功能
	/// </summary>
	public readonly ENeiliAllocationStatusType Type;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明（Tips描述）
	/// </summary>
	public readonly string[] Desc;

	/// <summary>
	/// 最小百分比（不含）
	/// - 相较于真气初始值的人物当前真气的百分比，必须配置为 0~300 的连续区间
	/// </summary>
	public readonly int MinThreshold;

	/// <summary>
	/// 最大百分比（含）
	/// </summary>
	public readonly int MaxThreshold;

	/// <summary>
	/// 允许等于最小百分比
	/// </summary>
	public readonly bool AllowEqualsMin;

	/// <summary>
	/// 反噬几率
	/// - 与真气类型对应的功法发生反噬的几率百分比，C类
	/// </summary>
	public readonly int GoneMadInjuryRate;

	/// <summary>
	/// 反噬伤害
	/// - 与真气类型对应的功法发生反噬的伤害的百分比，C类
	/// </summary>
	public readonly int GoneMadInjuryBonus;

	/// <summary>
	/// 功法威力
	/// - 影响功法威力的百分比，B类
	/// </summary>
	public readonly int PowerAddPercent;

	/// <summary>
	/// 真气损耗
	/// - 以百分比的形式影响真气的减少量，B类
	/// </summary>
	public readonly int CostNeiliAllocation;

	/// <summary>
	/// 真气增加
	/// - 以百分比的形式影响真气的增加量，B类
	/// </summary>
	public readonly int AddNeiliAllocation;

	/// <summary>
	/// 真气标记数
	/// - 负数使用溃散样式，正数使用暴涨样式，绝对值代表标记数
	/// </summary>
	public readonly sbyte MarkCount;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">类型 - 此项需与 TemplateId 逐一对应，由程序维护相关功能</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明（Tips描述）</param>
	/// <param name="minThreshold">最小百分比（不含） - 相较于真气初始值的人物当前真气的百分比，必须配置为 0~300 的连续区间</param>
	/// <param name="maxThreshold">最大百分比（含）</param>
	/// <param name="allowEqualsMin">允许等于最小百分比</param>
	/// <param name="goneMadInjuryRate">反噬几率 - 与真气类型对应的功法发生反噬的几率百分比，C类</param>
	/// <param name="goneMadInjuryBonus">反噬伤害 - 与真气类型对应的功法发生反噬的伤害的百分比，C类</param>
	/// <param name="powerAddPercent">功法威力 - 影响功法威力的百分比，B类</param>
	/// <param name="costNeiliAllocation">真气损耗 - 以百分比的形式影响真气的减少量，B类</param>
	/// <param name="addNeiliAllocation">真气增加 - 以百分比的形式影响真气的增加量，B类</param>
	/// <param name="markCount">真气标记数 - 负数使用溃散样式，正数使用暴涨样式，绝对值代表标记数</param>
	public NeiliAllocationStatusItem(sbyte templateId, ENeiliAllocationStatusType type, string name, string[] desc, int minThreshold, int maxThreshold, bool allowEqualsMin, int goneMadInjuryRate, int goneMadInjuryBonus, int powerAddPercent, int costNeiliAllocation, int addNeiliAllocation, sbyte markCount)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		MinThreshold = minThreshold;
		MaxThreshold = maxThreshold;
		AllowEqualsMin = allowEqualsMin;
		GoneMadInjuryRate = goneMadInjuryRate;
		GoneMadInjuryBonus = goneMadInjuryBonus;
		PowerAddPercent = powerAddPercent;
		CostNeiliAllocation = costNeiliAllocation;
		AddNeiliAllocation = addNeiliAllocation;
		MarkCount = markCount;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public NeiliAllocationStatusItem()
	{
		TemplateId = 0;
		Type = ENeiliAllocationStatusType.Scatter;
		Name = null;
		Desc = null;
		MinThreshold = 0;
		MaxThreshold = 0;
		AllowEqualsMin = false;
		GoneMadInjuryRate = 0;
		GoneMadInjuryBonus = 0;
		PowerAddPercent = 0;
		CostNeiliAllocation = 0;
		AddNeiliAllocation = 0;
		MarkCount = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public NeiliAllocationStatusItem(sbyte templateId, NeiliAllocationStatusItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		MinThreshold = other.MinThreshold;
		MaxThreshold = other.MaxThreshold;
		AllowEqualsMin = other.AllowEqualsMin;
		GoneMadInjuryRate = other.GoneMadInjuryRate;
		GoneMadInjuryBonus = other.GoneMadInjuryBonus;
		PowerAddPercent = other.PowerAddPercent;
		CostNeiliAllocation = other.CostNeiliAllocation;
		AddNeiliAllocation = other.AddNeiliAllocation;
		MarkCount = other.MarkCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override NeiliAllocationStatusItem Duplicate(int templateId)
	{
		return new NeiliAllocationStatusItem((sbyte)templateId, this);
	}
}
