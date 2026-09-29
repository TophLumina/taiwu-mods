using System;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.ExchangeSystem;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class ExchangeItem : ISerializableGameData, IEquatable<ExchangeItem>
{
	public enum EExchangeItemType
	{
		Item,
		Kidnap
	}

	[SerializableGameDataField]
	public int Type;

	[SerializableGameDataField]
	public ItemDisplayData ItemData;

	[SerializableGameDataField]
	public ItemDisplayData OriginItemData;

	[SerializableGameDataField]
	public KidnapCharDisplayData KidnapCharDisplayData;

	[SerializableGameDataField]
	public long TotalValue;

	[SerializableGameDataField]
	public int Count;

	[SerializableGameDataField]
	public Inventory Inventory;

	public EExchangeItemType TypeEnum => (EExchangeItemType)Type;

	public ITradeableContent Content => TypeEnum switch
	{
		EExchangeItemType.Item => ItemData, 
		EExchangeItemType.Kidnap => KidnapCharDisplayData, 
		_ => throw new ArgumentOutOfRangeException(), 
	};

	public long TotalValueAbs => Math.Abs(TotalValue);

	public sbyte Grade => TypeEnum switch
	{
		EExchangeItemType.Item => ItemData.Grade, 
		EExchangeItemType.Kidnap => KidnapCharDisplayData.OrganizationInfo.Grade, 
		_ => throw new ArgumentOutOfRangeException(), 
	};

	public bool Equals(ExchangeItem other)
	{
		if (other == null)
		{
			return false;
		}
		if (other.Type != Type)
		{
			return false;
		}
		switch (TypeEnum)
		{
		case EExchangeItemType.Item:
			if (other.ItemData == null || ItemData == null)
			{
				return false;
			}
			if (!other.ItemData.ContainsItemKey(ItemData.RealKey))
			{
				return false;
			}
			if (other.ItemData.OwnerCharId != ItemData.OwnerCharId)
			{
				return false;
			}
			if (other.ItemData.ItemSourceType != ItemData.ItemSourceType)
			{
				return false;
			}
			break;
		case EExchangeItemType.Kidnap:
			if (other.KidnapCharDisplayData == null || KidnapCharDisplayData == null)
			{
				return false;
			}
			if (other.KidnapCharDisplayData.CharacterId != KidnapCharDisplayData.CharacterId)
			{
				return false;
			}
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return true;
	}

	public ExchangeItem Clone()
	{
		return new ExchangeItem
		{
			Type = Type,
			ItemData = ItemData,
			KidnapCharDisplayData = KidnapCharDisplayData,
			Count = Count,
			TotalValue = TotalValue,
			Inventory = Inventory
		};
	}

	public ExchangeItem Clone(int count)
	{
		ExchangeItem exchangeItem = Clone();
		exchangeItem.Count = count;
		return exchangeItem;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
		totalSize = ((ItemData == null) ? (totalSize + 2) : (totalSize + (2 + ItemData.GetSerializedSize())));
		totalSize = ((OriginItemData == null) ? (totalSize + 2) : (totalSize + (2 + OriginItemData.GetSerializedSize())));
		totalSize = ((KidnapCharDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + KidnapCharDisplayData.GetSerializedSize())));
		totalSize = ((Inventory == null) ? (totalSize + 2) : (totalSize + (2 + Inventory.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Type;
		pCurrData += 4;
		if (ItemData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (OriginItemData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = OriginItemData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (KidnapCharDisplayData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = KidnapCharDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(long*)pCurrData = TotalValue;
		pCurrData += 8;
		*(int*)pCurrData = Count;
		pCurrData += 4;
		if (Inventory != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = Inventory.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		Type = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ItemData = new ItemDisplayData();
			pCurrData += ItemData.Deserialize(pCurrData);
		}
		else
		{
			ItemData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			OriginItemData = new ItemDisplayData();
			pCurrData += OriginItemData.Deserialize(pCurrData);
		}
		else
		{
			OriginItemData = null;
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			KidnapCharDisplayData = new KidnapCharDisplayData();
			pCurrData += KidnapCharDisplayData.Deserialize(pCurrData);
		}
		else
		{
			KidnapCharDisplayData = null;
		}
		TotalValue = *(long*)pCurrData;
		pCurrData += 8;
		Count = *(int*)pCurrData;
		pCurrData += 4;
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			Inventory = new Inventory();
			pCurrData += Inventory.Deserialize(pCurrData);
		}
		else
		{
			Inventory = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
