using System.Collections.Generic;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.FiveLoong;

public class JiaoPoolRecordArgumentCollection : ISerializableGameData
{
	[SerializableGameDataField]
	public List<int> JiaoIdList;

	[SerializableGameDataField]
	public List<string> JiaoNameList;

	public Dictionary<int, string> JiaoNameMap;

	public void InitMap()
	{
		if (JiaoNameMap == null)
		{
			JiaoNameMap = new Dictionary<int, string>();
		}
		JiaoNameMap.Clear();
		int i = 0;
		for (int max = JiaoIdList.Count; i < max; i++)
		{
			JiaoNameMap.Add(JiaoIdList[i], JiaoNameList[i]);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((JiaoIdList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * JiaoIdList.Count)));
		if (JiaoNameList != null)
		{
			totalSize += 2;
			int elementsCount = JiaoNameList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = JiaoNameList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element.Length)));
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
		if (JiaoIdList != null)
		{
			int elementsCount = JiaoIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = JiaoIdList[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (JiaoNameList != null)
		{
			int elementsCount2 = JiaoNameList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				string element = JiaoNameList[j];
				if (element != null)
				{
					int subElementsCount = element.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar = element)
					{
						for (int k = 0; k < subElementsCount; k++)
						{
							((short*)pCurrData)[k] = (short)pChar[k];
						}
					}
					pCurrData += 2 * subElementsCount;
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
			if (JiaoIdList == null)
			{
				JiaoIdList = new List<int>(elementsCount);
			}
			else
			{
				JiaoIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				JiaoIdList.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			JiaoIdList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (JiaoNameList == null)
			{
				JiaoNameList = new List<string>(elementsCount2);
			}
			else
			{
				JiaoNameList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					JiaoNameList.Add(Encoding.Unicode.GetString(pCurrData, subDataSize));
					pCurrData += subDataSize;
				}
				else
				{
					JiaoNameList.Add(null);
				}
			}
		}
		else
		{
			JiaoNameList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
