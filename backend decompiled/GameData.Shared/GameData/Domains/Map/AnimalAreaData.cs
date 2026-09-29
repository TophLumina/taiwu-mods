using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Map;

public class AnimalAreaData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<short, List<short>> BlockAnimalCharacterTemplateIdList = new Dictionary<short, List<short>>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int offset = 0;
		if (BlockAnimalCharacterTemplateIdList != null)
		{
			offset += 4;
			foreach (KeyValuePair<short, List<short>> pair in BlockAnimalCharacterTemplateIdList)
			{
				offset += 2;
				List<short> list = pair.Value;
				if (list != null)
				{
					offset += 4;
					foreach (short item in list)
					{
						_ = item;
						offset += 2;
					}
				}
				else
				{
					offset += 4;
				}
			}
		}
		else
		{
			offset += 4;
		}
		int totalSize = offset;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (BlockAnimalCharacterTemplateIdList != null)
		{
			int elementsCount = BlockAnimalCharacterTemplateIdList.Count;
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			foreach (KeyValuePair<short, List<short>> pair in BlockAnimalCharacterTemplateIdList)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				List<short> list = pair.Value;
				if (list != null)
				{
					*(int*)pCurrData = list.Count;
					pCurrData += 4;
					foreach (short templateId in list)
					{
						*(short*)pCurrData = templateId;
						pCurrData += 2;
					}
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
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
			if (BlockAnimalCharacterTemplateIdList == null)
			{
				BlockAnimalCharacterTemplateIdList = new Dictionary<short, List<short>>();
			}
			else
			{
				BlockAnimalCharacterTemplateIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short blockId = *(short*)pCurrData;
				pCurrData += 2;
				int count = *(int*)pCurrData;
				pCurrData += 4;
				if (count != 0)
				{
					List<short> list = new List<short>();
					for (int j = 0; j < count; j++)
					{
						short templateId = *(short*)pCurrData;
						pCurrData += 2;
						list.Add(templateId);
					}
					BlockAnimalCharacterTemplateIdList.Add(blockId, list);
				}
			}
		}
		else
		{
			BlockAnimalCharacterTemplateIdList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
