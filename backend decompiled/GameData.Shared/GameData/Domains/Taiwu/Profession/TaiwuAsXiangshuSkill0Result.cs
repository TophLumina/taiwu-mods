using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

[SerializableGameData(NoCopyConstructors = true)]
public class TaiwuAsXiangshuSkill0Result : ISerializableGameData
{
	[SerializableGameDataField]
	public List<TaiwuAsXiangshuSkill0ResultItem> ResultList = new List<TaiwuAsXiangshuSkill0ResultItem>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (ResultList != null)
		{
			totalSize += 2;
			int elementsCount = ResultList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				TaiwuAsXiangshuSkill0ResultItem element = ResultList[i];
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
		if (ResultList != null)
		{
			int elementsCount = ResultList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				TaiwuAsXiangshuSkill0ResultItem element = ResultList[i];
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ResultList == null)
			{
				ResultList = new List<TaiwuAsXiangshuSkill0ResultItem>(elementsCount);
			}
			else
			{
				ResultList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					TaiwuAsXiangshuSkill0ResultItem element = new TaiwuAsXiangshuSkill0ResultItem();
					pCurrData += element.Deserialize(pCurrData);
					ResultList.Add(element);
				}
				else
				{
					ResultList.Add(null);
				}
			}
		}
		else
		{
			ResultList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
