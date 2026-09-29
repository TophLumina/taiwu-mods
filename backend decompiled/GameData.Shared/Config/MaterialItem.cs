using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace Config;

[Serializable]
public class MaterialItem : ConfigItem<MaterialItem, short>, ICombatItemConfig, IItemConfig
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

	public readonly EMaterialProperty Property;

	public readonly sbyte BreakBonusEffect;

	public readonly List<int> TaskLock;

	public readonly sbyte RefiningEffect;

	public readonly short ResourceAmount;

	public readonly sbyte RequiredLifeSkillType;

	public readonly short RequiredAttainment;

	public readonly short RequiredResourceAmount;

	public readonly List<short> CraftableItemTypes;

	public readonly PoisonsAndLevels InnatePoisons;

	public readonly List<PresetInventoryItem> DisassembleResultItemList;

	public readonly short DisassembleResultCount;

	public readonly short Duration;

	public readonly short BaseMaxHealthDelta;

	public readonly EMedicineEffectType PrimaryEffectType;

	public readonly EMedicineEffectSubType PrimaryEffectSubType;

	public readonly short PrimaryEffectThresholdValue;

	public readonly short PrimaryEffectValue;

	public readonly sbyte PrimaryInjuryRecoveryTimes;

	public readonly bool PrimaryRecoverAllInjuries;

	public readonly EMedicineEffectType SecondaryEffectType;

	public readonly EMedicineEffectSubType SecondaryEffectSubType;

	public readonly short SecondaryEffectThresholdValue;

	public readonly short SecondaryEffectValue;

	public readonly sbyte SecondaryInjuryRecoveryTimes;

	public readonly bool SecondaryRecoverAllInjuries;

	public readonly short HitRateStrength;

	public readonly short HitRateTechnique;

	public readonly short HitRateSpeed;

	public readonly short HitRateMind;

	public readonly short PenetrateOfOuter;

	public readonly short PenetrateOfInner;

	public readonly short AvoidRateStrength;

	public readonly short AvoidRateTechnique;

	public readonly short AvoidRateSpeed;

	public readonly short AvoidRateMind;

	public readonly short PenetrateResistOfOuter;

	public readonly short PenetrateResistOfInner;

	public readonly short RecoveryOfStance;

	public readonly short RecoveryOfBreath;

	public readonly short MoveSpeed;

	public readonly short RecoveryOfFlaw;

	public readonly short CastSpeed;

	public readonly short RecoveryOfBlockedAcupoint;

	public readonly short WeaponSwitchSpeed;

	public readonly short AttackSpeed;

	public readonly short InnerRatio;

	public readonly short RecoveryOfQiDisorder;

	public readonly short ResistOfHotPoison;

	public readonly short ResistOfGloomyPoison;

	public readonly short ResistOfColdPoison;

	public readonly short ResistOfRedPoison;

	public readonly short ResistOfRottenPoison;

	public readonly short ResistOfIllusoryPoison;

	public readonly sbyte ConsumedFeatureMedals;

	public readonly int UseFrame;

	public readonly EMaterialFilterType FilterType;

	public readonly EMaterialFilterHardness FilterHardness;

	public MaterialItem Group
	{
		[return: MaybeNull]
		get
		{
			return Material.Instance.GetItemOrDefault(GroupId);
		}
	}

	int ICombatItemConfig.ConsumedFeatureMedals => ConsumedFeatureMedals;

	int ICombatItemConfig.UseFrame => UseFrame;

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	short IItemConfig.Duration => Duration;

	int IItemConfig.BaseValue => BaseValue;

	List<int> IItemConfig.TaskLock => TaskLock;

	public MaterialItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, EMaterialProperty property, sbyte breakBonusEffect, List<int> taskLock, sbyte refiningEffect, short resourceAmount, sbyte requiredLifeSkillType, short requiredAttainment, short requiredResourceAmount, List<short> craftableItemTypes, PoisonsAndLevels innatePoisons, List<PresetInventoryItem> disassembleResultItemList, short disassembleResultCount, short duration, short baseMaxHealthDelta, EMedicineEffectType primaryEffectType, EMedicineEffectSubType primaryEffectSubType, short primaryEffectThresholdValue, short primaryEffectValue, sbyte primaryInjuryRecoveryTimes, bool primaryRecoverAllInjuries, EMedicineEffectType secondaryEffectType, EMedicineEffectSubType secondaryEffectSubType, short secondaryEffectThresholdValue, short secondaryEffectValue, sbyte secondaryInjuryRecoveryTimes, bool secondaryRecoverAllInjuries, short hitRateStrength, short hitRateTechnique, short hitRateSpeed, short hitRateMind, short penetrateOfOuter, short penetrateOfInner, short avoidRateStrength, short avoidRateTechnique, short avoidRateSpeed, short avoidRateMind, short penetrateResistOfOuter, short penetrateResistOfInner, short recoveryOfStance, short recoveryOfBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, short resistOfHotPoison, short resistOfGloomyPoison, short resistOfColdPoison, short resistOfRedPoison, short resistOfRottenPoison, short resistOfIllusoryPoison, sbyte consumedFeatureMedals, int useFrame, EMaterialFilterType filterType, EMaterialFilterHardness filterHardness)
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
		Property = property;
		BreakBonusEffect = breakBonusEffect;
		TaskLock = taskLock;
		RefiningEffect = refiningEffect;
		ResourceAmount = resourceAmount;
		RequiredLifeSkillType = requiredLifeSkillType;
		RequiredAttainment = requiredAttainment;
		RequiredResourceAmount = requiredResourceAmount;
		CraftableItemTypes = craftableItemTypes;
		InnatePoisons = innatePoisons;
		DisassembleResultItemList = disassembleResultItemList;
		DisassembleResultCount = disassembleResultCount;
		Duration = duration;
		BaseMaxHealthDelta = baseMaxHealthDelta;
		PrimaryEffectType = primaryEffectType;
		PrimaryEffectSubType = primaryEffectSubType;
		PrimaryEffectThresholdValue = primaryEffectThresholdValue;
		PrimaryEffectValue = primaryEffectValue;
		PrimaryInjuryRecoveryTimes = primaryInjuryRecoveryTimes;
		PrimaryRecoverAllInjuries = primaryRecoverAllInjuries;
		SecondaryEffectType = secondaryEffectType;
		SecondaryEffectSubType = secondaryEffectSubType;
		SecondaryEffectThresholdValue = secondaryEffectThresholdValue;
		SecondaryEffectValue = secondaryEffectValue;
		SecondaryInjuryRecoveryTimes = secondaryInjuryRecoveryTimes;
		SecondaryRecoverAllInjuries = secondaryRecoverAllInjuries;
		HitRateStrength = hitRateStrength;
		HitRateTechnique = hitRateTechnique;
		HitRateSpeed = hitRateSpeed;
		HitRateMind = hitRateMind;
		PenetrateOfOuter = penetrateOfOuter;
		PenetrateOfInner = penetrateOfInner;
		AvoidRateStrength = avoidRateStrength;
		AvoidRateTechnique = avoidRateTechnique;
		AvoidRateSpeed = avoidRateSpeed;
		AvoidRateMind = avoidRateMind;
		PenetrateResistOfOuter = penetrateResistOfOuter;
		PenetrateResistOfInner = penetrateResistOfInner;
		RecoveryOfStance = recoveryOfStance;
		RecoveryOfBreath = recoveryOfBreath;
		MoveSpeed = moveSpeed;
		RecoveryOfFlaw = recoveryOfFlaw;
		CastSpeed = castSpeed;
		RecoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = weaponSwitchSpeed;
		AttackSpeed = attackSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		ResistOfHotPoison = resistOfHotPoison;
		ResistOfGloomyPoison = resistOfGloomyPoison;
		ResistOfColdPoison = resistOfColdPoison;
		ResistOfRedPoison = resistOfRedPoison;
		ResistOfRottenPoison = resistOfRottenPoison;
		ResistOfIllusoryPoison = resistOfIllusoryPoison;
		ConsumedFeatureMedals = consumedFeatureMedals;
		UseFrame = useFrame;
		FilterType = filterType;
		FilterHardness = filterHardness;
	}

	public MaterialItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 5;
		ItemSubType = 0;
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
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 15;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 50;
		GiftLevel = 8;
		AllowRandomCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 36;
		Property = EMaterialProperty.Invalid;
		BreakBonusEffect = 0;
		TaskLock = new List<int>();
		RefiningEffect = 0;
		ResourceAmount = 0;
		RequiredLifeSkillType = 0;
		RequiredAttainment = 0;
		RequiredResourceAmount = 0;
		CraftableItemTypes = new List<short>();
		InnatePoisons = new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		DisassembleResultItemList = new List<PresetInventoryItem>();
		DisassembleResultCount = 0;
		Duration = 1;
		BaseMaxHealthDelta = 0;
		PrimaryEffectType = EMedicineEffectType.Invalid;
		PrimaryEffectSubType = EMedicineEffectSubType.Invalid;
		PrimaryEffectThresholdValue = 0;
		PrimaryEffectValue = 0;
		PrimaryInjuryRecoveryTimes = 0;
		PrimaryRecoverAllInjuries = false;
		SecondaryEffectType = EMedicineEffectType.Invalid;
		SecondaryEffectSubType = EMedicineEffectSubType.Invalid;
		SecondaryEffectThresholdValue = 0;
		SecondaryEffectValue = 0;
		SecondaryInjuryRecoveryTimes = 0;
		SecondaryRecoverAllInjuries = false;
		HitRateStrength = 0;
		HitRateTechnique = 0;
		HitRateSpeed = 0;
		HitRateMind = 0;
		PenetrateOfOuter = 0;
		PenetrateOfInner = 0;
		AvoidRateStrength = 0;
		AvoidRateTechnique = 0;
		AvoidRateSpeed = 0;
		AvoidRateMind = 0;
		PenetrateResistOfOuter = 0;
		PenetrateResistOfInner = 0;
		RecoveryOfStance = 0;
		RecoveryOfBreath = 0;
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		ResistOfHotPoison = 0;
		ResistOfGloomyPoison = 0;
		ResistOfColdPoison = 0;
		ResistOfRedPoison = 0;
		ResistOfRottenPoison = 0;
		ResistOfIllusoryPoison = 0;
		ConsumedFeatureMedals = -1;
		UseFrame = 60;
		FilterType = EMaterialFilterType.Invalid;
		FilterHardness = EMaterialFilterHardness.Invalid;
	}

	public MaterialItem(short templateId, MaterialItem other)
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
		Property = other.Property;
		BreakBonusEffect = other.BreakBonusEffect;
		TaskLock = other.TaskLock;
		RefiningEffect = other.RefiningEffect;
		ResourceAmount = other.ResourceAmount;
		RequiredLifeSkillType = other.RequiredLifeSkillType;
		RequiredAttainment = other.RequiredAttainment;
		RequiredResourceAmount = other.RequiredResourceAmount;
		CraftableItemTypes = other.CraftableItemTypes;
		InnatePoisons = other.InnatePoisons;
		DisassembleResultItemList = other.DisassembleResultItemList;
		DisassembleResultCount = other.DisassembleResultCount;
		Duration = other.Duration;
		BaseMaxHealthDelta = other.BaseMaxHealthDelta;
		PrimaryEffectType = other.PrimaryEffectType;
		PrimaryEffectSubType = other.PrimaryEffectSubType;
		PrimaryEffectThresholdValue = other.PrimaryEffectThresholdValue;
		PrimaryEffectValue = other.PrimaryEffectValue;
		PrimaryInjuryRecoveryTimes = other.PrimaryInjuryRecoveryTimes;
		PrimaryRecoverAllInjuries = other.PrimaryRecoverAllInjuries;
		SecondaryEffectType = other.SecondaryEffectType;
		SecondaryEffectSubType = other.SecondaryEffectSubType;
		SecondaryEffectThresholdValue = other.SecondaryEffectThresholdValue;
		SecondaryEffectValue = other.SecondaryEffectValue;
		SecondaryInjuryRecoveryTimes = other.SecondaryInjuryRecoveryTimes;
		SecondaryRecoverAllInjuries = other.SecondaryRecoverAllInjuries;
		HitRateStrength = other.HitRateStrength;
		HitRateTechnique = other.HitRateTechnique;
		HitRateSpeed = other.HitRateSpeed;
		HitRateMind = other.HitRateMind;
		PenetrateOfOuter = other.PenetrateOfOuter;
		PenetrateOfInner = other.PenetrateOfInner;
		AvoidRateStrength = other.AvoidRateStrength;
		AvoidRateTechnique = other.AvoidRateTechnique;
		AvoidRateSpeed = other.AvoidRateSpeed;
		AvoidRateMind = other.AvoidRateMind;
		PenetrateResistOfOuter = other.PenetrateResistOfOuter;
		PenetrateResistOfInner = other.PenetrateResistOfInner;
		RecoveryOfStance = other.RecoveryOfStance;
		RecoveryOfBreath = other.RecoveryOfBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		ResistOfHotPoison = other.ResistOfHotPoison;
		ResistOfGloomyPoison = other.ResistOfGloomyPoison;
		ResistOfColdPoison = other.ResistOfColdPoison;
		ResistOfRedPoison = other.ResistOfRedPoison;
		ResistOfRottenPoison = other.ResistOfRottenPoison;
		ResistOfIllusoryPoison = other.ResistOfIllusoryPoison;
		ConsumedFeatureMedals = other.ConsumedFeatureMedals;
		UseFrame = other.UseFrame;
		FilterType = other.FilterType;
		FilterHardness = other.FilterHardness;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MaterialItem Duplicate(int templateId)
	{
		return new MaterialItem((short)templateId, this);
	}

	public int GetCharacterPropertyBonusInt(ECharacterPropertyReferencedType key)
	{
		return key switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => HitRateStrength, 
			ECharacterPropertyReferencedType.HitRateTechnique => HitRateTechnique, 
			ECharacterPropertyReferencedType.HitRateSpeed => HitRateSpeed, 
			ECharacterPropertyReferencedType.HitRateMind => HitRateMind, 
			ECharacterPropertyReferencedType.PenetrateOfOuter => PenetrateOfOuter, 
			ECharacterPropertyReferencedType.PenetrateOfInner => PenetrateOfInner, 
			ECharacterPropertyReferencedType.AvoidRateStrength => AvoidRateStrength, 
			ECharacterPropertyReferencedType.AvoidRateTechnique => AvoidRateTechnique, 
			ECharacterPropertyReferencedType.AvoidRateSpeed => AvoidRateSpeed, 
			ECharacterPropertyReferencedType.AvoidRateMind => AvoidRateMind, 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => PenetrateResistOfOuter, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => PenetrateResistOfInner, 
			ECharacterPropertyReferencedType.RecoveryOfStance => RecoveryOfStance, 
			ECharacterPropertyReferencedType.RecoveryOfBreath => RecoveryOfBreath, 
			ECharacterPropertyReferencedType.MoveSpeed => MoveSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfFlaw => RecoveryOfFlaw, 
			ECharacterPropertyReferencedType.CastSpeed => CastSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint => RecoveryOfBlockedAcupoint, 
			ECharacterPropertyReferencedType.WeaponSwitchSpeed => WeaponSwitchSpeed, 
			ECharacterPropertyReferencedType.AttackSpeed => AttackSpeed, 
			ECharacterPropertyReferencedType.InnerRatio => InnerRatio, 
			ECharacterPropertyReferencedType.RecoveryOfQiDisorder => RecoveryOfQiDisorder, 
			ECharacterPropertyReferencedType.ResistOfHotPoison => ResistOfHotPoison, 
			ECharacterPropertyReferencedType.ResistOfGloomyPoison => ResistOfGloomyPoison, 
			ECharacterPropertyReferencedType.ResistOfColdPoison => ResistOfColdPoison, 
			ECharacterPropertyReferencedType.ResistOfRedPoison => ResistOfRedPoison, 
			ECharacterPropertyReferencedType.ResistOfRottenPoison => ResistOfRottenPoison, 
			ECharacterPropertyReferencedType.ResistOfIllusoryPoison => ResistOfIllusoryPoison, 
			_ => 0, 
		};
	}
}
