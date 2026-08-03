using System.Collections.Generic;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class CharacterDisplayDataForBeggarUltimate : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayData CharacterData;

	[SerializableGameDataField]
	public List<ItemDisplayData> ItemDataList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((CharacterData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterData.GetSerializedSize())));
		if (ItemDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < ItemDataList.Count; i++)
			{
				totalSize = ((ItemDataList[i] == null) ? (totalSize + 2) : (totalSize + (2 + ItemDataList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CharacterData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ItemDataList != null)
		{
			int elementsCount = ItemDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (ItemDataList[i] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = ItemDataList[i].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharacterData = new CharacterDisplayData();
			pCurrData += CharacterData.Deserialize(pCurrData);
		}
		else
		{
			CharacterData = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ItemDataList == null)
			{
				ItemDataList = new List<ItemDisplayData>();
			}
			else
			{
				ItemDataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num2 > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				ItemDataList.Add(element);
			}
		}
		else
		{
			ItemDataList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
