using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 法号
/// </summary>
public struct MonasticTitle(short seniorityId, short suffixId) : ISerializableGameData, IEquatable<MonasticTitle>
{
	/// <summary>
	/// 辈字 ID.
	/// 小于 0 表示无效 ID.
	/// 不同门派的辈字组不同.
	/// </summary>
	public short SeniorityId = seniorityId;

	/// <summary>
	/// 尾字 ID.
	/// 小于 0 表示无效 ID.
	/// 不同门派的尾字组不同.
	/// </summary>
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
