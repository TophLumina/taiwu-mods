using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

/// <summary>
/// 真气状态工具
/// </summary>
public static class NeiliAllocationStatusHelper
{
	/// <summary>
	/// 获取真气状态
	/// </summary>
	/// <param name="currentValue">当前真气值</param>
	/// <param name="originalValue">初始真气值</param>
	/// <returns></returns>
	public static ENeiliAllocationStatusType GetStatus(short currentValue, short originalValue)
	{
		if (originalValue == 0)
		{
			return ENeiliAllocationStatusType.None;
		}
		foreach (NeiliAllocationStatusItem status in (IEnumerable<NeiliAllocationStatusItem>)NeiliAllocationStatus.Instance)
		{
			int min = originalValue * status.MinThreshold / 100;
			int max = originalValue * status.MaxThreshold / 100;
			if ((currentValue > min || (currentValue == min && status.AllowEqualsMin)) && currentValue <= max)
			{
				return status.Type;
			}
		}
		return ENeiliAllocationStatusType.None;
	}

	/// <summary>
	/// 获取真气状态
	/// </summary>
	public static ENeiliAllocationStatusType GetStatus(this NeiliAllocation currentNeiliAllocation, NeiliAllocation originalNeiliAllocation, byte neiliAllocationType)
	{
		if (neiliAllocationType >= 4)
		{
			return ENeiliAllocationStatusType.None;
		}
		short currentValue = currentNeiliAllocation[neiliAllocationType];
		short originalValue = originalNeiliAllocation[neiliAllocationType];
		return GetStatus(currentValue, originalValue);
	}

	/// <summary>
	/// 获取真气状态配置
	/// </summary>
	public static NeiliAllocationStatusItem GetConfig(this ENeiliAllocationStatusType statusType)
	{
		return NeiliAllocationStatus.Instance[(int)statusType];
	}

	/// <summary>
	/// 获取关联的真气类型
	/// </summary>
	public static byte GetRelatedNeiliAllocationType(this CombatSkillItem combatSkillConfig)
	{
		return combatSkillConfig.EquipType switch
		{
			1 => 0, 
			2 => 1, 
			3 => 2, 
			4 => 3, 
			_ => 4, 
		};
	}

	/// <summary>
	/// 与指定真气类型关联
	/// </summary>
	public static bool IsRelated(this CombatSkillItem combatSkillConfig, byte neiliAllocationType)
	{
		return combatSkillConfig.GetRelatedNeiliAllocationType() == neiliAllocationType;
	}

	/// <summary>
	/// 获取角色指定真气的状态
	/// </summary>
	/// <returns></returns>
	public static ENeiliAllocationStatusType GetNeiliAllocationStatus(this ICombatCharacterBridge combatChar, byte neiliAllocationType)
	{
		NeiliAllocation neiliAllocation = combatChar.GetNeiliAllocation();
		NeiliAllocation originalNeiliAllocation = combatChar.GetOriginNeiliAllocation();
		return neiliAllocation.GetStatus(originalNeiliAllocation, neiliAllocationType);
	}

	/// <summary>
	/// 获取功法关联的真气状态
	/// </summary>
	public static ENeiliAllocationStatusType GetRelatedNeiliAllocationStatus(this ICombatCharacterBridge combatChar, CombatSkillItem combatSkillConfig)
	{
		byte relatedNeiliAllocationType = combatSkillConfig.GetRelatedNeiliAllocationType();
		return combatChar.GetNeiliAllocationStatus(relatedNeiliAllocationType);
	}

	/// <summary>
	/// 内息紊乱导致功法反噬概率
	/// </summary>
	public static int GetInjuredRate(this ICombatCharacterBridge combatChar, CombatSkillItem combatSkillConfig)
	{
		sbyte injuredRate = DisorderLevelOfQi.GetDisorderLevelOfQiConfig(combatChar.GetDisorderOfQi()).InjuredRate;
		ENeiliAllocationStatusType status = combatChar.GetRelatedNeiliAllocationStatus(combatSkillConfig);
		CValuePercentBonus percent = NeiliAllocationStatus.Instance[(int)status].GoneMadInjuryRate;
		return injuredRate * percent;
	}

	/// <summary>
	/// 功法反噬伤害
	/// </summary>
	public static int GetGoneMadInjuryTotalPercent(this ICombatCharacterBridge combatChar, CombatSkillItem combatSkillConfig)
	{
		return combatChar.GetRelatedNeiliAllocationStatus(combatSkillConfig).GetConfig().GoneMadInjuryBonus;
	}

	/// <summary>
	/// 获取增加指定类型真气时状态提供的 B 类加成
	/// </summary>
	/// <param name="combatChar"></param>
	/// <param name="neiliAllocationType"></param>
	/// <returns></returns>
	public static int GetAddNeiliAllocationAddPercent(this ICombatCharacterBridge combatChar, byte neiliAllocationType)
	{
		return combatChar.GetNeiliAllocationStatus(neiliAllocationType).GetConfig().AddNeiliAllocation;
	}

	/// <summary>
	/// 获取减少指定类型真气时状态提供的 B 类加成
	/// </summary>
	/// <param name="combatChar"></param>
	/// <param name="neiliAllocationType"></param>
	/// <returns></returns>
	public static int GetCostNeiliAllocationAddPercent(this ICombatCharacterBridge combatChar, byte neiliAllocationType)
	{
		return combatChar.GetNeiliAllocationStatus(neiliAllocationType).GetConfig().CostNeiliAllocation;
	}
}
