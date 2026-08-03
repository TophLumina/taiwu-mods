using Config;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class InformationSecretDisplayDataForInteraction : ITradeableContent, ISerializableGameData
{
	[SerializableGameDataField]
	private ItemKey _key;

	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public bool Interactable;

	/// <summary>
	/// 数量
	/// </summary>
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

	/// <summary>
	/// 可交互
	/// </summary>
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

	/// <summary>
	/// templateId为Misc的秘闻
	/// </summary>
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

	int ITradeableContent.CharacterId => CharacterId;

	OrganizationInfo ITradeableContent.OrganizationInfo => default(OrganizationInfo);

	NameRelatedData ITradeableContent.NameRelatedData => default(NameRelatedData);

	AvatarRelatedData ITradeableContent.AvatarRelatedData => null;

	Inventory ITradeableContent.GetAllInventoryFromPool()
	{
		return GetAllItemKeysFromPool();
	}

	/// <summary>
	/// 从对象池获取，必须归还
	/// </summary>
	/// <returns></returns>
	public static Inventory GetItemKeyListFromPool()
	{
		return LocalObjectPool.Get();
	}

	/// <summary>
	/// </summary>
	/// <returns></returns>
	public Inventory GetAllItemKeysFromPool()
	{
		Inventory itemKeyListFromPool = GetItemKeyListFromPool();
		itemKeyListFromPool.Items.Add(_key, Amount);
		return itemKeyListFromPool;
	}

	public ITradeableContent Clone(int amount = -1)
	{
		return new InformationSecretDisplayDataForInteraction(this);
	}

	public sbyte GetContentType()
	{
		return 2;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public InformationSecretDisplayDataForInteraction()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public InformationSecretDisplayDataForInteraction(InformationSecretDisplayDataForInteraction other)
	{
		_key = other._key;
		CharacterId = other.CharacterId;
		Interactable = other.Interactable;
		Amount = other.Amount;
		AlertFactor = other.AlertFactor;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(InformationSecretDisplayDataForInteraction other)
	{
		_key = other._key;
		CharacterId = other.CharacterId;
		Interactable = other.Interactable;
		Amount = other.Amount;
		AlertFactor = other.AlertFactor;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 21;
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
		pCurrData += _key.Serialize(pCurrData);
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*pCurrData = (Interactable ? ((byte)1) : ((byte)0));
		pCurrData++;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += _key.Deserialize(pCurrData);
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		Interactable = *pCurrData != 0;
		pCurrData++;
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
