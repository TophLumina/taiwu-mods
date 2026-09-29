using System;
using GameData.Serializer;

namespace GameData.Domains.Character.Relation;

[SerializableGameData(NotForDisplayModule = true)]
public struct ParentAndChild(int parentId, int childId) : ISerializableGameData, IEquatable<ParentAndChild>
{
	public int ParentId = parentId;

	public int ChildId = childId;

	public static explicit operator ulong(ParentAndChild value)
	{
		return (ulong)(((long)value.ChildId << 32) + value.ParentId);
	}

	public static explicit operator ParentAndChild(ulong value)
	{
		return new ParentAndChild((int)value, (int)(value >> 32));
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
		*(int*)pData = ParentId;
		((int*)pData)[1] = ChildId;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		ParentId = *(int*)pData;
		ChildId = ((int*)pData)[1];
		return 8;
	}

	public bool Equals(ParentAndChild other)
	{
		if (ParentId == other.ParentId)
		{
			return ChildId == other.ChildId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ParentAndChild other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (ParentId * 397) ^ ChildId;
	}
}
