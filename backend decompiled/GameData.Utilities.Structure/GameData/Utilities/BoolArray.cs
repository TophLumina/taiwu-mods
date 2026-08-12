using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData]
public class BoolArray : ISerializableGameData
{
	public struct Enumerator
	{
		private readonly BoolArray _boolArray;

		private int _index;

		public bool Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _boolArray[_index];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal Enumerator(BoolArray boolArray)
		{
			_boolArray = boolArray;
			_index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			int num = _index + 1;
			if (num >= _boolArray.Length)
			{
				return false;
			}
			_index = num;
			return true;
		}
	}

	[SerializableGameDataField]
	private uint[] _internalArray;

	[SerializableGameDataField]
	private int _length;

	private const int SegmentLength = 32;

	private const int MaxLength = 2097120;

	public int Length => _length;

	public bool this[int index]
	{
		get
		{
			if (index < 0 || index >= _length)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {Length}");
			}
			int internalSubIndex;
			int internalIndex = Math.DivRem(index, 32, out internalSubIndex);
			return BitOperation.GetBit(_internalArray[internalIndex], internalSubIndex);
		}
		set
		{
			if (index < 0 || index >= Length)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {Length}");
			}
			int internalSubIndex;
			int internalIndex = Math.DivRem(index, 32, out internalSubIndex);
			_internalArray[internalIndex] = BitOperation.SetBit(_internalArray[internalIndex], internalSubIndex, value);
		}
	}

	public int Count => Length;

	public bool IsReadOnly => false;

	public BoolArray(int length)
	{
		if (length > 2097120)
		{
			throw new Exception($"length {length} exceeds max length {2097120}.");
		}
		_length = length;
		_internalArray = new uint[(length + 31) / 32 * 32];
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	public void SetAll(bool isOn)
	{
		uint value = (isOn ? uint.MaxValue : 0u);
		for (int i = 0; i < _internalArray.Length; i++)
		{
			_internalArray[i] = value;
		}
	}

	public BoolArray()
	{
	}

	public BoolArray(BoolArray other)
	{
		uint[] item = other._internalArray;
		int elementsCount = item.Length;
		_internalArray = new uint[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_internalArray[i] = item[i];
		}
		_length = other._length;
	}

	public void Assign(BoolArray other)
	{
		uint[] item = other._internalArray;
		int elementsCount = item.Length;
		_internalArray = new uint[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_internalArray[i] = item[i];
		}
		_length = other._length;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((_internalArray == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _internalArray.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_internalArray != null)
		{
			int elementsCount = _internalArray.Length;
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = (int)_internalArray[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = _length;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_internalArray == null || _internalArray.Length != elementsCount)
			{
				_internalArray = new uint[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_internalArray[i] = ((uint*)pCurrData)[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_internalArray = null;
		}
		_length = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
