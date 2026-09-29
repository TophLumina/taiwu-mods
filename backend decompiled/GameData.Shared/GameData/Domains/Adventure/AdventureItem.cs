using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Adventure;

[SerializableGameData(IsExtensible = true)]
public class AdventureItem : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ItemKey = 0;

		public const ushort ItemCount = 1;

		public const ushort OwnerId = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ItemKey", "ItemCount", "OwnerId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey ItemKey;

	[SerializableGameDataField(FieldIndex = 1)]
	public int ItemCount;

	[SerializableGameDataField(FieldIndex = 2)]
	public int OwnerId;

	public bool IsOwnedByTaiwu => IsItemOwnedByTaiwu(this);

	public static bool IsItemOwnedByTaiwu(AdventureItem item)
	{
		return item.OwnerId == 0;
	}

	public AdventureItem(ItemKey key, int count, int ownerId)
	{
		ItemKey = key;
		ItemCount = count;
		OwnerId = ownerId;
	}

	public bool ChangeCount(int delta)
	{
		if (ItemCount + delta < 0)
		{
			return false;
		}
		ItemCount += delta;
		return true;
	}

	public AdventureItem()
	{
	}

	public AdventureItem(AdventureItem other)
	{
		ItemKey = other.ItemKey;
		ItemCount = other.ItemCount;
		OwnerId = other.OwnerId;
	}

	public void Assign(AdventureItem other)
	{
		ItemKey = other.ItemKey;
		ItemCount = other.ItemCount;
		OwnerId = other.OwnerId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		pCurrData += ItemKey.Serialize(pCurrData);
		*(int*)pCurrData = ItemCount;
		pCurrData += 4;
		*(int*)pCurrData = OwnerId;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += ItemKey.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			ItemCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			OwnerId = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
