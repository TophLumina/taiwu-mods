using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 祠堂页面显示数据集合
/// </summary>
public class TaiwuShrineDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int Authority;

	[SerializableGameDataField]
	public List<int> CharIdList;

	public TaiwuShrineDisplayData()
	{
	}

	public TaiwuShrineDisplayData(TaiwuShrineDisplayData other)
	{
		Authority = other.Authority;
		List<int> item = other.CharIdList;
		int elementsCount = item.Count;
		CharIdList = new List<int>(elementsCount);
		for (int i = 0; i < elementsCount; i++)
		{
			CharIdList.Add(item[i]);
		}
	}

	public void Assign(TaiwuShrineDisplayData other)
	{
		Authority = other.Authority;
		List<int> item = other.CharIdList;
		int elementsCount = item.Count;
		CharIdList = new List<int>(elementsCount);
		for (int i = 0; i < elementsCount; i++)
		{
			CharIdList.Add(item[i]);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += 2;
		if (CharIdList != null && CharIdList.Count > 0)
		{
			totalSize += 4 * CharIdList.Count;
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
		*(int*)pCurrData = Authority;
		pCurrData += 4;
		if (CharIdList != null)
		{
			int elementsCount = CharIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = CharIdList[i];
				pCurrData += 4;
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
		Authority = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CharIdList == null)
			{
				CharIdList = new List<int>(elementsCount);
			}
			else
			{
				CharIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int charId = *(int*)pCurrData;
				pCurrData += 4;
				CharIdList.Add(charId);
			}
		}
		else
		{
			CharIdList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
