using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Merchant;

/// <summary>
/// 商店回购数据，不存档，每次过月清除。需要配合<see cref="T:GameData.Domains.Merchant.MerchantData" />使用。
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true, IsExtensible = true)]
public class MerchantBuyBackData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort MerchantType = 0;

		public const ushort BuyInGoodsList = 1;

		public const ushort BuyInPrice = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "MerchantType", "BuyInGoodsList", "BuyInPrice" };
	}

	/// <summary>
	/// 商店类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte MerchantType = -1;

	/// <summary>
	/// 回购列表
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public Inventory BuyInGoodsList = new Inventory();

	/// <summary>
	/// 回购价格。记录玩家卖出道具时的价格，回购时按原价购买
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public Dictionary<ItemKey, long> BuyInPrice = new Dictionary<ItemKey, long>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((BuyInGoodsList == null) ? (totalSize + 2) : (totalSize + (2 + BuyInGoodsList.GetSerializedSize())));
		totalSize += 4;
		if (BuyInPrice != null)
		{
			foreach (KeyValuePair<ItemKey, long> item in BuyInPrice)
			{
				totalSize += item.Key.GetSerializedSize();
				totalSize += 8;
			}
		}
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
		*pCurrData = (byte)MerchantType;
		pCurrData++;
		if (BuyInGoodsList != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = BuyInGoodsList.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BuyInPrice != null)
		{
			*(int*)pCurrData = BuyInPrice.Count;
			pCurrData += 4;
			foreach (KeyValuePair<ItemKey, long> pair in BuyInPrice)
			{
				pCurrData += pair.Key.Serialize(pCurrData);
				*(long*)pCurrData = pair.Value;
				pCurrData += 8;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			MerchantType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				BuyInGoodsList = new Inventory();
				pCurrData += BuyInGoodsList.Deserialize(pCurrData);
			}
			else
			{
				BuyInGoodsList = null;
			}
		}
		if (num > 2)
		{
			int BuyInPriceElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (BuyInPriceElementsCount > 0)
			{
				if (BuyInPrice == null)
				{
					BuyInPrice = new Dictionary<ItemKey, long>();
				}
				else
				{
					BuyInPrice.Clear();
				}
				for (int i = 0; i < BuyInPriceElementsCount; i++)
				{
					ItemKey key = default(ItemKey);
					pCurrData += key.Deserialize(pCurrData);
					long value = *(long*)pCurrData;
					pCurrData += 8;
					BuyInPrice.Add(key, value);
				}
			}
			else
			{
				BuyInPrice?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
