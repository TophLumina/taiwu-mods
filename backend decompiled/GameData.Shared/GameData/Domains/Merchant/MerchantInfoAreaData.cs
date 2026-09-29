using GameData.Serializer;

namespace GameData.Domains.Merchant;

[SerializableGameData(NoCopyConstructors = true)]
public class MerchantInfoAreaData : ISerializableGameData
{
	[SerializableGameDataField]
	public short AreaTemplateId;

	[SerializableGameDataField]
	public int CaravanCount;

	[SerializableGameDataField]
	public int MerchantCount;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = AreaTemplateId;
		byte* num = pData + 2;
		*(int*)num = CaravanCount;
		byte* num2 = num + 4;
		*(int*)num2 = MerchantCount;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		AreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CaravanCount = *(int*)pCurrData;
		pCurrData += 4;
		MerchantCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
