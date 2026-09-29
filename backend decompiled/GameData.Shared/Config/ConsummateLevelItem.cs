using System;
using Config.Common;

namespace Config;

[Serializable]
public class ConsummateLevelItem : ConfigItem<ConsummateLevelItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly sbyte Grade;

	public readonly int MaxNeiliAllocation;

	public readonly int DamageAddPercent;

	public readonly int DamageDecPercent;

	public readonly int MindDamageStepAddPercent;

	public readonly int FatalDamageStepAddPercent;

	public readonly int LoopingNeiliBonus;

	public readonly int LoopingNeiliAllocationBonus;

	public readonly int ExpBonus;

	public readonly int AddBreakSuccessRate;

	public readonly int AddBreakStepCount;

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

	public override ConsummateLevelItem Duplicate(int templateId)
	{
		return new ConsummateLevelItem((sbyte)templateId, this);
	}
}
