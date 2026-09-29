using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct ChangeTrickDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool CanChangeTrick;

	[SerializableGameDataField]
	public sbyte CostCount;

	[SerializableGameDataField]
	public short AddHitRate;

	[SerializableGameDataField]
	public short AddBreakBlock;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (CanChangeTrick ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*num = (byte)CostCount;
		byte* num2 = num + 1;
		*(short*)num2 = AddHitRate;
		byte* num3 = num2 + 2;
		*(short*)num3 = AddBreakBlock;
		int totalSize = (int)(num3 + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		CanChangeTrick = *pCurrData != 0;
		pCurrData++;
		CostCount = (sbyte)(*pCurrData);
		pCurrData++;
		AddHitRate = *(short*)pCurrData;
		pCurrData += 2;
		AddBreakBlock = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
