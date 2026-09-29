using System;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Extra;

public struct SectStoryFairyland : ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public bool Visited;

	[SerializableGameDataField]
	public bool Destroyed;

	[SerializableGameDataField]
	[Obsolete]
	public short MapAreaTemplateId;

	[SerializableGameDataField]
	[Obsolete]
	public sbyte MapAreaIndex;

	public SectStoryFairyland()
	{
		Visited = false;
		Destroyed = true;
		Location = Location.Invalid;
		MapAreaTemplateId = -1;
		MapAreaIndex = -1;
	}

	public SectStoryFairyland(Location location)
	{
		Visited = false;
		Destroyed = false;
		Location = location;
		MapAreaTemplateId = -1;
		MapAreaIndex = -1;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (Visited ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (Destroyed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = MapAreaTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)MapAreaIndex;
		pCurrData++;
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
		pCurrData += Location.Deserialize(pCurrData);
		Visited = *pCurrData != 0;
		pCurrData++;
		Destroyed = *pCurrData != 0;
		pCurrData++;
		MapAreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		MapAreaIndex = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
