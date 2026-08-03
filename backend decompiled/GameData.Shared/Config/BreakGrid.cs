using System;
using GameData.Serializer;

namespace Config;

[Serializable]
public struct BreakGrid(short bonusType, sbyte gridCount) : ISerializableGameData
{
	public short BonusType = bonusType;

	public sbyte GridCount = gridCount;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 3;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = BonusType;
		byte* num = pData + 2;
		*num = (byte)GridCount;
		return (int)(num + 1 - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		BonusType = *(short*)pCurrData;
		pCurrData += 2;
		GridCount = (sbyte)(*pCurrData);
		pCurrData++;
		return (int)(pCurrData - pData);
	}
}
