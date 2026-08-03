using System;
using GameData.Serializer;

namespace GameData.Domains.Character.Relation;

/// <summary>
/// 父母和子女
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public struct ParentAndChild : ISerializableGameData, IEquatable<ParentAndChild>
{
	/// <summary>
	/// 父母其中一方的角色 ID
	/// </summary>
	public int ParentId;

	/// <summary>
	/// 子女的角色 ID
	/// </summary>
	public int ChildId;

	/// <summary>
	/// 父母和子女
	/// </summary>
	/// <param name="parentId"></param>
	/// <param name="childId"></param>
	public ParentAndChild(int parentId, int childId)
	{
		ParentId = parentId;
		ChildId = childId;
	}

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
