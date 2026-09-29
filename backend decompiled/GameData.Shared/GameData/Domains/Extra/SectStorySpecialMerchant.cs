using GameData.Domains.Merchant;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class SectStorySpecialMerchant : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort MerchantData = 0;

		public const ushort RefreshTime = 1;

		public const ushort MerchantExtraGoodsData = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "MerchantData", "RefreshTime", "MerchantExtraGoodsData" };
	}

	[SerializableGameDataField]
	public MerchantData MerchantData;

	[SerializableGameDataField]
	public int RefreshTime;

	[SerializableGameDataField]
	public MerchantExtraGoodsData MerchantExtraGoodsData;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((MerchantData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantData.GetSerializedSize())));
		totalSize = ((MerchantExtraGoodsData == null) ? (totalSize + 2) : (totalSize + (2 + MerchantExtraGoodsData.GetSerializedSize())));
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
		if (MerchantData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = MerchantData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = RefreshTime;
		pCurrData += 4;
		if (MerchantExtraGoodsData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = MerchantExtraGoodsData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (MerchantData == null)
				{
					MerchantData = new MerchantData();
				}
				pCurrData += MerchantData.Deserialize(pCurrData);
			}
			else
			{
				MerchantData = null;
			}
		}
		if (num > 1)
		{
			RefreshTime = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				if (MerchantExtraGoodsData == null)
				{
					MerchantExtraGoodsData = new MerchantExtraGoodsData();
				}
				pCurrData += MerchantExtraGoodsData.Deserialize(pCurrData);
			}
			else
			{
				MerchantExtraGoodsData = null;
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
