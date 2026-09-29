using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace Config;

[Serializable]
public class WeaponItem : ConfigItem<WeaponItem, short>, IItemConfig
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

	public readonly PoisonsAndLevels InnatePoisons;

	public readonly List<PropertyAndValue> RequiredCharacterProperties;

	public readonly sbyte WeaponAction;

	public readonly string CombatPictureR;

	public readonly string CombatPictureL;

	public readonly string IdleAni;

	public readonly string ForwardAni;

	public readonly string BackwardAni;

	public readonly string FastForwardAni;

	public readonly string FastBackwardAni;

	public readonly string[] AvoidAnis;

	public readonly string[] HittedAnis;

	public readonly string FatalParticle;

	public readonly string TeammateCmdAniPostfix;

	public readonly List<string> BlockAnis;

	public readonly List<string> BlockParticles;

	public readonly List<string> BlockSounds;

	public readonly List<string> HitSounds;

	public readonly string SwingSoundsSuffix;

	public readonly bool PlayArmorHitSound;

	public readonly int UnlockEffect;

	public readonly List<sbyte> Tricks;

	public readonly List<TrickDistanceAdjust> TrickDistanceAdjusts;

	public readonly bool RandomTrick;

	public readonly bool CanChangeTrick;

	public readonly short ChangeTrickPercent;

	public readonly short PursueAttackFactor;

	public readonly sbyte AttackPreparePointCost;

	public readonly int BaseStartupFrames;

	public readonly int BaseRecoveryFrames;

	public readonly short MinDistance;

	public readonly short MaxDistance;

	public readonly HitOrAvoidShorts BaseHitFactors;

	public readonly short BasePenetrationFactor;

	public readonly short StanceIncrement;

	public readonly sbyte DefaultInnerRatio;

	public readonly sbyte InnerRatioAdjustRange;

	public readonly short EquipmentCombatPowerValueFactor;

	public WeaponItem Group
	{
		[return: MaybeNull]
		get
		{
			return Weapon.Instance.GetItemOrDefault(GroupId);
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

	public WeaponItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, bool allowRawCreate, bool allowCrippledCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, short equipmentMasteryId, short baseEquipmentAttack, short baseEquipmentDefense, PoisonsAndLevels innatePoisons, List<PropertyAndValue> requiredCharacterProperties, sbyte weaponAction, string combatPictureR, string combatPictureL, string idleAni, string forwardAni, string backwardAni, string fastForwardAni, string fastBackwardAni, string[] avoidAnis, string[] hittedAnis, string fatalParticle, string teammateCmdAniPostfix, List<string> blockAnis, List<string> blockParticles, List<string> blockSounds, List<string> hitSounds, string swingSoundsSuffix, bool playArmorHitSound, int unlockEffect, List<sbyte> tricks, List<TrickDistanceAdjust> trickDistanceAdjusts, bool randomTrick, bool canChangeTrick, short changeTrickPercent, short pursueAttackFactor, sbyte attackPreparePointCost, int baseStartupFrames, int baseRecoveryFrames, short minDistance, short maxDistance, HitOrAvoidShorts baseHitFactors, short basePenetrationFactor, short stanceIncrement, sbyte defaultInnerRatio, sbyte innerRatioAdjustRange, short equipmentCombatPowerValueFactor)
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
		InnatePoisons = innatePoisons;
		RequiredCharacterProperties = requiredCharacterProperties;
		WeaponAction = weaponAction;
		CombatPictureR = combatPictureR;
		CombatPictureL = combatPictureL;
		IdleAni = idleAni;
		ForwardAni = forwardAni;
		BackwardAni = backwardAni;
		FastForwardAni = fastForwardAni;
		FastBackwardAni = fastBackwardAni;
		AvoidAnis = avoidAnis;
		HittedAnis = hittedAnis;
		FatalParticle = fatalParticle;
		TeammateCmdAniPostfix = teammateCmdAniPostfix;
		BlockAnis = blockAnis;
		BlockParticles = blockParticles;
		BlockSounds = blockSounds;
		HitSounds = hitSounds;
		SwingSoundsSuffix = swingSoundsSuffix;
		PlayArmorHitSound = playArmorHitSound;
		UnlockEffect = unlockEffect;
		Tricks = tricks;
		TrickDistanceAdjusts = trickDistanceAdjusts;
		RandomTrick = randomTrick;
		CanChangeTrick = canChangeTrick;
		ChangeTrickPercent = changeTrickPercent;
		PursueAttackFactor = pursueAttackFactor;
		AttackPreparePointCost = attackPreparePointCost;
		BaseStartupFrames = baseStartupFrames;
		BaseRecoveryFrames = baseRecoveryFrames;
		MinDistance = minDistance;
		MaxDistance = maxDistance;
		BaseHitFactors = baseHitFactors;
		BasePenetrationFactor = basePenetrationFactor;
		StanceIncrement = stanceIncrement;
		DefaultInnerRatio = defaultInnerRatio;
		InnerRatioAdjustRange = innerRatioAdjustRange;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	public WeaponItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 0;
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
		InnatePoisons = new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		RequiredCharacterProperties = new List<PropertyAndValue>();
		WeaponAction = 0;
		CombatPictureR = null;
		CombatPictureL = null;
		IdleAni = null;
		ForwardAni = null;
		BackwardAni = null;
		FastForwardAni = null;
		FastBackwardAni = null;
		AvoidAnis = null;
		HittedAnis = null;
		FatalParticle = null;
		TeammateCmdAniPostfix = null;
		BlockAnis = new List<string> { "" };
		BlockParticles = new List<string> { "" };
		BlockSounds = new List<string> { "" };
		HitSounds = new List<string> { "" };
		SwingSoundsSuffix = null;
		PlayArmorHitSound = true;
		UnlockEffect = 0;
		Tricks = null;
		TrickDistanceAdjusts = new List<TrickDistanceAdjust>();
		RandomTrick = true;
		CanChangeTrick = true;
		ChangeTrickPercent = 100;
		PursueAttackFactor = 0;
		AttackPreparePointCost = 0;
		BaseStartupFrames = 36;
		BaseRecoveryFrames = 72;
		MinDistance = 20;
		MaxDistance = 50;
		BaseHitFactors = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		BasePenetrationFactor = 0;
		StanceIncrement = 30;
		DefaultInnerRatio = 0;
		InnerRatioAdjustRange = 15;
		EquipmentCombatPowerValueFactor = 100;
	}

	public WeaponItem(short templateId, WeaponItem other)
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
		InnatePoisons = other.InnatePoisons;
		RequiredCharacterProperties = other.RequiredCharacterProperties;
		WeaponAction = other.WeaponAction;
		CombatPictureR = other.CombatPictureR;
		CombatPictureL = other.CombatPictureL;
		IdleAni = other.IdleAni;
		ForwardAni = other.ForwardAni;
		BackwardAni = other.BackwardAni;
		FastForwardAni = other.FastForwardAni;
		FastBackwardAni = other.FastBackwardAni;
		AvoidAnis = other.AvoidAnis;
		HittedAnis = other.HittedAnis;
		FatalParticle = other.FatalParticle;
		TeammateCmdAniPostfix = other.TeammateCmdAniPostfix;
		BlockAnis = other.BlockAnis;
		BlockParticles = other.BlockParticles;
		BlockSounds = other.BlockSounds;
		HitSounds = other.HitSounds;
		SwingSoundsSuffix = other.SwingSoundsSuffix;
		PlayArmorHitSound = other.PlayArmorHitSound;
		UnlockEffect = other.UnlockEffect;
		Tricks = other.Tricks;
		TrickDistanceAdjusts = other.TrickDistanceAdjusts;
		RandomTrick = other.RandomTrick;
		CanChangeTrick = other.CanChangeTrick;
		ChangeTrickPercent = other.ChangeTrickPercent;
		PursueAttackFactor = other.PursueAttackFactor;
		AttackPreparePointCost = other.AttackPreparePointCost;
		BaseStartupFrames = other.BaseStartupFrames;
		BaseRecoveryFrames = other.BaseRecoveryFrames;
		MinDistance = other.MinDistance;
		MaxDistance = other.MaxDistance;
		BaseHitFactors = other.BaseHitFactors;
		BasePenetrationFactor = other.BasePenetrationFactor;
		StanceIncrement = other.StanceIncrement;
		DefaultInnerRatio = other.DefaultInnerRatio;
		InnerRatioAdjustRange = other.InnerRatioAdjustRange;
		EquipmentCombatPowerValueFactor = other.EquipmentCombatPowerValueFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override WeaponItem Duplicate(int templateId)
	{
		return new WeaponItem((short)templateId, this);
	}
}
