using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class CraftToolItem : ConfigItem<CraftToolItem, short>, ICombatItemConfig, IItemConfig
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

	public readonly List<int> TaskLock;

	public readonly List<sbyte> RequiredLifeSkillTypes;

	public readonly short AttainmentBonus;

	public readonly short[] DurabilityCost;

	public readonly sbyte ConsumedFeatureMedals;

	public CraftToolItem Group
	{
		[return: MaybeNull]
		get
		{
			return CraftTool.Instance.GetItemOrDefault(GroupId);
		}
	}

	int ICombatItemConfig.ConsumedFeatureMedals => ConsumedFeatureMedals;

	int ICombatItemConfig.UseFrame => GlobalConfig.Instance.RepairInCombatFrameUnit;

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	int IItemConfig.BaseValue => BaseValue;

	List<int> IItemConfig.TaskLock => TaskLock;

	public CraftToolItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, List<int> taskLock, List<sbyte> requiredLifeSkillTypes, short attainmentBonus, short[] durabilityCost, sbyte consumedFeatureMedals)
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
		TaskLock = taskLock;
		RequiredLifeSkillTypes = requiredLifeSkillTypes;
		AttainmentBonus = attainmentBonus;
		DurabilityCost = durabilityCost;
		ConsumedFeatureMedals = consumedFeatureMedals;
	}

	public CraftToolItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 6;
		ItemSubType = 600;
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
		PreservationDuration = 36;
		TaskLock = new List<int>();
		RequiredLifeSkillTypes = null;
		AttainmentBonus = 0;
		DurabilityCost = new short[9];
		ConsumedFeatureMedals = -1;
	}

	public CraftToolItem(short templateId, CraftToolItem other)
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
		TaskLock = other.TaskLock;
		RequiredLifeSkillTypes = other.RequiredLifeSkillTypes;
		AttainmentBonus = other.AttainmentBonus;
		DurabilityCost = other.DurabilityCost;
		ConsumedFeatureMedals = other.ConsumedFeatureMedals;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CraftToolItem Duplicate(int templateId)
	{
		return new CraftToolItem((short)templateId, this);
	}
}
