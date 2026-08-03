using System;

namespace GameData.Common;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
public class CollectionObjectFieldAttribute : Attribute
{
	public readonly bool IsTemplate;

	public readonly bool IsArchive;

	public readonly bool IsCache;

	public readonly bool IsReadonly;

	public readonly bool IsCharacterProperty;

	public int ArrayElementsCount;

	public CollectionObjectFieldAttribute(bool isTemplate, bool isArchive, bool isCache, bool isReadonly, bool isCharacterProperty)
	{
		IsTemplate = isTemplate;
		IsArchive = isArchive;
		IsCache = isCache;
		IsReadonly = isReadonly;
		IsCharacterProperty = isCharacterProperty;
		ArrayElementsCount = 0;
	}
}
