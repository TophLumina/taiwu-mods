using System;
using GameData.Serializer;

namespace GameData.Domains.Map;

public struct HunterAnimalKey(short areaId, short blockId, short animalId) : ISerializableGameData, IEquatable<HunterAnimalKey>
{
	public short AreaId = areaId;

	public short BlockId = blockId;

	public short AnimalId = animalId;

	public bool Equals(HunterAnimalKey other)
	{
		if (AreaId == other.AreaId && BlockId == other.BlockId)
		{
			return AnimalId == other.AnimalId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is HunterAnimalKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((AreaId.GetHashCode() * 397) ^ BlockId.GetHashCode()) * 397) ^ AnimalId.GetHashCode();
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = AreaId;
		byte* num = pData + 2;
		*(short*)num = BlockId;
		byte* num2 = num + 2;
		*(short*)num2 = AnimalId;
		int totalSize = (int)(num2 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		BlockId = *(short*)pCurrData;
		pCurrData += 2;
		AnimalId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
