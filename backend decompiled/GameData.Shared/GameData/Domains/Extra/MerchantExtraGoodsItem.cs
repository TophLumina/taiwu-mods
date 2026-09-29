using GameData.Serializer;

namespace GameData.Domains.Extra;

[SerializableGameData]
public struct MerchantExtraGoodsItem : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte Index;

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
