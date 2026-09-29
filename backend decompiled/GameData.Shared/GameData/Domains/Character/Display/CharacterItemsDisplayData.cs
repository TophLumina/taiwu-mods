using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Story.MainStory;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData]
[SerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class CharacterItemsDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterLoveAndHateItemInfo CharacterLoveAndHateItemInfo;

	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	[SerializableGameDataField]
	public CharacterDisplayData TaiwuCharacterDisplayData;

	[SerializableGameDataField]
	public ResourceInts Resources;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public MainAttributes CurMainAttributes;

	[SerializableGameDataField]
	public int CurrNeili;

	[SerializableGameDataField]
	public int MaxNeili;

	[SerializableGameDataField]
	public int Exp;

	[SerializableGameDataField]
	public int CurLoad;

	[SerializableGameDataField]
	public int MaxLoad;

	[SerializableGameDataField]
	public int MoveTimeCostPercent;

	[SerializableGameDataField]
	public long MaxWorthCanBeLentToTaiwu;

	[SerializableGameDataField]
	public int NeedleAmount;

	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryItems;

	[SerializableGameDataField]
	public EatingItems EatingItems;

	[SerializableGameDataField]
	public sbyte CanEatingMaxCount;

	[SerializableGameDataField]
	public ItemKey EmptyToolKey;

	[SerializableGameDataField]
	public DivineFlameData DivineFlameData;

	[SerializableGameDataField]
	public bool[] DivineFlameTargetState;

	[SerializableGameDataField]
	public CharacterDisplayData DivineFlameTargetCharacter;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 233;
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		totalSize = ((TaiwuCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + TaiwuCharacterDisplayData.GetSerializedSize())));
		if (InventoryItems != null)
		{
			totalSize += 2;
			for (int i = 0; i < InventoryItems.Count; i++)
			{
				totalSize = ((InventoryItems[i] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryItems[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((DivineFlameData == null) ? (totalSize + 2) : (totalSize + (2 + DivineFlameData.GetSerializedSize())));
		totalSize = ((DivineFlameTargetState == null) ? (totalSize + 2) : (totalSize + (2 + DivineFlameTargetState.Length)));
		totalSize = ((DivineFlameTargetCharacter == null) ? (totalSize + 2) : (totalSize + (2 + DivineFlameTargetCharacter.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += CharacterLoveAndHateItemInfo.Serialize(pCurrData);
		if (CharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuCharacterDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = TaiwuCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Resources.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += CurMainAttributes.Serialize(pCurrData);
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		*(int*)pCurrData = MaxNeili;
		pCurrData += 4;
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		*(int*)pCurrData = CurLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxLoad;
		pCurrData += 4;
		*(int*)pCurrData = MoveTimeCostPercent;
		pCurrData += 4;
		*(long*)pCurrData = MaxWorthCanBeLentToTaiwu;
		pCurrData += 8;
		*(int*)pCurrData = NeedleAmount;
		pCurrData += 4;
		if (InventoryItems != null)
		{
			int elementsCount = InventoryItems.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (InventoryItems[i] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = InventoryItems[i].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		pCurrData += EatingItems.Serialize(pCurrData);
		*pCurrData = (byte)CanEatingMaxCount;
		pCurrData++;
		pCurrData += EmptyToolKey.Serialize(pCurrData);
		if (DivineFlameData != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = DivineFlameData.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DivineFlameTargetState != null)
		{
			int elementsCount2 = DivineFlameTargetState.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (DivineFlameTargetState[j] ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DivineFlameTargetCharacter != null)
		{
			byte* intPtr5 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = DivineFlameTargetCharacter.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr5 = (ushort)fieldSize5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		CharacterLoveAndHateItemInfo = new CharacterLoveAndHateItemInfo();
		pCurrData += CharacterLoveAndHateItemInfo.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			TaiwuCharacterDisplayData = new CharacterDisplayData();
			pCurrData += TaiwuCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TaiwuCharacterDisplayData = null;
		}
		pCurrData += Resources.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += CurMainAttributes.Deserialize(pCurrData);
		CurrNeili = *(int*)pCurrData;
		pCurrData += 4;
		MaxNeili = *(int*)pCurrData;
		pCurrData += 4;
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		CurLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxLoad = *(int*)pCurrData;
		pCurrData += 4;
		MoveTimeCostPercent = *(int*)pCurrData;
		pCurrData += 4;
		MaxWorthCanBeLentToTaiwu = *(long*)pCurrData;
		pCurrData += 8;
		NeedleAmount = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (InventoryItems == null)
			{
				InventoryItems = new List<ItemDisplayData>();
			}
			else
			{
				InventoryItems.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num3 > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				InventoryItems.Add(element);
			}
		}
		else
		{
			InventoryItems?.Clear();
		}
		pCurrData += EatingItems.Deserialize(pCurrData);
		CanEatingMaxCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += EmptyToolKey.Deserialize(pCurrData);
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			DivineFlameData = new DivineFlameData();
			pCurrData += DivineFlameData.Deserialize(pCurrData);
		}
		else
		{
			DivineFlameData = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (DivineFlameTargetState == null || DivineFlameTargetState.Length != elementsCount2)
			{
				DivineFlameTargetState = new bool[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				DivineFlameTargetState[j] = *pCurrData != 0;
				pCurrData++;
			}
		}
		else
		{
			DivineFlameTargetState = null;
		}
		ushort num5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num5 > 0)
		{
			DivineFlameTargetCharacter = new CharacterDisplayData();
			pCurrData += DivineFlameTargetCharacter.Deserialize(pCurrData);
		}
		else
		{
			DivineFlameTargetCharacter = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
