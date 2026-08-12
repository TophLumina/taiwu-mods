using System;
using GameData.Serializer;

namespace Config;

[Serializable]
public struct NeedTrick(sbyte type, byte count) : ISerializableGameData
{
	public sbyte TrickType = type;

	public byte NeedCount = count;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)TrickType;
		byte* num = pData + 1;
		*num = NeedCount;
		return (int)(num + 1 + 2 - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TrickType = (sbyte)(*pCurrData);
		pCurrData++;
		NeedCount = *pCurrData;
		pCurrData++;
		pCurrData += 2;
		return (int)(pCurrData - pData);
	}
}
