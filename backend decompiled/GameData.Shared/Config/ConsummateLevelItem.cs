using System;
using Config.Common;

namespace Config;

[Serializable]
public class ConsummateLevelItem : ConfigItem<ConsummateLevelItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 品阶
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 真气上限
	/// - 前端目前仍使用 20 * 精纯级别计算表现值，如需调整此列参数，应联系相关程序进行修改
	/// </summary>
	public readonly int MaxNeiliAllocation;

	/// <summary>
	/// 增伤百分比
	/// - 攻方精纯大于守方时，使用攻方配置值减去守方配置值
	/// </summary>
	public readonly int DamageAddPercent;

	/// <summary>
	/// 减伤百分比
	/// - 守方精纯大于攻方时，使用守方配置值减去攻方配置值
	/// </summary>
	public readonly int DamageDecPercent;

	/// <summary>
	/// 心神强健
	/// - 如有战斗中动态变化精纯的需求，应联系相关程序进行改动
	/// </summary>
	public readonly int MindDamageStepAddPercent;

	/// <summary>
	/// 重创强健
	/// </summary>
	public readonly int FatalDamageStepAddPercent;

	/// <summary>
	/// 周天内力获取
	/// </summary>
	public readonly int LoopingNeiliBonus;

	/// <summary>
	/// 周天真气获取
	/// </summary>
	public readonly int LoopingNeiliAllocationBonus;

	/// <summary>
	/// 战斗历练获取
	/// </summary>
	public readonly int ExpBonus;

	/// <summary>
	/// 突破成功率
	/// </summary>
	public readonly int AddBreakSuccessRate;

	/// <summary>
	/// 突破天资数
	/// </summary>
	public readonly int AddBreakStepCount;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="grade">品阶</param>
	/// <param name="maxNeiliAllocation">真气上限 - 前端目前仍使用 20 * 精纯级别计算表现值，如需调整此列参数，应联系相关程序进行修改</param>
	/// <param name="damageAddPercent">增伤百分比 - 攻方精纯大于守方时，使用攻方配置值减去守方配置值</param>
	/// <param name="damageDecPercent">减伤百分比 - 守方精纯大于攻方时，使用守方配置值减去攻方配置值</param>
	/// <param name="mindDamageStepAddPercent">心神强健 - 如有战斗中动态变化精纯的需求，应联系相关程序进行改动</param>
	/// <param name="fatalDamageStepAddPercent">重创强健</param>
	/// <param name="loopingNeiliBonus">周天内力获取</param>
	/// <param name="loopingNeiliAllocationBonus">周天真气获取</param>
	/// <param name="expBonus">战斗历练获取</param>
	/// <param name="addBreakSuccessRate">突破成功率</param>
	/// <param name="addBreakStepCount">突破天资数</param>
	public ConsummateLevelItem(sbyte templateId, string name, string desc, sbyte grade, int maxNeiliAllocation, int damageAddPercent, int damageDecPercent, int mindDamageStepAddPercent, int fatalDamageStepAddPercent, int loopingNeiliBonus, int loopingNeiliAllocationBonus, int expBonus, int addBreakSuccessRate, int addBreakStepCount)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Grade = grade;
		MaxNeiliAllocation = maxNeiliAllocation;
		DamageAddPercent = damageAddPercent;
		DamageDecPercent = damageDecPercent;
		MindDamageStepAddPercent = mindDamageStepAddPercent;
		FatalDamageStepAddPercent = fatalDamageStepAddPercent;
		LoopingNeiliBonus = loopingNeiliBonus;
		LoopingNeiliAllocationBonus = loopingNeiliAllocationBonus;
		ExpBonus = expBonus;
		AddBreakSuccessRate = addBreakSuccessRate;
		AddBreakStepCount = addBreakStepCount;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ConsummateLevelItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Grade = 0;
		MaxNeiliAllocation = 0;
		DamageAddPercent = 0;
		DamageDecPercent = 0;
		MindDamageStepAddPercent = 0;
		FatalDamageStepAddPercent = 0;
		LoopingNeiliBonus = 0;
		LoopingNeiliAllocationBonus = 0;
		ExpBonus = 0;
		AddBreakSuccessRate = 0;
		AddBreakStepCount = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ConsummateLevelItem(sbyte templateId, ConsummateLevelItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Grade = other.Grade;
		MaxNeiliAllocation = other.MaxNeiliAllocation;
		DamageAddPercent = other.DamageAddPercent;
		DamageDecPercent = other.DamageDecPercent;
		MindDamageStepAddPercent = other.MindDamageStepAddPercent;
		FatalDamageStepAddPercent = other.FatalDamageStepAddPercent;
		LoopingNeiliBonus = other.LoopingNeiliBonus;
		LoopingNeiliAllocationBonus = other.LoopingNeiliAllocationBonus;
		ExpBonus = other.ExpBonus;
		AddBreakSuccessRate = other.AddBreakSuccessRate;
		AddBreakStepCount = other.AddBreakStepCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ConsummateLevelItem Duplicate(int templateId)
	{
		return new ConsummateLevelItem((sbyte)templateId, this);
	}
}
