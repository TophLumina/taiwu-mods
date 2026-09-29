using System;
using GameData.Serializer;

namespace GameData.Domains.Character.Relation;

public struct RelationKey(int charId, int relatedCharId) : ISerializableGameData, IEquatable<RelationKey>
{
	public int CharId = charId;

	public int RelatedCharId = relatedCharId;

	public static explicit operator ulong(RelationKey value)
	{
		return (ulong)(((long)value.RelatedCharId << 32) + value.CharId);
	}

	public static explicit operator RelationKey(ulong value)
	{
		return new RelationKey((int)value, (int)(value >> 32));
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CharId;
		((int*)pData)[1] = RelatedCharId;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		CharId = *(int*)pData;
		RelatedCharId = ((int*)pData)[1];
		return 8;
	}

	public bool Equals(RelationKey other)
	{
		if (CharId == other.CharId)
		{
			return RelatedCharId == other.RelatedCharId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is RelationKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (CharId * 397) ^ RelatedCharId;
	}

	public override string ToString()
	{
		return $"{CharId}, {RelatedCharId}";
	}
}
