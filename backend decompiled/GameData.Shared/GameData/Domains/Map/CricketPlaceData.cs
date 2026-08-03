using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 一个区域中的促织信息
/// </summary>
public class CricketPlaceData : ISerializableGameData
{
	[SerializableGameDataField]
	public short[] CricketBlocks;

	[SerializableGameDataField]
	public bool[] CricketTriggered;

	[SerializableGameDataField]
	public byte[] RealCircketIdx;

	public CricketPlaceData()
	{
	}

	public CricketPlaceData(CricketPlaceData other)
	{
		short[] item = other.CricketBlocks;
		int elementsCount = item.Length;
		CricketBlocks = new short[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			CricketBlocks[i] = item[i];
		}
		bool[] item2 = other.CricketTriggered;
		int elementsCount2 = item2.Length;
		CricketTriggered = new bool[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			CricketTriggered[j] = item2[j];
		}
		byte[] item3 = other.RealCircketIdx;
		int elementsCount3 = item3.Length;
		RealCircketIdx = new byte[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			RealCircketIdx[k] = item3[k];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((CricketBlocks == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CricketBlocks.Length)));
		totalSize = ((CricketTriggered == null) ? (totalSize + 2) : (totalSize + (2 + CricketTriggered.Length)));
		totalSize = ((RealCircketIdx == null) ? (totalSize + 2) : (totalSize + (2 + RealCircketIdx.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CricketBlocks != null)
		{
			int elementsCount = CricketBlocks.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = CricketBlocks[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CricketTriggered != null)
		{
			int elementsCount2 = CricketTriggered.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (CricketTriggered[j] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RealCircketIdx != null)
		{
			int elementsCount3 = RealCircketIdx.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData[k] = RealCircketIdx[k];
			}
			pCurrData += elementsCount3;
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
			if (CricketBlocks == null || CricketBlocks.Length != elementsCount)
			{
				CricketBlocks = new short[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CricketBlocks[i] = ((short*)pCurrData)[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			CricketBlocks = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CricketTriggered == null || CricketTriggered.Length != elementsCount2)
			{
				CricketTriggered = new bool[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				CricketTriggered[j] = pCurrData[j] != 0;
			}
			pCurrData += (int)elementsCount2;
		}
		else
		{
			CricketTriggered = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (RealCircketIdx == null || RealCircketIdx.Length != elementsCount3)
			{
				RealCircketIdx = new byte[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				RealCircketIdx[k] = pCurrData[k];
			}
			pCurrData += (int)elementsCount3;
		}
		else
		{
			RealCircketIdx = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
