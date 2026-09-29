using System;

namespace GameData.Utilities;

public struct BoolArray8
{
	public const int Length = 8;

	private byte _originalData;

	public bool this[int index]
	{
		get
		{
			if (index < 0 || index >= 8)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {8}");
			}
			return BitOperation.GetBit(_originalData, index);
		}
		set
		{
			if (index < 0 || index >= 8)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {8}");
			}
			_originalData = BitOperation.SetBit(_originalData, index, value);
		}
	}

	public static implicit operator byte(BoolArray8 array)
	{
		return array._originalData;
	}

	public static implicit operator BoolArray8(byte data)
	{
		return new BoolArray8
		{
			_originalData = data
		};
	}

	public bool Get(int index)
	{
		return this[index];
	}

	public void Set(int index, bool value)
	{
		this[index] = value;
	}

	public BoolArray8 ReadonlySet(int index, bool value)
	{
		BoolArray8 result = this;
		result.Set(index, value);
		return result;
	}

	public bool Any()
	{
		return _originalData != 0;
	}

	public void Reset()
	{
		_originalData = 0;
	}

	public static BoolArray8 operator |(BoolArray8 l, BoolArray8 r)
	{
		return new BoolArray8
		{
			_originalData = (byte)(l._originalData | r._originalData)
		};
	}
}
