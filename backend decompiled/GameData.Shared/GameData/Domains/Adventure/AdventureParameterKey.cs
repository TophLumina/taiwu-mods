using System;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇变量键
/// </summary>
[SerializableGameData(IsExtensible = true)]
public struct AdventureParameterKey : ISerializableGameData, IEquatable<AdventureParameterKey>
{
	private static class FieldIds
	{
		public const ushort Type = 0;

		public const ushort InternalInt = 1;

		public const ushort InternalString = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "Type", "InternalInt", "InternalString" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private EAdventureParameterKeyType _type;

	[SerializableGameDataField(FieldIndex = 1)]
	private int _internalInt;

	[SerializableGameDataField(FieldIndex = 2)]
	private string _internalString;

	public static implicit operator AdventureParameterKey(int key)
	{
		return new AdventureParameterKey(key);
	}

	public AdventureParameterKey(int key)
	{
		_type = EAdventureParameterKeyType.Int;
		_internalInt = key;
		_internalString = null;
	}

	public AdventureParameterKey(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			throw new Exception("Key cannot be null or empty.");
		}
		_type = EAdventureParameterKeyType.String;
		_internalInt = 0;
		_internalString = key;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize = ((_internalString == null) ? (totalSize + 2) : (totalSize + (2 + 2 * _internalString.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*pCurrData = (byte)_type;
		pCurrData++;
		*(int*)pCurrData = _internalInt;
		pCurrData += 4;
		if (_internalString != null)
		{
			int elementsCount = _internalString.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = _internalString)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
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
			_type = (EAdventureParameterKeyType)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			_internalInt = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				_internalString = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				_internalString = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool Equals(AdventureParameterKey other)
	{
		if (_type == other._type && _internalInt == other._internalInt)
		{
			return _internalString == other._internalString;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is AdventureParameterKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((((int)_type * 397) ^ _internalInt) * 397) ^ ((_internalString != null) ? _internalString.GetHashCode() : 0);
	}

	public static bool operator ==(AdventureParameterKey left, AdventureParameterKey right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(AdventureParameterKey left, AdventureParameterKey right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		if (_type != EAdventureParameterKeyType.Int)
		{
			return "String:" + _internalString;
		}
		return "Int:" + _internalInt;
	}
}
