using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 物品索引以及数量
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct ItemKeyAndCount : ISerializableGameData
{
	/// <summary>
	/// 物品索引
	/// </summary>
	[SerializableGameDataField]
	public ItemKey ItemKey;

	/// <summary>
	/// 数量
	/// </summary>
	[SerializableGameDataField]
	public int Count;

	public static implicit operator ItemKeyAndCount((ItemKey itemKey, int count) tuple)
	{
		ItemKeyAndCount result = default(ItemKeyAndCount);
		(result.ItemKey, result.Count) = tuple;
		return result;
	}

	/// <summary>
	/// 隐式转换
	/// </summary>
	public static implicit operator ItemKeyAndCount(ItemKey itemKey)
	{
		return new ItemKeyAndCount
		{
			ItemKey = itemKey,
			Count = 1
		};
	}

	/// <summary>
	/// 构造方法
	/// </summary>
	public ItemKeyAndCount(ItemKey itemKey, int count)
	{
		ItemKey = itemKey;
		Count = count;
	}

	/// <summary>
	/// 反构造
	/// </summary>
	public void Deconstruct(out ItemKey itemKey, out int count)
	{
		itemKey = ItemKey;
		count = Count;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += ItemKey.Serialize(pCurrData);
		*(int*)pCurrData = Count;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += ItemKey.Deserialize(pCurrData);
		Count = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
