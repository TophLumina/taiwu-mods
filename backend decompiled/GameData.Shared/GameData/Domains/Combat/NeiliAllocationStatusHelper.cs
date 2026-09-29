using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public static class NeiliAllocationStatusHelper
{
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

	public static NeiliAllocationStatusItem GetConfig(this ENeiliAllocationStatusType statusType)
	{
		return NeiliAllocationStatus.Instance[(int)statusType];
	}

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

	public static bool IsRelated(this CombatSkillItem combatSkillConfig, byte neiliAllocationType)
	{
		return combatSkillConfig.GetRelatedNeiliAllocationType() == neiliAllocationType;
	}

	public static ENeiliAllocationStatusType GetNeiliAllocationStatus(this ICombatCharacterBridge combatChar, byte neiliAllocationType)
	{
		NeiliAllocation neiliAllocation = combatChar.GetNeiliAllocation();
		NeiliAllocation originalNeiliAllocation = combatChar.GetOriginNeiliAllocation();
		return neiliAllocation.GetStatus(originalNeiliAllocation, neiliAllocationType);
	}

	public static ENeiliAllocationStatusType GetRelatedNeiliAllocationStatus(this ICombatCharacterBridge combatChar, CombatSkillItem combatSkillConfig)
	{
		byte relatedNeiliAllocationType = combatSkillConfig.GetRelatedNeiliAllocationType();
		return combatChar.GetNeiliAllocationStatus(relatedNeiliAllocationType);
	}

	public static int GetInjuredRate(this ICombatCharacterBridge combatChar, CombatSkillItem combatSkillConfig)
	{
		sbyte injuredRate = DisorderLevelOfQi.GetDisorderLevelOfQiConfig(combatChar.GetDisorderOfQi()).InjuredRate;
		ENeiliAllocationStatusType status = combatChar.GetRelatedNeiliAllocationStatus(combatSkillConfig);
		CValuePercentBonus percent = NeiliAllocationStatus.Instance[(int)status].GoneMadInjuryRate;
		return injuredRate * percent;
	}

	public static int GetGoneMadInjuryTotalPercent(this ICombatCharacterBridge combatChar, CombatSkillItem combatSkillConfig)
	{
		return combatChar.GetRelatedNeiliAllocationStatus(combatSkillConfig).GetConfig().GoneMadInjuryBonus;
	}

	public static int GetAddNeiliAllocationAddPercent(this ICombatCharacterBridge combatChar, byte neiliAllocationType)
	{
		return combatChar.GetNeiliAllocationStatus(neiliAllocationType).GetConfig().AddNeiliAllocation;
	}

	public static int GetCostNeiliAllocationAddPercent(this ICombatCharacterBridge combatChar, byte neiliAllocationType)
	{
		return combatChar.GetNeiliAllocationStatus(neiliAllocationType).GetConfig().CostNeiliAllocation;
	}
}
