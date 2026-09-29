using GameData.Serializer;

namespace GameData.Domains.Building;

public struct Chicken : ISerializableGameData
{
	public const sbyte HappinessMin = 0;

	public const sbyte HappinessMax = 100;

	public const sbyte AutoFeedHappiness = 50;

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public int CurrentSettlementId;

	[SerializableGameDataField]
	public sbyte Happiness;

	[SerializableGameDataField]
	public bool CanPluckFeather;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = Id;
		byte* num = pData + 4;
		*(short*)num = TemplateId;
		byte* num2 = num + 2;
		*(int*)num2 = CurrentSettlementId;
		byte* num3 = num2 + 4;
		*num3 = (byte)Happiness;
		byte* num4 = num3 + 1;
		*num4 = (CanPluckFeather ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num4 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Id = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CurrentSettlementId = *(int*)pCurrData;
		pCurrData += 4;
		Happiness = (sbyte)(*pCurrData);
		pCurrData++;
		CanPluckFeather = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
