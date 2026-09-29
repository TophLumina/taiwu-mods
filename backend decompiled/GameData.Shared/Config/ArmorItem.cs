using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class ArmorItem : ConfigItem<ArmorItem, short>, IItemConfig
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte ItemType;

	public readonly short ItemSubType;

	public readonly sbyte Grade;

	public readonly short GroupId;

	public readonly string Icon;

	public readonly string Desc;

	public readonly string FunctionDesc;

	public readonly bool Transferable;

	public readonly bool Stackable;

	public readonly bool Wagerable;

	public readonly bool Refinable;

	public readonly bool Poisonable;

	public readonly bool Repairable;

	public readonly bool Inheritable;

	public readonly bool Detachable;

	public readonly short MaxDurability;

	public readonly int BaseWeight;

	public readonly int BaseValue;

	public readonly sbyte MerchantLevel;

	public readonly sbyte BaseHappinessChange;

	public readonly int BaseFavorabilityChange;

	public readonly sbyte GiftLevel;

	public readonly bool AllowRandomCreate;

	public readonly bool AllowRawCreate;

	public readonly bool AllowCrippledCreate;

	public readonly sbyte DropRate;

	public readonly bool IsSpecial;

	public readonly sbyte ResourceType;

	public readonly short PreservationDuration;

	public readonly short MakeItemSubType;

	public readonly List<int> TaskLock;

	public readonly sbyte EquipmentType;

	public readonly short EquipmentEffectId;

	public readonly short EquipmentMasteryId;

	public readonly short BaseEquipmentAttack;

	public readonly short BaseEquipmentDefense;

	public readonly List<PropertyAndValue> RequiredCharacterProperties;

	public readonly HitOrAvoidShorts BaseAvoidFactors;

	public readonly OuterAndInnerShorts BasePenetrationResistFactors;

	public readonly OuterAndInnerShorts BaseInjuryFactors;

	public readonly short RelatedWeapon;

	public readonly List<string> SkeletonSlotAndAttachment;

	public readonly short EquipmentCombatPowerValueFactor;

	public ArmorItem Group
	{
		[return: MaybeNull]
		get
		{
			return Armor.Instance.GetItemOrDefault(GroupId);
		}
	}

	public EquipmentEffectItem EquipmentEffect
	{
		[return: MaybeNull]
		get
		{
			return Config.EquipmentEffect.Instance.GetItemOrDefault(EquipmentEffectId);
		}
	}

	public SpecialEffectItem EquipmentMastery
	{
		[return: MaybeNull]
		get
		{
			return SpecialEffect.Instance.GetItemOrDefault(EquipmentMasteryId);
		}
	}

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	int IItemConfig.BaseValue => BaseValue;

	int IItemConfig.EquipmentMasteryId => EquipmentMasteryId;

	List<int> IItemConfig.TaskLock => TaskLock;

	short IItemConfig.MakeItemSubType => MakeItemSubType;

	public ArmorItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, bool allowRawCreate, bool allowCrippledCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, short equipmentMasteryId, short baseEquipmentAttack, short baseEquipmentDefense, List<PropertyAndValue> requiredCharacterProperties, HitOrAvoidShorts baseAvoidFactors, OuterAndInnerShorts basePenetrationResistFactors, OuterAndInnerShorts baseInjuryFactors, short relatedWeapon, List<string> skeletonSlotAndAttachment, short equipmentCombatPowerValueFactor)
	{
		TemplateId = templateId;
		Name = name;
		ItemType = itemType;
		ItemSubType = itemSubType;
		Grade = grade;
		GroupId = groupId;
		Icon = icon;
		Desc = desc;
		FunctionDesc = functionDesc;
		Transferable = transferable;
		Stackable = stackable;
		Wagerable = wagerable;
		Refinable = refinable;
		Poisonable = poisonable;
		Repairable = repairable;
		Inheritable = inheritable;
		Detachable = detachable;
		MaxDurability = maxDurability;
		BaseWeight = baseWeight;
		BaseValue = baseValue;
		MerchantLevel = merchantLevel;
		BaseHappinessChange = baseHappinessChange;
		BaseFavorabilityChange = baseFavorabilityChange;
		GiftLevel = giftLevel;
		AllowRandomCreate = allowRandomCreate;
		AllowRawCreate = allowRawCreate;
		AllowCrippledCreate = allowCrippledCreate;
		DropRate = dropRate;
		IsSpecial = isSpecial;
		ResourceType = resourceType;
		PreservationDuration = preservationDuration;
		MakeItemSubType = makeItemSubType;
		TaskLock = taskLock;
		EquipmentType = equipmentType;
		EquipmentEffectId = equipmentEffectId;
		EquipmentMasteryId = equipmentMasteryId;
		BaseEquipmentAttack = baseEquipmentAttack;
		BaseEquipmentDefense = baseEquipmentDefense;
		RequiredCharacterProperties = requiredCharacterProperties;
		BaseAvoidFactors = baseAvoidFactors;
		BasePenetrationResistFactors = basePenetrationResistFactors;
		BaseInjuryFactors = baseInjuryFactors;
		RelatedWeapon = relatedWeapon;
		SkeletonSlotAndAttachment = skeletonSlotAndAttachment;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	public ArmorItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 1;
		ItemSubType = 0;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		Transferable = true;
		Stackable = false;
		Wagerable = true;
		Refinable = true;
		Poisonable = true;
		Repairable = true;
		Inheritable = true;
		Detachable = true;
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 20;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 150;
		GiftLevel = 8;
		AllowRandomCreate = true;
		AllowRawCreate = true;
		AllowCrippledCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 36;
		MakeItemSubType = 0;
		TaskLock = new List<int>();
		EquipmentType = 0;
		EquipmentEffectId = 0;
		EquipmentMasteryId = 0;
		BaseEquipmentAttack = 0;
		BaseEquipmentDefense = 0;
		RequiredCharacterProperties = new List<PropertyAndValue>();
		BaseAvoidFactors = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		BasePenetrationResistFactors = new OuterAndInnerShorts(0, 0);
		BaseInjuryFactors = new OuterAndInnerShorts(0, 0);
		RelatedWeapon = 0;
		SkeletonSlotAndAttachment = null;
		EquipmentCombatPowerValueFactor = 100;
	}

	public ArmorItem(short templateId, ArmorItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ItemType = other.ItemType;
		ItemSubType = other.ItemSubType;
		Grade = other.Grade;
		GroupId = other.GroupId;
		Icon = other.Icon;
		Desc = other.Desc;
		FunctionDesc = other.FunctionDesc;
		Transferable = other.Transferable;
		Stackable = other.Stackable;
		Wagerable = other.Wagerable;
		Refinable = other.Refinable;
		Poisonable = other.Poisonable;
		Repairable = other.Repairable;
		Inheritable = other.Inheritable;
		Detachable = other.Detachable;
		MaxDurability = other.MaxDurability;
		BaseWeight = other.BaseWeight;
		BaseValue = other.BaseValue;
		MerchantLevel = other.MerchantLevel;
		BaseHappinessChange = other.BaseHappinessChange;
		BaseFavorabilityChange = other.BaseFavorabilityChange;
		GiftLevel = other.GiftLevel;
		AllowRandomCreate = other.AllowRandomCreate;
		AllowRawCreate = other.AllowRawCreate;
		AllowCrippledCreate = other.AllowCrippledCreate;
		DropRate = other.DropRate;
		IsSpecial = other.IsSpecial;
		ResourceType = other.ResourceType;
		PreservationDuration = other.PreservationDuration;
		MakeItemSubType = other.MakeItemSubType;
		TaskLock = other.TaskLock;
		EquipmentType = other.EquipmentType;
		EquipmentEffectId = other.EquipmentEffectId;
		EquipmentMasteryId = other.EquipmentMasteryId;
		BaseEquipmentAttack = other.BaseEquipmentAttack;
		BaseEquipmentDefense = other.BaseEquipmentDefense;
		RequiredCharacterProperties = other.RequiredCharacterProperties;
		BaseAvoidFactors = other.BaseAvoidFactors;
		BasePenetrationResistFactors = other.BasePenetrationResistFactors;
		BaseInjuryFactors = other.BaseInjuryFactors;
		RelatedWeapon = other.RelatedWeapon;
		SkeletonSlotAndAttachment = other.SkeletonSlotAndAttachment;
		EquipmentCombatPowerValueFactor = other.EquipmentCombatPowerValueFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ArmorItem Duplicate(int templateId)
	{
		return new ArmorItem((short)templateId, this);
	}
}
