using System;
using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public struct CharacterSelectFilter : ISerializableGameData
{
	[SerializableGameDataField]
	public short FilterTemplateId;

	[SerializableGameDataField]
	public string SelectKey;

	[Obsolete]
	[SerializableGameDataField]
	public CharacterSet AvailableCharacters;

	[SerializableGameDataField]
	public List<CharacterDisplayData> AvailableCharactersDisplayDataList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((SelectKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SelectKey.Length)));
		totalSize += AvailableCharacters.GetSerializedSize();
		if (AvailableCharactersDisplayDataList != null)
		{
			totalSize += 2;
			int elementsCount = AvailableCharactersDisplayDataList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterDisplayData element = AvailableCharactersDisplayDataList[i];
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
		*(short*)pCurrData = FilterTemplateId;
		pCurrData += 2;
		if (SelectKey != null)
		{
			int elementsCount = SelectKey.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = SelectKey)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize = AvailableCharacters.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (AvailableCharactersDisplayDataList != null)
		{
			int elementsCount2 = AvailableCharactersDisplayDataList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterDisplayData element = AvailableCharactersDisplayDataList[j];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
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
		FilterTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			SelectKey = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			SelectKey = null;
		}
		pCurrData += AvailableCharacters.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (AvailableCharactersDisplayDataList == null)
			{
				AvailableCharactersDisplayDataList = new List<CharacterDisplayData>(elementsCount2);
			}
			else
			{
				AvailableCharactersDisplayDataList.Clear();
			}
			for (int i = 0; i < elementsCount2; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					CharacterDisplayData element = new CharacterDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					AvailableCharactersDisplayDataList.Add(element);
				}
				else
				{
					AvailableCharactersDisplayDataList.Add(null);
				}
			}
		}
		else
		{
			AvailableCharactersDisplayDataList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
