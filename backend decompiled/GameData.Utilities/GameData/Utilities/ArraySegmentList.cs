using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Redzen.Random;

namespace GameData.Utilities;

public struct ArraySegmentList<T> where T : unmanaged
{
	public struct Enumerator
	{
		private readonly ArraySegmentList<T> _arraySegment;

		private int _index;

		public ref T Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref _arraySegment[_index];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal Enumerator(ArraySegmentList<T> arraySegment)
		{
			_arraySegment = arraySegment;
			_index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			int num = _index + 1;
			if (num >= _arraySegment._count)
			{
				return false;
			}
			_index = num;
			return true;
		}
	}

	private readonly T[] _array;

	private readonly int _beginOffset;

	private readonly int _capacity;

	private int _count;

	private readonly T? _default;

	public int Capacity => _capacity;

	public int Count => _count;

	public ref T this[int index]
	{
		get
		{
			if (index >= _count || index < 0)
			{
				throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_count})");
			}
			return ref _array[index + _beginOffset];
		}
	}

	public ArraySegmentList(T[] arr, int offset, int capacity, T? defaultValue = null)
	{
		_array = arr;
		_beginOffset = offset;
		_capacity = capacity;
		_count = 0;
		_default = defaultValue;
	}

	public ArraySegmentList(T[] arr, int offset, int capacity, int count, T? defaultValue = null)
	{
		_array = arr;
		_beginOffset = offset;
		_capacity = capacity;
		_count = count;
		_default = defaultValue;
	}

	public void Push(T value)
	{
		Add(value);
	}

	public T Pop()
	{
		if (_count <= 0)
		{
			throw new InvalidOperationException("Invalid pop on empty stack.");
		}
		_count--;
		return _array[_beginOffset + _count];
	}

	public void Add(T value)
	{
		if (_count >= _capacity)
		{
			throw new Exception($"ArraySegmentList with capacity {_capacity} is already full.");
		}
		_array[_beginOffset + _count] = value;
		_count++;
	}

	public void Insert(int index, T value)
	{
		if (_count >= _capacity)
		{
			throw new Exception($"ArraySegmentList with capacity {_capacity} is already full.");
		}
		if (_count <= index)
		{
			throw new Exception($"Cannot insert at index {index} when range is [0, {_count})");
		}
		int size = _count - index;
		int offset = _beginOffset + index;
		Array.Copy(_array, offset, _array, offset + 1, size);
		_array[offset] = value;
		_count++;
	}

	public void AddRange(IEnumerable<T> values)
	{
		foreach (T value in values)
		{
			Add(value);
		}
	}

	public void AddRangeSafe(IEnumerable<T> values)
	{
		foreach (T value in values)
		{
			if (_count >= _capacity)
			{
				break;
			}
			_array[_beginOffset + _count] = value;
			_count++;
		}
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= _count)
		{
			throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_count})");
		}
		int srcOffset = _beginOffset + index + 1;
		int dstOffset = _beginOffset + index;
		int count = _count - index - 1;
		Array.Copy(_array, srcOffset, _array, dstOffset, count);
		_count--;
		if (_default.HasValue)
		{
			_array[_beginOffset + _count] = _default.Value;
		}
	}

	public void SwapRemove(int index)
	{
		if (index < 0 || index > _count)
		{
			throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_count})");
		}
		_array[_beginOffset + index] = _array[_beginOffset + _count - 1];
		_count--;
		if (_default.HasValue)
		{
			_array[_beginOffset + _count] = _default.Value;
		}
	}

	public void RemoveRange(int startIndex, int count)
	{
		if (startIndex < 0 || startIndex >= _count)
		{
			throw new IndexOutOfRangeException($"Index {startIndex} is out of range[0, {_count}]");
		}
		int endIndex = startIndex + count;
		if (endIndex >= _count)
		{
			if (_default.HasValue)
			{
				Array.Fill(_array, _default.Value, _beginOffset + startIndex, _count - startIndex);
			}
			_count = startIndex;
			return;
		}
		int srcOffset = _beginOffset + endIndex;
		int dstOffset = _beginOffset + startIndex;
		int copyCount = _count - endIndex;
		Array.Copy(_array, srcOffset, _array, dstOffset, copyCount);
		_count -= count;
		if (_default.HasValue)
		{
			Array.Fill(_array, _default.Value, _beginOffset + _count, count);
		}
	}

	public bool Exists(Predicate<T> predicate)
	{
		for (int i = 0; i < _count; i++)
		{
			T item = _array[_beginOffset + i];
			if (predicate(item))
			{
				return true;
			}
		}
		return false;
	}

	public T Find(Predicate<T> predicate)
	{
		for (int i = 0; i < _count; i++)
		{
			T item = _array[_beginOffset + i];
			if (predicate(item))
			{
				return item;
			}
		}
		return default(T);
	}

	public int IndexOf(Predicate<T> predicate)
	{
		for (int i = 0; i < _count; i++)
		{
			T item = _array[_beginOffset + i];
			if (predicate(item))
			{
				return i;
			}
		}
		return -1;
	}

	public void Clear()
	{
		if (_default.HasValue)
		{
			Array.Fill(_array, _default.Value, _beginOffset, _count);
		}
		_count = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Shuffle(IRandomSource randomSource)
	{
		CollectionUtils.Shuffle(randomSource, _array, _count);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T GetRandom(IRandomSource randomSource)
	{
		return _array[_beginOffset + randomSource.Next(_count)];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T[] ToArray()
	{
		if (_count == 0)
		{
			return Array.Empty<T>();
		}
		T[] array = new T[_count];
		Array.Copy(_array, _beginOffset, array, 0, _count);
		return array;
	}

	public static implicit operator ArraySegmentList<T>(ArraySegment<T> segment)
	{
		return new ArraySegmentList<T>(segment.Array, segment.Offset, segment.Count);
	}

	public static implicit operator ArraySegment<T>(ArraySegmentList<T> arraySegmentList)
	{
		return new ArraySegment<T>(arraySegmentList._array, arraySegmentList._beginOffset, arraySegmentList._count);
	}

	public static implicit operator ArraySegmentList<T>(T[] array)
	{
		return new ArraySegmentList<T>(array, 0, array.Length);
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}
}
