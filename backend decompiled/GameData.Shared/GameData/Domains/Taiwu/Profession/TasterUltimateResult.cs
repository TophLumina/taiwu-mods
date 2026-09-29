using System;
using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

[SerializableGameData(NoCopyConstructors = true)]
public class TasterUltimateResult : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayData> Characters = new Dictionary<int, CharacterDisplayData>();

	[SerializableGameDataField]
	public List<short> Books = new List<short>();

	[Obsolete]
	[SerializableGameDataField]
	public Dictionary<IntPair, IntPair> PracticeLevelData = new Dictionary<IntPair, IntPair>();

	[SerializableGameDataField]
	public Dictionary<IntPair, byte> ReadBookPageData = new Dictionary<IntPair, byte>();

	[SerializableGameDataField]
	public Dictionary<IntPair, bool> FavorabilityChangeData = new Dictionary<IntPair, bool>();

	[SerializableGameDataField]
	public Dictionary<IntPair, ushort> RelationChangeData = new Dictionary<IntPair, ushort>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(Characters);
		totalSize = ((Books == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Books.Count)));
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(PracticeLevelData);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(ReadBookPageData);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(FavorabilityChangeData);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(RelationChangeData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref Characters);
		if (Books != null)
		{
			int elementsCount = Books.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = Books[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Serialize(pCurrData, ref PracticeLevelData);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref ReadBookPageData);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref FavorabilityChangeData);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref RelationChangeData);
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref Characters);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Books == null)
			{
				Books = new List<short>(elementsCount);
			}
			else
			{
				Books.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Books.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			Books?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pCurrData, ref PracticeLevelData);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref ReadBookPageData);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref FavorabilityChangeData);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref RelationChangeData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
