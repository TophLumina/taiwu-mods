using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 额外商品信息
/// </summary>
[SerializableGameData]
public struct MerchantExtraGoodsItem : ISerializableGameData
{
	/// <summary>
	/// 商人行囊的序号
	/// </summary>
	[SerializableGameDataField]
	public sbyte Index;

	/// <summary>
	/// 额外物品的实际ID
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)Index;
		byte* num = pData + 1;
		*(int*)num = Id;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Index = (sbyte)(*pCurrData);
		pCurrData++;
		Id = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
