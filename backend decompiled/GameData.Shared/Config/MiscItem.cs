using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Domains.Extra;
using GameData.Utilities;

namespace Config;

[Serializable]
public class MiscItem : ConfigItem<MiscItem, short>, ICombatItemConfig, IItemConfig
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

	public readonly bool Consumable;

	public readonly short MaxDurability;

	public readonly int BaseWeight;

	public readonly int BaseValue;

	public readonly sbyte MerchantLevel;

	public readonly sbyte BaseHappinessChange;

	public readonly int BaseFavorabilityChange;

	public readonly sbyte GiftLevel;

	public readonly int Contribution;

	public readonly bool AllowRandomCreate;

	public readonly sbyte DropRate;

	public readonly bool IsSpecial;

	public readonly sbyte ResourceType;

	public readonly short MakeItemSubType;

	public readonly short PreservationDuration;

	public readonly List<int> TaskLock;

	public readonly sbyte BreakBonusEffect;

	public readonly short Neili;

	public readonly int MaxNeili;

	public readonly IntPair FiveElementTransfer;

	public readonly sbyte CricketHealInjuryOdds;

	public readonly short ReduceEscapeRate;

	public readonly sbyte ConsumedFeatureMedals;

	public readonly bool CanUseOnPrepareCombat;

	public readonly bool AllowUseInPlayAndTest;

	public readonly bool CanTriggerCommonEvent;

	public readonly sbyte MaxUseDistance;

	public readonly int UseFrame;

	public readonly List<short> RequireCombatConfig;

	public readonly List<int> AllowBrokenLevels;

	public readonly EMiscGenerateType GenerateType;

	public readonly List<TreasureStateInfo> StateBuryAmount;

	public readonly EMiscResourceMaterialType ResourceMaterialType;

	public readonly EMiscFilterType FilterType;

	public readonly short CombatUseEffect;

	public readonly short CombatPrepareUseEffect;

	public readonly int GainExp;

	public readonly short ResourceAmount;

	public readonly bool HasGiftEvent;

	public MiscItem Group
	{
		[return: MaybeNull]
		get
		{
			return Misc.Instance.GetItemOrDefault(GroupId);
		}
	}

	int ICombatItemConfig.ConsumedFeatureMedals => ConsumedFeatureMedals;

	int ICombatItemConfig.UseFrame => UseFrame;

	bool ICombatItemConfig.AllowUseInPlayAndTest => AllowUseInPlayAndTest;

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	sbyte IItemConfig.MaxUseDistance => MaxUseDistance;

	short IItemConfig.Duration => 0;

	int IItemConfig.BaseValue => BaseValue;

	List<int> IItemConfig.TaskLock => TaskLock;

	short IItemConfig.MakeItemSubType => MakeItemSubType;

	public MiscItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool consumable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, int contribution, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short makeItemSubType, short preservationDuration, List<int> taskLock, sbyte breakBonusEffect, short neili, int maxNeili, IntPair fiveElementTransfer, sbyte cricketHealInjuryOdds, short reduceEscapeRate, sbyte consumedFeatureMedals, bool canUseOnPrepareCombat, bool allowUseInPlayAndTest, bool canTriggerCommonEvent, sbyte maxUseDistance, int useFrame, List<short> requireCombatConfig, List<int> allowBrokenLevels, EMiscGenerateType generateType, List<TreasureStateInfo> stateBuryAmount, EMiscResourceMaterialType resourceMaterialType, EMiscFilterType filterType, short combatUseEffect, short combatPrepareUseEffect, int gainExp, short resourceAmount, bool hasGiftEvent)
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
		Consumable = consumable;
		MaxDurability = maxDurability;
		BaseWeight = baseWeight;
		BaseValue = baseValue;
		MerchantLevel = merchantLevel;
		BaseHappinessChange = baseHappinessChange;
		BaseFavorabilityChange = baseFavorabilityChange;
		GiftLevel = giftLevel;
		Contribution = contribution;
		AllowRandomCreate = allowRandomCreate;
		DropRate = dropRate;
		IsSpecial = isSpecial;
		ResourceType = resourceType;
		MakeItemSubType = makeItemSubType;
		PreservationDuration = preservationDuration;
		TaskLock = taskLock;
		BreakBonusEffect = breakBonusEffect;
		Neili = neili;
		MaxNeili = maxNeili;
		FiveElementTransfer = fiveElementTransfer;
		CricketHealInjuryOdds = cricketHealInjuryOdds;
		ReduceEscapeRate = reduceEscapeRate;
		ConsumedFeatureMedals = consumedFeatureMedals;
		CanUseOnPrepareCombat = canUseOnPrepareCombat;
		AllowUseInPlayAndTest = allowUseInPlayAndTest;
		CanTriggerCommonEvent = canTriggerCommonEvent;
		MaxUseDistance = maxUseDistance;
		UseFrame = useFrame;
		RequireCombatConfig = requireCombatConfig;
		AllowBrokenLevels = allowBrokenLevels;
		GenerateType = generateType;
		StateBuryAmount = stateBuryAmount;
		ResourceMaterialType = resourceMaterialType;
		FilterType = filterType;
		CombatUseEffect = combatUseEffect;
		CombatPrepareUseEffect = combatPrepareUseEffect;
		GainExp = gainExp;
		ResourceAmount = resourceAmount;
		HasGiftEvent = hasGiftEvent;
	}

	public MiscItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 12;
		ItemSubType = 1200;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		Transferable = true;
		Stackable = true;
		Wagerable = true;
		Refinable = false;
		Poisonable = false;
		Repairable = false;
		Inheritable = true;
		Consumable = false;
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 10;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 50;
		GiftLevel = 8;
		Contribution = 0;
		AllowRandomCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		MakeItemSubType = 0;
		PreservationDuration = 36;
		TaskLock = new List<int>();
		BreakBonusEffect = 0;
		Neili = 0;
		MaxNeili = 0;
		FiveElementTransfer = new IntPair(0, 0);
		CricketHealInjuryOdds = 0;
		ReduceEscapeRate = 0;
		ConsumedFeatureMedals = -1;
		CanUseOnPrepareCombat = false;
		AllowUseInPlayAndTest = false;
		CanTriggerCommonEvent = false;
		MaxUseDistance = -1;
		UseFrame = 60;
		RequireCombatConfig = new List<short>();
		AllowBrokenLevels = new List<int>();
		GenerateType = EMiscGenerateType.Invalid;
		StateBuryAmount = new List<TreasureStateInfo>();
		ResourceMaterialType = EMiscResourceMaterialType.Invalid;
		FilterType = EMiscFilterType.Invalid;
		CombatUseEffect = 0;
		CombatPrepareUseEffect = 0;
		GainExp = 0;
		ResourceAmount = 0;
		HasGiftEvent = false;
	}

	public MiscItem(short templateId, MiscItem other)
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
		Consumable = other.Consumable;
		MaxDurability = other.MaxDurability;
		BaseWeight = other.BaseWeight;
		BaseValue = other.BaseValue;
		MerchantLevel = other.MerchantLevel;
		BaseHappinessChange = other.BaseHappinessChange;
		BaseFavorabilityChange = other.BaseFavorabilityChange;
		GiftLevel = other.GiftLevel;
		Contribution = other.Contribution;
		AllowRandomCreate = other.AllowRandomCreate;
		DropRate = other.DropRate;
		IsSpecial = other.IsSpecial;
		ResourceType = other.ResourceType;
		MakeItemSubType = other.MakeItemSubType;
		PreservationDuration = other.PreservationDuration;
		TaskLock = other.TaskLock;
		BreakBonusEffect = other.BreakBonusEffect;
		Neili = other.Neili;
		MaxNeili = other.MaxNeili;
		FiveElementTransfer = other.FiveElementTransfer;
		CricketHealInjuryOdds = other.CricketHealInjuryOdds;
		ReduceEscapeRate = other.ReduceEscapeRate;
		ConsumedFeatureMedals = other.ConsumedFeatureMedals;
		CanUseOnPrepareCombat = other.CanUseOnPrepareCombat;
		AllowUseInPlayAndTest = other.AllowUseInPlayAndTest;
		CanTriggerCommonEvent = other.CanTriggerCommonEvent;
		MaxUseDistance = other.MaxUseDistance;
		UseFrame = other.UseFrame;
		RequireCombatConfig = other.RequireCombatConfig;
		AllowBrokenLevels = other.AllowBrokenLevels;
		GenerateType = other.GenerateType;
		StateBuryAmount = other.StateBuryAmount;
		ResourceMaterialType = other.ResourceMaterialType;
		FilterType = other.FilterType;
		CombatUseEffect = other.CombatUseEffect;
		CombatPrepareUseEffect = other.CombatPrepareUseEffect;
		GainExp = other.GainExp;
		ResourceAmount = other.ResourceAmount;
		HasGiftEvent = other.HasGiftEvent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MiscItem Duplicate(int templateId)
	{
		return new MiscItem((short)templateId, this);
	}
}
