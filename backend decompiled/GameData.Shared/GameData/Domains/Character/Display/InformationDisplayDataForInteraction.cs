using System;
using Config;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class InformationDisplayDataForInteraction : ITradeableContent, ISerializableGameData
{
	[SerializableGameDataField]
	private ItemKey _key;

	[SerializableGameDataField]
	public bool Interactable;

	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public int Amount;

	[SerializableGameDataField]
	public int AlertFactor;

	private static readonly LocalObjectPool<Inventory> LocalObjectPool = new LocalObjectPool<Inventory>(1, 4);

	int ITradeableContent.AlertFactor => AlertFactor;

	int ITradeableContent.Amount
	{
		get
		{
			return Amount;
		}
		set
		{
			Amount = value;
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
			throw new InvalidOperationException();
		}
	}

	public sbyte Grade => Misc.Instance[(short)388].Grade;

	sbyte ITradeableContent.Gender => -1;

	int ITradeableContent.CharacterId => CharacterId;

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
		itemKeyListFromPool.Items.Add(_key, Amount);
		return itemKeyListFromPool;
	}

	public ITradeableContent Clone(int amount = -1)
	{
		return new InformationDisplayDataForInteraction(this);
	}

	public sbyte GetContentType()
	{
		return 3;
	}

	public InformationDisplayDataForInteraction()
	{
	}

	public InformationDisplayDataForInteraction(InformationDisplayDataForInteraction other)
	{
		_key = other._key;
		Interactable = other.Interactable;
		CharacterId = other.CharacterId;
		Amount = other.Amount;
		AlertFactor = other.AlertFactor;
	}

	public void Assign(InformationDisplayDataForInteraction other)
	{
		_key = other._key;
		Interactable = other.Interactable;
		CharacterId = other.CharacterId;
		Amount = other.Amount;
		AlertFactor = other.AlertFactor;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 21;
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
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		*(int*)pCurrData = AlertFactor;
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
		pCurrData += _key.Deserialize(pCurrData);
		Interactable = *pCurrData != 0;
		pCurrData++;
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		Amount = *(int*)pCurrData;
		pCurrData += 4;
		AlertFactor = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
