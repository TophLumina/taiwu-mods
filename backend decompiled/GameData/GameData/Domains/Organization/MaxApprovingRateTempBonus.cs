using GameData.Serializer;

namespace GameData.Domains.Organization;

[SerializableGameData(NotForDisplayModule = true)]
public struct MaxApprovingRateTempBonus(short settlementId, short bonus, int expireDate) : ISerializableGameData
{
	[SerializableGameDataField]
	public short SettlementId = settlementId;

	[SerializableGameDataField]
	public short Bonus = bonus;

	[SerializableGameDataField]
	public int ExpireDate = expireDate;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = SettlementId;
		pCurrData += 2;
		*(short*)pCurrData = Bonus;
		pCurrData += 2;
		*(int*)pCurrData = ExpireDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SettlementId = *(short*)pCurrData;
		pCurrData += 2;
		Bonus = *(short*)pCurrData;
		pCurrData += 2;
		ExpireDate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
