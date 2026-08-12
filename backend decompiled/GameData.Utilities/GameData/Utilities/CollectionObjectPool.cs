using System.Collections.Generic;

namespace GameData.Utilities;

public class CollectionObjectPool<T, TValue> : ObjectPool<T> where T : class, ICollection<TValue>, new()
{
	public CollectionObjectPool(int initialCapacity, int maxObjectsCount)
		: base(initialCapacity, maxObjectsCount)
	{
	}

	public override void Return(T item)
	{
		item.Clear();
		base.Return(item);
	}
}
