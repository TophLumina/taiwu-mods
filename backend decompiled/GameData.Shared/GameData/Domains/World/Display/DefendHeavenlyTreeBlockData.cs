using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.World.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class DefendHeavenlyTreeBlockData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<MapBlockData> BlockList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (BlockList != null)
		{
			totalSize += 2;
			for (int i = 0; i < BlockList.Count; i++)
			{
				totalSize = ((BlockList[i] == null) ? (totalSize + 2) : (totalSize + (2 + BlockList[i].GetSerializedSize())));
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
		if (BlockList != null)
		{
			int elementsCount = BlockList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (BlockList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = BlockList[i].Serialize(pCurrData);
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
			if (BlockList == null)
			{
				BlockList = new List<MapBlockData>();
			}
			else
			{
				BlockList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				MapBlockData element;
				if (num > 0)
				{
					element = new MapBlockData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				BlockList.Add(element);
			}
		}
		else
		{
			BlockList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
