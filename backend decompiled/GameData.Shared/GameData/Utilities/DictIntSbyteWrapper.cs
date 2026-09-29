using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

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

	public DictIntSbyteWrapper()
	{
	}

	public DictIntSbyteWrapper(DictIntSbyteWrapper other)
	{
		Value = ((other.Value == null) ? null : new Dictionary<int, sbyte>(other.Value));
	}

	public void Assign(DictIntSbyteWrapper other)
	{
		Value = ((other.Value == null) ? null : new Dictionary<int, sbyte>(other.Value));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypePair.Serialize(pData, ref Value) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
