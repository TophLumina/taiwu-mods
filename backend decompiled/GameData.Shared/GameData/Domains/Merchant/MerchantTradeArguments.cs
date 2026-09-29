using System.Collections.Generic;
using GameData.Domains.Building;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Merchant;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class MerchantTradeArguments : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<ItemKey, long> TradeMoneySources;

	[SerializableGameDataField]
	public long BuyMoney;

	[SerializableGameDataField]
	public long SoldMoney;

	[SerializableGameDataField]
	public List<ItemSourceChange> ItemChangeList;

	[SerializableGameDataField]
	public MerchantOverFavorData OverFavorData;

	[SerializableGameDataField]
	public OpenShopEventArguments OpenShopEventArguments;

	[SerializableGameDataField]
	public MerchantData MerchantData;

	[SerializableGameDataField]
	public MerchantBuyBackData MerchantBuyBackData;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 28;
		totalSize += 4;
		if (TradeMoneySources != null)
		{
			foreach (KeyValuePair<ItemKey, long> tradeMoneySource in TradeMoneySources)
			{
				totalSize += tradeMoneySource.Key.GetSerializedSize();
				totalSize += 8;
			}
		}
		if (ItemChangeList != null)
		{
			totalSize += 2;
			for (int i = 0; i < ItemChangeList.Count; i++)
			{
				totalSize = ((ItemChangeList[i] == null) ? (totalSize + 2) : (totalSize + (2 + ItemChangeList[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((OverFavorData == null) ? (totalSize + 2) : (totalSize + (2 + OverFavorData.GetSerializedSize())));
		totalSize = ((MerchantData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantData.GetSerializedSize())));
		totalSize = ((MerchantBuyBackData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantBuyBackData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (TradeMoneySources != null)
		{
			*(int*)pCurrData = TradeMoneySources.Count;
			pCurrData += 4;
			foreach (KeyValuePair<ItemKey, long> pair in TradeMoneySources)
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
		*(long*)pCurrData = BuyMoney;
		pCurrData += 8;
		*(long*)pCurrData = SoldMoney;
		pCurrData += 8;
		if (ItemChangeList != null)
		{
			int elementsCount = ItemChangeList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (ItemChangeList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = ItemChangeList[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (OverFavorData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = OverFavorData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += OpenShopEventArguments.Serialize(pCurrData);
		if (MerchantData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = MerchantData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (MerchantBuyBackData != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = MerchantBuyBackData.Serialize(pCurrData);
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
		int TradeMoneySourcesElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (TradeMoneySourcesElementsCount > 0)
		{
			if (TradeMoneySources == null)
			{
				TradeMoneySources = new Dictionary<ItemKey, long>();
			}
			else
			{
				TradeMoneySources.Clear();
			}
			for (int i = 0; i < TradeMoneySourcesElementsCount; i++)
			{
				ItemKey key = default(ItemKey);
				pCurrData += key.Deserialize(pCurrData);
				long value = *(long*)pCurrData;
				pCurrData += 8;
				TradeMoneySources.Add(key, value);
			}
		}
		else
		{
			TradeMoneySources?.Clear();
		}
		BuyMoney = *(long*)pCurrData;
		pCurrData += 8;
		SoldMoney = *(long*)pCurrData;
		pCurrData += 8;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ItemChangeList == null)
			{
				ItemChangeList = new List<ItemSourceChange>();
			}
			else
			{
				ItemChangeList.Clear();
			}
			for (int j = 0; j < elementsCount; j++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemSourceChange element;
				if (num > 0)
				{
					element = new ItemSourceChange();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				ItemChangeList.Add(element);
			}
		}
		else
		{
			ItemChangeList?.Clear();
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			OverFavorData = new MerchantOverFavorData();
			pCurrData += OverFavorData.Deserialize(pCurrData);
		}
		else
		{
			OverFavorData = null;
		}
		OpenShopEventArguments = new OpenShopEventArguments();
		pCurrData += OpenShopEventArguments.Deserialize(pCurrData);
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			MerchantData = new MerchantData();
			pCurrData += MerchantData.Deserialize(pCurrData);
		}
		else
		{
			MerchantData = null;
		}
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			MerchantBuyBackData = new MerchantBuyBackData();
			pCurrData += MerchantBuyBackData.Deserialize(pCurrData);
		}
		else
		{
			MerchantBuyBackData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
