using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 额外商品信息的集合
/// 已废弃，用新结构代替<see cref="T:GameData.Domains.Extra.MerchantExtraGoodsData" />
/// </summary>
[SerializableGameData]
[Obsolete("use new archive data MerchantExtraGoodsData instead, do not delete this")]
public class MerchantExtraGoods : ISerializableGameData
{
	/// <summary>
	/// 额外商品信息的集合
	/// </summary>
	[SerializableGameDataField]
	public List<MerchantExtraGoodsItem> Items = new List<MerchantExtraGoodsItem>();

	/// <summary>
	/// 检查包含物品
	/// </summary>
	/// <returns></returns>
	public bool Check(int id, int index)
	{
		return Items?.Exists((MerchantExtraGoodsItem d) => d.Id == id && d.Index == index) ?? false;
	}

	public MerchantExtraGoods()
	{
	}

	public MerchantExtraGoods(MerchantExtraGoods other)
	{
		Items = new List<MerchantExtraGoodsItem>(other.Items);
	}

	public void Assign(MerchantExtraGoods other)
	{
		Items = new List<MerchantExtraGoodsItem>(other.Items);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((Items == null) ? (totalSize + 2) : (totalSize + (2 + 8 * Items.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Items[i].Serialize(pCurrData);
			}
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Items == null)
			{
				Items = new List<MerchantExtraGoodsItem>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				MerchantExtraGoodsItem element = default(MerchantExtraGoodsItem);
				pCurrData += element.Deserialize(pCurrData);
				Items.Add(element);
			}
		}
		else
		{
			Items?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
