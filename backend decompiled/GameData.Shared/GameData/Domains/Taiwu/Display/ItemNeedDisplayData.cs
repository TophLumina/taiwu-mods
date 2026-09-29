using System.Collections.Generic;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ItemNeedDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	[SerializableGameDataField]
	public List<ItemNeedCharacterDisplayData> CharacterDisplayDataList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		if (CharacterDisplayDataList != null)
		{
			totalSize += 2;
			int elementsCount = CharacterDisplayDataList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemNeedCharacterDisplayData element = CharacterDisplayDataList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
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
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CharacterDisplayDataList != null)
		{
			int elementsCount = CharacterDisplayDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemNeedCharacterDisplayData element = CharacterDisplayDataList[i];
				if (element != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize;
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
			if (ItemDisplayData == null)
			{
				ItemDisplayData = new ItemDisplayData();
			}
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CharacterDisplayDataList == null)
			{
				CharacterDisplayDataList = new List<ItemNeedCharacterDisplayData>(elementsCount);
			}
			else
			{
				CharacterDisplayDataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					ItemNeedCharacterDisplayData element = new ItemNeedCharacterDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					CharacterDisplayDataList.Add(element);
				}
				else
				{
					CharacterDisplayDataList.Add(null);
				}
			}
		}
		else
		{
			CharacterDisplayDataList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
