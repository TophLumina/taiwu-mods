using System;

namespace GameData.Common.SingleValueCollection;

public readonly struct SingleValueCollectionModification<TKey>(sbyte type, TKey id) where TKey : unmanaged, IEquatable<TKey>
{
	public readonly sbyte Type = type;

	public readonly TKey Id = id;

	public bool Equals(sbyte type, TKey id)
	{
		if (Type == type)
		{
			return Id.Equals(id);
		}
		return false;
	}
}
