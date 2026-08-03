using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.Common;
using GameData.Dependencies;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Clothing : EquipmentBase, ISerializableGameData
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

		public const uint Gender_Offset = 17u;

		public const int Gender_Size = 1;

		public const uint MaterialResources_Offset = 18u;

		public const int MaterialResources_Size = 12;
	}

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _gender;

	public const int FixedSize = 30;

	public const int DynamicCount = 0;

	private SpinLock _spinLock = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly ushort[] ArchiveFieldIds = new ushort[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

	private static readonly int[] FixedArchiveFieldSizes = new int[9] { 4, 2, 2, 2, 2, 1, 4, 1, 12 };

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

	public sbyte GetGender()
	{
		return _gender;
	}

	public void SetGender(sbyte gender, DataContext context)
	{
		_gender = gender;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public override void SetMaterialResources(MaterialResources materialResources, DataContext context)
	{
		MaterialResources = materialResources;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public override short GetEquippedPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 9))
		{
			return EquippedPower;
		}
		short value = CalcEquippedPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			EquippedPower = value;
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
		return EquippedPower;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetName()
	{
		return Config.Clothing.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Clothing.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Clothing.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Clothing.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Clothing.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Clothing.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Clothing.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Clothing.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Clothing.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Clothing.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Clothing.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Clothing.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Clothing.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Clothing.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Clothing.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Clothing.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Clothing.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetEquipmentType()
	{
		return Config.Clothing.Instance[TemplateId].EquipmentType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetDisplayId()
	{
		return Config.Clothing.Instance[TemplateId].DisplayId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetAgeGroup()
	{
		return Config.Clothing.Instance[TemplateId].AgeGroup;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetKeepOnPassing()
	{
		return Config.Clothing.Instance[TemplateId].KeepOnPassing;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMakeItemSubType()
	{
		return Config.Clothing.Instance[TemplateId].MakeItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Clothing.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Clothing.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Clothing.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetDetachable()
	{
		return Config.Clothing.Instance[TemplateId].Detachable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Clothing.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetWeaveNeedAttainment()
	{
		return Config.Clothing.Instance[TemplateId].WeaveNeedAttainment;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetWeaveType()
	{
		return Config.Clothing.Instance[TemplateId].WeaveType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetDlcName()
	{
		return Config.Clothing.Instance[TemplateId].DlcName;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSmallVillageDesc()
	{
		return Config.Clothing.Instance[TemplateId].SmallVillageDesc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Clothing.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Clothing.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Clothing.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Clothing.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEquipmentCombatPowerValueFactor()
	{
		return Config.Clothing.Instance[TemplateId].EquipmentCombatPowerValueFactor;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Clothing.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Clothing.Instance[TemplateId].FunctionDesc;
	}

	public Clothing()
	{
	}

	public Clothing(short templateId)
	{
		ClothingItem template = Config.Clothing.Instance[templateId];
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
		return 30;
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
		*pCurrData = (byte)_gender;
		pCurrData++;
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
				_gender = (sbyte)(*pCurrData);
				pCurrData++;
				continue;
			case 8:
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

	[ObjectCollectionDependency(6, 3, new ushort[] { 6 }, Scope = InfluenceScope.Self)]
	private short CalcEquippedPower()
	{
		GameData.Domains.Character.Character element;
		return (short)(DomainManager.Character.TryGetElement_Objects(EquippedCharId, out element) ? 100 : 0);
	}

	public Clothing(IRandomSource random, short templateId, int itemId, sbyte gender)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
		_gender = gender;
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		return 0;
	}
}
