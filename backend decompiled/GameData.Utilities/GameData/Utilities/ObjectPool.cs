namespace GameData.Utilities;

public class ObjectPool<T> where T : class, new()
{
	public static ObjectPool<T> Instance;

	protected readonly T[] Objects;

	private int _objectCount;

	public ObjectPool(int initialObjectsCount, int maxObjectsCount)
	{
		Tester.Assert(initialObjectsCount >= 0 && initialObjectsCount <= maxObjectsCount);
		Objects = new T[maxObjectsCount];
		for (int i = 0; i < initialObjectsCount; i++)
		{
			Objects[i] = new T();
		}
		_objectCount = initialObjectsCount;
	}

	public T Get()
	{
		lock (Objects)
		{
			if (_objectCount == 0)
			{
				return new T();
			}
			_objectCount--;
			T result = Objects[_objectCount];
			Objects[_objectCount] = null;
			return result;
		}
	}

	public virtual void Return(T item)
	{
		Tester.Assert(item != null);
		lock (Objects)
		{
			if (_objectCount < Objects.Length)
			{
				Objects[_objectCount++] = item;
			}
		}
	}
}
