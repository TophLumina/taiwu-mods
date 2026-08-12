using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Medicine : ItemBase, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint TemplateId_Offset = 4u;

		public const int TemplateId_Size = 2;

		public const uint MaxDurability_Offset = 6u;

		public const int MaxDurability_Size = 2;

		public const uint CurrDurability_Offset = 8u;

		public const int CurrDurability_Size = 2;

		public const uint ModificationState_Offset = 10u;

		public const int ModificationState_Size = 1;
	}

	public const int FixedSize = 11;

	public const int DynamicCount = 0;

	private static readonly ushort[] ArchiveFieldIds = new ushort[5] { 0, 1, 2, 3, 4 };

	private static readonly int[] FixedArchiveFieldSizes = new int[5] { 4, 2, 2, 2, 1 };

	public override void SetMaxDurability(short maxDurability, DataContext context)
	{
		MaxDurability = maxDurability;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public override void SetCurrDurability(short currDurability, DataContext context)
	{
		CurrDurability = currDurability;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public override void SetModificationState(byte modificationState, DataContext context)
	{
		ModificationState = modificationState;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetName()
	{
		return Config.Medicine.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Medicine.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Medicine.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Medicine.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Medicine.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Medicine.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Medicine.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Medicine.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Medicine.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Medicine.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Medicine.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Medicine.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Medicine.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Medicine.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Medicine.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Medicine.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Medicine.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetDuration()
	{
		return Config.Medicine.Instance[TemplateId].Duration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetInjuryRecoveryTimes()
	{
		return Config.Medicine.Instance[TemplateId].InjuryRecoveryTimes;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateStrength()
	{
		return Config.Medicine.Instance[TemplateId].HitRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateTechnique()
	{
		return Config.Medicine.Instance[TemplateId].HitRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateSpeed()
	{
		return Config.Medicine.Instance[TemplateId].HitRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateMind()
	{
		return Config.Medicine.Instance[TemplateId].HitRateMind;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfOuter()
	{
		return Config.Medicine.Instance[TemplateId].PenetrateOfOuter;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfInner()
	{
		return Config.Medicine.Instance[TemplateId].PenetrateOfInner;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateStrength()
	{
		return Config.Medicine.Instance[TemplateId].AvoidRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateTechnique()
	{
		return Config.Medicine.Instance[TemplateId].AvoidRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateSpeed()
	{
		return Config.Medicine.Instance[TemplateId].AvoidRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateMind()
	{
		return Config.Medicine.Instance[TemplateId].AvoidRateMind;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfOuter()
	{
		return Config.Medicine.Instance[TemplateId].PenetrateResistOfOuter;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfInner()
	{
		return Config.Medicine.Instance[TemplateId].PenetrateResistOfInner;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfStance()
	{
		return Config.Medicine.Instance[TemplateId].RecoveryOfStance;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfBreath()
	{
		return Config.Medicine.Instance[TemplateId].RecoveryOfBreath;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetMoveSpeed()
	{
		return Config.Medicine.Instance[TemplateId].MoveSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfFlaw()
	{
		return Config.Medicine.Instance[TemplateId].RecoveryOfFlaw;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetCastSpeed()
	{
		return Config.Medicine.Instance[TemplateId].CastSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfBlockedAcupoint()
	{
		return Config.Medicine.Instance[TemplateId].RecoveryOfBlockedAcupoint;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetWeaponSwitchSpeed()
	{
		return Config.Medicine.Instance[TemplateId].WeaponSwitchSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAttackSpeed()
	{
		return Config.Medicine.Instance[TemplateId].AttackSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetInnerRatio()
	{
		return Config.Medicine.Instance[TemplateId].InnerRatio;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfQiDisorder()
	{
		return Config.Medicine.Instance[TemplateId].RecoveryOfQiDisorder;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetWugType()
	{
		return Config.Medicine.Instance[TemplateId].WugType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetWugGrowthType()
	{
		return Config.Medicine.Instance[TemplateId].WugGrowthType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSpecialEffectClass()
	{
		return Config.Medicine.Instance[TemplateId].SpecialEffectClass;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetConsumedFeatureMedals()
	{
		return Config.Medicine.Instance[TemplateId].ConsumedFeatureMedals;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMaxUseDistance()
	{
		return Config.Medicine.Instance[TemplateId].MaxUseDistance;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSpecialEffectDesc()
	{
		return Config.Medicine.Instance[TemplateId].SpecialEffectDesc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBuffAndOtherMedicine()
	{
		return Config.Medicine.Instance[TemplateId].BuffAndOtherMedicine;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Medicine.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Medicine.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetSpecialEffectId()
	{
		return Config.Medicine.Instance[TemplateId].SpecialEffectId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Medicine.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfRedPoison()
	{
		return Config.Medicine.Instance[TemplateId].ResistOfRedPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfIllusoryPoison()
	{
		return Config.Medicine.Instance[TemplateId].ResistOfIllusoryPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfRottenPoison()
	{
		return Config.Medicine.Instance[TemplateId].ResistOfRottenPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfColdPoison()
	{
		return Config.Medicine.Instance[TemplateId].ResistOfColdPoison;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfGloomyPoison()
	{
		return Config.Medicine.Instance[TemplateId].ResistOfGloomyPoison;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanUseMultiple()
	{
		return Config.Medicine.Instance[TemplateId].CanUseMultiple;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBreakBonusEffect()
	{
		return Config.Medicine.Instance[TemplateId].BreakBonusEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Medicine.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Medicine.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Medicine.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Medicine.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetResistOfHotPoison()
	{
		return Config.Medicine.Instance[TemplateId].ResistOfHotPoison;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Medicine.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetDamageStepBonus()
	{
		return Config.Medicine.Instance[TemplateId].DamageStepBonus;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetRequiredMainAttributeValue()
	{
		return Config.Medicine.Instance[TemplateId].RequiredMainAttributeValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetRequiredMainAttributeType()
	{
		return Config.Medicine.Instance[TemplateId].RequiredMainAttributeType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetSideEffectValue()
	{
		return Config.Medicine.Instance[TemplateId].SideEffectValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEffectValue()
	{
		return Config.Medicine.Instance[TemplateId].EffectValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEffectThresholdValue()
	{
		return Config.Medicine.Instance[TemplateId].EffectThresholdValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMedicineEffectSubType GetEffectSubType()
	{
		return Config.Medicine.Instance[TemplateId].EffectSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetHasNormalEatingEffect()
	{
		return Config.Medicine.Instance[TemplateId].HasNormalEatingEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInstantAffect()
	{
		return Config.Medicine.Instance[TemplateId].InstantAffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetCombatUseEffect()
	{
		return Config.Medicine.Instance[TemplateId].CombatUseEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetCombatPrepareUseEffect()
	{
		return Config.Medicine.Instance[TemplateId].CombatPrepareUseEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMedicineEffectType GetEffectType()
	{
		return Config.Medicine.Instance[TemplateId].EffectType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetUseFrame()
	{
		return Config.Medicine.Instance[TemplateId].UseFrame;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Medicine.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsVirtual()
	{
		return Config.Medicine.Instance[TemplateId].IsVirtual;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Medicine.Instance[TemplateId].FunctionDesc;
	}

	public Medicine()
	{
	}

	public Medicine(short templateId)
	{
		MedicineItem template = Config.Medicine.Instance[templateId];
		TemplateId = template.TemplateId;
		MaxDurability = template.MaxDurability;
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
		return 11;
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
		*(short*)pCurrData = CurrDurability;
		pCurrData += 2;
		*pCurrData = ModificationState;
		pCurrData++;
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
				CurrDurability = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 4:
				ModificationState = *pCurrData;
				pCurrData++;
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

	public Medicine(IRandomSource random, short templateId, int itemId)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return GetCharacterPropertyBonusValue(TemplateId, type);
	}

	public static int GetCharacterPropertyBonusValue(short templateId, ECharacterPropertyReferencedType type)
	{
		return Config.Medicine.Instance[templateId].GetCharacterPropertyBonusValue(type);
	}

	public static int GetCharacterPropertyBonusPercentage(short templateId, ECharacterPropertyReferencedType type)
	{
		return Config.Medicine.Instance[templateId].GetCharacterPropertyBonusPercentage(type);
	}

	public static short GetDeltaWugDuration(sbyte medicineGrade)
	{
		return (short)(-(medicineGrade + 1) * 12);
	}
}
