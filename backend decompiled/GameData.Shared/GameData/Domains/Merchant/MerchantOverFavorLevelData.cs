using System;
using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Merchant;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class MerchantOverFavorLevelData : ISerializableGameData, ICloneable
{
	private static class FieldIds
	{
		public const ushort BuyCount = 0;

		public const ushort Inventory = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "BuyCount", "Inventory" };
	}

	[SerializableGameDataField]
	public short BuyCount;

	[SerializableGameDataField]
	public Inventory Inventory = new Inventory();

	public object Clone()
	{
		MerchantOverFavorLevelData levelData = new MerchantOverFavorLevelData
		{
			BuyCount = BuyCount,
			Inventory = new Inventory()
		};
		foreach (var (key, value) in Inventory.Items)
		{
			levelData.Inventory.Items.Add(key, value);
		}
		return levelData;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(short*)pCurrData = BuyCount;
		pCurrData += 2;
		if (Inventory != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Inventory.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			BuyCount = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (Inventory == null)
				{
					Inventory = new Inventory();
				}
				pCurrData += Inventory.Deserialize(pCurrData);
			}
			else
			{
				Inventory = null;
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
