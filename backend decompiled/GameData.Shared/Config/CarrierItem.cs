using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Domains.Item;
using GameData.Utilities;

namespace Config;

[Serializable]
public class CarrierItem : ConfigItem<CarrierItem, short>, IItemConfig
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

	public readonly sbyte BaseTravelTimeReduction;

	public readonly short BaseMaxInventoryLoadBonus;

	public readonly short BaseMaxKidnapSlotCountBonus;

	public readonly short BaseDropRateBonus;

	public readonly short BaseCaptureRateBonus;

	public readonly short BaseExploreBonusRate;

	public readonly short CharacterIdInCombat;

	public readonly short CombatState;

	public readonly sbyte[] TamePersonalities;

	public readonly bool IsFlying;

	public readonly sbyte TamePoint;

	public readonly List<short> LoveFoodType;

	public readonly List<short> HateFoodType;

	public readonly string StandDisplay;

	public readonly short TravelSkeleton;

	public readonly PoisonsAndLevels InnatePoisons;

	public readonly short EquipmentCombatPowerValueFactor;

	public CarrierItem Group
	{
		[return: MaybeNull]
		get
		{
			return Carrier.Instance.GetItemOrDefault(GroupId);
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

	public CarrierItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, sbyte baseTravelTimeReduction, short baseMaxInventoryLoadBonus, short baseMaxKidnapSlotCountBonus, short baseDropRateBonus, short baseCaptureRateBonus, short baseExploreBonusRate, short characterIdInCombat, short combatState, sbyte[] tamePersonalities, bool isFlying, sbyte tamePoint, List<short> loveFoodType, List<short> hateFoodType, string standDisplay, short travelSkeleton, PoisonsAndLevels innatePoisons, short equipmentCombatPowerValueFactor)
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
		BaseTravelTimeReduction = baseTravelTimeReduction;
		BaseMaxInventoryLoadBonus = baseMaxInventoryLoadBonus;
		BaseMaxKidnapSlotCountBonus = baseMaxKidnapSlotCountBonus;
		BaseDropRateBonus = baseDropRateBonus;
		BaseCaptureRateBonus = baseCaptureRateBonus;
		BaseExploreBonusRate = baseExploreBonusRate;
		CharacterIdInCombat = characterIdInCombat;
		CombatState = combatState;
		TamePersonalities = tamePersonalities;
		IsFlying = isFlying;
		TamePoint = tamePoint;
		LoveFoodType = loveFoodType;
		HateFoodType = hateFoodType;
		StandDisplay = standDisplay;
		TravelSkeleton = travelSkeleton;
		InnatePoisons = innatePoisons;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	public CarrierItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 4;
		ItemSubType = 0;
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
		Repairable = false;
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
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 36;
		MakeItemSubType = 0;
		TaskLock = new List<int>();
		EquipmentType = 7;
		EquipmentEffectId = 0;
		BaseTravelTimeReduction = 0;
		BaseMaxInventoryLoadBonus = 0;
		BaseMaxKidnapSlotCountBonus = 0;
		BaseDropRateBonus = 0;
		BaseCaptureRateBonus = 0;
		BaseExploreBonusRate = 0;
		CharacterIdInCombat = 0;
		CombatState = 0;
		TamePersonalities = new sbyte[7];
		IsFlying = false;
		TamePoint = -1;
		LoveFoodType = null;
		HateFoodType = null;
		StandDisplay = null;
		TravelSkeleton = 0;
		InnatePoisons = new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		EquipmentCombatPowerValueFactor = 0;
	}

	public CarrierItem(short templateId, CarrierItem other)
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
		BaseTravelTimeReduction = other.BaseTravelTimeReduction;
		BaseMaxInventoryLoadBonus = other.BaseMaxInventoryLoadBonus;
		BaseMaxKidnapSlotCountBonus = other.BaseMaxKidnapSlotCountBonus;
		BaseDropRateBonus = other.BaseDropRateBonus;
		BaseCaptureRateBonus = other.BaseCaptureRateBonus;
		BaseExploreBonusRate = other.BaseExploreBonusRate;
		CharacterIdInCombat = other.CharacterIdInCombat;
		CombatState = other.CombatState;
		TamePersonalities = other.TamePersonalities;
		IsFlying = other.IsFlying;
		TamePoint = other.TamePoint;
		LoveFoodType = other.LoveFoodType;
		HateFoodType = other.HateFoodType;
		StandDisplay = other.StandDisplay;
		TravelSkeleton = other.TravelSkeleton;
		InnatePoisons = other.InnatePoisons;
		EquipmentCombatPowerValueFactor = other.EquipmentCombatPowerValueFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CarrierItem Duplicate(int templateId)
	{
		return new CarrierItem((short)templateId, this);
	}
}
