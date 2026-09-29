using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Map;

[Obsolete]
public class AnimalPlaceData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<short, short> BlockAnimalCharacterTemplateIds;

	public AnimalPlaceData()
	{
		BlockAnimalCharacterTemplateIds = new Dictionary<short, short>();
	}

	public AnimalPlaceData(AnimalPlaceData other)
	{
		BlockAnimalCharacterTemplateIds = new Dictionary<short, short>(other.BlockAnimalCharacterTemplateIds);
	}

	public void Assign(AnimalPlaceData other)
	{
		BlockAnimalCharacterTemplateIds = new Dictionary<short, short>(other.BlockAnimalCharacterTemplateIds);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((BlockAnimalCharacterTemplateIds == null) ? (totalSize + 4) : (totalSize + (4 + 4 * BlockAnimalCharacterTemplateIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (BlockAnimalCharacterTemplateIds != null)
		{
			int elementsCount = BlockAnimalCharacterTemplateIds.Count;
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			foreach (KeyValuePair<short, short> pair in BlockAnimalCharacterTemplateIds)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(short*)pCurrData = pair.Value;
				pCurrData += 2;
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
		uint elementsCount = *(uint*)pCurrData;
		pCurrData += 4;
		if (elementsCount != 0)
		{
			if (BlockAnimalCharacterTemplateIds == null)
			{
				BlockAnimalCharacterTemplateIds = new Dictionary<short, short>();
			}
			else
			{
				BlockAnimalCharacterTemplateIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short id = *(short*)pCurrData;
				pCurrData += 2;
				short time = *(short*)pCurrData;
				pCurrData += 2;
				BlockAnimalCharacterTemplateIds.Add(id, time);
			}
		}
		else
		{
			BlockAnimalCharacterTemplateIds?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
