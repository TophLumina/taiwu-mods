using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Combat.Math;
using GameData.Utilities;

namespace Config;

[Serializable]
public class SpecialEffectItem : ConfigItem<SpecialEffectItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte EffectActiveType;

	public readonly short MinEffectCount;

	public readonly short MaxEffectCount;

	public readonly sbyte RequireAttackPower;

	public readonly sbyte AiCostNeiliAllocationChanceDelayFrame;

	public readonly ESpecialEffectAiCostNeiliAllocationType AiCostNeiliAllocationType;

	public readonly int TransferProportion;

	public readonly int[] AffectRequirePower;

	public readonly int[] PowerDamageFactors;

	public readonly int AddUnlockValue;

	public readonly short AddUnlockValueItemSubType;

	public readonly short RawCreateEffect;

	public readonly short RawCreateTips;

	public readonly ESpecialEffectRawCreateType RawCreateType;

	public readonly int RawCreateRequireMaterialCount;

	public readonly bool ShowUsingItemButtonEffect;

	public readonly string Name;

	public readonly short SkillTemplateId;

	public readonly string[] ShortDesc;

	public readonly string[] Desc;

	public readonly string[] DetailedDesc;

	public readonly string[] PlayerCastBossSkillDesc;

	public readonly string ClassName;

	public CombatSkillItem SkillTemplate
	{
		[return: MaybeNull]
		get
		{
			return CombatSkill.Instance.GetItemOrDefault(SkillTemplateId);
		}
	}

	public SpecialEffectItem(short templateId, sbyte effectActiveType, short minEffectCount, short maxEffectCount, sbyte requireAttackPower, sbyte aiCostNeiliAllocationChanceDelayFrame, ESpecialEffectAiCostNeiliAllocationType aiCostNeiliAllocationType, int transferProportion, int[] affectRequirePower, int[] powerDamageFactors, int addUnlockValue, short addUnlockValueItemSubType, short rawCreateEffect, short rawCreateTips, ESpecialEffectRawCreateType rawCreateType, int rawCreateRequireMaterialCount, bool showUsingItemButtonEffect, string name, short skillTemplateId, string[] shortDesc, string[] desc, string[] detailedDesc, string[] playerCastBossSkillDesc, string className)
	{
		TemplateId = templateId;
		EffectActiveType = effectActiveType;
		MinEffectCount = minEffectCount;
		MaxEffectCount = maxEffectCount;
		RequireAttackPower = requireAttackPower;
		AiCostNeiliAllocationChanceDelayFrame = aiCostNeiliAllocationChanceDelayFrame;
		AiCostNeiliAllocationType = aiCostNeiliAllocationType;
		TransferProportion = transferProportion;
		AffectRequirePower = affectRequirePower;
		PowerDamageFactors = powerDamageFactors;
		AddUnlockValue = addUnlockValue;
		AddUnlockValueItemSubType = addUnlockValueItemSubType;
		RawCreateEffect = rawCreateEffect;
		RawCreateTips = rawCreateTips;
		RawCreateType = rawCreateType;
		RawCreateRequireMaterialCount = rawCreateRequireMaterialCount;
		ShowUsingItemButtonEffect = showUsingItemButtonEffect;
		Name = name;
		SkillTemplateId = skillTemplateId;
		ShortDesc = shortDesc;
		Desc = desc;
		DetailedDesc = detailedDesc;
		PlayerCastBossSkillDesc = playerCastBossSkillDesc;
		ClassName = className;
	}

	public SpecialEffectItem()
	{
		TemplateId = 0;
		EffectActiveType = -1;
		MinEffectCount = 1;
		MaxEffectCount = -1;
		RequireAttackPower = -1;
		AiCostNeiliAllocationChanceDelayFrame = -1;
		AiCostNeiliAllocationType = ESpecialEffectAiCostNeiliAllocationType.None;
		TransferProportion = 0;
		AffectRequirePower = new int[0];
		PowerDamageFactors = new int[0];
		AddUnlockValue = 0;
		AddUnlockValueItemSubType = 0;
		RawCreateEffect = 0;
		RawCreateTips = 0;
		RawCreateType = ESpecialEffectRawCreateType.None;
		RawCreateRequireMaterialCount = 0;
		ShowUsingItemButtonEffect = false;
		Name = null;
		SkillTemplateId = 0;
		ShortDesc = new string[0];
		Desc = new string[0];
		DetailedDesc = new string[0];
		PlayerCastBossSkillDesc = new string[0];
		ClassName = null;
	}

	public SpecialEffectItem(short templateId, SpecialEffectItem other)
	{
		TemplateId = templateId;
		EffectActiveType = other.EffectActiveType;
		MinEffectCount = other.MinEffectCount;
		MaxEffectCount = other.MaxEffectCount;
		RequireAttackPower = other.RequireAttackPower;
		AiCostNeiliAllocationChanceDelayFrame = other.AiCostNeiliAllocationChanceDelayFrame;
		AiCostNeiliAllocationType = other.AiCostNeiliAllocationType;
		TransferProportion = other.TransferProportion;
		AffectRequirePower = other.AffectRequirePower;
		PowerDamageFactors = other.PowerDamageFactors;
		AddUnlockValue = other.AddUnlockValue;
		AddUnlockValueItemSubType = other.AddUnlockValueItemSubType;
		RawCreateEffect = other.RawCreateEffect;
		RawCreateTips = other.RawCreateTips;
		RawCreateType = other.RawCreateType;
		RawCreateRequireMaterialCount = other.RawCreateRequireMaterialCount;
		ShowUsingItemButtonEffect = other.ShowUsingItemButtonEffect;
		Name = other.Name;
		SkillTemplateId = other.SkillTemplateId;
		ShortDesc = other.ShortDesc;
		Desc = other.Desc;
		DetailedDesc = other.DetailedDesc;
		PlayerCastBossSkillDesc = other.PlayerCastBossSkillDesc;
		ClassName = other.ClassName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SpecialEffectItem Duplicate(int templateId)
	{
		return new SpecialEffectItem((short)templateId, this);
	}

	public CValuePercent GetPowerFactor(int index = 0)
	{
		if (PowerDamageFactors.CheckIndex(index))
		{
			return PowerDamageFactors[index];
		}
		PredefinedLog.Show(8, $"{TemplateId} failed to get power factor at {index}");
		return 100;
	}
}
