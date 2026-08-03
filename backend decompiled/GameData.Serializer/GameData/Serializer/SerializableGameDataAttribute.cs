using System;

namespace GameData.Serializer;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class SerializableGameDataAttribute : Attribute
{
	public bool NotForDisplayModule;

	public bool NotForArchive;

	public bool NotRestrictCollectionSerializedSize;

	public bool IsExtensible;

	public bool NoCopyConstructors;

	public SerializableGameDataAttribute()
	{
		NotForDisplayModule = false;
		NotForArchive = false;
		NotRestrictCollectionSerializedSize = false;
		IsExtensible = false;
		NoCopyConstructors = false;
	}
}
