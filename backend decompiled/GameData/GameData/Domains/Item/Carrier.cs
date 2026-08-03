using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.Common;
using GameData.DLC.FiveLoong;
using GameData.Dependencies;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Item;

[SerializableGameData(NotForDisplayModule = true)]
public class Carrier : EquipmentBase, ISerializableGameData
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
		return Config.Carrier.Instance[TemplateId].Name;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetItemType()
	{
		return Config.Carrier.Instance[TemplateId].ItemType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetItemSubType()
	{
		return Config.Carrier.Instance[TemplateId].ItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetGrade()
	{
		return Config.Carrier.Instance[TemplateId].Grade;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetIcon()
	{
		return Config.Carrier.Instance[TemplateId].Icon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override string GetDesc()
	{
		return Config.Carrier.Instance[TemplateId].Desc;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetTransferable()
	{
		return Config.Carrier.Instance[TemplateId].Transferable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetStackable()
	{
		return Config.Carrier.Instance[TemplateId].Stackable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetWagerable()
	{
		return Config.Carrier.Instance[TemplateId].Wagerable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRefinable()
	{
		return Config.Carrier.Instance[TemplateId].Refinable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetPoisonable()
	{
		return Config.Carrier.Instance[TemplateId].Poisonable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetRepairable()
	{
		return Config.Carrier.Instance[TemplateId].Repairable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseWeight()
	{
		return Config.Carrier.Instance[TemplateId].BaseWeight;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseValue()
	{
		return Config.Carrier.Instance[TemplateId].BaseValue;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetDropRate()
	{
		return Config.Carrier.Instance[TemplateId].DropRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetResourceType()
	{
		return Config.Carrier.Instance[TemplateId].ResourceType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override short GetPreservationDuration()
	{
		return Config.Carrier.Instance[TemplateId].PreservationDuration;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetEquipmentType()
	{
		return Config.Carrier.Instance[TemplateId].EquipmentType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsFlying()
	{
		return Config.Carrier.Instance[TemplateId].IsFlying;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMakeItemSubType()
	{
		return Config.Carrier.Instance[TemplateId].MakeItemSubType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override sbyte GetBaseHappinessChange()
	{
		return Config.Carrier.Instance[TemplateId].BaseHappinessChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override int GetBaseFavorabilityChange()
	{
		return Config.Carrier.Instance[TemplateId].BaseFavorabilityChange;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetGiftLevel()
	{
		return Config.Carrier.Instance[TemplateId].GiftLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<short> GetHateFoodType()
	{
		return Config.Carrier.Instance[TemplateId].HateFoodType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetTamePoint()
	{
		return Config.Carrier.Instance[TemplateId].TamePoint;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetCombatState()
	{
		return Config.Carrier.Instance[TemplateId].CombatState;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseCaptureRateBonus()
	{
		return Config.Carrier.Instance[TemplateId].BaseCaptureRateBonus;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseMaxKidnapSlotCountBonus()
	{
		return Config.Carrier.Instance[TemplateId].BaseMaxKidnapSlotCountBonus;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseMaxInventoryLoadBonus()
	{
		return Config.Carrier.Instance[TemplateId].BaseMaxInventoryLoadBonus;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetBaseTravelTimeReduction()
	{
		return Config.Carrier.Instance[TemplateId].BaseTravelTimeReduction;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<short> GetLoveFoodType()
	{
		return Config.Carrier.Instance[TemplateId].LoveFoodType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseDropRateBonus()
	{
		return Config.Carrier.Instance[TemplateId].BaseDropRateBonus;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 7)]
	public sbyte[] GetTamePersonalities()
	{
		return Config.Carrier.Instance[TemplateId].TamePersonalities;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override bool GetDetachable()
	{
		return Config.Carrier.Instance[TemplateId].Detachable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetCharacterIdInCombat()
	{
		return Config.Carrier.Instance[TemplateId].CharacterIdInCombat;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetMerchantLevel()
	{
		return Config.Carrier.Instance[TemplateId].MerchantLevel;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowRandomCreate()
	{
		return Config.Carrier.Instance[TemplateId].AllowRandomCreate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetTravelSkeleton()
	{
		return Config.Carrier.Instance[TemplateId].TravelSkeleton;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetStandDisplay()
	{
		return Config.Carrier.Instance[TemplateId].StandDisplay;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Carrier.Instance[TemplateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public ref readonly PoisonsAndLevels GetInnatePoisons()
	{
		return ref Config.Carrier.Instance[TemplateId].InnatePoisons;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsSpecial()
	{
		return Config.Carrier.Instance[TemplateId].IsSpecial;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInheritable()
	{
		return Config.Carrier.Instance[TemplateId].Inheritable;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetEquipmentCombatPowerValueFactor()
	{
		return Config.Carrier.Instance[TemplateId].EquipmentCombatPowerValueFactor;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseExploreBonusRate()
	{
		return Config.Carrier.Instance[TemplateId].BaseExploreBonusRate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public override List<int> GetTaskLock()
	{
		return Config.Carrier.Instance[TemplateId].TaskLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFunctionDesc()
	{
		return Config.Carrier.Instance[TemplateId].FunctionDesc;
	}

	public Carrier()
	{
	}

	public Carrier(short templateId)
	{
		CarrierItem template = Config.Carrier.Instance[templateId];
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

	[ObjectCollectionDependency(6, 4, new ushort[] { 6 }, Scope = InfluenceScope.Self)]
	private short CalcEquippedPower()
	{
		GameData.Domains.Character.Character element;
		return (short)(DomainManager.Character.TryGetElement_Objects(EquippedCharId, out element) ? 100 : 0);
	}

	public Carrier(IRandomSource random, short templateId, int itemId)
		: this(templateId)
	{
		Id = itemId;
		MaxDurability = ItemBase.GenerateMaxDurability(random, MaxDurability);
		CurrDurability = MaxDurability;
	}

	public override int GetCharacterPropertyBonus(ECharacterPropertyReferencedType type)
	{
		if (type >= ECharacterPropertyReferencedType.PersonalityCalm && type <= ECharacterPropertyReferencedType.PersonalityPerceptive && DomainManager.Extra.IsCarrierFullTamePoint(GetItemKey()) && !IsDurabilityRunningOut())
		{
			int personalityIndex = (int)(type - 94);
			return GetTamePersonalities()[personalityIndex];
		}
		return 0;
	}

	public sbyte GetTravelTimeReduction()
	{
		if (IsDurabilityRunningOut())
		{
			return 0;
		}
		sbyte res = Config.Carrier.Instance[TemplateId].BaseTravelTimeReduction;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += (sbyte)jiao.Properties.Get(jiao.TemplateId, 0);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += (sbyte)loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 0);
		}
		return res;
	}

	public short GetMaxInventoryLoadBonus()
	{
		if (IsDurabilityRunningOut())
		{
			return 0;
		}
		short res = Config.Carrier.Instance[TemplateId].BaseMaxInventoryLoadBonus;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += (short)jiao.Properties.Get(jiao.TemplateId, 1);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += (short)loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 1);
		}
		return res;
	}

	public short GetDropRateBonus()
	{
		if (IsDurabilityRunningOut())
		{
			return 0;
		}
		short res = Config.Carrier.Instance[TemplateId].BaseDropRateBonus;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += (short)jiao.Properties.Get(jiao.TemplateId, 2);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += (short)loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 2);
		}
		return res;
	}

	public short GetCaptureRateBonus()
	{
		if (IsDurabilityRunningOut())
		{
			return 0;
		}
		short res = Config.Carrier.Instance[TemplateId].BaseCaptureRateBonus;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += (short)jiao.Properties.Get(jiao.TemplateId, 3);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += (short)loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 3);
		}
		return res;
	}

	public int GetExploreBonusRate()
	{
		if (IsDurabilityRunningOut())
		{
			return 0;
		}
		int res = GetBaseExploreBonusRate();
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += jiao.Properties.Get(jiao.TemplateId, 5);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 5);
		}
		return res;
	}

	public short GetMaxKidnapSlotCountBonus()
	{
		if (IsDurabilityRunningOut())
		{
			return 0;
		}
		short res = Config.Carrier.Instance[TemplateId].BaseMaxKidnapSlotCountBonus;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += (short)jiao.Properties.Get(jiao.TemplateId, 4);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += (short)loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 4);
		}
		return res;
	}

	public override int GetValue()
	{
		int res = Config.Carrier.Instance[TemplateId].BaseValue;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += jiao.Properties.Get(jiao.TemplateId, 6);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 6);
		}
		return ApplyDurabilityEffect(res);
	}

	public override sbyte GetHappinessChange()
	{
		sbyte res = Config.Carrier.Instance[TemplateId].BaseHappinessChange;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += (sbyte)jiao.Properties.Get(jiao.TemplateId, 7);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += (sbyte)loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 7);
		}
		return (sbyte)ApplyDurabilityEffect(res);
	}

	public override int GetFavorabilityChange()
	{
		int res = Config.Carrier.Instance[TemplateId].BaseFavorabilityChange;
		ChildrenOfLoong loong;
		if (DomainManager.Extra.TryGetJiaoIdByItemKey(GetItemKey(), out var id) && DomainManager.Extra.TryGetJiao(id, out var jiao))
		{
			res += jiao.Properties.Get(jiao.TemplateId, 8);
		}
		else if (DomainManager.Extra.TryGetChildrenOfLoongIdByItemKey(GetItemKey(), out id) && DomainManager.Extra.TryGetLoong(id, out loong))
		{
			res += loong.Properties.Get(loong.JiaoTemplateId, loong.LoongTemplateId, 8);
		}
		return ApplyDurabilityEffect(res);
	}
}
