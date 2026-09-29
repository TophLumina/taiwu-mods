using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class ClothingItem : ConfigItem<ClothingItem, short>, IItemConfig
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

	public readonly sbyte DropRate;

	public readonly bool IsSpecial;

	public readonly sbyte ResourceType;

	public readonly short PreservationDuration;

	public readonly short MakeItemSubType;

	public readonly List<int> TaskLock;

	public readonly sbyte EquipmentType;

	public readonly short EquipmentEffectId;

	public readonly short DisplayId;

	public readonly sbyte AgeGroup;

	public readonly bool KeepOnPassing;

	public readonly short WeaveNeedAttainment;

	public readonly sbyte WeaveType;

	public readonly string DlcName;

	public readonly string SmallVillageDesc;

	public readonly short EquipmentCombatPowerValueFactor;

	public ClothingItem Group
	{
		[return: MaybeNull]
		get
		{
			return Clothing.Instance.GetItemOrDefault(GroupId);
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

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	int IItemConfig.BaseValue => BaseValue;

	List<int> IItemConfig.TaskLock => TaskLock;

	short IItemConfig.MakeItemSubType => MakeItemSubType;

	public ClothingItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, short displayId, sbyte ageGroup, bool keepOnPassing, short weaveNeedAttainment, sbyte weaveType, string dlcName, string smallVillageDesc, short equipmentCombatPowerValueFactor)
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
		DropRate = dropRate;
		IsSpecial = isSpecial;
		ResourceType = resourceType;
		PreservationDuration = preservationDuration;
		MakeItemSubType = makeItemSubType;
		TaskLock = taskLock;
		EquipmentType = equipmentType;
		EquipmentEffectId = equipmentEffectId;
		DisplayId = displayId;
		AgeGroup = ageGroup;
		KeepOnPassing = keepOnPassing;
		WeaveNeedAttainment = weaveNeedAttainment;
		WeaveType = weaveType;
		DlcName = dlcName;
		SmallVillageDesc = smallVillageDesc;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	public ClothingItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 3;
		ItemSubType = 300;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		Transferable = true;
		Stackable = false;
		Wagerable = true;
		Refinable = false;
		Poisonable = false;
		Repairable = true;
		Inheritable = true;
		Detachable = true;
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 15;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 100;
		GiftLevel = 8;
		AllowRandomCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 12;
		MakeItemSubType = 0;
		TaskLock = new List<int>();
		EquipmentType = 2;
		EquipmentEffectId = 0;
		DisplayId = 0;
		AgeGroup = 2;
		KeepOnPassing = false;
		WeaveNeedAttainment = 0;
		WeaveType = 0;
		DlcName = null;
		SmallVillageDesc = null;
		EquipmentCombatPowerValueFactor = 0;
	}

	public ClothingItem(short templateId, ClothingItem other)
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
		DropRate = other.DropRate;
		IsSpecial = other.IsSpecial;
		ResourceType = other.ResourceType;
		PreservationDuration = other.PreservationDuration;
		MakeItemSubType = other.MakeItemSubType;
		TaskLock = other.TaskLock;
		EquipmentType = other.EquipmentType;
		EquipmentEffectId = other.EquipmentEffectId;
		DisplayId = other.DisplayId;
		AgeGroup = other.AgeGroup;
		KeepOnPassing = other.KeepOnPassing;
		WeaveNeedAttainment = other.WeaveNeedAttainment;
		WeaveType = other.WeaveType;
		DlcName = other.DlcName;
		SmallVillageDesc = other.SmallVillageDesc;
		EquipmentCombatPowerValueFactor = other.EquipmentCombatPowerValueFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ClothingItem Duplicate(int templateId)
	{
		return new ClothingItem((short)templateId, this);
	}
}
