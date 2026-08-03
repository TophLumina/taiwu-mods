using System;
using System.Collections.Generic;

namespace GameData.Utilities;

public class BinaryHeap<T>
{
	private T[] _array;

	private int _count;

	public Comparison<T> Comparison;

	public int Count => _count;

	public BinaryHeap(Comparison<T> comparison, int initialCapacity = 4)
	{
		_array = new T[initialCapacity];
		Comparison = comparison;
	}

	public BinaryHeap(Comparison<T> comparison, IList<T> initialArr)
	{
		Comparison = comparison;
		_array = new T[initialArr.Count];
		initialArr.CopyTo(_array, 0);
		_count = initialArr.Count;
		Sort();
	}

	public void Push(T element)
	{
		int index = Count;
		EnsureCapacity(index + 1);
		_array[index] = element;
		_count++;
		index = BubbleUp();
		BubbleDown(index);
	}

	public T Pop()
	{
		T result = _array[0];
		int index = Count - 1;
		_count--;
		_array[0] = _array[index];
		_array[index] = default(T);
		BubbleDown(0);
		return result;
	}

	public void Remove(T element)
	{
		for (int i = 0; i < Count; i++)
		{
			if (Comparison(_array[i], element) == 0)
			{
				_array[i] = _array[Count - 1];
				_count--;
				_array[Count - 1] = default(T);
				BubbleDown(i);
				break;
			}
		}
	}

	public T Peek()
	{
		return _array[0];
	}

	public void Clear()
	{
		_count = 0;
	}

	private int BubbleUp()
	{
		int index = Count - 1;
		while (index > 0)
		{
			int parent = (index - 1) / 2;
			if (Comparison(_array[index], _array[parent]) <= 0)
			{
				return index;
			}
			T[] array = _array;
			int num = index;
			T[] array2 = _array;
			int num2 = parent;
			T val = _array[parent];
			T val2 = _array[index];
			array[num] = val;
			array2[num2] = val2;
			index = parent;
		}
		return index;
	}

	private void BubbleDown(int index)
	{
		int count = Count;
		while (true)
		{
			int childLeft = index * 2 + 1;
			int childRight = childLeft + 1;
			if (childLeft >= count)
			{
				break;
			}
			int maxChild = ((childRight >= count) ? childLeft : ((Comparison(_array[childLeft], _array[childRight]) <= 0) ? childRight : childLeft));
			if (Comparison(_array[index], _array[maxChild]) >= 0)
			{
				break;
			}
			T[] array = _array;
			int num = index;
			T[] array2 = _array;
			int num2 = maxChild;
			T val = _array[maxChild];
			T val2 = _array[index];
			array[num] = val;
			array2[num2] = val2;
			index = maxChild;
		}
	}

	private void Sort()
	{
		for (int i = Count / 2; i >= 0; i--)
		{
			BubbleDown(i);
		}
	}

	private void EnsureCapacity(int capacity)
	{
		if (capacity > _array.Length)
		{
			int newCapacity = _array.Length * 3 / 2 + 1;
			if (newCapacity < capacity)
			{
				newCapacity = capacity;
			}
			T[] newArr = new T[newCapacity];
			Array.Copy(_array, newArr, Count);
			_array = newArr;
		}
	}
}
