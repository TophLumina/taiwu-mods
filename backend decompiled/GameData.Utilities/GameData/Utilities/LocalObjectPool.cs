using System.Collections;
using System.Collections.Generic;

namespace GameData.Utilities;

public class LocalObjectPool<T> where T : class, new()
{
	private readonly Stack<T> _objects;

	private readonly int _maxObjectsCount;

	public LocalObjectPool(int initialObjectsCount, int maxObjectsCount)
	{
		_objects = new Stack<T>();
		_maxObjectsCount = maxObjectsCount;
		for (int i = 0; i < initialObjectsCount; i++)
		{
			_objects.Push(new T());
		}
	}

	public T Get()
	{
		if (_objects.Count <= 0)
		{
			return new T();
		}
		return _objects.Pop();
	}

	public void Return(T item)
	{
		Tester.Assert(item != null);
		if (item is IList list)
		{
			list.Clear();
		}
		if (_objects.Count < _maxObjectsCount)
		{
			_objects.Push(item);
		}
	}
}
