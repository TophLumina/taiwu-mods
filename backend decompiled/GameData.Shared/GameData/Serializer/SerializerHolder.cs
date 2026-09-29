using System;
using GameData.Utilities;

namespace GameData.Serializer;

public static class SerializerHolder<T>
{
	public delegate int SerializeFunction(T item, RawDataPool dataPool);

	public delegate int DeserializeFunction(RawDataPool dataPool, int offset, ref T item);

	public static SerializeFunction SerializeFunc;

	public static DeserializeFunction DeserializeFunc;

	public static int Serialize(T item, RawDataPool dataPool)
	{
		if (SerializeFunc != null)
		{
			return SerializeFunc(item, dataPool);
		}
		throw new Exception("SerializeFunc is null of " + typeof(T).FullName);
	}

	public static int Deserialize(RawDataPool dataPool, int offset, ref T item)
	{
		if (DeserializeFunc != null)
		{
			return DeserializeFunc(dataPool, offset, ref item);
		}
		throw new Exception("DeserializeFunc is null of " + typeof(T).FullName);
	}
}
