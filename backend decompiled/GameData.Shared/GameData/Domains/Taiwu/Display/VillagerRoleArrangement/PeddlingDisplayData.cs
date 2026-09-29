using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class PeddlingDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte InteractTargetGrade;

	[SerializableGameDataField]
	public int BuyPriceRate;

	[SerializableGameDataField]
	public int SellPriceRate;

	[SerializableGameDataField]
	public int AddFavorA;

	[SerializableGameDataField]
	public int AddFavorB;

	[SerializableGameDataField]
	public bool IsBuy;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)InteractTargetGrade;
		byte* num = pData + 1;
		*(int*)num = BuyPriceRate;
		byte* num2 = num + 4;
		*(int*)num2 = SellPriceRate;
		byte* num3 = num2 + 4;
		*(int*)num3 = AddFavorA;
		byte* num4 = num3 + 4;
		*(int*)num4 = AddFavorB;
		byte* num5 = num4 + 4;
		*num5 = (IsBuy ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		InteractTargetGrade = (sbyte)(*pCurrData);
		pCurrData++;
		BuyPriceRate = *(int*)pCurrData;
		pCurrData += 4;
		SellPriceRate = *(int*)pCurrData;
		pCurrData += 4;
		AddFavorA = *(int*)pCurrData;
		pCurrData += 4;
		AddFavorB = *(int*)pCurrData;
		pCurrData += 4;
		IsBuy = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
