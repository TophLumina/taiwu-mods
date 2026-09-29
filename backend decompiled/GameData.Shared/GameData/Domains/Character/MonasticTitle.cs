using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

public struct MonasticTitle(short seniorityId, short suffixId) : ISerializableGameData, IEquatable<MonasticTitle>
{
	public short SeniorityId = seniorityId;

	public short SuffixId = suffixId;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = SeniorityId;
		((short*)pData)[1] = SuffixId;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		SeniorityId = *(short*)pData;
		SuffixId = ((short*)pData)[1];
		return 4;
	}

	public bool Equals(MonasticTitle other)
	{
		if (SeniorityId == other.SeniorityId)
		{
			return SuffixId == other.SuffixId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is MonasticTitle other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (SeniorityId.GetHashCode() * 397) ^ SuffixId.GetHashCode();
	}
}
