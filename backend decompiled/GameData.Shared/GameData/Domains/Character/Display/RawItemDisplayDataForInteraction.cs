using Config;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class RawItemDisplayDataForInteraction : ITradeableContent, ISerializableGameData
{
	[SerializableGameDataField]
	private ItemKey _key;

	[SerializableGameDataField]
	public bool Interactable;

	private static readonly LocalObjectPool<Inventory> LocalObjectPool = new LocalObjectPool<Inventory>(1, 4);

	int ITradeableContent.Amount
	{
		get
		{
			return 1;
		}
		set
		{
		}
	}

	bool ITradeableContent.Interactable
	{
		get
		{
			return Interactable;
		}
		set
		{
			Interactable = value;
		}
	}

	public ItemKey Key
	{
		get
		{
			return _key;
		}
		set
		{
			_key = value;
		}
	}

	public ItemKey RealKey => _key;

	public long Value
	{
		get
		{
			return Misc.Instance[(short)388].BaseValue;
		}
		set
		{
		}
	}

	public sbyte Grade => Misc.Instance[(short)388].Grade;

	sbyte ITradeableContent.Gender => -1;

	OrganizationInfo ITradeableContent.OrganizationInfo => default(OrganizationInfo);

	NameRelatedData ITradeableContent.NameRelatedData => default(NameRelatedData);

	AvatarRelatedData ITradeableContent.AvatarRelatedData => null;

	Inventory ITradeableContent.GetAllInventoryFromPool()
	{
		return GetAllItemKeysFromPool();
	}

	public static Inventory GetItemKeyListFromPool()
	{
		return LocalObjectPool.Get();
	}

	public Inventory GetAllItemKeysFromPool()
	{
		Inventory itemKeyListFromPool = GetItemKeyListFromPool();
		itemKeyListFromPool.Items.Add(_key, 1);
		return itemKeyListFromPool;
	}

	public ITradeableContent Clone(int amount = -1)
	{
		return new RawItemDisplayDataForInteraction(this);
	}

	public sbyte GetContentType()
	{
		return 4;
	}

	public RawItemDisplayDataForInteraction()
	{
	}

	public RawItemDisplayDataForInteraction(RawItemDisplayDataForInteraction other)
	{
		_key = other._key;
		Interactable = other.Interactable;
	}

	public void Assign(RawItemDisplayDataForInteraction other)
	{
		_key = other._key;
		Interactable = other.Interactable;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _key.Serialize(pCurrData);
		*pCurrData = (Interactable ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		pCurrData += _key.Deserialize(pCurrData);
		Interactable = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
