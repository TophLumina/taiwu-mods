using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class TeaWine : ItemBase, ISerializableGameData
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

	public TeaWine(IRandomSource random, short templateId, int itemId)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return GetCharacterPropertyBonus(TemplateId, type);
	}

	public static int GetCharacterPropertyBonus(short templateId, ECharacterPropertyReferencedType type)
	{
		TeaWineItem config = Config.TeaWine.Instance[templateId];
		return config.GetCharacterPropertyBonusInt(type);
	}

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
		return Config.TeaWine.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.TeaWine.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.TeaWine.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.TeaWine.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.TeaWine.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.TeaWine.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.TeaWine.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.TeaWine.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.TeaWine.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.TeaWine.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.TeaWine.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.TeaWine.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.TeaWine.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.TeaWine.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.TeaWine.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.TeaWine.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.TeaWine.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetDuration()
	{
		return Config.TeaWine.Instance[TemplateId].Duration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetDirectChangeOfQiDisorder()
	{
		return Config.TeaWine.Instance[TemplateId].DirectChangeOfQiDisorder;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetConsumedFeatureMedals()
	{
		return Config.TeaWine.Instance[TemplateId].ConsumedFeatureMedals;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateStrength()
	{
		return Config.TeaWine.Instance[TemplateId].HitRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateTechnique()
	{
		return Config.TeaWine.Instance[TemplateId].HitRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateSpeed()
	{
		return Config.TeaWine.Instance[TemplateId].HitRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetHitRateMind()
	{
		return Config.TeaWine.Instance[TemplateId].HitRateMind;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfOuter()
	{
		return Config.TeaWine.Instance[TemplateId].PenetrateOfOuter;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateOfInner()
	{
		return Config.TeaWine.Instance[TemplateId].PenetrateOfInner;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateStrength()
	{
		return Config.TeaWine.Instance[TemplateId].AvoidRateStrength;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateTechnique()
	{
		return Config.TeaWine.Instance[TemplateId].AvoidRateTechnique;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateSpeed()
	{
		return Config.TeaWine.Instance[TemplateId].AvoidRateSpeed;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetAvoidRateMind()
	{
		return Config.TeaWine.Instance[TemplateId].AvoidRateMind;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfOuter()
	{
		return Config.TeaWine.Instance[TemplateId].PenetrateResistOfOuter;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetPenetrateResistOfInner()
	{
		return Config.TeaWine.Instance[TemplateId].PenetrateResistOfInner;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetInnerRatio()
	{
		return Config.TeaWine.Instance[TemplateId].InnerRatio;
	}

	[CollectionObjectField(true, false, false, false, true)]
	public short GetRecoveryOfQiDisorder()
	{
		return Config.TeaWine.Instance[TemplateId].RecoveryOfQiDisorder;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.TeaWine.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.TeaWine.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.TeaWine.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetSolarTermType()
	{
		return Config.TeaWine.Instance[TemplateId].SolarTermType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetEatHappinessChange()
	{
		return Config.TeaWine.Instance[TemplateId].EatHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.TeaWine.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBreakBonusEffect()
	{
		return Config.TeaWine.Instance[TemplateId].BreakBonusEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.TeaWine.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.TeaWine.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.TeaWine.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetActionPointRecover()
	{
		return Config.TeaWine.Instance[TemplateId].ActionPointRecover;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.TeaWine.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetBigIcon()
	{
		return Config.TeaWine.Instance[TemplateId].BigIcon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetUseFrame()
	{
		return Config.TeaWine.Instance[TemplateId].UseFrame;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.TeaWine.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.TeaWine.Instance[TemplateId].FunctionDesc;
	}

	public TeaWine()
	{
	}

	public TeaWine(short templateId)
	{
		TeaWineItem template = Config.TeaWine.Instance[templateId];
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
}
