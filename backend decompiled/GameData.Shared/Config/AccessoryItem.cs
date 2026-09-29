using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class AccessoryItem : ConfigItem<AccessoryItem, short>, IItemConfig
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

	public readonly sbyte DropRate;

	public readonly bool IsSpecial;

	public readonly sbyte ResourceType;

	public readonly short PreservationDuration;

	public readonly short MakeItemSubType;

	public readonly List<int> TaskLock;

	public readonly sbyte EquipmentType;

	public readonly short EquipmentEffectId;

	public readonly int MysteryEffectId;

	public readonly List<PropertyAndValue> RequiredCharacterProperties;

	public readonly short DropRateBonus;

	public readonly short BaseCaptureRateBonus;

	public readonly short BaseExploreBonusRate;

	public readonly short MaxInventoryLoadBonus;

	public readonly short Strength;

	public readonly short Dexterity;

	public readonly short Concentration;

	public readonly short Vitality;

	public readonly short Energy;

	public readonly short Intelligence;

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

	public readonly sbyte BonusCombatSkillSect;

	public readonly int CombatSkillAddMaxPower;

	public readonly short EquipmentCombatPowerValueFactor;

	public AccessoryItem Group
	{
		[return: MaybeNull]
		get
		{
			return Accessory.Instance.GetItemOrDefault(GroupId);
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

	public MysteryEffectItem MysteryEffect
	{
		[return: MaybeNull]
		get
		{
			return Config.MysteryEffect.Instance.GetItemOrDefault(MysteryEffectId);
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

	int IItemConfig.MysteryEffectId => MysteryEffectId;

	List<int> IItemConfig.TaskLock => TaskLock;

	short IItemConfig.MakeItemSubType => MakeItemSubType;

	public AccessoryItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, bool allowRawCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, int mysteryEffectId, List<PropertyAndValue> requiredCharacterProperties, short dropRateBonus, short baseCaptureRateBonus, short baseExploreBonusRate, short maxInventoryLoadBonus, short strength, short dexterity, short concentration, short vitality, short energy, short intelligence, short hitRateStrength, short hitRateTechnique, short hitRateSpeed, short hitRateMind, short penetrateOfOuter, short penetrateOfInner, short avoidRateStrength, short avoidRateTechnique, short avoidRateSpeed, short avoidRateMind, short penetrateResistOfOuter, short penetrateResistOfInner, short recoveryOfStance, short recoveryOfBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, short resistOfHotPoison, short resistOfGloomyPoison, short resistOfColdPoison, short resistOfRedPoison, short resistOfRottenPoison, short resistOfIllusoryPoison, sbyte bonusCombatSkillSect, int combatSkillAddMaxPower, short equipmentCombatPowerValueFactor)
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
		DropRate = dropRate;
		IsSpecial = isSpecial;
		ResourceType = resourceType;
		PreservationDuration = preservationDuration;
		MakeItemSubType = makeItemSubType;
		TaskLock = taskLock;
		EquipmentType = equipmentType;
		EquipmentEffectId = equipmentEffectId;
		MysteryEffectId = mysteryEffectId;
		RequiredCharacterProperties = requiredCharacterProperties;
		DropRateBonus = dropRateBonus;
		BaseCaptureRateBonus = baseCaptureRateBonus;
		BaseExploreBonusRate = baseExploreBonusRate;
		MaxInventoryLoadBonus = maxInventoryLoadBonus;
		Strength = strength;
		Dexterity = dexterity;
		Concentration = concentration;
		Vitality = vitality;
		Energy = energy;
		Intelligence = intelligence;
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
		BonusCombatSkillSect = bonusCombatSkillSect;
		CombatSkillAddMaxPower = combatSkillAddMaxPower;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	public AccessoryItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 2;
		ItemSubType = 200;
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
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 36;
		MakeItemSubType = 0;
		TaskLock = new List<int>();
		EquipmentType = 6;
		EquipmentEffectId = 0;
		MysteryEffectId = 0;
		RequiredCharacterProperties = new List<PropertyAndValue>();
		DropRateBonus = 0;
		BaseCaptureRateBonus = 0;
		BaseExploreBonusRate = 0;
		MaxInventoryLoadBonus = 0;
		Strength = 0;
		Dexterity = 0;
		Concentration = 0;
		Vitality = 0;
		Energy = 0;
		Intelligence = 0;
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
		BonusCombatSkillSect = 0;
		CombatSkillAddMaxPower = 0;
		EquipmentCombatPowerValueFactor = 50;
	}

	public AccessoryItem(short templateId, AccessoryItem other)
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
		DropRate = other.DropRate;
		IsSpecial = other.IsSpecial;
		ResourceType = other.ResourceType;
		PreservationDuration = other.PreservationDuration;
		MakeItemSubType = other.MakeItemSubType;
		TaskLock = other.TaskLock;
		EquipmentType = other.EquipmentType;
		EquipmentEffectId = other.EquipmentEffectId;
		MysteryEffectId = other.MysteryEffectId;
		RequiredCharacterProperties = other.RequiredCharacterProperties;
		DropRateBonus = other.DropRateBonus;
		BaseCaptureRateBonus = other.BaseCaptureRateBonus;
		BaseExploreBonusRate = other.BaseExploreBonusRate;
		MaxInventoryLoadBonus = other.MaxInventoryLoadBonus;
		Strength = other.Strength;
		Dexterity = other.Dexterity;
		Concentration = other.Concentration;
		Vitality = other.Vitality;
		Energy = other.Energy;
		Intelligence = other.Intelligence;
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
		BonusCombatSkillSect = other.BonusCombatSkillSect;
		CombatSkillAddMaxPower = other.CombatSkillAddMaxPower;
		EquipmentCombatPowerValueFactor = other.EquipmentCombatPowerValueFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AccessoryItem Duplicate(int templateId)
	{
		return new AccessoryItem((short)templateId, this);
	}

	public int GetCharacterPropertyBonusInt(ECharacterPropertyReferencedType key)
	{
		return key switch
		{
			ECharacterPropertyReferencedType.Strength => Strength, 
			ECharacterPropertyReferencedType.Dexterity => Dexterity, 
			ECharacterPropertyReferencedType.Concentration => Concentration, 
			ECharacterPropertyReferencedType.Vitality => Vitality, 
			ECharacterPropertyReferencedType.Energy => Energy, 
			ECharacterPropertyReferencedType.Intelligence => Intelligence, 
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
