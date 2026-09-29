using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PriceGougingDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public TemplateKey GougingItem;

	[SerializableGameDataField]
	public int PriceRiseRate;

	[SerializableGameDataField]
	public int MaxPriceTimes;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += GougingItem.Serialize(pCurrData);
		*(int*)pCurrData = PriceRiseRate;
		pCurrData += 4;
		*(int*)pCurrData = MaxPriceTimes;
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
		pCurrData += GougingItem.Deserialize(pCurrData);
		PriceRiseRate = *(int*)pCurrData;
		pCurrData += 4;
		MaxPriceTimes = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
