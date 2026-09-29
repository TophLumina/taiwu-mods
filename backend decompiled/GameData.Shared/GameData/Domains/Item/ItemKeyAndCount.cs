using GameData.Serializer;

namespace GameData.Domains.Item;

[SerializableGameData(NotForArchive = true)]
public struct ItemKeyAndCount : ISerializableGameData
{
	[SerializableGameDataField]
	public ItemKey ItemKey;

	[SerializableGameDataField]
	public int Count;

	public static implicit operator ItemKeyAndCount((ItemKey itemKey, int count) tuple)
	{
		ItemKeyAndCount result = default(ItemKeyAndCount);
		(result.ItemKey, result.Count) = tuple;
		return result;
	}

	public static implicit operator ItemKeyAndCount(ItemKey itemKey)
	{
		return new ItemKeyAndCount
		{
			ItemKey = itemKey,
			Count = 1
		};
	}

	public ItemKeyAndCount(ItemKey itemKey, int count)
	{
		ItemKey = itemKey;
		Count = count;
	}

	public void Deconstruct(out ItemKey itemKey, out int count)
	{
		itemKey = ItemKey;
		count = Count;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
