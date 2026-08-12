using System;
using GameData.Utilities;

namespace GameData.Serializer;

/// <summary>
/// 在表现模块与数据模块之间传递游戏数据时, 序列化方法的包装器与路由器
/// </summary>
public static class SerializerHolder<T>
{
	/// <summary>
	/// 序列化方法签名
	/// </summary>
	public delegate int SerializeFunction(T item, RawDataPool dataPool);

	/// <summary>
	/// 反序列化方法签名
	/// </summary>
	public delegate int DeserializeFunction(RawDataPool dataPool, int offset, ref T item);

	/// <summary>
	/// 序列化方法
	/// </summary>
	public static SerializeFunction SerializeFunc;

	/// <summary>
	/// 反序列化方法
	/// </summary>
	public static DeserializeFunction DeserializeFunc;

	/// <summary>
	/// 序列化
	/// </summary>
	/// <param name="item">要序列化的对象</param>
	/// <param name="dataPool">数据池</param>
	/// <returns>数据在数据池中的偏移</returns>
	public static int Serialize(T item, RawDataPool dataPool)
	{
		if (SerializeFunc != null)
		{
			return SerializeFunc(item, dataPool);
		}
		throw new Exception("SerializeFunc is null of " + typeof(T).FullName);
	}

	/// <summary>
	/// 反序列化
	/// </summary>
	/// <param name="dataPool">数据池</param>
	/// <param name="offset">数据在数据池中的偏移</param>
	/// <param name="item">存放反序列化后的结果的对象</param>
	/// <returns>序列化数据的长度</returns>
	public static int Deserialize(RawDataPool dataPool, int offset, ref T item)
	{
		if (DeserializeFunc != null)
		{
			return DeserializeFunc(dataPool, offset, ref item);
		}
		throw new Exception("DeserializeFunc is null of " + typeof(T).FullName);
	}
}
