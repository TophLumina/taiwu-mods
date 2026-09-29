using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(NotForArchive = true, NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class LegacyDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayData OldTaiwuChar;

	[SerializableGameDataField]
	public CharacterDisplayData InheritChar;

	[SerializableGameDataField]
	public int TaiwuGenerationsCount;

	[SerializableGameDataField]
	public int LegacyPoint;

	[SerializableGameDataField]
	public int LegacyPointBonusFactor;

	[SerializableGameDataField]
	public Dictionary<short, int> LegacyPointDict;

	[SerializableGameDataField]
	public Dictionary<short, short> LegacyPointTimesDict;

	[SerializableGameDataField]
	public List<short> AvailableLegacyList;

	[SerializableGameDataField]
	public WorldCreationInfo WorldCreationInfo;

	[SerializableGameDataField]
	public ChallengeModeData ChallengeModeData;

	[SerializableGameDataField]
	public int SectJieqingExtraLegacyPoints;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 36;
		totalSize = ((OldTaiwuChar == null) ? (totalSize + 2) : (totalSize + (2 + OldTaiwuChar.GetSerializedSize())));
		totalSize = ((InheritChar == null) ? (totalSize + 2) : (totalSize + (2 + InheritChar.GetSerializedSize())));
		totalSize += 4;
		if (LegacyPointDict != null)
		{
			foreach (KeyValuePair<short, int> item in LegacyPointDict)
			{
				_ = item;
				totalSize += 2;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (LegacyPointTimesDict != null)
		{
			foreach (KeyValuePair<short, short> item2 in LegacyPointTimesDict)
			{
				_ = item2;
				totalSize += 2;
				totalSize += 2;
			}
		}
		totalSize = ((AvailableLegacyList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AvailableLegacyList.Count)));
		totalSize = ((ChallengeModeData == null) ? (totalSize + 2) : (totalSize + (2 + ChallengeModeData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (OldTaiwuChar != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = OldTaiwuChar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InheritChar != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = InheritChar.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = TaiwuGenerationsCount;
		pCurrData += 4;
		*(int*)pCurrData = LegacyPoint;
		pCurrData += 4;
		*(int*)pCurrData = LegacyPointBonusFactor;
		pCurrData += 4;
		if (LegacyPointDict != null)
		{
			*(int*)pCurrData = LegacyPointDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair in LegacyPointDict)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (LegacyPointTimesDict != null)
		{
			*(int*)pCurrData = LegacyPointTimesDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, short> pair2 in LegacyPointTimesDict)
			{
				*(short*)pCurrData = pair2.Key;
				pCurrData += 2;
				*(short*)pCurrData = pair2.Value;
				pCurrData += 2;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (AvailableLegacyList != null)
		{
			int elementsCount = AvailableLegacyList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = AvailableLegacyList[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += WorldCreationInfo.Serialize(pCurrData);
		if (ChallengeModeData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = ChallengeModeData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = SectJieqingExtraLegacyPoints;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			OldTaiwuChar = new CharacterDisplayData();
			pCurrData += OldTaiwuChar.Deserialize(pCurrData);
		}
		else
		{
			OldTaiwuChar = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			InheritChar = new CharacterDisplayData();
			pCurrData += InheritChar.Deserialize(pCurrData);
		}
		else
		{
			InheritChar = null;
		}
		TaiwuGenerationsCount = *(int*)pCurrData;
		pCurrData += 4;
		LegacyPoint = *(int*)pCurrData;
		pCurrData += 4;
		LegacyPointBonusFactor = *(int*)pCurrData;
		pCurrData += 4;
		int LegacyPointDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (LegacyPointDictElementsCount > 0)
		{
			if (LegacyPointDict == null)
			{
				LegacyPointDict = new Dictionary<short, int>();
			}
			else
			{
				LegacyPointDict.Clear();
			}
			for (int i = 0; i < LegacyPointDictElementsCount; i++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				LegacyPointDict.Add(key, value);
			}
		}
		else
		{
			LegacyPointDict?.Clear();
		}
		int LegacyPointTimesDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (LegacyPointTimesDictElementsCount > 0)
		{
			if (LegacyPointTimesDict == null)
			{
				LegacyPointTimesDict = new Dictionary<short, short>();
			}
			else
			{
				LegacyPointTimesDict.Clear();
			}
			for (int j = 0; j < LegacyPointTimesDictElementsCount; j++)
			{
				short key2 = *(short*)pCurrData;
				pCurrData += 2;
				short value2 = *(short*)pCurrData;
				pCurrData += 2;
				LegacyPointTimesDict.Add(key2, value2);
			}
		}
		else
		{
			LegacyPointTimesDict?.Clear();
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (AvailableLegacyList == null)
			{
				AvailableLegacyList = new List<short>();
			}
			else
			{
				AvailableLegacyList.Clear();
			}
			for (int k = 0; k < elementsCount; k++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				AvailableLegacyList.Add(element);
			}
		}
		else
		{
			AvailableLegacyList?.Clear();
		}
		pCurrData += WorldCreationInfo.Deserialize(pCurrData);
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			ChallengeModeData = new ChallengeModeData();
			pCurrData += ChallengeModeData.Deserialize(pCurrData);
		}
		else
		{
			ChallengeModeData = null;
		}
		SectJieqingExtraLegacyPoints = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
