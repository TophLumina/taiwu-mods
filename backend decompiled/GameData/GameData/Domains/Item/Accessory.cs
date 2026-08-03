using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using Config.ConfigCells.Character;
using GameData.Common;
using GameData.Dependencies;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Accessory : EquipmentBase, ISerializableGameData, IExploreBonusRateItem
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

	public override short GetEquippedPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 8))
		{
			return EquippedPower;
		}
		short value = CalcEquippedPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			EquippedPower = value;
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
		return EquippedPower;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetName()
	{
		return Config.Accessory.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Accessory.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Accessory.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Accessory.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Accessory.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Accessory.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Accessory.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Accessory.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Accessory.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Accessory.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Accessory.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Accessory.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Accessory.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Accessory.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Accessory.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Accessory.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Accessory.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Accessory.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetEquipmentType()
	{
		return Config.Accessory.Instance[TemplateId].EquipmentType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetDropRateBonus()
	{
		return Config.Accessory.Instance[TemplateId].DropRateBonus;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMaxInventoryLoadBonus()
	{
		return Config.Accessory.Instance[TemplateId].MaxInventoryLoadBonus;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetStrength()
	{
		return Config.Accessory.Instance[TemplateId].Strength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetDexterity()
	{
		return Config.Accessory.Instance[TemplateId].Dexterity;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetConcentration()
	{
		return Config.Accessory.Instance[TemplateId].Concentration;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetVitality()
	{
		return Config.Accessory.Instance[TemplateId].Vitality;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetEnergy()
	{
		return Config.Accessory.Instance[TemplateId].Energy;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetIntelligence()
	{
		return Config.Accessory.Instance[TemplateId].Intelligence;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateStrength()
	{
		return Config.Accessory.Instance[TemplateId].HitRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateTechnique()
	{
		return Config.Accessory.Instance[TemplateId].HitRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateSpeed()
	{
		return Config.Accessory.Instance[TemplateId].HitRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfOuter()
	{
		return Config.Accessory.Instance[TemplateId].PenetrateOfOuter;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfInner()
	{
		return Config.Accessory.Instance[TemplateId].PenetrateOfInner;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateStrength()
	{
		return Config.Accessory.Instance[TemplateId].AvoidRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateTechnique()
	{
		return Config.Accessory.Instance[TemplateId].AvoidRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateSpeed()
	{
		return Config.Accessory.Instance[TemplateId].AvoidRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfOuter()
	{
		return Config.Accessory.Instance[TemplateId].PenetrateResistOfOuter;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfInner()
	{
		return Config.Accessory.Instance[TemplateId].PenetrateResistOfInner;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfStance()
	{
		return Config.Accessory.Instance[TemplateId].RecoveryOfStance;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfBreath()
	{
		return Config.Accessory.Instance[TemplateId].RecoveryOfBreath;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetMoveSpeed()
	{
		return Config.Accessory.Instance[TemplateId].MoveSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfFlaw()
	{
		return Config.Accessory.Instance[TemplateId].RecoveryOfFlaw;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetCastSpeed()
	{
		return Config.Accessory.Instance[TemplateId].CastSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfBlockedAcupoint()
	{
		return Config.Accessory.Instance[TemplateId].RecoveryOfBlockedAcupoint;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetWeaponSwitchSpeed()
	{
		return Config.Accessory.Instance[TemplateId].WeaponSwitchSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAttackSpeed()
	{
		return Config.Accessory.Instance[TemplateId].AttackSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetInnerRatio()
	{
		return Config.Accessory.Instance[TemplateId].InnerRatio;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfQiDisorder()
	{
		return Config.Accessory.Instance[TemplateId].RecoveryOfQiDisorder;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfHotPoison()
	{
		return Config.Accessory.Instance[TemplateId].ResistOfHotPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfGloomyPoison()
	{
		return Config.Accessory.Instance[TemplateId].ResistOfGloomyPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfColdPoison()
	{
		return Config.Accessory.Instance[TemplateId].ResistOfColdPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfRedPoison()
	{
		return Config.Accessory.Instance[TemplateId].ResistOfRedPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfRottenPoison()
	{
		return Config.Accessory.Instance[TemplateId].ResistOfRottenPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfIllusoryPoison()
	{
		return Config.Accessory.Instance[TemplateId].ResistOfIllusoryPoison;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBonusCombatSkillSect()
	{
		return Config.Accessory.Instance[TemplateId].BonusCombatSkillSect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMakeItemSubType()
	{
		return Config.Accessory.Instance[TemplateId].MakeItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Accessory.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Accessory.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetDetachable()
	{
		return Config.Accessory.Instance[TemplateId].Detachable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Accessory.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Accessory.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRawCreate()
	{
		return Config.Accessory.Instance[TemplateId].AllowRawCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Accessory.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateMind()
	{
		return Config.Accessory.Instance[TemplateId].AvoidRateMind;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetCombatSkillAddMaxPower()
	{
		return Config.Accessory.Instance[TemplateId].CombatSkillAddMaxPower;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Accessory.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Accessory.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateMind()
	{
		return Config.Accessory.Instance[TemplateId].HitRateMind;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEquipmentCombatPowerValueFactor()
	{
		return Config.Accessory.Instance[TemplateId].EquipmentCombatPowerValueFactor;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseCaptureRateBonus()
	{
		return Config.Accessory.Instance[TemplateId].BaseCaptureRateBonus;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseExploreBonusRate()
	{
		return Config.Accessory.Instance[TemplateId].BaseExploreBonusRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Accessory.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetMysteryEffectId()
	{
		return Config.Accessory.Instance[TemplateId].MysteryEffectId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<PropertyAndValue> GetRequiredCharacterProperties()
	{
		return Config.Accessory.Instance[TemplateId].RequiredCharacterProperties;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Accessory.Instance[TemplateId].FunctionDesc;
	}

	public Accessory()
	{
	}

	public Accessory(short templateId)
	{
		AccessoryItem template = Config.Accessory.Instance[templateId];
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

	[ObjectCollectionDependency(6, 2, new ushort[] { 6, 3, 7 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 79, 100, 89, 97, 99 }, Scope = InfluenceScope.AccessoriesOfTheChar)]
	private short CalcEquippedPower()
	{
		GameData.Domains.Character.Character element;
		return (short)(DomainManager.Character.TryGetElement_Objects(EquippedCharId, out element) ? DomainManager.Character.GetItemRequirementsPower(EquippedCharId, GetItemKey()) : 0);
	}

	public Accessory(IRandomSource random, short templateId, int itemId)
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
		AccessoryItem config = Config.Accessory.Instance[TemplateId];
		int bonus = config.GetCharacterPropertyBonusInt(type);
		if (ModificationStateHelper.IsActive(ModificationState, 2))
		{
			ERefiningEffectAccessoryType effectType = RefiningEffects.CharPropertyTypeToRefiningEffectAccessoryType(type);
			if (effectType != ERefiningEffectAccessoryType.Invalid)
			{
				int refineBonus = DomainManager.Item.GetRefinedEffects(GetItemKey()).GetAccessoryPropertyBonus(effectType);
				refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, EquippedCharId);
				bonus += refineBonus;
			}
		}
		return bonus;
	}

	int IExploreBonusRateItem.GetExploreBonusRate()
	{
		return GetBaseExploreBonusRate();
	}
}
