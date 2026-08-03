using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using Config.ConfigCells.Character;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Dependencies;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Weapon : EquipmentBase, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint TemplateId_Offset = 4u;

		public const int TemplateId_Size = 2;

		public const uint MaxDurability_Offset = 6u;

		public const int MaxDurability_Size = 2;

		public const uint EquipmentEffectId_Offset = 8u;

		public const int EquipmentEffectId_Size = 2;

		public const uint CurrDurability_Offset = 10u;

		public const int CurrDurability_Size = 2;

		public const uint ModificationState_Offset = 12u;

		public const int ModificationState_Size = 1;

		public const uint EquippedCharId_Offset = 13u;

		public const int EquippedCharId_Size = 4;

		public const uint MaterialResources_Offset = 17u;

		public const int MaterialResources_Size = 12;
	}

	[CollectionObjectField(true, true, false, false, false)]
	private List<sbyte> _tricks;

	[CollectionObjectField(false, false, true, false, false)]
	private short _penetrationFactor;

	[CollectionObjectField(false, false, true, false, false)]
	private short _equipmentAttack;

	[CollectionObjectField(false, false, true, false, false)]
	private short _equipmentDefense;

	[CollectionObjectField(false, false, true, false, false)]
	private int _weight;

	public const int FixedSize = 29;

	public const int DynamicCount = 1;

	private SpinLock _spinLock = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly ushort[] ArchiveFieldIds = new ushort[9] { 0, 1, 2, 3, 5, 6, 7, 8, 4 };

	private static readonly int[] FixedArchiveFieldSizes = new int[8] { 4, 2, 2, 2, 2, 1, 4, 12 };

	[ObjectCollectionDependency(6, 0, new ushort[] { 6, 8 }, Scope = InfluenceScope.Self)]
	private short CalcPenetrationFactor()
	{
		int value = GetBasePenetrationFactor();
		value = value * GetMaterialResourceBonusValuePercentage(2) / 100;
		if (!ModificationStateHelper.IsActive(ModificationState, 2))
		{
			return (short)value;
		}
		int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetWeaponPropertyBonus(ERefiningEffectWeaponType.Penetration);
		refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
		value += (short)refineBonus;
		return (short)value;
	}

	[ObjectCollectionDependency(6, 0, new ushort[] { 6, 3, 8 }, Scope = InfluenceScope.Self)]
	private short CalcEquipmentAttack()
	{
		int value = GetBaseEquipmentAttack();
		value = value * GetMaterialResourceBonusValuePercentage(0) / 100;
		value = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value, (EquipmentEffectItem x) => x.EquipmentAttackChange);
		if (!ModificationStateHelper.IsActive(ModificationState, 2))
		{
			return (short)value;
		}
		int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetWeaponPropertyBonus(ERefiningEffectWeaponType.EquipmentAttack);
		refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
		value = value * (100 + refineBonus) / 100;
		return (short)value;
	}

	[ObjectCollectionDependency(6, 0, new ushort[] { 6, 3, 8 }, Scope = InfluenceScope.Self)]
	private short CalcEquipmentDefense()
	{
		int value = GetBaseEquipmentDefense();
		value = value * GetMaterialResourceBonusValuePercentage(1) / 100;
		value = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value, (EquipmentEffectItem x) => x.EquipmentDefenseChange);
		if (!ModificationStateHelper.IsActive(ModificationState, 2))
		{
			return (short)value;
		}
		int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetWeaponPropertyBonus(ERefiningEffectWeaponType.EquipmentDefense);
		refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
		value = value * (100 + refineBonus) / 100;
		return (short)value;
	}

	[ObjectCollectionDependency(6, 0, new ushort[] { 6, 3, 8 }, Scope = InfluenceScope.Self)]
	private int CalcWeight()
	{
		int value = GetBaseWeight();
		value = value * (170 - GetMaterialResourceBonusValuePercentage(4)) / 100;
		value = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value, (EquipmentEffectItem x) => x.WeightChange);
		if (!ModificationStateHelper.IsActive(ModificationState, 2))
		{
			return value;
		}
		int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetWeaponPropertyBonus(ERefiningEffectWeaponType.Weight);
		refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
		return value * (100 + refineBonus) / 100;
	}

	[ObjectCollectionDependency(6, 0, new ushort[] { 7, 3, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 79, 100, 89, 97, 99 }, Scope = InfluenceScope.WeaponsOfTheChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 27, 28 }, Scope = InfluenceScope.WeaponsOfTheCharacterAffectedByTheSpecialEffects)]
	private short CalcEquippedPower()
	{
		GameData.Domains.Character.Character element;
		return (short)(DomainManager.Character.TryGetElement_Objects(EquippedCharId, out element) ? DomainManager.Character.GetItemRequirementsPower(EquippedCharId, GetItemKey()) : 0);
	}

	public Weapon(IRandomSource random, short templateId, int itemId)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
		if (GetRandomTrick())
		{
			CollectionUtils.Shuffle(random, _tricks);
		}
	}

	public override int GetFavorabilityChange()
	{
		int value = base.GetFavorabilityChange();
		if (EquipmentEffectId >= 0)
		{
			EquipmentEffectItem equipmentEffect = EquipmentEffect.Instance[EquipmentEffectId];
			value += value * equipmentEffect.FavorChange / 100;
		}
		return value;
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return 0;
	}

	public unsafe HitOrAvoidShorts GetHitFactors()
	{
		HitOrAvoidShorts value = GetBaseHitFactors();
		foreach (EquipmentEffectItem effect in DomainManager.Item.GetEquipmentEffects(this))
		{
			for (int i = 0; i < effect.HitFactors.Length; i++)
			{
				value[i] += effect.HitFactors[i];
			}
		}
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			RefiningEffects refiningEffects = DomainManager.Item.GetRefinedEffects(GetItemKey());
			for (int hitType = 0; hitType < 4; hitType++)
			{
				int refineBonus = refiningEffects.GetWeaponPropertyBonus((ERefiningEffectWeaponType)(0 + hitType));
				refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
				value.Items[hitType] = (short)(value.Items[hitType] + Math.Abs(value.Items[hitType] * refineBonus / 100));
			}
		}
		return value;
	}

	public unsafe HitOrAvoidShorts GetHitFactors(int charId)
	{
		HitOrAvoidShorts hitFactors = GetHitFactors();
		CValuePercent usePower = DomainManager.Character.GetItemPower(charId, GetItemKey());
		for (int hitType = 0; hitType < 4; hitType++)
		{
			int hitValue = hitFactors.Items[hitType];
			if (hitValue > 0)
			{
				hitFactors.Items[hitType] = (short)(hitValue * usePower);
			}
		}
		return hitFactors;
	}

	public bool TricksMatchCombatSkill(CombatSkillItem combatSkillCfg)
	{
		foreach (NeedTrick skillTrick in combatSkillCfg.TrickCost)
		{
			int count = 0;
			foreach (sbyte weaponTrick in _tricks)
			{
				if (weaponTrick == skillTrick.TrickType)
				{
					count++;
				}
			}
			if (count < skillTrick.NeedCount)
			{
				return false;
			}
		}
		return true;
	}

	public override void SetMaxDurability(short maxDurability, DataContext context)
	{
		MaxDurability = maxDurability;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public override void SetEquipmentEffectId(short equipmentEffectId, DataContext context)
	{
		EquipmentEffectId = equipmentEffectId;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public List<sbyte> GetTricks()
	{
		return _tricks;
	}

	public void SetTricks(List<sbyte> tricks, DataContext context)
	{
		_tricks = tricks;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public override void SetCurrDurability(short currDurability, DataContext context)
	{
		CurrDurability = currDurability;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public override void SetModificationState(byte modificationState, DataContext context)
	{
		ModificationState = modificationState;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public override void SetEquippedCharId(int equippedCharId, DataContext context)
	{
		EquippedCharId = equippedCharId;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public override void SetMaterialResources(MaterialResources materialResources, DataContext context)
	{
		MaterialResources = materialResources;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public short GetPenetrationFactor()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 9))
		{
			return _penetrationFactor;
		}
		short value = CalcPenetrationFactor();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_penetrationFactor = value;
			dataStates.SetCached(DataStatesOffset, 9);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _penetrationFactor;
	}

	public short GetEquipmentAttack()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 10))
		{
			return _equipmentAttack;
		}
		short value = CalcEquipmentAttack();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_equipmentAttack = value;
			dataStates.SetCached(DataStatesOffset, 10);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _equipmentAttack;
	}

	public short GetEquipmentDefense()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 11))
		{
			return _equipmentDefense;
		}
		short value = CalcEquipmentDefense();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_equipmentDefense = value;
			dataStates.SetCached(DataStatesOffset, 11);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _equipmentDefense;
	}

	public override int GetWeight()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 12))
		{
			return _weight;
		}
		int value = CalcWeight();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_weight = value;
			dataStates.SetCached(DataStatesOffset, 12);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _weight;
	}

	public override short GetEquippedPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 13))
		{
			return EquippedPower;
		}
		short value = CalcEquippedPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			EquippedPower = value;
			dataStates.SetCached(DataStatesOffset, 13);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return EquippedPower;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetName()
	{
		return Config.Weapon.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Weapon.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Weapon.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Weapon.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Weapon.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Weapon.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Weapon.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Weapon.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Weapon.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Weapon.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Weapon.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Weapon.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Weapon.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Weapon.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Weapon.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Weapon.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Weapon.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Weapon.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetEquipmentType()
	{
		return Config.Weapon.Instance[TemplateId].EquipmentType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseEquipmentAttack()
	{
		return Config.Weapon.Instance[TemplateId].BaseEquipmentAttack;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseEquipmentDefense()
	{
		return Config.Weapon.Instance[TemplateId].BaseEquipmentDefense;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public ref readonly PoisonsAndLevels GetInnatePoisons()
	{
		return ref Config.Weapon.Instance[TemplateId].InnatePoisons;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<PropertyAndValue> GetRequiredCharacterProperties()
	{
		return Config.Weapon.Instance[TemplateId].RequiredCharacterProperties;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetWeaponAction()
	{
		return Config.Weapon.Instance[TemplateId].WeaponAction;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetCombatPictureR()
	{
		return Config.Weapon.Instance[TemplateId].CombatPictureR;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetCombatPictureL()
	{
		return Config.Weapon.Instance[TemplateId].CombatPictureL;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<string> GetHitSounds()
	{
		return Config.Weapon.Instance[TemplateId].HitSounds;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSwingSoundsSuffix()
	{
		return Config.Weapon.Instance[TemplateId].SwingSoundsSuffix;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetPlayArmorHitSound()
	{
		return Config.Weapon.Instance[TemplateId].PlayArmorHitSound;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<TrickDistanceAdjust> GetTrickDistanceAdjusts()
	{
		return Config.Weapon.Instance[TemplateId].TrickDistanceAdjusts;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetRandomTrick()
	{
		return Config.Weapon.Instance[TemplateId].RandomTrick;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanChangeTrick()
	{
		return Config.Weapon.Instance[TemplateId].CanChangeTrick;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetPursueAttackFactor()
	{
		return Config.Weapon.Instance[TemplateId].PursueAttackFactor;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetAttackPreparePointCost()
	{
		return Config.Weapon.Instance[TemplateId].AttackPreparePointCost;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMinDistance()
	{
		return Config.Weapon.Instance[TemplateId].MinDistance;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMaxDistance()
	{
		return Config.Weapon.Instance[TemplateId].MaxDistance;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public HitOrAvoidShorts GetBaseHitFactors()
	{
		return Config.Weapon.Instance[TemplateId].BaseHitFactors;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBasePenetrationFactor()
	{
		return Config.Weapon.Instance[TemplateId].BasePenetrationFactor;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetStanceIncrement()
	{
		return Config.Weapon.Instance[TemplateId].StanceIncrement;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetDefaultInnerRatio()
	{
		return Config.Weapon.Instance[TemplateId].DefaultInnerRatio;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetInnerRatioAdjustRange()
	{
		return Config.Weapon.Instance[TemplateId].InnerRatioAdjustRange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<string> GetBlockParticles()
	{
		return Config.Weapon.Instance[TemplateId].BlockParticles;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Weapon.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Weapon.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMakeItemSubType()
	{
		return Config.Weapon.Instance[TemplateId].MakeItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetIdleAni()
	{
		return Config.Weapon.Instance[TemplateId].IdleAni;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetForwardAni()
	{
		return Config.Weapon.Instance[TemplateId].ForwardAni;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetBackwardAni()
	{
		return Config.Weapon.Instance[TemplateId].BackwardAni;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFastBackwardAni()
	{
		return Config.Weapon.Instance[TemplateId].FastBackwardAni;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 4)]
	public string[] GetAvoidAnis()
	{
		return Config.Weapon.Instance[TemplateId].AvoidAnis;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 3)]
	public string[] GetHittedAnis()
	{
		return Config.Weapon.Instance[TemplateId].HittedAnis;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFatalParticle()
	{
		return Config.Weapon.Instance[TemplateId].FatalParticle;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetTeammateCmdAniPostfix()
	{
		return Config.Weapon.Instance[TemplateId].TeammateCmdAniPostfix;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<string> GetBlockAnis()
	{
		return Config.Weapon.Instance[TemplateId].BlockAnis;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<string> GetBlockSounds()
	{
		return Config.Weapon.Instance[TemplateId].BlockSounds;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetChangeTrickPercent()
	{
		return Config.Weapon.Instance[TemplateId].ChangeTrickPercent;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFastForwardAni()
	{
		return Config.Weapon.Instance[TemplateId].FastForwardAni;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetDetachable()
	{
		return Config.Weapon.Instance[TemplateId].Detachable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetUnlockEffect()
	{
		return Config.Weapon.Instance[TemplateId].UnlockEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Weapon.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRawCreate()
	{
		return Config.Weapon.Instance[TemplateId].AllowRawCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Weapon.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Weapon.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Weapon.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Weapon.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowCrippledCreate()
	{
		return Config.Weapon.Instance[TemplateId].AllowCrippledCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEquipmentCombatPowerValueFactor()
	{
		return Config.Weapon.Instance[TemplateId].EquipmentCombatPowerValueFactor;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetBaseStartupFrames()
	{
		return Config.Weapon.Instance[TemplateId].BaseStartupFrames;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetBaseRecoveryFrames()
	{
		return Config.Weapon.Instance[TemplateId].BaseRecoveryFrames;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Weapon.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEquipmentMasteryId()
	{
		return Config.Weapon.Instance[TemplateId].EquipmentMasteryId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Weapon.Instance[TemplateId].FunctionDesc;
	}

	public Weapon()
	{
		_tricks = new List<sbyte>();
	}

	public Weapon(short templateId)
	{
		WeaponItem template = Config.Weapon.Instance[templateId];
		TemplateId = template.TemplateId;
		MaxDurability = template.MaxDurability;
		EquipmentEffectId = template.EquipmentEffectId;
		_tricks = new List<sbyte>(template.Tricks);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + ArchiveFieldIds.Length * 2 + 4 + FixedArchiveFieldSizes.Length * 4 + GetSerializedSizeWithoutHeader();
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = (*(int*)pCurrData = ArchiveFieldIds.Length);
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		fixed (ushort* archiveFieldIds = ArchiveFieldIds)
		{
			void* pFieldId = archiveFieldIds;
			Buffer.MemoryCopy(pFieldId, pCurrData, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = (*(int*)pCurrData = FixedArchiveFieldSizes.Length);
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		fixed (int* fixedArchiveFieldSizes = FixedArchiveFieldSizes)
		{
			void* pFieldSize = fixedArchiveFieldSizes;
			Buffer.MemoryCopy(pFieldSize, pCurrData, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += SerializeWithoutHeader(pCurrData);
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = *(int*)pCurrData;
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		ushort[] fieldIds = new ushort[length];
		fixed (ushort* ptr = fieldIds)
		{
			void* pFieldId = ptr;
			Buffer.MemoryCopy(pCurrData, pFieldId, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = *(int*)pCurrData;
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		int[] fieldSizes = new int[fixedFieldSizesLength];
		fixed (int* ptr2 = fieldSizes)
		{
			void* pFieldSize = ptr2;
			Buffer.MemoryCopy(pCurrData, pFieldSize, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += DeserializeWithFieldIds(pCurrData, fieldIds, fieldSizes);
		return (int)(pCurrData - pData);
	}

	public override int GetSerializedSizeWithoutHeader()
	{
		int totalSize = 33;
		int elementsCount = _tricks.Count;
		int contentSize = elementsCount;
		int dataSize = 2 + contentSize;
		return totalSize + dataSize;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = MaxDurability;
		pCurrData += 2;
		*(short*)pCurrData = EquipmentEffectId;
		pCurrData += 2;
		*(short*)pCurrData = CurrDurability;
		pCurrData += 2;
		*pCurrData = ModificationState;
		pCurrData++;
		*(int*)pCurrData = EquippedCharId;
		pCurrData += 4;
		pCurrData += MaterialResources.Serialize(pCurrData);
		int elementsCount = _tricks.Count;
		int contentSize = elementsCount;
		if (contentSize > 4194300)
		{
			throw new Exception($"Size of field {"_tricks"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int i = 0; i < elementsCount; i++)
		{
			pCurrData[i] = (byte)_tricks[i];
		}
		pCurrData += contentSize;
		return (int)(pCurrData - pData);
	}

	public unsafe override int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes)
	{
		byte* pCurrData = pData;
		for (int fieldIndex = 0; fieldIndex < fieldIds.Length; fieldIndex++)
		{
			switch (fieldIds[fieldIndex])
			{
			case 0:
				Id = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 1:
				TemplateId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 2:
				MaxDurability = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 3:
				EquipmentEffectId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 5:
				CurrDurability = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 6:
				ModificationState = *pCurrData;
				pCurrData++;
				break;
			case 7:
				EquippedCharId = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 8:
				pCurrData += MaterialResources.Deserialize(pCurrData);
				break;
			case 4:
			{
				pCurrData += 4;
				ushort elementsCount = *(ushort*)pCurrData;
				pCurrData += 2;
				_tricks.Clear();
				for (int i = 0; i < elementsCount; i++)
				{
					_tricks.Add((sbyte)pCurrData[i]);
				}
				pCurrData += (int)elementsCount;
				break;
			}
			default:
				if (fieldIndex < fixedFieldSizes.Length)
				{
					int fieldSize = fixedFieldSizes[fieldIndex];
					pCurrData += fieldSize;
				}
				else
				{
					int fieldSize2 = *(int*)pCurrData;
					pCurrData += 4;
					pCurrData += fieldSize2;
				}
				break;
			}
		}
		return (int)(pCurrData - pData);
	}
}
