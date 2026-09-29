using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class DemonSlayerTrialRestrictItem : ConfigItem<DemonSlayerTrialRestrictItem, int>
{
	public readonly int TemplateId;

	public readonly string Desc;

	public readonly int MutexGroupId;

	public readonly List<int> MutexDemonId;

	public readonly int Power;

	public readonly short Weight;

	public readonly sbyte MinCombatSkillGrade;

	public readonly sbyte MaxCombatSkillGrade;

	public readonly sbyte MaxAttackSkillSlotCount;

	public readonly sbyte MaxAgileSkillSlotCount;

	public readonly sbyte MaxDefenseSkillSlotCount;

	public readonly sbyte MaxAssistSkillSlotCount;

	public readonly sbyte MaxWeaponSlotCount;

	public readonly short PreferCombatConfig;

	public readonly List<short> EffectiveCombatConfigs;

	public readonly string EffectClassName;

	public readonly int[] EffectParameters;

	public DemonSlayerTrialRestrictItem MutexGroup
	{
		[return: MaybeNull]
		get
		{
			return DemonSlayerTrialRestrict.Instance.GetItemOrDefault(MutexGroupId);
		}
	}

	public DemonSlayerTrialRestrictItem(int templateId, string desc, int mutexGroupId, List<int> mutexDemonId, int power, short weight, sbyte minCombatSkillGrade, sbyte maxCombatSkillGrade, sbyte maxAttackSkillSlotCount, sbyte maxAgileSkillSlotCount, sbyte maxDefenseSkillSlotCount, sbyte maxAssistSkillSlotCount, sbyte maxWeaponSlotCount, short preferCombatConfig, List<short> effectiveCombatConfigs, string effectClassName, int[] effectParameters)
	{
		TemplateId = templateId;
		Desc = desc;
		MutexGroupId = mutexGroupId;
		MutexDemonId = mutexDemonId;
		Power = power;
		Weight = weight;
		MinCombatSkillGrade = minCombatSkillGrade;
		MaxCombatSkillGrade = maxCombatSkillGrade;
		MaxAttackSkillSlotCount = maxAttackSkillSlotCount;
		MaxAgileSkillSlotCount = maxAgileSkillSlotCount;
		MaxDefenseSkillSlotCount = maxDefenseSkillSlotCount;
		MaxAssistSkillSlotCount = maxAssistSkillSlotCount;
		MaxWeaponSlotCount = maxWeaponSlotCount;
		PreferCombatConfig = preferCombatConfig;
		EffectiveCombatConfigs = effectiveCombatConfigs;
		EffectClassName = effectClassName;
		EffectParameters = effectParameters;
	}

	public DemonSlayerTrialRestrictItem()
	{
		TemplateId = 0;
		Desc = null;
		MutexGroupId = 0;
		MutexDemonId = new List<int>();
		Power = 0;
		Weight = 0;
		MinCombatSkillGrade = 0;
		MaxCombatSkillGrade = 8;
		MaxAttackSkillSlotCount = -1;
		MaxAgileSkillSlotCount = -1;
		MaxDefenseSkillSlotCount = -1;
		MaxAssistSkillSlotCount = -1;
		MaxWeaponSlotCount = -1;
		PreferCombatConfig = 211;
		EffectiveCombatConfigs = new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		};
		EffectClassName = null;
		EffectParameters = new int[0];
	}

	public DemonSlayerTrialRestrictItem(int templateId, DemonSlayerTrialRestrictItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		MutexGroupId = other.MutexGroupId;
		MutexDemonId = other.MutexDemonId;
		Power = other.Power;
		Weight = other.Weight;
		MinCombatSkillGrade = other.MinCombatSkillGrade;
		MaxCombatSkillGrade = other.MaxCombatSkillGrade;
		MaxAttackSkillSlotCount = other.MaxAttackSkillSlotCount;
		MaxAgileSkillSlotCount = other.MaxAgileSkillSlotCount;
		MaxDefenseSkillSlotCount = other.MaxDefenseSkillSlotCount;
		MaxAssistSkillSlotCount = other.MaxAssistSkillSlotCount;
		MaxWeaponSlotCount = other.MaxWeaponSlotCount;
		PreferCombatConfig = other.PreferCombatConfig;
		EffectiveCombatConfigs = other.EffectiveCombatConfigs;
		EffectClassName = other.EffectClassName;
		EffectParameters = other.EffectParameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DemonSlayerTrialRestrictItem Duplicate(int templateId)
	{
		return new DemonSlayerTrialRestrictItem(templateId, this);
	}
}
