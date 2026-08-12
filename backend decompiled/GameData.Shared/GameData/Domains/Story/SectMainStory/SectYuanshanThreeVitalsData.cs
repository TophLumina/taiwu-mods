using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Extra;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Story.SectMainStory;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class SectYuanshanThreeVitalsData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool IsGoodEnd;

	[SerializableGameDataField]
	public List<SectStoryThreeVitalsCharacter> ThreeVitals;

	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayData> CharacterDisplayData;

	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayDataForInfect> PotentialTargetData;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 1;
		if (ThreeVitals != null)
		{
			totalSize += 2;
			int elementsCount = ThreeVitals.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				SectStoryThreeVitalsCharacter element = ThreeVitals[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterDisplayData);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(PotentialTargetData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IsGoodEnd ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ThreeVitals != null)
		{
			int elementsCount = ThreeVitals.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				SectStoryThreeVitalsCharacter element = ThreeVitals[i];
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CharacterDisplayData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref PotentialTargetData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		IsGoodEnd = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ThreeVitals == null)
			{
				ThreeVitals = new List<SectStoryThreeVitalsCharacter>(elementsCount);
			}
			else
			{
				ThreeVitals.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					SectStoryThreeVitalsCharacter element = new SectStoryThreeVitalsCharacter();
					pCurrData += element.Deserialize(pCurrData);
					ThreeVitals.Add(element);
				}
				else
				{
					ThreeVitals.Add(null);
				}
			}
		}
		else
		{
			ThreeVitals?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CharacterDisplayData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref PotentialTargetData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
