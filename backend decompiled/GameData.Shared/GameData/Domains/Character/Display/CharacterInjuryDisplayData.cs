using System.Collections.Generic;
using GameData.Domains.Combat;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData]
[SerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class CharacterInjuryDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public Injuries Injuries;

	[SerializableGameDataField]
	public CompleteDamageStepDisplayData CompleteDamageStepDisplayData;

	[SerializableGameDataField]
	public List<bool> AllBodyPartExists;

	[SerializableGameDataField]
	public PoisonInts Poisons;

	[SerializableGameDataField]
	public PoisonInts PoisonResists;

	[SerializableGameDataField]
	public bool[] IsImmune;

	[SerializableGameDataField]
	public bool[] IsBornImmune;

	[SerializableGameDataField]
	public short DisorderOfQi;

	[SerializableGameDataField]
	public short ChangeOfQiDisorder;

	[SerializableGameDataField]
	public short RecoveryOfQiDisorderChangeQiDisorderValue;

	[SerializableGameDataField]
	public short BuildingChangeQiDisorderValue;

	[SerializableGameDataField]
	public short EatItemChangeQiDisorderValue;

	[SerializableGameDataField]
	public short FeatureChangeQiDisorderValue;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public short LeftMaxHealth;

	[SerializableGameDataField]
	public short HealthRecovery;

	[SerializableGameDataField]
	public short DisorderOfQiChangeHealthValue;

	[SerializableGameDataField]
	public short InjuryChangeHealthValue;

	[SerializableGameDataField]
	public short PoisonChangeHealthValue;

	[SerializableGameDataField]
	public short BuildingChangeHealthValue;

	[SerializableGameDataField]
	public short EatItemChangeHealthValue;

	[SerializableGameDataField]
	public short FeatureChangeHealthValue;

	[SerializableGameDataField]
	public short SpecialEffectChangeHealthValue;

	[SerializableGameDataField]
	public short HealthCombatMark;

	[SerializableGameDataField]
	public sbyte CanEatingMaxCount;

	[SerializableGameDataField]
	public EatingItems EatingItems;

	[SerializableGameDataField]
	public ItemDisplayData[] EatingItemDisplayDataArray;

	[SerializableGameDataField]
	public MainAttributes CurMainAttributes;

	[SerializableGameDataField]
	public MainAttributes MaxMainAttributes;

	[SerializableGameDataField]
	public MainAttributes MainAttributeRecoveries;

	[SerializableGameDataField]
	public int CurrNeili;

	[SerializableGameDataField]
	public int MaxNeili;

	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public CombatCharacterDisplayData CombatCharacterDisplayData;

	[SerializableGameDataField]
	public int InventoryMedicineItemCount;

	public int AvailableEatingSlotsCount => EatingItems.GetAvailableEatingSlotsCount(CanEatingMaxCount);

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 697;
		totalSize = ((AllBodyPartExists == null) ? (totalSize + 2) : (totalSize + (2 + AllBodyPartExists.Count)));
		totalSize = ((IsImmune == null) ? (totalSize + 2) : (totalSize + (2 + IsImmune.Length)));
		totalSize = ((IsBornImmune == null) ? (totalSize + 2) : (totalSize + (2 + IsBornImmune.Length)));
		if (EatingItemDisplayDataArray != null)
		{
			totalSize += 2;
			for (int i = 0; i < EatingItemDisplayDataArray.Length; i++)
			{
				totalSize = ((EatingItemDisplayDataArray[i] == null) ? (totalSize + 2) : (totalSize + (2 + EatingItemDisplayDataArray[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((CombatCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CombatCharacterDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Injuries.Serialize(pCurrData);
		pCurrData += CompleteDamageStepDisplayData.Serialize(pCurrData);
		if (AllBodyPartExists != null)
		{
			int elementsCount = AllBodyPartExists.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (AllBodyPartExists[i] ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Poisons.Serialize(pCurrData);
		pCurrData += PoisonResists.Serialize(pCurrData);
		if (IsImmune != null)
		{
			int elementsCount2 = IsImmune.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (IsImmune[j] ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (IsBornImmune != null)
		{
			int elementsCount3 = IsBornImmune.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*pCurrData = (IsBornImmune[k] ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = DisorderOfQi;
		pCurrData += 2;
		*(short*)pCurrData = ChangeOfQiDisorder;
		pCurrData += 2;
		*(short*)pCurrData = RecoveryOfQiDisorderChangeQiDisorderValue;
		pCurrData += 2;
		*(short*)pCurrData = BuildingChangeQiDisorderValue;
		pCurrData += 2;
		*(short*)pCurrData = EatItemChangeQiDisorderValue;
		pCurrData += 2;
		*(short*)pCurrData = FeatureChangeQiDisorderValue;
		pCurrData += 2;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		*(short*)pCurrData = HealthRecovery;
		pCurrData += 2;
		*(short*)pCurrData = DisorderOfQiChangeHealthValue;
		pCurrData += 2;
		*(short*)pCurrData = InjuryChangeHealthValue;
		pCurrData += 2;
		*(short*)pCurrData = PoisonChangeHealthValue;
		pCurrData += 2;
		*(short*)pCurrData = BuildingChangeHealthValue;
		pCurrData += 2;
		*(short*)pCurrData = EatItemChangeHealthValue;
		pCurrData += 2;
		*(short*)pCurrData = FeatureChangeHealthValue;
		pCurrData += 2;
		*(short*)pCurrData = SpecialEffectChangeHealthValue;
		pCurrData += 2;
		*(short*)pCurrData = HealthCombatMark;
		pCurrData += 2;
		*pCurrData = (byte)CanEatingMaxCount;
		pCurrData++;
		pCurrData += EatingItems.Serialize(pCurrData);
		if (EatingItemDisplayDataArray != null)
		{
			int elementsCount4 = EatingItemDisplayDataArray.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (EatingItemDisplayDataArray[l] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = EatingItemDisplayDataArray[l].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += CurMainAttributes.Serialize(pCurrData);
		pCurrData += MaxMainAttributes.Serialize(pCurrData);
		pCurrData += MainAttributeRecoveries.Serialize(pCurrData);
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		*(int*)pCurrData = MaxNeili;
		pCurrData += 4;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		if (CombatCharacterDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = CombatCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = InventoryMedicineItemCount;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Injuries.Deserialize(pCurrData);
		CompleteDamageStepDisplayData = new CompleteDamageStepDisplayData();
		pCurrData += CompleteDamageStepDisplayData.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (AllBodyPartExists == null)
			{
				AllBodyPartExists = new List<bool>();
			}
			else
			{
				AllBodyPartExists.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				bool element = *pCurrData != 0;
				pCurrData++;
				AllBodyPartExists.Add(element);
			}
		}
		else
		{
			AllBodyPartExists?.Clear();
		}
		pCurrData += Poisons.Deserialize(pCurrData);
		pCurrData += PoisonResists.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (IsImmune == null || IsImmune.Length != elementsCount2)
			{
				IsImmune = new bool[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				IsImmune[j] = *pCurrData != 0;
				pCurrData++;
			}
		}
		else
		{
			IsImmune = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (IsBornImmune == null || IsBornImmune.Length != elementsCount3)
			{
				IsBornImmune = new bool[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				IsBornImmune[k] = *pCurrData != 0;
				pCurrData++;
			}
		}
		else
		{
			IsBornImmune = null;
		}
		DisorderOfQi = *(short*)pCurrData;
		pCurrData += 2;
		ChangeOfQiDisorder = *(short*)pCurrData;
		pCurrData += 2;
		RecoveryOfQiDisorderChangeQiDisorderValue = *(short*)pCurrData;
		pCurrData += 2;
		BuildingChangeQiDisorderValue = *(short*)pCurrData;
		pCurrData += 2;
		EatItemChangeQiDisorderValue = *(short*)pCurrData;
		pCurrData += 2;
		FeatureChangeQiDisorderValue = *(short*)pCurrData;
		pCurrData += 2;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		HealthRecovery = *(short*)pCurrData;
		pCurrData += 2;
		DisorderOfQiChangeHealthValue = *(short*)pCurrData;
		pCurrData += 2;
		InjuryChangeHealthValue = *(short*)pCurrData;
		pCurrData += 2;
		PoisonChangeHealthValue = *(short*)pCurrData;
		pCurrData += 2;
		BuildingChangeHealthValue = *(short*)pCurrData;
		pCurrData += 2;
		EatItemChangeHealthValue = *(short*)pCurrData;
		pCurrData += 2;
		FeatureChangeHealthValue = *(short*)pCurrData;
		pCurrData += 2;
		SpecialEffectChangeHealthValue = *(short*)pCurrData;
		pCurrData += 2;
		HealthCombatMark = *(short*)pCurrData;
		pCurrData += 2;
		CanEatingMaxCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += EatingItems.Deserialize(pCurrData);
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (EatingItemDisplayDataArray == null || EatingItemDisplayDataArray.Length != elementsCount4)
			{
				EatingItemDisplayDataArray = new ItemDisplayData[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					EatingItemDisplayDataArray[l] = new ItemDisplayData();
					pCurrData += EatingItemDisplayDataArray[l].Deserialize(pCurrData);
				}
				else
				{
					EatingItemDisplayDataArray[l] = null;
				}
			}
		}
		else
		{
			EatingItemDisplayDataArray = null;
		}
		pCurrData += CurMainAttributes.Deserialize(pCurrData);
		pCurrData += MaxMainAttributes.Deserialize(pCurrData);
		pCurrData += MainAttributeRecoveries.Deserialize(pCurrData);
		CurrNeili = *(int*)pCurrData;
		pCurrData += 4;
		MaxNeili = *(int*)pCurrData;
		pCurrData += 4;
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			CombatCharacterDisplayData = new CombatCharacterDisplayData();
			pCurrData += CombatCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CombatCharacterDisplayData = null;
		}
		InventoryMedicineItemCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
