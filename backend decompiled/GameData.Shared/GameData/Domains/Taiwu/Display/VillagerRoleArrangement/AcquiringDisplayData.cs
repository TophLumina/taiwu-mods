using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class AcquiringDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public int ExtraBuyPossibility;

	[SerializableGameDataField]
	public int PricePercent;

	[SerializableGameDataField]
	public TemplateKey AcquiringItem;

	[SerializableGameDataField]
	public int ExtraMerchantFavor;

	[SerializableGameDataField]
	public int BoughtAmount;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = ExtraBuyPossibility;
		pCurrData += 4;
		*(int*)pCurrData = PricePercent;
		pCurrData += 4;
		pCurrData += AcquiringItem.Serialize(pCurrData);
		*(int*)pCurrData = ExtraMerchantFavor;
		pCurrData += 4;
		*(int*)pCurrData = BoughtAmount;
		pCurrData += 4;
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
		ExtraBuyPossibility = *(int*)pCurrData;
		pCurrData += 4;
		PricePercent = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += AcquiringItem.Deserialize(pCurrData);
		ExtraMerchantFavor = *(int*)pCurrData;
		pCurrData += 4;
		BoughtAmount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
