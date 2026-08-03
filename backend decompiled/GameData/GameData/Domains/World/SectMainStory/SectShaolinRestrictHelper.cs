using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.World.SectMainStory;

public static class SectShaolinRestrictHelper
{
	public static short GetCombatConfigId(this IEnumerable<DemonSlayerTrialRestrictItem> restricts)
	{
		short result = 211;
		List<short> validCombatConfigs = ObjectPool<List<short>>.Instance.Get();
		List<short> preferCombatConfigs = ObjectPool<List<short>>.Instance.Get();
		foreach (DemonSlayerTrialRestrictItem restrict in restricts)
		{
			if (validCombatConfigs.Count == 0)
			{
				validCombatConfigs.AddRange(restrict.EffectiveCombatConfigs);
			}
			else
			{
				validCombatConfigs.RemoveAll((short x) => !restrict.EffectiveCombatConfigs.Contains(x));
				if (validCombatConfigs.Count == 0)
				{
					break;
				}
			}
			if (!preferCombatConfigs.Contains(restrict.PreferCombatConfig))
			{
				preferCombatConfigs.Add(restrict.PreferCombatConfig);
			}
		}
		if (validCombatConfigs.Count > 0)
		{
			if (preferCombatConfigs.Any(validCombatConfigs.Contains))
			{
				validCombatConfigs.RemoveAll((short x) => !preferCombatConfigs.Contains(x));
			}
			result = validCombatConfigs[0];
		}
		ObjectPool<List<short>>.Instance.Return(validCombatConfigs);
		ObjectPool<List<short>>.Instance.Return(preferCombatConfigs);
		return result;
	}

	public static bool Check(this DemonSlayerTrialRestrictItem restrict)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		CombatSkillEquipment combatSkillEquipment = taiwu.GetCombatSkillEquipment();
		if (restrict.MinCombatSkillGrade >= 0 && combatSkillEquipment.GetMinGrade() < restrict.MinCombatSkillGrade)
		{
			return false;
		}
		if (restrict.MaxCombatSkillGrade >= 0 && combatSkillEquipment.GetMaxGrade() > restrict.MaxCombatSkillGrade)
		{
			return false;
		}
		if (restrict.MaxAttackSkillSlotCount >= 0 && taiwu.GetSlotCount(1) > restrict.MaxAttackSkillSlotCount)
		{
			return false;
		}
		if (restrict.MaxAgileSkillSlotCount >= 0 && taiwu.GetSlotCount(2) > restrict.MaxAgileSkillSlotCount)
		{
			return false;
		}
		if (restrict.MaxDefenseSkillSlotCount >= 0 && taiwu.GetSlotCount(3) > restrict.MaxDefenseSkillSlotCount)
		{
			return false;
		}
		if (restrict.MaxAssistSkillSlotCount >= 0 && taiwu.GetSlotCount(4) > restrict.MaxAssistSkillSlotCount)
		{
			return false;
		}
		return restrict.MaxWeaponSlotCount < 0 || taiwu.GetWeaponCount() <= restrict.MaxWeaponSlotCount;
	}

	private static int GetMinGrade(this CombatSkillEquipment combatSkillEquipment)
	{
		sbyte minGrade = 8;
		foreach (short skillId in combatSkillEquipment)
		{
			minGrade = Math.Min(minGrade, Config.CombatSkill.Instance[skillId].Grade);
		}
		return minGrade;
	}

	private static int GetMaxGrade(this CombatSkillEquipment combatSkillEquipment)
	{
		sbyte maxGrade = 0;
		foreach (short skillId in combatSkillEquipment)
		{
			maxGrade = Math.Max(maxGrade, Config.CombatSkill.Instance[skillId].Grade);
		}
		return maxGrade;
	}

	private static int GetSlotCount(this GameData.Domains.Character.Character character, sbyte equipType)
	{
		return character.GetCombatSkillTypeRequireGrid(equipType);
	}

	private static int GetWeaponCount(this GameData.Domains.Character.Character character)
	{
		ItemKey[] equipment = character.GetEquipment();
		int count = 0;
		for (sbyte i = 0; i <= 2; i++)
		{
			if (equipment[i].IsValid())
			{
				count++;
			}
		}
		return count;
	}
}
