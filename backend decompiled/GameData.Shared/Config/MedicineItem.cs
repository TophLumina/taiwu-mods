using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class MedicineItem : ConfigItem<MedicineItem, short>, ICombatItemConfig, IItemConfig
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

	public readonly string SpecialEffectDesc;

	public readonly short SpecialEffectId;

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

	public readonly bool CanUseMultiple;

	public readonly sbyte BreakBonusEffect;

	public readonly List<int> TaskLock;

	public readonly short Duration;

	public readonly EMedicineEffectType EffectType;

	public readonly EMedicineEffectSubType EffectSubType;

	public readonly short EffectThresholdValue;

	public readonly short EffectValue;

	public readonly short SideEffectValue;

	public readonly sbyte InjuryRecoveryTimes;

	public readonly sbyte RequiredMainAttributeType;

	public readonly sbyte RequiredMainAttributeValue;

	public readonly sbyte DamageStepBonus;

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

	public readonly sbyte WugType;

	public readonly sbyte WugGrowthType;

	public readonly string SpecialEffectClass;

	public readonly sbyte ConsumedFeatureMedals;

	public readonly sbyte MaxUseDistance;

	public readonly int UseFrame;

	public readonly sbyte BuffAndOtherMedicine;

	public readonly short ResistOfHotPoison;

	public readonly short ResistOfGloomyPoison;

	public readonly short ResistOfColdPoison;

	public readonly short ResistOfRedPoison;

	public readonly short ResistOfRottenPoison;

	public readonly short ResistOfIllusoryPoison;

	public readonly bool HasNormalEatingEffect;

	public readonly bool InstantAffect;

	public readonly short CombatUseEffect;

	public readonly short CombatPrepareUseEffect;

	public readonly bool IsVirtual;

	public MedicineItem Group
	{
		[return: MaybeNull]
		get
		{
			return Medicine.Instance.GetItemOrDefault(GroupId);
		}
	}

	public SpecialEffectItem SpecialEffect
	{
		[return: MaybeNull]
		get
		{
			return Config.SpecialEffect.Instance.GetItemOrDefault(SpecialEffectId);
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

	sbyte IItemConfig.MaxUseDistance => MaxUseDistance;

	short IItemConfig.Duration => Duration;

	int IItemConfig.BaseValue => BaseValue;

	List<int> IItemConfig.TaskLock => TaskLock;

	public sbyte PoisonType => EffectSubType.PoisonType();

	public sbyte DetoxPoisonType => EffectSubType.DetoxPoisonType();

	public sbyte ApplyPoisonType => EffectSubType.ApplyPoisonType();

	public sbyte DetoxWugType => EMedicineEffectSubTypeExtension.DetoxWugType(EffectType, SideEffectValue);

	public EMedicineEffectSubTypeExtension.Operate OperateType => EffectSubType.OperateType();

	public bool EffectIsPercentage => EffectSubType.IsPercentage();

	public bool EffectIsValue => EffectSubType.IsValue();

	public MedicineItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, string specialEffectDesc, short specialEffectId, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, bool canUseMultiple, sbyte breakBonusEffect, List<int> taskLock, short duration, EMedicineEffectType effectType, EMedicineEffectSubType effectSubType, short effectThresholdValue, short effectValue, short sideEffectValue, sbyte injuryRecoveryTimes, sbyte requiredMainAttributeType, sbyte requiredMainAttributeValue, sbyte damageStepBonus, short hitRateStrength, short hitRateTechnique, short hitRateSpeed, short hitRateMind, short penetrateOfOuter, short penetrateOfInner, short avoidRateStrength, short avoidRateTechnique, short avoidRateSpeed, short avoidRateMind, short penetrateResistOfOuter, short penetrateResistOfInner, short recoveryOfStance, short recoveryOfBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, sbyte wugType, sbyte wugGrowthType, string specialEffectClass, sbyte consumedFeatureMedals, sbyte maxUseDistance, int useFrame, sbyte buffAndOtherMedicine, short resistOfHotPoison, short resistOfGloomyPoison, short resistOfColdPoison, short resistOfRedPoison, short resistOfRottenPoison, short resistOfIllusoryPoison, bool hasNormalEatingEffect, bool instantAffect, short combatUseEffect, short combatPrepareUseEffect, bool isVirtual)
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
		SpecialEffectDesc = specialEffectDesc;
		SpecialEffectId = specialEffectId;
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
		CanUseMultiple = canUseMultiple;
		BreakBonusEffect = breakBonusEffect;
		TaskLock = taskLock;
		Duration = duration;
		EffectType = effectType;
		EffectSubType = effectSubType;
		EffectThresholdValue = effectThresholdValue;
		EffectValue = effectValue;
		SideEffectValue = sideEffectValue;
		InjuryRecoveryTimes = injuryRecoveryTimes;
		RequiredMainAttributeType = requiredMainAttributeType;
		RequiredMainAttributeValue = requiredMainAttributeValue;
		DamageStepBonus = damageStepBonus;
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
		WugType = wugType;
		WugGrowthType = wugGrowthType;
		SpecialEffectClass = specialEffectClass;
		ConsumedFeatureMedals = consumedFeatureMedals;
		MaxUseDistance = maxUseDistance;
		UseFrame = useFrame;
		BuffAndOtherMedicine = buffAndOtherMedicine;
		ResistOfHotPoison = resistOfHotPoison;
		ResistOfGloomyPoison = resistOfGloomyPoison;
		ResistOfColdPoison = resistOfColdPoison;
		ResistOfRedPoison = resistOfRedPoison;
		ResistOfRottenPoison = resistOfRottenPoison;
		ResistOfIllusoryPoison = resistOfIllusoryPoison;
		HasNormalEatingEffect = hasNormalEatingEffect;
		InstantAffect = instantAffect;
		CombatUseEffect = combatUseEffect;
		CombatPrepareUseEffect = combatPrepareUseEffect;
		IsVirtual = isVirtual;
	}

	public MedicineItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 8;
		ItemSubType = 0;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		SpecialEffectDesc = null;
		SpecialEffectId = 0;
		Transferable = true;
		Stackable = true;
		Wagerable = true;
		Refinable = false;
		Poisonable = true;
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
		ResourceType = 5;
		PreservationDuration = 36;
		CanUseMultiple = true;
		BreakBonusEffect = 0;
		TaskLock = new List<int>();
		Duration = 1;
		EffectType = EMedicineEffectType.Invalid;
		EffectSubType = EMedicineEffectSubType.Invalid;
		EffectThresholdValue = 0;
		EffectValue = 0;
		SideEffectValue = 0;
		InjuryRecoveryTimes = 0;
		RequiredMainAttributeType = -1;
		RequiredMainAttributeValue = 0;
		DamageStepBonus = 0;
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
		WugType = -1;
		WugGrowthType = -1;
		SpecialEffectClass = null;
		ConsumedFeatureMedals = -1;
		MaxUseDistance = -1;
		UseFrame = 60;
		BuffAndOtherMedicine = 0;
		ResistOfHotPoison = 0;
		ResistOfGloomyPoison = 0;
		ResistOfColdPoison = 0;
		ResistOfRedPoison = 0;
		ResistOfRottenPoison = 0;
		ResistOfIllusoryPoison = 0;
		HasNormalEatingEffect = true;
		InstantAffect = false;
		CombatUseEffect = 10;
		CombatPrepareUseEffect = 9;
		IsVirtual = false;
	}

	public MedicineItem(short templateId, MedicineItem other)
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
		SpecialEffectDesc = other.SpecialEffectDesc;
		SpecialEffectId = other.SpecialEffectId;
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
		CanUseMultiple = other.CanUseMultiple;
		BreakBonusEffect = other.BreakBonusEffect;
		TaskLock = other.TaskLock;
		Duration = other.Duration;
		EffectType = other.EffectType;
		EffectSubType = other.EffectSubType;
		EffectThresholdValue = other.EffectThresholdValue;
		EffectValue = other.EffectValue;
		SideEffectValue = other.SideEffectValue;
		InjuryRecoveryTimes = other.InjuryRecoveryTimes;
		RequiredMainAttributeType = other.RequiredMainAttributeType;
		RequiredMainAttributeValue = other.RequiredMainAttributeValue;
		DamageStepBonus = other.DamageStepBonus;
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
		WugType = other.WugType;
		WugGrowthType = other.WugGrowthType;
		SpecialEffectClass = other.SpecialEffectClass;
		ConsumedFeatureMedals = other.ConsumedFeatureMedals;
		MaxUseDistance = other.MaxUseDistance;
		UseFrame = other.UseFrame;
		BuffAndOtherMedicine = other.BuffAndOtherMedicine;
		ResistOfHotPoison = other.ResistOfHotPoison;
		ResistOfGloomyPoison = other.ResistOfGloomyPoison;
		ResistOfColdPoison = other.ResistOfColdPoison;
		ResistOfRedPoison = other.ResistOfRedPoison;
		ResistOfRottenPoison = other.ResistOfRottenPoison;
		ResistOfIllusoryPoison = other.ResistOfIllusoryPoison;
		HasNormalEatingEffect = other.HasNormalEatingEffect;
		InstantAffect = other.InstantAffect;
		CombatUseEffect = other.CombatUseEffect;
		CombatPrepareUseEffect = other.CombatPrepareUseEffect;
		IsVirtual = other.IsVirtual;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MedicineItem Duplicate(int templateId)
	{
		return new MedicineItem((short)templateId, this);
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

	public int GetEffectValue(int fullRangeValue = 100)
	{
		return EMedicineEffectSubTypeExtension.EffectValue(fullRangeValue, EffectValue, EffectIsPercentage);
	}

	public int GetCharacterPropertyBonusValue(ECharacterPropertyReferencedType key)
	{
		if (!EffectIsValue && key < ECharacterPropertyReferencedType.ResistOfHotPoison)
		{
			return 0;
		}
		return GetCharacterPropertyBonusInt(key);
	}

	public int GetCharacterPropertyBonusPercentage(ECharacterPropertyReferencedType key)
	{
		bool flag = EffectIsPercentage;
		if (flag)
		{
			bool flag2 = ((key < ECharacterPropertyReferencedType.ResistOfHotPoison || key > ECharacterPropertyReferencedType.ResistOfIllusoryPoison) ? true : false);
			flag = flag2;
		}
		if (!flag)
		{
			return 0;
		}
		return GetCharacterPropertyBonusInt(key);
	}

	public bool HasCharacterPropertyBonus(ECharacterPropertyReferencedType key)
	{
		if (key.TryParsePoisonResist(out var poisonType))
		{
			return DetoxPoisonType == poisonType;
		}
		return GetCharacterPropertyBonusInt(key) > 0;
	}
}
