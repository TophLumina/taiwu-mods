using System;
using GameData.Serializer;

namespace GameData.Domains.Map;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public struct HunterAnimalKeyBroken(short areaId, short blockId, short animalId) : ISerializableGameData, IEquatable<HunterAnimalKeyBroken>
{
	public short AreaId = areaId;

	public short BlockId = blockId;

	public short AnimalId = animalId;

	public bool Equals(HunterAnimalKeyBroken other)
	{
		return AreaId == other.AreaId && BlockId == other.BlockId && AnimalId == other.AnimalId;
	}

	public override bool Equals(object obj)
	{
		return obj is HunterAnimalKeyBroken other && Equals(other);
	}

	public override int GetHashCode()
	{
		int hashCode = AreaId.GetHashCode();
		hashCode = (hashCode * 397) ^ BlockId.GetHashCode();
		return (hashCode * 397) ^ AnimalId.GetHashCode();
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
