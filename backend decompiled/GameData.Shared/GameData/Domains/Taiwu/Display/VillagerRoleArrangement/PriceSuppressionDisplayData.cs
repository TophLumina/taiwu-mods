using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PriceSuppressionDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public TemplateKey SuppressionItem;

	[SerializableGameDataField]
	public int PriceDropRate;

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
		pCurrData += SuppressionItem.Serialize(pCurrData);
		*(int*)pCurrData = PriceDropRate;
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
		pCurrData += SuppressionItem.Deserialize(pCurrData);
		PriceDropRate = *(int*)pCurrData;
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
