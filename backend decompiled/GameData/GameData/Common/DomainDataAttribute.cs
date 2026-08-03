using System;

namespace GameData.Common;

[AttributeUsage(AttributeTargets.Field)]
public class DomainDataAttribute : Attribute
{
	public readonly DomainDataType DomainDataType;

	public readonly bool IsArchive;

	public readonly bool IsCache;

	public readonly bool IsReadable;

	public readonly bool IsWritable;

	public int ArrayElementsCount;

	public int CollectionCapacity;

	public bool HoldIdsOnly;

	public bool GenerateModificationFreeMethods;

	public bool ThreadSafe;

	public string DefaultValue;

	public bool SkipLoad;

	public DomainDataAttribute(DomainDataType domainDataType, bool isArchive, bool isCache, bool isReadable = true, bool isWritable = true)
	{
		DomainDataType = domainDataType;
		IsArchive = isArchive;
		IsCache = isCache;
		IsReadable = isReadable;
		IsWritable = isWritable;
		ArrayElementsCount = 0;
		CollectionCapacity = 0;
		HoldIdsOnly = false;
		GenerateModificationFreeMethods = false;
		ThreadSafe = false;
	}
}
