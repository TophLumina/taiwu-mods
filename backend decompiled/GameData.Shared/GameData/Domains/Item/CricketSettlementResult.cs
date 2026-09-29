using GameData.Serializer;

namespace GameData.Domains.Item;

[SerializableGameData(NotForArchive = true)]
public class CricketSettlementResult : ISerializableGameData
{
	[SerializableGameDataField]
	public bool TaiwuWin;

	[SerializableGameDataField]
	public Wager ExtraWager = Wager.Invalid;

	public CricketSettlementResult()
	{
	}

	public CricketSettlementResult(CricketSettlementResult other)
	{
		TaiwuWin = other.TaiwuWin;
		ExtraWager = other.ExtraWager;
	}

	public void Assign(CricketSettlementResult other)
	{
		TaiwuWin = other.TaiwuWin;
		ExtraWager = other.ExtraWager;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 21;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (TaiwuWin ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += ExtraWager.Serialize(pCurrData);
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
		TaiwuWin = *pCurrData != 0;
		pCurrData++;
		pCurrData += ExtraWager.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
