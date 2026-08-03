using System;
using GameData.Adventure;
using GameData.Serializer;

namespace GameData.Domains.Adventure;

/// <summary>
/// 用于序列化的奇遇格索引
/// </summary>
[SerializableGameData(IsExtensible = true)]
public struct AdventureBlockIndexForSerialize : ISerializableGameData, IEquatable<AdventureBlockIndexForSerialize>
{
	private static class FieldIds
	{
		public const ushort Gx = 0;

		public const ushort Gy = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Gx", "Gy" };
	}

	[SerializableGameDataField]
	private int _gx;

	[SerializableGameDataField]
	private int _gy;

	public static implicit operator AdventureBlockIndex(AdventureBlockIndexForSerialize index)
	{
		return new AdventureBlockIndex(index._gx, index._gy);
	}

	public static implicit operator AdventureBlockIndexForSerialize(AdventureBlockIndex index)
	{
		return new AdventureBlockIndexForSerialize
		{
			_gx = index.Gx,
			_gy = index.Gy
		};
	}

	public override string ToString()
	{
		return "(" + _gx + "," + _gy + ")";
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*(int*)num = _gx;
		byte* num2 = num + 4;
		*(int*)num2 = _gy;
		int totalSize = (int)(num2 + 4 - pData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			_gx = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			_gy = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool Equals(AdventureBlockIndexForSerialize other)
	{
		if (_gx == other._gx)
		{
			return _gy == other._gy;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is AdventureBlockIndexForSerialize other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (_gx * 397) ^ _gy;
	}

	public static bool operator ==(AdventureBlockIndexForSerialize left, AdventureBlockIndexForSerialize right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(AdventureBlockIndexForSerialize left, AdventureBlockIndexForSerialize right)
	{
		return !left.Equals(right);
	}
}
