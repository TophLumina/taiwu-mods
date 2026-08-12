using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

/// <summary>
/// Int/Sbyte 字典包装器
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class DictIntSbyteWrapper : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<int, sbyte> Value;

	public static implicit operator DictIntSbyteWrapper(Dictionary<int, sbyte> dict)
	{
		if (dict == null)
		{
			return new DictIntSbyteWrapper();
		}
		return new DictIntSbyteWrapper
		{
			Value = new Dictionary<int, sbyte>(dict)
		};
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DictIntSbyteWrapper()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public DictIntSbyteWrapper(DictIntSbyteWrapper other)
	{
		Value = ((other.Value == null) ? null : new Dictionary<int, sbyte>(other.Value));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(DictIntSbyteWrapper other)
	{
		Value = ((other.Value == null) ? null : new Dictionary<int, sbyte>(other.Value));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(Value);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypePair.Serialize(pData, ref Value) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pData, ref Value) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
