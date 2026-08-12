using System;

namespace GameData.Utilities;

public struct BoolArray32
{
	public const int Length = 32;

	private uint _originalData;

	public bool this[int index]
	{
		get
		{
			if (index < 0 || index >= 32)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {32}");
			}
			return BitOperation.GetBit(_originalData, index);
		}
		set
		{
			if (index < 0 || index >= 32)
			{
				throw new IndexOutOfRangeException($"{GetType().Name} not support index {index} that out of {32}");
			}
			_originalData = BitOperation.SetBit(_originalData, index, value);
		}
	}

	public static implicit operator uint(BoolArray32 array)
	{
		return array._originalData;
	}

	public static implicit operator BoolArray32(uint data)
	{
		return new BoolArray32
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
		_originalData = 0u;
	}
}
