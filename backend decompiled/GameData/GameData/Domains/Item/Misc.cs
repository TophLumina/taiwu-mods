using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Extra;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Misc : ItemBase, ISerializableGameData
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
		return Config.Misc.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Misc.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Misc.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Misc.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Misc.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Misc.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Misc.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Misc.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Misc.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Misc.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Misc.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Misc.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Misc.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Misc.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Misc.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Misc.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Misc.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetNeili()
	{
		return Config.Misc.Instance[TemplateId].Neili;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetCricketHealInjuryOdds()
	{
		return Config.Misc.Instance[TemplateId].CricketHealInjuryOdds;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetConsumedFeatureMedals()
	{
		return Config.Misc.Instance[TemplateId].ConsumedFeatureMedals;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMaxUseDistance()
	{
		return Config.Misc.Instance[TemplateId].MaxUseDistance;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Misc.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMakeItemSubType()
	{
		return Config.Misc.Instance[TemplateId].MakeItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<TreasureStateInfo> GetStateBuryAmount()
	{
		return Config.Misc.Instance[TemplateId].StateBuryAmount;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetConsumable()
	{
		return Config.Misc.Instance[TemplateId].Consumable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Misc.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Misc.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<short> GetRequireCombatConfig()
	{
		return Config.Misc.Instance[TemplateId].RequireCombatConfig;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Misc.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Misc.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Misc.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Misc.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBreakBonusEffect()
	{
		return Config.Misc.Instance[TemplateId].BreakBonusEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Misc.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<int> GetAllowBrokenLevels()
	{
		return Config.Misc.Instance[TemplateId].AllowBrokenLevels;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMiscGenerateType GetGenerateType()
	{
		return Config.Misc.Instance[TemplateId].GenerateType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMiscFilterType GetFilterType()
	{
		return Config.Misc.Instance[TemplateId].FilterType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetReduceEscapeRate()
	{
		return Config.Misc.Instance[TemplateId].ReduceEscapeRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetCombatUseEffect()
	{
		return Config.Misc.Instance[TemplateId].CombatUseEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetCombatPrepareUseEffect()
	{
		return Config.Misc.Instance[TemplateId].CombatPrepareUseEffect;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetGainExp()
	{
		return Config.Misc.Instance[TemplateId].GainExp;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanUseOnPrepareCombat()
	{
		return Config.Misc.Instance[TemplateId].CanUseOnPrepareCombat;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetUseFrame()
	{
		return Config.Misc.Instance[TemplateId].UseFrame;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetResourceAmount()
	{
		return Config.Misc.Instance[TemplateId].ResourceAmount;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowUseInPlayAndTest()
	{
		return Config.Misc.Instance[TemplateId].AllowUseInPlayAndTest;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Misc.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public IntPair GetFiveElementTransfer()
	{
		return Config.Misc.Instance[TemplateId].FiveElementTransfer;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetMaxNeili()
	{
		return Config.Misc.Instance[TemplateId].MaxNeili;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanTriggerCommonEvent()
	{
		return Config.Misc.Instance[TemplateId].CanTriggerCommonEvent;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Misc.Instance[TemplateId].FunctionDesc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public EMiscResourceMaterialType GetResourceMaterialType()
	{
		return Config.Misc.Instance[TemplateId].ResourceMaterialType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetHasGiftEvent()
	{
		return Config.Misc.Instance[TemplateId].HasGiftEvent;
	}

	public Misc()
	{
	}

	public Misc(short templateId)
	{
		MiscItem template = Config.Misc.Instance[templateId];
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

	public Misc(IRandomSource random, short templateId, int itemId)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return 0;
	}
}
