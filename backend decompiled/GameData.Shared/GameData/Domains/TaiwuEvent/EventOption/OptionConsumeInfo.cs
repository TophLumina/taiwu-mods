using System;
using GameData.Serializer;

namespace GameData.Domains.TaiwuEvent.EventOption;

[Serializable]
[SerializableGameData(NotForDisplayModule = true)]
public struct OptionConsumeInfo(sbyte type, int count, bool auto) : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte ConsumeType = type;

	[SerializableGameDataField]
	public int ConsumeCount = count;

	[SerializableGameDataField]
	public int HoldCount = 0;

	[SerializableGameDataField]
	public bool HasEnough = false;

	public bool AutoConsume = auto;

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
		*pData = (byte)ConsumeType;
		byte* num = pData + 1;
		*(int*)num = ConsumeCount;
		byte* num2 = num + 4;
		*(int*)num2 = HoldCount;
		byte* num3 = num2 + 4;
		*num3 = (HasEnough ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num3 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ConsumeType = (sbyte)(*pCurrData);
		pCurrData++;
		ConsumeCount = *(int*)pCurrData;
		pCurrData += 4;
		HoldCount = *(int*)pCurrData;
		pCurrData += 4;
		HasEnough = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
