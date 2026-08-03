using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Extra;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.SectMainStory;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class SectRanshanThreeCorpsesData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<SectStoryThreeCorpsesCharacter> ThreeCorpses;

	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayData> CharacterDisplayData;

	[SerializableGameDataField]
	public Dictionary<int, MainAttributes> CharacterAttributes;

	[SerializableGameDataField]
	public Dictionary<int, sbyte> LegendaryBookOwners;

	[SerializableGameDataField]
	public List<sbyte> CanKeepBooks;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (ThreeCorpses != null)
		{
			totalSize += 2;
			for (int i = 0; i < ThreeCorpses.Count; i++)
			{
				totalSize = ((ThreeCorpses[i] == null) ? (totalSize + 2) : (totalSize + (2 + ThreeCorpses[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (CharacterDisplayData != null)
		{
			foreach (KeyValuePair<int, CharacterDisplayData> pair in CharacterDisplayData)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (CharacterAttributes != null)
		{
			foreach (KeyValuePair<int, MainAttributes> pair2 in CharacterAttributes)
			{
				totalSize += 4;
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (LegendaryBookOwners != null)
		{
			foreach (KeyValuePair<int, sbyte> legendaryBookOwner in LegendaryBookOwners)
			{
				_ = legendaryBookOwner;
				totalSize += 4;
				totalSize++;
			}
		}
		totalSize = ((CanKeepBooks == null) ? (totalSize + 2) : (totalSize + (2 + CanKeepBooks.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ThreeCorpses != null)
		{
			int elementsCount = ThreeCorpses.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (ThreeCorpses[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = ThreeCorpses[i].Serialize(pCurrData);
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
		if (CharacterDisplayData != null)
		{
			*(int*)pCurrData = CharacterDisplayData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, CharacterDisplayData> pair in CharacterDisplayData)
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
		if (CharacterAttributes != null)
		{
			*(int*)pCurrData = CharacterAttributes.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, MainAttributes> pair2 in CharacterAttributes)
			{
				*(int*)pCurrData = pair2.Key;
				pCurrData += 4;
				pCurrData += pair2.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (LegendaryBookOwners != null)
		{
			*(int*)pCurrData = LegendaryBookOwners.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, sbyte> pair3 in LegendaryBookOwners)
			{
				*(int*)pCurrData = pair3.Key;
				pCurrData += 4;
				*pCurrData = (byte)pair3.Value;
				pCurrData++;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (CanKeepBooks != null)
		{
			int elementsCount2 = CanKeepBooks.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (byte)CanKeepBooks[j];
				pCurrData++;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ThreeCorpses == null)
			{
				ThreeCorpses = new List<SectStoryThreeCorpsesCharacter>();
			}
			else
			{
				ThreeCorpses.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				SectStoryThreeCorpsesCharacter element;
				if (num > 0)
				{
					element = new SectStoryThreeCorpsesCharacter();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				ThreeCorpses.Add(element);
			}
		}
		else
		{
			ThreeCorpses?.Clear();
		}
		int CharacterDisplayDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CharacterDisplayDataElementsCount > 0)
		{
			if (CharacterDisplayData == null)
			{
				CharacterDisplayData = new Dictionary<int, CharacterDisplayData>();
			}
			else
			{
				CharacterDisplayData.Clear();
			}
			for (int j = 0; j < CharacterDisplayDataElementsCount; j++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				CharacterDisplayData value = new CharacterDisplayData();
				pCurrData += value.Deserialize(pCurrData);
				CharacterDisplayData.Add(key, value);
			}
		}
		else
		{
			CharacterDisplayData?.Clear();
		}
		int CharacterAttributesElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CharacterAttributesElementsCount > 0)
		{
			if (CharacterAttributes == null)
			{
				CharacterAttributes = new Dictionary<int, MainAttributes>();
			}
			else
			{
				CharacterAttributes.Clear();
			}
			for (int k = 0; k < CharacterAttributesElementsCount; k++)
			{
				int key2 = *(int*)pCurrData;
				pCurrData += 4;
				MainAttributes value2 = default(MainAttributes);
				pCurrData += value2.Deserialize(pCurrData);
				CharacterAttributes.Add(key2, value2);
			}
		}
		else
		{
			CharacterAttributes?.Clear();
		}
		int LegendaryBookOwnersElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (LegendaryBookOwnersElementsCount > 0)
		{
			if (LegendaryBookOwners == null)
			{
				LegendaryBookOwners = new Dictionary<int, sbyte>();
			}
			else
			{
				LegendaryBookOwners.Clear();
			}
			for (int l = 0; l < LegendaryBookOwnersElementsCount; l++)
			{
				int key3 = *(int*)pCurrData;
				pCurrData += 4;
				sbyte value3 = (sbyte)(*pCurrData);
				pCurrData++;
				LegendaryBookOwners.Add(key3, value3);
			}
		}
		else
		{
			LegendaryBookOwners?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CanKeepBooks == null)
			{
				CanKeepBooks = new List<sbyte>();
			}
			else
			{
				CanKeepBooks.Clear();
			}
			for (int m = 0; m < elementsCount2; m++)
			{
				sbyte element2 = (sbyte)(*pCurrData);
				pCurrData++;
				CanKeepBooks.Add(element2);
			}
		}
		else
		{
			CanKeepBooks?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
