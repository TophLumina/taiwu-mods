using System;

namespace GameData.Utilities;

public struct BoolArray64
{
	public const int Length = 64;

	private ulong _originalData;

	public bool this[int index]
	{
		get
		{
			if (index < 0 || index >= 64)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {64}");
			}
			return BitOperation.GetBit(_originalData, index);
		}
		set
		{
			if (index < 0 || index >= 64)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {64}");
			}
			_originalData = BitOperation.SetBit(_originalData, index, value);
		}
	}

	public static implicit operator ulong(BoolArray64 array)
	{
		return array._originalData;
	}

	public static implicit operator BoolArray64(ulong data)
	{
		return new BoolArray64
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

	public bool Any()
	{
		return _originalData != 0;
	}

	public void Reset()
	{
		_originalData = 0uL;
	}
}
