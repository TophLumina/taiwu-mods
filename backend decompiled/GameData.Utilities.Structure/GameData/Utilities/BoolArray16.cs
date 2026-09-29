using System;

namespace GameData.Utilities;

public struct BoolArray16
{
	public const int Length = 16;

	private ushort _originalData;

	public bool this[int index]
	{
		get
		{
			if (index < 0 || index >= 16)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {16}");
			}
			return BitOperation.GetBit(_originalData, index);
		}
		set
		{
			if (index < 0 || index >= 16)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {16}");
			}
			_originalData = BitOperation.SetBit(_originalData, index, value);
		}
	}

	public static implicit operator ushort(BoolArray16 array)
	{
		return array._originalData;
	}

	public static implicit operator BoolArray16(ushort data)
	{
		return new BoolArray16
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

	public BoolArray16 ReadonlySet(int index, bool value)
	{
		BoolArray16 result = this;
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

	public static BoolArray16 operator |(BoolArray16 l, BoolArray16 r)
	{
		return new BoolArray16
		{
			_originalData = (ushort)(l._originalData | r._originalData)
		};
	}
}
