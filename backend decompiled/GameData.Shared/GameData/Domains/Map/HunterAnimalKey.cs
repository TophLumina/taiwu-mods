using System;
using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 猎户召唤的野兽索引
/// </summary>
public struct HunterAnimalKey : ISerializableGameData, IEquatable<HunterAnimalKey>
{
	/// <summary>
	/// 区域ID
	/// </summary>
	public short AreaId;

	/// <summary>
	/// 地块ID
	/// </summary>
	public short BlockId;

	/// <summary>
	/// 野兽ID
	/// </summary>
	public short AnimalId;

	/// <summary>
	/// 默认构造函数
	/// </summary>
	/// <param name="areaId"></param>
	/// <param name="blockId"></param>
	/// <param name="animalId"></param>
	public HunterAnimalKey(short areaId, short blockId, short animalId)
	{
		AreaId = areaId;
		BlockId = blockId;
		AnimalId = animalId;
	}

	/// <inheritdoc />
	public bool Equals(HunterAnimalKey other)
	{
		if (AreaId == other.AreaId && BlockId == other.BlockId)
		{
			return AnimalId == other.AnimalId;
		}
		return false;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is HunterAnimalKey other)
		{
			return Equals(other);
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return (((AreaId.GetHashCode() * 397) ^ BlockId.GetHashCode()) * 397) ^ AnimalId.GetHashCode();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
