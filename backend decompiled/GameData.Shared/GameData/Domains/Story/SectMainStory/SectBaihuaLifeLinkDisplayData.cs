using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.SectMainStory;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class SectBaihuaLifeLinkDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public SectBaihuaLifeLinkData Data;

	[SerializableGameDataField]
	public sbyte NeiliType;

	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayDataForLifeLink> CharacterDisplayData;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize = ((Data == null) ? (totalSize + 2) : (totalSize + (2 + Data.GetSerializedSize())));
		totalSize += 4;
		if (CharacterDisplayData != null)
		{
			foreach (KeyValuePair<int, CharacterDisplayDataForLifeLink> pair in CharacterDisplayData)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
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
		if (Data != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Data.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)NeiliType;
		pCurrData++;
		if (CharacterDisplayData != null)
		{
			*(int*)pCurrData = CharacterDisplayData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, CharacterDisplayDataForLifeLink> pair in CharacterDisplayData)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
			Data = new SectBaihuaLifeLinkData();
			pCurrData += Data.Deserialize(pCurrData);
		}
		else
		{
			Data = null;
		}
		NeiliType = (sbyte)(*pCurrData);
		pCurrData++;
		int CharacterDisplayDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CharacterDisplayDataElementsCount > 0)
		{
			if (CharacterDisplayData == null)
			{
				CharacterDisplayData = new Dictionary<int, CharacterDisplayDataForLifeLink>();
			}
			else
			{
				CharacterDisplayData.Clear();
			}
			for (int i = 0; i < CharacterDisplayDataElementsCount; i++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				CharacterDisplayDataForLifeLink value = new CharacterDisplayDataForLifeLink();
				pCurrData += value.Deserialize(pCurrData);
				CharacterDisplayData.Add(key, value);
			}
		}
		else
		{
			CharacterDisplayData?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
