using System.Collections.Generic;
using GameData.Domains.Combat;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 人物伤病的全部显示数据
/// </summary>
[AutoGenerateSerializableGameData]
[SerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class CharacterInjuryDisplayData : ISerializableGameData
{
	/// <summary>
	/// 人物伤病数据
	/// </summary>
	[SerializableGameDataField]
	public Injuries Injuries;

	/// <summary>
	/// 强健数据
	/// </summary>
	[SerializableGameDataField]
	public CompleteDamageStepDisplayData CompleteDamageStepDisplayData;

	/// <summary>
	/// 身体残缺数据
	/// </summary>
	[SerializableGameDataField]
	public List<bool> AllBodyPartExists;

	/// <summary>
	/// 人物中毒数据
	/// </summary>
	[SerializableGameDataField]
	public PoisonInts Poisons;

	/// <summary>
	/// 人物毒抗数据
	/// </summary>
	[SerializableGameDataField]
	public PoisonInts PoisonResists;

	/// <summary>
	/// 是否免疫
	/// </summary>
	[SerializableGameDataField]
	public bool[] IsImmune;

	/// <summary>
	/// 是否先天免疫
	/// </summary>
	[SerializableGameDataField]
	public bool[] IsBornImmune;

	/// <summary>
	/// 内息紊乱当前值
	/// </summary>
	[SerializableGameDataField]
	public short DisorderOfQi;

	/// <summary>
	/// 内息紊乱变化值
	/// </summary>
	[SerializableGameDataField]
	public short ChangeOfQiDisorder;

	/// <summary>
	/// 调息对内息紊乱的影响
	/// </summary>
	[SerializableGameDataField]
	public short RecoveryOfQiDisorderChangeQiDisorderValue;

	/// <summary>
	/// 产业对内息紊乱的影响
	/// </summary>
	[SerializableGameDataField]
	public short BuildingChangeQiDisorderValue;

	/// <summary>
	/// 服食对内息紊乱的影响
	/// </summary>
	[SerializableGameDataField]
	public short EatItemChangeQiDisorderValue;

	/// <summary>
	/// 特性对内息紊乱的影响
	/// </summary>
	[SerializableGameDataField]
	public short FeatureChangeQiDisorderValue;

	/// <summary>
	/// 当前健康
	/// </summary>
	[SerializableGameDataField]
	public short Health;

	/// <summary>
	/// 剩余最大健康
	/// </summary>
	[SerializableGameDataField]
	public short LeftMaxHealth;

	/// <summary>
	/// 健康变动
	/// </summary>
	[SerializableGameDataField]
	public short HealthRecovery;

	/// <summary>
	/// 内息对健康的变动
	/// </summary>
	[SerializableGameDataField]
	public short DisorderOfQiChangeHealthValue;

	/// <summary>
	/// 伤势对对健康的变动
	/// </summary>
	[SerializableGameDataField]
	public short InjuryChangeHealthValue;

	/// <summary>
	/// 毒素对健康的变动
	/// </summary>
	[SerializableGameDataField]
	public short PoisonChangeHealthValue;

	/// <summary>
	/// 产业对健康的变动
	/// </summary>
	[SerializableGameDataField]
	public short BuildingChangeHealthValue;

	/// <summary>
	/// 服食对健康的变动
	/// </summary>
	[SerializableGameDataField]
	public short EatItemChangeHealthValue;

	/// <summary>
	/// 特性对健康的变动
	/// </summary>
	[SerializableGameDataField]
	public short FeatureChangeHealthValue;

	/// <summary>
	/// 特效系统对健康的变动
	/// </summary>
	[SerializableGameDataField]
	public short SpecialEffectChangeHealthValue;

	/// <summary>
	/// 战斗中出现的健康标记
	/// </summary>
	[SerializableGameDataField]
	public short HealthCombatMark;

	/// <summary>
	/// 最大可服食数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte CanEatingMaxCount;

	/// <summary>
	/// 已服食物品数据
	/// </summary>
	[SerializableGameDataField]
	public EatingItems EatingItems;

	/// <summary>
	/// 已服食物品的显示数据
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData[] EatingItemDisplayDataArray;

	[SerializableGameDataField]
	public MainAttributes CurMainAttributes;

	[SerializableGameDataField]
	public MainAttributes MaxMainAttributes;

	[SerializableGameDataField]
	public MainAttributes MainAttributeRecoveries;

	/// <summary>
	/// 当前内力
	/// </summary>
	[SerializableGameDataField]
	public int CurrNeili;

	/// <summary>
	/// 最大内力
	/// </summary>
	[SerializableGameDataField]
	public int MaxNeili;

	/// <summary>
	/// CharacterId
	/// </summary>
	[SerializableGameDataField]
	public int CharacterId;

	/// <summary>
	/// CharacterTemplateId
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 战斗中角色的参战前部分数据
	/// </summary>
	[SerializableGameDataField]
	public CombatCharacterDisplayData CombatCharacterDisplayData;

	/// <summary>
	/// 行囊的药品数量
	/// </summary>
	[SerializableGameDataField]
	public int InventoryMedicineItemCount;

	/// <summary>
	/// 剩余可服食数量
	/// </summary>
	public int AvailableEatingSlotsCount => EatingItems.GetAvailableEatingSlotsCount(CanEatingMaxCount);

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 53;
		totalSize += Injuries.GetSerializedSize();
		totalSize = ((CompleteDamageStepDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CompleteDamageStepDisplayData.GetSerializedSize())));
		totalSize = ((AllBodyPartExists == null) ? (totalSize + 2) : (totalSize + (2 + AllBodyPartExists.Count)));
		totalSize += Poisons.GetSerializedSize();
		totalSize += PoisonResists.GetSerializedSize();
		totalSize = ((IsImmune == null) ? (totalSize + 2) : (totalSize + (2 + IsImmune.Length)));
		totalSize = ((IsBornImmune == null) ? (totalSize + 2) : (totalSize + (2 + IsBornImmune.Length)));
		totalSize += EatingItems.GetSerializedSize();
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
		totalSize += CurMainAttributes.GetSerializedSize();
		totalSize += MaxMainAttributes.GetSerializedSize();
		totalSize += MainAttributeRecoveries.GetSerializedSize();
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
