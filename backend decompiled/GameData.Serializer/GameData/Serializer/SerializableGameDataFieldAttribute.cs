using System;

namespace GameData.Serializer;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class SerializableGameDataFieldAttribute : Attribute
{
	public int ArrayElementsCount;

	public int CollectionMaxElementsCount;

	public int SubDataMaxCount;

	public string SerializationHandler;

	public int FieldIndex;

	public SerializableGameDataFieldAttribute()
	{
		ArrayElementsCount = -1;
		CollectionMaxElementsCount = 65535;
		SubDataMaxCount = 65535;
		FieldIndex = -1;
		SerializationHandler = string.Empty;
	}
}
