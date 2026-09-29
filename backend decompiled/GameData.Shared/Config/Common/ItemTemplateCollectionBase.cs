using System.Collections;
using System.Collections.Generic;

namespace Config.Common;

public abstract class ItemTemplateCollectionBase<T> : IEnumerable<ItemTemplateBase>, IEnumerable where T : ItemTemplateBase
{
	public abstract int Count { get; }

	public abstract ItemTemplateBase GetItemBase(short templateId);

	IEnumerator<ItemTemplateBase> IEnumerable<ItemTemplateBase>.GetEnumerator()
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current as ItemTemplateBase;
		}
	}

	public abstract IEnumerator GetEnumerator();
}
