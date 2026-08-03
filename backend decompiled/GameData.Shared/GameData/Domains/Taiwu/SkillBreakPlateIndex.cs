using System;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 功法突破盘索引
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public struct SkillBreakPlateIndex : ISerializableGameData, IEquatable<SkillBreakPlateIndex>
{
	/// <summary>
	/// 无效索引
	/// </summary>
	public static SkillBreakPlateIndex Invalid => (x: -1, y: -1);

	/// <summary>
	/// 列数
	/// </summary>
	[SerializableGameDataField]
	public int X { get; private set; }

	/// <summary>
	/// 行数
	/// </summary>
	[SerializableGameDataField]
	public int Y { get; private set; }

	public static implicit operator SkillBreakPlateIndex((int x, int y) tup)
	{
		SkillBreakPlateIndex result = default(SkillBreakPlateIndex);
		(result.X, result.Y) = tup;
		return result;
	}

	/// <summary>
	/// 反构造
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	public void Deconstruct(out int x, out int y)
	{
		int x2 = X;
		int y2 = Y;
		x = x2;
		y = y2;
	}

	/// <summary>
	/// 加法
	/// </summary>
	/// <param name="lhs"></param>
	/// <param name="rhs"></param>
	/// <returns></returns>
	public static SkillBreakPlateIndex operator +(SkillBreakPlateIndex lhs, SkillBreakPlateIndex rhs)
	{
		return new SkillBreakPlateIndex
		{
			X = lhs.X + rhs.X,
			Y = lhs.Y + rhs.Y
		};
	}

	/// <summary>
	/// 乘法
	/// </summary>
	/// <param name="value"></param>
	/// <param name="multiplier"></param>
	/// <returns></returns>
	public static SkillBreakPlateIndex operator *(SkillBreakPlateIndex value, int multiplier)
	{
		return new SkillBreakPlateIndex
		{
			X = value.X * multiplier,
			Y = value.Y * multiplier
		};
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return $"Index({X},{Y})";
	}

	/// <inheritdoc />
	public bool Equals(SkillBreakPlateIndex other)
	{
		if (X == other.X)
		{
			return Y == other.Y;
		}
		return false;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is SkillBreakPlateIndex other)
		{
			return Equals(other);
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return (((((X * 397) ^ Y) * 397) ^ X) * 397) ^ Y;
	}

	/// <summary>
	/// 等于
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static bool operator ==(SkillBreakPlateIndex left, SkillBreakPlateIndex right)
	{
		return left.Equals(right);
	}

	/// <summary>
	/// 不等
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static bool operator !=(SkillBreakPlateIndex left, SkillBreakPlateIndex right)
	{
		return !(left == right);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = X;
		byte* num = pData + 4;
		*(int*)num = Y;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		X = *(int*)pCurrData;
		pCurrData += 4;
		Y = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
