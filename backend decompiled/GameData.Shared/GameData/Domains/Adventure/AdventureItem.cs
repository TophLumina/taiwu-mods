using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇道具
/// </summary>
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

	/// <summary>
	/// 道具键
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey ItemKey;

	/// <summary>
	/// 道具数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int ItemCount;

	/// <summary>
	/// 持有者，当前仅用于元素 ID <see cref="F:GameData.Domains.Adventure.AdventureElement.Id" />
	/// 等于 <see cref="F:GameData.Adventure.AdventureDataHelper.Invalid" /> 时是太吾持有的道具
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int OwnerId;

	/// <summary>
	/// 自身是否被太吾持有
	/// </summary>
	public bool IsOwnedByTaiwu => IsItemOwnedByTaiwu(this);

	/// <summary>
	/// 是否太吾持有的临时道具
	/// </summary>
	public static bool IsItemOwnedByTaiwu(AdventureItem item)
	{
		return item.OwnerId == 0;
	}

	/// <summary>
	/// 基于创建好的道具构造
	/// </summary>
	public AdventureItem(ItemKey key, int count, int ownerId)
	{
		ItemKey = key;
		ItemCount = count;
		OwnerId = ownerId;
	}

	/// <summary>
	/// 改变数量
	/// </summary>
	/// <param name="delta"></param>
	/// <returns>成功进行了改变</returns>
	public bool ChangeCount(int delta)
	{
		if (ItemCount + delta < 0)
		{
			return false;
		}
		ItemCount += delta;
		return true;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AdventureItem()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AdventureItem(AdventureItem other)
	{
		ItemKey = other.ItemKey;
		ItemCount = other.ItemCount;
		OwnerId = other.OwnerId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AdventureItem other)
	{
		ItemKey = other.ItemKey;
		ItemCount = other.ItemCount;
		OwnerId = other.OwnerId;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 18;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
