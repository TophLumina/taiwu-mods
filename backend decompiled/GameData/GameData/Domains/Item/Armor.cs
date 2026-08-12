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
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Armor : EquipmentBase, ISerializableGameData
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

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerShorts _penetrationResistFactors;

	[CollectionObjectField(false, false, true, false, false)]
	private short _equipmentAttack;

	[CollectionObjectField(false, false, true, false, false)]
	private short _equipmentDefense;

	[CollectionObjectField(false, false, true, false, false)]
	private int _weight;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerShorts _injuryFactor;

	public const int FixedSize = 29;

	public const int DynamicCount = 0;

	private SpinLock _spinLock = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly ushort[] ArchiveFieldIds = new ushort[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

	private static readonly int[] FixedArchiveFieldSizes = new int[8] { 4, 2, 2, 2, 2, 1, 4, 12 };

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

	public override void SetCurrDurability(short currDurability, DataContext context)
	{
		CurrDurability = currDurability;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public override void SetModificationState(byte modificationState, DataContext context)
	{
		ModificationState = modificationState;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public override void SetEquippedCharId(int equippedCharId, DataContext context)
	{
		EquippedCharId = equippedCharId;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public override void SetMaterialResources(MaterialResources materialResources, DataContext context)
	{
		MaterialResources = materialResources;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public OuterAndInnerShorts GetPenetrationResistFactors()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 8))
		{
			return _penetrationResistFactors;
		}
		OuterAndInnerShorts value = CalcPenetrationResistFactors();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_penetrationResistFactors = value;
			dataStates.SetCached(DataStatesOffset, 8);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _penetrationResistFactors;
	}

	public short GetEquipmentAttack()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 9))
		{
			return _equipmentAttack;
		}
		short value = CalcEquipmentAttack();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_equipmentAttack = value;
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
		return _equipmentAttack;
	}

	public short GetEquipmentDefense()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 10))
		{
			return _equipmentDefense;
		}
		short value = CalcEquipmentDefense();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_equipmentDefense = value;
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
		return _equipmentDefense;
	}

	public override int GetWeight()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 11))
		{
			return _weight;
		}
		int value = CalcWeight();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_weight = value;
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
		return _weight;
	}

	public OuterAndInnerShorts GetInjuryFactor()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 12))
		{
			return _injuryFactor;
		}
		OuterAndInnerShorts value = CalcInjuryFactor();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_injuryFactor = value;
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
		return _injuryFactor;
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
		return Config.Armor.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Armor.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Armor.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Armor.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Armor.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Armor.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Armor.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Armor.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Armor.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Armor.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Armor.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Armor.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Armor.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Armor.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Armor.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Armor.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Armor.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Armor.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetEquipmentType()
	{
		return Config.Armor.Instance[TemplateId].EquipmentType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseEquipmentAttack()
	{
		return Config.Armor.Instance[TemplateId].BaseEquipmentAttack;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseEquipmentDefense()
	{
		return Config.Armor.Instance[TemplateId].BaseEquipmentDefense;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<PropertyAndValue> GetRequiredCharacterProperties()
	{
		return Config.Armor.Instance[TemplateId].RequiredCharacterProperties;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public HitOrAvoidShorts GetBaseAvoidFactors()
	{
		return Config.Armor.Instance[TemplateId].BaseAvoidFactors;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public OuterAndInnerShorts GetBasePenetrationResistFactors()
	{
		return Config.Armor.Instance[TemplateId].BasePenetrationResistFactors;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetRelatedWeapon()
	{
		return Config.Armor.Instance[TemplateId].RelatedWeapon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<string> GetSkeletonSlotAndAttachment()
	{
		return Config.Armor.Instance[TemplateId].SkeletonSlotAndAttachment;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMakeItemSubType()
	{
		return Config.Armor.Instance[TemplateId].MakeItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Armor.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Armor.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetDetachable()
	{
		return Config.Armor.Instance[TemplateId].Detachable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public OuterAndInnerShorts GetBaseInjuryFactors()
	{
		return Config.Armor.Instance[TemplateId].BaseInjuryFactors;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Armor.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Armor.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Armor.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Armor.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowCrippledCreate()
	{
		return Config.Armor.Instance[TemplateId].AllowCrippledCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Armor.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRawCreate()
	{
		return Config.Armor.Instance[TemplateId].AllowRawCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEquipmentCombatPowerValueFactor()
	{
		return Config.Armor.Instance[TemplateId].EquipmentCombatPowerValueFactor;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Armor.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEquipmentMasteryId()
	{
		return Config.Armor.Instance[TemplateId].EquipmentMasteryId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Armor.Instance[TemplateId].FunctionDesc;
	}

	public Armor()
	{
	}

	public Armor(short templateId)
	{
		ArmorItem template = Config.Armor.Instance[templateId];
		TemplateId = template.TemplateId;
		MaxDurability = template.MaxDurability;
		EquipmentEffectId = template.EquipmentEffectId;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
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
		return 29;
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
				continue;
			case 1:
				TemplateId = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 2:
				MaxDurability = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 3:
				EquipmentEffectId = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 4:
				CurrDurability = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 5:
				ModificationState = *pCurrData;
				pCurrData++;
				continue;
			case 6:
				EquippedCharId = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 7:
				pCurrData += MaterialResources.Deserialize(pCurrData);
				continue;
			}
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
		}
		return (int)(pCurrData - pData);
	}

	[ObjectCollectionDependency(6, 1, new ushort[] { 5, 3, 7 }, Scope = InfluenceScope.Self)]
	private OuterAndInnerShorts CalcPenetrationResistFactors()
	{
		OuterAndInnerInts value = GetBasePenetrationResistFactors();
		CValuePercent percent = GetMaterialResourceBonusValuePercentage(3);
		value.Outer *= percent;
		value.Inner *= percent;
		EquipmentEffectHelper.ValueSelector outerSelector = EquipmentEffectHelper.GetPenetrationResistFactorSelector(inner: false);
		value.Outer = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value.Outer, outerSelector);
		EquipmentEffectHelper.ValueSelector innerSelector = EquipmentEffectHelper.GetPenetrationResistFactorSelector(inner: true);
		value.Inner = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value.Inner, innerSelector);
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetArmorPropertyBonus(ERefiningEffectArmorType.PenetrationResist);
			refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
			value.Inner += refineBonus;
			value.Outer += refineBonus;
		}
		return (OuterAndInnerShorts)value;
	}

	[ObjectCollectionDependency(6, 1, new ushort[] { 5, 3 }, Scope = InfluenceScope.Self)]
	private OuterAndInnerShorts CalcInjuryFactor()
	{
		OuterAndInnerInts value = GetBaseInjuryFactors();
		EquipmentEffectHelper.ValueSelector outerSelector = EquipmentEffectHelper.GetInjuryFactorSelector(inner: false);
		value.Outer = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value.Outer, outerSelector);
		EquipmentEffectHelper.ValueSelector innerSelector = EquipmentEffectHelper.GetInjuryFactorSelector(inner: true);
		value.Inner = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value.Inner, innerSelector);
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			RefiningEffects refiningEffects = DomainManager.Item.GetRefinedEffects(GetItemKey());
			int outerRefineBonus = refiningEffects.GetArmorPropertyBonus(ERefiningEffectArmorType.InjuryFactorOuter);
			outerRefineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(outerRefineBonus, EquippedCharId);
			value.Outer += outerRefineBonus;
			int innerRefineBonus = refiningEffects.GetArmorPropertyBonus(ERefiningEffectArmorType.InjuryFactorInner);
			innerRefineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(innerRefineBonus, EquippedCharId);
			value.Inner += innerRefineBonus;
		}
		return (OuterAndInnerShorts)value;
	}

	[ObjectCollectionDependency(6, 1, new ushort[] { 5, 3, 7 }, Scope = InfluenceScope.Self)]
	private short CalcEquipmentAttack()
	{
		int value = GetBaseEquipmentAttack();
		value = value * GetMaterialResourceBonusValuePercentage(0) / 100;
		value = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value, (EquipmentEffectItem x) => x.EquipmentAttackChange);
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetArmorPropertyBonus(ERefiningEffectArmorType.EquipmentAttack);
			refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
			value = value * (100 + refineBonus) / 100;
		}
		return (short)value;
	}

	[ObjectCollectionDependency(6, 1, new ushort[] { 5, 3, 7 }, Scope = InfluenceScope.Self)]
	private short CalcEquipmentDefense()
	{
		int value = GetBaseEquipmentDefense();
		value = value * GetMaterialResourceBonusValuePercentage(1) / 100;
		value = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value, (EquipmentEffectItem x) => x.EquipmentDefenseChange);
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetArmorPropertyBonus(ERefiningEffectArmorType.EquipmentDefense);
			refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
			value = value * (100 + refineBonus) / 100;
		}
		return (short)value;
	}

	[ObjectCollectionDependency(6, 1, new ushort[] { 5, 3, 7 }, Scope = InfluenceScope.Self)]
	private int CalcWeight()
	{
		int value = GetBaseWeight();
		value = value * (170 - GetMaterialResourceBonusValuePercentage(4)) / 100;
		value = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value, (EquipmentEffectItem x) => x.WeightChange);
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetArmorPropertyBonus(ERefiningEffectArmorType.Weight);
			refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
			value = value * (100 + refineBonus) / 100;
		}
		return value;
	}

	[ObjectCollectionDependency(6, 1, new ushort[] { 6, 3, 7 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 79, 100, 89, 97, 99 }, Scope = InfluenceScope.ArmorsOfTheChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 30, 31 }, Scope = InfluenceScope.ArmorsOfTheCharacterAffectedByTheSpecialEffects)]
	private short CalcEquippedPower()
	{
		GameData.Domains.Character.Character element;
		return (short)(DomainManager.Character.TryGetElement_Objects(EquippedCharId, out element) ? DomainManager.Character.GetItemRequirementsPower(EquippedCharId, GetItemKey()) : 0);
	}

	public Armor(IRandomSource random, short templateId, int itemId)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
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

	public unsafe HitOrAvoidShorts GetAvoidFactors()
	{
		HitOrAvoidInts value = GetBaseAvoidFactors();
		for (int i = 0; i < 4; i++)
		{
			EquipmentEffectHelper.ValueSelector selector = EquipmentEffectHelper.GetAvoidFactorSelector(i);
			value[i] = DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value[i], selector);
		}
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			RefiningEffects refiningEffects = DomainManager.Item.GetRefinedEffects(GetItemKey());
			for (int hitType = 0; hitType < 4; hitType++)
			{
				int refineBonus = refiningEffects.GetArmorPropertyBonus((ERefiningEffectArmorType)(0 + hitType));
				refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
				ref int reference = ref value.Items[hitType];
				reference += Math.Abs(value.Items[hitType] * refineBonus / 100);
			}
		}
		return (HitOrAvoidShorts)value;
	}

	public unsafe HitOrAvoidShorts GetAvoidFactors(int charId)
	{
		HitOrAvoidShorts avoidFactors = GetAvoidFactors();
		short usePower = DomainManager.Character.GetItemPower(charId, GetItemKey());
		for (int hitType = 0; hitType < 4; hitType++)
		{
			int avoidValue = avoidFactors.Items[hitType];
			if (avoidValue > 0)
			{
				avoidFactors.Items[hitType] = (short)(avoidValue * usePower / 100);
			}
		}
		return avoidFactors;
	}
}
