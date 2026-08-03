using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Redzen.Random;

namespace GameData.Utilities;

public ref struct SpanList<T> where T : unmanaged
{
	public ref struct Enumerator
	{
		private readonly SpanList<T> _span;

		private int _index;

		public ref T Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return ref _span[_index];
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal Enumerator(SpanList<T> span)
		{
			_span = span;
			_index = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			int num = _index + 1;
			if (num >= _span._count)
			{
				return false;
			}
			_index = num;
			return true;
		}
	}

	private unsafe readonly T* _pointer;

	private readonly int _capacity;

	private int _count;

	public int Capacity => _capacity;

	public int Count => _count;

	public unsafe ref T this[int index]
	{
		get
		{
			if (index >= _count || index < 0)
			{
				throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_count})");
			}
			return ref _pointer[index];
		}
	}

	public unsafe SpanList(T* pointer, int capacity)
	{
		_pointer = pointer;
		_capacity = capacity;
		_count = 0;
	}

	public unsafe SpanList(T[] arr, int offset, int capacity)
	{
		fixed (T* pArr = arr)
		{
			_pointer = pArr + offset;
			_capacity = capacity;
			_count = 0;
		}
	}

	public void Push(T value)
	{
		Add(value);
	}

	public unsafe T Pop()
	{
		if (_count <= 0)
		{
			throw new InvalidOperationException("Invalid pop on empty stack.");
		}
		_count--;
		return _pointer[_count];
	}

	public unsafe void Add(T value)
	{
		if (_count >= _capacity)
		{
			throw new Exception($"SpanList with capacity {_capacity} is already full.");
		}
		_pointer[_count] = value;
		_count++;
	}

	public unsafe void Insert(int index, T value)
	{
		if (_count >= _capacity)
		{
			throw new Exception($"SpanList with capacity {_capacity} is already full.");
		}
		if (_count <= index)
		{
			throw new Exception($"Cannot insert at index {index} when range is [0, {_count})");
		}
		int size = (_count - index) * sizeof(T);
		T* num = _pointer + index;
		T* dstAddr = num + 1;
		Buffer.MemoryCopy(num, dstAddr, size, size);
		*num = value;
		_count++;
	}

	public void AddRange(IEnumerable<T> values)
	{
		foreach (T value in values)
		{
			Add(value);
		}
	}

	public unsafe void AddRangeSafe(IEnumerable<T> values)
	{
		foreach (T value in values)
		{
			if (_count >= _capacity)
			{
				break;
			}
			_pointer[_count] = value;
			_count++;
		}
	}

	public unsafe void RemoveAt(int index)
	{
		if (index < 0 || index >= _count)
		{
			throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_count})");
		}
		for (int i = index + 1; i < _count; i++)
		{
			_pointer[i - 1] = _pointer[i];
		}
		_count--;
	}

	public unsafe void SwapRemove(int index)
	{
		if (index < 0 || index > _count)
		{
			throw new IndexOutOfRangeException($"Index {index} is out of range [0, {_count})");
		}
		_pointer[index] = _pointer[_count - 1];
		_count--;
	}

	public unsafe void RemoveRange(int startIndex, int count)
	{
		if (startIndex < 0 || startIndex >= _count)
		{
			throw new IndexOutOfRangeException($"Index {startIndex} is out of range[0, {_count}]");
		}
		int endIndex = startIndex + count;
		if (endIndex >= _count)
		{
			_count = startIndex;
			return;
		}
		int i = endIndex;
		int j = startIndex;
		while (i < _count)
		{
			_pointer[j] = _pointer[i];
			i++;
			j++;
		}
		_count -= count;
	}

	public unsafe void AppendAllToList(List<T> targetList)
	{
		for (int i = 0; i < _count; i++)
		{
			T item = _pointer[i];
			targetList.Add(item);
		}
	}

	public unsafe bool Exists(T element, Predicate<T> predicate)
	{
		for (int i = 0; i < _count; i++)
		{
			T item = _pointer[i];
			if (predicate(item))
			{
				return true;
			}
		}
		return false;
	}

	public unsafe T Find(Predicate<T> predicate)
	{
		for (int i = 0; i < _count; i++)
		{
			T item = _pointer[i];
			if (predicate(item))
			{
				return item;
			}
		}
		return default(T);
	}

	public unsafe int IndexOf(Predicate<T> predicate)
	{
		for (int i = 0; i < _count; i++)
		{
			T item = _pointer[i];
			if (predicate(item))
			{
				return i;
			}
		}
		return -1;
	}

	public void Clear()
	{
		_count = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void Shuffle(IRandomSource randomSource)
	{
		CollectionUtils.Shuffle(randomSource, _pointer, _count);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe T GetRandom(IRandomSource randomSource)
	{
		return _pointer[randomSource.Next(_count)];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe T[] ToArray()
	{
		if (_count == 0)
		{
			return Array.Empty<T>();
		}
		T[] array = new T[_count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _pointer[i];
		}
		return array;
	}

	public static implicit operator SpanList<T>(ArraySegment<T> segment)
	{
		return new SpanList<T>(segment.Array, segment.Offset, segment.Count);
	}

	public unsafe static implicit operator Span<T>(SpanList<T> spanList)
	{
		return new Span<T>(spanList._pointer, spanList._count);
	}

	public unsafe static implicit operator SpanList<T>(Span<T> span)
	{
		return new SpanList<T>((T*)Unsafe.AsPointer(ref span.GetPinnableReference()), span.Length);
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}
}
