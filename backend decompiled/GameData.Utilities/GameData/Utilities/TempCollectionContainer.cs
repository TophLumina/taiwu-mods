using System.Collections.Generic;

namespace GameData.Utilities;

public class TempCollectionContainer<TCollection, TElement> : TempObjectContainerBase<TCollection> where TCollection : class, ICollection<TElement>, new()
{
	public TempCollectionContainer()
		: base(new TCollection())
	{
	}

	public TempCollectionContainer(TCollection collection)
		: base(collection)
	{
	}

	protected override void Reset(TCollection obj)
	{
		Obj.Clear();
	}

	protected override TCollection GetFallbackObject()
	{
		return new TCollection();
	}
}
